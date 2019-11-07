
// So as we need to use WIN32 API just build this application as WIN FORM (not WPF)

using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Threading;

namespace WindowsFormsMouse
{
    public partial class formMouse : Form
    {
        public formMouse()
        {
            InitializeComponent();
        }


        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint dwData, UIntPtr dwExtraInfo);

        const uint MOUSEEVENTF_ABSOLUTE = 0x8000;
        const uint MOUSEEVENTF_LEFTDOWN = 0x0002;
        const uint MOUSEEVENTF_LEFTUP = 0x0004;
        const uint MOUSEEVENTF_MIDDLEDOWN = 0x0020;
        const uint MOUSEEVENTF_MIDDLEUP = 0x0040;
        const uint MOUSEEVENTF_MOVE = 0x0001;
        const uint MOUSEEVENTF_RIGHTDOWN = 0x0008;
        const uint MOUSEEVENTF_RIGHTUP = 0x0010;
        const uint MOUSEEVENTF_XDOWN = 0x0080;
        const uint MOUSEEVENTF_XUP = 0x0100;
        const uint MOUSEEVENTF_WHEEL = 0x0800;
        const uint MOUSEEVENTF_HWHEEL = 0x01000;

        //http://www.pinvoke.net/default.aspx/user32.mouse_event
        //https://msdn.microsoft.com/en-us/library/windows/desktop/ms646260(v=vs.85).aspx

        private void MoveCursor(string Direction)
        {
            // Set the Current cursor, move the cursor's Position,
 
            // mouse_event moves in a coordinate system where
            // (0, 0) is in the upper left corner and
            // (65535,65535) is in the lower right corner.

            // Get the current mouse coordinates and convert
            // them into this new system.
            
            int X = 0; // Cursor.Position.X;
            int Y = 0; // Cursor.Position.Y;
           
            uint action = 0;

            if (Direction == "Up")      { action =  MOUSEEVENTF_MOVE ; Y = -3;  X = 0; }
            else if (Direction == "Down") { action =  MOUSEEVENTF_MOVE ; Y =  3;  X = 0; }
            else if (Direction == "Left") { action =  MOUSEEVENTF_MOVE ; Y = 0 ;  X = -3; }
            else if (Direction == "Right") { action =  MOUSEEVENTF_MOVE ; Y = 0 ;  X =  3; }

            else if (Direction == "L") 
            {
                mouse_event(MOUSEEVENTF_LEFTDOWN, 0u, 0u, 0u, (UIntPtr)0);
                Thread.Sleep(100);
                mouse_event(MOUSEEVENTF_LEFTUP, 0u, 0u, 0u, (UIntPtr)0);
                return;
            }
            else if (Direction == "R")
            {
                mouse_event(MOUSEEVENTF_RIGHTDOWN, 0u, 0u, 0u, (UIntPtr)0);
                Thread.Sleep(100);
                mouse_event(MOUSEEVENTF_RIGHTUP, 0u, 0u, 0u, (UIntPtr)0);
                return;
            }
           
            else return;

            // mouse_event(MOUSEEVENTF_ABSOLUTE + MOUSEEVENTF_MOVE + MOUSEEVENTF_LEFTDOWN + MOUSEEVENTF_LEFTUP .... 
            mouse_event(action, (uint)X, (uint)Y, (uint)0, (UIntPtr)0);

        }

        // Below just for example : how to manage "Mouse' by Key  ...

        private string strAuto = "";

        private async void AutoMoveCursor() {
            // Set the Current cursor, move the cursor's Position,

            int X = 0; // Cursor.Position.X;
            int Y = 0; // Cursor.Position.Y;

            uint action = 0;

            action = MOUSEEVENTF_MOVE;
            Y = -3;
            X = 0; 

            while (strAuto == "A") {

                Y = Y * -1;
                lblAuto.BackColor = Color.Red;
                // mouse_event(MOUSEEVENTF_ABSOLUTE + MOUSEEVENTF_MOVE + MOUSEEVENTF_LEFTDOWN + MOUSEEVENTF_LEFTUP .... 
                mouse_event(action, ( uint ) X, ( uint ) Y, ( uint ) 0, ( UIntPtr ) 0);

                await Task.Delay(1000 * 60 * 5); // Each 5 min move cursor

            }

            lblAuto.BackColor = Color.Transparent;

        }


        private void formMouse_KeyDown(object sender, KeyEventArgs e)
        {
            strAuto = e.KeyCode.ToString();
            switch (e.KeyCode)
            {
                case Keys.A:
                    AutoMoveCursor();
                    break;
                case Keys.Down:
                    MoveCursor("Down");
                    break;
                case Keys.Up:
                    MoveCursor("Up");
                    break;
                case Keys.Left:
                    MoveCursor("Left");
                    break;
                case Keys.Right:
                    MoveCursor("Right");
                    break;
                case Keys.L:
                    MoveCursor("L");
                    break;
                case Keys.R:
                    MoveCursor("R");
                    break;
            }
        }


    }
}
