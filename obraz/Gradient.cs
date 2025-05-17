using System;
using System.Drawing;
using System.Windows.Forms;

public class Gradient
{
    public Gradient()
    {
        
    }
    public static void ApplyRobertsFilter(PictureBox inputBox, PictureBox outputBox)
    {
        if (inputBox.Image == null) return;

        Bitmap original = new Bitmap(inputBox.Image);
        Bitmap output = new Bitmap(original.Width, original.Height);

        int width = original.Width;
        int height = original.Height;

        int[,] gx = new int[,] { { 1, 0 }, { 0, -1 } };
        int[,] gy = new int[,] { { 0, 1 }, { -1, 0 } };

        for (int y = 0; y < height - 1; y++)
        {
            for (int x = 0; x < width - 1; x++)
            {
                Color c1 = original.GetPixel(x, y);
                Color c2 = original.GetPixel(x + 1, y);
                Color c3 = original.GetPixel(x, y + 1);
                Color c4 = original.GetPixel(x + 1, y + 1);

                int rx = c1.R * gx[0, 0] + c2.R * gx[0, 1] + c3.R * gx[1, 0] + c4.R * gx[1, 1];
                int ry = c1.R * gy[0, 0] + c2.R * gy[0, 1] + c3.R * gy[1, 0] + c4.R * gy[1, 1];
                int r = (int)Math.Sqrt(rx * rx + ry * ry);

                int gxv = c1.G * gx[0, 0] + c2.G * gx[0, 1] + c3.G * gx[1, 0] + c4.G * gx[1, 1];
                int gyv = c1.G * gy[0, 0] + c2.G * gy[0, 1] + c3.G * gy[1, 0] + c4.G * gy[1, 1];
                int g = (int)Math.Sqrt(gxv * gxv + gyv * gyv);

                int bx = c1.B * gx[0, 0] + c2.B * gx[0, 1] + c3.B * gx[1, 0] + c4.B * gx[1, 1];
                int by = c1.B * gy[0, 0] + c2.B * gy[0, 1] + c3.B * gy[1, 0] + c4.B * gy[1, 1];
                int b = (int)Math.Sqrt(bx * bx + by * by);

                r = Math.Clamp(r, 0, 255);
                g = Math.Clamp(g, 0, 255);
                b = Math.Clamp(b, 0, 255);

                output.SetPixel(x, y, Color.FromArgb(r, g, b));
            }
        }

        outputBox.Image = output;
    }
    public static void ApplyPrewittFilter(PictureBox inputBox, PictureBox outputBox)
    {
        if (inputBox.Image == null) return;

        Bitmap original = new Bitmap(inputBox.Image);
        Bitmap output = new Bitmap(original.Width, original.Height);

        int width = original.Width;
        int height = original.Height;

        int[,] gx = new int[,]
        {
            { -1, 0, 1 },
            { -1, 0, 1 },
            { -1, 0, 1 }
        };

        int[,] gy = new int[,]
        {
            { 1, 1, 1 },
            { 0, 0, 0 },
            { -1, -1, -1 }
        };

        for (int y = 1; y < height - 1; y++)
        {
            for (int x = 1; x < width - 1; x++)
            {
                int rX = 0, rY = 0;
                int gX = 0, gY = 0;
                int bX = 0, bY = 0;

                for (int ky = -1; ky <= 1; ky++)
                {
                    for (int kx = -1; kx <= 1; kx++)
                    {
                        Color pixel = original.GetPixel(x + kx, y + ky);

                        int kxVal = gx[ky + 1, kx + 1];
                        int kyVal = gy[ky + 1, kx + 1];

                        rX += pixel.R * kxVal;
                        rY += pixel.R * kyVal;

                        gX += pixel.G * kxVal;
                        gY += pixel.G * kyVal;

                        bX += pixel.B * kxVal;
                        bY += pixel.B * kyVal;
                    }
                }

                int r = (int)Math.Sqrt(rX * rX + rY * rY);
                int g = (int)Math.Sqrt(gX * gX + gY * gY);
                int b = (int)Math.Sqrt(bX * bX + bY * bY);

                r = Math.Clamp(r, 0, 255);
                g = Math.Clamp(g, 0, 255);
                b = Math.Clamp(b, 0, 255);

                output.SetPixel(x, y, Color.FromArgb(r, g, b));
            }
        }

        outputBox.Image = output;
    }
    public static void ApplySobelFilter(PictureBox inputBox, PictureBox outputBox)
    {
        if (inputBox.Image == null) return;

        Bitmap original = new Bitmap(inputBox.Image);
        Bitmap output = new Bitmap(original.Width, original.Height);

        int width = original.Width;
        int height = original.Height;

        int[,] gx = new int[,]
        {
            { -1, 0, 1 },
            { -2, 0, 2 },
            { -1, 0, 1 }
        };

        int[,] gy = new int[,]
        {
            { 1, 2, 1 },
            { 0, 0, 0 },
            { -1, -2, -1 }
        };

        for (int y = 1; y < height - 1; y++)
        {
            for (int x = 1; x < width - 1; x++)
            {
                int rX = 0, rY = 0;
                int gX = 0, gY = 0;
                int bX = 0, bY = 0;

                for (int ky = -1; ky <= 1; ky++)
                {
                    for (int kx = -1; kx <= 1; kx++)
                    {
                        Color pixel = original.GetPixel(x + kx, y + ky);

                        int kxVal = gx[ky + 1, kx + 1];
                        int kyVal = gy[ky + 1, kx + 1];

                        rX += pixel.R * kxVal;
                        rY += pixel.R * kyVal;

                        gX += pixel.G * kxVal;
                        gY += pixel.G * kyVal;

                        bX += pixel.B * kxVal;
                        bY += pixel.B * kyVal;
                    }
                }

                int r = (int)Math.Sqrt(rX * rX + rY * rY);
                int g = (int)Math.Sqrt(gX * gX + gY * gY);
                int b = (int)Math.Sqrt(bX * bX + bY * bY);

                r = Math.Clamp(r, 0, 255);
                g = Math.Clamp(g, 0, 255);
                b = Math.Clamp(b, 0, 255);

                output.SetPixel(x, y, Color.FromArgb(r, g, b));
            }
        }

        outputBox.Image = output;
    }
    public static void ApplyLaplacianFilter(PictureBox inputBox, PictureBox outputBox)
    {
        if (inputBox.Image == null) return;

        Bitmap original = new Bitmap(inputBox.Image);
        Bitmap output = new Bitmap(original.Width, original.Height);

        int width = original.Width;
        int height = original.Height;

        int[,] kernel = new int[,]
        {
        { 0, -1, 0 },
        { -1, 4, -1 },
        { 0, -1, 0 }
        };

        for (int y = 1; y < height - 1; y++)
        {
            for (int x = 1; x < width - 1; x++)
            {
                int r = 0, g = 0, b = 0;

                for (int ky = -1; ky <= 1; ky++)
                {
                    for (int kx = -1; kx <= 1; kx++)
                    {
                        Color pixel = original.GetPixel(x + kx, y + ky);
                        int kernelVal = kernel[ky + 1, kx + 1];

                        r += pixel.R * kernelVal;
                        g += pixel.G * kernelVal;
                        b += pixel.B * kernelVal;
                    }
                }

                r = Math.Clamp(Math.Abs(r), 0, 255);
                g = Math.Clamp(Math.Abs(g), 0, 255);
                b = Math.Clamp(Math.Abs(b), 0, 255);

                output.SetPixel(x, y, Color.FromArgb(r, g, b));
            }
        }

        outputBox.Image = output;
    }
    private static double[,] ConvertToGrayscale(Bitmap image)
{
    int width = image.Width;
    int height = image.Height;
    double[,] gray = new double[width, height];

    for (int y = 0; y < height; y++)
        for (int x = 0; x < width; x++)
        {
            Color c = image.GetPixel(x, y);
            gray[x, y] = 0.299 * c.R + 0.587 * c.G + 0.114 * c.B;
        }

    return gray;
}

private static double[,] Convolve(double[,] input, double[,] kernel)
{
    int width = input.GetLength(0);
    int height = input.GetLength(1);
    int kWidth = kernel.GetLength(0);
    int kHeight = kernel.GetLength(1);
    int kHalfW = kWidth / 2;
    int kHalfH = kHeight / 2;

    double[,] output = new double[width, height];

    for (int y = kHalfH; y < height - kHalfH; y++)
    {
        for (int x = kHalfW; x < width - kHalfW; x++)
        {
            double sum = 0;
            for (int ky = -kHalfH; ky <= kHalfH; ky++)
            {
                for (int kx = -kHalfW; kx <= kHalfW; kx++)
                {
                    sum += input[x + kx, y + ky] * kernel[kx + kHalfW, ky + kHalfH];
                }
            }
            output[x, y] = sum;
        }
    }

    return output;
}

    public static void ApplyZeroCrossingFilter(PictureBox inputBox, PictureBox outputBox, double alpha = 1.6, int threshold = 5)
    {
        if (inputBox.Image == null) return;

        Bitmap original = new Bitmap(inputBox.Image);
        int width = original.Width;
        int height = original.Height;
        double[,] kernel = new double[,]
        {
        { 0, 1, 0 },
        { 1, -4 * alpha, 1 },
        { 0, 1, 0 }
        };
        double[,,] channels = new double[3, width, height]; 

        for (int c = 0; c < 3; c++)
        {
            for (int y = 1; y < height - 1; y++)
            {
                for (int x = 1; x < width - 1; x++)
                {
                    double sum = 0;

                    for (int ky = -1; ky <= 1; ky++)
                    {
                        for (int kx = -1; kx <= 1; kx++)
                        {
                            Color pixel = original.GetPixel(x + kx, y + ky);
                            int val = (c == 0) ? pixel.R : (c == 1) ? pixel.G : pixel.B;
                            sum += val * kernel[ky + 1, kx + 1];
                        }
                    }

                    channels[c, x, y] = sum;
                }
            }
        }
        Bitmap result = new Bitmap(width, height);

        for (int y = 1; y < height - 1; y++)
        {
            for (int x = 1; x < width - 1; x++)
            {
                bool edgeDetected = false;

                for (int c = 0; c < 3; c++)
                {
                    double v0 = channels[c, x, y];
                    double[] neighbors = {
                    channels[c, x - 1, y],
                    channels[c, x + 1, y],
                    channels[c, x, y - 1],
                    channels[c, x, y + 1]
                };

                    foreach (var v in neighbors)
                    {
                        if (Math.Abs(v - v0) > threshold && v * v0 < 0)
                        {
                            edgeDetected = true;
                            break;
                        }
                    }

                    if (edgeDetected) break;
                }

                result.SetPixel(x, y, edgeDetected ? Color.Gray : Color.Black);
            }
        }

        outputBox.Image = result;
    }


    public static void ApplyCannyEdgeDetection(PictureBox inputBox, PictureBox outputBox, double lowThreshold = 20, double highThreshold = 50)
    {
        if (inputBox.Image == null) return;

        Bitmap original = new Bitmap(inputBox.Image);
        int width = original.Width;
        int height = original.Height;
        double[,] gray = ConvertToGrayscale(original, width, height);
        double[,] gaussian = GaussianBlur(gray, width, height);
        double[,] gradX, gradY;
        double[,] gradient = ComputeGradient(gaussian, width, height, out gradX, out gradY);
        double[,] direction = ComputeGradientDirection(gradX, gradY, width, height);
        double[,] suppressed = NonMaximumSuppression(gradient, direction, width, height);
        Bitmap result = HysteresisThresholding(suppressed, direction, lowThreshold, highThreshold, width, height);
        outputBox.Image = result;
    }

    private static double[,] ConvertToGrayscale(Bitmap image, int width, int height)
    {
        double[,] gray = new double[width, height];
        for (int y = 0; y < height; y++)
            for (int x = 0; x < width; x++)
            {
                Color c = image.GetPixel(x, y);
                gray[x, y] = 0.299 * c.R + 0.587 * c.G + 0.114 * c.B;
            }
        return gray;
    }

    private static double[,] GaussianBlur(double[,] input, int width, int height)
    {
        double[,] kernel = {
            { 2, 4, 5, 4, 2 },
            { 4, 9,12, 9, 4 },
            { 5,12,15,12, 5 },
            { 4, 9,12, 9, 4 },
            { 2, 4, 5, 4, 2 }
        };
        double kernelSum = 159.0;
        double[,] output = new double[width, height];

        for (int y = 2; y < height - 2; y++)
        {
            for (int x = 2; x < width - 2; x++)
            {
                double sum = 0;
                for (int ky = -2; ky <= 2; ky++)
                    for (int kx = -2; kx <= 2; kx++)
                        sum += input[x + kx, y + ky] * kernel[ky + 2, kx + 2];
                output[x, y] = sum / kernelSum;
            }
        }

        return output;
    }

    private static double[,] ComputeGradient(double[,] input, int width, int height, out double[,] gradX, out double[,] gradY)
    {
        int[,] sobelX = {
            { -1, 0, 1 },
            { -2, 0, 2 },
            { -1, 0, 1 }
        };
        int[,] sobelY = {
            { 1, 2, 1 },
            { 0, 0, 0 },
            { -1, -2, -1 }
        };

        gradX = new double[width, height];
        gradY = new double[width, height];
        double[,] gradient = new double[width, height];

        for (int y = 1; y < height - 1; y++)
        {
            for (int x = 1; x < width - 1; x++)
            {
                double gx = 0, gy = 0;

                for (int ky = -1; ky <= 1; ky++)
                    for (int kx = -1; kx <= 1; kx++)
                    {
                        gx += input[x + kx, y + ky] * sobelX[ky + 1, kx + 1];
                        gy += input[x + kx, y + ky] * sobelY[ky + 1, kx + 1];
                    }

                gradX[x, y] = gx;
                gradY[x, y] = gy;
                gradient[x, y] = Math.Sqrt(gx * gx + gy * gy);
            }
        }

        return gradient;
    }

    private static double[,] ComputeGradientDirection(double[,] gradX, double[,] gradY, int width, int height)
    {
        double[,] direction = new double[width, height];
        for (int y = 0; y < height; y++)
            for (int x = 0; x < width; x++)
                direction[x, y] = Math.Atan2(gradY[x, y], gradX[x, y]) * 180.0 / Math.PI;

        return direction;
    }

    private static double[,] NonMaximumSuppression(double[,] gradient, double[,] direction, int width, int height)
    {
        double[,] suppressed = new double[width, height];

        for (int y = 1; y < height - 1; y++)
        {
            for (int x = 1; x < width - 1; x++)
            {
                double angle = direction[x, y];
                angle = (angle + 180) % 180;

                double g = gradient[x, y];
                double g1 = 0, g2 = 0;
                if ((angle >= 0 && angle < 22.5) || (angle >= 157.5 && angle <= 180))
                {
                    g1 = gradient[x - 1, y];
                    g2 = gradient[x + 1, y];
                }
                else if (angle >= 22.5 && angle < 67.5)
                {
                    g1 = gradient[x - 1, y - 1];
                    g2 = gradient[x + 1, y + 1];
                }
                else if (angle >= 67.5 && angle < 112.5)
                {
                    g1 = gradient[x, y - 1];
                    g2 = gradient[x, y + 1];
                }
                else if (angle >= 112.5 && angle < 157.5)
                {
                    g1 = gradient[x + 1, y - 1];
                    g2 = gradient[x - 1, y + 1];
                }

                if (g >= g1 && g >= g2)
                    suppressed[x, y] = g;
                else
                    suppressed[x, y] = 0;
            }
        }

        return suppressed;
    }

    private static Bitmap HysteresisThresholding(double[,] suppressed, double[,] direction, double low, double high, int width, int height)
    {
        Bitmap result = new Bitmap(width, height);

        bool[,] strong = new bool[width, height];
        bool[,] weak = new bool[width, height];

        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                double val = suppressed[x, y];
                if (val >= high)
                    strong[x, y] = true;
                else if (val >= low)
                    weak[x, y] = true;
            }
        }
        for (int y = 1; y < height - 1; y++)
        {
            for (int x = 1; x < width - 1; x++)
            {
                if (weak[x, y])
                {
                    bool connected = false;
                    for (int j = -1; j <= 1 && !connected; j++)
                    {
                        for (int i = -1; i <= 1; i++)
                        {
                            if (strong[x + i, y + j])
                            {
                                connected = true;
                                break;
                            }
                        }
                    }
                    if (connected)
                        result.SetPixel(x, y, Color.Gray); 
                    else
                        result.SetPixel(x, y, Color.Black); 
                }
                else if (strong[x, y])
                {
                    result.SetPixel(x, y, Color.Gray);
                }
                else
                {
                    result.SetPixel(x, y, Color.Black);
                }
            }
        }

        return result;
    }

}
 