using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace obraz
{
    internal class WatershedTransform
    {
        private const int BACKGROUND = -1;
        private const int UNLABELLED = -2;
        private const int WSHED = 0;

        public static void Run(PictureBox inputBox, PictureBox outputBox, int binThreshold = 90)
        {
            if (inputBox.Image == null)
            {
                MessageBox.Show("Brak obrazu wejściowego.");
                return;
            }

            Bitmap gray = ToGrayscale(new Bitmap(inputBox.Image));
            Bitmap blurred = ApplyMedianFilter(gray, 3);

            int width = gray.Width, height = gray.Height;
            int[,] labels = new int[width, height];
            int nextLabel = 1;

            // Binarizacja
            for (int y = 0; y < height; y++)
                for (int x = 0; x < width; x++)
                {
                    int g = blurred.GetPixel(x, y).R;
                    labels[x, y] = (g < binThreshold) ? BACKGROUND : UNLABELLED;
                }

            // Segmentacja flood fill
            for (int y = 0; y < height; y++)
                for (int x = 0; x < width; x++)
                    if (labels[x, y] == UNLABELLED)
                        FloodFill(blurred, labels, x, y, nextLabel++);

            // Tworzenie listy pikseli posortowanych po intensywności
            var pixels = new List<(int x, int y, int val)>();
            for (int y = 0; y < height; y++)
                for (int x = 0; x < width; x++)
                    pixels.Add((x, y, blurred.GetPixel(x, y).R));
            pixels.Sort((a, b) => a.val.CompareTo(b.val));

            // Relabelowanie
            foreach (var (x, y, _) in pixels)
                RelabelNeighborhood(labels, x, y);

            // Wizualizacja
            Bitmap result = new Bitmap(width, height);
            Dictionary<int, byte> regionShades = new Dictionary<int, byte>();
            int shadeStep = 255 / (nextLabel + 1);
            int shade = 30;

            for (int y = 0; y < height; y++)
                for (int x = 0; x < width; x++)
                {
                    int lbl = labels[x, y];
                    byte g;

                    if (lbl == BACKGROUND)
                        g = 255;
                    else if (lbl == WSHED)
                        g = 0;
                    else
                    {
                        if (!regionShades.ContainsKey(lbl))
                        {
                            regionShades[lbl] = (byte)Math.Min(shade, 250);
                            shade += shadeStep;
                        }
                        g = regionShades[lbl];
                    }

                    result.SetPixel(x, y, Color.FromArgb(g, g, g));
                }

            outputBox.Image = result;
        }

        private static Bitmap ToGrayscale(Bitmap bmp)
        {
            Bitmap gray = new Bitmap(bmp.Width, bmp.Height);
            for (int y = 0; y < bmp.Height; y++)
                for (int x = 0; x < bmp.Width; x++)
                {
                    Color c = bmp.GetPixel(x, y);
                    int g = (int)(0.3 * c.R + 0.59 * c.G + 0.11 * c.B);
                    gray.SetPixel(x, y, Color.FromArgb(g, g, g));
                }
            return gray;
        }

        private static Bitmap ApplyMedianFilter(Bitmap src, int size)
        {
            Bitmap dest = new Bitmap(src.Width, src.Height);
            int r = size / 2;

            for (int y = 0; y < src.Height; y++)
                for (int x = 0; x < src.Width; x++)
                {
                    List<int> values = new List<int>();
                    for (int dy = -r; dy <= r; dy++)
                        for (int dx = -r; dx <= r; dx++)
                        {
                            int nx = x + dx;
                            int ny = y + dy;
                            if (nx >= 0 && ny >= 0 && nx < src.Width && ny < src.Height)
                                values.Add(src.GetPixel(nx, ny).R);
                        }
                    values.Sort();
                    int median = values[values.Count / 2];
                    dest.SetPixel(x, y, Color.FromArgb(median, median, median));
                }

            return dest;
        }

        private static void FloodFill(Bitmap gray, int[,] labels, int x, int y, int label)
        {
            int width = gray.Width, height = gray.Height;
            byte target = gray.GetPixel(x, y).R;
            var q = new Queue<(int x, int y)>();
            q.Enqueue((x, y));
            labels[x, y] = label;

            int[][] dirs = new int[][] {
                new int[] {1, 0},
                new int[] {-1, 0},
                new int[] {0, 1},
                new int[] {0, -1}
            };

            while (q.Count > 0)
            {
                var (cx, cy) = q.Dequeue();
                foreach (var dir in dirs)
                {
                    int nx = cx + dir[0], ny = cy + dir[1];
                    if (nx >= 0 && ny >= 0 && nx < width && ny < height &&
                        labels[nx, ny] == UNLABELLED && gray.GetPixel(nx, ny).R == target)
                    {
                        labels[nx, ny] = label;
                        q.Enqueue((nx, ny));
                    }
                }
            }
        }

        private static void RelabelNeighborhood(int[,] labels, int x, int y)
        {
            int width = labels.GetLength(0), height = labels.GetLength(1);
            int current = labels[x, y];
            int newLabel = current;

            int[][] dirs = new int[][] {
                new int[] {1, 0},
                new int[] {-1, 0},
                new int[] {0, 1},
                new int[] {0, -1}
            };

            foreach (var dir in dirs)
            {
                int nx = x + dir[0], ny = y + dir[1];
                if (nx >= 0 && ny >= 0 && nx < width && ny < height)
                {
                    int neighbor = labels[nx, ny];
                    if (current == UNLABELLED && neighbor > 0)
                        newLabel = neighbor;
                    else if (neighbor > 0 && current > 0 && neighbor != current)
                        newLabel = WSHED;
                }
            }

            labels[x, y] = newLabel;
        }
    }
}
