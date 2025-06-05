using System;
using System.Collections.Generic;
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

            // Krok 1: Skala szarości
            new Greyscale(inputBox, outputBox);

            // Krok 2: Filtr Laplace’a na wyniku Greyscale
            Gradient.ApplyLaplacianFilter(outputBox, outputBox);

            // Krok 3: Transformacja Hougha (klasyczna) – detekcja linii
            Bitmap edgeImage = new Bitmap(outputBox.Image);
            int width = edgeImage.Width;
            int height = edgeImage.Height;

            int diagonal = (int)Math.Ceiling(Math.Sqrt(width * width + height * height));
            int[,] accumulator = new int[2 * diagonal, 180];

            // Przejście po pikselach i uzupełnianie akumulatora
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    Color color = edgeImage.GetPixel(x, y);
                    if (color.R > 128) // Próg - Laplacian daje białe linie
                    {
                        for (int theta = 0; theta < 180; theta++)
                        {
                            double radians = theta * Math.PI / 180.0;
                            int r = (int)(x * Math.Cos(radians) + y * Math.Sin(radians));
                            r += diagonal; // przesunięcie żeby uniknąć ujemnych indeksów
                            if (r >= 0 && r < 2 * diagonal)
                                accumulator[r, theta]++;
                        }
                    }
                }
            }

            // Krok 4: Znalezienie linii o największej liczbie głosów
            List<(int r, int theta)> lines = new List<(int r, int theta)>();
            int threshold = 100; // można dobrać doświadczalnie

            for (int r = 0; r < 2 * diagonal; r++)
            {
                for (int theta = 0; theta < 180; theta++)
                {
                    if (accumulator[r, theta] > threshold)
                    {
                        lines.Add((r - diagonal, theta));
                    }
                }
            }

            // Krok 5: Rysowanie wykrytych linii na kopii oryginału
            Bitmap result = new Bitmap(inputBox.Image);
            using (Graphics g = Graphics.FromImage(result))
            {
                Pen pen = new Pen(Color.Red, 1);

                foreach (var (r, theta) in lines)
                {
                    double radians = theta * Math.PI / 180.0;
                    double cosT = Math.Cos(radians);
                    double sinT = Math.Sin(radians);

                    // punkty przecięcia linii z krawędziami obrazu
                    Point pt1 = new Point();
                    Point pt2 = new Point();

                    if (sinT != 0)
                    {
                        pt1.X = 0;
                        pt1.Y = (int)(r / sinT);

                        pt2.X = width;
                        pt2.Y = (int)((r - width * cosT) / sinT);
                    }
                    else
                    {
                        pt1.X = (int)(r / cosT);
                        pt1.Y = 0;

                        pt2.X = (int)(r / cosT);
                        pt2.Y = height;
                    }

                    g.DrawLine(pen, pt1, pt2);
                }
            }

            outputBox.Image = result;
        }
    }
}
