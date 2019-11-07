using System;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Ipc;
using System.Runtime.Remoting.Lifetime;
using System.Runtime.Serialization.Formatters;
using System.Threading;
using IpcSample;

namespace ShComp.Ipc
{
	/// <summary>
	/// IPC通信によって、指定した型を後続プロセスから先行プロセスに送信します。<para />
	/// T は、シリアライズ可能型じゃないとたぶんだめです。
	/// </summary>
	/// <typeparam name="T">通信するメッセージの型</typeparam>
	// シリアライズ可能型じゃないと MessageHolder のイベントに追加できないので Serializable を設定します。
	// 中身のフィールドは別にシリアル化されなくてもいいので NonSerialized します。
	//
	// ※イベントについて
	// リモートのオブジェクトのイベントは、発生させることはできても登録が出来ません。
	// そのため、イベントの発生は後続->先行の一方通行になります。
	[Serializable]
	public sealed class IpcMessageSender<T> : IDisposable
	{
		/// <summary>
		/// 指定したポート名とURIを使用してIPC通信を作成します。
		/// </summary>
		/// <param name="portName">ポート名</param>
		/// <param name="uri">URI</param>
		public IpcMessageSender(string portName, string uri)
		{
			// サーバ作成が成功したら、指定したポートを使用するIPC通信が初めて作成されたことを表します。
			// そうでなければ、このIPC通信が後続であることを表しているため、クライアントを作成します。
			// これらが同時に実行されないように、サーバ作成・クライアント作成をMutexで同期します。
			using (var mutex = new Mutex(true, typeof(MessageHolder).FullName + " " + portName))
			{
				mutex.WaitOne();
				try
				{
					// サーバ作成
					// name も portName も、同じでつくっちゃいます。
					_channel = new IpcServerChannel(portName, portName, new BinaryServerFormatterSinkProvider
					{
						TypeFilterLevel = TypeFilterLevel.Full,
					});
					ChannelServices.RegisterChannel(_channel, true);

					RemotingConfiguration.RegisterWellKnownServiceType(
						typeof(MessageHolder), uri, WellKnownObjectMode.Singleton);
					_messageHolder = new MessageHolder();
					RemotingServices.Marshal(_messageHolder, uri, typeof(MessageHolder));

					IsCadet = false;

					// メッセージの送受信は MessageHolder を介しておこなわれます。
					// MessageHolder の MessageReceived イベントをキャッチして、
					// このクラスに設定された MessageReceived イベントを発生させます。
					_messageHolder.MessageReceived += new Action<T>(MessageHolder_MessageReceived);
				}
				catch (RemotingException)
				{
					// クライアント作成
					_channel = new IpcClientChannel();
					ChannelServices.RegisterChannel(_channel, true);

					RemotingConfiguration.RegisterWellKnownClientType(
						typeof(MessageHolder), string.Format("ipc://{0}/{1}", portName, uri));
					_messageHolder = new MessageHolder();

					IsCadet = true;
				}
			}
		}

		[NonSerialized]
		private IChannel _channel;
		[NonSerialized]
		private MessageHolder _messageHolder;

		/// <summary>
		/// このIPC通信が後続かどうかを取得します。
		/// </summary>
		public bool IsCadet { get; private set; }
		/// <summary>
		/// 直前に受信したメッセージを取得します。
		/// </summary>
		public T Message { get; private set; }

		private event MessageEventHandler<T> _messageReceived;
		/// <summary>
		/// メッセージを受信したときに発生します。<para />
		/// 後続プロセスの場合は操作できません。
		/// </summary>
		public event MessageEventHandler<T> MessageReceived
		{
			add
			{
				if (IsCadet)
					throw new Exception("後続プロセスは、メッセージ受信イベントを操作できません。");
				_messageReceived += value;
			}
			remove
			{
				if (IsCadet)
					throw new Exception("後続プロセスは、メッセージ受信イベントを操作できません。");
				_messageReceived -= value;
			}
		}

		/// <summary>
		/// MessageReceived イベントを発生させます。
		/// </summary>
		private void MessageHolder_MessageReceived(T message)
		{
			Message = message;
			if (_messageReceived != null)
				_messageReceived(this, new MessageEventArgs<T>(message));
		}

		/// <summary>
		/// メッセージを送信します。
		/// </summary>
		/// <param name="message">送信するメッセージ</param>
		public void SendMessage(T message)
		{
			_messageHolder.OnMessageReceived(message);
		}

		/// <summary>
		/// 直前にやり取りされたメッセージをそのまま送信します。
		/// </summary>
		public void SendMessage()
		{
			SendMessage(Message);
		}

		/// <summary>
		/// このインスタンスを破棄します。
		/// </summary>
		public void Dispose()
		{
			ChannelServices.UnregisterChannel(_channel);
		}

		/// <summary>
		/// すべてのプロセスが共通して持ち、送受信されるメッセージを格納します。
		/// </summary>
		private sealed class MessageHolder : MarshalByRefObject
		{
			/// <summary>
			/// 有効期間サービス オブジェクトを取得します。
			/// </summary>
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

			/// <summary>
			/// メッセージを受信したときに発生します。
			/// </summary>
			public event Action<T> MessageReceived;

			/// <summary>
			/// MessageEventHandler イベントを発生させます。
			/// </summary>
			public void OnMessageReceived(T message)
			{
				if (MessageReceived != null)
					MessageReceived(message);
			}
		}
	}

	/// <summary>
	/// IPC通信で発生するメッセージの受け渡しに関するイベントを処理するメソッドを表します。
	/// </summary>
	public delegate void MessageEventHandler<T>(object sender, MessageEventArgs<T> e);

	/// <summary>
	/// IPC通信で発生するメッセージの受け渡しに関するイベントのデータを提供します。
	/// </summary>
	public sealed class MessageEventArgs<T> : EventArgs
	{
		public MessageEventArgs(T message)
		{
			Message = message;
		}

		/// <summary>
		/// メッセージを取得します。
		/// </summary>
		public T Message { get; private set; }
	}
}
