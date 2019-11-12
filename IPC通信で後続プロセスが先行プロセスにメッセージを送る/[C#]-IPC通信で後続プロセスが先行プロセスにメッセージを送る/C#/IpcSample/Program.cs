using System;
using ShComp.Ipc;

namespace IpcSample
{
	class Program
	{
		static void Main(string[] args)
		{
			var ipc = new IpcMessageSender<string>("sample", "sample");

			if (ipc.IsCadet)
			{
				// ポートとURIが同じIPC通信がすでに作成されていた場合
				// (このプログラムの2個を起動した場合、など)
				// ここが実行されます。
				// ここでプログラムを終了すれば、多重起動禁止とかできます。

				// 後続プロセスのコマンドライン引数などを先行プロセスに渡して、
				// 後続プロセスを終了、先行プロセスで処理、みたいなこともできます。

				// それだけならもっといい方法があるって？使い方は自分で考えてくれ！！

				Console.WriteLine("すでに起動しています。");
				ipc.SendMessage(string.Format("{0:HH時mm分ss秒}です。後続プロセスが起動しました。", DateTime.Now));
			}
			else
			{
				// IPCでオブジェクトを受信したとき発生します。
				Console.WriteLine("先行プロセスです。後続プロセスの起動を待機しています。");
				ipc.MessageReceived += new MessageEventHandler<string>(ipc_MessageReceived);
			}
			Console.ReadLine();
		}

		static void ipc_MessageReceived(object sender, MessageEventArgs<string> e)
		{
			// 同じポートとURIを持つ IpcObjectSender で SendObject が呼び出された時発生します。
			// 今回のように後続プロセスが SendObject を呼び出せば、先に起動していたプロセスが
			// 後続の起動を検知できます。
			Console.WriteLine(e.Message);
		}
	}
}
