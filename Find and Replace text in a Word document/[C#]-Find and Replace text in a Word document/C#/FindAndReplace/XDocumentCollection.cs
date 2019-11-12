using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.IO.Packaging;
using System.Linq;
using System.Xml.Linq;

namespace FindAndReplace
{
    /// <summary>
    /// Represents a collection of Word document parts (body, headers, footers, comments, etc.).
    /// </summary>
    internal sealed class XDocumentCollection : IEnumerable<XDocument>, IDisposable
    {
        private readonly Package package;
        private readonly List<KeyValuePair<PackagePart, XDocument>> packageDocuments;

        private XDocumentCollection(Package package)
        {
            this.package = package;
            this.packageDocuments = new List<KeyValuePair<PackagePart, XDocument>>();
        }

        private void LoadDocuments()
        {
            foreach (PackagePart packagePart in this.package.GetParts().Where(p => IsSupportedPart(p.ContentType)))
                using (Stream stream = packagePart.GetStream(FileMode.Open, FileAccess.Read))
                    this.packageDocuments.Add(new KeyValuePair<PackagePart, XDocument>(packagePart, XDocument.Load(stream)));
        }

        private void SaveDocuments()
        {
            foreach (KeyValuePair<PackagePart, XDocument> packageDocument in this.packageDocuments)
                using (Stream stream = packageDocument.Key.GetStream(FileMode.Create, FileAccess.Write))
                    packageDocument.Value.Save(stream);
        }

        public IEnumerator<XDocument> GetEnumerator() { return this.packageDocuments.Select(pd => pd.Value).GetEnumerator(); }

        IEnumerator IEnumerable.GetEnumerator() { return this.GetEnumerator(); }

        public void Dispose()
        {
            this.SaveDocuments();
            this.package.Close();
        }

        public static XDocumentCollection Open(Stream stream)
        {
            var documents = new XDocumentCollection(Package.Open(stream, FileMode.Open, FileAccess.ReadWrite));
            documents.LoadDocuments();
            return documents;
        }

        private static bool IsSupportedPart(string contentType)
        {
            return contentType == FlatConstants.DocumentContentType ||
                   contentType == FlatConstants.HeaderContentType ||
                   contentType == FlatConstants.FooterContentType ||
                   contentType == FlatConstants.FootnotesContentType ||
                   contentType == FlatConstants.EndnotesContentType ||
                   contentType == FlatConstants.CommentsContentType;
        }
    }
}
