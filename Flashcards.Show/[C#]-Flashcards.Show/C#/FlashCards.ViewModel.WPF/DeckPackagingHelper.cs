using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.WindowsAPICodePack.Dialogs;
using Microsoft.WindowsAPICodePack.Shell;
using System.Windows;
using System.IO.Packaging;
using System.IO;
using System.Xml;
using System.Windows.Markup;
using System.Xml.Serialization;
using System.Collections;
using System.Reflection;

namespace FlashCards.ViewModel
{
    /// <summary>
    /// Helper Class used to Package and UnPackage Deck folder for sharing purpose.
    /// </summary>
    public static class DeckPackagingHelper
    {
        /// <summary>
        /// This will Package the Deck folder in to .deck file, and will be saved to a user selected location
        /// When the user clicks on share deck button this method is called
        /// </summary>
        /// <param name="deckRootPath">Path of the Deck , which is to be packaged. </param>
        /// <param name="deckTitle">Title of the deck</param>
        public static void PackageDeck(string deckRootPath, string deckTitle)
        {
            try
            {
                string zippedDeckFileName = Path.Combine(DeckFileHelper.ZippedDecksPath, deckTitle) + MainViewModel.ZippedDeckExtension;

                string[] fullPathFiles = Directory.GetFiles(deckRootPath);

                List<string> fileNames = new List<string>();

                foreach (string filename in fullPathFiles)
                {
                    string zippedFileName = AddFileToZip(zippedDeckFileName, filename);

                    fileNames.Add(Path.GetFileName(zippedFileName));
                    fileNames.Add(Path.GetFileName(filename));
                }

                // Add files.xml to zip
                string pathFilesXml = Path.Combine(deckRootPath, "files.xml");
                File.Delete(pathFilesXml);
                FileStream fs = File.Create(pathFilesXml);
                XmlSerializer SerializerObj = new XmlSerializer(typeof(string[]));
                SerializerObj.Serialize(fs, fileNames.ToArray());
                fs.Close();
                    
                AddFileToZip(zippedDeckFileName, pathFilesXml);
            }
            catch (Exception e)
            {
                Utils.LogException(MethodBase.GetCurrentMethod(), e);
            }
        }

        /// <summary>
        /// This holds the logic for unpacking the deck from the .deck package and saving it locally
        /// </summary>
        /// <param name="zipFilename">.deck file path</param>
        /// <param name="newDeckGUID">New deck foldername</param>
        public static string ExtractFromZip(string zipFilename)
        {
            try
            {
                string deckGuid = string.Empty;
                string deckTitle = string.Empty;
                string outputPath;
                using (Package unZip = System.IO.Packaging.Package.Open(zipFilename, FileMode.Open, FileAccess.Read))
                {
                    Uri uri = new Uri("/deck.xml", UriKind.RelativeOrAbsolute);
                    PackagePart xmlPart = unZip.GetPart(uri);
                    Stream xmlStream = xmlPart.GetStream(FileMode.Open, FileAccess.Read);

                    XmlSerializer SerializerObj = new XmlSerializer(typeof(CardDeck));
                    CardDeck cDeck = (CardDeck)SerializerObj.Deserialize(xmlStream);

                    xmlStream.Close();


                    Uri uriFilesXml = new Uri("/files.xml", UriKind.RelativeOrAbsolute);
                    xmlPart = unZip.GetPart(uriFilesXml);
                    xmlStream = xmlPart.GetStream(FileMode.Open, FileAccess.Read);

                    SerializerObj = new XmlSerializer(typeof(string[]));
                    string[] fileNames = (string[])SerializerObj.Deserialize(xmlStream);


                    xmlStream.Close();

                    // prepare dictionary
                    Dictionary<string, string> dic = new Dictionary<string, string>();
                    for (int i = 0; i < fileNames.Length; i += 2)
                    {
                        dic[fileNames[i]] = fileNames[i + 1];
                    }

                    

                    deckGuid = cDeck.DeckGUID;
                    deckTitle = cDeck.Title;
                    outputPath = Path.Combine(DeckFileHelper.ApplicationTempPath, deckGuid);
                    
                    if (!Directory.Exists(outputPath))
                        Directory.CreateDirectory(outputPath);
                    foreach (PackagePart part in unZip.GetParts())
                    {
                        string destFilename = Path.Combine(outputPath, Path.GetFileName(part.Uri.OriginalString));
                        if (dic.ContainsKey(Path.GetFileName(part.Uri.OriginalString)))
                        {
                            destFilename = Path.Combine(outputPath, dic[Path.GetFileName(part.Uri.OriginalString)]);
                        }
                        using (Stream source = part.GetStream(FileMode.Open, FileAccess.Read))
                        {
                            using (Stream dest = File.OpenWrite(destFilename))
                            {
                                Utils.CopyStream(source, dest);
                            }
                        }
                    }
                }

                return outputPath;
            }
            catch (Exception e)
            {
                Utils.LogException(MethodBase.GetCurrentMethod(), e);
                return string.Empty;
            }
        }

        /// <summary>
        /// this method holds the logic for packaging the deck folder and saving to the user specified location
        /// </summary>
        /// <param name="zipFilename"> user given package name</param>
        /// <param name="fileToAdd"> deck files to be added</param>
        private static string AddFileToZip(string zipFilename, string fileToAdd)
        {
            try
            {
                using (Package zip = System.IO.Packaging.Package.Open(zipFilename, FileMode.OpenOrCreate))
                {
                    string destFilename = ".\\" + Path.GetFileName(fileToAdd);
                    Uri uri = PackUriHelper.CreatePartUri(new Uri(destFilename, UriKind.Relative));
                    if (zip.PartExists(uri))
                    {
                        zip.DeletePart(uri);
                    }
                    PackagePart part = zip.CreatePart(uri, "", CompressionOption.Normal);
                    using (FileStream fileStream = new FileStream(fileToAdd, FileMode.Open, FileAccess.Read))
                    {
                        using (Stream dest = part.GetStream())
                        {
                            Utils.CopyStream(fileStream, dest);
                        }
                    }
                    return uri.ToString();
                }
            }
            catch (Exception e)
            {
                Utils.LogException(MethodBase.GetCurrentMethod(), e);
                return string.Empty;
            }
        }
    }
}
