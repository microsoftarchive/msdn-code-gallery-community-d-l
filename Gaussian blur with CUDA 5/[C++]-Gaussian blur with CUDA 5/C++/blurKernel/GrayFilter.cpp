#include "stdafx.h"
#include "GrayFilter.h"

using namespace Bisque;

using cv::Mat;
using cv::cvtColor;
using cv::imread;
using cv::imwrite;

using std::cout;
using std::endl;
using std::function;
using std::exception;
using std::runtime_error;

using std::chrono::duration_cast;
using std::chrono::milliseconds;
using std::chrono::microseconds;
using std::chrono::high_resolution_clock;
using std::chrono::time_point;

// Forward declarations
void RunRGBAtoGrayKernel(
		unsigned char*	gray,				// gray image: 1 byte per image --> this will be returned from this function
		uchar4*			rgba,				// rgba image: 4 bytes per image
		int				rows,				// image size: number of rows
		int				cols				// image size: number of columns
	);

// Ctor
GrayFilter::GrayFilter(void)
{
	m_device.gray = nullptr;
	m_device.originalImage = nullptr;
}

GrayFilter::~GrayFilter(void)
{
}

// Converts r8g8b8a8 image to one channel gray
void GrayFilter::ApplyFilter(const string& imagePath, const string& outputPath)
{
    const char* func = "GrayFilter::ApplyFilter";

	cudaError hr = cudaSuccess;

	time_point<high_resolution_clock> start;
	time_point<high_resolution_clock> stop;

	// Load image and initialize kernel
	KernelMap host;

	start = high_resolution_clock::now();

	InitializeKernel(host, imagePath);

	stop = high_resolution_clock::now();
	long long ms = duration_cast<milliseconds>(stop - start).count();
	long long us = duration_cast<microseconds>(stop - start).count();

	cout << "InitializeKernel executed in " << us << "us (" << ms << "ms)" << endl;

	// Run kernel: convert rgba image to gray
	start = high_resolution_clock::now();

	GpuTimer gpuTimer;
	gpuTimer.Start();

	RunRGBAtoGrayKernel(
		m_device.gray, 
		m_device.originalImage, 
		m_host.originalImage.rows, 
		m_host.originalImage.cols
		);

	gpuTimer.Stop();

	stop = high_resolution_clock::now();
	ms = duration_cast<milliseconds>(stop - start).count();
	us = duration_cast<microseconds>(stop - start).count();

	cout << "RunRGBAtoGrayKernel executed in " << us << "us (" << ms << "ms); gpu time: " << gpuTimer.Elapsed() << "ms" << endl;

	// Save gray image to disk
	start = high_resolution_clock::now();

	SaveGrayImageToDisk(outputPath);

	stop = high_resolution_clock::now();
	ms = duration_cast<milliseconds>(stop - start).count();
	us = duration_cast<microseconds>(stop - start).count();

	cout << "SaveGrayImageToDisk executed in " << us << "us (" << ms << "ms)" << endl;

#if 1			// Change to 1 to enable
	// Validate GPU convertion against CPU result.
	// Only turn it when you want to run validation because CPU calculation will be slow.
	VerifyGpuComputation(host.originalImage);
#endif

	// Release cuda
	hr = cudaFree(m_device.gray);
	hr = cudaFree(m_device.originalImage);
}

// Loads image from the disk and allocates memory for original and modified images on the host and the device.
void GrayFilter::InitializeKernel(KernelMap& host, const string& imagePath)
{
    const char* func = "GrayFilter::InitializeKernel";
	CV_FUNCNAME("GrayFilter::InitializeKernel");
	__CV_BEGIN__

	cudaError hr = cudaFree(nullptr);																							CHECK_CUDA_ERROR(hr, func, "Could not free CUDA memory space.");

	// Load image
	Mat image = imread(imagePath.c_str(), CV_LOAD_IMAGE_COLOR);
	if (image.empty())
	{
		string msg = "Could not open image file: " + imagePath;
		throw runtime_error(msg);
	}

	// Convert image from BGR to RGB
	cvtColor(image, m_host.originalImage, CV_BGR2RGBA);

	// Allocate memory for the gray image (on the host)
	m_host.modifiedImage.create(image.rows, image.cols, CV_8UC1);

	CV_ASSERT(m_host.originalImage.isContinuous());
	CV_ASSERT(m_host.modifiedImage.isContinuous());

	host.originalImage = reinterpret_cast<uchar4*>(m_host.originalImage.ptr<unsigned char>(0));
	host.gray = m_host.modifiedImage.ptr<unsigned char>(0);

	const int numPixels = m_host.originalImage.rows * m_host.originalImage.cols;

	// Allocate memory on the device for both rgba and gray images, 
	// then fill gray image with zeros to make sure there is no memory left laying around.
	// Finally, copy rgba image to the GPU.
	hr = cudaMalloc(&m_device.originalImage, numPixels * sizeof(uchar4));														CHECK_CUDA_ERROR(hr, func, "Could not allocate device memory for RGBA image.");
	hr = cudaMalloc(&m_device.gray,			 numPixels * sizeof(unsigned char));												CHECK_CUDA_ERROR(hr, func, "Could not allocate device memory for gray image.");
	hr = cudaMemset( m_device.gray, 0,		 numPixels * sizeof(unsigned char));												CHECK_CUDA_ERROR(hr, func, "Could not fill gray image with constant values.");
	hr = cudaMemcpy( m_device.originalImage, host.originalImage, numPixels * sizeof(uchar4), cudaMemcpyHostToDevice);				CHECK_CUDA_ERROR(hr, func, "Could not copy rgba image from host to device.");

	__CV_END__
}

// Copies gray image from device to the host and saves it to disk
void GrayFilter::SaveGrayImageToDisk(const string& outputPath)
{
    const char* func = "GrayFilter::SaveGrayImageToDisk";
	cudaError hr = cudaSuccess;

	const int numPixels = m_host.originalImage.rows * m_host.originalImage.cols;

	// Copy gray image from device to the host
	hr = cudaMemcpy(
		m_host.modifiedImage.ptr<unsigned char>(0), 
		m_device.gray,
		numPixels * sizeof(unsigned char),
		cudaMemcpyDeviceToHost
		);																														CHECK_CUDA_ERROR(hr, func, "Could not copy gray image from device to the host.");

	// Save image to disk
	imwrite(outputPath.c_str(), m_host.modifiedImage);
}

// Verifies correctness of the GPU computation running the same algorithm on the CPU
// and comparing pixel values. 
//
// NOTE: Because we recompute pixels on the CPU, call this function only when you need
//		 to validate GPU computation.
void GrayFilter::VerifyGpuComputation(const uchar4* const rgba)
{
    const char* func = "GrayFilter::VerifyGpuComputation";
	cudaError hr = cudaSuccess;

	const int numPixels = m_host.originalImage.rows * m_host.originalImage.cols;
	unsigned char* gpu = new unsigned char[numPixels];				// image computed on GPU
	unsigned char* ref = new unsigned char[numPixels];				// reference image that will be computed on CPU

	// Copy device gray image to the host
	hr = cudaMemcpy(
		gpu, 
		m_device.gray, 
		numPixels * sizeof(unsigned char), 
		cudaMemcpyDeviceToHost
		);																									CHECK_CUDA_ERROR(hr, func, "Could not copy gray image from device to the host.");

	// Copmute gray image on the CPU
	time_point<high_resolution_clock> start = high_resolution_clock::now();
	time_point<high_resolution_clock> stop  = high_resolution_clock::now();

	RGBAtoGrayOnCPU(ref, rgba, m_host.originalImage.rows, m_host.originalImage.cols);

	stop = high_resolution_clock::now();
	long long ms = duration_cast<milliseconds>(stop - start).count();
	long long us = duration_cast<microseconds>(stop - start).count();

	cout << "RGBAtoGrayOnCPU executed in " << us << "us (" << ms << "ms)" << endl;

	// Compare results
	// NOTE: Since this sample works with 8-bit images and ranges of colors between 1 and 255 per channel,
	//		 we only allow color to differ by value of 1 between GPU and CPU computations.
	//		 As this is a gray image with only one channel of color intensity, we allow intensity error
	//		 to be no more than 1 between the same pixel in GPU and CPU images, and total percent of errors
	//		 is expected not to be higher than 0.001
	Utilities::CheckGpuComputationEps(ref, gpu, numPixels, 1, .001);
	//Utilities::CheckGpuComputationExact(ref, gpu, numPixels);
	//Utilities::CheckGpuComputationAutodesk(ref, gpu, numPixels, 1.0, 100);

	// Clean up
	delete[] gpu;
	delete[] ref;
}

// Converts RGBA image to grayscale intensity on CPU.
// NOTE: This is a reference computation for validating results on GPU.
//		 Otherwise, do not call this function.
void GrayFilter::RGBAtoGrayOnCPU(unsigned char* gray, const uchar4* const rgba, int rows, int cols)
{
	for (int r = 0; r < rows; ++r)
	{
		for (int c = 0; c < cols; ++c)
		{
			int	   idx		 = c + cols * r;		// current pixel index
			uchar4 pixel	 = rgba[idx];
			float  intensity = 0.2126f * pixel.x + 0.7152f * pixel.y + 0.0722f * pixel.z;

			gray[idx]		 = static_cast<unsigned char>(intensity);
		}
	}
}
