//-----------------------------------------------------------------------------
// File: ImageKernel.cu
// http://people.csail.mit.edu/sparis/bf_course/slides08/03_definition_bf.pdf
// http://www.swageroo.com/wordpress/how-to-program-a-gaussian-blur-without-using-3rd-party-libraries/
// http://rastergrid.com/blog/2010/09/efficient-gaussian-blur-with-linear-sampling/
//
// Desc: 
//
// The Gaussian blur is a type of image-blurring filter that uses a Gaussian function (which also expresses the normal distribution in statistics) 
// for calculating the transformation to apply to each pixel in the image. In two dimensions, it is the product of two Gaussians, one in each dimension.
// In the formula, x is the distance from the origin in the horizontal axis, y is the distance from the origin in the vertical axis, 
// and σ is the standard deviation of the Gaussian distribution. When applied in two dimensions, this formula produces a surface 
// whose contours are concentric circles with a Gaussian distribution from the center point. Values from this distribution are used 
// to build a convolution matrix which is applied to the original image. Each pixel's new value is set to a weighted average of that 
// pixel's neighborhood. The original pixel's value receives the heaviest weight (having the highest Gaussian value) and neighboring pixels 
// receive smaller weights as their distance to the original pixel increases. This results in a blur that preserves boundaries and edges 
// better than other, more uniform blurring filters; see also scale space implementation.	 
// Ref: http://en.wikipedia.org/wiki/Gaussian_blur
//
//-----------------------------------------------------------------------------

#include "stdafx.h"
#include "Utilities.h"
#include "BlurFilter.h"

using namespace Bisque;

// Convolution kernel. Must be called once for each channel: red, green, blue.
__global__ 
void gaussian_blur(
	unsigned char* const		blurredChannel,						// return value: blurred channel (either red, green, or blue)
	const unsigned char* const	inputChannel,						// red, green, or blue channel from the original image
	int							rows, 
	int							cols,
	const float* const			filterWeight,						// gaussian filter weights. The weights look like a bell shape.
	int							filterWidth							// number of pixels in x and y directions for calculating average blurring
	)
{
	int r			=  blockIdx.y * blockDim.y + threadIdx.y;		// current row
	int c			=  blockIdx.x * blockDim.x + threadIdx.x;		// current column


	if ((r >= rows) || (c >= cols))
	{
		return;
	}

	int			  half   = filterWidth / 2;
	float		  blur   = 0.f;								// will contained blurred value
	int			  width  = cols - 1;
	int			  height = rows - 1;

	for (int i = -half; i <= half; ++i)					// rows
	{
		for (int j = -half; j <= half; ++j)				// columns
		{
			// Clamp filter to the image border
			int		h		= min(max(r + i, 0), height);
			int		w		= min(max(c + j, 0), width);

			// Blur is a product of current pixel value and weight of that pixel.
			// Remember that sum of all weights equals to 1, so we are averaging sum of all pixels by their weight.
			int		idx		= w + cols * h;											// current pixel index
			float	pixel	= static_cast<float>(inputChannel[idx]);

					idx		= (i + half) * filterWidth + j + half;
			float	weight	= filterWeight[idx];

			blur += pixel * weight;
		}
	}

	blurredChannel[c + r * cols] = static_cast<unsigned char>(blur);
}

// Recombines red, green, and blue channels into an RGB image.
// Alpha channel is set to 255 or opaque.
__global__
void gaussian_recombine_channels(
	uchar4* const				rgba,
	const unsigned char* const	red,
	const unsigned char* const	green,
	const unsigned char* const	blue,
	int							rows,
	int							cols
	)
{
	int x			=  blockIdx.y * blockDim.y + threadIdx.y;		// current row
	int y			=  blockIdx.x * blockDim.x + threadIdx.x;		// current column

	if ((x >= rows) || (y >= cols))
	{
		return;
	}

	int idx			= y + cols * x;		// current pixel index

	// Copy channels to the local variables
	unsigned char r = red[idx];
	unsigned char g = green[idx];
	unsigned char b = blue[idx];

	// Combine, setting alpha to 255
	uchar4 pixel = make_uchar4(r, g, b, 255);

	// Update image
	rgba[idx] = pixel;
}

// Kernel separates rgba image into red, green, blue channels
__global__ 
void gaussian_separate_channels(
	unsigned char* const red, 
	unsigned char* const green, 
	unsigned char* const blue, 
	const uchar4* const  rgba, 
	int					 rows, 
	int					 cols
	)
{
	int r			=  blockIdx.y * blockDim.y + threadIdx.y;		// current row
	int c			=  blockIdx.x * blockDim.x + threadIdx.x;		// current column

	if ((r >= rows) || (c >= cols))
	{
		return;
	}

	int idx			= c + cols * r;		// current pixel index

	red  [idx]		= rgba[idx].x;
	green[idx]		= rgba[idx].y;
	blue [idx]		= rgba[idx].z;
}

// Applies gaussian blur to an r8g8b8a8 image.
// Returns blurredimage.
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
	)
{
	const char* func = "RunGaussianBlurKernel";

	cudaError hr = cudaSuccess;

	static const int BLOCK_WIDTH = 32;						// threads per block; because we are setting 2-dimensional block, the total number of threads is 32^2, or 1024
															// 1024 is the maximum number of threads per block for modern GPUs.

	int x = static_cast<int>(ceilf(static_cast<float>(cols) / BLOCK_WIDTH));
	int y = static_cast<int>(ceilf(static_cast<float>(rows) / BLOCK_WIDTH));

	const dim3 grid (x, y, 1);								// number of blocks
	const dim3 block(BLOCK_WIDTH, BLOCK_WIDTH, 1);			// block width: number of threads per block

	// Separate RGBA image into different color channels
	gaussian_separate_channels<<<grid, block>>>(
		red,
		green,
		blue,
		originalImage, 
		rows, 
		cols
		);
		
	hr = cudaDeviceSynchronize();																CHECK_CUDA_ERROR(hr, func, "separate_channels kernel failed.");

	// Call convolution kernel for the total of 3 times, once for each channel
	gaussian_blur<<<grid, block>>>(
		redBlurred,
		red,
		rows,
		cols,
		filterWeight,
		filterWidth
		);

	hr = cudaDeviceSynchronize();																CHECK_CUDA_ERROR(hr, func, "gaussian_blur kernel failed - red channel");

	gaussian_blur<<<grid, block>>>(
		greenBlurred,
		green,
		rows,
		cols,
		filterWeight,
		filterWidth
		);

	hr = cudaDeviceSynchronize();																CHECK_CUDA_ERROR(hr, func, "gaussian_blur kernel failed - green channel");

	gaussian_blur<<<grid, block>>>(
		blueBlurred,
		blue,
		rows,
		cols,
		filterWeight,
		filterWidth
		);

	hr = cudaDeviceSynchronize();																CHECK_CUDA_ERROR(hr, func, "gaussian_blur kernel failed - blue channel");

	// Recombine red, green,and blue channels into an RGB image
	gaussian_recombine_channels<<<grid, block>>>(
		blurredImage,
		redBlurred,
		greenBlurred,
		blueBlurred,
		rows,
		cols
		);

	hr = cudaDeviceSynchronize();																CHECK_CUDA_ERROR(hr, func, "gaussian_recombine_channels kernel failed.");
}
