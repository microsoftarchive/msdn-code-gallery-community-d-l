using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Padre : Form
    {
        public Padre()
        {
            InitializeComponent();
        }       

        private void btMostrarHijo1_Click(object sender, EventArgs e)
        {
            if (this.panelContenedor.Controls.Count > 0)
                this.panelContenedor.Controls.RemoveAt(0);
            Hijo1 hijo1 = new Hijo1();
            hijo1.TopLevel = false;
            hijo1.FormBorderStyle = FormBorderStyle.None;
            hijo1.Dock = DockStyle.Fill;
            this.panelContenedor.Controls.Add(hijo1);
            this.panelContenedor.Tag = hijo1;
            hijo1.Show();
        }

        private void btMostrarHijo2_Click(object sender, EventArgs e)
        {            
            AddFormInPanel(new Hijo2());
        }

        /// <summary>
        /// Agrega en un Panel un formulario
        /// </summary>
        /// <param name="formHijo">Instancia del formulario a agregar</param>
        private void AddFormInPanel(object formHijo)
        {
            if (this.panelContenedor.Controls.Count > 0)
                this.panelContenedor.Controls.RemoveAt(0);
            Form fh = formHijo as Form;
            fh.TopLevel = false;
            fh.FormBorderStyle = FormBorderStyle.None;
            fh.Dock = DockStyle.Fill;
            this.panelContenedor.Controls.Add(fh);
            this.panelContenedor.Tag = fh;
            fh.Show();
        }

        
    }
}
