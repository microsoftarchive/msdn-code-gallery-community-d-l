namespace ChromeSample
{
    partial class ChromeSample
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonDesktop = new System.Windows.Forms.Button();
            this.listBoxProcesses = new System.Windows.Forms.ListBox();
            this.buttonProcess = new System.Windows.Forms.Button();
            this.buttonGetProcesses = new System.Windows.Forms.Button();
            this.buttonHide = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonDesktop
            // 
            this.buttonDesktop.Location = new System.Drawing.Point(13, 13);
            this.buttonDesktop.Name = "buttonDesktop";
            this.buttonDesktop.Size = new System.Drawing.Size(120, 23);
            this.buttonDesktop.TabIndex = 0;
            this.buttonDesktop.Text = "Highlight Desktop";
            this.buttonDesktop.UseVisualStyleBackColor = true;
            this.buttonDesktop.Click += new System.EventHandler(this.buttonDesktop_Click);
            // 
            // listBoxProcesses
            // 
            this.listBoxProcesses.FormattingEnabled = true;
            this.listBoxProcesses.Location = new System.Drawing.Point(13, 80);
            this.listBoxProcesses.Name = "listBoxProcesses";
            this.listBoxProcesses.Size = new System.Drawing.Size(120, 95);
            this.listBoxProcesses.TabIndex = 1;
            // 
            // buttonProcess
            // 
            this.buttonProcess.Location = new System.Drawing.Point(13, 181);
            this.buttonProcess.Name = "buttonProcess";
            this.buttonProcess.Size = new System.Drawing.Size(120, 23);
            this.buttonProcess.TabIndex = 2;
            this.buttonProcess.Text = "Highlight Process";
            this.buttonProcess.UseVisualStyleBackColor = true;
            this.buttonProcess.Click += new System.EventHandler(this.buttonProcess_Click);
            // 
            // buttonGetProcesses
            // 
            this.buttonGetProcesses.Location = new System.Drawing.Point(13, 51);
            this.buttonGetProcesses.Name = "buttonGetProcesses";
            this.buttonGetProcesses.Size = new System.Drawing.Size(120, 23);
            this.buttonGetProcesses.TabIndex = 3;
            this.buttonGetProcesses.Text = "Get Processes";
            this.buttonGetProcesses.UseVisualStyleBackColor = true;
            this.buttonGetProcesses.Click += new System.EventHandler(this.buttonGetProcesses_Click);
            // 
            // buttonHide
            // 
            this.buttonHide.Location = new System.Drawing.Point(167, 13);
            this.buttonHide.Name = "buttonHide";
            this.buttonHide.Size = new System.Drawing.Size(75, 23);
            this.buttonHide.TabIndex = 4;
            this.buttonHide.Text = "Hide";
            this.buttonHide.UseVisualStyleBackColor = true;
            this.buttonHide.Click += new System.EventHandler(this.buttonHide_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 273);
            this.Controls.Add(this.buttonHide);
            this.Controls.Add(this.buttonGetProcesses);
            this.Controls.Add(this.buttonProcess);
            this.Controls.Add(this.listBoxProcesses);
            this.Controls.Add(this.buttonDesktop);
            this.Name = "Form1";
            this.Text = "ChromeSample";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonDesktop;
        private System.Windows.Forms.ListBox listBoxProcesses;
        private System.Windows.Forms.Button buttonProcess;
        private System.Windows.Forms.Button buttonGetProcesses;
        private System.Windows.Forms.Button buttonHide;
    }
}

