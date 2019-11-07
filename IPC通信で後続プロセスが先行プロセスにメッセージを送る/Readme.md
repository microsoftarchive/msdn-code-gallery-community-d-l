# IPC通信で後続プロセスが先行プロセスにメッセージを送る
## Requires
- Visual Studio 2010
## License
- Apache License, Version 2.0
## Technologies
- C#
## Topics
- C# プログラミング
## Updated
- 03/25/2011
## Description

<p>IPC通信によって、指定した型を後続プロセスから先行プロセスに送信します。<br>
イベントを用いて、先行プロセスは後続プロセスからメッセージを受信することが出来ます。</p>
<p>多重起動禁止や、後続プロセスのコマンドライン引数などを先行プロセスに渡して、後続プロセスを終了し先行プロセスで処理、みたいなこともできます。<br>
他の方法でも出来そうですが、こんな方法もあるよ、ということで。</p>
<p>先行プロセスはIpcServerChannelを生成してサーバとなり、後続プロセスはIpcClientChannelを生成しクライアントとなります。<br>
サーバとクライアントのコーディング方法は下記のような感じです。こう書くと、サーバでリモートオブジェクトを1つ持ち、それにクライアントがアクセスする感じになります。</p>
<p>●サーバ部分（先行プロセス）</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginEditHolderLink">スクリプトの編集</div>
<span class="hidden">csharp</span>
<pre class="hidden">_channel = new IpcServerChannel(portName, portName, new BinaryServerFormatterSinkProvider
{
	TypeFilterLevel = TypeFilterLevel.Full,
});
ChannelServices.RegisterChannel(_channel, true);

RemotingConfiguration.RegisterWellKnownServiceType(
	typeof(MessageHolder), uri, WellKnownObjectMode.Singleton);
_messageHolder = new MessageHolder();
RemotingServices.Marshal(_messageHolder, uri, typeof(MessageHolder));</pre>
<div class="preview">
<pre class="csharp">_channel&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;IpcServerChannel(portName,&nbsp;portName,&nbsp;<span class="cs__keyword">new</span>&nbsp;BinaryServerFormatterSinkProvider&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;TypeFilterLevel&nbsp;=&nbsp;TypeFilterLevel.Full,&nbsp;
});&nbsp;
ChannelServices.RegisterChannel(_channel,&nbsp;<span class="cs__keyword">true</span>);&nbsp;
&nbsp;
RemotingConfiguration.RegisterWellKnownServiceType(&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">typeof</span>(MessageHolder),&nbsp;uri,&nbsp;WellKnownObjectMode.Singleton);&nbsp;
_messageHolder&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;MessageHolder();&nbsp;
RemotingServices.Marshal(_messageHolder,&nbsp;uri,&nbsp;<span class="cs__keyword">typeof</span>(MessageHolder));&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p>●クライアント部分（後続プロセス）</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginEditHolderLink">スクリプトの編集</div>
<span class="hidden">csharp</span>
<pre class="hidden">_channel = new IpcClientChannel();
ChannelServices.RegisterChannel(_channel, true);

RemotingConfiguration.RegisterWellKnownClientType(
	typeof(MessageHolder), string.Format(&quot;ipc://{0}/{1}&quot;, portName, uri));
_messageHolder = new MessageHolder();</pre>
<div class="preview">
<pre class="csharp">_channel&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;IpcClientChannel();&nbsp;
ChannelServices.RegisterChannel(_channel,&nbsp;<span class="cs__keyword">true</span>);&nbsp;
&nbsp;
RemotingConfiguration.RegisterWellKnownClientType(&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">typeof</span>(MessageHolder),&nbsp;<span class="cs__keyword">string</span>.Format(<span class="cs__string">&quot;ipc://{0}/{1}&quot;</span>,&nbsp;portName,&nbsp;uri));&nbsp;
_messageHolder&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;MessageHolder();&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p>イベントは、後続プロセスから先行プロセスへの一方通行となります。<br>
これは、リモートオブジェクトの実態を持っているのが、サーバ（先行プロセス）だからです。<br>
オブジェクトをクライアントとサーバの双方で持っていれば、双方向の通信が出来そうなので、そのうち改良します。</p>
<p>リモートで通信を行うオブジェクトは以下のようになります。<br>
MarshalByRefObjectの継承は必須です。<br>
InitializeLifetimeServiceをオーバーライドし、リース期限を無制限にします。こうすることで、生成されたリモートオブジェクトが勝手に破棄されなくなります。<br>
MessageReceivedイベントにサーバがハンドラを登録するわけですが、そのオブジェクトが破棄されると、次のクライアントからのアクセスにより新しオブジェクトが生成されてしまうことになります。その新しいオブジェクトのイベントにはサーバはなにも登録していませんので、サーバはメッセージ受信を感知出来なくなってしまいます。</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginEditHolderLink">スクリプトの編集</div>
<span class="hidden">csharp</span>
<pre class="hidden">private sealed class MessageHolder : MarshalByRefObject
{
	/// &lt;summary&gt;
	/// 有効期間サービス オブジェクトを取得します。
	/// &lt;/summary&gt;
	public override object InitializeLifetimeService()
	{
		// このオブジェクトのリース期限を無制限にします。
		// そうしなければ、オブジェクトにアクセスせず一定期限が過ぎると
		// 自動的に破棄されてしまいます。
		var lease = base.InitializeLifetimeService() as ILease;
		if (lease.CurrentState == LeaseState.Initial)
		{
			lease.InitialLeaseTime = TimeSpan.Zero;
		}
		return lease;
	}

	/// &lt;summary&gt;
	/// メッセージを受信したときに発生します。
	/// &lt;/summary&gt;
	public event Action&lt;T&gt; MessageReceived;

	/// &lt;summary&gt;
	/// MessageEventHandler イベントを発生させます。
	/// &lt;/summary&gt;
	public void OnMessageReceived(T message)
	{
		if (MessageReceived != null)
			MessageReceived(message);
	}
}</pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">sealed</span>&nbsp;<span class="cs__keyword">class</span>&nbsp;MessageHolder&nbsp;:&nbsp;MarshalByRefObject&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;&lt;summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;有効期間サービス&nbsp;オブジェクトを取得します。</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;&lt;/summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">override</span>&nbsp;<span class="cs__keyword">object</span>&nbsp;InitializeLifetimeService()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;このオブジェクトのリース期限を無制限にします。</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;そうしなければ、オブジェクトにアクセスせず一定期限が過ぎると</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;自動的に破棄されてしまいます。</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;lease&nbsp;=&nbsp;<span class="cs__keyword">base</span>.InitializeLifetimeService()&nbsp;<span class="cs__keyword">as</span>&nbsp;ILease;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(lease.CurrentState&nbsp;==&nbsp;LeaseState.Initial)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;lease.InitialLeaseTime&nbsp;=&nbsp;TimeSpan.Zero;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;lease;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;&lt;summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;メッセージを受信したときに発生します。</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;&lt;/summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">event</span>&nbsp;Action&lt;T&gt;&nbsp;MessageReceived;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;&lt;summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;MessageEventHandler&nbsp;イベントを発生させます。</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;&lt;/summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;OnMessageReceived(T&nbsp;message)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(MessageReceived&nbsp;!=&nbsp;<span class="cs__keyword">null</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;MessageReceived(message);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
}&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
