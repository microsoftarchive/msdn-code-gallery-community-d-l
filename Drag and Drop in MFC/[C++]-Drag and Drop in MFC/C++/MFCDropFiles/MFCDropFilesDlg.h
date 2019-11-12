
// MFCDropFilesDlg.h : header file
//

#pragma once
#include "afxwin.h"


// CMFCDropFilesDlg dialog
class CMFCDropFilesDlg : public CDialogEx
{
// Construction
public:
	CMFCDropFilesDlg(CWnd* pParent = NULL);	// standard constructor

// Dialog Data
	enum { IDD = IDD_MFCDROPFILES_DIALOG };

	protected:
	virtual void DoDataExchange(CDataExchange* pDX);	// DDX/DDV support


// Implementation
protected:
	HICON m_hIcon;

	// Generated message map functions
	virtual BOOL OnInitDialog();
	afx_msg void OnSysCommand(UINT nID, LPARAM lParam);
	afx_msg void OnPaint();
	afx_msg HCURSOR OnQueryDragIcon();
	afx_msg void OnDropFiles (HDROP dropInfo);

	DECLARE_MESSAGE_MAP()
public:
	CListBox list;
};
