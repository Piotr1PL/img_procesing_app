public static class IterativeThresholding
{
    public static Bitmap Apply(Bitmap input)
    {
        int width = input.Width;
        int height = input.Height;

        // Konwersja do skali szarości
        byte[,] gray = new byte[width, height];
        for (int y = 0; y < height; y++)
            for (int x = 0; x < width; x++)
            {
                Color c = input.GetPixel(x, y);
                byte grayVal = (byte)(0.299 * c.R + 0.587 * c.G + 0.114 * c.B);
                gray[x, y] = grayVal;
            }

        // 1. Początkowy próg (średnia jasność)
        double T = 0;
        long sum = 0;
        int count = width * height;

        for (int y = 0; y < height; y++)
            for (int x = 0; x < width; x++)
                sum += gray[x, y];

        T = sum / (double)count;
        double newT;

        // 2. Iteracyjna aktualizacja progu
        do
        {
            double sum1 = 0, sum2 = 0;
            int count1 = 0, count2 = 0;

            for (int y = 0; y < height; y++)
                for (int x = 0; x < width; x++)
                {
                    if (gray[x, y] > T)
                    {
                        sum1 += gray[x, y];
                        count1++;
                    }
                    else
                    {
                        sum2 += gray[x, y];
                        count2++;
                    }
                }

            double m1 = count1 > 0 ? sum1 / count1 : 0;
            double m2 = count2 > 0 ? sum2 / count2 : 0;

            newT = (m1 + m2) / 2;

            if (Math.Abs(newT - T) < 0.5)
                break;

            T = newT;

        } while (true);

        // 3. Tworzenie obrazu progowanego
        Bitmap result = new Bitmap(width, height);
        for (int y = 0; y < height; y++)
            for (int x = 0; x < width; x++)
            {
                if (gray[x, y] >= T)
                    result.SetPixel(x, y, Color.White);
                else
                    result.SetPixel(x, y, Color.Black);
            }

        return result;
    }
}
