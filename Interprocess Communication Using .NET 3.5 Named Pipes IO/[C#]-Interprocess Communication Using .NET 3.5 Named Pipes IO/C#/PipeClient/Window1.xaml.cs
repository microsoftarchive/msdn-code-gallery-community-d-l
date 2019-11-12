using System.IO;
using System.IO.Pipes;
using System.Windows;

namespace PipeClient
{
  /// <summary>
  /// Test Client sends strings entered in a TextBlock to the PipeServer
  /// </summary>
  public partial class Window1 : Window
  {
    public Window1()
    {
      InitializeComponent();
    }

    private void button1_Click(object sender, RoutedEventArgs e)
    {
      using (NamedPipeClientStream pipeClient = new NamedPipeClientStream(".", "testpipe",
                                                                        PipeDirection.Out, 
                                                                 PipeOptions.Asynchronous))
      {
        tbStatus.Text = "Attempting to connect to pipe...";
        try
        {
          pipeClient.Connect(2000);
        }
        catch
        {
          MessageBox.Show("The Pipe server must be started in order to send data to it.");
          return;
        }
        tbStatus.Text = "Connected to pipe.";
        using (StreamWriter sw = new StreamWriter(pipeClient))
        {
          sw.WriteLine(tbClientText.Text);
        }
      }
      tbStatus.Text = "";
    }

    private void btnClose_Click(object sender, RoutedEventArgs e)
    {
      this.Close();
    }
  }
}
