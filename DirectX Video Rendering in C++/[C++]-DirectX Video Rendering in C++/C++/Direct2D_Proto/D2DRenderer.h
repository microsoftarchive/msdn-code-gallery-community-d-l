#pragma once

#include "streams.h"
#include <d2d1.h>
#include <d2d1helper.h>
#include "atlbase.h"
#include <math.h>
#include <memory.h>
#include <wchar.h>
#include <math.h>
#include <d2d1.h>
#include <d2d1helper.h>
#include <dwrite.h>
#include <wincodec.h>

template <typename T>
inline void SafeRelease(T& p)
{
    if (NULL != p)
    {
        p.Release();
        p = NULL;
    }
}

#define HR(x) if(FAILED(x)) { return x; }

enum DisplayMode
{
	KeepAspectRatio = 0,
	Fill = 1
};

class CD2DRenderer
{
public:
	CD2DRenderer(void);
	virtual ~CD2DRenderer(void);

	HRESULT PrepareRenderTarget(BITMAPINFOHEADER& bih, HWND hWnd, bool bFlipHorizontally);
	HRESULT DrawSample(const BYTE* pRgb32Buffer);
	void SetDisplayMode(DisplayMode mode);
	void timerCallBack();
	DisplayMode GetDisplayMode();
    HRESULT SetVideoWindow(HWND hWnd);

private:
	HRESULT CreateResources();
	void DiscardResources();
	HRESULT CreateDeviceIndependentResources();
    HRESULT CreateDeviceResources();
    void DiscardDeviceResources();
    HRESULT OnRender();

public:

	CComPtr<ID2D1Factory>           m_d2dFactory;
    CComPtr<ID2D1HwndRenderTarget>  m_hWndTarget;
	CComPtr<ID2D1Bitmap>            m_bitmap;
	IDWriteFactory                  *m_pDWriteFactory;
	CComPtr<IDWriteTextFormat>      m_pTextFormat;
	CComPtr<ID2D1SolidColorBrush>   m_pBlackBrush;


	UINT32 m_pitch;
	DisplayMode m_displayMode;
	BITMAPINFOHEADER m_pBitmapInfo;
	bool m_bFlipHorizontally;
	HWND m_hWnd;
    LARGE_INTEGER StartingTime, EndingTime, ElapsedMicroseconds;
    LARGE_INTEGER Frequency;
	UINT32 iteration;
};


