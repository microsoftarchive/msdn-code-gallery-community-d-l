using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using JumpListHelpers;

namespace JumpListManagerExample
{
    public partial class MainForm : JumpListMainFormBase
    {
        public MainForm()
        {
            InitializeComponent();

            this.JumpListCommandReceived += new EventHandler<CommandEventArgs>(MainForm_JumpListCommandReceived);
        }

        private void MainForm_JumpListCommandReceived(object sender, CommandEventArgs e)
        {
            lstCommands.Items.Add(e.CommandName);
            lstCommands.SelectedIndex = lstCommands.Items.Count - 1;           
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            JumpListManager.AddCategorySelfLink("Commands", "First command", "Command1");
            JumpListManager.AddCategorySelfLink("Commands", "Second command", "Command2");
            JumpListManager.AddCategorySelfLink("Commands", "Third command", "Command3");

            JumpListManager.AddCategoryLink("Links", "Around and About .NET World", "http://blogs.ugidotnet.org/marcom", "shell32.dll", 220);

            JumpListManager.AddTaskLink("Start Notepad", "notepad.exe", "notepad.exe");
            JumpListManager.AddTaskLink("Start Calculator", "calc.exe", "calc.exe");
            JumpListManager.AddTaskLink("Start Paint", "mspaint.exe", "mspaint.exe");

            JumpListManager.Refresh();
        }
    }
}
