using System;
using System.Drawing;
using System.Windows.Forms;

namespace obraz
{
    internal class HarrisCornerDetector
    {
        static double[,] GenerateGaussianKernel(int size, double sigma)
        {
            double[,] kernel = new double[size, size];
            double sum = 0;
            int r = size / 2;

            for (int y = -r; y <= r; y++)
                for (int x = -r; x <= r; x++)
                {
                    double g = Math.Exp(-(x * x + y * y) / (2 * sigma * sigma));
                    g /= 2 * Math.PI * sigma * sigma;
                    kernel[x + r, y + r] = g;
                    sum += g;
                }

            for (int y = 0; y < size; y++)
                for (int x = 0; x < size; x++)
                    kernel[x, y] /= sum;

            return kernel;
        }

        public static void Run(PictureBox inputBox, PictureBox outputBox,
                               double sigma = 1.6, double sigmaWeight = 0.76,
                               double kparam = 0.05, double threshold = 30000000)
        {
            if (inputBox.Image == null)
            {
                MessageBox.Show("Brak obrazu wejœciowego.");
                return;
            }

            Bitmap src = new Bitmap(inputBox.Image);
            int width = src.Width;
            int height = src.Height;

            double[,] gray = new double[width, height];
            for (int y = 0; y < height; y++)
                for (int x = 0; x < width; x++)
                {
                    Color c = src.GetPixel(x, y);
                    gray[x, y] = 0.3 * c.R + 0.59 * c.G + 0.11 * c.B;
                }

            // Gaussian blur
            double[,] gauss = GenerateGaussianKernel(3, sigma);
            double[,] blurred = new double[width, height];
            for (int y = 1; y < height - 1; y++)
                for (int x = 1; x < width - 1; x++)
                {
                    double sum = 0;
                    for (int j = -1; j <= 1; j++)
                        for (int i = -1; i <= 1; i++)
                            sum += gray[x + i, y + j] * gauss[i + 1, j + 1];
                    blurred[x, y] = sum;
                }

            // Sobel gradients
            int[,] sobelX = { { -1, 0, 1 }, { -2, 0, 2 }, { -1, 0, 1 } };
            int[,] sobelY = { { -1, -2, -1 }, { 0, 0, 0 }, { 1, 2, 1 } };
            double[,] Gx = new double[width, height];
            double[,] Gy = new double[width, height];

            for (int y = 1; y < height - 1; y++)
                for (int x = 1; x < width - 1; x++)
                {
                    double gx = 0, gy = 0;
                    for (int j = -1; j <= 1; j++)
                        for (int i = -1; i <= 1; i++)
                        {
                            gx += blurred[x + i, y + j] * sobelX[i + 1, j + 1];
                            gy += blurred[x + i, y + j] * sobelY[i + 1, j + 1];
                        }
                    Gx[x, y] = gx;
                    Gy[x, y] = gy;
                }

            double[,] Ixx = new double[width, height];
            double[,] Iyy = new double[width, height];
            double[,] Ixy = new double[width, height];

            for (int y = 0; y < height; y++)
                for (int x = 0; x < width; x++)
                {
                    Ixx[x, y] = Gx[x, y] * Gx[x, y];
                    Iyy[x, y] = Gy[x, y] * Gy[x, y];
                    Ixy[x, y] = Gx[x, y] * Gy[x, y];
                }

            // Harris response
            double[,] cornerCandidates = new double[width, height];
            for (int y = 1; y < height - 1; y++)
                for (int x = 1; x < width - 1; x++)
                {
                    double Sxx = 0, Syy = 0, Sxy = 0;
                    for (int j = -1; j <= 1; j++)
                        for (int i = -1; i <= 1; i++)
                        {
                            double w = gauss[i + 1, j + 1] / sigmaWeight;
                            Sxx += Ixx[x + i, y + j] * w;
                            Syy += Iyy[x + i, y + j] * w;
                            Sxy += Ixy[x + i, y + j] * w;
                        }

                    double det = Sxx * Syy - Sxy * Sxy;
                    double trace = Sxx + Syy;
                    double r = det - kparam * trace * trace;

                    if (r > threshold)
                        cornerCandidates[x, y] = r;
                }

            // Iterative Non-Maximum Suppression
            double[,] cornerNonMax = new double[width, height];
            bool search = true;
            while (search)
            {
                search = false;
                for (int y = 1; y < height - 1; y++)
                    for (int x = 1; x < width - 1; x++)
                    {
                        double val = cornerCandidates[x, y];
                        if (val == 0)
                            continue;

                        bool isMax = true;
                        for (int j = -1; j <= 1; j++)
                            for (int i = -1; i <= 1; i++)
                                if (!(i == 0 && j == 0) && cornerCandidates[x + i, y + j] > val)
                                    isMax = false;

                        if (isMax)
                        {
                            cornerNonMax[x, y] = val;
                        }
                        else
                        {
                            if (val > 0)
                                search = true;
                            cornerNonMax[x, y] = 0;
                        }
                    }

                Array.Copy(cornerNonMax, cornerCandidates, cornerCandidates.Length);
            }

            // Create final binary image: Inew
            Bitmap result = new Bitmap(width, height);
            for (int y = 0; y < height; y++)
                for (int x = 0; x < width; x++)
                {
                    if (cornerCandidates[x, y] > 0)
                        result.SetPixel(x, y, Color.White);  // naro¿nik
                    else
                        result.SetPixel(x, y, Color.Black);  // t³o
                }

            outputBox.Image = result;
        }
    }
}
