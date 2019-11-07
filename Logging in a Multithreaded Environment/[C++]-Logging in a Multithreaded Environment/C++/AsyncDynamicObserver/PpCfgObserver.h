/**********************************************************************
*
* PpCfgObserver.h: Declaration of PpCfgObserver
*
* PropertyPage to set up log observer
*
* Author: Stefan Ruck, Frankfurt/Main, Germany, 2001
*
**********************************************************************/

#if !defined(AFX_PPCFGOBSERVER_H__9D0010E4_4921_11D5_9DD8_00C0F054D067__INCLUDED_)
#define AFX_PPCFGOBSERVER_H__9D0010E4_4921_11D5_9DD8_00C0F054D067__INCLUDED_

#if _MSC_VER > 1000
#pragma once
#endif // _MSC_VER > 1000

#include "resource.h"

class PpCfgObserver : public CPropertyPage
{
	DECLARE_DYNCREATE(PpCfgObserver)

public:
  // Constructor
	PpCfgObserver();

// Overrides
	// ClassWizard generate virtual function overrides
	//{{AFX_VIRTUAL(PpCfgObserver)
	//}}AFX_VIRTUAL

// Implementation
protected:

  // Connects the controls of the dialog to the class members
  void ConnectControls();

	// Generated message map functions
	//{{AFX_MSG(PpCfgObserver)
	afx_msg void OnBtnAdd();
	virtual BOOL OnInitDialog();
  afx_msg void OnItemChangedLbxObserver(NMHDR* pNMHDR, LRESULT* pResult);
	afx_msg void OnBtnRemove();
	//}}AFX_MSG
	DECLARE_MESSAGE_MAP()

private:
  enum { evColType, evColArea, evColLevel };

  // Fills the observer list
  void FillObserverList();

// Dialog Data
	//{{AFX_DATA(PpCfgObserver)
	enum { IDD = IDD_CFG_OBSERVER };
	CListCtrl	m_lbxObserver;
	CButton	m_btnRemove;
	//}}AFX_DATA
};

//{{AFX_INSERT_LOCATION}}
// Microsoft Visual C++ will insert additional declarations immediately before the previous line.

#endif // !defined(AFX_PPCFGOBSERVER_H__9D0010E4_4921_11D5_9DD8_00C0F054D067__INCLUDED_)
