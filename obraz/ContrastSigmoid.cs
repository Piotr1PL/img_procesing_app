using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace obraz
{
    internal class ContrastSigmoid
    {
        public static void ApplySigmoidContrast(PictureBox inputBox, PictureBox outputBox, float t)
        {
            if (inputBox.Image == null) return;

            Bitmap original = new(inputBox.Image);
            Bitmap modified = new(original.Width, original.Height);

            float a = (t - 0.5f) * 20f;
            int[] lut = new int[256];
            for (int i = 0; i < 256; i++)
            {
                lut[i] = ApplySigmoid(i, a);
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

        private static int ApplySigmoid(int value, float a)
        {
            float normalized = value / 255f;
            float sigmoid = 1f / (1f + (float)Math.Exp(-a * (normalized - 0.5f)));
            return Clamp((int)(sigmoid * 255f));
        }

        private static int Clamp(int value)
        {
            return Math.Max(0, Math.Min(255, value));
        }
    }
}
