/**********************************************************************
*
* DlgObserverData.h: Declaration of DlgObserverData
*
* Dialog to enter observer data
*
* Author: Stefan Ruck, Frankfurt/Main, Germany, 2001
*
**********************************************************************/

#if !defined(AFX_DLGOBSERVERDATA_H__9D0010E3_4921_11D5_9DD8_00C0F054D067__INCLUDED_)
#define AFX_DLGOBSERVERDATA_H__9D0010E3_4921_11D5_9DD8_00C0F054D067__INCLUDED_

#if _MSC_VER > 1000
#pragma once
#endif // _MSC_VER > 1000

class DlgObserverData : public CDialog
{
public:
  // Constructor
	DlgObserverData
    (
    CWnd* pParent = NULL
    );

	// ClassWizard generated virtual function overrides
	//{{AFX_VIRTUAL(DlgObserverData)
	//}}AFX_VIRTUAL

protected:

	// Generated message map functions
	//{{AFX_MSG(DlgObserverData)
	virtual BOOL OnInitDialog();
	virtual void OnOK();
	//}}AFX_MSG
	DECLARE_MESSAGE_MAP()

private:
  // Connects the controls of the dialog to the class members
  void ConnectControls();

// Dialog Data
	//{{AFX_DATA(DlgObserverData)
	enum { IDD = IDD_DLG_OBSERVER_DATA };
	CButton	m_chkUserActivity;
	CButton	m_chkCom;
	CButton	m_chkGUI;
	CEdit	m_edOutputfile;
	CComboBox	m_cbxType;
	CComboBox	m_cbxLevel;
	//}}AFX_DATA
};

//{{AFX_INSERT_LOCATION}}
// Microsoft Visual C++ will insert additional declarations immediately before the previous line.

#endif // !defined(AFX_DLGOBSERVERDATA_H__9D0010E3_4921_11D5_9DD8_00C0F054D067__INCLUDED_)
