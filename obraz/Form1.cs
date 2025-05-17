using System;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization;
using System.Windows.Forms.DataVisualization.Charting;
using static obraz.PpmLoader;
using static obraz.Negative;
using static obraz.Greyscale;
using static obraz.GammaCorrection;

namespace obraz
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            trackBarContrast.Minimum = 0;
            trackBarContrast.Maximum = 100;
            trackBarContrast.Value = 50;
            trackBarGamma.Minimum = 0;
            trackBarGamma.Maximum = 100;
            trackBarGamma.Value = 50;
            trackBarBrightness.Minimum = 0;
            trackBarBrightness.Maximum = 100;
            trackBarBrightness.Value = 50;
            trackBarBrightness.Scroll += trackBarBrightness_Scroll;
            trackBarContrast.Scroll += trackBarContrast_Scroll;
            trackBarGamma.Scroll += trackBarGamma_Scroll;
            textBox1.Visible = false;
            textBox2.Visible = false;
            textBox3.Visible = false;
            trackBarBrightness.Visible = false;
            trackBarContrast.Visible = false;
            trackBarGamma.Visible = false;
        }

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

        public static class HistogramOperations
        {
            public static void ApplyHistogramStretching(PictureBox inputBox, PictureBox outputBox)
            {
                if (inputBox.Image == null) return;

                Bitmap original = new(inputBox.Image);
                Bitmap stretched = new(original.Width, original.Height);

                int min = 255, max = 0;


                for (int y = 0; y < original.Height; y++)
                {
                    for (int x = 0; x < original.Width; x++)
                    {
                        Color pixel = original.GetPixel(x, y);
                        int gray = (int)(0.3 * pixel.R + 0.59 * pixel.G + 0.11 * pixel.B);
                        if (gray < min) min = gray;
                        if (gray > max) max = gray;
                    }
                }

                if (max == min) return;

                float scale = 255f / (max - min);

                // Rozci¹ganie ka¿dego kana³u RGB
                for (int y = 0; y < original.Height; y++)
                {
                    for (int x = 0; x < original.Width; x++)
                    {
                        Color pixel = original.GetPixel(x, y);
                        int r = Clamp((int)((pixel.R - min) * scale));
                        int g = Clamp((int)((pixel.G - min) * scale));
                        int b = Clamp((int)((pixel.B - min) * scale));
                        stretched.SetPixel(x, y, Color.FromArgb(r, g, b));
                    }
                }

                outputBox.Image = stretched;
            }

            private static int Clamp(int value)
            {
                return Math.Max(0, Math.Min(255, value));
            }



            public static void EqualizeHistogram(PictureBox inputBox, PictureBox outputBox)
            {
                if (inputBox.Image == null) return;

                Bitmap original = new(inputBox.Image);
                Bitmap result = new(original.Width, original.Height);

                int width = original.Width;
                int height = original.Height;


                int[] rHist = new int[256];
                int[] gHist = new int[256];
                int[] bHist = new int[256];

                for (int y = 0; y < height; y++)
                {
                    for (int x = 0; x < width; x++)
                    {
                        Color pixel = original.GetPixel(x, y);
                        rHist[pixel.R]++;
                        gHist[pixel.G]++;
                        bHist[pixel.B]++;
                    }
                }

                int totalPixels = width * height;
                int[] rLUT = BuildEqualizationLUT(rHist, totalPixels);
                int[] gLUT = BuildEqualizationLUT(gHist, totalPixels);
                int[] bLUT = BuildEqualizationLUT(bHist, totalPixels);


                for (int y = 0; y < height; y++)
                {
                    for (int x = 0; x < width; x++)
                    {
                        Color pixel = original.GetPixel(x, y);
                        int r = rLUT[pixel.R];
                        int g = gLUT[pixel.G];
                        int b = bLUT[pixel.B];

                        result.SetPixel(x, y, Color.FromArgb(r, g, b));
                    }
                }

                outputBox.Image = result;
            }


            private static int[] BuildEqualizationLUT(int[] hist, int totalPixels)
            {
                int[] lut = new int[256];
                float[] cdf = new float[256];
                int sum = 0;

                for (int i = 0; i < 256; i++)
                {
                    sum += hist[i];
                    cdf[i] = (float)sum / totalPixels;
                    lut[i] = (int)(cdf[i] * 255);
                }

                return lut;
            }



            public static void ShowHistogram(PictureBox pictureBox)
            {
                if (pictureBox.Image == null) return;

                Bitmap bitmap = new Bitmap(pictureBox.Image);
                int[] rHist = new int[256];
                int[] gHist = new int[256];
                int[] bHist = new int[256];

                for (int y = 0; y < bitmap.Height; y++)
                {
                    for (int x = 0; x < bitmap.Width; x++)
                    {
                        Color pixel = bitmap.GetPixel(x, y);
                        rHist[pixel.R]++;
                        gHist[pixel.G]++;
                        bHist[pixel.B]++;
                    }
                }

                Form histogramForm = new Form
                {
                    Text = "Histogram",
                    Width = 600,
                    Height = 400
                };

                Chart chart = new Chart
                {
                    Dock = DockStyle.Fill
                };

                ChartArea chartArea = new ChartArea();
                chart.ChartAreas.Add(chartArea);

                Series redSeries = new Series("Red")
                {
                    ChartType = SeriesChartType.Line,
                    Color = Color.Red
                };
                Series greenSeries = new Series("Green")
                {
                    ChartType = SeriesChartType.Line,
                    Color = Color.Green
                };
                Series blueSeries = new Series("Blue")
                {
                    ChartType = SeriesChartType.Line,
                    Color = Color.Blue
                };

                for (int i = 1; i < 255; i++)
                {
                    redSeries.Points.AddXY(i, rHist[i]);
                    greenSeries.Points.AddXY(i, gHist[i]);
                    blueSeries.Points.AddXY(i, bHist[i]);
                }

                chart.Series.Add(redSeries);
                chart.Series.Add(greenSeries);
                chart.Series.Add(blueSeries);

                histogramForm.Controls.Add(chart);
                histogramForm.ShowDialog();
            }
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
            if (trackBarBrightness.Visible)
            {
                trackBarBrightness.Visible = false;
            }
            else
            {
                trackBarBrightness.Visible = true;
                trackBarContrast.Visible = false;
                trackBarGamma.Visible = false;
            }
        }
        private void contrastToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (trackBarContrast.Visible)
            {
                trackBarContrast.Visible = false;
            }
            else
            {
                trackBarContrast.Visible = true;
                trackBarBrightness.Visible = false;
                trackBarGamma.Visible = false;
            }
        }

        private void gammaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (trackBarGamma.Visible)
            {
                trackBarGamma.Visible = false;
            }
            else
            {
                trackBarGamma.Visible = true;
                trackBarBrightness.Visible = false;
                trackBarContrast.Visible = false;
            }
        }

        internal class BrightnessBezier
        {
            public static void ApplyBrightnessWithBezier(PictureBox inputBox, PictureBox outputBox, float t)
            {
                if (inputBox.Image == null) return;

                Bitmap original = new(inputBox.Image);
                Bitmap modified = new(original.Width, original.Height);

                // LUT 0-255
                int[] lut = new int[256];
                for (int i = 0; i < 256; i++)
                {
                    lut[i] = AdjustValue(i, t);
                }

                for (int y = 0; y < original.Height; y++)
                {
                    for (int x = 0; x < original.Width; x++)
                    {
                        Color pixel = original.GetPixel(x, y);
                        modified.SetPixel(x, y, Color.FromArgb(
                            lut[pixel.R],
                            lut[pixel.G],
                            lut[pixel.B]));
                    }
                }

                outputBox.Image = modified;
            }

            private static int AdjustValue(int value, float t)
            {
                if (t == 0.5f) return value;

                float factor;
                if (t > 0.5f)
                {
                    float intensity = (t - 0.5f) * 2;
                    factor = BezierCurve(intensity, 1f, 1.25f, 1.5f);
                }
                else
                {
                    float intensity = (0.5f - t) * 2;
                    factor = BezierCurve(intensity, 1f, 0.75f, 0.5f);
                }

                int newValue = (int)(value * factor);
                return Math.Clamp(newValue, 0, 255);
            }

            private static float BezierCurve(float t, float p0, float p1, float p2)
            {
                return (float)(
                    Math.Pow(1 - t, 2) * p0 +
                    2 * (1 - t) * t * p1 +
                    Math.Pow(t, 2) * p2
                );
            }
        }



        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
        private void PictureBox1_Click(object sender, EventArgs e) { }


        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void trackBar1_Scroll(object sender, EventArgs e)
        {

        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {

        }


        private void trackBar3_Scroll(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
        private void trackBarBrightness_Scroll(object sender, EventArgs e)
        {
            if (pictureBox1.Image == null) return;

            float t = trackBarBrightness.Value / 100f;
            BrightnessBezier.ApplyBrightnessWithBezier(pictureBox1, pictureBox2, t);
        }

        private void trackBarContrast_Scroll(object sender, EventArgs e)
        {
            if (pictureBox1.Image == null) return;
            float t = trackBarContrast.Value / 100f;
            ContrastSigmoid.ApplySigmoidContrast(pictureBox1, pictureBox2, t);
        }

        private void trackBarGamma_Scroll(object sender, EventArgs e)
        {
            if (pictureBox1.Image == null) return;
            float t = trackBarGamma.Value / 100f;
            GammaCorrection.ApplyGammaCorrection(pictureBox1, pictureBox2, t);
        }

        private void equalizationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HistogramOperations.EqualizeHistogram(pictureBox1, pictureBox2);
            HistogramOperations.ShowHistogram(pictureBox2);
        }

        private void strechingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HistogramOperations.ApplyHistogramStretching(pictureBox1, pictureBox2);
            HistogramOperations.ShowHistogram(pictureBox2);
        }

        private void histogramToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void histogramToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            HistogramOperations.ShowHistogram(pictureBox1);
        }

        private void gaussToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConvolutionOperations.ApplyGaussianBlur(pictureBox1, pictureBox2);
        }

        private void uniformBlurToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConvolutionOperations.ApplyUniformBlur(pictureBox1, pictureBox2);
        }

        private void customKarnelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image == null)
            {
                MessageBox.Show("Najpierw wczytaj obraz.");
                return;
            }

            Form kernelForm = new Form
            {
                Text = "WprowadŸ maskê splotu (np. 3x3, wartoœci oddzielone spacjami, wiersze enterami)",
                Width = 400,
                Height = 300
            };

            TextBox kernelInput = new TextBox
            {
                Multiline = true,
                Dock = DockStyle.Fill,
                AcceptsReturn = true,
                AcceptsTab = true,
                Text = "1 1 1\n1 1 1\n1 1 1"
            };

            Button applyButton = new Button
            {
                Text = "Zastosuj",
                Dock = DockStyle.Bottom
            };

            kernelForm.Controls.Add(kernelInput);
            kernelForm.Controls.Add(applyButton);

            applyButton.Click += (s, ev) =>
            {
                try
                {
                    string[] rows = kernelInput.Text.Trim().Split('\n');
                    int size = rows.Length;
                    if (size % 2 == 0 || size < 3)
                    {
                        MessageBox.Show("Rozmiar maski musi byæ nieparzysty i wiêkszy lub równy 3.");
                        return;
                    }

                    float[,] kernel = new float[size, size];

                    for (int i = 0; i < size; i++)
                    {
                        string[] values = rows[i].Trim().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                        if (values.Length != size)
                        {
                            MessageBox.Show("Maska musi byæ kwadratowa!");
                            return;
                        }

                        for (int j = 0; j < size; j++)
                        {
                            kernel[i, j] = float.Parse(values[j]);
                        }
                    }

                    ConvolutionOperations.ApplyConvolution(pictureBox1, pictureBox2, kernel);
                    kernelForm.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("B³¹d podczas parsowania maski: " + ex.Message);
                }
            };

            kernelForm.ShowDialog();
        }

        private void robertsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Gradient.ApplyRobertsFilter(pictureBox1, pictureBox2);
        }

        private void prewittaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Gradient.ApplyPrewittFilter(pictureBox1, pictureBox2);
        }

        private void sobelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Gradient.ApplySobelFilter(pictureBox1, pictureBox2);
        }

        private void laplaceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Gradient.ApplyLaplacianFilter(pictureBox1, pictureBox2);

        }

        private void laplaceZeroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Gradient.ApplyZeroCrossingFilter(pictureBox1, pictureBox2);
        }

        private void cannyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Gradient.ApplyCannyEdgeDetection(pictureBox1, pictureBox2);
        }
    }


}

