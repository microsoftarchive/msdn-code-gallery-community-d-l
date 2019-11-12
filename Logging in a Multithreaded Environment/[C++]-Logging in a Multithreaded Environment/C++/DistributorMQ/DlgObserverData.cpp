/**********************************************************************
*
* DlgObserverData.cpp: Definition of DlgObserverData
*
* Dialog to enter observer data
*
* Author: Stefan Ruck, Frankfurt/Main, Germany, 2001
*
**********************************************************************/

#include "stdafx.h"
#include "DistributorMQ.h"
#include "DlgObserverData.h"
#include "LogDistributor.h"
#include "LogObserver.h"
#include "ConsoleObserver.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif

BEGIN_MESSAGE_MAP(DlgObserverData, CDialog)
	//{{AFX_MSG_MAP(DlgObserverData)
	//}}AFX_MSG_MAP
END_MESSAGE_MAP()

/**********************************************************************
*
* DlgObserverData::DlgObserverData
*
* Description: Constructor
*
**********************************************************************/
DlgObserverData::DlgObserverData
  (
  CWnd* pParent /*=NULL*/
  )
	: CDialog(DlgObserverData::IDD, pParent)
{
	//{{AFX_DATA_INIT(DlgObserverData)
	//}}AFX_DATA_INIT
}

/**********************************************************************
*
* DlgObserverData::ConnectControls
*
* Description: Connects the controls of the dialog to the class members
*
* Comment: By default, this is implemented by DoDataExchange. Since
*          one only have to connect the controls once, it is seperated
*          into a separate method.
*
**********************************************************************/
void DlgObserverData::ConnectControls()
{
	CDataExchange DX(this, FALSE);
	CDataExchange * pDX = & DX; // to make class wizard happy

	//{{AFX_DATA_MAP(DlgObserverData)
	DDX_Control(pDX, IDC_CHK_USERACTIVITY, m_chkUserActivity);
	DDX_Control(pDX, IDC_CHK_COM, m_chkCom);
	DDX_Control(pDX, IDC_CHK_GUI, m_chkGUI);
	DDX_Control(pDX, IDC_ED_OUTPUTFILE, m_edOutputfile);
	DDX_Control(pDX, IDC_CBX_TYP, m_cbxType);
	DDX_Control(pDX, IDC_CBX_LEVEL, m_cbxLevel);
	//}}AFX_DATA_MAP
}

/**********************************************************************
*
* DlgObserverData::OnInitDialog
*
* Description: This member function is called in response to the WM_INITDIALOG message.
*
* Returns: BOOL
*			The application can return 0 only if it has explicitly set the input focus 
*			to one of the controls in the dialog box.
*
**********************************************************************/
BOOL DlgObserverData::OnInitDialog() 
{
	CDialog::OnInitDialog();
	
	ConnectControls();
	
	return TRUE;  // return TRUE unless you set the focus to a control
	              // EXCEPTION: OCX Property Pages should return FALSE
}

/**********************************************************************
*
* DlgObserverData::OnOK
*
* Description: Add the observer to the list
*
**********************************************************************/
void DlgObserverData::OnOK() 
{
  // Check whether all information is set
  if (m_cbxType.GetCurSel() == CB_ERR)
  {
    AfxMessageBox(IDS_ENTER_OBSERVER_TYPE);
    m_cbxType.SetFocus();
    return;
  }

  if (m_cbxLevel.GetCurSel() == CB_ERR)
  {
    AfxMessageBox(IDS_ENTER_OBSERVER_LEVEL);
    m_cbxType.SetFocus();
    return;
  }

  // Set the area of observer
  int iArea = 0;

  if (m_chkGUI.GetCheck())
    iArea += LogMessage::evGUI;

  if (m_chkCom.GetCheck())
    iArea += LogMessage::evCom;

  if (m_chkUserActivity.GetCheck())
    iArea += LogMessage::evUserActivity;

  if (!iArea)
  {
    AfxMessageBox(IDS_ENTER_OBSERVER_BEREICH);
    m_chkGUI.SetFocus();
    return;
  }

  // Create the new observer depending on the selected type
  LogObserver * pObserver = 0L;

  switch(m_cbxType.GetCurSel())
  {
    case LogObserver::Console:
      pObserver = new ConsoleObserver(iArea,
                                      (LogMessage::Level) m_cbxLevel.GetCurSel());
      break;
    default:
      AfxMessageBox(IDS_OBSERVER_NOT_IMPLEMENTED_YET);
      return;
  }

  // Register the observer
  LogDistributor::Instance() += pObserver;

	CDialog::OnOK();
}
