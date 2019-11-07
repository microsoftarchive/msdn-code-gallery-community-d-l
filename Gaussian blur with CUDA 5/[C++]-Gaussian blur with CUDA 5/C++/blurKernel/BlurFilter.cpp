#include "stdafx.h"
#include "BlurFilter.h"

using namespace Bisque;

using cv::Mat;
using cv::cvtColor;
using cv::imread;
using cv::imwrite;

using std::cout;
using std::endl;
using std::expf;
using std::exception;
using std::runtime_error;

using std::chrono::duration_cast;
using std::chrono::milliseconds;
using std::chrono::microseconds;
using std::chrono::high_resolution_clock;
using std::chrono::time_point;

// Forward declarations
void RunGaussianBlurKernel(
	uchar4* const			blurredImage,					// Return value: blurred rgba image with alpha set to 255 or opaque.
	const uchar4* const		originalImage,
	unsigned char* const	red,							// red channel from the original image
	unsigned char* const	green,							// green channel from the original image
	unsigned char* const	blue,							// blue channel from the original image
	unsigned char* const	redBlurred,						// red channel from the blurred image
	unsigned char* const	greenBlurred,					// green channel from the blurred image
	unsigned char* const	blueBlurred,					// blue channel from the blurred image
	const float* const		filterWeight,					// gaussian filter weights. The weights look like a bell shape.
	int						filterWidth,					// number of pixels in x and y directions for calculating average blurring
	int						rows,							// image size: number of rows
	int						cols							// image size: number of columns
	);

// Ctor
BlurFilter::BlurFilter(void)
{
	m_device.modifiedImage = nullptr;
	m_device.originalImage = nullptr;
}

BlurFilter::~BlurFilter(void)
{
}

// Allocates red, green, and blue channels of both original and modified images on the device.
// Also, allocates guassian filter on the device.
void BlurFilter::AllocateChannels()
{
    const char* func = "BlurFilter::AllocateChannels";
	cudaError hr = cudaSuccess;

	size_t size = m_host.originalImage.rows * m_host.originalImage.cols * sizeof(unsigned char);

	// Original image
	hr = cudaMalloc(&m_device.blue, size);																CHECK_CUDA_ERROR(hr, func, "Could not allocate device memory for the original image blue channel.");
	hr = cudaMalloc(&m_device.green, size);																CHECK_CUDA_ERROR(hr, func, "Could not allocate device memory for the original image green channel.");
	hr = cudaMalloc(&m_device.red, size);																CHECK_CUDA_ERROR(hr, func, "Could not allocate device memory for the original image red channel.");

	// Blurred image
	hr = cudaMalloc(&m_device.blueBlurred, size);														CHECK_CUDA_ERROR(hr, func, "Could not allocate device memory for the modified image blue channel.");
	hr = cudaMalloc(&m_device.greenBlurred, size);														CHECK_CUDA_ERROR(hr, func, "Could not allocate device memory for the modified image green channel.");
	hr = cudaMalloc(&m_device.redBlurred, size);														CHECK_CUDA_ERROR(hr, func, "Could not allocate device memory for the modified image red channel.");

	// Filter
	size = m_filter.weight.size() * sizeof(float);

	hr = cudaMalloc(&m_device.filter, size);															CHECK_CUDA_ERROR(hr, func, "Could not allocate device memory for gaussian filter.");
	hr = cudaMemcpy(m_device.filter, &m_filter.weight[0], size, cudaMemcpyHostToDevice);				CHECK_CUDA_ERROR(hr, func, "Could not copy gaussian filter date from host to device.");
}

// Creates gaussian filter based on G(x,y) formula: http://en.wikipedia.org/wiki/Gaussian_blur.
void BlurFilter::CreateGaussianFilter()
{
	const int   width	= 9;				// This is stencil width, or how many pixels in each row or column should we include in blurring function. SHould be odd.
	const float sigma	= 2.f;				// Standard deviation of the Gaussian distribution.

	const int	half	= width / 2;
	float		sum		= 0.f;

	m_filter.width = width;

	// Create convolution matrix
	m_filter.weight.resize(width * width);

	// Calculate filter sum first
	for (int r = -half; r <= half; ++r)
	{
		for (int c = -half; c <= half; ++c)
		{
			// e (natural logarithm base) to the power x, where x is what's in the brackets
			float weight = expf(-static_cast<float>(c * c + r * r) / (2.f * sigma * sigma));
			int idx = (r + half) * width + c + half;

			m_filter.weight[idx] = weight;
			sum += weight;
		}
	}

	// Normalize weight: sum of weights must equal 1
	float normal = 1.f / sum;

	for (int r = -half; r <= half; ++r)
	{
		for (int c = -half; c <= half; ++c)
		{
			int idx = (r + half) * width + c + half;

			m_filter.weight[idx] *= normal;
		}
	}
}

// Applies gaussian blur to an image
void BlurFilter::GaussianBlur(const string& imagePath, const string& outputPath)
{
    const char* func = "BlurFilter::GaussianBlur";

	cudaError hr = cudaSuccess;

	time_point<high_resolution_clock> start;
	time_point<high_resolution_clock> stop;

	// Load image and initialize kernel
	KernelMap host;

	start = high_resolution_clock::now();

	InitializeKernel(host, imagePath);
	CreateGaussianFilter();
	AllocateChannels();

	stop = high_resolution_clock::now();
	long long ms = duration_cast<milliseconds>(stop - start).count();
	long long us = duration_cast<microseconds>(stop - start).count();

	cout << "InitializeKernel executed in " << us << "us (" << ms << "ms)" << endl;

	// Run kernel: convert rgba image to modifiedImage
	start = high_resolution_clock::now();

	GpuTimer gpuTimer;
	gpuTimer.Start();

	RunGaussianBlurKernel(
		m_device.modifiedImage,
		m_device.originalImage, 
		m_device.red,
		m_device.green,
		m_device.blue,
		m_device.redBlurred,
		m_device.greenBlurred,
		m_device.blueBlurred,
		m_device.filter,
		m_filter.width,
		m_host.originalImage.rows, 
		m_host.originalImage.cols
		);

	gpuTimer.Stop();

	stop = high_resolution_clock::now();
	ms = duration_cast<milliseconds>(stop - start).count();
	us = duration_cast<microseconds>(stop - start).count();

	cout << "RunGaussianBlurKernel executed in " << us << "us (" << ms << "ms); gpu time: " << gpuTimer.Elapsed() << "ms" << endl;

	// Save modifiedImage image to disk
	start = high_resolution_clock::now();

	SaveImageToDisk(outputPath);

	stop = high_resolution_clock::now();
	ms = duration_cast<milliseconds>(stop - start).count();
	us = duration_cast<microseconds>(stop - start).count();

	cout << "SaveImageToDisk executed in " << us << "us (" << ms << "ms)" << endl;

#if 0			// Change to 1 to enable
	// Validate GPU convertion against CPU result.
	// Only turn it when you want to run validation because CPU calculation will be slow.
	VerifyGpuComputation(host.originalImage);
#endif

	// Release cuda
	hr = cudaFree(m_device.modifiedImage);
	hr = cudaFree(m_device.originalImage);
}

// Loads image from the disk and allocates memory for original and modified images on the host and the device.
void BlurFilter::InitializeKernel(KernelMap& host, const string& imagePath)
{
    const char* func = "BlurFilter::InitializeKernel";
	CV_FUNCNAME("BlurFilter::InitializeKernel");
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

	// Allocate memory for the modified image (on the host)
	m_host.modifiedImage.create(image.rows, image.cols, CV_8UC4);				// 8-bit unsigned character times 4

	CV_ASSERT(m_host.originalImage.isContinuous());
	CV_ASSERT(m_host.modifiedImage.isContinuous());

	host.originalImage = reinterpret_cast<uchar4*>(m_host.originalImage.ptr<unsigned char>(0));
	host.modifiedImage = reinterpret_cast<uchar4*>(m_host.modifiedImage.ptr<unsigned char>(0));

	const int numPixels = m_host.originalImage.rows * m_host.originalImage.cols;
	const size_t size = numPixels * sizeof(uchar4);

	// Allocate memory on the device for both rgba and modifiedImage images, 
	// then fill modifiedImage image with zeros to make sure there is no memory left laying around.
	// Finally, copy rgba image to the GPU.
	hr = cudaMalloc(&m_device.originalImage,	size);																			CHECK_CUDA_ERROR(hr, func, "Could not allocate device memory for RGBA image.");
	hr = cudaMalloc(&m_device.modifiedImage,	size);																			CHECK_CUDA_ERROR(hr, func, "Could not allocate device memory for blurred image.");
	hr = cudaMemset( m_device.modifiedImage, 0, size);																			CHECK_CUDA_ERROR(hr, func, "Could not fill blurred image with constant values.");
	hr = cudaMemcpy( m_device.originalImage, host.originalImage, size, cudaMemcpyHostToDevice);									CHECK_CUDA_ERROR(hr, func, "Could not copy rgba image from host to device.");

	__CV_END__
}

// Copies modified image from device to the host and saves it to disk
void BlurFilter::SaveImageToDisk(const string& outputPath)
{
    const char* func = "BlurFilter::SaveImageToDisk";
	cudaError hr = cudaSuccess;

	const int numPixels = m_host.originalImage.rows * m_host.originalImage.cols;

	// Copy image from device to the host
	hr = cudaMemcpy(
		m_host.modifiedImage.ptr<uchar4>(0), 
		m_device.modifiedImage,
		numPixels * sizeof(uchar4),
		cudaMemcpyDeviceToHost
		);																														CHECK_CUDA_ERROR(hr, func, "Could not copy gray image from device to the host.");

	// Convert RGBA to BGRA
	Mat bgra;
	cvtColor(m_host.modifiedImage, bgra, CV_RGBA2BGRA);

	// Save image to disk
	imwrite(outputPath.c_str(), bgra);
}

// Verifies correctness of the GPU computation running the same algorithm on the CPU
// and comparing pixel values. 
//
// NOTE: Because we recompute pixels on the CPU, call this function only when you need
//		 to validate GPU computation.
void BlurFilter::VerifyGpuComputation(const uchar4* const rgba)
{
    const char* func = "BlurFilter::VerifyGpuComputation";
	cudaError hr = cudaSuccess;

	const int numPixels = m_host.originalImage.rows * m_host.originalImage.cols;

	uchar4* gpu = new uchar4[numPixels];				// image computed on GPU
	uchar4* ref = new uchar4[numPixels];				// reference image that will be computed on CPU

	// Copy device modifiedImage image to the host
	hr = cudaMemcpy(
		gpu, 
		m_device.modifiedImage, 
		numPixels * sizeof(uchar4), 
		cudaMemcpyDeviceToHost
		);																							CHECK_CUDA_ERROR(hr, func, "Could not copy modifiedImage image from device to the host.");

	// Copmute gray image on the CPU
	time_point<high_resolution_clock> start = high_resolution_clock::now();
	time_point<high_resolution_clock> stop  = high_resolution_clock::now();

	GaussianBlurOnCPU(ref, rgba, m_host.originalImage.rows, m_host.originalImage.cols);

	stop = high_resolution_clock::now();
	long long ms = duration_cast<milliseconds>(stop - start).count();
	long long us = duration_cast<microseconds>(stop - start).count();

	cout << "GaussianBlurOnCPU executed in " << us << "us (" << ms << "ms)" << endl;

	// Compare results
	// NOTE: Since this sample works with 8-bit images and ranges of colors between 1 and 255 per channel,
	//		 we only allow color to differ by value of 1 between GPU and CPU computations.
	//		 As this is a gray image with only one channel of color intensity, we allow intensity error
	//		 to be no more than 1 between the same pixel in GPU and CPU images, and total percent of errors
	//		 is expected not to be higher than 0.001
	Utilities::CheckGpuComputationEps(reinterpret_cast<unsigned char*>(ref), reinterpret_cast<unsigned char*>(gpu), numPixels * 4, 1, .001);
	//Utilities::CheckGpuComputationExact(reinterpret_cast<unsigned char*>(ref), reinterpret_cast<unsigned char*>(gpu), numPixels * 4);		// time 4, becuse there are 4 channels in uchar4
	//Utilities::CheckGpuComputationAutodesk(ref, gpu, numPixels, 1.0, 100);

	// Clean up
	delete[] gpu;
	delete[] ref;
}

// Converts RGBA image to grayscale intensity on CPU.
// NOTE: This is a reference computation for validating results on GPU.
//		 Otherwise, do not call this function.
void BlurFilter::GaussianBlurOnCPU(uchar4* const modifiedImage, const uchar4* const rgba, int rows, int cols)
{
	const int numPixels = rows * cols;
	
	// Create channel variables
	unsigned char* red			= new unsigned char[numPixels];
	unsigned char* green		= new unsigned char[numPixels];
	unsigned char* blue			= new unsigned char[numPixels];

	unsigned char* redBlurred	= new unsigned char[numPixels];
	unsigned char* greenBlurred = new unsigned char[numPixels];
	unsigned char* blueBlurred	= new unsigned char[numPixels];

	// Separate RGBAimage into red, green, and blue components
	for (int p = 0; p < numPixels; ++p)
	{
		uchar4 pixel = rgba[p];

		red[p]	 = pixel.x;
		green[p] = pixel.y;
		blue [p] = pixel.z;
	}

	// Compute convolution for each individual channel
	ComputeConvolutionOnCPU(redBlurred, red, rows, cols);
	ComputeConvolutionOnCPU(greenBlurred, green, rows, cols);
	ComputeConvolutionOnCPU(blueBlurred, blue, rows, cols);

	// Recombine channels back into an RGBAimage setting alpha to 255, or fully opaque
	for (int p = 0; p < numPixels; ++p)
	{
		unsigned char r = redBlurred[p];
		unsigned char g = greenBlurred[p];
		unsigned char b = blueBlurred[p];

		modifiedImage[p] = make_uchar4(r, g, b, 255);
	}

	delete[] red;
	delete[] green;
	delete[] blue;
	delete[] redBlurred;
	delete[] greenBlurred;
	delete[] blueBlurred;
}

// Copmute gaussian blur per channel on the CPU.
// Call this function for each of red, green, and blue channels
// Returns blurred channel.
void BlurFilter::ComputeConvolutionOnCPU(unsigned char* const blurredChannel, const unsigned char* const inputChannel, int rows, int cols)
{
	// Filter width should be odd as we are calculating average blur for a pixel plus some offset in all directions
	assert(m_filter.width % 2 == 1);

	const int half   = m_filter.width / 2;
	const int width  = cols - 1;
	const int height = rows - 1;

	// Compute blur
	for (int r = 0; r < rows; ++r)
	{
		for (int c = 0; c < cols; ++c)
		{
			float blur = 0.f;

			// Average pixel color summing up adjacent pixels.
			for (int i = -half; i <= half; ++i)
			{
				for (int j = -half; j <= half; ++j)
				{
					// Clamp filter to the image border
					int h = min(max(r + i, 0), height);
					int w = min(max(c + j, 0), width);

					// Blur is a product of current pixel value and weight of that pixel.
					// Remember that sum of all weights equals to 1, so we are averaging sum of all pixels by their weight.
					int		idx		= w + cols * h;											// current pixel index
					float	pixel	= static_cast<float>(inputChannel[idx]);

					idx				= (i + half) * m_filter.width + j + half;
					float	weight	= m_filter.weight[idx];

					blur += pixel * weight;
				}
			}

			blurredChannel[c + cols * r] = static_cast<unsigned char>(blur);
		}
	}
}
