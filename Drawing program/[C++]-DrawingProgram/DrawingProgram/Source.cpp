#include <Windows.h>
#include "resource.h"


//C++ variables
bool isFill = false;
bool isBlue = false;
bool isRed = false;
bool isGreen = false;
bool isYellow = false;
bool isBrushActive = false;
bool isText = false;
bool isEraserActive = false;
bool isLine = false;
bool isMLine = false;
bool isRect = false;
bool isEllipse = false;
bool isTriangle = false;
bool isPentagon = false;
bool isStar = false;
bool isFourStar = false;
bool isHex = false;
bool isStarSix = false;
bool isSolid = false;
bool isDashed = false;
int x, y;

//Win32 api variables
HWND hwnd;
HWND brushGUI;
HWND text;
HWND redButtonGUI,blueButtonGUI,greenButtonGUI,yellowButtonGUI,eraserButtonGUI,fillButtonGUI,
textButtonGUI,lineButtonGUI,mlineButtonGUI,noColorGUI,isRectButtonGUI,isEllipseButtonGUI,
isTriangleButtonGUI,isPentagonButtonGUI,isStarButtonGUI,isFStarGUI,hexGUI,sixStarGUI,
dashedBrush,solidBrush;
HINSTANCE hInst;
COLORREF color;
HFONT hFont;


//Change background
void changeBCK(HWND hWnd,int r,int g,int b)
{
	color = RGB(r, g,b);
	InvalidateRect(hWnd, NULL, TRUE);
}
//Handiling messages for the context menu
LRESULT CALLBACK WinProc2(HWND hwnd2, UINT msg, WPARAM wParam, LPARAM lParam)
{
	switch (msg)
	{
	case WM_COMMAND:
		switch (LOWORD(wParam))
		{
		case 1:
			changeBCK(hwnd, 0, 0, 0);
			if (isBlue == true)
			{
				changeBCK(hwnd, 0, 0, 255);
				isRed = false;
				isGreen = false;
				isYellow = false;
			}
			if (isRed == true)
			{
				changeBCK(hwnd, 255, 0, 0);
				isBlue = false;
				isYellow = false;
				isGreen = false;
			}
			if (isGreen == true)
			{
				changeBCK(hwnd, 0, 255, 0);
				isRed = false;
				isYellow = false;
				isBlue = false;
			}
			if (isYellow == true)
			{
				changeBCK(hwnd, 255, 255, 0);
				isRed = false;
				isGreen = false;
				isBlue = false;
			}
			break;
		case 2:
			isBlue = true;
			isRed = false;
			isGreen = false;
			isYellow = false;
			break;
		case 3:
			isRed = true;
			isBlue = false;
			isYellow = false;
			isGreen = false;
			break;
		case 4:
			isGreen = true;
			isRed = false;
			isYellow = false;
			isBlue = false;
			break;
		case 5:
			isYellow = true;
			isRed = false;
			isBlue = false;
			isGreen = false;
			break;
		case 6:
			isEraserActive = true;
			break;
		case 7:
			isText = true;
			break;
		case 8:
			isLine = true;
			break;
		case 9:
			isMLine = true;
			break;
		case 10:
			isYellow = false;
			isRed = false;
			isBlue = false;
			isGreen = false;
			break;
		case 11:
			isRect = true;
			break;
		case 12:
			isEllipse = true;
			break;
		case 14:
			isTriangle = true;
			break;
		case 13:
			isPentagon = true;
			break;
		case 15:
			isStar = true;
			break;
		case 16:
			isFourStar = true;
			break;
		case 17:
			isHex = true;
			break;
		case 18:
			isStarSix = true;
			break;
		case 19:
			isSolid = true;
			isDashed = false;
			break;
		case 20:
			isSolid = false;
			isDashed = true;
			break;
		}
		break;
	case WM_CLOSE:
		DestroyWindow(hwnd2);
		break;
	case WM_DESTROY:
		PostQuitMessage(0);
		break;
	default:
		return DefWindowProc(hwnd2, msg, wParam, lParam);
		break;
	}
	return 0;
}
//Handiling messages for the window
LRESULT CALLBACK WinProc(HWND hwnd2,UINT msg,WPARAM wParam,LPARAM lParam)
{
	OPENFILENAME ofn;
	HDC hdc;
	HPEN pen;
	HBRUSH brush;
	RECT rc;
	static int endx, endy;

	char szFilename[MAX_PATH] = "";

	//Points for the triangle
	POINT pt[3];

	//1st point
	pt[0].x = x;
	pt[0].y = y;
	//2nd point
	pt[1].x = x;
	pt[1].y = y - 100;
	//3rd point
	pt[2].x = x + 100;
	pt[2].y = y - 100;


	//Points for pentagon
	POINT penPt[5];

	//1st point
	penPt[0].x = x;
	penPt[0].y = y;
	//2nd point
	penPt[1].x = x - 100;
	penPt[1].y = y + 100;
	//3rd point
	penPt[2].x = x - 50;
	penPt[2].y = y + 200;
	//4th point
	penPt[3].x = x + 50;
	penPt[3].y = y + 200;
	//5th point
	penPt[4].x = x + 100;
	penPt[4].y = y + 100;


	//Points for a star
	POINT starPt[10];

	//1st point
	starPt[0].x = x;
	starPt[0].y = y;
	//2nd point
	starPt[1].x = x - 60;
	starPt[1].y = y + 100;
	//3rd point
	starPt[2].x = x - 120;
	starPt[2].y = y + 100;
	//4th point
	starPt[3].x = x - 90;
	starPt[3].y = y + 175;
	//5th point
	starPt[4].x = x - 100;
	starPt[4].y = y + 250;
	//6th point
	starPt[5].x = x;
	starPt[5].y = y + 200;
	//7th point
	starPt[6].x = x + 100;
	starPt[6].y = y + 250;
	//8th point
	starPt[7].x = x + 90;
	starPt[7].y = y + 175;
	//9th point
	starPt[8].x = x + 120;
	starPt[8].y = y + 100;
	//10th point 
	starPt[9].x = x + 60;
	starPt[9].y = y + 100;

	//Points for the four pointed star
	POINT fStarPt[8];

	//1st point
	fStarPt[0].x = x;
	fStarPt[0].y = y;
	//2nd point
	fStarPt[1].x = x - 50;
	fStarPt[1].y = y + 100;
	//3rd point
	fStarPt[2].x = x - 100;
	fStarPt[2].y = y + 150;
	//4th point
	fStarPt[3].x = x - 50;
	fStarPt[3].y = y + 200;
	//5th point
	fStarPt[4].x = x;
	fStarPt[4].y = y + 250;
	//6th point
	fStarPt[5].x = x + 50;
	fStarPt[5].y = y + 200;
	//7th point
	fStarPt[6].x = x + 100;
	fStarPt[6].y = y + 150;
	//8th point
	fStarPt[7].x = x + 50;
	fStarPt[7].y = y + 100;

	//Points for Hexagon
	POINT hexPt[6];

	//1st point
	hexPt[0].x = x;
	hexPt[0].y = y;
	//2nd point
	hexPt[1].x = x - 150;
	hexPt[1].y = y + 150;
	//3rd point
	hexPt[2].x = x;
	hexPt[2].y = y + 300;
	//4th point
	hexPt[3].x = x + 100;
	hexPt[3].y = y + 300;
	//5th point
	hexPt[4].x = x + 150;
	hexPt[4].y = y + 150;
	//6th point
	hexPt[5].x = x + 100;
	hexPt[5].y = y;

	//Points for six-pointed star
	POINT sixStarPt[12];

	//1st point
	sixStarPt[0].x = x;
	sixStarPt[0].y = y;
	//2nd point
	sixStarPt[1].x = x - 100;
	sixStarPt[1].y = y + 100;
	//3rd point
	sixStarPt[2].x = x - 125;
	sixStarPt[2].y = y + 100;
	//4th point
	sixStarPt[3].x = x - 150;
	sixStarPt[3].y = y + 150;
	//5th point
	sixStarPt[4].x = x - 175;
	sixStarPt[4].y = y + 200;
	//6th point
	sixStarPt[5].x = x - 100;
	sixStarPt[5].y = y + 200;
	//7th point
	sixStarPt[6].x = x;
	sixStarPt[6].y = y + 250;
	//8th point
	sixStarPt[7].x = x + 100;
	sixStarPt[7].y = y + 200;
	//9th point
	sixStarPt[8].x = x + 175;
	sixStarPt[8].y = y + 200;
	//10th point
	sixStarPt[9].x = x + 150;
	sixStarPt[9].y = y + 150;
	//11th point
	sixStarPt[10].x = x + 125;
	sixStarPt[10].y = y + 100;
	//12th point
	sixStarPt[11].x = x + 100;
	sixStarPt[11].y = y + 100;

	//msg loop
	switch (msg)
	{
	case WM_COMMAND:
		switch (LOWORD(wParam))
		{
		
		case 252:
			//Save
			ZeroMemory(&ofn, sizeof(ofn));

			ofn.lStructSize = sizeof(ofn);
			ofn.hwndOwner = hwnd;
			ofn.lpstrFilter = "JPEG (*.jpeg)\0*.jpeg\0All Files (*.*)\0*.*\0";
			ofn.lpstrFile = szFilename;
			ofn.nMaxFile = MAX_PATH;
			ofn.Flags = OFN_EXPLORER | OFN_FILEMUSTEXIST | OFN_HIDEREADONLY | OFN_OVERWRITEPROMPT;
			ofn.lpstrDefExt = "jpeg";

			if (GetSaveFileName(&ofn))
			{

			}

			break;
		case 251:
			//Open
			ZeroMemory(&ofn, sizeof(ofn));

			ofn.lStructSize = sizeof(ofn);
			ofn.hwndOwner = hwnd;
			ofn.lpstrFilter = "JPEG (*.jpeg)\0*.jpeg\0All Files (*.*)\0*.*\0";
			ofn.lpstrFile = szFilename;
			ofn.nMaxFile = MAX_PATH;
			ofn.Flags = OFN_EXPLORER | OFN_FILEMUSTEXIST | OFN_HIDEREADONLY;
			ofn.lpstrDefExt = "jpeg";

			if (GetOpenFileName(&ofn))
			{

			}


			break;
		case 254:
			PostQuitMessage(0);
			break;
		}
		break;
	case WM_CHAR:
		//Keyboard input
		switch (wParam)
		{
		case 0x1B:
			PostQuitMessage(0);
			break;
		case 0x46:
			isFill = true;
			break;
		case 0x52:
			isRed = true;
			break;
		default:
			break;
		}
		break;
	case WM_ERASEBKGND:
		//Background
		pen = CreatePen(PS_SOLID, 1, color);
		brush = CreateSolidBrush(color);

		SelectObject((HDC)wParam, pen);
		SelectObject((HDC)wParam, brush);
		
		GetClientRect(hwnd, &rc);

		Rectangle((HDC)wParam, rc.left, rc.top, rc.right, rc.bottom);
		break;
	case WM_LBUTTONDOWN:
		isBrushActive = true;
		if (isText == true)
		{
			isBrushActive = false;

			hFont = CreateFont(24, 0, 0, 0, FW_DONTCARE, FALSE, FALSE, FALSE, ANSI_CHARSET, OUT_TT_PRECIS, CLIP_DEFAULT_PRECIS, DEFAULT_QUALITY, DEFAULT_PITCH | FF_DONTCARE, TEXT("Arial Black"));


			int x = LOWORD(lParam);
			int y = HIWORD(lParam);

			text = CreateWindow("EDIT", "", WS_TABSTOP | WS_VISIBLE | WS_CHILD, x, y, 300, 100, hwnd, NULL, hInst, NULL);

			SendMessage(text, WM_SETFONT, (WPARAM)hFont, TRUE);

			isText = false;
		}
		if ((isLine == true) || (isMLine == true) )
		{
			isBrushActive = false;
			isRect = false;
			isStar = false;
			isEllipse = false;
			isTriangle = false;
			isPentagon = false;
			isFourStar = false;
			isStarSix = false;

			hdc = GetDC(hwnd);
			x = LOWORD(lParam);
			y = HIWORD(lParam);

			endx = LOWORD(lParam);
			endy = HIWORD(lParam);

			if (isMLine == true)
			{
				SetROP2(hdc, R2_NOTXORPEN);
			}

			MoveToEx(hdc, x, y, NULL);
			LineTo(hdc, endx, endy);
			ReleaseDC(hwnd, hdc);


		}
		if (isRect == true)
		{
			isBrushActive = false;
			isLine = false;
			isStar = false;
			isMLine = false;
			isTriangle = false;
			isEllipse = false;
			isPentagon = false;
			isFourStar = false;
			isStarSix = false;

			hdc = GetDC(hwnd);
			x = LOWORD(lParam);
			y = HIWORD(lParam);

			endx = LOWORD(lParam);
			endy = HIWORD(lParam);

			SetROP2(hdc, R2_NOTXORPEN);

			Rectangle(hdc, x, y, endx, endy);

			ReleaseDC(hwnd, hdc);

		}
		if (isEllipse == true)
		{
			isBrushActive = false;
			isLine = false;
			isMLine = false;
			isStar = false;
			isRect = false;
			isTriangle = false;
			isPentagon = false;
			isFourStar = false;
			isStarSix = false;

			hdc = GetDC(hwnd);

			x = LOWORD(lParam);
			y = HIWORD(lParam);

			endx = LOWORD(lParam);
			endy = HIWORD(lParam);

			SetROP2(hdc, R2_NOTXORPEN);

			Ellipse(hdc, x, y, endx, endy);

			ReleaseDC(hwnd, hdc);
		}
		if (isTriangle == true)
		{
			isBrushActive = false;
			isMLine = false;
			isLine = false;
			isRect = false;
			isEllipse = false;
			isPentagon = false;
			isStar = false;
			isFourStar = false;
			isHex = false;
			isStarSix = false;

			hdc = GetDC(hwnd);

			x = LOWORD(lParam);
			y = HIWORD(lParam);

			SetROP2(hdc, R2_NOTXORPEN);

			Polygon(hdc, pt, 3);

			ReleaseDC(hwnd, hdc);
		}
		if (isPentagon == true)
		{
			isBrushActive = false;
			isMLine = false;
			isLine = false;
			isRect = false;
			isEllipse = false;
			isStar = false;
			isTriangle = false;
			isFourStar = false;
			isHex = false;
			isStarSix = false;

			hdc = GetDC(hwnd);

			x = LOWORD(lParam);
			y = HIWORD(lParam);

			SetROP2(hdc, R2_NOTXORPEN);

			Polygon(hdc, penPt, 5);

			ReleaseDC(hwnd, hdc);

		}
		if (isStar == true)
		{
			isBrushActive = false;
			isMLine = false;
			isLine = false;
			isRect = false;
			isEllipse = false;
			isTriangle = false;
			isPentagon = false;
			isFourStar = false;
			isHex = false;
			isStarSix = false;

			hdc = GetDC(hwnd);

			x = LOWORD(lParam);
			y = HIWORD(lParam);

			SetROP2(hdc, R2_NOTXORPEN);

			Polygon(hdc, starPt, 10);

			ReleaseDC(hwnd, hdc);
		}
		if (isFourStar == true)
		{
			isBrushActive = false;
			isMLine = false;
			isLine = false;
			isRect = false;
			isEllipse = false;
			isTriangle = false;
			isPentagon = false;
			isStar = false;
			isHex = false;
			isStarSix = false;

			hdc = GetDC(hwnd);

			x = LOWORD(lParam);
			y = HIWORD(lParam);

			SetROP2(hdc, R2_NOTXORPEN);

			Polygon(hdc, fStarPt, 8);

			ReleaseDC(hwnd, hdc);
		}
		if (isHex == true)
		{
			isBrushActive = false;
			isMLine = false;
			isLine = false;
			isRect = false;
			isEllipse = false;
			isTriangle = false;
			isPentagon = false;
			isStar = false;
			isFourStar = false;
			isStarSix = false;
			
			hdc = GetDC(hwnd);

			x = LOWORD(lParam);
			y = HIWORD(lParam);

			SetROP2(hdc, R2_NOTXORPEN);

			Polygon(hdc, hexPt, 6);

			ReleaseDC(hwnd, hdc);

		}
		if (isStarSix == true)
		{
			isBrushActive = false;
			isMLine = false;
			isLine = false;
			isRect = false;
			isEllipse = false;
			isTriangle = false;
			isPentagon = false;
			isStar = false;
			isFourStar = false;
			isHex = false;

			hdc = GetDC(hwnd);

			x = LOWORD(lParam);
			y = HIWORD(lParam);

			SetROP2(hdc, R2_NOTXORPEN);

			Polygon(hdc, sixStarPt, 12);

			ReleaseDC(hwnd, hdc);
		}
		return 0;
		break;
	case WM_LBUTTONUP:
		isBrushActive = false;
		isEraserActive = false;
		isLine = false;
		isMLine = false;
		isRect = false;
		isEllipse = false;
		isTriangle = false;
		isPentagon = false;
		isStar = false;
		isFourStar = false;
		isHex = false;
		isStarSix = false;
		break;
	case WM_RBUTTONDOWN:
		///Context menu
		x = LOWORD(lParam);
		y = HIWORD(lParam);
		brushGUI = CreateWindowEx(WS_EX_CLIENTEDGE, "DRAW2", "", WS_POPUP, x, y, 500, 250, NULL, NULL, hInst, NULL);

		redButtonGUI = CreateWindow("BUTTON", "Red", WS_VISIBLE | WS_CHILD | WS_TABSTOP | BS_DEFPUSHBUTTON, 0, 0, 50, 50, brushGUI, (HMENU)3, (HINSTANCE)GetWindowLong(brushGUI, GWL_HINSTANCE), NULL);
		greenButtonGUI = CreateWindow("BUTTON", "Green", WS_VISIBLE | WS_CHILD | WS_TABSTOP | BS_DEFPUSHBUTTON, 50, 0, 50, 50, brushGUI, (HMENU)4, (HINSTANCE)GetWindowLong(brushGUI, GWL_HINSTANCE), NULL);
		yellowButtonGUI = CreateWindow("BUTTON", "Yellow", WS_VISIBLE | WS_CHILD | WS_TABSTOP | BS_DEFPUSHBUTTON, 100, 0, 50, 50, brushGUI, (HMENU)5, (HINSTANCE)GetWindowLong(brushGUI, GWL_HINSTANCE), NULL);
		blueButtonGUI = CreateWindow("BUTTON", "Blue", WS_VISIBLE | WS_CHILD | WS_TABSTOP | BS_DEFPUSHBUTTON, 150, 0, 50, 50, brushGUI, (HMENU)2, (HINSTANCE)GetWindowLong(brushGUI, GWL_HINSTANCE), NULL);
		fillButtonGUI = CreateWindow("BUTTON", "FILL", WS_VISIBLE | WS_CHILD | WS_TABSTOP | BS_DEFPUSHBUTTON, 0, 50, 50, 50, brushGUI, (HMENU)1, (HINSTANCE)GetWindowLong(brushGUI, GWL_HINSTANCE), NULL);
		eraserButtonGUI = CreateWindow("BUTTON", "ERASER", WS_VISIBLE | WS_CHILD | WS_TABSTOP | BS_DEFPUSHBUTTON, 0, 100, 50, 50, brushGUI, (HMENU)6, (HINSTANCE)GetWindowLong(brushGUI, GWL_HINSTANCE), NULL);
		textButtonGUI = CreateWindow("BUTTON", "TEXT", WS_VISIBLE | WS_CHILD | WS_TABSTOP | BS_DEFPUSHBUTTON, 0, 150, 50, 50, brushGUI, (HMENU)7, (HINSTANCE)GetWindowLong(brushGUI, GWL_HINSTANCE), NULL);
		lineButtonGUI = CreateWindow("BUTTON", "MULTI LINE", WS_VISIBLE | WS_CHILD | WS_TABSTOP | BS_DEFPUSHBUTTON, 0, 200, 50, 50, brushGUI, (HMENU)8, (HINSTANCE)GetWindowLong(brushGUI, GWL_HINSTANCE), NULL);
		mlineButtonGUI = CreateWindow("BUTTON", "LINE", WS_VISIBLE | WS_CHILD | WS_TABSTOP | BS_DEFPUSHBUTTON, 50, 200, 50, 50, brushGUI, (HMENU) 9, (HINSTANCE)GetWindowLong(brushGUI, GWL_HINSTANCE), NULL);
		noColorGUI = CreateWindow("BUTTON", "No Color", WS_VISIBLE | WS_CHILD | WS_TABSTOP | BS_DEFPUSHBUTTON, 200, 0, 50, 50, brushGUI, (HMENU)10, (HINSTANCE)GetWindowLong(brushGUI, GWL_HINSTANCE), NULL);
		isRectButtonGUI = CreateWindow("BUTTON", "RECTANGLE", WS_VISIBLE | WS_CHILD | WS_TABSTOP | BS_DEFPUSHBUTTON, 100, 200, 50, 50, brushGUI, (HMENU)11, (HINSTANCE)GetWindowLong(brushGUI, GWL_HINSTANCE), NULL);
		isEllipseButtonGUI = CreateWindow("BUTTON", "ELLIPSE", WS_VISIBLE | WS_CHILD | WS_TABSTOP | BS_DEFPUSHBUTTON, 150, 200, 50, 50, brushGUI, (HMENU)12, (HINSTANCE)GetWindowLong(brushGUI, GWL_HINSTANCE), NULL);
		isTriangleButtonGUI = CreateWindow("BUTTON", "TRIANGLE", WS_VISIBLE | WS_CHILD | WS_TABSTOP | BS_DEFPUSHBUTTON, 200, 200, 50, 50, brushGUI, (HMENU)14, (HINSTANCE)GetWindowLong(brushGUI, GWL_HINSTANCE), NULL);
		isPentagonButtonGUI = CreateWindow("BUTTON", "PENTAGON", WS_VISIBLE | WS_CHILD | WS_TABSTOP | BS_DEFPUSHBUTTON, 250, 200, 50, 50, brushGUI, (HMENU)13, (HINSTANCE)GetWindowLong(brushGUI, GWL_HINSTANCE), NULL);
		isStarButtonGUI = CreateWindow("BUTTON", "STAR", WS_VISIBLE | WS_CHILD | WS_TABSTOP | BS_DEFPUSHBUTTON, 300, 200, 50, 50, brushGUI, (HMENU)15, (HINSTANCE)GetWindowLong(brushGUI, GWL_HINSTANCE), NULL);
		isFStarGUI = CreateWindow("BUTTON", "FOUR STAR", WS_VISIBLE | WS_CHILD | WS_TABSTOP | BS_DEFPUSHBUTTON, 350, 200, 50, 50, brushGUI, (HMENU)16, (HINSTANCE)GetWindowLong(brushGUI, GWL_HINSTANCE), NULL);
		hexGUI = CreateWindow("BUTTON", "HEXAGON", WS_VISIBLE | WS_CHILD | WS_TABSTOP | BS_DEFPUSHBUTTON, 400, 200, 50, 50, brushGUI, (HMENU)17, (HINSTANCE)GetWindowLong(brushGUI, GWL_HINSTANCE), NULL);
		sixStarGUI = CreateWindow("BUTTON", "SIX-POINTED STAR", WS_VISIBLE | WS_CHILD | WS_TABSTOP | BS_DEFPUSHBUTTON, 450, 200, 50, 50, brushGUI, (HMENU)18, (HINSTANCE)GetWindowLong(brushGUI, GWL_HINSTANCE), NULL);
		solidBrush = CreateWindow("BUTTON", "SOLID BRUSH", WS_VISIBLE | WS_CHILD | WS_TABSTOP | BS_DEFPUSHBUTTON, 50, 50, 50, 50, brushGUI, (HMENU)19, (HINSTANCE)GetWindowLong(brushGUI, GWL_HINSTANCE), NULL);
		dashedBrush = CreateWindow("BUTTON", "DASHED BRUSH", WS_VISIBLE | WS_CHILD | WS_TABSTOP | BS_DEFPUSHBUTTON, 100, 50, 50, 50, brushGUI, (HMENU)20, (HINSTANCE)GetWindowLong(brushGUI, GWL_HINSTANCE), NULL);

		if (brushGUI == NULL)
		{
			MessageBox(NULL, "GUI failed creation", "ERROR", MB_OK);
		}

		ShowWindow(brushGUI, SW_SHOW);
		UpdateWindow(brushGUI);
		break;
	case WM_RBUTTONUP:
		ShowWindow(brushGUI, SW_HIDE);
		break;
	case WM_MOUSEMOVE:
		if (isBrushActive == true)
		{
			if (MK_LBUTTON)
			{
				hdc = GetDC(hwnd);
				if (isBlue == true)
				{
					if (isSolid == true)
					{
						pen = CreatePen(PS_SOLID, 12, RGB(0, 0, 255));
						SelectObject(hdc, pen);
					}
					if (isDashed == true)
					{
						pen = CreatePen(PS_DASH, 12, RGB(0, 0, 255));
						SelectObject(hdc, pen);
					}
				}
				if (isRed == true)
				{
					if (isSolid == true)
					{
						pen = CreatePen(PS_SOLID, 12, RGB(255, 0, 0));
						SelectObject(hdc, pen);
					}
					if (isDashed == true)
					{
						pen = CreatePen(PS_DASH, 12, RGB(255, 0, 0));
						SelectObject(hdc, pen);
					}
				}
				if (isGreen == true)
				{
					if (isSolid == true)
					{
						pen = CreatePen(PS_SOLID, 12, RGB(0, 255, 0));
						SelectObject(hdc, pen);
					}
					if (isDashed == true)
					{
						pen = CreatePen(PS_DASH, 12, RGB(0, 255, 0));
						SelectObject(hdc, pen);
					}
				}
				if (isYellow == true)
				{
					if (isSolid == true)
					{
						pen = CreatePen(PS_SOLID, 12, RGB(255, 255, 0));
						SelectObject(hdc, pen);
					}
					if (isDashed == true)
					{
						pen = CreatePen(PS_DASH, 12, RGB(255, 255, 0));
						SelectObject(hdc, pen);
					}
				}
				if (isEraserActive == true)
				{
					if (isSolid == true)
					{
						pen = CreatePen(PS_SOLID, 12, RGB(0, 0, 0));
						SelectObject(hdc, pen);
					}
					if (isDashed == true)
					{
						pen = CreatePen(PS_DASH, 12, RGB(0, 0, 0));
						SelectObject(hdc, pen);
					}
				}
			

				int x = LOWORD(lParam);
				int y = HIWORD(lParam);

				MoveToEx(hdc, x, y, NULL);
				LineTo(hdc, LOWORD(lParam), HIWORD(lParam));
				ReleaseDC(hwnd, hdc);
			}
		}
		hdc = GetDC(hwnd);
		if (isMLine == true )
		{		
		
			SetROP2(hdc, R2_NOTXORPEN);

			if (isBlue == true)
			{
				pen = CreatePen(PS_SOLID, 12, RGB(255, 255, 0));
				SelectObject(hdc, pen);
			}
			if (isRed == true)
			{
				pen = CreatePen(PS_SOLID, 12, RGB(0, 255, 255));
				SelectObject(hdc, pen);
			}
			if (isGreen == true)
			{
				pen = CreatePen(PS_SOLID, 12, RGB(255, 0, 255));
				SelectObject(hdc, pen);
			}
			if (isYellow == true)
			{
				pen = CreatePen(PS_SOLID, 12, RGB(0, 0, 255));
				SelectObject(hdc, pen);
			}
			MoveToEx(hdc, x, y, NULL);
			LineTo(hdc, endx, endy);
			endx = LOWORD(lParam);
			endy = HIWORD(lParam);
			MoveToEx(hdc, x, y, NULL);
			LineTo(hdc, endx, endy);
		}
		if (isRect == true)
		{
			if (isBlue == true)
			{
				pen = CreatePen(PS_SOLID, 12, RGB(255, 255, 0));
				SelectObject(hdc, pen);
			}
			if (isRed == true)
			{
				pen = CreatePen(PS_SOLID, 12, RGB(0, 255, 255));
				SelectObject(hdc, pen);
			}
			if (isGreen == true)
			{
				pen = CreatePen(PS_SOLID, 12, RGB(255, 0 , 255));
				SelectObject(hdc, pen);
			}
			if (isYellow == true)
			{
				pen = CreatePen(PS_SOLID, 12, RGB(0, 0, 255));
				SelectObject(hdc, pen);
			}
			SetROP2(hdc, R2_NOTXORPEN);
			Rectangle(hdc, x, y, endx, endy);
			endx = LOWORD(lParam);
			endy = HIWORD(lParam);
			Rectangle(hdc, x, y, endx, endy);
		}
		if (isEllipse == true)
		{
			if (isBlue == true)
			{
				pen = CreatePen(PS_SOLID, 12, RGB(255, 255, 0));
				SelectObject(hdc, pen);
			}
			if (isRed == true)
			{
				pen = CreatePen(PS_SOLID, 12, RGB(0, 255, 255));
				SelectObject(hdc, pen);
			}
			if (isGreen == true)
			{
				pen = CreatePen(PS_SOLID, 12, RGB(255, 0, 255));
				SelectObject(hdc, pen);
			}
			if (isYellow == true)
			{
				pen = CreatePen(PS_SOLID, 12, RGB(0, 0, 255));
				SelectObject(hdc, pen);
			}
			SetROP2(hdc, R2_NOTXORPEN);
			Ellipse(hdc, x, y, endx, endy);
			endx = LOWORD(lParam);
			endy = HIWORD(lParam);
			Ellipse(hdc, x, y, endx, endy);
		}
		if (isLine == true)
		{
			if (isBlue == true)
			{
				pen = CreatePen(PS_SOLID, 12, RGB(0, 0, 255));
				SelectObject(hdc, pen);
			}
			if (isRed == true)
			{
				pen = CreatePen(PS_SOLID, 12, RGB(255, 0, 0));
				SelectObject(hdc, pen);
			}
			if (isGreen == true)
			{
				pen = CreatePen(PS_SOLID, 12, RGB(0, 255, 0));
				SelectObject(hdc, pen);
			}
			if (isYellow == true)
			{
				pen = CreatePen(PS_SOLID, 12, RGB(255, 255, 0));
				SelectObject(hdc, pen);
			}
			MoveToEx(hdc, x, y, NULL);
			LineTo(hdc, endx, endy);
			endx = LOWORD(lParam);
			endy = HIWORD(lParam);
			MoveToEx(hdc, x, y, NULL);
			LineTo(hdc, endx, endy);
		}
		if (isTriangle == true)
		{
			if (isBlue == true)
			{
				pen = CreatePen(PS_SOLID, 12, RGB(255, 255, 0));
				SelectObject(hdc, pen);
			}
			if (isRed == true)
			{
				pen = CreatePen(PS_SOLID, 12, RGB(0, 255, 255));
				SelectObject(hdc, pen);
			}
			if (isGreen == true)
			{
				pen = CreatePen(PS_SOLID, 12, RGB(255, 0, 255));
				SelectObject(hdc, pen);
			}
			if (isYellow == true)
			{
				pen = CreatePen(PS_SOLID, 12, RGB(0, 0, 255));
				SelectObject(hdc, pen);
			}
			SetROP2(hdc, R2_NOTXORPEN);

			Polygon(hdc, pt, 3);
		}
		if (isPentagon == true)
		{
			if (isBlue == true)
			{
				pen = CreatePen(PS_SOLID, 12, RGB(255, 255, 0));
				SelectObject(hdc, pen);
			}
			if (isRed == true)
			{
				pen = CreatePen(PS_SOLID, 12, RGB(0, 255, 255));
				SelectObject(hdc, pen);
			}
			if (isGreen == true)
			{
				pen = CreatePen(PS_SOLID, 12, RGB(255, 0, 255));
				SelectObject(hdc, pen);
			}
			if (isYellow == true)
			{
				pen = CreatePen(PS_SOLID, 12, RGB(0, 0, 255));
				SelectObject(hdc, pen);
			}
			SetROP2(hdc, R2_NOTXORPEN);

			Polygon(hdc, penPt, 5);
		}
		if (isStar == true)
		{
			if (isBlue == true)
			{
				pen = CreatePen(PS_SOLID, 12, RGB(255, 255, 0));
				SelectObject(hdc, pen);
			}
			if (isRed == true)
			{
				pen = CreatePen(PS_SOLID, 12, RGB(0, 255, 255));
				SelectObject(hdc, pen);
			}
			if (isGreen == true)
			{
				pen = CreatePen(PS_SOLID, 12, RGB(255, 0, 255));
				SelectObject(hdc, pen);
			}
			if (isYellow == true)
			{
				pen = CreatePen(PS_SOLID, 12, RGB(0, 0, 255));
				SelectObject(hdc, pen);
			}
			SetROP2(hdc, R2_NOTXORPEN);

			Polygon(hdc, starPt, 10);
		}
		if (isFourStar == true)
		{
			if (isBlue == true)
			{
				pen = CreatePen(PS_SOLID, 12, RGB(255, 255, 0));
				SelectObject(hdc, pen);
			}
			if (isRed == true)
			{
				pen = CreatePen(PS_SOLID, 12, RGB(0, 255, 255));
				SelectObject(hdc, pen);
			}
			if (isGreen == true)
			{
				pen = CreatePen(PS_SOLID, 12, RGB(255, 0, 255));
				SelectObject(hdc, pen);
			}
			if (isYellow == true)
			{
				pen = CreatePen(PS_SOLID, 12, RGB(0, 0, 255));
				SelectObject(hdc, pen);
			}
			SetROP2(hdc, R2_NOTXORPEN);

			Polygon(hdc, fStarPt, 8);
		}
		if (isHex == true)
		{
			if (isBlue == true)
			{
				pen = CreatePen(PS_SOLID, 12, RGB(255, 255, 0));
				SelectObject(hdc, pen);
			}
			if (isRed == true)
			{
				pen = CreatePen(PS_SOLID, 12, RGB(0, 255, 255));
				SelectObject(hdc, pen);
			}
			if (isGreen == true)
			{
				pen = CreatePen(PS_SOLID, 12, RGB(255, 0, 255));
				SelectObject(hdc, pen);
			}
			if (isYellow == true)
			{
				pen = CreatePen(PS_SOLID, 12, RGB(0, 0, 255));
				SelectObject(hdc, pen);
			}

			SetROP2(hdc, R2_NOTXORPEN);

			Polygon(hdc, hexPt, 6);
		}
		if (isStarSix == true)
		{
			if (isBlue == true)
			{
				pen = CreatePen(PS_SOLID, 12, RGB(255, 255, 0));
				SelectObject(hdc, pen);
			}
			if (isRed == true)
			{
				pen = CreatePen(PS_SOLID, 12, RGB(0, 255, 255));
				SelectObject(hdc, pen);
			}
			if (isGreen == true)
			{
				pen = CreatePen(PS_SOLID, 12, RGB(255, 0, 255));
				SelectObject(hdc, pen);
			}
			if (isYellow == true)
			{
				pen = CreatePen(PS_SOLID, 12, RGB(0, 0, 255));
				SelectObject(hdc, pen);
			}

			SetROP2(hdc, R2_NOTXORPEN);

			Polygon(hdc, sixStarPt, 12);
		}
		ReleaseDC(hwnd, hdc);
		break;
	case WM_CLOSE:
		DestroyWindow(hwnd2);
		break;
	case WM_DESTROY:
		PostQuitMessage(0);
		break;
	default:
		return DefWindowProc(hwnd2, msg, wParam, lParam);
	}
	return 0;
}
///Main Function
int WINAPI WinMain(HINSTANCE hInstance,HINSTANCE hPrevInstance,LPSTR lpCmdLine,int cmdShow)
{
	WNDCLASSEX wcex;
	WNDCLASSEX wc;
	MSG msg;

	hInst = hInstance;
	
	//Registering the wndclassex for the main window
	wcex.cbSize = sizeof(WNDCLASSEX);
	wcex.style = 0;
	wcex.lpfnWndProc = WinProc;
	wcex.cbClsExtra = 0;
	wcex.cbWndExtra = 0;
	wcex.hInstance = hInstance;
	wcex.hIcon = LoadIcon(NULL, IDI_APPLICATION);
	wcex.hCursor = LoadCursor(NULL, IDC_ARROW);
	wcex.hbrBackground = (HBRUSH)(COLOR_WINDOW + 1);
	wcex.lpszMenuName = MAKEINTRESOURCE(IDR_MENU);
	wcex.lpszClassName = "DRAW";
	wcex.hIconSm = LoadIcon(NULL, IDI_APPLICATION);
	//Registering the wndclassex for the context menu
	wc.cbSize = sizeof(WNDCLASSEX);
	wc.style = 0;
	wc.lpfnWndProc = WinProc2;
	wc.cbClsExtra = 0;
	wc.cbWndExtra = 0;
	wc.hInstance = hInstance;
	wc.hIcon = LoadIcon(NULL, IDI_APPLICATION);
	wc.hCursor = LoadCursor(NULL, IDC_ARROW);
	wc.hbrBackground = (HBRUSH)(COLOR_WINDOW + 1);
	wc.lpszMenuName = NULL;
	wc.lpszClassName = "DRAW2";
	wc.hIconSm = LoadIcon(NULL, IDI_APPLICATION);


	if (!RegisterClassEx(&wcex))
	{
		MessageBox(NULL, "Window Class Registration fail", "Error!", MB_OK);
		return 0;
	}
	if (!RegisterClassEx(&wc))
	{
		MessageBox(NULL, "Window Class Registration fail", "Error!", MB_OK);
		return 0;
	}
	///Creating the window
	hwnd = CreateWindowEx(
		WS_EX_CLIENTEDGE,
		"DRAW",
		"Drawing Program",
		WS_OVERLAPPEDWINDOW,
		CW_USEDEFAULT, CW_USEDEFAULT, 840, 620,
		NULL, NULL, hInstance, NULL);
	

	if (hwnd == NULL)
	{
		MessageBox(NULL, "Window creation fail", "Error!", MB_OK);
		return 0;
	}
	///Showing the window
	ShowWindow(hwnd, cmdShow);
	UpdateWindow(hwnd);
	//msg loop
	while (GetMessage(&msg,NULL,0,0) > 0)
	{
		
		TranslateMessage(&msg);
		DispatchMessage(&msg);
	}
	return msg.wParam;
}