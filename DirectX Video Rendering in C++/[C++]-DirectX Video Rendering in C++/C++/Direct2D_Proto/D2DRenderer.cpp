#include "stdafx.h"
#include "D2DRenderer.h"

#include <dwrite.h>
#pragma comment(lib, "Dwrite")
static WCHAR sc_helloWorld[] = L"Simple Overlay1 Simple Overlay1";
static UINT32 counter=0;
CD2DRenderer::CD2DRenderer(void)
	: m_bitmap(0), m_d2dFactory(0), m_hWndTarget(0), m_displayMode(KeepAspectRatio),m_pDWriteFactory(NULL),m_pTextFormat(NULL),m_pBlackBrush(NULL)
{
	HRESULT hr = D2D1CreateFactory(D2D1_FACTORY_TYPE_SINGLE_THREADED, IID_ID2D1Factory, (void **)&m_d2dFactory);

	
}

CD2DRenderer::~CD2DRenderer(void)
{
	SafeRelease(m_bitmap);
	SafeRelease(m_hWndTarget);
	SafeRelease(m_d2dFactory);
	//SafeRelease(m_pDWriteFactory);
	SafeRelease(m_pTextFormat);
	SafeRelease(m_pBlackBrush);
}

void CALLBACK sTimerProc(UINT uID, UINT uMsg, DWORD dwUser, 
					   DWORD dw1, DWORD dw2)
{	

	/*static WCHAR sc_helloWorld[] = L"Sample Overlay";*/
	CD2DRenderer *rend=(CD2DRenderer*)dwUser;
	rend->timerCallBack();
	
}


HRESULT CD2DRenderer::PrepareRenderTarget(BITMAPINFOHEADER& bih, HWND hWnd, bool bFlipHorizontally)
{
	m_pBitmapInfo = bih;
	m_hWnd = hWnd;	
	m_bFlipHorizontally = bFlipHorizontally;
	m_pitch = m_pBitmapInfo.biWidth * 4;
	//CD2DRenderer *pTimerHndl = (CD2DRenderer*)this;
	//UINT32				m_TimerHndle;
	//timeBeginPeriod(1); 
	//m_TimerHndle=timeSetEvent(2000,1,         
	//	sTimerProc,      
	//	(UINT32)pTimerHndl,                  
	//	TIME_PERIODIC
	//	/*TIME_ONESHOT TIME_PERIODIC*/); 

	DiscardResources();

	HRESULT hr = S_OK;

    static const WCHAR msc_fontName[] = L"Verdana";
	
    static const FLOAT msc_fontSize = 25;

	if (SUCCEEDED(hr))
    {
        // Create a DirectWrite factory.
        hr = DWriteCreateFactory(
            DWRITE_FACTORY_TYPE_SHARED,
            __uuidof(m_pDWriteFactory),
            reinterpret_cast<IUnknown **>(&m_pDWriteFactory)
            );
    }
	if (SUCCEEDED(hr))
    {
        // Create a DirectWrite text format object.
        hr = m_pDWriteFactory->CreateTextFormat(
            msc_fontName,
            NULL,
            DWRITE_FONT_WEIGHT_NORMAL,
            DWRITE_FONT_STYLE_NORMAL,
            DWRITE_FONT_STRETCH_NORMAL,
            msc_fontSize,
            L"", //locale
            &m_pTextFormat
            );
    }
	return CreateResources();
}

HRESULT CD2DRenderer::CreateResources()
{
	D2D1_PIXEL_FORMAT pixelFormat = 
	{
        DXGI_FORMAT_B8G8R8A8_UNORM,
        D2D1_ALPHA_MODE_IGNORE
    };

    D2D1_RENDER_TARGET_PROPERTIES renderTargetProps = 
	{
        D2D1_RENDER_TARGET_TYPE_DEFAULT,
        pixelFormat,
        0,
        0,
        D2D1_RENDER_TARGET_USAGE_NONE,
        D2D1_FEATURE_LEVEL_DEFAULT
    };

	RECT rect;
	::GetClientRect(m_hWnd, &rect);

    D2D1_SIZE_U windowSize = 
	{
        rect.right - rect.left,
        rect.bottom - rect.top
    };
    
    D2D1_HWND_RENDER_TARGET_PROPERTIES hWndRenderTargetProps = 
	{
        m_hWnd,
        windowSize,
        D2D1_PRESENT_OPTIONS_IMMEDIATELY 
    };

	HR(m_d2dFactory->CreateHwndRenderTarget(renderTargetProps, hWndRenderTargetProps, &m_hWndTarget));
    
	//  (0,0) + --------> X
	//        |
	//        |
	//        |
	//        Y
  //if (SUCCEEDED(HR))
        {
			HRESULT hr = S_OK;

    if (SUCCEEDED(hr))
    {
        // Center the text horizontally and vertically.
        m_pTextFormat->SetTextAlignment(DWRITE_TEXT_ALIGNMENT_CENTER);

        m_pTextFormat->SetParagraphAlignment(DWRITE_PARAGRAPH_ALIGNMENT_CENTER);

    }
            // Create a black brush.
            hr = m_hWndTarget->CreateSolidColorBrush(
                D2D1::ColorF(D2D1::ColorF::Red),
                &m_pBlackBrush
                );
        }
	if(m_bFlipHorizontally)
	{
		// Flip the image around the X axis
		D2D1::Matrix3x2F scale = D2D1::Matrix3x2F(1, 0,
			                                      0, -1,
												  0, 0);

		// Move it back into place
		D2D1::Matrix3x2F translate = D2D1::Matrix3x2F::Translation(0, windowSize.height);
		m_hWndTarget->SetTransform(scale * translate);
	}

	FLOAT dpiX, dpiY;
	m_d2dFactory->GetDesktopDpi(&dpiX, &dpiY);

    D2D1_BITMAP_PROPERTIES bitmapProps = 
	{
        pixelFormat,
        dpiX,
        dpiY
    };
    
    D2D1_SIZE_U bitmapSize = 
	{
		m_pBitmapInfo.biWidth,
		m_pBitmapInfo.biHeight
    };

	return m_hWndTarget->CreateBitmap(bitmapSize, bitmapProps, &m_bitmap);
}

void CD2DRenderer::DiscardResources()
{
	SafeRelease(m_bitmap);
	SafeRelease(m_hWndTarget);
}

static inline void ApplyLetterBoxing(D2D1_RECT_F& rendertTargetArea, D2D1_SIZE_F& frameArea)
{
	const float aspectRatio = frameArea.width / frameArea.height;

	const float targetW = fabs(rendertTargetArea.right - rendertTargetArea.left);
	const float targetH = fabs(rendertTargetArea.bottom - rendertTargetArea.top);

	float tempH = targetW / aspectRatio;	
		
	if(tempH <= targetH) // desired frame height is smaller than display height so fill black on top and bottom of display 
	{		
		float deltaH = fabs(tempH - targetH) / 2;
		rendertTargetArea.top += deltaH;
		rendertTargetArea.bottom -= deltaH;
	}
	else //desired frame height is bigger than display height so fill black on left and right of display 
	{
		float tempW = targetH * aspectRatio;	
		float deltaW = fabs(tempW - targetW) / 2;

		rendertTargetArea.left += deltaW;
		rendertTargetArea.right -= deltaW;
	}
}



void CD2DRenderer::timerCallBack()
{
	counter = counter+1;
	/*QueryPerformanceCounter(&EndingTime);
	ElapsedMicroseconds.QuadPart = EndingTime.QuadPart - StartingTime.QuadPart;
	UINT32 val=(ElapsedMicroseconds.QuadPart / 1000);
	if(val %2 ==0)
	{*/
	if(counter %2 ==0)
	{
		WCHAR sc_helloWorld2[]=L"Overlay2 Simple Overlay2 Simple";
		wcscpy(sc_helloWorld,sc_helloWorld2);
	}
	else
	{
		//WCHAR sc_helloWorld2[]=L"Simple Overlay3 Simple Overlay3";
		WCHAR sc_helloWorld2[]=L"                                 ";
		wcscpy(sc_helloWorld,sc_helloWorld2);
	}
	/*}
	else
	{
		WCHAR sc_helloWorld2[]=L"asdadadad qwqeqqeqeqewqe";
		wcscpy(sc_helloWorld,sc_helloWorld2);
	}*/
}

HRESULT CD2DRenderer::DrawSample(const BYTE* pRgb32Buffer)
{
	LPCSTR sring="asdadsda";

	OutputDebugStringA(sring);

	//QueryPerformanceCounter(&StartingTime);
	
	//iteration +=1;
	//if(iteration %100==0)
	//{
	//	WCHAR sc_helloWorld2[]=L"asdadadad";
	//	QueryPerformanceFrequency(&Frequency);
	//	
	//	
	//}

	//CheckPointer(pRgb32Buffer, E_POINTER);

	if(!m_bitmap || !m_hWndTarget)
	{
		HR(CreateResources());
	}

	

	//HR(m_bitmap->CopyFromMemory(NULL, pRgb32Buffer, m_pitch));
	
	//if (!(m_hWndTarget->CheckWindowState() & D2D1_WINDOW_STATE_OCCLUDED))
	{
		RECT rect;
		::GetClientRect(m_hWnd, &rect);
		D2D1_SIZE_U newSize = { rect.right, rect.bottom };
		D2D1_SIZE_U size = m_hWndTarget->GetPixelSize();

		if(newSize.height != size.height || newSize.width != size.width)
		{
			m_hWndTarget->Resize(newSize);
		}

		D2D1_RECT_F rectangle = D2D1::RectF(0, 0, newSize.width, newSize.height);
		
		D2D1_SIZE_F renderTargetSize = m_hWndTarget->GetSize();

		if(m_displayMode == KeepAspectRatio)
		{
			ApplyLetterBoxing(rectangle, m_bitmap->GetSize());
		}

		m_hWndTarget->BeginDraw();

		//m_hWndTarget->Clear(D2D1::ColorF(D2D1::ColorF::Red));
		

		//m_hWndTarget->DrawBitmap(m_bitmap, rectangle);

		m_hWndTarget->DrawText(
            sc_helloWorld,
            ARRAYSIZE(sc_helloWorld) - 1,
            m_pTextFormat,
            D2D1::RectF(10, 400, renderTargetSize.width, renderTargetSize.height),
            m_pBlackBrush);

		HRESULT hr = m_hWndTarget->EndDraw();

		/*if(hr == D2DERR_RECREATE_TARGET)
		{
			DiscardResources();
		}*/
	}

    return S_OK;
}

void CD2DRenderer::SetDisplayMode(DisplayMode mode)
{
	m_displayMode = mode;
}

DisplayMode CD2DRenderer::GetDisplayMode()
{
	return m_displayMode;
}

HRESULT CD2DRenderer::SetVideoWindow(HWND hWnd)
{
	if(!IsWindow(hWnd))
	{
		
		return E_INVALIDARG;
	}

	m_hWnd = hWnd;
	return S_OK;
}

