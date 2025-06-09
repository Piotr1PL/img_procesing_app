using System;
using System.Drawing;
using System.Windows.Forms;

namespace obraz
{
    internal class Hougha
    {
        public static void Run(PictureBox inputBox, PictureBox outputBox)
        {
            if (inputBox.Image == null)
            {
                MessageBox.Show("Brak obrazu wejściowego.");
                return;
            }

            Bitmap source = new Bitmap(inputBox.Image);
            int width = source.Width;
            int height = source.Height;

            PictureBox tempBox = new PictureBox { Image = (Bitmap)source.Clone() };
            new Greyscale(tempBox, tempBox);
            Gradient.ApplyLaplacianFilter(tempBox, tempBox);
            Bitmap edgeImage = new Bitmap(tempBox.Image);

            int diagonal = (int)Math.Ceiling(Math.Sqrt(width * width + height * height));
            int[,] accumulator = new int[2 * diagonal, 180];

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    Color color = edgeImage.GetPixel(x, y);
                    if (color.R > 128)
                    {
                        for (int theta = 0; theta < 180; theta++)
                        {
                            double radians = theta * Math.PI / 180.0;
                            int r = (int)(x * Math.Cos(radians) + y * Math.Sin(radians));
                            r += diagonal;
                            if (r >= 0 && r < 2 * diagonal)
                                accumulator[r, theta]++;
                        }
                    }
                }
            }

            int accWidth = 180;
            int accHeight = 2 * diagonal;
            Bitmap spectrum = new Bitmap(accWidth, accHeight);
            int maxVal = 0;

            for (int r = 0; r < accHeight; r++)
                for (int t = 0; t < accWidth; t++)
                    if (accumulator[r, t] > maxVal)
                        maxVal = accumulator[r, t];

            double brightnessBoost = 1.5; // <--- Wzmocnienie jasności

            for (int r = 0; r < accHeight; r++)
            {
                for (int t = 0; t < accWidth; t++)
                {
                    int value = (int)(brightnessBoost * 255.0 * accumulator[r, t] / maxVal);
                    value = Math.Min(255, value);
                    spectrum.SetPixel(t, r, Color.FromArgb(value, value, value));
                }
            }

            Bitmap resizedSpectrum = new Bitmap(width, height);
            using (Graphics g = Graphics.FromImage(resizedSpectrum))
            {
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                g.DrawImage(spectrum, new Rectangle(0, 0, width, height));
            }

            outputBox.Image = resizedSpectrum;
        }
    }
}
