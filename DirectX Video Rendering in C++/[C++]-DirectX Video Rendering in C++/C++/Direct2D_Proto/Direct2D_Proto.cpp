// Direct2D_Proto.cpp : Defines the entry point for the application.
//

#include "stdafx.h"
#include "Direct2D_Proto.h"
#include "D2DRenderer.h"
#include "stdio.h"
#include "stdlib.h"
#include "ColorSpaceConverter.h"
#include "exp_emz_comm_image_proc.h"

#define MAX_LOADSTRING 100

// Global Variables:
HINSTANCE hInst;								// current instance
TCHAR szTitle[MAX_LOADSTRING];					// The title bar text
TCHAR szWindowClass[MAX_LOADSTRING];			// the main window class name
CD2DRenderer *gpCD2DRenderer = NULL;
FILE* gpInputFile = NULL;

// Forward declarations of functions included in this code module:
ATOM				MyRegisterClass(HINSTANCE hInstance);
BOOL				InitInstance(HINSTANCE, int);
LRESULT CALLBACK	WndProc(HWND, UINT, WPARAM, LPARAM);
INT_PTR CALLBACK	About(HWND, UINT, WPARAM, LPARAM);

static void SetMediaTypeAndFillBitmapHeaderInfo();

int APIENTRY _tWinMain(HINSTANCE hInstance,
                     HINSTANCE hPrevInstance,
                     LPTSTR    lpCmdLine,
                     int       nCmdShow)
{
	UNREFERENCED_PARAMETER(hPrevInstance);
	UNREFERENCED_PARAMETER(lpCmdLine);

 	// TODO: Place code here.
	MSG msg;
	HACCEL hAccelTable;
    HRESULT lResult = S_OK;
    DWORD lStartTime = 0, lEndTime = 0;

    tEmzInt32		lTemp,lTemp1;
	tEmzInt32		lWidth = 640;
	tEmzInt32		lHeight = 480;
	tFrameData		tInputFrame, tOutFrame;

	// Initialize global strings
	LoadString(hInstance, IDS_APP_TITLE, szTitle, MAX_LOADSTRING);
	LoadString(hInstance, IDC_DIRECT2D_PROTO, szWindowClass, MAX_LOADSTRING);
	MyRegisterClass(hInstance);

	// Perform application initialization:
	if (!InitInstance (hInstance, nCmdShow))
	{
		return FALSE;
	}

	hAccelTable = LoadAccelerators(hInstance, MAKEINTRESOURCE(IDC_DIRECT2D_PROTO));

  	lTemp = (lWidth * lHeight);
	lTemp1 = lWidth * lHeight * 4;

	tInputFrame.Ptr1 = (tEmzUint8 *) malloc(lTemp);
	tInputFrame.Ptr2 = (tEmzUint8 *) malloc(lTemp >> 2);
	tInputFrame.Ptr3 = (tEmzUint8 *) malloc(lTemp >> 2);
	
	tOutFrame.Ptr1 = (tEmzUint8 *) malloc(lTemp1); 
	
	tInputFrame.Xoffset = 0;
	tInputFrame.Yoffset = 0;
	tInputFrame.CropWidth  = lWidth;
	tInputFrame.CropHeight = lHeight;

	tOutFrame.Xoffset = 0;
	tOutFrame.Yoffset = 0;
	tOutFrame.wndWidth  = lWidth; 
	tOutFrame.wndHeight = lHeight;

	tInputFrame.ActWidth = lWidth;
	tInputFrame.ActHeight = lHeight;
	
	tOutFrame.ActWidth = lWidth;
	tOutFrame.ActHeight = lHeight;

    // Main message loop:
	while (GetMessage(&msg, NULL, 0, 0))
	{
		if (!TranslateAccelerator(msg.hwnd, hAccelTable, &msg))
		{
			TranslateMessage(&msg);
			DispatchMessage(&msg);
		}
        while((gpInputFile) && !feof(gpInputFile))
        {
            fread (tInputFrame.Ptr1, 1, (lTemp), gpInputFile);
            fread (tInputFrame.Ptr2, 1, (lTemp >> 2), gpInputFile);
            fread (tInputFrame.Ptr3, 1, (lTemp >> 2), gpInputFile);

            gColConv_YUV420P_BGRAI(&tInputFrame,&tOutFrame);

            if(tOutFrame.Ptr1 != NULL)
            {
                lStartTime = timeGetTime();
                lResult = gpCD2DRenderer->DrawSample((BYTE *)tOutFrame.Ptr1);
                lEndTime = timeGetTime();
                char temp[100];
                _snprintf_s ( temp, 100, 100 ,"Time Diff IS  %lu\n", (lEndTime - lStartTime) );
                OutputDebugStringA(temp);
                if(lResult == S_OK)
                {
                    // draw sample success
                }
                else
                {
                    // draw sample failed
                }
            }
            else
            {
                // out of memory
            }
        }
        if(gpInputFile)
        {
            fclose(gpInputFile);
            gpInputFile = NULL;
        }
        if(tInputFrame.Ptr1)
        {
            free(tInputFrame.Ptr1);
            tInputFrame.Ptr1 = NULL;
        }
        if(tInputFrame.Ptr2)
        {
            free(tInputFrame.Ptr2);
            tInputFrame.Ptr2 = NULL;
        }
        if(tInputFrame.Ptr3)
        {
            free(tInputFrame.Ptr3);
            tInputFrame.Ptr3 = NULL;
        }
        if(tOutFrame.Ptr1)
        {
            free(tOutFrame.Ptr1);
            tOutFrame.Ptr1 = NULL;
        }

	}

	return (int) msg.wParam;
}



//
//  FUNCTION: MyRegisterClass()
//
//  PURPOSE: Registers the window class.
//
//  COMMENTS:
//
//    This function and its usage are only necessary if you want this code
//    to be compatible with Win32 systems prior to the 'RegisterClassEx'
//    function that was added to Windows 95. It is important to call this function
//    so that the application will get 'well formed' small icons associated
//    with it.
//
ATOM MyRegisterClass(HINSTANCE hInstance)
{
	WNDCLASSEX wcex;

	wcex.cbSize = sizeof(WNDCLASSEX);

	wcex.style			= CS_HREDRAW | CS_VREDRAW;
	wcex.lpfnWndProc	= WndProc;
	wcex.cbClsExtra		= 0;
	wcex.cbWndExtra		= 0;
	wcex.hInstance		= hInstance;
	wcex.hIcon			= LoadIcon(hInstance, MAKEINTRESOURCE(IDI_DIRECT2D_PROTO));
	wcex.hCursor		= LoadCursor(NULL, IDC_ARROW);
	wcex.hbrBackground	= (HBRUSH)(COLOR_WINDOW+1);
	wcex.lpszMenuName	= MAKEINTRESOURCE(IDC_DIRECT2D_PROTO);
	wcex.lpszClassName	= szWindowClass;
	wcex.hIconSm		= LoadIcon(wcex.hInstance, MAKEINTRESOURCE(IDI_SMALL));

	return RegisterClassEx(&wcex);
}

//
//   FUNCTION: InitInstance(HINSTANCE, int)
//
//   PURPOSE: Saves instance handle and creates main window
//
//   COMMENTS:
//
//        In this function, we save the instance handle in a global variable and
//        create and display the main program window.
//



BOOL InitInstance(HINSTANCE hInstance, int nCmdShow)
{
   HWND hWnd;

   hInst = hInstance; // Store instance handle in our global variable

   hWnd = CreateWindow(szWindowClass, szTitle, WS_OVERLAPPEDWINDOW,
      CW_USEDEFAULT, 0, CW_USEDEFAULT, 0, NULL, NULL, hInstance, NULL);

   if (!hWnd)
   {
      return FALSE;
   }

   ShowWindow(hWnd, nCmdShow);
   UpdateWindow(hWnd);
   gpInputFile = fopen("D:\\car_vga_copy.yuv", "rb");
   if(gpInputFile == NULL)
   {
       MessageBox(NULL, L"File Open Failed", L"Info", MB_DEFBUTTON2);
   }
   gpCD2DRenderer = new CD2DRenderer();
   // Set the video window handle
   if(gpCD2DRenderer != NULL)
   {
       gpCD2DRenderer->SetVideoWindow(hWnd);
   }

   // Fill the BITMAP Header Info structure
   SetMediaTypeAndFillBitmapHeaderInfo();

   // Prepare Render Target
   if(gpCD2DRenderer != NULL)
   {
       gpCD2DRenderer->PrepareRenderTarget(gpCD2DRenderer->m_pBitmapInfo, gpCD2DRenderer->m_hWnd, false);
   }
   return TRUE;
}

//
//  FUNCTION: WndProc(HWND, UINT, WPARAM, LPARAM)
//
//  PURPOSE:  Processes messages for the main window.
//
//  WM_COMMAND	- process the application menu
//  WM_PAINT	- Paint the main window
//  WM_DESTROY	- post a quit message and return
//
//
LRESULT CALLBACK WndProc(HWND hWnd, UINT message, WPARAM wParam, LPARAM lParam)
{
	int wmId, wmEvent;
	PAINTSTRUCT ps;
	HDC hdc;

	switch (message)
	{
	case WM_COMMAND:
		wmId    = LOWORD(wParam);
		wmEvent = HIWORD(wParam);
		// Parse the menu selections:
		switch (wmId)
		{
		case IDM_ABOUT:
			DialogBox(hInst, MAKEINTRESOURCE(IDD_ABOUTBOX), hWnd, About);
			break;
		case IDM_EXIT:
			DestroyWindow(hWnd);
			break;
		default:
			return DefWindowProc(hWnd, message, wParam, lParam);
		}
		break;
	case WM_PAINT:
		hdc = BeginPaint(hWnd, &ps);
		// TODO: Add any drawing code here...

			
			////if(hdc)
			//  {
			//	//	//Creating double buffer
			//		HDC hdcMem = CreateCompatibleDC(ps.hdc);
			//		int ndcmem = SaveDC(hdcMem);
			//		HDC hdcBackground = CreateCompatibleDC(ps.hdc);
			//		LOGFONT	lf;
   //                 HFONT hFont;	
			//		COLORREF CLR;
			//		//char Text[] = "Simple flicker free";
			//		WCHAR fontName[] = L"Lucida Console";
			//		static const WCHAR sc_helloWorld[] = L"Hello, World!";
			//		CLR=RGB(255,0,0);
			//	// Create a font as desired
			//	  ZeroMemory(&lf, sizeof(LOGFONT));
			//	  //lf.lfFaceName="Lucida Console";
			//	  //strcpy(lf.lfFaceName,fontName);
			//	  lf.lfHeight = 20;
			//	  lf.lfWeight = FW_BOLD;
			//	  lf.lfQuality = ANTIALIASED_QUALITY;
			//	  hFont=CreateFontIndirect(&lf);
			//		
			//		HBITMAP hbmMem = CreateCompatibleBitmap(ps.hdc, 200, 300);
			//		SelectObject(hdcMem, hbmMem);
			//	

			//		/* Copy background bitmap into double buffer*/
			//		BitBlt(hdcMem, 0, 0, 200, 300, hdcBackground, 0, 0, SRCCOPY);
			//		SelectObject(hdcMem, hFont);
			//		SetTextColor(hdcMem, CLR);
			//		SetBkMode(hdcMem, TRANSPARENT);
			//		 RECT rc;
   //                 GetClientRect(hWnd, &rc);
			//		DrawText(hdcMem,sc_helloWorld,-1,&rc,DT_CENTER);

			//		// Copy double buffer to screen
			//		BitBlt(ps.hdc, 0, 0, 200, 300, hdcMem, 0, 0, SRCCOPY);
			//	
			//		// Clean up
			//		RestoreDC(hdcMem, ndcmem);
			//		DeleteObject(hbmMem);
			//		DeleteDC(hdcMem);
			//}
		EndPaint(hWnd, &ps);
		break;
    case WM_SHOWWINDOW:
        {
            if(wParam == TRUE)
            {

            }
        }
        break;
	case WM_DESTROY:
		PostQuitMessage(0);
		break;
	default:
		return DefWindowProc(hWnd, message, wParam, lParam);
	}
	return 0;
}

// Message handler for about box.
INT_PTR CALLBACK About(HWND hDlg, UINT message, WPARAM wParam, LPARAM lParam)
{
	UNREFERENCED_PARAMETER(lParam);
	switch (message)
	{
	case WM_INITDIALOG:
		return (INT_PTR)TRUE;

	case WM_COMMAND:
		if (LOWORD(wParam) == IDOK || LOWORD(wParam) == IDCANCEL)
		{
			EndDialog(hDlg, LOWORD(wParam));
			return (INT_PTR)TRUE;
		}
		break;
	}
	return (INT_PTR)FALSE;
}

static void SetMediaTypeAndFillBitmapHeaderInfo()
{
    DWORD forCC = '21VY';
    DWORD forCC1 = MAKEFOURCC('Y','V','1','2');
    if(gpCD2DRenderer != NULL)
    {
        gpCD2DRenderer->m_pBitmapInfo.biSize = 32;
        gpCD2DRenderer->m_pBitmapInfo.biWidth = 640;
        gpCD2DRenderer->m_pBitmapInfo.biHeight = 480;
        gpCD2DRenderer->m_pBitmapInfo.biPlanes = 0;
        //gpCD2DRenderer->m_pBitmapInfo.biBitCount = 12;
        gpCD2DRenderer->m_pBitmapInfo.biCompression = 0;//842094158;
        gpCD2DRenderer->m_pBitmapInfo.biSizeImage = 0;
        gpCD2DRenderer->m_pBitmapInfo.biXPelsPerMeter = 0;
        gpCD2DRenderer->m_pBitmapInfo.biYPelsPerMeter = 0;
        gpCD2DRenderer->m_pBitmapInfo.biClrUsed = 0;
        gpCD2DRenderer->m_pBitmapInfo.biClrImportant = 0;
    }

    return;
}

