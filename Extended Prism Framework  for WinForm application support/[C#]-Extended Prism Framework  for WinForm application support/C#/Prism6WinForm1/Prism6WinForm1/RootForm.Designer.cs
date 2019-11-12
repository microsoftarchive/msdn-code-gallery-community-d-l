
namespace PrismApp
{
    partial class RootForm
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.menuPanel = new System.Windows.Forms.Panel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.regionExtender1 = new Prism.Unity.RegionExtender();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 26.04651F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 73.95349F));
            this.tableLayoutPanel1.Controls.Add(this.statusStrip1, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.menuPanel, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.splitContainer1, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.regionExtender1.SetRegionName(this.tableLayoutPanel1, "");
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40.48197F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 45.24456F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.27347F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(896, 446);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // statusStrip1
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.statusStrip1, 2);
            this.statusStrip1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.statusStrip1.Location = new System.Drawing.Point(1, 419);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.statusStrip1.Size = new System.Drawing.Size(894, 26);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // groupBox1
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.groupBox1, 2);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(4, 369);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(888, 46);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Status";
            // 
            // menuPanel
            // 
            this.menuPanel.AccessibleRole = System.Windows.Forms.AccessibleRole.Clock;
            this.tableLayoutPanel1.SetColumnSpan(this.menuPanel, 2);
            this.menuPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.menuPanel.Location = new System.Drawing.Point(4, 4);
            this.menuPanel.Name = "menuPanel";
            this.regionExtender1.SetRegionName(this.menuPanel, "MenuRegion");
            this.menuPanel.Size = new System.Drawing.Size(888, 44);
            this.menuPanel.TabIndex = 2;
            // 
            // splitContainer1
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.splitContainer1, 2);
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(4, 55);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.regionExtender1.SetRegionName(this.splitContainer1.Panel1, "NavigationRegion");
            // 
            // splitContainer1.Panel2
            // 
            this.regionExtender1.SetRegionName(this.splitContainer1.Panel2, "MainRegion");
            this.tableLayoutPanel1.SetRowSpan(this.splitContainer1, 2);
            this.splitContainer1.Size = new System.Drawing.Size(888, 307);
            this.splitContainer1.SplitterDistance = 296;
            this.splitContainer1.TabIndex = 3;
            // 
            // RootForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(896, 446);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "RootForm";
            this.Text = "RootForm";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel menuPanel;
        private System.Windows.Forms.SplitContainer splitContainer1;
        #endregion

        private Prism.Unity.RegionExtender regionExtender1;
    }
}