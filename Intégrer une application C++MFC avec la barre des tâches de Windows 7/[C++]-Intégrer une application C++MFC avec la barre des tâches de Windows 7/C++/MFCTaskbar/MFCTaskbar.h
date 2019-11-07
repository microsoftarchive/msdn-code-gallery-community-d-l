
// MFCTaskbar.h : fichier d'en-tête principal pour l'application MFCTaskbar
//
#pragma once

#ifndef __AFXWIN_H__
	#error "incluez 'stdafx.h' avant d'inclure ce fichier pour PCH"
#endif

#include "resource.h"       // symboles principaux


// CMFCTaskbarApp:
// Consultez MFCTaskbar.cpp pour l'implémentation de cette classe
//

class CMFCTaskbarApp : public CWinAppEx
{
public:
	CMFCTaskbarApp();


// Substitutions
public:
	virtual BOOL InitInstance();

// Implémentation
	UINT  m_nAppLook;
	BOOL  m_bHiColorIcons;

	virtual void PreLoadState();
	virtual void LoadCustomState();
	virtual void SaveCustomState();

	afx_msg void OnAppAbout();
	DECLARE_MESSAGE_MAP()
};

extern CMFCTaskbarApp theApp;
