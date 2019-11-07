//-----------------------------------------------------------------------------
// File: BlurFilter.h
//
// Desc: Applies blurring ffects to an image.
//
//-----------------------------------------------------------------------------

#pragma once

namespace Bisque
{
	using cv::Mat;
	using std::function;
	using std::string;
	using std::vector;

	// class BlurFilter
	class BlurFilter
	{
	public:
		BlurFilter(void);
		~BlurFilter(void);

		void GaussianBlur(const string& imagePath, const string& outputPath);

	private:
		// struct ImageHandle: handles to images on the host
		struct ImageHandle
		{
			Mat originalImage;					// handle to a rgba image
			Mat modifiedImage;					// handle to a modified image
		};

		// struct GuassianFilter: weighted coefficients for gaussian blur function
		struct GaussianFilter
		{
			vector<float> weight;				// array of weights
			int			  width;				// filter width
		};

		// struct KernelMap: pointers to device representations of images
		struct KernelMap
		{
			uchar4*			originalImage;				// rgba image: 4 bytes per image
			uchar4*			modifiedImage;				// modified image
			unsigned char*	red;						// red channel of the original image
			unsigned char*	green;
			unsigned char*	blue;
			unsigned char*	redBlurred;					// red channel of the modified image
			unsigned char*	greenBlurred;
			unsigned char*	blueBlurred;
			float*			filter;						// gaussian filter
		};

	private:
		void AllocateChannels		();
		void ComputeConvolutionOnCPU(unsigned char* const blurredChannel, const unsigned char* const inputChannel, int rows, int cols);
		void CreateGaussianFilter	();
		void GaussianBlurOnCPU		(uchar4* const modifiedImage, const uchar4* const originalImage, int rows, int cols);
		void InitializeKernel		(KernelMap& host, const string& imagePath);
		void SaveImageToDisk		(const string& imagePath);
		void VerifyGpuComputation	(const uchar4* const originalImage);

	private:
		KernelMap		m_device;
		ImageHandle		m_host;
		GaussianFilter	m_filter;
	};
}
