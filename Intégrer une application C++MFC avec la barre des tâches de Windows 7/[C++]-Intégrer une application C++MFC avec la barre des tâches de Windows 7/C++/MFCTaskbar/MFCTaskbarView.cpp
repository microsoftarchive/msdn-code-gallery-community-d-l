
// MFCTaskbarView.cpp : implémentation de la classe CMFCTaskbarView
//

#include "stdafx.h"
// SHARED_HANDLERS peuvent être définis dans les gestionnaires d'aperçu, de miniature
// et de recherche d'implémentation de projet ATL et permettent la partage de code de document avec ce projet.
#ifndef SHARED_HANDLERS
#include "MFCTaskbar.h"
#endif

#include "MFCTaskbarDoc.h"
#include "MFCTaskbarView.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#endif


// CMFCTaskbarView

IMPLEMENT_DYNCREATE(CMFCTaskbarView, CEditView)

BEGIN_MESSAGE_MAP(CMFCTaskbarView, CEditView)
	ON_WM_CONTEXTMENU()
	ON_WM_RBUTTONUP()
END_MESSAGE_MAP()

// construction ou destruction de CMFCTaskbarView

CMFCTaskbarView::CMFCTaskbarView()
{
	// TODO: ajoutez ici du code de construction

}

CMFCTaskbarView::~CMFCTaskbarView()
{
}

BOOL CMFCTaskbarView::PreCreateWindow(CREATESTRUCT& cs)
{
	// TODO: changez ici la classe ou les styles Window en modifiant
	//  CREATESTRUCT cs

	BOOL bPreCreated = CEditView::PreCreateWindow(cs);
	cs.style &= ~(ES_AUTOHSCROLL|WS_HSCROLL);	// Active le retour automatique à la ligne

	return bPreCreated;
}

void CMFCTaskbarView::OnRButtonUp(UINT /* nFlags */, CPoint point)
{
	ClientToScreen(&point);
	OnContextMenu(this, point);
}

void CMFCTaskbarView::OnContextMenu(CWnd* /* pWnd */, CPoint point)
{
#ifndef SHARED_HANDLERS
	theApp.GetContextMenuManager()->ShowPopupMenu(IDR_POPUP_EDIT, point.x, point.y, this, TRUE);
#endif
}


// diagnostics pour CMFCTaskbarView

#ifdef _DEBUG
void CMFCTaskbarView::AssertValid() const
{
	CEditView::AssertValid();
}

void CMFCTaskbarView::Dump(CDumpContext& dc) const
{
	CEditView::Dump(dc);
}

CMFCTaskbarDoc* CMFCTaskbarView::GetDocument() const // la version non Debug est inline
{
	ASSERT(m_pDocument->IsKindOf(RUNTIME_CLASS(CMFCTaskbarDoc)));
	return (CMFCTaskbarDoc*)m_pDocument;
}
#endif //_DEBUG


// gestionnaires de messages pour CMFCTaskbarView
