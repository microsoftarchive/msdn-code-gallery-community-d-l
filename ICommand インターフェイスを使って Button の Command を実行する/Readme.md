# ICommand インターフェイスを使って Button の Command を実行する
## Requires
- Visual Studio 2012
## License
- MS-LPL
## Technologies
- Windows 8
- Windows RT
- Windows Store app
## Topics
- ICommand
## Updated
- 04/30/2013
## Description

<p>これは次の記事のサンプルコードをベースにしています。</p>
<blockquote>
<div>@IT 2013/04/25 掲載<br>
<img id="68637" src="68637-gyoumu_newallarticle_icon_61_1349480145.gif" alt="" width="80" height="60"><br>
<strong><a href="http://www.atmarkit.co.jp/ait/articles/1304/25/news064.html" target="_blank">デザイン画面でデータをバインドするには？［Win 8／WP 8］</a></strong><br>
前回までで紹介したデータ・バインドの方法では、実際にどのような表示になるかは実行してみないと分からない。実行する前にVisual Studioのデザイン画面で表示を確かめることはできないだろうか？
<br>
そこで本稿では、XAMLコードだけでデータ・ソースのインスタンスを生成し、それをデータ・コンテキストに設定してデザイン画面に表示する方法を説明する</div>
</blockquote>
<p>コードの全体を理解したいときは、 上の記事をお読みください。</p>
<p>[2013/5/1]<br>
<strong>ソースコードを入れ替えました</strong><br>
下記の説明にはありませんが、新しいサンプルコードでは CommandParameter を使って複数のボタンの機能を使い分けるようになっています。</p>
<p>&nbsp;</p>
<h1>Building the Sample</h1>
<div>Windows 8 製品版(または評価版) &#43; Visual Studio 2012 製品版(Expressでも可) でビルドしてほしい。<br>
これらを準備するには、<a href="http://www.atmarkit.co.jp/ait/articles/1208/23/news131.html" target="_blank">第1回のTIPS</a>を参考にしてほしい。本稿では64bit版Win 8 Proと<a href="http://www.microsoft.com/visualstudio/jpn/downloads#d-2012-express" target="_blank">VS 2012 Express for Windows
 8</a>を使用している。</div>
<p>&nbsp;</p>
<h1>Description</h1>
<h2>M と V を分離するために</h2>
<p>UI を持つアプリは、 Model と View を分離するのが良いのですな。 主にメンテナンスの面で (ということは、 開発中にどんどん姿が変わっていくときにも有効)。</p>
<p>Windows ストア アプリで M と V を分離しようとしたとき、 最大の敵はたぶん「コマンド」。<br>
たとえばボタン クリックで何かする、 というコマンドを Model (≒業務ロジック) と綺麗に切り離そうとすると、 <strong><a href="http://msdn.microsoft.com/ja-jp/library/system.windows.input.icommand.aspx" target="_blank">ICommand インターフェイス</a></strong>を実装したコマンド オブジェクトを使うのだけれど、 意外とサンプルが無い。 ので、 簡単な例をここで紹介しておきます。</p>
<p>ちなみに、「たかがクラウドのフロントエンドごときに MVVM を使うのかい!?」 って話はありますが、 知っておいて損はありません。 というか、 知ったうえで、 「この程度のアプリでは MVVM を適用しないほうがお得」という判断をすべきでしょう。</p>
<p>&nbsp;</p>
<h2>ICommand の実装</h2>
<p>これの実装例は、 けっこう見つかります。 <a href="http://msdn.microsoft.com/ja-jp/library/vstudio/hh563947.aspx" target="_blank">
MSDN</a> とか <a href="http://twitter.com/okazuki">@okazuki</a> の<a href="http://d.hatena.ne.jp/okazuki/20120421/1335015512" target="_blank">ブログ記事</a>とか。<br>
ここでは、 <a href="http://d.hatena.ne.jp/okazuki/20120421/1335015512" target="_blank">
そのブログ記事</a>の <strong>DelegateCommand クラス</strong>をそのまま使わせてもらいます。 これは、 コマンドで実行するロジックを、 インタンスを作るときに渡せるという汎用的なものです。</p>
<p>&nbsp;</p>
<h2>M の実装</h2>
<p>このアプリは Model (&hellip;というほどキチンとしたものではありませんが) として Clock クラスを持っています。 これに、 上記の DelegateCommand クラスのインスタンスも持たせましょう。 持たせるコマンドは、 現在時刻の秒が偶数のときに実行できる (という、わざとらしい例w) ものとします。</p>
<p>Model には次のように、 ICommand の実装を見せるプロパティと、 コマンドの有効/無効の変化を誰か(=コマンドの消費者)に教えるコードが必要です。</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">スクリプトの編集</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">// Clock クラスの改修部分

    // *** ICommand の実装を公開するプロパティ
    private DelegateCommand _command;
    public DelegateCommand Command {
      get {
        if(_command == null)
          _command = new DelegateCommand(
                       // コマンドで実行されるのは CommandAction に登録した処理
                       () =&gt;
                       {
                         var action = CommandAction;
                         if (action != null)
                           action();
                       },
                       // コマンドの実行可否は IsEven プロパティに依存
                       () =&gt; IsEven);

        return _command;
      }
    }
    public Action CommandAction { get; set; }



    // 秒が偶数のとき true (既存のコード)
    private bool _isEven;
    public bool IsEven 
    {
      get { return _isEven; }
      internal set
      {
        if (SetProperty(ref _isEven, value))
        {
          // 以下 &darr; を追加 
          // *** IsEven プロパティが変化したときだけ
          //     CanExecuteChanged イベントを発火させる
          this.Command.RaiseCanExecuteChanged();
        }
      }
    }
</pre>
<div class="preview">
<pre class="csharp"><span class="cs__com">//&nbsp;Clock&nbsp;クラスの改修部分</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;***&nbsp;ICommand&nbsp;の実装を公開するプロパティ</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span>&nbsp;DelegateCommand&nbsp;_command;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;DelegateCommand&nbsp;Command&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">get</span>&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>(_command&nbsp;==&nbsp;<span class="cs__keyword">null</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;_command&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;DelegateCommand(&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;コマンドで実行されるのは&nbsp;CommandAction&nbsp;に登録した処理</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;()&nbsp;=&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;action&nbsp;=&nbsp;CommandAction;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(action&nbsp;!=&nbsp;<span class="cs__keyword">null</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;action();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;},&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;コマンドの実行可否は&nbsp;IsEven&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;()&nbsp;=&gt;&nbsp;IsEven);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;_command;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;Action&nbsp;CommandAction&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;
&nbsp;
&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;秒が偶数のとき&nbsp;true&nbsp;(既存のコード)</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">bool</span>&nbsp;_isEven;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">bool</span>&nbsp;IsEven&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">get</span>&nbsp;{&nbsp;<span class="cs__keyword">return</span>&nbsp;_isEven;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">internal</span>&nbsp;<span class="cs__keyword">set</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(SetProperty(<span class="cs__keyword">ref</span>&nbsp;_isEven,&nbsp;<span class="cs__keyword">value</span>))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;以下&nbsp;&darr;&nbsp;を追加&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;***&nbsp;IsEven&nbsp;プロパティが変化したときだけ</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;CanExecuteChanged&nbsp;イベントを発火させる</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">this</span>.Command.RaiseCanExecuteChanged();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p>※ なお、 Model, Model と言ってきましたが、 ICommand (System.Windows.Input 名前空間) なんてものを入れちゃったので、 もはや純粋な Model (ロジック) とは呼べません。 むしろ、 画面を抽象的に表現しているナニカのような&hellip;。</p>
<p>&nbsp;</p>
<h2>V の実装</h2>
<p>画面には Button を置いて、 Model の Command プロパティをバインドしましょう。</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XAML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">スクリプトの編集</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">xaml</span>
<pre class="hidden">&lt;!-- *** ICommand のテストのために追加した StackPanel --&gt;
&lt;StackPanel x:Name=&quot;stackPanelForTest&quot; Grid.Column=&quot;1&quot; Margin=&quot;0,20,0,0&quot; 
            DataContext=&quot;{StaticResource ClockInstance}&quot;&gt;
  &hellip;&hellip;省略&hellip;&hellip;
  &lt;Button Content=&quot;今だ!!&quot; Command=&quot;{Binding Command}&quot; &hellip;&hellip;省略&hellip;&hellip; /&gt;
  &hellip;&hellip;省略&hellip;&hellip;
&lt;/StackPanel&gt;</pre>
<div class="preview">
<pre class="xaml"><span class="xaml__comment">&lt;!--&nbsp;***&nbsp;ICommand&nbsp;のテストのために追加した&nbsp;StackPanel&nbsp;--&gt;</span>&nbsp;
<span class="xaml__tag_start">&lt;StackPanel</span>&nbsp;x:<span class="xaml__attr_name">Name</span>=<span class="xaml__attr_value">&quot;stackPanelForTest&quot;</span>&nbsp;Grid.<span class="xaml__attr_name">Column</span>=<span class="xaml__attr_value">&quot;1&quot;</span>&nbsp;<span class="xaml__attr_name">Margin</span>=<span class="xaml__attr_value">&quot;0,20,0,0&quot;</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__attr_name">DataContext</span>=<span class="xaml__attr_value">&quot;{StaticResource&nbsp;ClockInstance}&quot;</span><span class="xaml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&hellip;&hellip;省略&hellip;&hellip;&nbsp;
&nbsp;&nbsp;<span class="xaml__tag_start">&lt;Button</span>&nbsp;<span class="xaml__attr_name">Content</span>=<span class="xaml__attr_value">&quot;今だ!!&quot;</span>&nbsp;<span class="xaml__attr_name">Command</span>=<span class="xaml__attr_value">&quot;{Binding&nbsp;Command}&quot;</span>&nbsp;&hellip;&hellip;省略&hellip;&hellip;&nbsp;<span class="xaml__tag_start">/&gt;</span>&nbsp;
&nbsp;&nbsp;&hellip;&hellip;省略&hellip;&hellip;&nbsp;
<span class="xaml__tag_end">&lt;/StackPanel&gt;</span></pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p>これで完成? いえ、 まだコマンドで実行する処理を与えていません。<br>
今回は、 Button が配置されている StackPanel の色を変えてみましょう。 この処理は UI を変更するものですから、 V の側に記述します。</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">スクリプトの編集</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">    public MainPage()
    {
      this.InitializeComponent();

      // *** 新しく設置した StackPanel の DataContext の CommandAction を設定する。
      //     UIをいじるアクションなので、コードビハインドで設定する。
      var clk = this.stackPanelForTest.DataContext as Clock;
      if (clk != null)
      {
        clk.CommandAction = async () =&gt;
          {
            this.stackPanelForTest.Background = new SolidColorBrush(Colors.HotPink);
            await Task.Delay(300);
            this.stackPanelForTest.Background = new SolidColorBrush(Colors.Transparent);
          };
      }
    }
</pre>
<div class="preview">
<pre class="csharp">&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;MainPage()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">this</span>.InitializeComponent();&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;***&nbsp;新しく設置した&nbsp;StackPanel&nbsp;の&nbsp;DataContext&nbsp;の&nbsp;CommandAction&nbsp;を設定する。</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;UIをいじるアクションなので、コードビハインドで設定する。</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;clk&nbsp;=&nbsp;<span class="cs__keyword">this</span>.stackPanelForTest.DataContext&nbsp;<span class="cs__keyword">as</span>&nbsp;Clock;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(clk&nbsp;!=&nbsp;<span class="cs__keyword">null</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;clk.CommandAction&nbsp;=&nbsp;async&nbsp;()&nbsp;=&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">this</span>.stackPanelForTest.Background&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;SolidColorBrush(Colors.HotPink);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;await&nbsp;Task.Delay(<span class="cs__number">300</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">this</span>.stackPanelForTest.Background&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;SolidColorBrush(Colors.Transparent);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;};&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p>これで完成です。<br>
<br>
<img id="81356" src="81356-20130428_icommand01.png" alt="" width="683" height="384"></p>
<p>実行すると、秒が偶数のときに [今だ!!] ボタンが有効になるので、 その間にクリックすると背景がピンクに変わります。</p>
<p>&nbsp;</p>
<h2>補足</h2>
<p>ICommand の実装に出てくる CanExecuteChanged の第1引数は this になっています。 これは、 ほかのオブジェクトを指定したり null だったりしても、 本来は OK です。 ただし、 Windows 8/RT では次の KB2750149 のパッチが当たってないと this しかダメですので、 注意してください。</p>
<p>・KB2750149 (2013/1) &quot;<a href="http://support.microsoft.com/kb/2750149/en-us" target="_blank">An update is available for the .NET Framework 4.5 in Windows 8, Windows RT and Windows Server 2012</a>&quot;<br>
・Connect #751429 (2012/6/28～) &quot;<a href="http://connect.microsoft.com/VisualStudio/feedback/details/751429/wpf-icommand-canexecutechanged-behaviour-change-in-net-4-5#details" target="_blank">WPF: ICommand CanExecuteChanged behaviour change in .NET 4.5</a>&quot;</p>
