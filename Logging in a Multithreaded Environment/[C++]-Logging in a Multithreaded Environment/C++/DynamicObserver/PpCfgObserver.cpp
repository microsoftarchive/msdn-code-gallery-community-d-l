/**********************************************************************
*
* PpCfgObserver.cpp: Definition of PpCfgObserver
*
* PropertyPage to set up log observer
*
* Author: Stefan Ruck, Frankfurt/Main, Germany, 2001
*
**********************************************************************/

#include "stdafx.h"
#include "DynamicObserver.h"
#include "PpCfgObserver.h"
#include "DlgObserverData.h"
#include "LogObserver.h"
#include "LogDistributor.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif

IMPLEMENT_DYNCREATE(PpCfgObserver, CPropertyPage)

BEGIN_MESSAGE_MAP(PpCfgObserver, CPropertyPage)
	//{{AFX_MSG_MAP(PpCfgObserver)
	ON_BN_CLICKED(IDC_BTN_ADD, OnBtnAdd)
	ON_BN_CLICKED(IDC_BTN_REMOVE, OnBtnRemove)
	//}}AFX_MSG_MAP
END_MESSAGE_MAP()

// Only for internal use, no need to add it to the class' private interface
// Inserts a column into a list control
static void InsertColumn
	(
	CListCtrl & rListCtrl,  // ListControl to insert the column into
	const int iCol,		      // Column number
	const int iResourceId,  // ResourceId of the column label
	const int iWidth	      // Width of the column
	);


/**********************************************************************
*
* PpCfgObserver::PpCfgObserver
*
* Description: Constructor
*
**********************************************************************/
PpCfgObserver::PpCfgObserver() 
  : CPropertyPage(PpCfgObserver::IDD)
{
	//{{AFX_DATA_INIT(PpCfgObserver)
		// NOTE: the ClassWizard will add member initialization here
	//}}AFX_DATA_INIT
}

/**********************************************************************
*
* PpCfgObserver::ConnectControls
*
* Description: Connects the controls of the dialog to the class members
*
* Comment: By default, this is implemented by DoDataExchange. Since
*          one only have to connect the controls once, it is seperated
*          into this method.
*
**********************************************************************/
void PpCfgObserver::ConnectControls()
{
	CDataExchange DX(this, FALSE);
	CDataExchange * pDX = & DX; // to make class wizard happy

	//{{AFX_DATA_MAP(PpCfgObserver)
	DDX_Control(pDX, IDC_LBX_OBSERVER, m_lbxObserver);
	DDX_Control(pDX, IDC_BTN_REMOVE, m_btnRemove);
	//}}AFX_DATA_MAP
}

/**********************************************************************
*
* PpCfgObserver::OnInitDialog
*
* Description: This member function is called in response to the WM_INITDIALOG message.
*
* Returns: BOOL
*			The application can return 0 only if it has explicitly set the input focus 
*			to one of the controls in the dialog box.
*
**********************************************************************/
BOOL PpCfgObserver::OnInitDialog() 
{
	CPropertyPage::OnInitDialog();

  ConnectControls();

  // Set up the list control columns
	::InsertColumn(m_lbxObserver, evColType, IDS_TYPE, 175);
	::InsertColumn(m_lbxObserver, evColArea, IDS_AREA, 175);
	::InsertColumn(m_lbxObserver, evColLevel, IDS_LEVEL, 175);

  m_lbxObserver.SetExtendedStyle(LVS_EX_FULLROWSELECT);

  FillObserverList();
	
	return TRUE;  // return TRUE unless you set the focus to a control
	              // EXCEPTION: OCX Property Pages should return FALSE
}

/**********************************************************************
*
* PpCfgObserver::FillObserverList
*
* Description: Fills the observer list
*
**********************************************************************/
void PpCfgObserver::FillObserverList()
{
  int iItem;
  CString strValue;

  // Clear the list
  m_lbxObserver.DeleteAllItems();

  const LogObserver * pObserver = 0L;

  int iObservers = LogDistributor::Instance().GetNumberOfObservers();

  // Insert each observer
  for(int iCurrentObserver = 0; iCurrentObserver < iObservers; ++iCurrentObserver)
  {
    pObserver = LogDistributor::Instance().GetObserver(iCurrentObserver);
    // Insert the observer type into the list
    switch(pObserver->GetType())
    {
      case LogObserver::Console:
        strValue = "Console";
        break;
      case LogObserver::Window:
        strValue = "Window";
        break;
      case LogObserver::File:
        strValue = "File";
        break;
      default:
        ASSERT(FALSE);
        strValue = "unknown";
        break;
    }
    iItem = m_lbxObserver.InsertItem(evColType, strValue);

    // Insert the area to which the observer is listening
    strValue = "";
    if (pObserver->GetArea() & LogMessage::evGUI)
      strValue = "GUI";
    if (pObserver->GetArea() & LogMessage::evCom)
      strValue += strValue.IsEmpty() ? "Com" : " / Com";
    if (pObserver->GetArea() & LogMessage::evUserActivity)
      strValue += strValue.IsEmpty() ? "UserActivity" : " / UserActivity";
    m_lbxObserver.SetItemText(iItem, evColArea, strValue);

    // Insert the message level of the observer
    switch(pObserver->GetLevel())
    {
      case LogMessage::evError:
        strValue = "Error";
        break;
      case LogMessage::evEvent:
        strValue = "Event";
        break;
      case LogMessage::evTrace:
        strValue = "Trace";
        break;
      case LogMessage::evDebug:
        strValue = "Debug";
        break;
      default:
        ASSERT(FALSE);
        strValue = "unknown";
        break;
    }
    m_lbxObserver.SetItemText(iItem, evColLevel, strValue);

    // 'Connect' the item to the observer to be able to remove it later
    m_lbxObserver.SetItemData(iItem, reinterpret_cast<DWORD> (pObserver)); 
  }

  m_btnRemove.EnableWindow(m_lbxObserver.GetItemCount());
}

/**********************************************************************
*
* PpCfgObserver::OnBtnAdd
*
* Description: Message handling IDC_BTN_ADD: Add a new Observer
*
**********************************************************************/
void PpCfgObserver::OnBtnAdd() 
{
  DlgObserverData dlg;

  if (dlg.DoModal() != IDOK)
    return;

  FillObserverList();
}

/**********************************************************************
*
* PpCfgObserver::OnBtnRemove
*
* Description: Message handling IDC_BTN_REMOVE: 
*   Remove the selected observer
*
**********************************************************************/
void PpCfgObserver::OnBtnRemove() 
{
  int iItem = m_lbxObserver.GetNextItem(-1, LVNI_SELECTED);

  if (iItem == -1) // Any observer selected?
  {
    AfxMessageBox(IDS_SELECT_OBSERVER_TO_REMOVE);
    return;
  }

  LogObserver * pObserver 
    = reinterpret_cast<LogObserver *> (m_lbxObserver.GetItemData(iItem));

  // Remove the observer from the list and free memory
  LogDistributor::Instance() -= pObserver;

  // Rebuild the list
  FillObserverList();
}

/**********************************************************************
*
* InsertColumn
*
* Description: Inserts a column into a list control
*
* Comment: Locale static helper function, not a class member
*
**********************************************************************/
void InsertColumn
	(
	CListCtrl & rListCtrl,  // ListControl to insert the column into
	const int iCol,		      // Column numver
	const int iResourceId,  // ResourceId of the column label
	const int iWidth	      // Width of the column
	)
{
	CString strLabel;

	strLabel.LoadString(iResourceId);

	rListCtrl.InsertColumn(iCol, strLabel, LVCFMT_LEFT, iWidth);
}