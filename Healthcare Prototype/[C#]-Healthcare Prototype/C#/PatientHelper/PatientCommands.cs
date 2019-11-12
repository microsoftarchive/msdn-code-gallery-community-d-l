using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace IdentityMine.Avalon.Controls
{
    public class PatientCommands
    {
        public class WindowCommand : ICommand
        {
            public WindowCommand(int appCommandId)
            {
                _appCommandId = appCommandId;
            }

            public bool IsEnabled { get { return true; } }

            public void Execute(object o)
            {
                string param = o as string;

                if ((param != null) && (param == "DiagnosticsWindow"))
                {
                    DocumentWindow documentViewWindow = new DocumentWindow();
                    documentViewWindow.Show();
                }

            }

            public bool CanExecute(object o)
            {
                return true;
            }

            public event EventHandler CanExecuteChanged;

            private int _appCommandId;
        }

        public class VideoAnnotationWindowCommand : ICommand
        {
            public VideoAnnotationWindowCommand(int appCommandId)
            {
                _appCommandId = appCommandId;
            }

            public bool IsEnabled { get { return true; } }

            public void Execute(object o)
            {
                string param = o as string;

                if ((param != null) && (param == "XRay"))
                {
                    VideoAnnotationWindow videoAnnotationWindow = new VideoAnnotationWindow();
                    videoAnnotationWindow.Show();
                }

            }

            public bool CanExecute(object o)
            {
                return true;
            }

            public event EventHandler CanExecuteChanged;

            private int _appCommandId;
        }
        #region Public Methods

        public static WindowCommand LaunchDocumentWindow
        {
            get { return new WindowCommand(0); }
        }

        public static VideoAnnotationWindowCommand LaunchVideoAnnotationWindow
        {
            get { return new VideoAnnotationWindowCommand(0); }
        }
        #endregion

        #region Globals

        #endregion
    }
}
