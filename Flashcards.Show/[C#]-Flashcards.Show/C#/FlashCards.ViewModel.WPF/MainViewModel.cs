using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows;
using System.Xml.Linq;
using System.Xml.Serialization;
using Microsoft.WindowsAPICodePack.Shell;
using Microsoft.WindowsAPICodePack.Taskbar;

namespace FlashCards.ViewModel
{
    public class MainViewModel : BaseMainViewModel
    {
        private MainViewModel()
        {
            Decks = new DecksCollection();

            LoadAllAvailableDecks();
        }

        private void LoadAllAvailableDecks()
        {
            DirectoryInfo info = new DirectoryInfo(DeckFileHelper.ZippedDecksPath);

            // if the decks directory is not created then create it.
            if (!info.Exists)
            {
                info.Create();
            }

            string searchPattern = string.Format("*{0}", ZippedDeckExtension);
            FileInfo[] decks = info.GetFiles(searchPattern, SearchOption.TopDirectoryOnly);

            foreach (FileInfo deck in decks)
            {
                try
                {
                    string outputPath = DeckPackagingHelper.ExtractFromZip(deck.FullName);
                    if (!string.IsNullOrEmpty(outputPath))
                    {
                        LoadUnzippedDeck(deck.FullName, outputPath);
                    }
                }
                catch (Exception e)
                {
                    Utils.LogException(MethodBase.GetCurrentMethod(), e);
                }
            }

            CurrentView = this.Decks;
        }

        public string LoadUnzippedDeck(string originalZipPath, string unzippedDeckPath)
        {
            string deckTitle = string.Empty;

            try
            {
                if (string.IsNullOrEmpty(unzippedDeckPath))
                {
                    return string.Empty;
                }

                using (Stream stream = File.OpenRead(Path.Combine(unzippedDeckPath, "deck.xml")))
                {
                    XmlSerializer SerializerObj = new XmlSerializer(typeof(CardDeck));
                    CardDeck cDeck = (CardDeck)SerializerObj.Deserialize(stream);

                    cDeck.ZipPath = originalZipPath;
                    cDeck.RootPath = unzippedDeckPath;
                    if (cDeck != null)
                    {
                        CardDeck theDeck = Decks.Collection.FirstOrDefault(s => s.RootPath == unzippedDeckPath);

                        if (theDeck != null)
                        {
                            int index = Decks.Collection.IndexOf(theDeck);
                            Decks.Collection.Remove(theDeck);
                            Decks.Collection.Insert(index, cDeck);
                        }
                        else
                        {
                            Decks.Collection.Add(cDeck);
                        }
                    }

                    cDeck.Initialize();
                    foreach (CardPair cp in cDeck.Collection)
                    {
                        cp.ParentDeck = cDeck;
                        cp.Initialize();
                    }

                    deckTitle = cDeck.Title;
                }
            }
            catch (Exception e)
            {
                Utils.LogException(MethodBase.GetCurrentMethod(), e);
            }

            return deckTitle;
        }

        public static MainViewModel Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new MainViewModel();
                }

                return _instance;
            }
        }

        public bool IsAdmin
        {
            get
            {
                return _isAdmin;
            }
            set
            {
                _isAdmin = value;

                if (value)
                {
                    TaskbarManager.Instance.ApplicationId = "FlashCardAdminInstance";
                }
                else
                {
                    TaskbarManager.Instance.ApplicationId = "FlashCardGameInstance";
                }
            }
        }
        
        

        private bool _isAdmin = false;
    
        private static MainViewModel _instance;
    }
}
