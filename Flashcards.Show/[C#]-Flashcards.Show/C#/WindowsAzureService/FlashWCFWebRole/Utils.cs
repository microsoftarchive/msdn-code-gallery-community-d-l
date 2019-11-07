using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Reflection;
using System.IO;
using System.Linq.Expressions;

namespace FlashCards.ViewModel
{
    public static class Utils
    {
        [Conditional("DEBUG")]
        public static void LogException(MethodBase methodBase, Exception e)
        {
            Debug.WriteLine(string.Format("Exception while {0}. Exception = {1}", methodBase.Name, e.ToString()));
        }

        /// <summary>
        ///   Copies data from a source stream to a target stream. this method is used during both packaging and unpackaging.
        /// </summary>
        /// <param name="source">The source stream to copy from.</param>
        /// <param name="target">The destination stream to copy to.</param>
        public static void CopyStream(Stream source, Stream target)
        {
            try
            {
                const int bufSize = 0x1000;
                byte[] buf = new byte[bufSize];
                int bytesRead = 0;
                while ((bytesRead = source.Read(buf, 0, bufSize)) > 0)
                {
                    target.Write(buf, 0, bytesRead);
                }
            }
            catch (Exception e)
            {
                Utils.LogException(MethodBase.GetCurrentMethod(), e);
            }
        }

#if !WINDOWS_PHONE
        public static string Encode(string str)
        {
            byte[] encbuff = System.Text.Encoding.UTF8.GetBytes(str);
            str = Convert.ToBase64String(encbuff);
            str = str.Replace('+', '-');
            str = str.Replace('/', '_');
            str = str.TrimEnd('=');
            return str;
        }

        public static string Decode(string str)
        {
            int paddedSize = Convert.ToInt32(Math.Ceiling((double)str.Length / 4d) * 4);
            str = str.PadRight(paddedSize,'=');
            str = str.Replace('_', '/');
            str = str.Replace('-', '+');
            byte[] decbuff = Convert.FromBase64String(str);
            return System.Text.Encoding.UTF8.GetString(decbuff, 0, decbuff.Length);
        }
#endif

#if !SILVERLIGHT

        /// <summary>
        /// Open mail client
        /// </summary>
        /// <param name="to">To.</param>
        /// <param name="cc">CC.</param>
        /// <param name="bcc">BCC.</param>
        /// <param name="subject">subject.</param>
        /// <param name="body">body.</param>
        public static void SendMail(string to, string cc, string bcc, string subject, string body)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("mailto:?to=");

            if (!string.IsNullOrEmpty(to))
            {
                stringBuilder.Append(Uri.EscapeUriString(to));
            }

            if (!string.IsNullOrEmpty(cc))
            {
                stringBuilder.Append("&CC=" + Uri.EscapeUriString(cc));
            }
            
            if (!string.IsNullOrEmpty(bcc))
            {
                stringBuilder.Append("&BCC=" + Uri.EscapeUriString(bcc));
            }

            if (!string.IsNullOrEmpty(subject))
            {
                stringBuilder.Append("&subject=" + Uri.EscapeUriString(subject));
            }

            if (!string.IsNullOrEmpty(body))
            {
                stringBuilder.Append("&body=" + Uri.EscapeUriString(body));
            }

            Process mailClientProcess = new Process();

            mailClientProcess.StartInfo.FileName = stringBuilder.ToString();
            mailClientProcess.StartInfo.UseShellExecute = true;
            mailClientProcess.StartInfo.RedirectStandardOutput = false;
            
            mailClientProcess.Start();
        }
#endif
    }

    public static class @string
    {
        private static string GetMemberName(Expression expression)
        {
            switch (expression.NodeType)
            {
                case ExpressionType.MemberAccess:
                    var memberExpression = (MemberExpression)expression;
                    var supername = GetMemberName(memberExpression.Expression);

                    if (String.IsNullOrEmpty(supername))
                        return memberExpression.Member.Name;

                    return String.Concat(supername, '.', memberExpression.Member.Name);

                case ExpressionType.Call:
                    var callExpression = (MethodCallExpression)expression;
                    return callExpression.Method.Name;

                case ExpressionType.Convert:
                    var unaryExpression = (UnaryExpression)expression;
                    return GetMemberName(unaryExpression.Operand);

                case ExpressionType.Constant:
                case ExpressionType.Parameter:
                    return String.Empty;

                default:
                    throw new ArgumentException("The expression is not a member access or method call expression");
            }
        }

        /// <summary>
        /// Get a string containing the identifier nameOfs the specified expression.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="expression">The expression.</param>
        /// <returns></returns>
        public static string of<T>(Expression<Func<T>> expression)
        {
            return GetMemberName(expression.Body);
        }

        public static string of(Expression<Action> expression)
        {
            return GetMemberName(expression.Body);
        }

        public static string of<T>()
        {
            return typeof(T).Name;
        }
    }
}
