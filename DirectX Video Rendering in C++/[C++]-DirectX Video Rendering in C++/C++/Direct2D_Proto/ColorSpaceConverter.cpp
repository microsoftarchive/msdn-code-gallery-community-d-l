#include "stdafx.h"
#include "ColorSpaceConverter.h"

#define clamp(x) max(min(255, x), 0)

static void InitConvertTable()
{
   long int crv,cbu,cgu,cgv;
   int i,ind;   
     
   crv = 104597; cbu = 132201;
   cgu = 25675;  cgv = 53279;
  
   for (i = 0; i < 256; i++) 
   {
      crv_tab[i] = (i-128) * crv;
      cbu_tab[i] = (i-128) * cbu;
      cgu_tab[i] = (i-128) * cgu;
      cgv_tab[i] = (i-128) * cgv;
      tab_76309[i] = 76309*(i-16);
   }
	 
   for (i=0; i<384; i++)
	  clp[i] =0;
   ind=384;
   for (i=0;i<256; i++)
	   clp[ind++]=i;
   ind=640;
   for (i=0;i<384;i++)
	   clp[ind++]=255;
}

static inline void get_rgb_from_yuv(int y, int u, int v, BYTE* r, BYTE* g, BYTE* b)
{
	int c1 = crv_tab[v];
	int c2 = cgu_tab[u];
	int c3 = cgv_tab[v];
	int c4 = cbu_tab[u];

	int y1 = tab_76309[y];	
	*r = clp[384+((y1 + c1)>>16)];  
	*g = clp[384+((y1 - c2 - c3)>>16)];
    *b = clp[384+((y1 + c4)>>16)];
}

static inline void YUV420_to_RGB32(BYTE* src0, BYTE* src1, BYTE* src2, BYTE* dst, int width,int height)
{
	int y1,y2,u,v; 
	unsigned char *py1,*py2;
	int i,j, c1, c2, c3, c4;
	unsigned char *d1, *d2;

	py1 = src0;
	py2 = py1 + width;
	d1 = dst;
	d2 = d1 + 4 * width;
 	for (j = 0; j < height; j += 2)
	{ 
		for (i = 0; i < width; i += 2) 
		{
			u = *src1++;
			v = *src2++;

			c1 = crv_tab[v];
			c2 = cgu_tab[u];
			c3 = cgv_tab[v];
			c4 = cbu_tab[u];

			//up-left
            y1 = tab_76309[*py1++];	
			*d1++ = clp[384+((y1 + c1)>>16)];  
			*d1++ = clp[384+((y1 - c2 - c3)>>16)];
            *d1++ = clp[384+((y1 + c4)>>16)];
			*d1++ = 0xff;

			//down-left
			y2 = tab_76309[*py2++];
			*d2++ = clp[384+((y2 + c1)>>16)];  
			*d2++ = clp[384+((y2 - c2 - c3)>>16)];
            *d2++ = clp[384+((y2 + c4)>>16)];
			*d2++ = 0xff;

			//up-right
			y1 = tab_76309[*py1++];
			*d1++ = clp[384+((y1 + c1)>>16)];  
			*d1++ = clp[384+((y1 - c2 - c3)>>16)];
			*d1++ = clp[384+((y1 + c4)>>16)];
			*d1++ = 0xff;

			//down-right
			y2 = tab_76309[*py2++];
			*d2++ = clp[384+((y2 + c1)>>16)];  
			*d2++ = clp[384+((y2 - c2 - c3)>>16)];
            *d2++ = clp[384+((y2 + c4)>>16)];
			*d2++ = 0xff;
		}

		d1 += 4 * width;
		d2 += 4 * width;
		py1+=   width;
		py2+=   width;
	}       
}

static inline void NV12_to_RGB32(BYTE* luma, BYTE* uv, BYTE* dst, int width, int height)
{
	int y1,y2,u,v; 
	unsigned char *py1,*py2;
	int i,j, c1, c2, c3, c4;
	unsigned char *d1, *d2;

	py1 = luma;
	py2 = py1 + width;
	d1 = dst;
	d2 = d1 + 4 * width;
 	for (j = 0; j < height; j += 2)
	{ 
		for (i = 0; i < width; i += 2) 
		{
			v = *uv++;
			u = *uv++;

			c1 = crv_tab[v];
			c2 = cgu_tab[u];
			c3 = cgv_tab[v];
			c4 = cbu_tab[u];

			//up-left
            y1 = tab_76309[*py1++];	
			*d1++ = clp[384+((y1 + c1)>>16)];  
			*d1++ = clp[384+((y1 - c2 - c3)>>16)];
            *d1++ = clp[384+((y1 + c4)>>16)];
			*d1++ = 0xff;

			//down-left
			y2 = tab_76309[*py2++];
			*d2++ = clp[384+((y2 + c1)>>16)];  
			*d2++ = clp[384+((y2 - c2 - c3)>>16)];
            *d2++ = clp[384+((y2 + c4)>>16)];
			*d2++ = 0xff;

			//up-right
			y1 = tab_76309[*py1++];
			*d1++ = clp[384+((y1 + c1)>>16)];  
			*d1++ = clp[384+((y1 - c2 - c3)>>16)];
			*d1++ = clp[384+((y1 + c4)>>16)];
			*d1++ = 0xff;

			//down-right
			y2 = tab_76309[*py2++];
			*d2++ = clp[384+((y2 + c1)>>16)];  
			*d2++ = clp[384+((y2 - c2 - c3)>>16)];
            *d2++ = clp[384+((y2 + c4)>>16)];
			*d2++ = 0xff;
		}

		d1 += 4 * width;
		d2 += 4 * width;
		py1+=   width;
		py2+=   width;
	}       
}

static inline bool rgb24_to_rgb32(const BYTE* input, BYTE* output, int numOfPixels)
{
	if(!input || !output)
	{
		return false;
	}

	for(int i = 0 ; i < numOfPixels; i++)
	{
		*(output++) = *(input++);
		*(output++) = *(input++);
		*(output++) = *(input++);
		*(output++) = 0xff;            // Alpha = 1
	}

	return true;
}

static inline bool rgb555_to_rgb32(const BYTE* input, BYTE* output, int numOfPixels)
{
	if(!input || !output)
	{
		return false;
	}

	// red pixel   (0111 1100 0000 0000) 0x7C00
    // green pixel (0000 0011 1110 0000) 0x03E0
    // blue pixel  (0000 0000 0001 1111) 0x001F

	USHORT* pPixel = (USHORT*)input;
	for(int i = 0 ; i < numOfPixels; i++)
	{
		*(output++) = (*pPixel & 0x001F) << 3;
		*(output++) = (*pPixel & 0x03E0) >> 2;	
		*(output++) = (*pPixel & 0x7C00) >> 7;		
		*(output++) = 0xff;            // Alpha = 1
		pPixel++;
	}

	return true;
}

static inline bool rgb565_to_rgb32(const BYTE* input, BYTE* output, int numOfPixels)
{
	if(!input || !output)
	{
		return false;
	}

	// red pixel   (1111 1000 0000 0000) 0xF800
    // green pixel (0000 0111 1110 0000) 0x7E0
    // blue pixel  (0000 0000 0001 1111) 0x1F

	USHORT* pPixel = (USHORT*)input;
	for(int i = 0 ; i < numOfPixels; i++)
	{
		*(output++) = (*pPixel & 0x001F) << 3;	
		*(output++) = (*pPixel & 0x07E0) >> 3; 			
		*(output++) = (*pPixel & 0xF800) >> 8;
		*(output++) = 0xff;            // Alpha = 1
		pPixel++;
	}

	return true;
}

static inline bool yuy2_to_rgb32(const BYTE* input, BYTE* output, int numOfPixels)
{
	if(!input || !output)
	{
		return false;
	}

	BYTE r, g, b;
	for(int i = 0 ; i < numOfPixels / 2; i++)
	{		
		int y0 = *(input++);
		int u  = *(input++);
		int y1 = *(input++);
		int v  = *(input++);
		
		get_rgb_from_yuv(y0, u, v, &r, &g, &b);
		*(output++) = b;
		*(output++) = g;
		*(output++) = r;
		*(output++) = 0xff;  

		get_rgb_from_yuv(y1, u, v, &r, &g, &b);
		*(output++) = b;
		*(output++) = g;
		*(output++) = r;
		*(output++) = 0xff;         
	}

	return true;
}

CColorSpaceConverter::CColorSpaceConverter(const GUID mediaType, int width, int height)
	: m_pRgbaBuffer(0)
{
	InitConvertTable();

	m_mediaType = mediaType;
	m_width = width;
	m_height = height;
	m_uPlanePos = width * height;
	m_vPlanePos = m_uPlanePos + m_uPlanePos / 4;

	int size = width * height * 4;
	m_pRgbaBuffer = new BYTE[size];
	memset(m_pRgbaBuffer, 0, size);
}

CColorSpaceConverter::~CColorSpaceConverter(void)
{
	delete m_pRgbaBuffer;
}

const BYTE* CColorSpaceConverter::convert_to_rgb32(BYTE* frameBuffer)
{
	if(m_mediaType == MEDIASUBTYPE_YV12)
	{
		YUV420_to_RGB32(frameBuffer, &frameBuffer[m_uPlanePos], &frameBuffer[m_vPlanePos], m_pRgbaBuffer, m_width, m_height);
	}
	else if(m_mediaType == MEDIASUBTYPE_IYUV || m_mediaType == WMMEDIASUBTYPE_I420) // swap the u and v planes
	{
		YUV420_to_RGB32(frameBuffer, &frameBuffer[m_vPlanePos], &frameBuffer[m_uPlanePos], m_pRgbaBuffer, m_width, m_height);
	}
	else if(m_mediaType == MEDIASUBTYPE_NV12)
	{
		NV12_to_RGB32(frameBuffer, &frameBuffer[m_uPlanePos], m_pRgbaBuffer, m_width, m_height);	
	}
	else if(m_mediaType == MEDIASUBTYPE_YUY2)
	{
		yuy2_to_rgb32(frameBuffer, m_pRgbaBuffer, m_width * m_height);
	}
	else if(m_mediaType == MEDIASUBTYPE_RGB24)
	{
		rgb24_to_rgb32(frameBuffer, m_pRgbaBuffer, m_width * m_height);
	}
	else if(m_mediaType == MEDIASUBTYPE_RGB555)
	{
		rgb555_to_rgb32(frameBuffer, m_pRgbaBuffer, m_width * m_height);
	}
	else if(m_mediaType == MEDIASUBTYPE_RGB565)
	{
		rgb565_to_rgb32(frameBuffer, m_pRgbaBuffer, m_width * m_height);
	}
	else
	{
		::OutputDebugString(L"Unknowm media subtype");
	}

	return m_pRgbaBuffer;
}
