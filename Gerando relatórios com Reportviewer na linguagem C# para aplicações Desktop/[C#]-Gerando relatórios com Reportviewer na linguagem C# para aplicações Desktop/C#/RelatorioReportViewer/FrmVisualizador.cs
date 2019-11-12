using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RelatorioReportViewer
{
    public partial class FrmVisualizador : Form
    {
        public FrmVisualizador()
        {
            InitializeComponent();
        }

        private void FrmVisualizador_Load(object sender, EventArgs e)
        {
             
            // TODO: This line of code loads data into the 'Acoes_ColetivasDataSet.Produtos' table. You can move, or remove it, as needed.
            this.ProdutosTableAdapter.Fill(this.Acoes_ColetivasDataSet.Produtos);

            this.reportViewer1.RefreshReport();
        }
    }
}
