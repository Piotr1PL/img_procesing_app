using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace obraz
{
    internal class ConvolutionOperations
    {
        public static void ApplyConvolution(PictureBox inputBox, PictureBox outputBox, float[,] kernel)
        {
            if (inputBox.Image == null)
            {
                MessageBox.Show("Najpierw wczytaj obraz.");
                return;
            }

            Bitmap inputBitmap = new Bitmap(inputBox.Image);
            Bitmap outputBitmap = new Bitmap(inputBitmap.Width, inputBitmap.Height);

            int kernelSize = kernel.GetLength(0);
            int kernelRadius = kernelSize / 2;

            float kernelSum = 0;
            for (int i = 0; i < kernelSize; i++)
                for (int j = 0; j < kernelSize; j++)
                    kernelSum += kernel[i, j];

            if (kernelSum == 0) kernelSum = 1;

            for (int y = 0; y < inputBitmap.Height; y++)
            {
                for (int x = 0; x < inputBitmap.Width; x++)
                {
                    float r = 0, g = 0, b = 0;

                    for (int ky = -kernelRadius; ky <= kernelRadius; ky++)
                    {
                        for (int kx = -kernelRadius; kx <= kernelRadius; kx++)
                        {
                            int pixelX = Math.Clamp(x + kx, 0, inputBitmap.Width - 1);
                            int pixelY = Math.Clamp(y + ky, 0, inputBitmap.Height - 1);

                            Color pixel = inputBitmap.GetPixel(pixelX, pixelY);
                            float kernelValue = kernel[ky + kernelRadius, kx + kernelRadius] / kernelSum;

                            r += pixel.R * kernelValue;
                            g += pixel.G * kernelValue;
                            b += pixel.B * kernelValue;
                        }
                    }

                    int newR = Math.Clamp((int)Math.Round(r), 0, 255);
                    int newG = Math.Clamp((int)Math.Round(g), 0, 255);
                    int newB = Math.Clamp((int)Math.Round(b), 0, 255);

                    outputBitmap.SetPixel(x, y, Color.FromArgb(newR, newG, newB));
                }
            }

            outputBox.Image = outputBitmap;
        }

        public static void ApplyUniformBlur(PictureBox inputBox, PictureBox outputBox, int kernelSize = 3)
        {
            if (kernelSize % 2 == 0 || kernelSize < 3)
            {
                MessageBox.Show("Rozmiar maski musi być nieparzysty i większy lub równy 3.");
                return;
            }

            float[,] kernel = new float[kernelSize, kernelSize];
            float weight = 1f;

            for (int i = 0; i < kernelSize; i++)
                for (int j = 0; j < kernelSize; j++)
                    kernel[i, j] = weight;

            ApplyConvolution(inputBox, outputBox, kernel);
        }

        public static void ApplyGaussianBlur(PictureBox inputBox, PictureBox outputBox, int kernelSize = 5, double sigma = 1.0)
        {
            if (kernelSize % 2 == 0 || kernelSize < 3)
            {
                MessageBox.Show("Rozmiar maski musi być nieparzysty i większy lub równy 3.");
                return;
            }

            float[,] kernel = new float[kernelSize, kernelSize];
            int radius = kernelSize / 2;
            double sum = 0;

            for (int y = -radius; y <= radius; y++)
            {
                for (int x = -radius; x <= radius; x++)
                {
                    double value = (1.0 / (2.0 * Math.PI * sigma * sigma)) * Math.Exp(-(x * x + y * y) / (2.0 * sigma * sigma));
                    kernel[y + radius, x + radius] = (float)value;
                    sum += value;
                }
            }

            for (int y = 0; y < kernelSize; y++)
                for (int x = 0; x < kernelSize; x++)
                    kernel[y, x] /= (float)sum;

            ApplyConvolution(inputBox, outputBox, kernel);
        }
    }
}
