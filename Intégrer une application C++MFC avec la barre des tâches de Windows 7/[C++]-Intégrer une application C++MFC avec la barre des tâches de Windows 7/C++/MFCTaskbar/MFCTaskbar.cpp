
// MFCTaskbar.cpp : Définit les comportements de classe pour l'application.
//

#include "stdafx.h"
#include "afxwinappex.h"
#include "afxdialogex.h"
#include "MFCTaskbar.h"
#include "MainFrm.h"

#include "MFCTaskbarDoc.h"
#include "MFCTaskbarView.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#endif


// CMFCTaskbarApp

BEGIN_MESSAGE_MAP(CMFCTaskbarApp, CWinAppEx)
	ON_COMMAND(ID_APP_ABOUT, &CMFCTaskbarApp::OnAppAbout)
	// Commandes de fichier standard
	ON_COMMAND(ID_FILE_NEW, &CWinAppEx::OnFileNew)
	ON_COMMAND(ID_FILE_OPEN, &CWinAppEx::OnFileOpen)
END_MESSAGE_MAP()


// construction CMFCTaskbarApp

CMFCTaskbarApp::CMFCTaskbarApp()
{
	m_bHiColorIcons = TRUE;

	// prend en charge le Gestionnaire de redémarrage
	m_dwRestartManagerSupportFlags = AFX_RESTART_MANAGER_SUPPORT_ALL_ASPECTS;

	// TODO: remplacer la chaîne d'ID de l'application ci-dessous par une chaîne ID unique ; le format recommandé
	// pour la chaîne est CompanyName.ProductName.SubProduct.VersionInformation
	SetAppID(_T("BlogMFC.MFCTaskbar.FR.100"));

	// TODO: ajoutez ici du code de construction,
	// Placez toutes les initialisations significatives dans InitInstance
}

// Seul et unique objet CMFCTaskbarApp

CMFCTaskbarApp theApp;


// initialisation de CMFCTaskbarApp

BOOL CMFCTaskbarApp::InitInstance()
{
	// InitCommonControlsEx() est requis sur Windows XP si le manifeste de l'application
	// spécifie l'utilisation de ComCtl32.dll version 6 ou ultérieure pour activer les
	// styles visuels.  Dans le cas contraire, la création de fenêtres échouera.
	INITCOMMONCONTROLSEX InitCtrls;
	InitCtrls.dwSize = sizeof(InitCtrls);
	// À définir pour inclure toutes les classes de contrôles communs à utiliser
	// dans votre application.
	InitCtrls.dwICC = ICC_WIN95_CLASSES;
	InitCommonControlsEx(&InitCtrls);

	CWinAppEx::InitInstance();


	EnableTaskbarInteraction(FALSE);

	// AfxInitRichEdit2() est requis pour utiliser un contrôle RichEdit	
	// AfxInitRichEdit2();

	// Initialisation standard
	// Si vous n'utilisez pas ces fonctionnalités et que vous souhaitez réduire la taille
	// de votre exécutable final, vous devez supprimer ci-dessous
	// les routines d'initialisation spécifiques dont vous n'avez pas besoin.
	// Changez la clé de Registre sous laquelle nos paramètres sont enregistrés
	// TODO: modifiez cette chaîne avec des informations appropriées,
	// telles que le nom de votre société ou organisation
	SetRegistryKey(_T("Applications locales générées par AppWizard"));
	LoadStdProfileSettings(4);  // Charge les options de fichier INI standard (y compris les derniers fichiers utilisés)


	InitContextMenuManager();

	InitKeyboardManager();

	InitTooltipManager();
	CMFCToolTipInfo ttParams;
	ttParams.m_bVislManagerTheme = TRUE;
	theApp.GetTooltipManager()->SetTooltipParams(AFX_TOOLTIP_TYPE_ALL,
		RUNTIME_CLASS(CMFCToolTipCtrl), &ttParams);

	// Inscrire les modèles de document de l'application. Ces modèles
	//  lient les documents, fenêtres frame et vues entre eux
	CSingleDocTemplate* pDocTemplate;
	pDocTemplate = new CSingleDocTemplate(
		IDR_MAINFRAME,
		RUNTIME_CLASS(CMFCTaskbarDoc),
		RUNTIME_CLASS(CMainFrame),       // fenêtre frame SDI principale
		RUNTIME_CLASS(CMFCTaskbarView));
	if (!pDocTemplate)
		return FALSE;
	AddDocTemplate(pDocTemplate);

	// Activer les ouvertures d'exécution DDE
	EnableShellOpen();
	RegisterShellFileTypes(TRUE);


	// Récupère la couleur de la skin, Silver par défaut
	m_nAppLook = theApp.GetInt(_T("ApplicationLook"), ID_VIEW_APPLOOK_OFF_2007_SILVER);

	// Si paramètre sur la ligne de commande, on change la couleur de la skin
	if (!wcscmp(m_lpCmdLine, L"/blue"))
		m_nAppLook = ID_VIEW_APPLOOK_OFF_2007_BLUE;
	if (!wcscmp(m_lpCmdLine, L"/black"))
		m_nAppLook = ID_VIEW_APPLOOK_OFF_2007_BLACK;

	OnFileNew();

	// La seule fenêtre a été initialisée et peut donc être affichée et mise à jour
	m_pMainWnd->ShowWindow(SW_SHOW);
	m_pMainWnd->UpdateWindow();
	// appelle DragAcceptFiles uniquement s'il y a un suffixe
	//  Dans une application SDI, cet appel doit avoir lieu juste après ProcessShellCommand
	// Activer les ouvertures via glisser-déplacer
	m_pMainWnd->DragAcceptFiles();


	// Récupère le chemin du fichier exécutable
	TCHAR szModule[MAX_PATH]; 
	DWORD dwFLen = GetModuleFileName(nullptr, szModule, MAX_PATH);

	// Ajoute deux tâches au menu de la taskbar
	CJumpList TaskList;
	TaskList.AddTask(szModule, L"/blue", L"Lance l'application en bleu", 0,0);
	TaskList.AddTask(szModule, L"/black", L"Lance l'application en noir", 0,0);

	if (afxGlobalData.bIsWindows7) // Windows 7 ou +
	{
		// Crée deux boutons dans la miniature de l'application dans la barre des tâches
		THUMBBUTTON btn[2]; // Deux boutons

		btn[0].dwMask = THB_TOOLTIP|THB_ICON;
		btn[0].iId = ID_VIEW_APPLOOK_OFF_2007_BLACK;
		btn[0].hIcon = LoadIcon(IDI_ICON_BLACK);
		wcscpy_s(btn[0].szTip, L"Noir");

		btn[1].dwMask = THB_TOOLTIP|THB_ICON;
		btn[1].iId = ID_VIEW_APPLOOK_OFF_2007_BLUE;
		btn[1].hIcon = LoadIcon(IDI_ICON_BLUE);
		wcscpy_s(btn[1].szTip, L"Bleu");

		HWND hwndMain = AfxGetMainWnd()->GetSafeHwnd();
		ITaskbarList3 *pTaskBar = afxGlobalData.GetITaskbarList3();

		// Crée les deux boutons
		HRESULT hr = pTaskBar->ThumbBarAddButtons(hwndMain, 2, btn);
		ASSERT(SUCCEEDED(hr));
	}
	return TRUE;
}

// gestionnaires de messages pour CMFCTaskbarApp


// boîte de dialogue CAboutDlg utilisée pour la boîte de dialogue 'À propos de' pour votre application

class CAboutDlg : public CDialogEx
{
public:
	CAboutDlg();

// Données de boîte de dialogue
	enum { IDD = IDD_ABOUTBOX };

protected:
	virtual void DoDataExchange(CDataExchange* pDX);    // Prise en charge de DDX/DDV

// Implémentation
protected:
	DECLARE_MESSAGE_MAP()
};

CAboutDlg::CAboutDlg() : CDialogEx(CAboutDlg::IDD)
{
}

void CAboutDlg::DoDataExchange(CDataExchange* pDX)
{
	CDialogEx::DoDataExchange(pDX);
}

BEGIN_MESSAGE_MAP(CAboutDlg, CDialogEx)
END_MESSAGE_MAP()

// Commande App pour exécuter la boîte de dialogue
void CMFCTaskbarApp::OnAppAbout()
{
	CAboutDlg aboutDlg;
	aboutDlg.DoModal();
}

// CMFCTaskbarApp, méthodes de chargement/d'enregistrement de la personnalisation

void CMFCTaskbarApp::PreLoadState()
{
	BOOL bNameValid;
	CString strName;
	bNameValid = strName.LoadString(IDS_EDIT_MENU);
	ASSERT(bNameValid);
	GetContextMenuManager()->AddMenu(strName, IDR_POPUP_EDIT);
}

void CMFCTaskbarApp::LoadCustomState()
{
}

void CMFCTaskbarApp::SaveCustomState()
{
}

// gestionnaires de messages pour CMFCTaskbarApp



