namespace SyncApplication
{
    partial class NewCEClientCreationWizard
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
            this.label1 = new System.Windows.Forms.Label();
            this.fullInitRadioBtn = new System.Windows.Forms.RadioButton();
            this.fastInitSnapshotBtn = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.browseFullInitBtn = new System.Windows.Forms.Button();
            this.fullInitDbLocation = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.snapshotSrcBrowse = new System.Windows.Forms.Button();
            this.snapshotSrcLocation = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.snapshotDestBrowse = new System.Windows.Forms.Button();
            this.snapshotDestLocation = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.okBtn = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "CE Creation Mode:";
            // 
            // fullInitRadioBtn
            // 
            this.fullInitRadioBtn.AutoSize = true;
            this.fullInitRadioBtn.Location = new System.Drawing.Point(131, 7);
            this.fullInitRadioBtn.Name = "fullInitRadioBtn";
            this.fullInitRadioBtn.Size = new System.Drawing.Size(58, 17);
            this.fullInitRadioBtn.TabIndex = 1;
            this.fullInitRadioBtn.TabStop = true;
            this.fullInitRadioBtn.Tag = "";
            this.fullInitRadioBtn.Text = "Full Init";
            this.fullInitRadioBtn.UseVisualStyleBackColor = true;
            this.fullInitRadioBtn.CheckedChanged += new System.EventHandler(this.fullInitRadioBtn_CheckedChanged);
            // 
            // fastInitSnapshotBtn
            // 
            this.fastInitSnapshotBtn.AutoSize = true;
            this.fastInitSnapshotBtn.Location = new System.Drawing.Point(205, 7);
            this.fastInitSnapshotBtn.Name = "fastInitSnapshotBtn";
            this.fastInitSnapshotBtn.Size = new System.Drawing.Size(127, 17);
            this.fastInitSnapshotBtn.TabIndex = 2;
            this.fastInitSnapshotBtn.TabStop = true;
            this.fastInitSnapshotBtn.Tag = "";
            this.fastInitSnapshotBtn.Text = "Snapshot Initialization";
            this.fastInitSnapshotBtn.UseVisualStyleBackColor = true;
            this.fastInitSnapshotBtn.CheckedChanged += new System.EventHandler(this.fastInitSnapshotBtn_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.browseFullInitBtn);
            this.groupBox1.Controls.Add(this.fullInitDbLocation);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(2, 30);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(535, 62);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Full Initialization Settings";
            // 
            // browseFullInitBtn
            // 
            this.browseFullInitBtn.Location = new System.Drawing.Point(495, 19);
            this.browseFullInitBtn.Name = "browseFullInitBtn";
            this.browseFullInitBtn.Size = new System.Drawing.Size(29, 23);
            this.browseFullInitBtn.TabIndex = 2;
            this.browseFullInitBtn.Text = "...";
            this.browseFullInitBtn.UseVisualStyleBackColor = true;
            this.browseFullInitBtn.Click += new System.EventHandler(this.browseFullInitBtn_Click);
            // 
            // fullInitDbLocation
            // 
            this.fullInitDbLocation.Location = new System.Drawing.Point(129, 21);
            this.fullInitDbLocation.Name = "fullInitDbLocation";
            this.fullInitDbLocation.Size = new System.Drawing.Size(360, 20);
            this.fullInitDbLocation.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(117, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "CE Database Location:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.snapshotSrcBrowse);
            this.groupBox2.Controls.Add(this.snapshotSrcLocation);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.snapshotDestBrowse);
            this.groupBox2.Controls.Add(this.snapshotDestLocation);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Location = new System.Drawing.Point(2, 100);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(535, 99);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Snapshot Initialization Settings";
            // 
            // snapshotSrcBrowse
            // 
            this.snapshotSrcBrowse.Location = new System.Drawing.Point(499, 28);
            this.snapshotSrcBrowse.Name = "snapshotSrcBrowse";
            this.snapshotSrcBrowse.Size = new System.Drawing.Size(29, 23);
            this.snapshotSrcBrowse.TabIndex = 8;
            this.snapshotSrcBrowse.Text = "...";
            this.snapshotSrcBrowse.UseVisualStyleBackColor = true;
            this.snapshotSrcBrowse.Click += new System.EventHandler(this.snapshotSrcBrowse_Click);
            // 
            // snapshotSrcLocation
            // 
            this.snapshotSrcLocation.Location = new System.Drawing.Point(173, 30);
            this.snapshotSrcLocation.Name = "snapshotSrcLocation";
            this.snapshotSrcLocation.Size = new System.Drawing.Size(320, 20);
            this.snapshotSrcLocation.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(5, 33);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(151, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Source CE Database Location";
            // 
            // snapshotDestBrowse
            // 
            this.snapshotDestBrowse.Location = new System.Drawing.Point(499, 66);
            this.snapshotDestBrowse.Name = "snapshotDestBrowse";
            this.snapshotDestBrowse.Size = new System.Drawing.Size(29, 23);
            this.snapshotDestBrowse.TabIndex = 5;
            this.snapshotDestBrowse.Text = "...";
            this.snapshotDestBrowse.UseVisualStyleBackColor = true;
            this.snapshotDestBrowse.Click += new System.EventHandler(this.snapshotDestBrowse_Click);
            // 
            // snapshotDestLocation
            // 
            this.snapshotDestLocation.Location = new System.Drawing.Point(173, 68);
            this.snapshotDestLocation.Name = "snapshotDestLocation";
            this.snapshotDestLocation.Size = new System.Drawing.Size(316, 20);
            this.snapshotDestLocation.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 71);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(142, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "New CE Database Location:";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.CheckFileExists = false;
            this.openFileDialog1.DefaultExt = "sdf";
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // okBtn
            // 
            this.okBtn.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okBtn.Location = new System.Drawing.Point(178, 207);
            this.okBtn.Name = "okBtn";
            this.okBtn.Size = new System.Drawing.Size(75, 23);
            this.okBtn.TabIndex = 5;
            this.okBtn.Text = "&Ok";
            this.okBtn.UseVisualStyleBackColor = true;
            this.okBtn.Click += new System.EventHandler(this.okBtn_Click);
            // 
            // button2
            // 
            this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button2.Location = new System.Drawing.Point(274, 207);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 6;
            this.button2.Text = "&Cancel";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // NewCEClientCreationWizard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(538, 239);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.okBtn);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.fastInitSnapshotBtn);
            this.Controls.Add(this.fullInitRadioBtn);
            this.Controls.Add(this.label1);
            this.Name = "NewCEClientCreationWizard";
            this.Text = "New CE Creation Wizard";
            this.Load += new System.EventHandler(this.NewCEClientCreationWizard_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button browseFullInitBtn;
        public System.Windows.Forms.TextBox fullInitDbLocation;
        private System.Windows.Forms.Button snapshotDestBrowse;
        public System.Windows.Forms.TextBox snapshotDestLocation;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button snapshotSrcBrowse;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button okBtn;
        private System.Windows.Forms.Button button2;
        public System.Windows.Forms.RadioButton fastInitSnapshotBtn;
        public System.Windows.Forms.RadioButton fullInitRadioBtn;
        public System.Windows.Forms.TextBox snapshotSrcLocation;
    }
}