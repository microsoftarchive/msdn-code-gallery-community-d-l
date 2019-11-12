
// MainFrm.h : interface de la classe CMainFrame
//

#pragma once

class CMainFrame : public CFrameWndEx
{
	
protected: // création à partir de la sérialisation uniquement
	CMainFrame();
	DECLARE_DYNCREATE(CMainFrame)

// Attributs
public:

// Opérations
public:

// Substitutions
public:
	virtual BOOL PreCreateWindow(CREATESTRUCT& cs);
	virtual BOOL LoadFrame(UINT nIDResource, DWORD dwDefaultStyle = WS_OVERLAPPEDWINDOW | FWS_ADDTOTITLE, CWnd* pParentWnd = NULL, CCreateContext* pContext = NULL);

// Implémentation
public:
	virtual ~CMainFrame();
#ifdef _DEBUG
	virtual void AssertValid() const;
	virtual void Dump(CDumpContext& dc) const;
#endif

protected:  // membres incorporés de la barre de contrôle
	CMFCMenuBar       m_wndMenuBar;
	CMFCToolBar       m_wndToolBar;
	CMFCStatusBar     m_wndStatusBar;
	CMFCToolBarImages m_UserImages;

// Fonctions générées de la table des messages
protected:
	afx_msg int OnCreate(LPCREATESTRUCT lpCreateStruct);
	afx_msg void OnViewCustomize();
	afx_msg LRESULT OnToolbarCreateNew(WPARAM wp, LPARAM lp);
	afx_msg void OnApplicationLook(UINT id);
	afx_msg void OnUpdateApplicationLook(CCmdUI* pCmdUI);

	// Menus modifiant l'indicateur de progrès
	afx_msg void OnProgress0();
	afx_msg void OnProgress50();
	afx_msg void OnProgress100();
	afx_msg void OnProgressNormal();
	afx_msg void OnProgressPause();
	afx_msg void OnProgressError();
	DECLARE_MESSAGE_MAP()

public:
	afx_msg void OnOverlayShow();
	afx_msg void OnOverlayHide();
};


