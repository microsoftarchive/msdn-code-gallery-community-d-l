/****************** Copyright Notice *****************
 
This code is licensed under Microsoft Public License (Ms-PL). 
You are free to use, modify and distribute any portion of this code. 
The only requirement to do that, you need to keep the developer name, as provided below to recognize and encourage original work:

=======================================================
   
Architecture Designed and Implemented By:
Mohammad Ashraful Alam
Microsoft Most Valuable Professional, ASP.NET 2007 – 2011
Twitter: http://twitter.com/AshrafulAlam | Blog: http://blog.ashraful.net | Portfolio: http://www.ashraful.net
   
*******************************************************/
namespace Eisk.Helpers
{
    public enum MessageType { Success, Error, Notice }

    public class MessageFormatter
    {
        public static string GetFormattedSuccessMessage(string message)
        {
            return GetFormattedMessage(message, MessageType.Success);
        }

        public static string GetFormattedErrorMessage(string message)
        {
            return GetFormattedMessage(message, MessageType.Error);
        }

        public static string GetFormattedNoticeMessage(string message)
        {
            return GetFormattedMessage(message, MessageType.Notice);
        }

        public static string GetFormattedMessage(string message, MessageType messageType = MessageType.Notice)
        {
            switch (messageType)
            {
                case MessageType.Success: return "<div class='success'>" + message + "</div>";
                case MessageType.Error: return "<div class='error'>" + message + "</div>";
                default: return "<div class='notice'>" + message + "</div>";
            }
        }
        
    }
}