/**********************************************************************
*
* DistributorMQ.cpp: Definition of DistributorMQApp
*
* DistributorMQApp is the application class
*
* Author: Stefan Ruck, Frankfurt/Main, Germany, 2001
*
**********************************************************************/

#include "stdafx.h"

#include <io.h>
#include <fcntl.h>

#include "DistributorMQ.h"

#include "MainFrm.h"
#include "LogDistributor.h"
#include "LogObserver.h"
#include "PpCfgObserver.h"
#include "LoggerThread.h"
#include "AboutDlg.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif

// Threads to permanently generate log output
static LoggerThread saLogger[3];

BEGIN_MESSAGE_MAP(DistributorMQApp, CWinApp)
	//{{AFX_MSG_MAP(DistributorMQApp)
	ON_COMMAND(ID_APP_ABOUT, OnAppAbout)
	ON_COMMAND(IDM_CONFIG_OBSERVER, OnConfigObserver)
	ON_COMMAND(IDM_LOG_GUI, OnLogGui)
	ON_COMMAND(IDM_LOG_COM, OnLogCom)
	ON_COMMAND(IDM_LOG_USERACTIVITY, OnLogUserActivity)
	//}}AFX_MSG_MAP
END_MESSAGE_MAP()


/////////////////////////////////////////////////////////////////////////////
// The one and only DistributorMQApp object

DistributorMQApp theApp;

/**********************************************************************
*
* DistributorMQApp::InitInstance
*
* Description: The framework’s implementation of WinMain calls this function.
*
* Returns: BOOL
*     Nonzero if initialization is successful; otherwise 0.
*
**********************************************************************/
BOOL DistributorMQApp::InitInstance()
{
	// Standard initialization
	// If you are not using these features and wish to reduce the size
	//  of your final executable, you should remove from the following
	//  the specific initialization routines you do not need.

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

  // Create the instance and initialize its critical section (done by ctor)
  LogDistributor::Instance().Initialize().Start();

  // Start the log output generator threads
  saLogger[0].Start();
  saLogger[1].Start();
  saLogger[2].Start();

	// try to load shared MDI menus and accelerator table
	//TODO: add additional member variables and load calls for
	//	additional menu types your application may need. 

	HINSTANCE hInst = AfxGetResourceHandle();
	m_hMDIMenu  = ::LoadMenu(hInst, MAKEINTRESOURCE(IDR_ASYNCDTYPE));
	m_hMDIAccel = ::LoadAccelerators(hInst, MAKEINTRESOURCE(IDR_ASYNCDTYPE));

	// The main window has been initialized, so show and update it.
	pFrame->ShowWindow(m_nCmdShow);
	pFrame->UpdateWindow();

	return TRUE;
}

/**********************************************************************
*
* DistributorMQApp::ExitInstance
*
* Description: Called by the framework from within the Run member 
*     function to exit this instance of the application. 
*
* Returns: int
*     The application’s exit code; 0 indicates no errors, and values greater 
*     than 0 indicate an error. This value is used as the return value from WinMain.
*
**********************************************************************/
int DistributorMQApp::ExitInstance() 
{
	//TODO: handle additional resources you may have added
	if (m_hMDIMenu != NULL)
		FreeResource(m_hMDIMenu);
	if (m_hMDIAccel != NULL)
		FreeResource(m_hMDIAccel);

  // Stop the log output generator threads
  saLogger[0].End(true);
  saLogger[1].End(true);
  saLogger[2].End(true);

  LogDistributor::Instance().End(true);

	return CWinApp::ExitInstance();
}

/**********************************************************************
*
* DistributorMQApp::OnAppAbout
*
* Description: Message handling ID_APP_ABOUT: Shows the About dialog
*
**********************************************************************/
void DistributorMQApp::OnAppAbout()
{
	AboutDlg aboutDlg;

	aboutDlg.DoModal();
}

/**********************************************************************
*
* DistributorMQApp::OnConfigObserver
*
* Description: Message handling IDM_CONFIG_OBSERVER: 
*   Shows the observer config sheet
*
**********************************************************************/
void DistributorMQApp::OnConfigObserver() 
{
  CPropertySheet sheet(IDS_OBSERVER);
  PpCfgObserver ppCfgObserver;

  sheet.AddPage(&ppCfgObserver);

  sheet.DoModal();
}

/**********************************************************************
*
* DistributorMQApp::OnLogGui
*
* Description: Message handling IDM_LOG_GUI: 
*   Creates a log message of the GUI area
*
**********************************************************************/
void DistributorMQApp::OnLogGui() 
{
  LogDistributor::Instance().Log(LogMessage(LogMessage::evGUI, LogMessage::evTrace,
                                           "This is my GUI-Trace-Output."));
}

/**********************************************************************
*
* DistributorMQApp::OnLogCom
*
* Description: Message handling IDM_LOG_COM: 
*   Creates a log message of the communication area
*
**********************************************************************/
void DistributorMQApp::OnLogCom() 
{
  LogDistributor::Instance().Log(LogMessage(LogMessage::evCom, LogMessage::evError,
                                           "This is my Com-Error-Output."));
}

/**********************************************************************
*
* DistributorMQApp::OnLogUserActivity
*
* Description: Message handling IDM_LOG_GUI: 
*   Creates a log message of the user activity area
*
**********************************************************************/
void DistributorMQApp::OnLogUserActivity() 
{
  LogDistributor::Instance().Log(LogMessage(LogMessage::evUserActivity, 
                                           LogMessage::evEvent,
                                           "This is my UserActivity-Event-Output."));
}
