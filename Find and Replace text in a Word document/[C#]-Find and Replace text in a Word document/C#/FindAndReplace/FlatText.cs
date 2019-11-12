using System;
using System.Xml.Linq;

namespace FindAndReplace
{
    /// <summary>
    /// Represents document's single text (single text element).
    /// </summary>
    internal sealed class FlatText
    {
        private readonly XElement textElement;

        public int StartIndex { get; private set; }
        public int EndIndex { get; private set; }

        public FlatText(XElement textElement) { this.textElement = textElement; }
        
        public string Text
        {
            get { return this.textElement.Value; }
            set
            {
                this.textElement.Value = value;

                // If needed set preserve space on Text element.
                if (value.StartsWith(" ") || value.EndsWith(" "))
                {
                    XAttribute space = this.textElement.Attribute(FlatConstants.TextSpaceAttributeName);
                    if (space == null)
                        this.textElement.Add(new XAttribute(FlatConstants.TextSpaceAttributeName, "preserve"));
                    else if (space.Value != "preserve")
                        space.Value = "preserve";
                }
            }
        }

        public void SetIndexes(int startIndex)
        {
            this.StartIndex = startIndex;
            this.EndIndex = startIndex + this.Text.Length - 1;
        }

        public void Remove() { this.textElement.Parent.Remove(); }
    }
}
