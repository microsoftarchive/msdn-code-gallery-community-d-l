using System;
using WebClientFtp.FTP;

namespace WebClientFtp
{
  class Program
  {
    static void Main(string[] args)
    {
      try
      {
        UploadFiles uploadFiles = new UploadFiles(args);
        uploadFiles.CopyFolderFiles();
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex.Message);
      }
    }
  }
}
