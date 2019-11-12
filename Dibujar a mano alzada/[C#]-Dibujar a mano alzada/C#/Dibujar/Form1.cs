using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Dibujar
{
    public partial class Form1 : Form
    {
        private bool cursorDown;
        private Point[] puntos;
        private Pen lapiz;
        private Pen goma;
        private Bitmap bmp;
        private string accion;

        public Form1()
        {
            InitializeComponent();
        }

        private void Inicializar()
        {
            accion = "dibujar";
            puntos = new Point[0];

            //Creo el lapiz y la goma y defino el tipo de linea
            lapiz = new Pen(Color.Black, 1);
            lapiz.StartCap = System.Drawing.Drawing2D.LineCap.Round;
            lapiz.EndCap = System.Drawing.Drawing2D.LineCap.Round;
            lapiz.LineJoin = System.Drawing.Drawing2D.LineJoin.Round;
            goma = new Pen(Color.White, 10);
            goma.StartCap = System.Drawing.Drawing2D.LineCap.Round;
            goma.EndCap = System.Drawing.Drawing2D.LineCap.Round;
            goma.LineJoin = System.Drawing.Drawing2D.LineJoin.Round;

            bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);

            //creo el cursor del lapiz a partir de una imagen que tengo como recurso
            IntPtr intprCursor = Dibujar.Properties.Resources.LapizC.GetHicon();
            pictureBox1.Cursor = new Cursor(intprCursor);
        }

        private void agregarPunto(Point punto)
        {
            //agrega los puntos obtenidos al arreglo
            Point[] temp = new Point[puntos.Length + 1];
            puntos.CopyTo(temp, 0);
            puntos = temp;
            puntos[puntos.Length - 1] = punto;
        }

        private void MDibujar()
        {
            //Dibuja
            if (puntos.Length > 1)
            {
                //Aqui usamos dos Graphics, uno que dibuja directamente en el pictureBox y
                //otro que dibuja en la imagen.
                //Esto ayuda a que el dibujo sea rapido ya que si dibujamos solo la imagen
                //y la vamos colocando en el pictureBox puede ser mas lento.
                Graphics g1 = pictureBox1.CreateGraphics();
                Graphics g2 = Graphics.FromImage(bmp);
                g1.DrawLines(lapiz, puntos);
                g2.DrawLines(lapiz, puntos);
                g1.Dispose();
                g2.Dispose();
            }
        }

        private void MBorrar()
        {
            //Borra, es lo mismo que dibujar solo que el objeto Pen es otro
            if (puntos.Length > 1)
            {
                Graphics g1 = pictureBox1.CreateGraphics();
                Graphics g2 = Graphics.FromImage(bmp);
                g1.DrawLines(goma, puntos);
                g2.DrawLines(goma, puntos);
                g1.Dispose();
                g2.Dispose();
            }
        }

        private void CrearGoma()
        {
            //en realidad este metodo lo que hace es crear un cursor para la goma a partir de dos
            //elipses, de esta manera el cursor queda como un circulo
            int diametroG = Convert.ToInt32(goma.Width);
            Bitmap Goma = new Bitmap(diametroG, diametroG);

            Graphics gGoma = Graphics.FromImage(Goma);
            gGoma.FillRectangle(Brushes.Magenta, 0, 0, diametroG, diametroG);
            gGoma.FillEllipse(Brushes.White, 0, 0, diametroG - 1, diametroG - 1);
            gGoma.DrawEllipse(new Pen(Color.Black, 1), 0, 0, diametroG- 1, diametroG - 1);
            Goma.MakeTransparent(Color.Magenta);
            gGoma.Dispose();

            IntPtr intprCursorGoma = Goma.GetHicon();
            pictureBox1.Cursor = new Cursor(intprCursorGoma);

        }

        private void Unir(Bitmap fondo)
        {
            //Este metodo une un fondo con lo que se ha dibujado.
            //esto es necesario ya que lo que dibujamos se dibuja sobre un fondo transparente
            //y si no lo unimos puede traer problemas al salvar la imagen o al cambiarle el tamaño
            //al area de dibujo.
            Graphics g = Graphics.FromImage(fondo);
            g.DrawImage(bmp, 0, 0);
            bmp = new Bitmap(fondo);
            g.Dispose();
            fondo.Dispose();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //llamamos al metodo Inicializar() que inicializa los elementos
            Inicializar();
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            cursorDown = true;
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            toolStripStatusLabel4.Text = "X: " + e.X.ToString() + " Y: " + e.Y.ToString();
            if (cursorDown)
            {
                agregarPunto(new Point(e.X, e.Y));
                if (accion == "dibujar")
                {
                    MDibujar();
                }
                if (accion == "borrar")
                {
                    MBorrar();
                }
            }
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            cursorDown = false;

            //Aqui reinicializamos a puntos para que no se unan las lineas
            //al volver a dibujar
            puntos = new Point[0];

            //Marcamos como transparente en la imagen donde estamos dibujando todo aquello que sea
            //del color de fondo, esto es necesario para que al cambiar de fondo no se vea lo que borramos
            bmp.MakeTransparent(pictureBox1.BackColor);

            //ponemos la imagen dibujada como fondo
            //esto lo hago aqui y no mientras se dibuja para que el trabajo de dibujar sea mas rapido.
            pictureBox1.Image = bmp;
        }

        private void salvarDibujoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                Bitmap fondo = new Bitmap(bmp.Width, bmp.Height);
                Graphics g = Graphics.FromImage(fondo);
                g.FillRectangle(new SolidBrush(pictureBox1.BackColor), 0, 0, bmp.Width, bmp.Height);
                g.Dispose();
                Unir(fondo);
                bmp.Save(saveFileDialog1.FileName, ImageFormat.Bmp);
            }
        }

        private void tamañoDelDibujoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.ancho = pictureBox1.Width;
            f2.alto = pictureBox1.Height;
            if (f2.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Width = f2.ancho;
                pictureBox1.Height = f2.alto;
                Bitmap fondo = new Bitmap(pictureBox1.Width, pictureBox1.Height);
                Unir(fondo);
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            toolStripButton3.Checked = false;
            toolStripButton2.Checked = true;
            IntPtr intprCursor = Dibujar.Properties.Resources.LapizC.GetHicon();
            pictureBox1.Cursor = new Cursor(intprCursor);
            accion = "dibujar";
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            toolStripButton2.Checked = false;
            toolStripButton3.Checked = true;
            CrearGoma();
            accion = "borrar";

        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                Bitmap btemp = new Bitmap(15, 15);
                Graphics gtemp = Graphics.FromImage(btemp);
                gtemp.FillRectangle(new SolidBrush(colorDialog1.Color), 0, 0, 16, 16);
                toolStripButton4.Image = new Bitmap(btemp);
                gtemp.Dispose();
                btemp.Dispose();
                lapiz.Color = colorDialog1.Color;
            }
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                Bitmap btemp = new Bitmap(15, 15);
                Graphics gtemp = Graphics.FromImage(btemp);
                gtemp.FillRectangle(new SolidBrush(colorDialog1.Color), 0, 0, 16, 16);
                toolStripButton5.Image = new Bitmap(btemp);
                gtemp.Dispose();
                btemp.Dispose();
                pictureBox1.BackColor = colorDialog1.Color;
                goma.Color = colorDialog1.Color;
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Add)
            {
                if (accion == "dibujar")
                {
                    if (lapiz.Width < 100)
                    {
                        lapiz.Width++;
                    }
                }
                if (accion == "borrar")
                {
                    if (goma.Width < 100)
                    {
                        goma.Width++;
                        CrearGoma();
                    }
                }
            }

            if (e.KeyCode == Keys.Subtract)
            {
                if (accion == "dibujar")
                {
                    if (lapiz.Width > 1)
                    {
                        lapiz.Width--;
                    }
                }
                if (accion == "borrar")
                {
                    if (goma.Width > 10)
                    {
                        goma.Width--;
                        CrearGoma();
                    }
                }
            }

            toolStripStatusLabel2.Text = "Grosor Linea: " + lapiz.Width.ToString();
            toolStripStatusLabel3.Text = "Grosor Goma: " + goma.Width.ToString();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
     
    }
}