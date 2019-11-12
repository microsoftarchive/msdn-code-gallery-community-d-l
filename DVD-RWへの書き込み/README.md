# DVD-RWへの書き込み
## Requires
- Visual Studio 2010
## License
- Apache License, Version 2.0
## Technologies
- COM
- Visual Studio 2010
- Windows 7
- Windows SDK
## Topics
- COM
- Windows プログラミング
## Updated
- 04/21/2011
## Description

<h1>Introduction</h1>
<p><em>Windows Vista 以降にて、DVD-RWへの書き込みを行うサンプルです。</em></p>
<p><span style="font-size:20px; font-weight:bold">Description</span></p>
<p>Image Mastering API(IMAPI V2) にて書き込みを行います。<br>
IMAPI V2のインターフェースは COM なので、いろいろなアクセス方法がありますが、サンプルでは、コード量が小さくなる スマートポインターを利用しています。</p>
<p>Windows SDK にも サンプル があります。</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C&#43;&#43;</span></div>
<div class="pluginEditHolderLink">スクリプトの編集</div>
<span class="hidden">cplusplus</span>

<div class="preview">
<pre class="cplusplus"><span class="cpp__com">//&nbsp;デスクへの書き込み</span>&nbsp;
<span class="cpp__keyword">void</span>&nbsp;WriteToDisc(<span class="cpp__datatype">LPCWSTR</span>&nbsp;folder)&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__datatype">HRESULT</span>&nbsp;hr;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;IDiscMaster2Ptr&nbsp;DiscMaster2&nbsp;=&nbsp;NULL;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;IDiscRecorder2Ptr&nbsp;DiscRecorder2&nbsp;=&nbsp;NULL;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;IDiscFormat2DataPtr&nbsp;DiscFormat2Data&nbsp;=&nbsp;NULL;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;BSTR&nbsp;path&nbsp;=&nbsp;&nbsp;::SysAllocString(folder);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&nbsp;DiscMaster2インスタンスの作成</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;hr&nbsp;=&nbsp;DiscMaster2.CreateInstance(&nbsp;CLSID_MsftDiscMaster2&nbsp;);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">if</span>&nbsp;(&nbsp;!SUCCEEDED(hr)&nbsp;)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;wprintf_s(L<span class="cpp__string">&quot;Error&nbsp;(0x%x)&nbsp;(%d)\n&quot;</span>,&nbsp;hr,&nbsp;__LINE__);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">return</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&nbsp;DiscRecorder2インスタンスの作成</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;hr&nbsp;=&nbsp;DiscRecorder2.CreateInstance(&nbsp;CLSID_MsftDiscRecorder2&nbsp;);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">if</span>&nbsp;(&nbsp;!SUCCEEDED(hr)&nbsp;)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;wprintf_s(L<span class="cpp__string">&quot;Error&nbsp;(0x%x)&nbsp;(%d)\n&quot;</span>,&nbsp;hr,&nbsp;__LINE__);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">return</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&nbsp;IDiscFormat2Dataインスタンスの作成</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;hr&nbsp;=&nbsp;DiscFormat2Data.CreateInstance(&nbsp;CLSID_MsftDiscFormat2Data&nbsp;);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">if</span>&nbsp;(&nbsp;!SUCCEEDED(hr)&nbsp;)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;wprintf_s(L<span class="cpp__string">&quot;Error&nbsp;(0x%x)&nbsp;(%d)\n&quot;</span>,&nbsp;hr,&nbsp;__LINE__);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">return</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&nbsp;レコーダーの選択</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;BSTR&nbsp;uniqueId;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;hr&nbsp;=&nbsp;DiscMaster2-&gt;get_Item(<span class="cpp__number">0</span>,&nbsp;&amp;uniqueId);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">if</span>&nbsp;(&nbsp;!SUCCEEDED(hr)&nbsp;)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;wprintf_s(L<span class="cpp__string">&quot;Error&nbsp;(0x%x)&nbsp;(%d)\n&quot;</span>,&nbsp;hr,&nbsp;__LINE__);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">return</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;hr&nbsp;=&nbsp;DiscRecorder2-&gt;InitializeDiscRecorder(&nbsp;uniqueId&nbsp;);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">if</span>&nbsp;(&nbsp;!SUCCEEDED(hr)&nbsp;)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;wprintf_s(L<span class="cpp__string">&quot;Error&nbsp;(0x%x)&nbsp;(%d)\n&quot;</span>,&nbsp;hr,&nbsp;__LINE__);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">return</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;hr&nbsp;=&nbsp;DiscFormat2Data-&gt;put_Recorder(DiscRecorder2);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">if</span>&nbsp;(&nbsp;!SUCCEEDED(hr)&nbsp;)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;wprintf_s(L<span class="cpp__string">&quot;Error&nbsp;(0x%x)&nbsp;(%d)\n&quot;</span>,&nbsp;hr,&nbsp;__LINE__);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">return</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&nbsp;HDD上のフォルダから&nbsp;構造化ストレージを作成</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;IFileSystemImagePtr&nbsp;FileSystemImage&nbsp;=&nbsp;NULL;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;IFsiDirectoryItemPtr&nbsp;root&nbsp;=&nbsp;NULL;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;IFileSystemImageResultPtr&nbsp;result&nbsp;=&nbsp;NULL;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;IStreamPtr&nbsp;stream&nbsp;=&nbsp;NULL;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;hr&nbsp;=&nbsp;FileSystemImage.CreateInstance(&nbsp;CLSID_MsftFileSystemImage&nbsp;);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">if</span>&nbsp;(&nbsp;!SUCCEEDED(hr)&nbsp;)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;wprintf_s(L<span class="cpp__string">&quot;Error&nbsp;(0x%x)&nbsp;(%d)\n&quot;</span>,&nbsp;hr,&nbsp;__LINE__);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">return</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;hr&nbsp;=&nbsp;FileSystemImage-&gt;put_FileSystemsToCreate(&nbsp;FsiFileSystemUDF&nbsp;);&nbsp;<span class="cpp__com">//&nbsp;UDF&nbsp;を作成</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">if</span>&nbsp;(&nbsp;!SUCCEEDED(hr)&nbsp;)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;wprintf_s(L<span class="cpp__string">&quot;Error&nbsp;(0x%x)&nbsp;(%d)\n&quot;</span>,&nbsp;hr,&nbsp;__LINE__);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">return</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;hr&nbsp;=&nbsp;FileSystemImage-&gt;ChooseImageDefaultsForMediaType(&nbsp;IMAPI_MEDIA_TYPE_DVDDASHRW&nbsp;);&nbsp;<span class="cpp__com">//&nbsp;DVD-RW</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">if</span>&nbsp;(&nbsp;!SUCCEEDED(hr)&nbsp;)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;wprintf_s(L<span class="cpp__string">&quot;Error&nbsp;(0x%x)&nbsp;(%d)\n&quot;</span>,&nbsp;hr,&nbsp;__LINE__);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">return</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;hr&nbsp;=&nbsp;FileSystemImage-&gt;get_Root(&amp;root);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">if</span>&nbsp;(&nbsp;!SUCCEEDED(hr)&nbsp;)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;wprintf_s(L<span class="cpp__string">&quot;Error&nbsp;(0x%x)&nbsp;(%d)\n&quot;</span>,&nbsp;hr,&nbsp;__LINE__);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">return</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;hr&nbsp;=&nbsp;root-&gt;AddTree(path,&nbsp;VARIANT_FALSE);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">if</span>&nbsp;(&nbsp;!SUCCEEDED(hr)&nbsp;)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;wprintf_s(L<span class="cpp__string">&quot;Error&nbsp;(0x%x)&nbsp;(%d)\n&quot;</span>,&nbsp;hr,&nbsp;__LINE__);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">return</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;hr&nbsp;=&nbsp;FileSystemImage-&gt;CreateResultImage(&amp;result);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">if</span>&nbsp;(&nbsp;!SUCCEEDED(hr)&nbsp;)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;wprintf_s(L<span class="cpp__string">&quot;Error&nbsp;(0x%x)&nbsp;(%d)\n&quot;</span>,&nbsp;hr,&nbsp;__LINE__);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">return</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;hr&nbsp;=&nbsp;result-&gt;get_ImageStream(&amp;stream);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">if</span>&nbsp;(&nbsp;!SUCCEEDED(hr)&nbsp;)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;wprintf_s(L<span class="cpp__string">&quot;Error&nbsp;(0x%x)&nbsp;(%d)\n&quot;</span>,&nbsp;hr,&nbsp;__LINE__);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">return</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&nbsp;属性の設定</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;hr&nbsp;=&nbsp;DiscFormat2Data-&gt;put_ForceMediaToBeClosed(VARIANT_TRUE);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">if</span>&nbsp;(&nbsp;!SUCCEEDED(hr)&nbsp;)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;wprintf_s(L<span class="cpp__string">&quot;Error&nbsp;(0x%x)&nbsp;(%d)\n&quot;</span>,&nbsp;hr,&nbsp;__LINE__);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">return</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;hr&nbsp;=&nbsp;DiscFormat2Data-&gt;put_ClientName(g_appName);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">if</span>&nbsp;(&nbsp;!SUCCEEDED(hr)&nbsp;)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;wprintf_s(L<span class="cpp__string">&quot;Error&nbsp;(0x%x)&nbsp;(%d)\n&quot;</span>,&nbsp;hr,&nbsp;__LINE__);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">return</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&nbsp;書き込み開始</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;wprintf_s(L<span class="cpp__string">&quot;メディアに書き込み\n&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;hr&nbsp;=&nbsp;DiscFormat2Data-&gt;Write(stream);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">if</span>&nbsp;(&nbsp;!SUCCEEDED(hr)&nbsp;)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;wprintf_s(L<span class="cpp__string">&quot;Error&nbsp;(0x%x)&nbsp;(%d)\n&quot;</span>,&nbsp;hr,&nbsp;__LINE__);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">return</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;wprintf_s(L<span class="cpp__string">&quot;書き込み終了\n&quot;</span>);&nbsp;
&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">return</span>;&nbsp;
}&nbsp;
&nbsp;
</pre>
</div>
</div>
</div>
<p>&nbsp;</p>
<h1><span>Source Code Files</span></h1>
<ul>
<li><em><em>TestV2.zip<br>
</em></em></li></ul>
<h1>More Information</h1>
<p>Image Mastering API<br>
<a href="http://msdn.microsoft.com/en-us/library/aa366450.aspx">http://msdn.microsoft.com/en-us/library/aa366450.aspx</a></p>
