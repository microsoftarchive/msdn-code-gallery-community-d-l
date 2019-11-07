//-----------------------------------------------------------------------------
// File: GrayFilter.h
//
// Desc: Converts an image to grayscale intensity.
//
//-----------------------------------------------------------------------------

#pragma once

namespace Bisque
{
	using cv::Mat;
	using std::function;
	using std::string;

	// class GrayFilter
	class GrayFilter
	{
	public:
		GrayFilter(void);
		~GrayFilter(void);

		void ApplyFilter(const string& imagePath, const string& outputPath);

	private:
		// struct ImageHandle: handles to images on the host
		struct ImageHandle
		{
			Mat originalImage;					// handle to a rgba image
			Mat modifiedImage;					// handle to a modified image
		};

		// struct KernelMap: pointers to device representations of images
		struct KernelMap
		{
			uchar4*			originalImage;		// rgba image: 4 bytes per image
			unsigned char*	gray;				// gray image: 1 byte per image
		};

	private:
		void RGBAtoGrayOnCPU		(unsigned char* gray, const uchar4* const originalImage, int rows, int cols);
		void InitializeKernel		(KernelMap& host, const string& imagePath);
		void SaveGrayImageToDisk	(const string& imagePath);
		void VerifyGpuComputation	(const uchar4* const originalImage);

	private:
		KernelMap		m_device;
		ImageHandle		m_host;
	};
}
