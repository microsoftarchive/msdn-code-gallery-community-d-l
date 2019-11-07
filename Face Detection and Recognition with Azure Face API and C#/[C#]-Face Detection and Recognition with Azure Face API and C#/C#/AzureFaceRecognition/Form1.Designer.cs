namespace AzureFaceRecognition
{
    partial class Form1
    {
        /// <summary>
        /// Variabile di progettazione necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Pulire le risorse in uso.
        /// </summary>
        /// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Codice generato da Progettazione Windows Form

        /// <summary>
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent()
        {
            this.imgBox = new System.Windows.Forms.PictureBox();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.btnProcess = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnTrain = new System.Windows.Forms.Button();
            this.btnIdentify = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.idList = new System.Windows.Forms.ListBox();
            this.btnPBrowse = new System.Windows.Forms.Button();
            this.txtImageFolder = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.listUsers = new System.Windows.Forms.ListBox();
            this.btnAddUser = new System.Windows.Forms.Button();
            this.btnCreateGroup = new System.Windows.Forms.Button();
            this.txtNewUser = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtGroupName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.imgBox)).BeginInit();
            this.panel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // imgBox
            // 
            this.imgBox.BackColor = System.Drawing.Color.Black;
            this.imgBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.imgBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.imgBox.Location = new System.Drawing.Point(0, 0);
            this.imgBox.Name = "imgBox";
            this.imgBox.Size = new System.Drawing.Size(887, 497);
            this.imgBox.TabIndex = 0;
            this.imgBox.TabStop = false;
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(3, 3);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(139, 34);
            this.btnBrowse.TabIndex = 1;
            this.btnBrowse.Text = "&Browse";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // btnProcess
            // 
            this.btnProcess.Location = new System.Drawing.Point(148, 3);
            this.btnProcess.Name = "btnProcess";
            this.btnProcess.Size = new System.Drawing.Size(139, 34);
            this.btnProcess.TabIndex = 2;
            this.btnProcess.Text = "&Process image";
            this.btnProcess.UseVisualStyleBackColor = true;
            this.btnProcess.Click += new System.EventHandler(this.btnProcess_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.flowLayoutPanel1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 458);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(887, 39);
            this.panel1.TabIndex = 4;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.btnBrowse);
            this.flowLayoutPanel1.Controls.Add(this.btnProcess);
            this.flowLayoutPanel1.Controls.Add(this.btnTrain);
            this.flowLayoutPanel1.Controls.Add(this.btnIdentify);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(305, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(582, 39);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // btnTrain
            // 
            this.btnTrain.Location = new System.Drawing.Point(293, 3);
            this.btnTrain.Name = "btnTrain";
            this.btnTrain.Size = new System.Drawing.Size(139, 34);
            this.btnTrain.TabIndex = 3;
            this.btnTrain.Text = "&Train";
            this.btnTrain.UseVisualStyleBackColor = true;
            this.btnTrain.Click += new System.EventHandler(this.btnTrain_Click);
            // 
            // btnIdentify
            // 
            this.btnIdentify.Location = new System.Drawing.Point(438, 3);
            this.btnIdentify.Name = "btnIdentify";
            this.btnIdentify.Size = new System.Drawing.Size(139, 34);
            this.btnIdentify.TabIndex = 4;
            this.btnIdentify.Text = "&Identify";
            this.btnIdentify.UseVisualStyleBackColor = true;
            this.btnIdentify.Click += new System.EventHandler(this.btnIdentify_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.idList);
            this.panel2.Controls.Add(this.btnPBrowse);
            this.panel2.Controls.Add(this.txtImageFolder);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.listUsers);
            this.panel2.Controls.Add(this.btnAddUser);
            this.panel2.Controls.Add(this.btnCreateGroup);
            this.panel2.Controls.Add(this.txtNewUser);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.txtGroupName);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(590, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(297, 458);
            this.panel2.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(5, 328);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(203, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Identified persons in current image";
            // 
            // idList
            // 
            this.idList.FormattingEnabled = true;
            this.idList.Location = new System.Drawing.Point(8, 344);
            this.idList.Name = "idList";
            this.idList.Size = new System.Drawing.Size(281, 108);
            this.idList.TabIndex = 9;
            // 
            // btnPBrowse
            // 
            this.btnPBrowse.Location = new System.Drawing.Point(258, 232);
            this.btnPBrowse.Name = "btnPBrowse";
            this.btnPBrowse.Size = new System.Drawing.Size(29, 21);
            this.btnPBrowse.TabIndex = 8;
            this.btnPBrowse.Text = "...";
            this.btnPBrowse.UseVisualStyleBackColor = true;
            this.btnPBrowse.Click += new System.EventHandler(this.btnPBrowse_Click);
            // 
            // txtImageFolder
            // 
            this.txtImageFolder.Location = new System.Drawing.Point(6, 233);
            this.txtImageFolder.Name = "txtImageFolder";
            this.txtImageFolder.Size = new System.Drawing.Size(246, 20);
            this.txtImageFolder.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 218);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(105, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Persons image folder";
            // 
            // listUsers
            // 
            this.listUsers.FormattingEnabled = true;
            this.listUsers.Location = new System.Drawing.Point(6, 54);
            this.listUsers.Name = "listUsers";
            this.listUsers.Size = new System.Drawing.Size(281, 160);
            this.listUsers.TabIndex = 5;
            // 
            // btnAddUser
            // 
            this.btnAddUser.Location = new System.Drawing.Point(258, 28);
            this.btnAddUser.Name = "btnAddUser";
            this.btnAddUser.Size = new System.Drawing.Size(29, 20);
            this.btnAddUser.TabIndex = 4;
            this.btnAddUser.Text = "+";
            this.btnAddUser.UseVisualStyleBackColor = true;
            this.btnAddUser.Click += new System.EventHandler(this.btnAddUser_Click);
            // 
            // btnCreateGroup
            // 
            this.btnCreateGroup.Location = new System.Drawing.Point(6, 258);
            this.btnCreateGroup.Name = "btnCreateGroup";
            this.btnCreateGroup.Size = new System.Drawing.Size(281, 26);
            this.btnCreateGroup.TabIndex = 3;
            this.btnCreateGroup.Text = "&Create group";
            this.btnCreateGroup.UseVisualStyleBackColor = true;
            this.btnCreateGroup.Click += new System.EventHandler(this.btnCreateGroup_Click);
            // 
            // txtNewUser
            // 
            this.txtNewUser.Location = new System.Drawing.Point(74, 28);
            this.txtNewUser.Name = "txtNewUser";
            this.txtNewUser.Size = new System.Drawing.Size(178, 20);
            this.txtNewUser.TabIndex = 3;
            this.txtNewUser.Text = "???";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "New user";
            // 
            // txtGroupName
            // 
            this.txtGroupName.Location = new System.Drawing.Point(74, 6);
            this.txtGroupName.Name = "txtGroupName";
            this.txtGroupName.Size = new System.Drawing.Size(213, 20);
            this.txtGroupName.TabIndex = 1;
            this.txtGroupName.Text = "My Group";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Group name";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(887, 497);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.imgBox);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AzureFaceRecognition - Emiliano Musso @2017";
            ((System.ComponentModel.ISupportInitialize)(this.imgBox)).EndInit();
            this.panel1.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox imgBox;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.Button btnProcess;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ListBox listUsers;
        private System.Windows.Forms.Button btnAddUser;
        private System.Windows.Forms.TextBox txtNewUser;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtGroupName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCreateGroup;
        private System.Windows.Forms.Button btnPBrowse;
        private System.Windows.Forms.TextBox txtImageFolder;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnTrain;
        private System.Windows.Forms.Button btnIdentify;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListBox idList;
    }
}

