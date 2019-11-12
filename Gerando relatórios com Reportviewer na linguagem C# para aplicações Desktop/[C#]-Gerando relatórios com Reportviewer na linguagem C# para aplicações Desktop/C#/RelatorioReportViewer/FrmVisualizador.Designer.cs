namespace RelatorioReportViewer
{
    partial class FrmVisualizador
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
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.Acoes_ColetivasDataSet = new RelatorioReportViewer.Acoes_ColetivasDataSet();
            this.ProdutosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ProdutosTableAdapter = new RelatorioReportViewer.Acoes_ColetivasDataSetTableAdapters.ProdutosTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.Acoes_ColetivasDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ProdutosBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            reportDataSource1.Name = "DataSet_Produtos";
            reportDataSource1.Value = this.ProdutosBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "RelatorioReportViewer.Relatorio_Produtos.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 1);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(442, 321);
            this.reportViewer1.TabIndex = 0;
            // 
            // Acoes_ColetivasDataSet
            // 
            this.Acoes_ColetivasDataSet.DataSetName = "Acoes_ColetivasDataSet";
            this.Acoes_ColetivasDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // ProdutosBindingSource
            // 
            this.ProdutosBindingSource.DataMember = "Produtos";
            this.ProdutosBindingSource.DataSource = this.Acoes_ColetivasDataSet;
            // 
            // ProdutosTableAdapter
            // 
            this.ProdutosTableAdapter.ClearBeforeFill = true;
            // 
            // FrmVisualizador
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(440, 321);
            this.Controls.Add(this.reportViewer1);
            this.Name = "FrmVisualizador";
            this.Text = "FrmVisualizador";
            this.Load += new System.EventHandler(this.FrmVisualizador_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Acoes_ColetivasDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ProdutosBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource ProdutosBindingSource;
        private Acoes_ColetivasDataSet Acoes_ColetivasDataSet;
        private Acoes_ColetivasDataSetTableAdapters.ProdutosTableAdapter ProdutosTableAdapter;
    }
}