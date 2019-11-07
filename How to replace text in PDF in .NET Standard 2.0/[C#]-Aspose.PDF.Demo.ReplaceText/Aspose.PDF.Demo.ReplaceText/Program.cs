using Aspose.Pdf.Text;
using System;
using System.Collections.Generic;

namespace Aspose.PDF.Demo.ReplaceText
{
    struct StringPair
    {
        public StringPair(string oldVal, string newVal)
        {
            oldValue = oldVal;
            newValue = newVal;
        }
        public string oldValue;
        public string newValue;
    }

    class Program
    {
        private const string DateFormat = "MMM dd, yyyy";

        static void Main()
        {            
            ReplaceTextExampleSimple();
            ReplaceTextExampleWithFontSettings();
        }

        private static void ReplaceTextExampleWithFontSettings()
        {
            var eventDate = new DateTime(2018, 6, 1);
            var listOfreplacements = new List<StringPair>
            {
                new StringPair("<FirstName>","Sherlock"),
                new StringPair("<LastName>" ,"Holmes" ),
                new StringPair("<ShortDate>", eventDate.ToString(DateFormat)),
                new StringPair("<ShortTime>", "6:00PM"),
                new StringPair("<ImportantDate1>", eventDate.AddDays(-1).ToString(DateFormat)),
                new StringPair("<ImportantDate3>", eventDate.AddDays(1).ToString(DateFormat)),
                new StringPair("<ImportantDate4>", eventDate.AddDays(7).ToString(DateFormat))
        };
            var pdfDocument = new Aspose.Pdf.Document(@".\Data\invitation.pdf");
            var pdfContentEditor = new Aspose.Pdf.Facades.PdfContentEditor();
            pdfContentEditor.BindPdf(pdfDocument);
            pdfContentEditor.TextReplaceOptions.ReplaceScope = TextReplaceOptions.Scope.REPLACE_FIRST;

            foreach (var replacement in listOfreplacements)
            {
                pdfContentEditor.ReplaceText(replacement.oldValue, replacement.newValue,
                    new TextState(foregroundColor: System.Drawing.Color.Red, fontSize: 14.0));
            }

            pdfContentEditor.ReplaceText("<ImportantDate2>", eventDate.ToString("MMMM dd, yyyy"));
            pdfContentEditor.ReplaceText("<ImportantDate2>", eventDate.ToString("MMMM dd, yyyy"),
                new TextState(foregroundColor: System.Drawing.Color.Red, fontSize: 14.0));

            pdfContentEditor.TextReplaceOptions.ReplaceScope = TextReplaceOptions.Scope.REPLACE_ALL;
            pdfContentEditor.ReplaceText("<ProgramTitle>", "Violin Contest");

            pdfContentEditor.Save(@".\Data\invitation-1.pdf");

        }

        private static void ReplaceTextExampleSimple()
        {
            var eventDate = new DateTime(2018, 6, 1);
            var listOfreplacements = new List<StringPair>
            {
                new StringPair("<FirstName>","Sherlock"),
                new StringPair("<LastName>" ,"Holmes" ),
                new StringPair("<ShortDate>", eventDate.ToString("MMM dd, yyyy")),
                new StringPair("<ShortTime>", "6:00PM"),
                new StringPair("<ImportantDate1>", eventDate.AddDays(-1).ToString("MMM dd, yyyy")),
                new StringPair("<ImportantDate3>", eventDate.AddDays(1).ToString("MMM dd, yyyy")),
                new StringPair("<ImportantDate4>", eventDate.AddDays(7).ToString("MMM dd, yyyy"))

            };
            var pdfDocument = new Aspose.Pdf.Document(@".\Data\invitation.pdf");
            var pdfContentEditor = new Aspose.Pdf.Facades.PdfContentEditor();
            pdfContentEditor.BindPdf(pdfDocument);
            pdfContentEditor.TextReplaceOptions.ReplaceScope = TextReplaceOptions.Scope.REPLACE_FIRST;

            foreach (var replacement in listOfreplacements)
            {
                pdfContentEditor.ReplaceText(replacement.oldValue, replacement.newValue);
            }

            pdfContentEditor.TextReplaceOptions.ReplaceScope = TextReplaceOptions.Scope.REPLACE_ALL;
            pdfContentEditor.ReplaceText("<ProgramTitle>", "Violin Contest");
            pdfContentEditor.ReplaceText("<ImportantDate2>", eventDate.ToString("MMMM dd, yyyy"));

            pdfContentEditor.Save(@".\Data\invitation-0.pdf");
        }
    }
}
