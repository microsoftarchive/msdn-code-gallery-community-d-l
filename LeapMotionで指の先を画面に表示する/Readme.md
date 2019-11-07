# LeapMotionで指の先を画面に表示する
## Requires
- Visual Studio 2013
## License
- Apache License, Version 2.0
## Technologies
- Leap Motion
## Topics
- Leap Motion
## Updated
- 06/29/2014
## Description

<h1>サンプルプログラムの概要</h1>
<p>このサンプルプログラムは、LeapMotionのv2(beta)を使って、画面上に認識した手の指先の場所を表示するサンプルプログラムです。</p>
<p><img id="119386" src="119386-fingerpos.jpg" alt="" width="500" height="500"></p>
<p>指の位置は、丸で表示されます。Leap Motionで検出したX座標Y座標を、ウィンドウ内の位置に変換して表示しています。丸の大きさはZ軸の座標をベースに50px～150pxの大きさで変化します。</p>
<h1>サンプルプログラムの実行方法</h1>
<p>サンプルプログラムには、Leap MotionのSDKのDLLは同梱していません。ダウンロードしたサンプルプログラムを解凍したあとにLeap MotionのサイトからSDKをダウンロードしてプロジェクトファイル直下にDLLを置いてください。</p>
<ul>
<li>Leap Motionのサイト<br>
https://developer.leapmotion.com/ </li><li>プロジェクト直下に置く必要のあるDLL
<ul>
<li>&nbsp;Leap.dll </li><li>LeapCSharp.dll(x86) </li><li>LeapCSharp.NET4.0.dll(x86) </li></ul>
</li></ul>
<p>DLLを置いてビルドをするとNuGetのパッケージの復元が行われてサンプルプログラムが実行されます。</p>
<h1>サンプルプログラムのポイント</h1>
<p>このサンプルプログラムのポイントを説明します。</p>
<h2>Leap Motionからの値の処理</h2>
<p>このサンプルプログラムでは、Leap Motionから受け取った値の処理をReactivePropertyとReactive Extensionを使って処理をしています。Leap MotionのListenerから、Frameを取り出し、Modelクラスに用意したFrameを受け取るReactivePropertyにセットしています。</p>
<p></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">スクリプトの編集</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">class LeapListener : Listener
{
    private Model model;

    public LeapListener(Model model)
    {
        this.model = model;
    }

    public override void OnFrame(Controller c)
    {
        this.model.Frame.Value = c.Frame();
    }
}
</pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">class</span>&nbsp;LeapListener&nbsp;:&nbsp;Listener&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span>&nbsp;Model&nbsp;model;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;LeapListener(Model&nbsp;model)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">this</span>.model&nbsp;=&nbsp;model;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">override</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;OnFrame(Controller&nbsp;c)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">this</span>.model.Frame.Value&nbsp;=&nbsp;c.Frame();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
}&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p></p>
<p>Model内では、Frameから左手と右手を抽出しています。Modelクラスのコンストラクタに該当するコードがあります。</p>
<p></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">スクリプトの編集</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">this.Frame = new ReactiveProperty&lt;Leap.Frame&gt;();
var frames = this.Frame
    .Where(f =&gt; f != null)
    .Sample(TimeSpan.FromSeconds(1 / 60.0));

var leftHand = frames
    .Select(f =&gt; f.Hands)
    .Select(hs =&gt; hs.FirstOrDefault(h =&gt; h.IsLeft));

var rightHand = frames
    .Select(f =&gt; f.Hands)
    .Select(hs =&gt; hs.FirstOrDefault(h =&gt; h.IsRight));
</pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">this</span>.Frame&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;ReactiveProperty&lt;Leap.Frame&gt;();&nbsp;
var&nbsp;frames&nbsp;=&nbsp;<span class="cs__keyword">this</span>.Frame&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;.Where(f&nbsp;=&gt;&nbsp;f&nbsp;!=&nbsp;<span class="cs__keyword">null</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;.Sample(TimeSpan.FromSeconds(<span class="cs__number">1</span>&nbsp;/&nbsp;<span class="cs__number">60.0</span>));&nbsp;
&nbsp;
var&nbsp;leftHand&nbsp;=&nbsp;frames&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;.Select(f&nbsp;=&gt;&nbsp;f.Hands)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;.Select(hs&nbsp;=&gt;&nbsp;hs.FirstOrDefault(h&nbsp;=&gt;&nbsp;h.IsLeft));&nbsp;
&nbsp;
var&nbsp;rightHand&nbsp;=&nbsp;frames&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;.Select(f&nbsp;=&gt;&nbsp;f.Hands)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;.Select(hs&nbsp;=&gt;&nbsp;hs.FirstOrDefault(h&nbsp;=&gt;&nbsp;h.IsRight));&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p></p>
<p>上記コードでは、Frameを60分の1秒間隔で取得して、その中から左手、右手を取得しています。続きのコードで、手が取得できた場合は指の情報を取得して指の場所をLeap MotionのInteractionBoxを使って-1～1の間に正規化しています。</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">スクリプトの編集</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">this.LeftHandFingers = leftHand
    .Where(h =&gt; h != null)
    .Select(h =&gt; h.Fingers)
    .Select(fs =&gt;
    {
        var frame = fs.Leftmost.Frame;
        return fs
            .Select(f =&gt; frame.InteractionBox.NormalizePoint(f.TipPosition))
            .Select(v =&gt; new FingerPoint { X = v.x, Y = v.y, Z = v.z })
            .ToList();
    })
    .ToReactiveProperty();
</pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">this</span>.LeftHandFingers&nbsp;=&nbsp;leftHand&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;.Where(h&nbsp;=&gt;&nbsp;h&nbsp;!=&nbsp;<span class="cs__keyword">null</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;.Select(h&nbsp;=&gt;&nbsp;h.Fingers)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;.Select(fs&nbsp;=&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;frame&nbsp;=&nbsp;fs.Leftmost.Frame;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;fs&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.Select(f&nbsp;=&gt;&nbsp;frame.InteractionBox.NormalizePoint(f.TipPosition))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.Select(v&nbsp;=&gt;&nbsp;<span class="cs__keyword">new</span>&nbsp;FingerPoint&nbsp;{&nbsp;X&nbsp;=&nbsp;v.x,&nbsp;Y&nbsp;=&nbsp;v.y,&nbsp;Z&nbsp;=&nbsp;v.z&nbsp;})&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.ToList();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;})&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;.ToReactiveProperty();&nbsp;
</pre>
</div>
</div>
</div>
<p class="endscriptcode">そして、最後に、ReactivePropertyに変換をしてプロパティに設定しています。</p>
<h2 class="endscriptcode">画面に表示する座標への変換</h2>
<p>-1～1の値に正規化された値を画面の座標に変換するのは、Converterで実装しています。ApplicationクラスからMainWindowを取得して幅と高さを算出しています。</p>
<p></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">スクリプトの編集</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">public class MarginConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
    {
        var width = Application.Current.MainWindow.ActualWidth;
        var height = Application.Current.MainWindow.ActualHeight;
        var pos = (FingerPoint)value;
        var result = new Thickness();

        result.Top = height - height * pos.Y;
        result.Left = width * pos.X;

        return result;
    }

    public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}</pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">class</span>&nbsp;MarginConverter&nbsp;:&nbsp;IValueConverter&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">object</span>&nbsp;Convert(<span class="cs__keyword">object</span>&nbsp;<span class="cs__keyword">value</span>,&nbsp;Type&nbsp;targetType,&nbsp;<span class="cs__keyword">object</span>&nbsp;parameter,&nbsp;System.Globalization.CultureInfo&nbsp;culture)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;width&nbsp;=&nbsp;Application.Current.MainWindow.ActualWidth;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;height&nbsp;=&nbsp;Application.Current.MainWindow.ActualHeight;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;pos&nbsp;=&nbsp;(FingerPoint)<span class="cs__keyword">value</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;result&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;Thickness();&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;result.Top&nbsp;=&nbsp;height&nbsp;-&nbsp;height&nbsp;*&nbsp;pos.Y;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;result.Left&nbsp;=&nbsp;width&nbsp;*&nbsp;pos.X;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;result;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">object</span>&nbsp;ConvertBack(<span class="cs__keyword">object</span>&nbsp;<span class="cs__keyword">value</span>,&nbsp;Type&nbsp;targetType,&nbsp;<span class="cs__keyword">object</span>&nbsp;parameter,&nbsp;System.Globalization.CultureInfo&nbsp;culture)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">throw</span>&nbsp;<span class="cs__keyword">new</span>&nbsp;NotImplementedException();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
}</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p></p>
<h2 class="endscriptcode">丸の大きさへの変換</h2>
<p>Z座標から丸の大きさへの変換もConverterを使って行っています。SizeConverterでZ座標から算出を行っています。</p>
<p></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">スクリプトの編集</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">public double BaseSize { get; set; }

public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
{
    var pos = (FingerPoint)value;
    var z = -1 * (pos.Z - 1);
    return this.BaseSize &#43; this.BaseSize * z;
}</pre>
<div class="preview">
<pre class="js">public&nbsp;double&nbsp;BaseSize&nbsp;<span class="js__brace">{</span>&nbsp;get;&nbsp;set;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;
public&nbsp;object&nbsp;Convert(object&nbsp;value,&nbsp;Type&nbsp;targetType,&nbsp;object&nbsp;parameter,&nbsp;System.Globalization.CultureInfo&nbsp;culture)&nbsp;
<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;pos&nbsp;=&nbsp;(FingerPoint)value;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;z&nbsp;=&nbsp;-<span class="js__num">1</span>&nbsp;*&nbsp;(pos.Z&nbsp;-&nbsp;<span class="js__num">1</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">return</span>&nbsp;<span class="js__operator">this</span>.BaseSize&nbsp;&#43;&nbsp;<span class="js__operator">this</span>.BaseSize&nbsp;*&nbsp;z;&nbsp;
<span class="js__brace">}</span></pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p></p>
