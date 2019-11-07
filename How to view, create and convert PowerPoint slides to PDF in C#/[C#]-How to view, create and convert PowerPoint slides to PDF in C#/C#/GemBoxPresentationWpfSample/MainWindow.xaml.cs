using System;
using System.Diagnostics;
using System.IO;
using System.Windows;
using System.Windows.Navigation;
using System.Windows.Xps.Packaging;
using GemBox.Presentation;
using Microsoft.Win32;

namespace GemBoxPresentationWpfSample
{
    public partial class MainWindow : Window
    {
        private PresentationDocument presentation;
        private XpsDocument xpsPresentation;

        static MainWindow()
        {
            ComponentInfo.SetLicense("FREE-LIMITED-KEY");
            ComponentInfo.FreeLimitReached += (sender, e) => e.FreeLimitReachedAction = FreeLimitReachedAction.ContinueAsTrial;
        }

        public MainWindow()
        {
            InitializeComponent();

            this.LoadPresentation("WelcomeToGemBoxPresentation.pptx");
        }

        private void LoadPresentation(string path)
        {
            if (File.Exists(path))
            {
                try
                {

                    this.presentation = PresentationDocument.Load(path);

                    this.UpdatePresentationViewer();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(this, ex.ToString(), "Exception " + ex.GetType() + " occurred while opening a presentation!", MessageBoxButton.OK, MessageBoxImage.Error);
                    Process.Start("http://support.gemboxsoftware.com/new-ticket");
                }
            }
        }

        private void UpdatePresentationViewer()
        {
            // XpsDocument needs to stay referenced so that DocumentViewer 
            // can access additional required resources.
            // Otherwise, GC will collect/dispose XpsDocument and DocumentViewer 
            // will not work.
            this.xpsPresentation = presentation.ConvertToXpsDocument(SaveOptions.Xps);

            this.PresentationViewer.Document = this.xpsPresentation.GetFixedDocumentSequence();
        }

        private void OpenClicked(object sender, RoutedEventArgs e)
        {
            var openFileDialog = new OpenFileDialog()
            {
                DefaultExt = ".pptx",
                Filter = "PowerPoint Presentation|*.pptx"
            };

            if (openFileDialog.ShowDialog(this) == true)
                this.LoadPresentation(openFileDialog.FileName);
        }

        private void SaveClicked(object sender, RoutedEventArgs e)
        {
            var saveFileDialog = new SaveFileDialog()
            {
                Filter = "PowerPoint Presentation|*.pptx|Adobe Portable Document Format|*.pdf|XML Paper Specification|*.xps|Image|*.png"
            };

            if (saveFileDialog.ShowDialog(this) == true)
                try
                {
                    this.presentation.Save(saveFileDialog.FileName);
                    Process.Start(saveFileDialog.FileName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(this, ex.ToString(), "Exception " + ex.GetType() + " occurred while saving a presentation!", MessageBoxButton.OK, MessageBoxImage.Error);
                    Process.Start("http://support.gemboxsoftware.com/new-ticket");
                }
        }

        private void AppendClicked(object sender, RoutedEventArgs e)
        {
            if (this.presentation != null)
            {
                // Add a new empty slide.
                var slide = this.presentation.Slides.AddNew(SlideLayoutType.Custom);

                if (!string.IsNullOrEmpty(this.slideTextBox.Text))
                {
                    // Add a text box of size 5 x 5 cm in the top-left corner of the slide.
                    var textBox = slide.Content.AddTextBox(0, 0, 5, 5, LengthUnit.Centimeter);

                    // Add a paragraph with text content to the text box.
                    textBox.AddParagraph().AddRun(this.slideTextBox.Text);
                }

                this.UpdatePresentationViewer();
            }
        }

        private void Navigate(object sender, RequestNavigateEventArgs e)
        {
            Process.Start(e.Uri.ToString());
        }
    }
}
