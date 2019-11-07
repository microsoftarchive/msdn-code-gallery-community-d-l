#include "Header.h"
int WINAPI WinMain(HINSTANCE hInstance, HINSTANCE hPrevInstance, LPSTR lpCmdLine, int nCmdShow)
{
	wincl.hInstance = hInstance;
	wincl.lpszClassName = TEXT("szClassName");
	wincl.lpfnWndProc = WinProc;
	wincl.style = 0;
	wincl.cbSize = sizeof (WNDCLASSEX);
	wincl.hCursor = LoadCursor(NULL, IDC_ARROW);
	wincl.lpszMenuName = NULL;
	wincl.cbClsExtra = 0;
	wincl.cbWndExtra = 0;
	wincl.hbrBackground = CreateSolidBrush(RGB(255, 240, 240));
	wincl.hIcon = LoadIcon(hInstance, MAKEINTRESOURCE(thisicon));
	wincl.hIconSm = LoadIcon(hInstance, MAKEINTRESOURCE(thisicon));
	RegisterClassEx(&wincl);
	hwnd = CreateWindowEx(WS_EX_ACCEPTFILES, TEXT("szClassName"), TEXT("Example of math, variables, and if statements"), WS_SYSMENU | WS_MINIMIZEBOX | WS_MAXIMIZEBOX | WS_SIZEBOX, CW_USEDEFAULT, CW_USEDEFAULT, 534, 311, HWND_DESKTOP, NULL, hInstance, NULL);
	ShowWindow(hwnd, nCmdShow);
	while (GetMessage(&messages, NULL, 0, 0))
	{
		TranslateMessage(&messages);
		DispatchMessage(&messages);
	}
	return 0;
}
LRESULT CALLBACK WinProc(HWND hwnd, UINT message, WPARAM wParam, LPARAM lParam)
{
	switch (message)
	{
	case WM_CREATE: //This runs when the window is created
	{
						HWND textBox1 = CreateWindow(TEXT("edit"), TEXT(""), WS_VISIBLE | WS_CHILD | WS_BORDER, 36, 10, 100, 20, hwnd, (HMENU) 1, NULL, NULL); //This creates textbox
						HWND textbox2 = CreateWindow(TEXT("edit"), TEXT(""), WS_VISIBLE | WS_CHILD | WS_BORDER, 36, 28, 100, 20, hwnd, (HMENU) 2, NULL, NULL);
						HWND label1 = CreateWindow(TEXT("static"), TEXT("X"), WS_VISIBLE | WS_CHILD | WS_TABSTOP, 12, 13, 14, 13, hwnd, (HMENU) 14, NULL, NULL); //This creates a label
						HWND label2 = CreateWindow(TEXT("static"), TEXT("Y"), WS_VISIBLE | WS_CHILD | WS_TABSTOP, 12, 28, 14, 13, hwnd, (HMENU) 15, NULL, NULL);
						HWND radioButton1 = CreateWindow(TEXT("BUTTON"), TEXT("Add"), WS_CHILD | WS_VISIBLE | BS_AUTORADIOBUTTON | WS_GROUP | WS_TABSTOP, 15, 72, 44, 17, hwnd, (HMENU) 3, NULL, NULL); //This creates the first radiobutton in the group
						HWND radioButton2 = CreateWindow(TEXT("BUTTON"), TEXT("Sub"), WS_CHILD | WS_VISIBLE | BS_AUTORADIOBUTTON, 15, 96, 44, 17, hwnd, (HMENU) 4, NULL, NULL);
						HWND radioButton3 = CreateWindow(TEXT("BUTTON"), TEXT("Div"), WS_CHILD | WS_VISIBLE | BS_AUTORADIOBUTTON, 15, 144, 44, 17, hwnd, (HMENU) 5, NULL, NULL);
						HWND radioButton4 = CreateWindow(TEXT("BUTTON"), TEXT("Mul"), WS_CHILD | WS_VISIBLE | BS_AUTORADIOBUTTON, 15, 120, 44, 17, hwnd, (HMENU) 6, NULL, NULL);
						HWND radioButton5 = CreateWindow(TEXT("BUTTON"), TEXT("Equal"), WS_CHILD | WS_VISIBLE | BS_AUTORADIOBUTTON | WS_GROUP | WS_TABSTOP, 271, 48, 160, 17, hwnd, (HMENU) 7, NULL, NULL); //This creates the first radiobutton in the second group
						HWND radioButton6 = CreateWindow(TEXT("BUTTON"), TEXT("Greater Than"), WS_CHILD | WS_VISIBLE | BS_AUTORADIOBUTTON, 271, 72, 160, 17, hwnd, (HMENU) 8, NULL, NULL);
						HWND radioButton7 = CreateWindow(TEXT("BUTTON"), TEXT("Less Than"), WS_CHILD | WS_VISIBLE | BS_AUTORADIOBUTTON, 271, 96, 160, 17, hwnd, (HMENU) 9, NULL, NULL);
						HWND radioButton8 = CreateWindow(TEXT("BUTTON"), TEXT("Greater Than or Equal"), WS_CHILD | WS_VISIBLE | BS_AUTORADIOBUTTON, 271, 120, 160, 17, hwnd, (HMENU) 10, NULL, NULL);
						HWND radioButton9 = CreateWindow(TEXT("BUTTON"), TEXT("Less Than or Equal"), WS_CHILD | WS_VISIBLE | BS_AUTORADIOBUTTON, 271, 144, 160, 17, hwnd, (HMENU) 11, NULL, NULL);
						HWND radioButton10 = CreateWindow(TEXT("BUTTON"), TEXT("Not Equal"), WS_CHILD | WS_VISIBLE | BS_AUTORADIOBUTTON, 271, 168, 160, 17, hwnd, (HMENU) 12, NULL, NULL);
						HWND label3 = CreateWindow(TEXT("static"), TEXT("Answer"), WS_VISIBLE | WS_CHILD | WS_GROUP | WS_TABSTOP, 33, 53, 160, 13, hwnd, (HMENU) 13, NULL, NULL);
						UpdateWindow(hwnd);
						break;
	}
	case WM_COMMAND:
	{
					   switch (wParam)
					   {
					   case 3: //This is ran when the radiobutton with (HEMNU)3 is pressed
					   {
								   std::ostringstream ostr;
								   GetDlgItemTextA(hwnd, 1, x, 32767);
								   GetDlgItemTextA(hwnd, 2, y, 32767);
								   if (x == "") //This sees if x has no value
								   {
									   x[0] = '0'; //This sets x to 0
								   }
								   if (y == "") //This sees if x has no value
								   {
									   y[0] = '0'; //This sets y to 0
								   }
								   x_number = atof(x); //This converts the string x to a integer then stores it in x_number
								   y_number = atof(y);
								   random = x_number + y_number;
								   ostr << random;
								   random_string = ostr.str();
								   SetDlgItemTextA(hwnd, 13, random_string.c_str());
								   break;
					   }
					   case 4:
					   {
								 GetDlgItemTextA(hwnd, 1, x, 32767);
								 GetDlgItemTextA(hwnd, 2, y, 32767);
								 if (x == "") //This sees if x has no value
								 {
									 x[0] = '0'; //This sets x to 0
								 }
								 if (y == "") //This sees if x has no value
								 {
									 y[0] = '0'; //This sets y to 0
								 }
								 std::ostringstream ostr;
								 GetDlgItemTextA(hwnd, 1, x, 32767);
								 GetDlgItemTextA(hwnd, 2, y, 32767);
								 if (x == "") //This sees if x has no value
								 {
									 x[0] = '0'; //This sets x to 0
								 }
								 if (y == "") //This sees if x has no value
								 {
									 y[0] = '0'; //This sets y to 0
								 }
								 x_number = atof(x); //This converts the string x to a integer then stores it in x_number
								 y_number = atof(y);
								 random = x_number - y_number;
								 ostr << random;
								 random_string = ostr.str();
								 SetDlgItemTextA(hwnd, 13, random_string.c_str());
								 break;
					   }
					   case 5:
					   {
								 GetDlgItemTextA(hwnd, 1, x, 32767);
								 GetDlgItemTextA(hwnd, 2, y, 32767);
								 if (x == "") //This sees if x has no value
								 {
									 x[0] = '0'; //This sets x to 0
								 }
								 if (y == "") //This sees if x has no value
								 {
									 y[0] = '0'; //This sets y to 0
								 }
								 std::ostringstream ostr;
								 GetDlgItemTextA(hwnd, 1, x, 32767);
								 GetDlgItemTextA(hwnd, 2, y, 32767);
								 if (x == "") //This sees if x has no value
								 {
									 x[0] = '0'; //This sets x to 0
								 }
								 if (y == "") //This sees if x has no value
								 {
									 y[0] = '0'; //This sets y to 0
								 }
								 x_number = atof(x); //This converts the string x to a integer then stores it in x_number
								 y_number = atof(y);
								 random = x_number / y_number;
								 ostr << random;
								 random_string = ostr.str();
								 SetDlgItemTextA(hwnd, 13, random_string.c_str());
								 break;
					   }
					   case 6:
					   {
								 GetDlgItemTextA(hwnd, 1, x, 32767);
								 GetDlgItemTextA(hwnd, 2, y, 32767);
								 if (x == "") //This sees if x has no value
								 {
									 x[0] = '0'; //This sets x to 0
								 }
								 if (y == "") //This sees if x has no value
								 {
									 y[0] = '0'; //This sets y to 0
								 }
								 std::ostringstream ostr;
								 GetDlgItemTextA(hwnd, 1, x, 32767);
								 GetDlgItemTextA(hwnd, 2, y, 32767);
								 if (x == "") //This sees if x has no value
								 {
									 x[0] = '0'; //This sets x to 0
								 }
								 if (y == "") //This sees if x has no value
								 {
									 y[0] = '0'; //This sets y to 0
								 }
								 x_number = atof(x); //This converts the string x to a integer then stores it in x_number
								 y_number = atof(y);
								 random = x_number * y_number;
								 ostr << random;
								 random_string = ostr.str();
								 SetDlgItemTextA(hwnd, 13, random_string.c_str());
								 break;
					   }
					   case 7:
					   {
								 GetDlgItemTextA(hwnd, 1, x, 32767);
								 GetDlgItemTextA(hwnd, 2, y, 32767);
								 if (x == "") //This sees if x has no value
								 {
									 x[0] = '0'; //This sets x to 0
								 }
								 if (y == "") //This sees if x has no value
								 {
									 y[0] = '0'; //This sets y to 0
								 }
								 x_number = atof(x); //This converts the string x to a integer then stores it in x_number
								 y_number = atof(y);
								 if (x_number == y_number)
								 {
									 whattodisplay = 1;
								 }
								 else
								 {
									 whattodisplay = 2;
								 }
								 RECT rect = { 0, 0, 534, 311 };
								 InvalidateRect(hwnd, &rect, TRUE);
								 break;
					   }
					   case 8:
					   {
								 GetDlgItemTextA(hwnd, 1, x, 32767);
								 GetDlgItemTextA(hwnd, 2, y, 32767);
								 if (x == "") //This sees if x has no value
								 {
									 x[0] = '0'; //This sets x to 0
								 }
								 if (y == "") //This sees if x has no value
								 {
									 y[0] = '0'; //This sets y to 0
								 }
								 x_number = atof(x); //This converts the string x to a integer then stores it in x_number
								 y_number = atof(y);
								 if (x_number > y_number)
								 {
									 whattodisplay = 1;
								 }
								 else
								 {
									 whattodisplay = 2;
								 }
								 RECT rect = { 0, 0, 534, 311 };
								 InvalidateRect(hwnd, &rect, TRUE);
								 break;
					   }
					   case 9:
					   {
								 GetDlgItemTextA(hwnd, 1, x, 32767);
								 GetDlgItemTextA(hwnd, 2, y, 32767);
								 if (x == "") //This sees if x has no value
								 {
									 x[0] = '0'; //This sets x to 0
								 }
								 if (y == "") //This sees if x has no value
								 {
									 y[0] = '0'; //This sets y to 0
								 }
								 x_number = atof(x); //This converts the string x to a integer then stores it in x_number
								 y_number = atof(y);
								 if (x_number < y_number)
								 {
									 whattodisplay = 1;
								 }
								 else
								 {
									 whattodisplay = 2;
								 }
								 RECT rect = { 0, 0, 534, 311 };
								 InvalidateRect(hwnd, &rect, TRUE);
								 break;
					   }
					   case 10:
					   {
								  GetDlgItemTextA(hwnd, 1, x, 32767);
								  GetDlgItemTextA(hwnd, 2, y, 32767);
								  if (x == "") //This sees if x has no value
								  {
									  x[0] = '0'; //This sets x to 0
								  }
								  if (y == "") //This sees if x has no value
								  {
									  y[0] = '0'; //This sets y to 0
								  }
								  x_number = atof(x); //This converts the string x to a integer then stores it in x_number
								  y_number = atof(y);
								  if (x_number >= y_number)
								  {
									  whattodisplay = 1;
								  }
								  else
								  {
									  whattodisplay = 2;
								  }
								  RECT rect = { 0, 0, 534, 311 };
								  InvalidateRect(hwnd, &rect, TRUE);
								  break;
					   }
					   case 11:
					   {
								  GetDlgItemTextA(hwnd, 1, x, 32767);
								  GetDlgItemTextA(hwnd, 2, y, 32767);
								  if (x == "") //This sees if x has no value
								  {
									  x[0] = '0'; //This sets x to 0
								  }
								  if (y == "") //This sees if x has no value
								  {
									  y[0] = '0'; //This sets y to 0
								  }
								  x_number = atof(x); //This converts the string x to a integer then stores it in x_number
								  y_number = atof(y);
								  if (x_number <= y_number)
								  {
									  whattodisplay = 1;
								  }
								  else
								  {
									  whattodisplay = 2;
								  }
								  RECT rect = { 0, 0, 534, 311 };
								  InvalidateRect(hwnd, &rect, TRUE);
								  break;
					   }
					   case 12:
					   {
								  GetDlgItemTextA(hwnd, 1, x, 32767);
								  GetDlgItemTextA(hwnd, 2, y, 32767);
								  if (x == "") //This sees if x has no value
								  {
									  x[0] = '0'; //This sets x to 0
								  }
								  if (y == "") //This sees if x has no value
								  {
									  y[0] = '0'; //This sets y to 0
								  }
								  x_number = atof(x); //This converts the string x to a integer then stores it in x_number
								  y_number = atof(y);
								  if (x_number != y_number)
								  {
									  whattodisplay = 1;
								  }
								  else
								  {
									  whattodisplay = 2;
								  }
								  RECT rect = { 0, 0, 534, 311 };
								  InvalidateRect(hwnd, &rect, TRUE);
								  break;
					   }
					   }
	}
	case WM_PAINT: //This runs when the window is requested to repaint itself
	{
					   BITMAP bm;
					   PAINTSTRUCT ps;
					   HDC screendc = BeginPaint(hwnd, &ps);
					   HDC bitmaphdc = CreateCompatibleDC(screendc);
					   HGDIOBJ orginal = SelectObject(bitmaphdc, LoadBitmap(GetModuleHandle(NULL), MAKEINTRESOURCE(file))); //It is important to save the result of the first SelectObject, and put it back into the HDC before you delete the HDC
					   if (whattodisplay == 0)
					   {
						   BitBlt(screendc, 271, 10, 90, 35, bitmaphdc, 0, 0, SRCCOPY);
					   }
					   else
					   {
						   if (whattodisplay == 1)
						   {
							   SelectObject(bitmaphdc, LoadBitmap(GetModuleHandle(NULL), MAKEINTRESOURCE(yes)));
							   BitBlt(screendc, 271, 10, 90, 35, bitmaphdc, 0, 0, SRCCOPY);
						   }
						   else
						   {
							   SelectObject(bitmaphdc, LoadBitmap(GetModuleHandle(NULL), MAKEINTRESOURCE(no)));
							   BitBlt(screendc, 271, 10, 90, 35, bitmaphdc, 0, 0, SRCCOPY);
						   }
					   }
					   SelectObject(bitmaphdc, orginal);
					   DeleteDC(bitmaphdc);
					   EndPaint(hwnd, &ps);
					   break;
	}
	case WM_DESTROY: //This runs when the window is destroyed
	{
						 exit(0);
						 break;
	}
	default:
		return DefWindowProc(hwnd, message, wParam, lParam);
	}
}