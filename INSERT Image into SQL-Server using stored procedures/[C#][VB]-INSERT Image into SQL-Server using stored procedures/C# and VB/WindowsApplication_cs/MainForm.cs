using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using WindowsApplication_cs.Classes;

namespace WindowsApplication_cs
{
    public partial class MainForm : Form
    {
        BindingSource bs = new BindingSource();
        DatabaseImageOperations ops = new DatabaseImageOperations();
        public MainForm()
        {
            InitializeComponent();
        }
        void BindImage(object sender, ConvertEventArgs e)
        {
            if (e.DesiredType == typeof(Image))
            {
                System.IO.MemoryStream ms = new System.IO.MemoryStream((byte[])e.Value);
                Image image = Image.FromStream(ms);
                e.Value = image;
            }
        }
        void Form1_Load(object sender, EventArgs e)
        {
            DataGridView1.AutoGenerateColumns = false;
            bs.DataSource = ops.DataTable();
            DataGridView1.DataSource = bs;

            Binding ImageBinding = new Binding("Image", bs, "ImageData");
            ImageBinding.Format += BindImage;
            PictureBox1.DataBindings.Add(ImageBinding);
        }

        void cmdInsertImage_Click(object sender, EventArgs e)
        {
            SelectImageForm f = new SelectImageForm();
            try
            {
                if (f.ShowDialog() == DialogResult.OK)
                {
                    int Identifier = 0;
                    var fileBytes = System.IO.File.ReadAllBytes(f.FileName);
                    if (ops.InsertImage(fileBytes, f.Description, ref Identifier) == Success.Okay)
                    {
                        ((DataTable)bs.DataSource).Rows.Add(new object[] { Identifier, fileBytes, f.Description });
                        var index = bs.Find("ImageId", Identifier);
                        if (index > -1)
                        {
                            bs.Position = index;
                        }
                    }
                }
            }
            finally
            {
                f.Dispose();
            }
        }
    }
}
