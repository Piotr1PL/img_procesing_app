using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace obraz
{
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
