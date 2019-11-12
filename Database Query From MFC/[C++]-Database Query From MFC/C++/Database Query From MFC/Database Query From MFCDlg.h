
// Database Query From MFCDlg.h : header file
//

#pragma once
#include "afxwin.h"
#include <afxdb.h>

// CDatabaseQueryFromMFCDlg dialog
class CDatabaseQueryFromMFCDlg : public CDialogEx
{
// Construction
public:
	CString strConnection;
	CString Connection[3];
	CDatabase database;
	CString path;

	CDatabaseQueryFromMFCDlg(CWnd* pParent = NULL);	// standard constructor
	void OnOK();
	void OnCancel();
// Dialog Data
	enum { IDD = IDD_DATABASEQUERYFROMMFC_DIALOG };

	protected:
	virtual void DoDataExchange(CDataExchange* pDX);	// DDX/DDV support


// Implementation
protected:
	HICON m_hIcon;

	// Generated message map functions
	virtual BOOL OnInitDialog();
	afx_msg void OnPaint();
	afx_msg HCURSOR OnQueryDragIcon();
	DECLARE_MESSAGE_MAP()
public:
	CComboBox odb;
	CEdit tquery;
	CListBox list;
	afx_msg void OnCbnSelchangeCombo2();
	CString username;
	CString password;
	afx_msg void OnBnClickedButton2();
	afx_msg void OnBnClickedButton3();
	afx_msg void OnBnClickedButton1();
};
