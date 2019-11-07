using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using ComponentPro.Diagnostics;

namespace ClientSample
{
    public class RichTextBoxTraceListener : UltimateTextWriterTraceListener
    {
        private static readonly Color TextColorCommand = Color.White; // Text color for command texts.
        private static readonly Color TextColorError = Color.FromArgb(0xff, 0x50, 0x50); // Text color for error texts.
        internal static readonly Color TextColorInfo = Color.FromArgb(0x72, 0xff, 0x7c); // Text color for information texts.
        private static readonly Color TextColorResponse = Color.FromArgb(0xa0, 0xa0, 0xa0); // Text color for response texts.
        private static readonly Color TextColorSecure = Color.FromArgb(0x8b, 0xf5, 0xfc); // Text color for security information texts.
        private readonly RichTextBox _textbox;

        public RichTextBoxTraceListener(RichTextBox textbox)
        {
            _textbox = textbox;
        }

        public override void TraceData(TraceEventCache eventCache, string source, TraceEventType level, int id, params object[] data)
        {
            Color color = TextColorInfo;
            string category = (string)data[1];
            string message = (string)data[0];

            // If it's showing an error?
            if (level <= TraceEventType.Error)
            {
                color = TextColorError;
            }
            else
            {
                switch (category.ToUpper())
                {
                    case "COMMAND":
                        // command log.
                        color = TextColorCommand;
                        message = string.Format("[{0:HH:mm:ss.fff}] {1} - COMMAND>   {2}\r\n", DateTime.Now, level,
                                                message);
                        goto Invoke;

                    case "RESPONSE":
                        // response log.
                        color = TextColorResponse;
                        message = string.Format("[{0:HH:mm:ss.fff}] {1} -        <   {2}\r\n", DateTime.Now, level,
                                                message);
                        goto Invoke;

                    case "SECURESHELL":
                    case "SECURESOCKET":
                        color = TextColorSecure;
                        break;
                }
            }
            message = string.Format("[{0:HH:mm:ss.fff}] {1} - {2}: {3}\r\n", DateTime.Now, level, category, message);

            Invoke:
            _textbox.Invoke(new OnLogHandler(OnLog), new object[] {message, color});
        }

        private void OnLog(string message, Color color)
        {
            // Write log message to the text box.
            _textbox.SelectionColor = color;
            _textbox.SelectionStart = _textbox.Text.Length;
            _textbox.SelectedText = message;
            _textbox.ScrollToCaret();
        }

        #region Nested type: OnLogHandler

        private delegate void OnLogHandler(string message, Color color);

        #endregion
    }
}