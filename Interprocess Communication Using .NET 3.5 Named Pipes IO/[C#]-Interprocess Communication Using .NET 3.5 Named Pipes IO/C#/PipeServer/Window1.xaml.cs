using System;
using System.IO.Pipes;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Controls;

namespace PipeServer
{
  /// <summary>
  /// PipeServer creates a listener thread and waits for messages from clients.
  /// Received messages are displayed in Textbox
  /// </summary>
  public partial class Window1 : Window
  {
    public Window1()
    {
      InitializeComponent();
    }

    private void Window_Loaded(object sender, RoutedEventArgs e)
    {
      tbox.Text = "";
      Pipeserver.pipeName = "testpipe";
      Pipeserver.owner = this;
      Pipeserver.ownerInvoker = new Invoker(this);
      ThreadStart pipeThread = new ThreadStart(Pipeserver.createPipeServer);
      Thread listenerThread = new Thread(pipeThread);
      listenerThread.SetApartmentState(ApartmentState.STA);
      listenerThread.IsBackground = true;
      listenerThread.Start();
    }
  }

  public class Invoker
  {
    public Action<string> sDel;
    private Window1 owner;

    public Invoker(Window1 wOwner)
    {
      owner = wOwner;
    }

    public void Invoke(string sArg)
    {
      owner.Dispatcher.Invoke(sDel, sArg);
    }

    public void BeginInvoke(string sArg)
    {
      owner.Dispatcher.BeginInvoke(sDel, sArg);
    }
  }

  public class Pipeserver
  {
    public static Window1 owner;
    public static Invoker ownerInvoker;
    public static string pipeName;
    private static NamedPipeServerStream pipeServer;
    private static readonly int BufferSize = 256;

    private static void SetTextbox(String text)
    {
      owner.tbox.Text = String.Concat(owner.tbox.Text, text);
      if (owner.tbox.ExtentHeight > owner.tbox.ViewportHeight)
      {
        owner.tbox.ScrollToEnd();
      }
    }

    public static void createPipeServer()
    {
      Decoder decoder = Encoding.Default.GetDecoder();
      Byte[] bytes = new Byte[BufferSize];
      char[] chars = new char[BufferSize];
      int numBytes = 0;
      StringBuilder msg = new StringBuilder();
      ownerInvoker.sDel = SetTextbox;

      try
      {
        pipeServer = new NamedPipeServerStream(pipeName, PipeDirection.In, 1,
                                               PipeTransmissionMode.Message, 
                                               PipeOptions.Asynchronous);
        while (true)
        {
          pipeServer.WaitForConnection();

          do
          {
            msg.Length = 0;
            do
            {
              numBytes = pipeServer.Read(bytes, 0, BufferSize);
              if (numBytes > 0)
              {
                int numChars = decoder.GetCharCount(bytes, 0, numBytes);
                decoder.GetChars(bytes, 0, numBytes, chars, 0, false);
                msg.Append(chars, 0, numChars);
              }
            } while (numBytes > 0 && !pipeServer.IsMessageComplete);
            decoder.Reset();
            if (numBytes > 0)
            {
              ownerInvoker.Invoke(msg.ToString());
            }
          } while (numBytes != 0);
          pipeServer.Disconnect();
        }
      }
      catch (Exception ex)
      {
        MessageBox.Show(ex.Message);
      }
    }
  }
}

