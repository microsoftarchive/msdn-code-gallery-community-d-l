using System;
using System.IO;
using SautinSoft.Document;

namespace Sample
{
    class Sample
    {
        static void Main(string[] args)
        {
            CreateRtf();            
        }
        /// <summary>
        /// Creates a simple RTF document.
        /// </summary>
        public static void CreateRtf()
        {
            // Working directory
            string workingDir = Path.GetFullPath(Directory.GetCurrentDirectory() + @"..\..\..\..\..\..\Testing Files");
            string rtfFilePath = Path.Combine(workingDir, "Result.rtf");

            // Let's create a simple RTF document.
            DocumentCore rtf = new DocumentCore();
            //DocumentCore.Serial = "put your serial here";

            // Add new section.
            Section section = new Section(rtf);
            rtf.Sections.Add(section);

            // Let's set page size A4.
            section.PageSetup.PaperType = PaperType.A4;

            // Add two paragraphs using different ways:

            // Way 1: Add 1st paragraph.
            section.Blocks.Add(new Paragraph(rtf, "This is a first line in 1st paragraph!"));
            Paragraph par1 = section.Blocks[0] as Paragraph;
            par1.ParagraphFormat.Alignment = HorizontalAlignment.Center;

            // Let's add a second line.
            par1.Inlines.Add(new SpecialCharacter(rtf, SpecialCharacterType.LineBreak));
            par1.Inlines.Add(new Run(rtf, "Let's type a second line."));

            // Let's change font name, size and color.
            CharacterFormat cf = new CharacterFormat() { FontName = "Verdana", Size = 16, FontColor = Color.Orange };
            foreach (Inline inline in par1.Inlines)
                if (inline is Run)
                    (inline as Run).CharacterFormat = cf.Clone();

            // Way 2 (easy): Add 2nd paragarph using another way.
            rtf.Content.End.Insert("\nThis is a first line in 2nd paragraph.", new CharacterFormat() { Size = 25, FontColor = Color.Blue, Bold = true });
            SpecialCharacter lBr = new SpecialCharacter(rtf, SpecialCharacterType.LineBreak);
            rtf.Content.End.Insert(lBr.Content);
            rtf.Content.End.Insert("This is a second line.", new CharacterFormat() { Size = 20, FontColor = Color.DarkGreen, UnderlineStyle = UnderlineType.Single });

            // Save RTF to a file
            rtf.Save(rtfFilePath, SaveOptions.RtfDefault);

            // Open the result for demonstation purposes.
            System.Diagnostics.Process.Start(rtfFilePath);
        }

    }
}
