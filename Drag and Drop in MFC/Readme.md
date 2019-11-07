# Drag and Drop in MFC
## Requires
- Visual Studio 2012
## License
- Apache License, Version 2.0
## Technologies
- MFC
## Topics
- Drag and Drop
## Updated
- 12/16/2013
## Description

<h1>Introduction</h1>
<p><em>Simple program for draging files or folders from file explorer to a list control in MFC.</em></p>
<p><span style="font-size:20px; font-weight:bold">Code</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C&#43;&#43;</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">cplusplus</span>
<pre class="hidden">BEGIN_MESSAGE_MAP(CMFCDropFilesDlg, CDialogEx)
	ON_WM_SYSCOMMAND()
	ON_WM_PAINT()
	ON_WM_DROPFILES()
	ON_WM_QUERYDRAGICON()
END_MESSAGE_MAP()

DragAcceptFiles (); // entire dialog
list.DragAcceptFiles (); // control represented by variable m_oPath

void CMFCDropFilesDlg::OnDropFiles (HDROP dropInfo)
{
	CString sFile;
	DWORD   nBuffer = 0;

	// Get the number of files dropped
	int nFilesDropped = DragQueryFile (dropInfo, 0xFFFFFFFF, NULL, 0);

	for(int i=0; i&lt;nFilesDropped; i&#43;&#43;)
	{
		// Get the buffer size of the file.
		nBuffer = DragQueryFile (dropInfo, i, NULL, 0);

		// Get path and name of the file
		DragQueryFile (dropInfo, i, sFile.GetBuffer (nBuffer &#43; 1), nBuffer &#43; 1);
		sFile.ReleaseBuffer ();
		
	
		list.AddString(PathFindFileName(sFile));

	}

	// Free the memory block containing the dropped-file information
	DragFinish(dropInfo);
}


.h file
// CMFCDropFilesDlg dialog
class CMFCDropFilesDlg : public CDialogEx
{
// Construction
public:
	CMFCDropFilesDlg(CWnd* pParent = NULL);	// standard constructor

// Dialog Data
	enum { IDD = IDD_MFCDROPFILES_DIALOG };

	protected:
	virtual void DoDataExchange(CDataExchange* pDX);	// DDX/DDV support


// Implementation
protected:
	HICON m_hIcon;

	// Generated message map functions
	virtual BOOL OnInitDialog();
	afx_msg void OnSysCommand(UINT nID, LPARAM lParam);
	afx_msg void OnPaint();
	afx_msg HCURSOR OnQueryDragIcon();
	afx_msg void OnDropFiles (HDROP dropInfo);

	DECLARE_MESSAGE_MAP()
public:
	CListBox list;
};</pre>
<div class="preview">
<pre class="cplusplus">BEGIN_MESSAGE_MAP(CMFCDropFilesDlg,&nbsp;CDialogEx)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;ON_WM_SYSCOMMAND()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;ON_WM_PAINT()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;ON_WM_DROPFILES()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;ON_WM_QUERYDRAGICON()&nbsp;
END_MESSAGE_MAP()&nbsp;
&nbsp;
DragAcceptFiles&nbsp;();&nbsp;<span class="cpp__com">//&nbsp;entire&nbsp;dialog</span>&nbsp;
list.DragAcceptFiles&nbsp;();&nbsp;<span class="cpp__com">//&nbsp;control&nbsp;represented&nbsp;by&nbsp;variable&nbsp;m_oPath</span>&nbsp;
&nbsp;
<span class="cpp__keyword">void</span>&nbsp;CMFCDropFilesDlg::OnDropFiles&nbsp;(<span class="cpp__datatype">HDROP</span>&nbsp;dropInfo)&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;CString&nbsp;sFile;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__datatype">DWORD</span>&nbsp;&nbsp;&nbsp;nBuffer&nbsp;=&nbsp;<span class="cpp__number">0</span>;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&nbsp;Get&nbsp;the&nbsp;number&nbsp;of&nbsp;files&nbsp;dropped</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__datatype">int</span>&nbsp;nFilesDropped&nbsp;=&nbsp;DragQueryFile&nbsp;(dropInfo,&nbsp;0xFFFFFFFF,&nbsp;NULL,&nbsp;<span class="cpp__number">0</span>);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">for</span>(<span class="cpp__datatype">int</span>&nbsp;i=<span class="cpp__number">0</span>;&nbsp;i&lt;nFilesDropped;&nbsp;i&#43;&#43;)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&nbsp;Get&nbsp;the&nbsp;buffer&nbsp;size&nbsp;of&nbsp;the&nbsp;file.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;nBuffer&nbsp;=&nbsp;DragQueryFile&nbsp;(dropInfo,&nbsp;i,&nbsp;NULL,&nbsp;<span class="cpp__number">0</span>);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&nbsp;Get&nbsp;path&nbsp;and&nbsp;name&nbsp;of&nbsp;the&nbsp;file</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;DragQueryFile&nbsp;(dropInfo,&nbsp;i,&nbsp;sFile.GetBuffer&nbsp;(nBuffer&nbsp;&#43;&nbsp;<span class="cpp__number">1</span>),&nbsp;nBuffer&nbsp;&#43;&nbsp;<span class="cpp__number">1</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;sFile.ReleaseBuffer&nbsp;();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;list.AddString(PathFindFileName(sFile));&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&nbsp;Free&nbsp;the&nbsp;memory&nbsp;block&nbsp;containing&nbsp;the&nbsp;dropped-file&nbsp;information</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;DragFinish(dropInfo);&nbsp;
}&nbsp;
&nbsp;
&nbsp;
.h&nbsp;file&nbsp;
<span class="cpp__com">//&nbsp;CMFCDropFilesDlg&nbsp;dialog</span>&nbsp;
<span class="cpp__keyword">class</span>&nbsp;CMFCDropFilesDlg&nbsp;:&nbsp;<span class="cpp__keyword">public</span>&nbsp;CDialogEx&nbsp;
{&nbsp;
<span class="cpp__com">//&nbsp;Construction</span>&nbsp;
<span class="cpp__keyword">public</span>:&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;CMFCDropFilesDlg(CWnd*&nbsp;pParent&nbsp;=&nbsp;NULL);&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&nbsp;standard&nbsp;constructor</span>&nbsp;
&nbsp;
<span class="cpp__com">//&nbsp;Dialog&nbsp;Data</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">enum</span>&nbsp;{&nbsp;IDD&nbsp;=&nbsp;IDD_MFCDROPFILES_DIALOG&nbsp;};&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">protected</span>:&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">virtual</span>&nbsp;<span class="cpp__keyword">void</span>&nbsp;DoDataExchange(CDataExchange*&nbsp;pDX);&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&nbsp;DDX/DDV&nbsp;support</span>&nbsp;
&nbsp;
&nbsp;
<span class="cpp__com">//&nbsp;Implementation</span>&nbsp;
<span class="cpp__keyword">protected</span>:&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__datatype">HICON</span>&nbsp;m_hIcon;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&nbsp;Generated&nbsp;message&nbsp;map&nbsp;functions</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">virtual</span>&nbsp;<span class="cpp__datatype">BOOL</span>&nbsp;OnInitDialog();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;afx_msg&nbsp;<span class="cpp__keyword">void</span>&nbsp;OnSysCommand(<span class="cpp__datatype">UINT</span>&nbsp;nID,&nbsp;<span class="cpp__datatype">LPARAM</span>&nbsp;lParam);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;afx_msg&nbsp;<span class="cpp__keyword">void</span>&nbsp;OnPaint();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;afx_msg&nbsp;<span class="cpp__datatype">HCURSOR</span>&nbsp;OnQueryDragIcon();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;afx_msg&nbsp;<span class="cpp__keyword">void</span>&nbsp;OnDropFiles&nbsp;(<span class="cpp__datatype">HDROP</span>&nbsp;dropInfo);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;DECLARE_MESSAGE_MAP()&nbsp;
<span class="cpp__keyword">public</span>:&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;CListBox&nbsp;list;&nbsp;
};</pre>
</div>
</div>
</div>
<h1><img id="104587" src="104587-untitled.jpg" alt="" width="502" height="454"></h1>
<p>Drag files from your file explorer to MFCDragDrop application.</p>
<p>&nbsp;</p>
<p>Reference:</p>
<h2>How Drag-and-Drop Works with Shell Objects</h2>
<p>Applications often need to provide users with a way to transfer Shell data. Some examples are:</p>
<ul>
<li>Dragging a file from Windows Explorer or the desktop and dropping it on an application.
</li><li>Copying a file to the Clipboard in Windows Explorer and pasting it into an application.
</li><li>Dragging a file from an application to the Recycle Bin. </li></ul>
<p>For a detailed discussion of how to handle these and other scenarios, see&nbsp;<a href="http://msdn.microsoft.com/en-us/library/windows/desktop/bb776904(v=vs.85).aspx">Handling Shell Data Transfer Scenarios</a>. This document focuses on the general principles
 behind Shell data transfer.</p>
<p>Windows provides two standard ways for applications to transfer Shell data:</p>
<ul>
<li>A user cuts or copies Shell data, such as one or more files, to the Clipboard. The other application retrieves the data from the Clipboard.
</li><li>A user drags an icon that represents the data from the source application and drops the icon on a window owned by the target.
</li></ul>
<p>In both cases, the transferred data is contained in a&nbsp;<em>data object</em>. Data objects are Component Object Model (COM) objects that expose the&nbsp;<a href="http://msdn.microsoft.com/en-us/library/windows/desktop/ms688421(v=vs.85).aspx"><strong>IDataObject</strong></a>&nbsp;interface.
 Schematically, there are three essential steps that all Shell data transfers must follow:</p>
<ol>
<li>The source creates a data object that represents the data that is to be transferred.
</li><li>The target receives a pointer to the data object's&nbsp;<a href="http://msdn.microsoft.com/en-us/library/windows/desktop/ms688421(v=vs.85).aspx"><strong>IDataObject</strong></a>&nbsp;interface.
</li><li>The target calls the&nbsp;<a href="http://msdn.microsoft.com/en-us/library/windows/desktop/ms688421(v=vs.85).aspx"><strong>IDataObject</strong></a>&nbsp;interface to extract the data from it.
</li></ol>
<p>The difference between Clipboard and drag-and-drop data transfers lies primarily in how the&nbsp;<a href="http://msdn.microsoft.com/en-us/library/windows/desktop/ms688421(v=vs.85).aspx"><strong>IDataObject</strong></a>&nbsp;pointer is transferred from the
 source to the target.</p>
