using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace FindAndReplace
{
    /// <summary>
    /// Represents document's single text area (like single paragraph element's text, single hyperlink element's text, etc.).
    /// </summary>
    internal sealed class FlatTextRange
    {
        private readonly StringBuilder rangeText;
        private readonly LinkedList<FlatText> range;

        public XElement Parent { get; private set; }

        public FlatTextRange(XElement parent)
        {
            this.Parent = parent;
            this.rangeText = new StringBuilder();
            this.range = new LinkedList<FlatText>();
        }

        public void AddFlatText(FlatText flatText)
        {
            this.range.AddLast(flatText);
            this.AddRangeText(flatText);
        }

        private void AddRangeText(FlatText flatText)
        {
            flatText.SetIndexes(this.rangeText.Length);
            this.rangeText.Append(flatText.Text);
        }

        public void FindAndReplace(string find, string replace, StringComparison comparisonType)
        {
            int searchStartIndex = -1, searchEndIndex = -1, searchPosition = 0;

            while ((searchStartIndex = this.rangeText.ToString().IndexOf(find, searchPosition, comparisonType)) != -1)
            {
                searchEndIndex = searchStartIndex + find.Length - 1;

                // Find FlatText that contains the beginning of the searched text.
                LinkedListNode<FlatText> node = this.FindNode(searchStartIndex);
                FlatText flatText = node.Value;

                ReplaceText(flatText, searchStartIndex, searchEndIndex, replace);
                
                // Remove next FlatTexts that contain parts of the searched text.
                this.RemoveNodes(node, searchEndIndex);

                this.ResetRangeText();
                searchPosition = searchStartIndex + replace.Length;
            }
        }

        private LinkedListNode<FlatText> FindNode(int searchStartIndex)
        {
            for (LinkedListNode<FlatText> node = this.range.First; node != null; node = node.Next)
                if (node.Value.StartIndex <= searchStartIndex && node.Value.EndIndex >= searchStartIndex)
                    return node;

            // This should never happen!
            throw new InvalidOperationException();
        }

        private static void ReplaceText(FlatText flatText, int searchStartIndex, int searchEndIndex, string replace)
        {
            string text = string.Empty;

            if (flatText.StartIndex < searchStartIndex)
                // Leave text that is before the searched text.
                text = flatText.Text.Remove(searchStartIndex - flatText.StartIndex);

            text += replace;

            if (flatText.EndIndex > searchEndIndex)
                // Leave text that is after the searched text.
                text += flatText.Text.Substring(searchEndIndex - flatText.StartIndex + 1);

            flatText.Text = text;
        }

        private void RemoveNodes(LinkedListNode<FlatText> replacedNode, int searchEndIndex)
        {
            LinkedListNode<FlatText> node;
            FlatText flatText;

            while ((node = replacedNode.Next) != null &&
                   (flatText = node.Value).StartIndex <= searchEndIndex)
            {
                if (flatText.EndIndex <= searchEndIndex)
                    this.RemoveNode(node);
                else
                {
                    // Leave text that is after the searched text.
                    flatText.Text = flatText.Text.Substring(searchEndIndex - flatText.StartIndex + 1);
                    break;
                }
            }
        }
        
        private void RemoveNode(LinkedListNode<FlatText> node)
        {
            node.Value.Remove();
            this.range.Remove(node);
        }

        private void ResetRangeText()
        {
            this.rangeText.Clear();
            foreach (FlatText flatText in this.range)
                this.AddRangeText(flatText);
        }
    }
}
