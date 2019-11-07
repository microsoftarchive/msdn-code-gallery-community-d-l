
// CntrItem.h : interface of the CMFCWebBrowserPaneCntrItem class
//

#pragma once

class CMFCWebBrowserPaneDoc;
class CMFCWebBrowserPaneView;

class CMFCWebBrowserPaneCntrItem : public COleClientItem
{
	DECLARE_SERIAL(CMFCWebBrowserPaneCntrItem)

// Constructors
public:
	CMFCWebBrowserPaneCntrItem(CMFCWebBrowserPaneDoc* pContainer = NULL);
		// Note: pContainer is allowed to be NULL to enable IMPLEMENT_SERIALIZE
		//  IMPLEMENT_SERIALIZE requires the class have a constructor with
		//  zero arguments.  Normally, OLE items are constructed with a
		//  non-NULL document pointer

// Attributes
public:
	CMFCWebBrowserPaneDoc* GetDocument()
		{ return reinterpret_cast<CMFCWebBrowserPaneDoc*>(COleClientItem::GetDocument()); }
	CMFCWebBrowserPaneView* GetActiveView()
		{ return reinterpret_cast<CMFCWebBrowserPaneView*>(COleClientItem::GetActiveView()); }

public:
	virtual void OnChange(OLE_NOTIFICATION wNotification, DWORD dwParam);
	virtual void OnActivate();

protected:
	virtual void OnGetItemPosition(CRect& rPosition);
	virtual void OnDeactivateUI(BOOL bUndoable);
	virtual BOOL OnChangeItemPosition(const CRect& rectPos);
	virtual BOOL OnShowControlBars(CFrameWnd* pFrameWnd, BOOL bShow);

// Implementation
public:
	~CMFCWebBrowserPaneCntrItem();
#ifdef _DEBUG
	virtual void AssertValid() const;
	virtual void Dump(CDumpContext& dc) const;
#endif
	virtual void Serialize(CArchive& ar);
};

