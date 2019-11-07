namespace ShanuDGVHelper_Demo
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다.
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.Panel4 = new System.Windows.Forms.Panel();
            this.Label1 = new System.Windows.Forms.Label();
            this.pnlShanuGrid = new System.Windows.Forms.Panel();
            this.Panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // Panel4
            // 
            this.Panel4.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Panel4.BackgroundImage")));
            this.Panel4.Controls.Add(this.Label1);
            this.Panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.Panel4.Location = new System.Drawing.Point(0, 0);
            this.Panel4.Name = "Panel4";
            this.Panel4.Size = new System.Drawing.Size(1027, 29);
            this.Panel4.TabIndex = 128;
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.BackColor = System.Drawing.Color.Transparent;
            this.Label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1.ForeColor = System.Drawing.Color.Yellow;
            this.Label1.Location = new System.Drawing.Point(256, 0);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(477, 24);
            this.Label1.TabIndex = 47;
            this.Label1.Text = "S   H   A    N   U        -  DataGridView Helper Class";
            // 
            // pnlShanuGrid
            // 
            this.pnlShanuGrid.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlShanuGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlShanuGrid.Location = new System.Drawing.Point(0, 29);
            this.pnlShanuGrid.Name = "pnlShanuGrid";
            this.pnlShanuGrid.Size = new System.Drawing.Size(1027, 775);
            this.pnlShanuGrid.TabIndex = 129;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1027, 804);
            this.Controls.Add(this.pnlShanuGrid);
            this.Controls.Add(this.Panel4);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "S   H   A    N   U        -  DataGridView Helper Class";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Panel4.ResumeLayout(false);
            this.Panel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.Panel Panel4;
        internal System.Windows.Forms.Label Label1;
        private System.Windows.Forms.Panel pnlShanuGrid;

    }
}

