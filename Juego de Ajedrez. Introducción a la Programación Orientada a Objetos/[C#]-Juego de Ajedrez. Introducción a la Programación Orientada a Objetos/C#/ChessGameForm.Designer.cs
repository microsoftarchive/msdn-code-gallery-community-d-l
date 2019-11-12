namespace ChessGame
{
    partial class ChessGameForm
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
            this.panelBoard = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnStart = new System.Windows.Forms.Button();
            this.radioBlack = new System.Windows.Forms.RadioButton();
            this.radioWhite = new System.Windows.Forms.RadioButton();
            this.lblWin = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelBoard
            // 
            this.panelBoard.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelBoard.Location = new System.Drawing.Point(0, 0);
            this.panelBoard.Name = "panelBoard";
            this.panelBoard.Size = new System.Drawing.Size(553, 487);
            this.panelBoard.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblWin);
            this.groupBox1.Controls.Add(this.btnStart);
            this.groupBox1.Controls.Add(this.radioBlack);
            this.groupBox1.Controls.Add(this.radioWhite);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupBox1.Location = new System.Drawing.Point(563, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(158, 487);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Jugador arriba";
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(16, 92);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(118, 31);
            this.btnStart.TabIndex = 2;
            this.btnStart.Text = "Reiniciar";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // radioBlack
            // 
            this.radioBlack.AutoSize = true;
            this.radioBlack.Location = new System.Drawing.Point(16, 52);
            this.radioBlack.Name = "radioBlack";
            this.radioBlack.Size = new System.Drawing.Size(59, 17);
            this.radioBlack.TabIndex = 1;
            this.radioBlack.Text = "Negras";
            this.radioBlack.UseVisualStyleBackColor = true;
            // 
            // radioWhite
            // 
            this.radioWhite.AutoSize = true;
            this.radioWhite.Checked = true;
            this.radioWhite.Location = new System.Drawing.Point(16, 29);
            this.radioWhite.Name = "radioWhite";
            this.radioWhite.Size = new System.Drawing.Size(63, 17);
            this.radioWhite.TabIndex = 0;
            this.radioWhite.TabStop = true;
            this.radioWhite.Text = "Blancas";
            this.radioWhite.UseVisualStyleBackColor = true;
            // 
            // lblWin
            // 
            this.lblWin.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWin.Location = new System.Drawing.Point(22, 156);
            this.lblWin.Name = "lblWin";
            this.lblWin.Size = new System.Drawing.Size(111, 120);
            this.lblWin.TabIndex = 3;
            this.lblWin.Text = "Blancas\r\nGanan";
            this.lblWin.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblWin.Visible = false;
            // 
            // ChessGameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(721, 487);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panelBoard);
            this.MinimumSize = new System.Drawing.Size(520, 320);
            this.Name = "ChessGameForm";
            this.Text = "Chess";
            this.Load += new System.EventHandler(this.ChessGameForm_Load);
            this.Resize += new System.EventHandler(this.ChessGameForm_Resize);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelBoard;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioBlack;
        private System.Windows.Forms.RadioButton radioWhite;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Label lblWin;
    }
}

