/**********************************************************************
*
* DynamicObserver.h: Declaration of DynamicObserver
*
* DynamicObserver is the application class
*
* Author: Stefan Ruck, Frankfurt/Main, Germany, 2001
*
**********************************************************************/

#if !defined(AFX_DYNAMICOBSERVER_H__EEBDBF41_4901_11D5_9DD7_00C0F054D067__INCLUDED_)
#define AFX_DYNAMICOBSERVER_H__EEBDBF41_4901_11D5_9DD7_00C0F054D067__INCLUDED_

#if _MSC_VER > 1000
#pragma once
#endif // _MSC_VER > 1000

#ifndef __AFXWIN_H__
	#error include 'stdafx.h' before including this file for PCH
#endif

#include "resource.h"       // main symbols
#include <vector>

class LogObserver;

class DynamicObserverApp : public CWinApp
{
public:
  // Constructor
  DynamicObserverApp() { }

// Overrides
	// ClassWizard generated virtual function overrides
	//{{AFX_VIRTUAL(DynamicObserverApp)
	public:
	virtual BOOL InitInstance();
	virtual int ExitInstance();
	//}}AFX_VIRTUAL

// Implementation
protected:
	HMENU m_hMDIMenu;
	HACCEL m_hMDIAccel;

public:
	//{{AFX_MSG(DynamicObserverApp)
	afx_msg void OnAppAbout();
	afx_msg void OnConfigObserver();
	afx_msg void OnLogGui();
	afx_msg void OnLogCom();
	afx_msg void OnLogUserActivity();
	//}}AFX_MSG
	DECLARE_MESSAGE_MAP()
};


/////////////////////////////////////////////////////////////////////////////

//{{AFX_INSERT_LOCATION}}
// Microsoft Visual C++ will insert additional declarations immediately before the previous line.

#endif // !defined(AFX_DYNAMICOBSERVER_H__EEBDBF41_4901_11D5_9DD7_00C0F054D067__INCLUDED_)
