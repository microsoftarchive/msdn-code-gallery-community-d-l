# File System Tree View
## Requires
- Visual Studio 2012
## License
- Apache License, Version 2.0
## Technologies
- Windows Forms
- VB.Net
- System.Windows.Forms.UserControl
- Visual Studio 2012
## Topics
- User Interface
- Windows Forms
- VB.Net
- TreeView
- User Control
## Updated
- 08/12/2015
## Description

<h1>Introduction</h1>
<p><em>This sample how to build directory and file tree view with UserControl and TreeView controls in Windows Forms. Sample was originally build with VS 2008, but has converted to VS 2012.<br>
</em></p>
<h1><span>Building the Sample</span></h1>
<p><em>You need .NET 4.5 and Visual Studio 2012. No other requirements or 3rd party libraries, just extract and build.<br>
</em></p>
<p><span style="font-size:20px; font-weight:bold">Description</span></p>
<p><em>This sample solves the problem of browsing drives, folders and files by using UserControl with TreeView and creating custom TreeNode classes for each kind of an file system item. Control start from the My Computer node and under that is drives --&gt;
 folders --&gt; images and so on. There is also multiple properties to control what will be shown in the control, for example to control whether or not inactive drives are shown. Other behavior of the control is to track the changes in drive state and enable
 browsing for the content of the drive, if it becomes active. This is also controlled by property and by default it's not enabled.<br>
</em></p>
<p>The UI of the control can be seen in the following screen shot. As you can see it shows some icons for directory and files based on file extension.</p>
<p><img id="75448" src="75448-file_system_tree.jpg" alt="" width="300" height="518"></p>
<p>The custom TreeNode classes are based on single base class FileSystemNode and there is one for each item shown in Control. ComputerNode, DriveNode, DirectoryNode and FileNode.</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>Visual Basic</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">vb</span>
<pre class="hidden">''' &lt;summary&gt;
''' Class that represents file system tree node.
''' &lt;/summary&gt;
Friend MustInherit Class FileSystemNode
    Inherits TreeNode

    Private m_nodeType As FileSystemNodeType

    ''' &lt;summary&gt;
    ''' Initializes new instance of &lt;see cref=&quot;FileSystemNode&quot;/&gt; class.
    ''' &lt;/summary&gt;
    ''' &lt;param name=&quot;nodeType&quot;&gt;A &lt;see cref=&quot;FileSystemNodeType&quot;/&gt; of the node.&lt;/param&gt;
    Protected Sub New(ByVal nodeType As FileSystemNodeType)
        Me.New(nodeType, String.Empty)
    End Sub

    ''' &lt;summary&gt;
    ''' Initializes new instance of &lt;see cref=&quot;FileSystemNode&quot;/&gt; class.
    ''' &lt;/summary&gt;
    ''' &lt;param name=&quot;nodeType&quot;&gt;A &lt;see cref=&quot;FileSystemNodeType&quot;/&gt; of the node.&lt;/param&gt;
    ''' &lt;param name=&quot;text&quot;&gt;A text of the node.&lt;/param&gt;
    Protected Sub New(ByVal nodeType As FileSystemNodeType, ByVal text As String)
        MyBase.New(text)
        Me.m_nodeType = nodeType
    End Sub

    ''' &lt;summary&gt;
    ''' Gets the &lt;see cref=&quot;FileSystemNodeType&quot;/&gt; of the node.
    ''' &lt;/summary&gt;
    Public ReadOnly Property NodeType As FileSystemNodeType
        Get
            Return Me.m_nodeType
        End Get
    End Property

End Class</pre>
<div class="preview">
<pre class="vb"><span class="visualBasic__com">'''&nbsp;&lt;summary&gt;</span>&nbsp;
<span class="visualBasic__com">'''&nbsp;Class&nbsp;that&nbsp;represents&nbsp;file&nbsp;system&nbsp;tree&nbsp;node.</span>&nbsp;
<span class="visualBasic__com">'''&nbsp;&lt;/summary&gt;</span>&nbsp;
<span class="visualBasic__keyword">Friend</span>&nbsp;<span class="visualBasic__keyword">MustInherit</span>&nbsp;<span class="visualBasic__keyword">Class</span>&nbsp;FileSystemNode&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Inherits</span>&nbsp;TreeNode&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Private</span>&nbsp;m_nodeType&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;FileSystemNodeType&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'''&nbsp;&lt;summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'''&nbsp;Initializes&nbsp;new&nbsp;instance&nbsp;of&nbsp;&lt;see&nbsp;cref=&quot;FileSystemNode&quot;/&gt;&nbsp;class.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'''&nbsp;&lt;/summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'''&nbsp;&lt;param&nbsp;name=&quot;nodeType&quot;&gt;A&nbsp;&lt;see&nbsp;cref=&quot;FileSystemNodeType&quot;/&gt;&nbsp;of&nbsp;the&nbsp;node.&lt;/param&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Protected</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;<span class="visualBasic__keyword">New</span>(<span class="visualBasic__keyword">ByVal</span>&nbsp;nodeType&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;FileSystemNodeType)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Me</span>.<span class="visualBasic__keyword">New</span>(nodeType,&nbsp;<span class="visualBasic__keyword">String</span>.Empty)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'''&nbsp;&lt;summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'''&nbsp;Initializes&nbsp;new&nbsp;instance&nbsp;of&nbsp;&lt;see&nbsp;cref=&quot;FileSystemNode&quot;/&gt;&nbsp;class.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'''&nbsp;&lt;/summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'''&nbsp;&lt;param&nbsp;name=&quot;nodeType&quot;&gt;A&nbsp;&lt;see&nbsp;cref=&quot;FileSystemNodeType&quot;/&gt;&nbsp;of&nbsp;the&nbsp;node.&lt;/param&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'''&nbsp;&lt;param&nbsp;name=&quot;text&quot;&gt;A&nbsp;text&nbsp;of&nbsp;the&nbsp;node.&lt;/param&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Protected</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;<span class="visualBasic__keyword">New</span>(<span class="visualBasic__keyword">ByVal</span>&nbsp;nodeType&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;FileSystemNodeType,&nbsp;<span class="visualBasic__keyword">ByVal</span>&nbsp;text&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">String</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">MyBase</span>.<span class="visualBasic__keyword">New</span>(text)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Me</span>.m_nodeType&nbsp;=&nbsp;nodeType&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'''&nbsp;&lt;summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'''&nbsp;Gets&nbsp;the&nbsp;&lt;see&nbsp;cref=&quot;FileSystemNodeType&quot;/&gt;&nbsp;of&nbsp;the&nbsp;node.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'''&nbsp;&lt;/summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Public</span>&nbsp;<span class="visualBasic__keyword">ReadOnly</span>&nbsp;<span class="visualBasic__keyword">Property</span>&nbsp;NodeType&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;FileSystemNodeType&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Get</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Return</span>&nbsp;<span class="visualBasic__keyword">Me</span>.m_nodeType&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Get</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Property</span>&nbsp;
&nbsp;
<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Class</span></pre>
</div>
</div>
</div>
<div class="endscriptcode">It is also possible to select multiple nodes by pressing the Control key when node is selected. You can get the selected directories and files in code by calling GetSelectedDirectories or GetSelectedFiles method. The multi-selection
 is demonstrated in following screen shot.</div>
<div class="endscriptcode"></div>
<div class="endscriptcode"></div>
<div class="endscriptcode"><img id="141169" src="141169-folder_multiselection.jpg" alt="" width="624" height="518"></div>
<p>It also possible to limit tree to only select files from specified drive by setting RootDrive property to some valid path or drive. Control also has two methods, Expand and Collapse, to either expand or collapse specified path in tree. Both these features
 can seen in screenshot below.</p>
<p><img id="141171" src="141171-root_path_and_expansion.jpg" alt="" width="624" height="518"></p>
<h1><span>Source Code Files</span></h1>
<ul>
<li><em>FileSystemNode.vb - base class for the custom TreeNode classes.<br>
</em></li><li><em><em>ComputerNode.vb - computer TreeNode.</em></em> </li><li><em>DirectoryTreeNode.vb - base class for TreeNode with directories.</em> </li><li><em>DriveNode.vb - drive TreeNode.</em> </li><li><em>DirectoryNode.vb - directory TreeNode.</em> </li><li><em>FileNode.vb - file TreeNode.</em> </li><li><em>FileSystemTree.vb - the UserControl that contains the custom TreeView.</em>
</li></ul>
