
// MFCTaskbarView.h : interface de la classe CMFCTaskbarView
//

#pragma once


class CMFCTaskbarView : public CEditView
{
protected: // création à partir de la sérialisation uniquement
	CMFCTaskbarView();
	DECLARE_DYNCREATE(CMFCTaskbarView)

// Attributs
public:
	CMFCTaskbarDoc* GetDocument() const;

// Opérations
public:

// Substitutions
public:
	virtual BOOL PreCreateWindow(CREATESTRUCT& cs);
protected:

// Implémentation
public:
	virtual ~CMFCTaskbarView();
#ifdef _DEBUG
	virtual void AssertValid() const;
	virtual void Dump(CDumpContext& dc) const;
#endif

protected:

// Fonctions générées de la table des messages
protected:
	afx_msg void OnFilePrintPreview();
	afx_msg void OnRButtonUp(UINT nFlags, CPoint point);
	afx_msg void OnContextMenu(CWnd* pWnd, CPoint point);
	DECLARE_MESSAGE_MAP()
};

#ifndef _DEBUG  // version debug dans MFCTaskbarView.cpp
inline CMFCTaskbarDoc* CMFCTaskbarView::GetDocument() const
   { return reinterpret_cast<CMFCTaskbarDoc*>(m_pDocument); }
#endif

