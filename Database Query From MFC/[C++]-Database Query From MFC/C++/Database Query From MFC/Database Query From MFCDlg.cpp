
// Database Query From MFCDlg.cpp : implementation file
//

#include "stdafx.h"
#include "Database Query From MFC.h"
#include "Database Query From MFCDlg.h"
#include "afxdialogex.h"


#ifdef _DEBUG
#define new DEBUG_NEW
#endif

//to check is the query is a report or statement, untill we use the ExecuteSQL or CRecordset to get report
bool IsReport(CString code){
	code.TrimLeft();code.TrimRight();code.MakeLower();
	if(code.Left(6)==_T("insert")||code.Left(6)==_T("update"))return 0;
	return 1;
}


// CDatabaseQueryFromMFCDlg dialog



CDatabaseQueryFromMFCDlg::CDatabaseQueryFromMFCDlg(CWnd* pParent /*=NULL*/)
	: CDialogEx(CDatabaseQueryFromMFCDlg::IDD, pParent)
	, username(_T(""))
	, password(_T(""))
{
	m_hIcon = AfxGetApp()->LoadIcon(IDR_MAINFRAME);
}

void CDatabaseQueryFromMFCDlg::DoDataExchange(CDataExchange* pDX)
{
	CDialogEx::DoDataExchange(pDX);
	DDX_Control(pDX, IDC_COMBO2, odb);
	DDX_Control(pDX, IDC_EDIT1, tquery);
	DDX_Control(pDX, IDC_LIST1, list);
	DDX_Text(pDX, IDC_EDIT2, username);
	DDX_Text(pDX, IDC_EDIT3, password);
}

BEGIN_MESSAGE_MAP(CDatabaseQueryFromMFCDlg, CDialogEx)
	ON_WM_PAINT()
	ON_WM_QUERYDRAGICON()
	ON_CBN_SELCHANGE(IDC_COMBO2, &CDatabaseQueryFromMFCDlg::OnCbnSelchangeCombo2)
	ON_BN_CLICKED(IDC_BUTTON2, &CDatabaseQueryFromMFCDlg::OnBnClickedButton2)
	ON_BN_CLICKED(IDC_BUTTON3, &CDatabaseQueryFromMFCDlg::OnBnClickedButton3)
	ON_BN_CLICKED(IDC_BUTTON1, &CDatabaseQueryFromMFCDlg::OnBnClickedButton1)
END_MESSAGE_MAP()


// CDatabaseQueryFromMFCDlg message handlers
void CDatabaseQueryFromMFCDlg::OnOK(){
}

void CDatabaseQueryFromMFCDlg::OnCancel(){
	if(MessageBox(_T("You Sure ?"),_T("Exit"),MB_YESNO)==IDYES)PostQuitMessage(0);
}

BOOL CDatabaseQueryFromMFCDlg::OnInitDialog()
{
	CDialogEx::OnInitDialog();

	// Set the icon for this dialog.  The framework does this automatically
	//  when the application's main window is not a dialog
	SetIcon(m_hIcon, TRUE);			// Set big icon
	SetIcon(m_hIcon, FALSE);		// Set small icon

	SetBackgroundColor(RGB(90,90,90));
	TCHAR tc[260];GetCurrentDirectory(260,tc);path=tc;

	odb.AddString(_T("Access Database"));
	odb.AddString(_T("Excel Database"));
	odb.AddString(_T("SQL Database"));
	odb.SetCurSel(0);

	return TRUE;  // return TRUE  unless you set the focus to a control
}

// If you add a minimize button to your dialog, you will need the code below
//  to draw the icon.  For MFC applications using the document/view model,
//  this is automatically done for you by the framework.

void CDatabaseQueryFromMFCDlg::OnPaint()
{
	if (IsIconic())
	{
		CPaintDC dc(this); // device context for painting

		SendMessage(WM_ICONERASEBKGND, reinterpret_cast<WPARAM>(dc.GetSafeHdc()), 0);

		// Center icon in client rectangle
		int cxIcon = GetSystemMetrics(SM_CXICON);
		int cyIcon = GetSystemMetrics(SM_CYICON);
		CRect rect;
		GetClientRect(&rect);
		int x = (rect.Width() - cxIcon + 1) / 2;
		int y = (rect.Height() - cyIcon + 1) / 2;

		// Draw the icon
		dc.DrawIcon(x, y, m_hIcon);
	}
	else
	{
		CDialogEx::OnPaint();
	}
}

// The system calls this function to obtain the cursor to display while the user drags
//  the minimized window.
HCURSOR CDatabaseQueryFromMFCDlg::OnQueryDragIcon()
{
	return static_cast<HCURSOR>(m_hIcon);
}



void CDatabaseQueryFromMFCDlg::OnCbnSelchangeCombo2()
{

}


void CDatabaseQueryFromMFCDlg::OnBnClickedButton2()//connect
{
if(database.IsOpen()){
	MessageBox(_T("The database is connected to application."));goto fin;
}
UpdateData(1);
//Access Driver
Connection[0]=_T("Driver={Microsoft Access Driver (*.mdb)};Server:.;Dbq=")+path+_T("\\db.mdb;Uid=")+username+_T(";Pwd=")+password+_T(";");

//Excel Driver
Connection[1]=_T("Driver={Microsoft Excel Driver (*.xls)};DriverId=790;bq=db.xls;Uid=")+username+_T(";Pwd=")+password+_T(";");

//SQL Driver
Connection[2]=_T("Driver={SQL Server Native Client 11.0};Server=.;AttachDbFilename=db.mdf;Trusted_Connection=Yes;Uid=")+username+_T(";Pwd=")+password+_T(";");

strConnection=Connection[odb.GetCurSel()];
if(database.OpenEx(strConnection,CDatabase::useCursorLib)){
	MessageBox(_T("Connected Succefully."));
	tquery.EnableWindow(1);
	list.EnableWindow(1);
	GetDlgItem(IDC_BUTTON1)->EnableWindow(1);
	list.ResetContent();
}else MessageBox(_T("Failed to Connect to the Database File."),0,0);
fin:;
}


void CDatabaseQueryFromMFCDlg::OnBnClickedButton3()
{
if(database.IsOpen()){
	MessageBox(_T("Dissonnected Succefully."));
	list.ResetContent();
	tquery.EnableWindow(0);
	list.EnableWindow(0);
	GetDlgItem(IDC_BUTTON1)->EnableWindow(0);
	database.Close();
}
}


void CDatabaseQueryFromMFCDlg::OnBnClickedButton1()//Query
{
CString query;
tquery.GetWindowText(query);
list.ResetContent();
if(IsReport(query)){//this is a report command
	CRecordset recordset(&database);
	CString temp,record;
	recordset.Open(CRecordset::forwardOnly,query,CRecordset::readOnly);
	while(!recordset.IsEOF()){//is null
		record=_T("");
		register int len=recordset.GetODBCFieldCount();
		for(register int i=0;i<len;i++){
				recordset.GetFieldValue(i,temp);
				record+=temp+_T("   |   ");
		}
		list.AddString(record);
		recordset.MoveNext();
	}
}else{
	database.ExecuteSQL(query);
}
MessageBox(_T("Query done."),0,0);


}
