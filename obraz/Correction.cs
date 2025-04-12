using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace obraz
{
    public static class Correction
    {
        public static byte[] LUT = new byte[256];

        public static void transform(int shift, double factor, double gamma)
        {
            for (int i = 0; i < 256; i++)
            {
                double value = i;

                // Jasność
                value += shift;

                // Kontrast
                value *= factor;

                // Gamma (potęgowanie po normalizacji)
                value = Math.Pow(value / 255.0, gamma) * 255.0;

                // Zaokrąglenie i ograniczenie zakresu
                int corrected = (int)Math.Round(value);
                corrected = Math.Max(0, Math.Min(255, corrected));

                LUT[i] = (byte)corrected;
            }
        }
    }
}
