using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Threading;
using WebClientFtp.Properties;

namespace WebClientFtp.FTP
{
  public class UploadFiles
  {
    private SortedList<string, string> ArgList = new SortedList<string, string>(4);
    private WebClient _webClient;

    public UploadFiles(string[] args)
    {
      string key = null;

      foreach (string arg in args)
      {
        if (arg[0] == '-')
        {
          key = arg.ToLower();
        }
        else if (key != null)
        {
          if (!ArgList.ContainsKey(key))
          {
            ArgList.Add(key, arg);
          }
        }
      }
      if (!ArgList.ContainsKey("-source") || !ArgList.ContainsKey("-ftpdest"))
      {
        Console.WriteLine("Usage: WebClientFtp -source <path-to-local-folder> -ftpdest <uri-ftp-directory>");
        Console.WriteLine("                  [ -user <userName> -pwd <password> ]");
        Console.WriteLine("       -source and -ftpdest are required arguments");
        Console.ReadKey(true);
        Environment.Exit(1);
      }
      _webClient = new WebClient();
    }

    public void CopyFolderFiles()
    {
      string sPath = ArgList["-source"];

      if (Directory.Exists(sPath))
      {
        //get all files in path
        string[] files = Directory.GetFiles(sPath, "*.*", SearchOption.TopDirectoryOnly);
        //if user and password exist, set credentials
        if (ArgList.ContainsKey("-user") && ArgList.ContainsKey("-pwd"))
        {
          _webClient.Credentials = new NetworkCredential(ArgList["-user"], ArgList["-pwd"]);
        }
        bool UploadCompleted;
        int wait = Settings.Default.WaitInterval;
        string ftpDest = ArgList["-ftpdest"];
        //loop through files in folder and upload
        foreach (string file in files)
        {
          do
          {
            UploadCompleted = ftpUpFile(file, ftpDest);
            if (!UploadCompleted)
            {
              Thread.Sleep(wait);
              wait += 1000; //wait an extra second after each failed attempt
            }
          } while (!UploadCompleted);
        }
      }
    }

    private bool ftpUpFile(string filePath, string ftpUri)
    {
      try
      {
        Console.WriteLine("Uploading file: " + filePath + "\nTo: " + ftpUri);

        //create full uri path
        string file = ftpUri + "/" + Path.GetFileName(filePath);

        //ftp the file to Uri path via the ftp STOR command
        // (ignoring the the Byte[] array return since it is always empty in this case)
        _webClient.UploadFile(file, filePath);
        Console.WriteLine("Upload complete.");
        return true;
      }
      catch (Exception ex)
      {
        //WebException is frequenty thrown for this condition: 
        //    "An error occurred while uploading the file"
        Console.WriteLine(ex.Message);
        return false;
      }
    }

  }
}
