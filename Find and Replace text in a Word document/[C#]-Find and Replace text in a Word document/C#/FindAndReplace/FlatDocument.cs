using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace FindAndReplace
{
    /// <summary>
    /// Represents a Word document with flatten, searchable, text content.
    /// </summary>
    public sealed class FlatDocument : IDisposable
    {
        private readonly XDocumentCollection documents;
        private readonly List<FlatTextRange> ranges;

        /// <summary>
        /// Initializes a new instance of the FlatDocument class.
        /// </summary>
        /// <param name="path">Word document's path.</param>
        public FlatDocument(string path) : this(File.Open(path, FileMode.Open, FileAccess.ReadWrite)) { }

        /// <summary>
        /// Initializes a new instance of the FlatDocument class.
        /// </summary>
        /// <param name="stream">Word document's stream.</param>
        public FlatDocument(Stream stream)
        {
            if (stream == null)
                throw new ArgumentNullException("stream");

            this.documents = XDocumentCollection.Open(stream);
            this.ranges = new List<FlatTextRange>();

            this.CreateFlatTextRanges();
        }

        private void CreateFlatTextRanges()
        {
            foreach (XDocument document in this.documents)
            {
                FlatTextRange currentRange = null;
                foreach (XElement run in document.Descendants(FlatConstants.RunElementName))
                {
                    if (!run.HasElements)
                        continue;

                    FlatText flatText = FlattenRunElement(run);
                    if (flatText == null)
                        continue;

                    // If current Run doesn't belong to same parent (like paragraph, hyperlink, etc.)
                    // create new FlatTextRange, otherwise use current one.
                    if (currentRange == null || currentRange.Parent != run.Parent)
                        currentRange = this.CreateFlatTextRange(run.Parent);
                    currentRange.AddFlatText(flatText);
                }
            }
        }

        private FlatTextRange CreateFlatTextRange(XElement parent)
        {
            var range = new FlatTextRange(parent);
            this.ranges.Add(range);
            return range;
        }

        private static FlatText FlattenRunElement(XElement run)
        {
            XElement[] childs = run.Elements().ToArray();
            XElement runProperties = childs[0].Name == FlatConstants.RunPropertiesElementName ? childs[0] : null;

            int childCount = childs.Length;
            int flatChildCount = 1 + (runProperties != null ? 1 : 0);

            // Break current Run into multiple Run elements which have one child,
            // or two childs in case it has first RunProperties child.
            while (childCount > flatChildCount)
            {
                // Move last child element from current Run into new Run which is added after the current Run.
                XElement child = childs[childCount - 1];
                run.AddAfterSelf(
                    new XElement(FlatConstants.RunElementName,
                        runProperties != null ? new XElement(runProperties) : null,
                        new XElement(child)));

                child.Remove();
                --childCount;
            }

            XElement remainingChild = childs[childCount - 1];
            return remainingChild.Name == FlatConstants.TextElementName ? new FlatText(remainingChild) : null;
        }
        
        /// <summary>
        /// Replaces all occurrences of a specified text in the current document with another specified text.
        /// </summary>
        /// <param name="find">Text for finding.</param>
        /// <param name="replace">Text for replacing.</param>
        public void FindAndReplace(string find, string replace) { this.FindAndReplace(find, replace, StringComparison.CurrentCulture); }

        /// <summary>
        /// Replaces all occurrences of a specified text in the current document with another specified text.
        /// </summary>
        /// <param name="find">Text for finding.</param>
        /// <param name="replace">Text for replacing.</param>
        /// <param name="comparisonType">Rule for string comparison.</param>
        public void FindAndReplace(string find, string replace, StringComparison comparisonType)
        {
            if (string.IsNullOrEmpty(find))
                throw new ArgumentNullException("find");
            if (string.IsNullOrEmpty(replace))
                throw new ArgumentNullException("replace");

            this.ranges.ForEach(range => range.FindAndReplace(find, replace, comparisonType));
        }

        /// <summary>
        /// Saves and closes the Word document.
        /// </summary>
        public void Dispose() { this.documents.Dispose(); }
    }
}
