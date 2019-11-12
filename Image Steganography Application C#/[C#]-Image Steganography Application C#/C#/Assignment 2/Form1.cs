using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AForge.Imaging.Filters;

namespace Assignment_2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonBrowseSimple_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Bitmap Image (.bmp)|*.bmp| Gif Image (.gif)|*.gif| JPG Image (.jpg) |*.jpg| Png Image (.png)|*.png";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                pictureBoxSimple.ImageLocation = ofd.FileName;
                buttonBrowseSecret.Enabled = true;
            }
        }

        private void buttonBrowseSecret_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Bitmap Image (.bmp)|*.bmp| Gif Image (.gif)|*.gif | JPG Image (.jpg)|*.jpg| Png Image (.png)|*.png";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                Bitmap img = new Bitmap(ofd.FileName);
                pictureBoxSecret.Image = ToGreyScale(img);
                buttonSaveAsGrey.Enabled = true;
            }
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private Bitmap ToGreyScale(Bitmap bitmap)
        {
            int grey, i, j;
            Color color;

            for (i = 0; i < bitmap.Width; i++)
            {
                for (j = 0; j < bitmap.Height; j++)
                {
                    color = bitmap.GetPixel(i, j);
                    grey = (int)((color.R + color.G + color.B) / 3);
            //      grey = (int)((color.R * .3) + (color.G * .59) + (color.B * .11));

                    bitmap.SetPixel(i, j, Color.FromArgb(grey, grey, grey));
                }
            }

            return bitmap;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBoxKey.Text.Trim().Length < 4)
            {
                buttonGenerateResult.Enabled = false;
                errorProvider.SetError(textBoxKey, "Key length must be greater than 3");
                return;
            }
            else
            {
                buttonGenerateResult.Enabled = true;
                errorProvider.SetError(textBoxKey, "");
            }

            try
            {
               int.Parse(textBoxKey.Text);
               errorProvider.SetError(textBoxKey, "");
            }
            catch (FormatException except)
            {
                errorProvider.SetError(textBoxKey, "Only Integers allowed");
                return;
            }
        }

        private void buttonSaveAs_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Bitmap Image (.bmp)|*.bmp";

            if (sfd.ShowDialog() == DialogResult.OK)
            {

                pictureBoxResult.Image.Save(sfd.FileName);
            }
        }

        private void buttonDecryption_Click(object sender, EventArgs e)
        {
            groupBoxEncryption.Visible = false;
            groupBoxDecryption.Visible = true;
        }

        private void buttonEncryption_Click(object sender, EventArgs e)
        {
            groupBoxEncryption.Visible = true;
            groupBoxDecryption.Visible = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            groupBoxDecryption.Visible = false;
            groupBoxEncryption.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Bitmap Image (.bmp)|*.bmp|Gif Image (.gif)|*.gif |JPEG Image (.jpeg)|*.jpeg |Png Image (.png)|*.png ";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                pictureBoxEncryptedImage.ImageLocation = ofd.FileName;
            }
        }

        private byte getByte(byte[] bits)
        {
            String bitString = "";

            for (int i = 0; i < 8; i++)
                bitString += bits[i];
            byte newpix = Convert.ToByte(bitString, 2);
            int dePix = (int)newpix ^ key;
            return (byte)dePix;
        }

        private byte[] getBits(byte simplepixel)
        {
            int pixel = 0;
            pixel = (int)simplepixel ^ key;
            BitArray bits = new BitArray(new byte[] { (byte)pixel });
            bool[] boolarray = new bool[bits.Count];
            bits.CopyTo(boolarray, 0);
            byte[] bitsArray = boolarray.Select(bit => (byte)(bit ? 1 : 0)).ToArray();
            Array.Reverse(bitsArray);
            return bitsArray;
        }

        int key = 0;
        private void buttonGenerateResult_Click(object sender, EventArgs e)
        {
            Bitmap simple = new Bitmap(pictureBoxSimple.Image);
            Bitmap secretGreyScale = new Bitmap(pictureBoxSecret.Image);

            if (secretGreyScale.Height != simple.Height || secretGreyScale.Width != simple.Width)
            {
                ResizeBilinear resizeFilter = new ResizeBilinear(simple.Width, simple.Height);
                secretGreyScale = resizeFilter.Apply(secretGreyScale);
            }

            /* Variables initialization */
            Color pixelContainerImage = new Color();
            Color pixelMsgImage = new Color();
            
            key = int.Parse(textBoxKey.Text);

            byte[] MsgBits;
            byte[] AlphaBits;
            byte[] RedBits;
            byte[] GreenBits;
            byte[] BlueBits;

            byte newAlpha = 0;
            byte newRed = 0;
            byte newGreen = 0;
            byte newBlue = 0;

            /* Image Encryption */
            #region Encryption

            for (int i = 0; i < simple.Height; i++)
            {
                for (int j = 0; j < simple.Width; j++)
                {
                    pixelMsgImage = secretGreyScale.GetPixel(j, i);
                    MsgBits = getBits((byte)pixelMsgImage.R);

                    pixelContainerImage = simple.GetPixel(j, i);
                    AlphaBits = getBits((byte)pixelContainerImage.A);
                    RedBits = getBits((byte)pixelContainerImage.R);
                    GreenBits = getBits((byte)pixelContainerImage.G);
                    BlueBits = getBits((byte)pixelContainerImage.B);

                    AlphaBits[6] = MsgBits[0];
                    AlphaBits[7] = MsgBits[1];

                    RedBits[6] = MsgBits[2];
                    RedBits[7] = MsgBits[3];

                    GreenBits[6] = MsgBits[4];
                    GreenBits[7] = MsgBits[5];

                    BlueBits[6] = MsgBits[6];
                    BlueBits[7] = MsgBits[7];

                    newAlpha = getByte(AlphaBits);
                    newRed = getByte(RedBits);
                    newGreen = getByte(GreenBits);
                    newBlue = getByte(BlueBits);

                    pixelContainerImage = Color.FromArgb(newAlpha, newRed, newGreen, newBlue);
                    simple.SetPixel(j, i, pixelContainerImage);
                }
        //        richTextBox1.Text += "\n";
            }
            pictureBoxResult.Image = simple;
            // in the line below the value of pixels are changed
            //MessageBox.Show(((Bitmap)pictureBoxResult.Image).GetPixel(0, 0).B.ToString());
            // but if this will give the correct modified value
            //MessageBox.Show(simple.GetPixel(0, 0).B.ToString());

            buttonSaveAs.Enabled = true;
            #endregion
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Bitmap EncryptedImage = (Bitmap)pictureBoxEncryptedImage.Image;
            //Bitmap hiddenImage = (Bitmap)EncryptedImage.Clone();
            Bitmap hiddenImage = new Bitmap (EncryptedImage.Width, EncryptedImage.Height);

            /* Variables initialization */
            Color pixelToDecrypt = new Color();

            try
            {
                key = int.Parse(textBoxDekey.Text);
            }
            catch (FormatException except)
            {
                MessageBox.Show("Integer Key allowed only");
                return;
            }

            byte[] BitsToDecrypt = new byte[8];
            byte[] AlphaBits;
            byte[] RedBits;
            byte[] GreenBits;
            byte[] BlueBits;

            byte newGrey = 0;

            /* Image Decryption */
            #region Encryption

            for (int i = 0; i < EncryptedImage.Height; i++)
            {
                for (int j = 0; j < EncryptedImage.Width; j++)
                {
                    pixelToDecrypt = EncryptedImage.GetPixel(j, i);

                    AlphaBits = getBits((byte)pixelToDecrypt.A);
                    RedBits = getBits((byte)pixelToDecrypt.R);
                    GreenBits = getBits((byte)pixelToDecrypt.G);
                    BlueBits = getBits((byte)pixelToDecrypt.B);

                    BitsToDecrypt[0] = AlphaBits[6];
                    BitsToDecrypt[1] = AlphaBits[7];
                    BitsToDecrypt[2] = RedBits[6];
                    BitsToDecrypt[3] = RedBits[7];
                    BitsToDecrypt[4] = GreenBits[6];
                    BitsToDecrypt[5] = GreenBits[7];
                    BitsToDecrypt[6] = BlueBits[6];
                    BitsToDecrypt[7] = BlueBits[7];

                    //for (int k = 0; k < BitsToDecrypt.Length; k++)
                    //    richTextBox2.Text += BitsToDecrypt[k];
                    //richTextBox2.Text += " - ";

                    newGrey = getByte(BitsToDecrypt);

                   // MessageBox.Show(newGrey.ToString());

                    pixelToDecrypt = Color.FromArgb(newGrey, newGrey, newGrey);

                    hiddenImage.SetPixel(j, i, pixelToDecrypt);
                }
         //       richTextBox2.Text += "\n";
            }
            pictureBoxExtractedImage.Image = hiddenImage;
            buttonSaveAsFinal.Enabled = true;

            #endregion
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Bitmap Image (.bmp)|*.bmp|Gif Image (.gif)|*.gif |JPEG Image (.jpeg)|*.jpeg |Png Image (.png)|*.png ";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                pictureBoxExtractedImage.Image.Save(sfd.FileName);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Bitmap Image (.bmp)|*.bmp|Gif Image (.gif)|*.gif |JPEG Image (.jpeg)|*.jpeg |Png Image (.png)|*.png ";
            
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                pictureBoxSecret.Image.Save(sfd.FileName);
            }
        }

        private void textBoxDekey_TextChanged(object sender, EventArgs e)
        {
            if (textBoxDekey.Text.Trim().Length < 4 && textBoxDekey.Text.Trim().Length > 7)
            {
                buttonDecrypt.Enabled = false;
                errorProvider.SetError(textBoxDekey, "Key length must be greater than 3 and less than 7");
                return;
            }
            else
            {
                errorProvider.SetError(textBoxDekey, "");
                buttonDecrypt.Enabled = true;
            }

            try
            {
                int.Parse(textBoxDekey.Text);
                errorProvider.SetError(textBoxDekey, "");
            }
            catch (FormatException except)
            {
                errorProvider.SetError(textBoxDekey, "Only Integers allowed");
                return;
            }
        }
    }
}
