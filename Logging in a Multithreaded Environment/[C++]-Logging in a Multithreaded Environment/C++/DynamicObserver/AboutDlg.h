//////////////////////////////////////////////////////////////////////
//
// AboutDlg.h: interface for the AboutDlg class.
//
//////////////////////////////////////////////////////////////////////

#if !defined(AFX_ABOUTDLG_H__CA612612_B6AC_4398_B664_737D5F0FD162__INCLUDED_)
#define AFX_ABOUTDLG_H__CA612612_B6AC_4398_B664_737D5F0FD162__INCLUDED_

#if _MSC_VER > 1000
#pragma once
#endif // _MSC_VER > 1000

#include "resource.h"

class AboutDlg : public CDialog  
{
public:
	AboutDlg();
  virtual ~AboutDlg() { }

// Dialog Data
	//{{AFX_DATA(AboutDlg)
	enum { IDD = IDD_ABOUTBOX };
	//}}AFX_DATA

	// ClassWizard generated virtual function overrides
	//{{AFX_VIRTUAL(AboutDlg)
	protected:
	virtual void DoDataExchange(CDataExchange* pDX);    // DDX/DDV support
	//}}AFX_VIRTUAL

// Implementation
protected:
	//{{AFX_MSG(AboutDlg)
		// No message handlers
	//}}AFX_MSG
	DECLARE_MESSAGE_MAP()
};

#endif // !defined(AFX_ABOUTDLG_H__CA612612_B6AC_4398_B664_737D5F0FD162__INCLUDED_)
