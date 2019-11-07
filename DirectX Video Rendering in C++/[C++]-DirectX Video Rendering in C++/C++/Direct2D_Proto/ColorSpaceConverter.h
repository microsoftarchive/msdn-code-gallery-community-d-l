#pragma once

#include "windows.h"
#include "streams.h"
#include "Dvdmedia.h"
#include "wmsdkidl.h"

static long int crv_tab[256];
static long int cbu_tab[256];
static long int cgu_tab[256];
static long int cgv_tab[256];
static long int tab_76309[256];
static unsigned char clp[1024];	
static inline void YUV420_to_RGB32(BYTE* src0, BYTE* src1, BYTE* src2, BYTE* dst, int width,int height);
class CColorSpaceConverter
{
public:
	CColorSpaceConverter(const GUID mediaType, int width, int height);
	virtual ~CColorSpaceConverter(void);

	const BYTE* convert_to_rgb32(BYTE* frameBuffer);

private:
	BYTE* m_pRgbaBuffer;

	GUID m_mediaType;
	int m_width; 
	int m_height;

	int m_uPlanePos;
	int m_vPlanePos;
};

