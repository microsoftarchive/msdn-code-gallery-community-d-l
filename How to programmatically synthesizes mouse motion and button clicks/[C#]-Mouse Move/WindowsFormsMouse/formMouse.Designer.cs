namespace WindowsFormsMouse
{
    partial class formMouse
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
            this.lblNote = new System.Windows.Forms.Label();
            this.lblNote2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblAuto = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblNote
            // 
            this.lblNote.AutoSize = true;
            this.lblNote.Location = new System.Drawing.Point(33, 50);
            this.lblNote.Name = "lblNote";
            this.lblNote.Size = new System.Drawing.Size(129, 13);
            this.lblNote.TabIndex = 0;
            this.lblNote.Text = "Use - Lef,Right,Up,Down ";
            // 
            // lblNote2
            // 
            this.lblNote2.AutoSize = true;
            this.lblNote2.Location = new System.Drawing.Point(33, 81);
            this.lblNote2.Name = "lblNote2";
            this.lblNote2.Size = new System.Drawing.Size(122, 13);
            this.lblNote2.TabIndex = 1;
            this.lblNote2.Text = "Use - \"L\"eft mouse click";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 94);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(129, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Use - \"R\"ight mouse click";
            // 
            // lblAuto
            // 
            this.lblAuto.AutoSize = true;
            this.lblAuto.Location = new System.Drawing.Point(33, 122);
            this.lblAuto.Name = "lblAuto";
            this.lblAuto.Size = new System.Drawing.Size(170, 13);
            this.lblAuto.TabIndex = 2;
            this.lblAuto.Text = "Use - \"A\"uto mouse move +/- 3 px";
            // 
            // formMouse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(224, 208);
            this.Controls.Add(this.lblAuto);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblNote2);
            this.Controls.Add(this.lblNote);
            this.Name = "formMouse";
            this.Text = "MOUSE";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.formMouse_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblNote;
        private System.Windows.Forms.Label lblNote2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblAuto;
    }
}

