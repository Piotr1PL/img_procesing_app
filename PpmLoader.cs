using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace obraz
{
    public static class PpmLoader
    {
        private const int MaxFileSize = 10 * 1024 * 1024; 
        public static void LoadPpmImage(string filePath, PictureBox pictureBox)
        {
            try
            {
                FileInfo fileInfo = new(filePath);
                if (fileInfo.Length > MaxFileSize)
                {
                    MessageBox.Show("Plik jest za duży. Maksymalny rozmiar to 10 MB.");
                    return;
                }

                using FileStream fs = new(filePath, FileMode.Open, FileAccess.Read);
                using BinaryReader reader = new(fs);
                string magic = ReadToken(reader);
                if (magic == "P2")
                    LoadPgmP2(reader, pictureBox);
                else if (magic == "P5")
                    LoadPgmP5(reader, pictureBox);
                else if (magic == "P3")
                    LoadPpmP3(reader, pictureBox);
                else if (magic == "P6")
                    LoadPpmP6(reader, pictureBox);
                else
                    MessageBox.Show("Nieznany format: " + magic);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Błąd podczas ładowania pliku: " + ex.Message);
            }
        }

        private static string ReadToken(BinaryReader reader)
        {
            List<byte> bytes = [];
            byte b;

            while (true)
            {
                b = reader.ReadByte();
                if (b == '#')
                {
                    while (reader.ReadByte() != '\n') { }
                }
                else if (!char.IsWhiteSpace((char)b))
                {
                    break;
                }
            }
            do
            {
                bytes.Add(b);
                b = reader.ReadByte();
            }
            while (!char.IsWhiteSpace((char)b));

            return Encoding.ASCII.GetString([.. bytes]);
        }

        private static void LoadPgmP2(BinaryReader reader, PictureBox pictureBox)
        {
            try
            {
                int width = int.Parse(ReadToken(reader));
                int height = int.Parse(ReadToken(reader));
                int maxColor = int.Parse(ReadToken(reader));

                Bitmap bitmap = new(width, height);
                for (int y = 0; y < height; y++)
                {
                    for (int x = 0; x < width; x++)
                    {
                        string token = ReadToken(reader);
                        int grayValue = int.Parse(token);
                        grayValue = Math.Max(0, Math.Min(maxColor, grayValue));
                        Color color = Color.FromArgb(grayValue, grayValue, grayValue);
                        bitmap.SetPixel(x, y, color);
                    }
                }

                pictureBox.Image = bitmap;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Błąd PGM: " + ex.Message);
            }
        }

        private static void LoadPgmP5(BinaryReader reader, PictureBox pictureBox)
        {
            try
            {
                int width = int.Parse(ReadToken(reader));
                int height = int.Parse(ReadToken(reader));
                int maxColor = int.Parse(ReadToken(reader));

                Bitmap bitmap = new(width, height);

                for (int y = 0; y < height; y++)
                {
                    for (int x = 0; x < width; x++)
                    {
                        byte grayValue = reader.ReadByte();
                        grayValue = Math.Max((byte)0, Math.Min((byte)maxColor, grayValue));
                        Color color = Color.FromArgb(grayValue, grayValue, grayValue);
                        bitmap.SetPixel(x, y, color);
                    }
                }

                pictureBox.Image = bitmap;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Błąd PGM P5: " + ex.Message);
            }
        }

        private static void LoadPpmP3(BinaryReader reader, PictureBox pictureBox)
        {
            try
            {
                int width = int.Parse(ReadToken(reader));
                int height = int.Parse(ReadToken(reader));
                int maxColor = int.Parse(ReadToken(reader));

                Bitmap bitmap = new(width, height);
                for (int y = 0; y < height; y++)
                {
                    for (int x = 0; x < width; x++)
                    {
                        int r = int.Parse(ReadToken(reader));
                        int g = int.Parse(ReadToken(reader));
                        int b = int.Parse(ReadToken(reader));
                        r = Math.Max(0, Math.Min(maxColor, r));
                        g = Math.Max(0, Math.Min(maxColor, g));
                        b = Math.Max(0, Math.Min(maxColor, b));
                        bitmap.SetPixel(x, y, Color.FromArgb(r, g, b));
                    }
                }

                pictureBox.Image = bitmap;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Błąd PPM P3: " + ex.Message);
            }
        }
        private static void LoadPpmP6(BinaryReader reader, PictureBox pictureBox)
        {
            try
            {
                int width = int.Parse(ReadToken(reader));
                int height = int.Parse(ReadToken(reader));
                int maxColor = int.Parse(ReadToken(reader));
                while (char.IsWhiteSpace((char)reader.PeekChar()))
                    reader.ReadByte();

                Bitmap bitmap = new (width, height);

                for (int y = 0; y < height; y++)
                {
                    for (int x = 0; x < width; x++)
                    {
                        byte r = reader.ReadByte();
                        byte g = reader.ReadByte();
                        byte b = reader.ReadByte();
                        bitmap.SetPixel(x, y, Color.FromArgb(r, g, b));
                    }
                }

                pictureBox.Image = bitmap;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Błąd PPM P6: " + ex.Message);
            }
        }

        
    }
}
