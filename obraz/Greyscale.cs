using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace obraz
{
    internal class Greyscale
    {
        public Greyscale(PictureBox pictureBox)
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
                        int gray = (int)(0.3 * pixelColor.R + 0.59 * pixelColor.G + 0.11 * pixelColor.B);
                        Color greyscale = Color.FromArgb(gray, gray, gray);
                        bitmap.SetPixel(x, y, greyscale);
                    }
                }

                pictureBox.Image = bitmap;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error during negative conversion: " + ex.Message);
            }
        }
    }
}
