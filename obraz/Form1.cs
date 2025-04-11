using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using static obraz.PpmLoader;
using static obraz.Negative;
using static obraz.Greyscale;
using System.Security.Cryptography.X509Certificates;

namespace obraz
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void PictureBox1_Click(object sender, EventArgs e) { }

        private void FileToolStripMenuItem_Click(object sender, EventArgs e) { }

        private void LoadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new()
            {
                Filter = "Pliki PPM, PGM, PBM (*.ppm;*.pgm;*.pbm)|*.ppm;*.pgm;*.pbm"
            };
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                PpmLoader.LoadPpmImage(openFileDialog.FileName, pictureBox1);
            }
        }

        private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SavePpmImage(pictureBox1);
        }
        public static void SavePpmImage(PictureBox pictureBox)
        {
            try
            {
                Bitmap bitmap = (Bitmap)pictureBox.Image;
                if (bitmap == null)
                {
                    MessageBox.Show("Nie ma obrazu do zapisania.");
                    return;
                }
                int width = bitmap.Width;
                int height = bitmap.Height;


                using SaveFileDialog saveFileDialog = new();
                saveFileDialog.Filter = "PPM Files (*.ppm)|*.ppm|All Files (*.*)|*.*";
                saveFileDialog.DefaultExt = "ppm";
                saveFileDialog.AddExtension = true;

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = saveFileDialog.FileName;

                    using FileStream fs = new(filePath, FileMode.Create, FileAccess.Write);
                    using BinaryWriter writer = new(fs);
                    writer.Write(Encoding.ASCII.GetBytes("P6\n"));
                    writer.Write(Encoding.ASCII.GetBytes($"{width} {height}\n"));
                    writer.Write(Encoding.ASCII.GetBytes("255\n"));
                    for (int y = 0; y < height; y++)
                    {
                        for (int x = 0; x < width; x++)
                        {
                            Color pixelColor = bitmap.GetPixel(x, y);
                            writer.Write(pixelColor.R);
                            writer.Write(pixelColor.G);
                            writer.Write(pixelColor.B);
                        }
                    }

                    MessageBox.Show($"Obraz zapisany pomyœlnie: {filePath}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("B³¹d podczas zapisywania obrazu: " + ex.Message);
            }
        }

        private void NegatywToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void NegativeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Negative.InvertImage(pictureBox1, pictureBox2);
        }

        private void NegativegreyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NegativeGrayscale.InvertGrayscaleImage(pictureBox1, pictureBox2);
        }

        private void GreyScaleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Greyscale(pictureBox1, pictureBox2);
        }

        private void brightnessToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }
    }
}

