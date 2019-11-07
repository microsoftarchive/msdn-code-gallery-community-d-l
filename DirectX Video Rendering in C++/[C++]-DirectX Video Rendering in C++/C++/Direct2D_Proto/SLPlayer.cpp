
#include "stdafx.h"
#include "D2DRenderer.h"
#include "stdio.h"
#include "stdlib.h"
#include "ColorSpaceConverter.h"
#include "exp_emz_comm_image_proc.h"


CD2DRenderer* CreateNativePlayerInstance();
void SetMediaTypeAndFillBitmapHeaderInfo();
CD2DRenderer *gpCD2DRenderer1 = NULL;
HWND                    g_hWnd = NULL;

HRESULT InitWindow();
HRESULT OnInit();


//--------------------------------------------------------------------------------------
// Entry point to the program. Initializes everything and goes into a message processing 
// loop. Idle time is used to render the scene.
//--------------------------------------------------------------------------------------
extern "C" __declspec(dllexport) int Init(const int width, const int height, HWND hWnd)
{
	

    /*if( FAILED( InitWindow() ) )
        return 0;

    if( FAILED( InitDevice() ) )
    {
        Cleanup();
        return 0;
    }
*/
	InitWindow();
	OnInit();
	//InitDevice();
	

    return 0;
}

//--------------------------------------------------------------------------------------
// Register class and create window
//--------------------------------------------------------------------------------------
HRESULT InitWindow()
{
	LPCWSTR sring=L"asdadsda";
	OutputDebugString(sring);

	const wchar_t CLASS_NAME[]  = L"PlayerApplication";
    
    // Register class
	WNDCLASSEX wcex = { };
    wcex.cbSize = sizeof( WNDCLASSEX );
	
    wcex.lpfnWndProc = DefWindowProc;
    wcex.lpszClassName = CLASS_NAME;
    if( !RegisterClassEx( &wcex ) )
        return E_FAIL;

    // Create window
    //g_hWnd = CreateWindow(CLASS_NAME, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 );
    if( !g_hWnd )
        return E_FAIL;

    return TRUE;
}


HRESULT OnInit()
{

	

 gpCD2DRenderer1 = CreateNativePlayerInstance();

 
   // Set the video window handle
   if(gpCD2DRenderer1 != NULL)
   {
       gpCD2DRenderer1->SetVideoWindow(g_hWnd);
   }

   // Fill the BITMAP Header Info structure
   SetMediaTypeAndFillBitmapHeaderInfo();

   // Prepare Render Target
   if(gpCD2DRenderer1 != NULL)
   {
       gpCD2DRenderer1->PrepareRenderTarget(gpCD2DRenderer1->m_pBitmapInfo, gpCD2DRenderer1->m_hWnd, false);
	   gpCD2DRenderer1->DrawSample(NULL);
   }


   return TRUE;
}

static void SetMediaTypeAndFillBitmapHeaderInfo()
{
    DWORD forCC = '21VY';
    DWORD forCC1 = MAKEFOURCC('Y','V','1','2');
    if(gpCD2DRenderer1 != NULL)
    {
        gpCD2DRenderer1->m_pBitmapInfo.biSize = 32;
        gpCD2DRenderer1->m_pBitmapInfo.biWidth = 640;
        gpCD2DRenderer1->m_pBitmapInfo.biHeight = 480;
        gpCD2DRenderer1->m_pBitmapInfo.biPlanes = 0;
        gpCD2DRenderer1->m_pBitmapInfo.biBitCount = 12;
        gpCD2DRenderer1->m_pBitmapInfo.biCompression = 0;//842094158;
        gpCD2DRenderer1->m_pBitmapInfo.biSizeImage = 0;
        gpCD2DRenderer1->m_pBitmapInfo.biXPelsPerMeter = 0;
        gpCD2DRenderer1->m_pBitmapInfo.biYPelsPerMeter = 0;
        gpCD2DRenderer1->m_pBitmapInfo.biClrUsed = 0;
        gpCD2DRenderer1->m_pBitmapInfo.biClrImportant = 0;
    }

    return;
}

CD2DRenderer* CreateNativePlayerInstance()
{
	CD2DRenderer *pNativePlayerInstance = new CD2DRenderer();
	return pNativePlayerInstance;
}

extern "C" __declspec(dllexport) void __stdcall DestroyNativePlayerInstance(CD2DRenderer *pObj)
{
    if(pObj != NULL)
    {
        delete pObj;
        pObj = NULL;
    }
}
