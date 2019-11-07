using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace FlashCards.ViewModel
{
    public class DeckFileHelper
    {
        public static string ZippedDecksPath
        {
            get
            {
                string myDocumentsFolder = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                string zippedDecksPath = Path.Combine(myDocumentsFolder, GameName);
                return zippedDecksPath;
            }
        }

        public static string ApplicationTempPath
        {
            get
            {
                string generalTempPath = Path.GetTempPath();
                string applicationTempPath = Path.Combine(generalTempPath, GameName);
                return applicationTempPath;
            }
        }

        public const string GameName = "FlashCards.Show";
    }
}
