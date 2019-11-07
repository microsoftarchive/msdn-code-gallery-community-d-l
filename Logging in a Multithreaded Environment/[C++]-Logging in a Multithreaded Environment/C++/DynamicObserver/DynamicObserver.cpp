/**********************************************************************
*
* DynamicObserver.cpp: Definition of DynamicObserver
*
* DynamicObserver is the application class
*
* Author: Stefan Ruck, Frankfurt/Main, Germany, 2001
*
**********************************************************************/

#include "stdafx.h"

#include <io.h>
#include <fcntl.h>

#include "DynamicObserver.h"

#include "MainFrm.h"
#include "PpCfgObserver.h"
#include "LogDistributor.h"
#include "LogObserver.h"
#include "AboutDlg.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif

/////////////////////////////////////////////////////////////////////////////
// The one and only DynamicObserverApp object

DynamicObserverApp theApp;

BEGIN_MESSAGE_MAP(DynamicObserverApp, CWinApp)
	//{{AFX_MSG_MAP(DynamicObserverApp)
	ON_COMMAND(ID_APP_ABOUT, OnAppAbout)
	ON_COMMAND(IDM_CONFIG_OBSERVER, OnConfigObserver)
	ON_COMMAND(IDM_LOG_GUI, OnLogGui)
	ON_COMMAND(IDM_LOG_COM, OnLogCom)
	ON_COMMAND(IDM_LOG_USERACTIVITY, OnLogUserActivity)
	//}}AFX_MSG_MAP
END_MESSAGE_MAP()

/**********************************************************************
*
* DynamicObserverApp::InitInstance
*
* Description: The framework’s implementation of WinMain calls this function.
*
* Returns: BOOL
*     Nonzero if initialization is successful; otherwise 0.
*
**********************************************************************/
BOOL DynamicObserverApp::InitInstance()
{
	// Change the registry key under which our settings are stored.
	// TODO: You should modify this string to be something appropriate
	// such as the name of your company or organization.
	SetRegistryKey(_T("Local AppWizard-Generated Applications"));

	// To create the main window, this code creates a new frame window
	// object and then sets it as the application's main window object.

	CMDIFrameWnd* pFrame = new MainFrame;
	m_pMainWnd = pFrame;

	// create main MDI frame window
	if (!pFrame->LoadFrame(IDR_MAINFRAME))
		return FALSE;

  // Create a console window
  int hCrt;
  FILE *hf;

  ::AllocConsole();
  hCrt = _open_osfhandle(
           (long) GetStdHandle(STD_OUTPUT_HANDLE),
           _O_TEXT
        );
  hf = _fdopen( hCrt, "w" );
  *stdout = *hf;
  setvbuf( stdout, NULL, _IONBF, 0 );

	// try to load shared MDI menus and accelerator table
	//TODO: add additional member variables and load calls for
	//	additional menu types your application may need. 

	HINSTANCE hInst = AfxGetResourceHandle();
	m_hMDIMenu  = ::LoadMenu(hInst, MAKEINTRESOURCE(IDR_DYNAMITYPE));
	m_hMDIAccel = ::LoadAccelerators(hInst, MAKEINTRESOURCE(IDR_DYNAMITYPE));

	// The main window has been initialized, so show and update it.
	pFrame->ShowWindow(m_nCmdShow);
	pFrame->UpdateWindow();

	return TRUE;
}

/**********************************************************************
*
* DynamicObserverApp::ExitInstance
*
* Description: Called by the framework from within the Run member 
*     function to exit this instance of the application. 
*
* Returns: int
*     The application’s exit code; 0 indicates no errors, and values greater 
*     than 0 indicate an error. This value is used as the return value from WinMain.
*
**********************************************************************/
int DynamicObserverApp::ExitInstance() 
{
	//TODO: handle additional resources you may have added
	if (m_hMDIMenu != NULL)
		FreeResource(m_hMDIMenu);
	if (m_hMDIAccel != NULL)
		FreeResource(m_hMDIAccel);

	return CWinApp::ExitInstance();
}

/**********************************************************************
*
* DynamicObserverApp::OnAppAbout
*
* Description: Message handling ID_APP_ABOUT: Shows the About dialog
*
**********************************************************************/
void DynamicObserverApp::OnAppAbout()
{
	AboutDlg aboutDlg;

	aboutDlg.DoModal();
}

/**********************************************************************
*
* DynamicObserverApp::OnConfigObserver
*
* Description: Message handling IDM_CONFIG_OBSERVER: 
*   Shows the observer config sheet
*
**********************************************************************/
void DynamicObserverApp::OnConfigObserver() 
{
  CPropertySheet sheet(IDS_OBSERVER);
  PpCfgObserver ppCfgObserver;

  sheet.AddPage(&ppCfgObserver);

  sheet.DoModal();
}

/**********************************************************************
*
* DynamicObserverApp::OnLogGui
*
* Description: Message handling IDM_LOG_GUI: 
*   Creates a log message of the GUI area
*
**********************************************************************/
void DynamicObserverApp::OnLogGui() 
{
  LogDistributor::Instance().Log(LogMessage(LogMessage::evGUI, LogMessage::evTrace,
                                           "This is my GUI-Trace-Output."));
}

/**********************************************************************
*
* DynamicObserverApp::OnLogCom
*
* Description: Message handling IDM_LOG_COM: 
*   Creates a log message of the communication area
*
**********************************************************************/
void DynamicObserverApp::OnLogCom() 
{
  LogDistributor::Instance().Log(LogMessage(LogMessage::evCom, LogMessage::evError,
                                           "This is my Com-Error-Output."));
}

/**********************************************************************
*
* DynamicObserverApp::OnLogUserActivity
*
* Description: Message handling IDM_LOG_GUI: 
*   Creates a log message of the user activity area
*
**********************************************************************/
void DynamicObserverApp::OnLogUserActivity() 
{
  LogDistributor::Instance().Log(LogMessage(LogMessage::evUserActivity, 
                                           LogMessage::evEvent,
                                           "This is my UserActivity-Event-Output."));
}
