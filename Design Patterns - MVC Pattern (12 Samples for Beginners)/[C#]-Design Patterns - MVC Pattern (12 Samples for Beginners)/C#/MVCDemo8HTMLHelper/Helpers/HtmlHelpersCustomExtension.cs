using System.Web.Mvc;

namespace MVCDemo8HTMLHelper.Helpers
{
    public static class HtmlHelpersCustomExtension
    {
        public static string PrefexHello(this HtmlHelper helper, string input)
        {
            return "Hello .. " + input;
        }
        public static string Truncate(this HtmlHelper helper, string input, int length)
        {
            if (input.Length <= length)
            {
                return input;
            }
            else
            {
                return input.Substring(0, length) + "...";
            }
        }        
    }
}
