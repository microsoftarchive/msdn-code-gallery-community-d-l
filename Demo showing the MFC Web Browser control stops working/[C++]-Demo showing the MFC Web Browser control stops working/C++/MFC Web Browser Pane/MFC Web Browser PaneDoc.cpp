
// MFC Web Browser PaneDoc.cpp : implementation of the CMFCWebBrowserPaneDoc class
//

#include "stdafx.h"
// SHARED_HANDLERS can be defined in an ATL project implementing preview, thumbnail
// and search filter handlers and allows sharing of document code with that project.
#ifndef SHARED_HANDLERS
#include "MFC Web Browser Pane.h"
#endif

#include "MFC Web Browser PaneDoc.h"
#include "CntrItem.h"

#include <propkey.h>

#ifdef _DEBUG
#define new DEBUG_NEW
#endif

// CMFCWebBrowserPaneDoc

IMPLEMENT_DYNCREATE(CMFCWebBrowserPaneDoc, COleDocument)

BEGIN_MESSAGE_MAP(CMFCWebBrowserPaneDoc, COleDocument)
	// Enable default OLE container implementation
	ON_UPDATE_COMMAND_UI(ID_EDIT_PASTE, &COleDocument::OnUpdatePasteMenu)
	ON_UPDATE_COMMAND_UI(ID_EDIT_PASTE_LINK, &COleDocument::OnUpdatePasteLinkMenu)
	ON_UPDATE_COMMAND_UI(ID_OLE_EDIT_CONVERT, &COleDocument::OnUpdateObjectVerbMenu)
	ON_COMMAND(ID_OLE_EDIT_CONVERT, &COleDocument::OnEditConvert)
	ON_UPDATE_COMMAND_UI(ID_OLE_EDIT_LINKS, &COleDocument::OnUpdateEditLinksMenu)
	ON_UPDATE_COMMAND_UI(ID_OLE_VERB_POPUP, &CMFCWebBrowserPaneDoc::OnUpdateObjectVerbPopup)
	ON_COMMAND(ID_OLE_EDIT_LINKS, &COleDocument::OnEditLinks)
	ON_UPDATE_COMMAND_UI_RANGE(ID_OLE_VERB_FIRST, ID_OLE_VERB_LAST, &COleDocument::OnUpdateObjectVerbMenu)
END_MESSAGE_MAP()


// CMFCWebBrowserPaneDoc construction/destruction

CMFCWebBrowserPaneDoc::CMFCWebBrowserPaneDoc()
{
	// Use OLE compound files
	EnableCompoundFile();

	// TODO: add one-time construction code here

}

CMFCWebBrowserPaneDoc::~CMFCWebBrowserPaneDoc()
{
}

BOOL CMFCWebBrowserPaneDoc::OnNewDocument()
{
	if (!COleDocument::OnNewDocument())
		return FALSE;

	// TODO: add reinitialization code here
	// (SDI documents will reuse this document)

	return TRUE;
}




// CMFCWebBrowserPaneDoc serialization

void CMFCWebBrowserPaneDoc::Serialize(CArchive& ar)
{
	if (ar.IsStoring())
	{
		// TODO: add storing code here
	}
	else
	{
		// TODO: add loading code here
	}

	// Calling the base class COleDocument enables serialization
	//  of the container document's COleClientItem objects.
	COleDocument::Serialize(ar);
}

#ifdef SHARED_HANDLERS

// Support for thumbnails
void CMFCWebBrowserPaneDoc::OnDrawThumbnail(CDC& dc, LPRECT lprcBounds)
{
	// Modify this code to draw the document's data
	dc.FillSolidRect(lprcBounds, RGB(255, 255, 255));

	CString strText = _T("TODO: implement thumbnail drawing here");
	LOGFONT lf;

	CFont* pDefaultGUIFont = CFont::FromHandle((HFONT) GetStockObject(DEFAULT_GUI_FONT));
	pDefaultGUIFont->GetLogFont(&lf);
	lf.lfHeight = 36;

	CFont fontDraw;
	fontDraw.CreateFontIndirect(&lf);

	CFont* pOldFont = dc.SelectObject(&fontDraw);
	dc.DrawText(strText, lprcBounds, DT_CENTER | DT_WORDBREAK);
	dc.SelectObject(pOldFont);
}

// Support for Search Handlers
void CMFCWebBrowserPaneDoc::InitializeSearchContent()
{
	CString strSearchContent;
	// Set search contents from document's data. 
	// The content parts should be separated by ";"

	// For example:  strSearchContent = _T("point;rectangle;circle;ole object;");
	SetSearchContent(strSearchContent);
}

void CMFCWebBrowserPaneDoc::SetSearchContent(const CString& value)
{
	if (value.IsEmpty())
	{
		RemoveChunk(PKEY_Search_Contents.fmtid, PKEY_Search_Contents.pid);
	}
	else
	{
		CMFCFilterChunkValueImpl *pChunk = NULL;
		ATLTRY(pChunk = new CMFCFilterChunkValueImpl);
		if (pChunk != NULL)
		{
			pChunk->SetTextValue(PKEY_Search_Contents, value, CHUNK_TEXT);
			SetChunkValue(pChunk);
		}
	}
}

#endif // SHARED_HANDLERS

// CMFCWebBrowserPaneDoc diagnostics

#ifdef _DEBUG
void CMFCWebBrowserPaneDoc::AssertValid() const
{
	COleDocument::AssertValid();
}

void CMFCWebBrowserPaneDoc::Dump(CDumpContext& dc) const
{
	COleDocument::Dump(dc);
}
#endif //_DEBUG


// CMFCWebBrowserPaneDoc commands
