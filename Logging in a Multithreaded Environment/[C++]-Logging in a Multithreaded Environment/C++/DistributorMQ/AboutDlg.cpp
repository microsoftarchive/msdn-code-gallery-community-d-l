//////////////////////////////////////////////////////////////////////
//
// AboutDlg.cpp: implementation of the AboutDlg class.
//
//////////////////////////////////////////////////////////////////////

#include "stdafx.h"
#include "AboutDlg.h"

BEGIN_MESSAGE_MAP(AboutDlg, CDialog)
	//{{AFX_MSG_MAP(AboutDlg)
		// No message handlers
	//}}AFX_MSG_MAP
END_MESSAGE_MAP()

//////////////////////////////////////////////////////////////////////
// Construction/Destruction
//////////////////////////////////////////////////////////////////////

AboutDlg::AboutDlg() : CDialog(AboutDlg::IDD)
{
	//{{AFX_DATA_INIT(AboutDlg)
	//}}AFX_DATA_INIT
}

void AboutDlg::DoDataExchange(CDataExchange* pDX)
{
	CDialog::DoDataExchange(pDX);
	//{{AFX_DATA_MAP(AboutDlg)
	//}}AFX_DATA_MAP
}
