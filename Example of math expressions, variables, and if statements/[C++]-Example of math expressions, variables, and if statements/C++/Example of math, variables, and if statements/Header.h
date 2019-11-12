#pragma once
#include <Windows.h>
#include <sstream>
#include <string>
#define thisicon 1
#define file 2
#define yes 3
#define no 4
HWND hwnd;
WNDCLASSEX wincl;
static MSG messages;
int whattodisplay = 0;
int WINAPI WinMain(HINSTANCE hInstance, HINSTANCE hPrevInstance, LPSTR lpCmdLine, int nCmdShow);
LRESULT CALLBACK WinProc(HWND hwnd, UINT message, WPARAM wParam, LPARAM lParam);
char x[32767];
char y[32767];
std::string random_string;
int x_number;
int y_number;
int random;