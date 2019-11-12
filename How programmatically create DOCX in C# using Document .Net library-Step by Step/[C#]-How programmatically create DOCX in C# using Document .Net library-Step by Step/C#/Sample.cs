using System;
using System.IO;
using SautinSoft.Document;

namespace Sample
{
    class Sample
    {
        static void Main(string[] args)
        {
            CreateDocx();            
        }
        /// <summary>
        /// Creates a simple Docx document.
        /// </summary>
        public static void CreateDocx()
        {
            // Set a path to our docx file.
            string docxPath = @"..\..\..\..\..\Testing Files\Result.docx";

            // Let's create a simple DOCX document.
            DocumentCore docx = new DocumentCore();
            //DocumentCore.Serial = "put your serial here";

            // Add new section.
            Section section = new Section(docx);
            docx.Sections.Add(section);

            // Let's set page size A4.
            section.PageSetup.PaperType = PaperType.A4;

            // Add two paragraphs using different ways:

            // Way 1: Add 1st paragraph.
            section.Blocks.Add(new Paragraph(docx, "This is a first line in 1st paragraph!"));
            Paragraph par1 = section.Blocks[0] as Paragraph;
            par1.ParagraphFormat.Alignment = HorizontalAlignment.Center;

            // Let's add a second line.
            par1.Inlines.Add(new SpecialCharacter(docx, SpecialCharacterType.LineBreak));
            par1.Inlines.Add(new Run(docx, "Let's type a second line."));

            // Let's change font name, size and color.
            CharacterFormat cf = new CharacterFormat() { FontName = "Verdana", Size = 16, FontColor = Color.Orange };
            foreach (Inline inline in par1.Inlines)
                if (inline is Run)
                    (inline as Run).CharacterFormat = cf.Clone();

            // Way 2 (easy): Add 2nd paragarph using another way.
            docx.Content.End.Insert("\nThis is a first line in 2nd paragraph.", new CharacterFormat() { Size = 25, FontColor = Color.Blue, Bold = true });
            SpecialCharacter lBr = new SpecialCharacter(docx, SpecialCharacterType.LineBreak);
            docx.Content.End.Insert(lBr.Content);
            docx.Content.End.Insert("This is a second line.", new CharacterFormat() { Size = 20, FontColor = Color.DarkGreen, UnderlineStyle = UnderlineType.Single });

            // Save DOCX to a file
            docx.Save(docxPath);

            // Open the result for demonstation purposes.
            System.Diagnostics.Process.Start(docxPath);
        }

    }
}
