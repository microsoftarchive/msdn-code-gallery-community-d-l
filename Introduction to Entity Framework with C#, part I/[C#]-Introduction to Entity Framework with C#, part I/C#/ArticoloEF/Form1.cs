using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ArticoloEF.Model;

namespace ArticoloEF
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            using (TechnetModelloCF db = new TechnetModelloCF()){
                List<Articoli> la = db.Articoli.ToList();

                MessageBox.Show(la.FirstOrDefault().DesArt);
            }

        }
    }
}
