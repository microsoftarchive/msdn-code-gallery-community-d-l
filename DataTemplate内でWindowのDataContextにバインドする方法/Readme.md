# DataTemplate内でWindowのDataContextにバインドする方法
## Requires
- Visual Studio 2012
## License
- Apache License, Version 2.0
## Technologies
- WPF
## Topics
- Data Binding
## Updated
- 05/08/2013
## Description

<h1>Introduction</h1>
<p>Windows Presentation Foundationを使ったアプリケーション(Windows Presentation Foundationを例にしていますがSilverlight, Windows Phone, Windows store appでも同様なことが可能です。一部機能についてはWindows Presentation Foundationの固有機能を使っています）のDataTemplate内で、自分のDataContext以外のものをソースに指定してBindingを行う方法のサンプルプログラムについて紹介します。</p>
<h1>サンプルの実行方法と動作</h1>
<p>サンプルをダウンロードしてVisual Studio 2012で開いてください。プロジェクトを開いて実行するとボタンが横に2列に並んで20行表示されます。ボタンを押すと、画面上部のテキストの表示が変わります。</p>
<p><img id="81858" src="81858-ws000000.jpg" alt="" width="300" height="200"></p>
<h1>サンプルプログラムのポイント</h1>
<p>サンプルプログラムでは、MainWindow内でItemsControlにListItemというクラスのコレクションをバインドしています。ItemsControlの1行1行はMainWindow内のResourcesに作成したDataTemplateで見た目を定義しています。DataTemplateは、StackPanelを使ってButtonを横に2つ並べています。このDataTemplateのボタンでMainWindowのDataContextに設定しているMainWindowViewModelのインスタンスのCommandをバインドしています。</p>
<p>ポイントとなるXAMLのコードを以下に示します。</p>
<p>まず、MainWindow内でのViewModelのインスタンスの定義とDataContextへの設定を行っているコードを以下に示します。</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XAML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">スクリプトの編集</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">xaml</span>
<pre class="hidden">&lt;Window.Resources&gt;
    &lt;local:MainWindowViewModel x:Key=&quot;viewModel&quot; /&gt;
    ...省略...
&lt;/Window.Resources&gt;

&lt;Window.DataContext&gt;
    &lt;StaticResourceExtension ResourceKey=&quot;viewModel&quot; /&gt;
&lt;/Window.DataContext&gt;
</pre>
<div class="preview">
<pre class="xaml"><span class="xaml__tag_start">&lt;Window</span>.Resources<span class="xaml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;local</span>:MainWindowViewModel&nbsp;x:<span class="xaml__attr_name">Key</span>=<span class="xaml__attr_value">&quot;viewModel&quot;</span>&nbsp;<span class="xaml__tag_start">/&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;...省略...&nbsp;
&lt;/Window.Resources&gt;&nbsp;
&nbsp;
<span class="xaml__tag_start">&lt;Window</span>.DataContext<span class="xaml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;StaticResourceExtension</span>&nbsp;<span class="xaml__attr_name">ResourceKey</span>=<span class="xaml__attr_value">&quot;viewModel&quot;</span>&nbsp;<span class="xaml__tag_start">/&gt;</span>&nbsp;
&lt;/Window.DataContext&gt;&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;DataContextに直接MainWindowViewModelのインスタンスを設定するのではなく、ResourcesにMainWindowViewModelのインスタンスを置いて、StaticResourceExtensionを使ってWindowのDataContextに設定しています。このようにMainWindowViewModelのインスタンスをResourcesに登録しているため、同じWindow内で定義しているDataTemplate内からもStaticResourceを使ってMainWindowViewModelが参照可能です。そのためDataTemplate内のボタンで以下のようなBindingを定義することで、MainWindowViewModelのコマンドを参照できます。</div>
<div class="endscriptcode">&nbsp;</div>
<div class="endscriptcode">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XAML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">スクリプトの編集</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">xaml</span>
<pre class="hidden">&lt;!-- StaticResourceで参照する方法 --&gt;
&lt;Button Content=&quot;{Binding Text}&quot; 
        Command=&quot;{Binding ViewModelCommand, Source={StaticResource viewModel}}&quot;
        CommandParameter=&quot;{Binding}&quot;/&gt;</pre>
<div class="preview">
<pre class="xaml"><span class="xaml__comment">&lt;!--&nbsp;StaticResourceで参照する方法&nbsp;--&gt;</span>&nbsp;
<span class="xaml__tag_start">&lt;Button</span>&nbsp;<span class="xaml__attr_name">Content</span>=<span class="xaml__attr_value">&quot;{Binding&nbsp;Text}&quot;</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__attr_name">Command</span>=<span class="xaml__attr_value">&quot;{Binding&nbsp;ViewModelCommand,&nbsp;Source={StaticResource&nbsp;viewModel}}&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__attr_name">CommandParameter</span>=<span class="xaml__attr_value">&quot;{Binding}&quot;</span><span class="xaml__tag_start">/&gt;</span></pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;もう1つのボタンでは、WindowのResourcesにMainWindowViewModelのインスタンスを設定しなくても可能な方法でCommandをBindingしています。XAMLを以下に示します。</div>
<div class="endscriptcode">&nbsp;</div>
<div class="endscriptcode">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XAML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">スクリプトの編集</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">xaml</span>
<pre class="hidden">&lt;!-- RelativeSourceで参照する方法 --&gt;
&lt;Button Content=&quot;{Binding Text}&quot; 
        Command=&quot;{Binding DataContext.ViewModelCommand, RelativeSource={RelativeSource AncestorType=ItemsControl}}&quot;
        CommandParameter=&quot;{Binding}&quot;/&gt;</pre>
<div class="preview">
<pre class="xaml"><span class="xaml__comment">&lt;!--&nbsp;RelativeSourceで参照する方法&nbsp;--&gt;</span>&nbsp;
<span class="xaml__tag_start">&lt;Button</span>&nbsp;<span class="xaml__attr_name">Content</span>=<span class="xaml__attr_value">&quot;{Binding&nbsp;Text}&quot;</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__attr_name">Command</span>=<span class="xaml__attr_value">&quot;{Binding&nbsp;DataContext.ViewModelCommand,&nbsp;RelativeSource={RelativeSource&nbsp;AncestorType=ItemsControl}}&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__attr_name">CommandParameter</span>=<span class="xaml__attr_value">&quot;{Binding}&quot;</span><span class="xaml__tag_start">/&gt;</span></pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
BindingのRelativeSourceを使うと相対的な位置をベースにしてBindingのPathを書くことができます。この場合ではAncestorTypeを使い指定した型にいきつくまで要素を親へ親へたどっていくようにしています。ItemsControlのDataContextは、MainWindowViewModelなのでPathにDataContext.ViewModelCommandという値を指定することでコマンドを参照しています。</div>
<div class="endscriptcode"></div>
<h1 class="endscriptcode">参考情報</h1>
<div class="endscriptcode">RelativeSourceについては、以下のMSDNのページを参照してください。</div>
<div class="endscriptcode"><a href="http://msdn.microsoft.com/ja-jp/library/vstudio/ms743599.aspx">RelativeSource のマークアップ拡張機能</a></div>
</div>
<div class="endscriptcode">&nbsp;</div>
