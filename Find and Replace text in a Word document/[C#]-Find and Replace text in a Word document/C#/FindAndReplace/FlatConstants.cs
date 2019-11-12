using System.Xml.Linq;

namespace FindAndReplace
{
    internal static class FlatConstants
    {
        public const string
            DocumentContentType = "application/vnd.openxmlformats-officedocument.wordprocessingml.document.main+xml",
            HeaderContentType = "application/vnd.openxmlformats-officedocument.wordprocessingml.header+xml",
            FooterContentType = "application/vnd.openxmlformats-officedocument.wordprocessingml.footer+xml",
            FootnotesContentType = "application/vnd.openxmlformats-officedocument.wordprocessingml.footnotes+xml",
            EndnotesContentType = "application/vnd.openxmlformats-officedocument.wordprocessingml.endnotes+xml",
            CommentsContentType = "application/vnd.openxmlformats-officedocument.wordprocessingml.comments+xml";

        private static readonly XNamespace MainNamespace = "http://schemas.openxmlformats.org/wordprocessingml/2006/main";

        public static readonly XName
            RunElementName = MainNamespace + "r",
            RunPropertiesElementName = MainNamespace + "rPr",
            TextElementName = MainNamespace + "t",
            TextSpaceAttributeName = XNamespace.Xml + "space";
    }
}
