using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace obraz
{
    internal class Negative
    {
        public static void InvertImage(PictureBox pictureBox, PictureBox pictureBox2)
        {
            try
            {
                Bitmap? bitmap = pictureBox.Image as Bitmap;
                if (bitmap == null)
                {
                    MessageBox.Show("No image to process.");
                    return;
                }
                for (int y = 0; y < bitmap.Height; y++)
                {
                    for (int x = 0; x < bitmap.Width; x++)
                    {
                        Color pixelColor = bitmap.GetPixel(x, y);
                        Color invertedColor = Color.FromArgb(255 - pixelColor.R, 255 - pixelColor.G, 255 - pixelColor.B);
                        bitmap.SetPixel(x, y, invertedColor);
                    }
                }

                pictureBox2.Image = bitmap;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error during negative conversion: " + ex.Message);
            }
        }
    }
    internal class NegativeGrayscale
    {
        public static void InvertGrayscaleImage(PictureBox pictureBox, PictureBox pictureBox2)
        {
            try
            {
                Bitmap? bitmap = pictureBox.Image as Bitmap;
                if (bitmap == null)
                {
                    MessageBox.Show("No image to process.");
                    return;
                }

                for (int y = 0; y < bitmap.Height; y++)
                {
                    for (int x = 0; x < bitmap.Width; x++)
                    {
                        Color pixelColor = bitmap.GetPixel(x, y);
                        int invertedGray = 255 - pixelColor.R;

                        Color invertedColor = Color.FromArgb(invertedGray, invertedGray, invertedGray);
                        bitmap.SetPixel(x, y, invertedColor);
                    }
                }

                pictureBox2.Image = bitmap;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error during grayscale negative conversion: " + ex.Message);
            }
        }
    }
    internal class Greyscale
    {
        public Greyscale(PictureBox box1, PictureBox box2)
        {
            try
            {
                Bitmap? original = box1.Image as Bitmap;
                if (original == null)
                {
                    MessageBox.Show("No image to process.");
                    return;
                }

                Bitmap greyscaleBitmap = new Bitmap(original.Width, original.Height);

                for (int y = 0; y < original.Height; y++)
                {
                    for (int x = 0; x < original.Width; x++)
                    {
                        Color pixelColor = original.GetPixel(x, y);
                        int gray = (int)(0.3 * pixelColor.R + 0.59 * pixelColor.G + 0.11 * pixelColor.B);
                        Color greyscale = Color.FromArgb(gray, gray, gray);
                        greyscaleBitmap.SetPixel(x, y, greyscale);
                    }
                }

                box2.Image = greyscaleBitmap;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error during greyscale conversion: " + ex.Message);
            }
        }
    }

}
