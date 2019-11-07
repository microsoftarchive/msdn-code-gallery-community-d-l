/**********************************************************************
*
* DistributorMQ.h: Declaration of DistributorMQApp
*
* DistributorMQApp is the application class
*
* Author: Stefan Ruck, Frankfurt/Main, Germany, 2001
*
**********************************************************************/

#if !defined(AFX_DISTRIBUTORMQ_H__11392A2E_49FF_11D5_9DDB_00C0F054D067__INCLUDED_)
#define AFX_DISTRIBUTORMQ_H__11392A2E_49FF_11D5_9DDB_00C0F054D067__INCLUDED_

#if _MSC_VER > 1000
#pragma once
#endif // _MSC_VER > 1000

#ifndef __AFXWIN_H__
	#error include 'stdafx.h' before including this file for PCH
#endif

#include "resource.h"       // main symbols

class DistributorMQApp : public CWinApp
{
public:
  // Constructor
  DistributorMQApp() { }

// Overrides
	// ClassWizard generated virtual function overrides
	//{{AFX_VIRTUAL(DistributorMQApp)
	public:
	virtual BOOL InitInstance();
	virtual int ExitInstance();
	//}}AFX_VIRTUAL

// Implementation
protected:
	HMENU m_hMDIMenu;
	HACCEL m_hMDIAccel;

public:
	//{{AFX_MSG(DistributorMQApp)
	afx_msg void OnAppAbout();
	afx_msg void OnConfigObserver();
	afx_msg void OnLogGui();
	afx_msg void OnLogCom();
	afx_msg void OnLogUserActivity();
	//}}AFX_MSG
	DECLARE_MESSAGE_MAP()

private:
};


/////////////////////////////////////////////////////////////////////////////

//{{AFX_INSERT_LOCATION}}
// Microsoft Visual C++ will insert additional declarations immediately before the previous line.

#endif // !defined(AFX_DISTRIBUTORMQ_H__11392A2E_49FF_11D5_9DDB_00C0F054D067__INCLUDED_)
