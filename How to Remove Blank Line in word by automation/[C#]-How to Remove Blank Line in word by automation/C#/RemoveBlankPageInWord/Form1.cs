using System;
using System.IO;
using System.Windows.Forms;

using System.Runtime.InteropServices;
using Word = Microsoft.Office.Interop.Word;

namespace RemoveBlankPageInWord
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //the path of word document
        string wordPath = null; 
        
       
        // Open word document   
        private void btnOpenWord_Click(object sender, EventArgs e)
        {
            using(OpenFileDialog openfileDialog=new OpenFileDialog())
            {
                openfileDialog.Filter="Word document(*.doc,*.docx)|*.doc;*.docx";
                if (openfileDialog.ShowDialog() == DialogResult.OK)
                {
                    txbWordPath.Text = openfileDialog.FileName;
                    wordPath = openfileDialog.FileName;
                }
            }
        }

        
        // Click event of Remove Blank Page button     
        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (!File.Exists(txbWordPath.Text))
            {
                MessageBox.Show("Invalid Word Path","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }

            try
            {
                // Remove blank Page in word document
                if (RemoveBlankPage() == true)
                {
                    MessageBox.Show("Remove Blank Page in word successfully");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Remove Failed, error message is: " + ex.Message);
            }
        }
       
        // Remove Blank Page in Word document
        private bool RemoveBlankPage()
        {
            Word.Application wordapp = null;
            Word.Document doc = null;
            Word.Paragraphs paragraphs=null;
            try
            {
                // Start Word APllication and set it be invisible
                wordapp = new Word.Application();
                wordapp.Visible = false;
                doc = wordapp.Documents.Open(wordPath);
                paragraphs = doc.Paragraphs;
                foreach (Word.Paragraph paragraph in paragraphs)
                {
                    if (paragraph.Range.Text.Trim() == string.Empty)
                    {
                        paragraph.Range.Select();
                        wordapp.Selection.Delete();
                    }
                }

                // Save the document and close document
                doc.Save();
                doc.Close();

                // Quit the word application
                wordapp.Quit();

            }
            catch
            {
                throw;
            }
            finally
            { 
                // Clean up the unmanaged Word COM resources by explicitly
                if (paragraphs != null)
                {
                    Marshal.FinalReleaseComObject(paragraphs);
                    paragraphs = null;
                }
                if (doc != null)
                {
                    Marshal.FinalReleaseComObject(doc);
                    doc = null;
                }
                if (wordapp != null)
                {
                    Marshal.FinalReleaseComObject(wordapp);
                    wordapp = null;
                }
            }

            return true;
        }
    }
}
