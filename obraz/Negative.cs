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
}
