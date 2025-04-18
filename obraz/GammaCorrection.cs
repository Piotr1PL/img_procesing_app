using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace obraz
{
    internal class GammaCorrection
    {
        public static void ApplyGammaCorrection(PictureBox inputBox, PictureBox outputBox, float t)
        {
            if (inputBox.Image == null) return;

            Bitmap original = new(inputBox.Image);
            Bitmap modified = new(original.Width, original.Height);

            float gamma = (float)(0.1 + (5.0f - 0.1f) * t);

            int[] lut = new int[256];
            for (int i = 0; i < 256; i++)
            {
                float normalized = i / 255f;
                float corrected = (float)Math.Pow(normalized, 1.0f / gamma);
                lut[i] = Math.Clamp((int)(corrected * 255), 0, 255);
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
    }
}
