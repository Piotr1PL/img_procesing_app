using System.Drawing;
using System.Windows.Forms;

public static class ManualThresholding
{

    public static void Apply(PictureBox inputBox, PictureBox outputBox, byte threshold)
    {
        if (inputBox.Image == null) return;

        Bitmap original = new Bitmap(inputBox.Image);
        int width = original.Width;
        int height = original.Height;
        Bitmap result = new Bitmap(width, height);

        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                Color pixel = original.GetPixel(x, y);
                byte gray = (byte)(0.299 * pixel.R + 0.587 * pixel.G + 0.114 * pixel.B);
                Color binaryColor = gray < threshold ? Color.Black : Color.White;
                result.SetPixel(x, y, binaryColor);
            }
        }

        outputBox.Image = result;
    }
}

