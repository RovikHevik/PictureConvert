using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;

namespace PictureConvert.Logic
{
    static class ImageLogic
    {
        /// <summary>
        /// Color list for color correction
        /// </summary>
        private static Color[] colorList = new Color[]
        {
            Color.FromArgb(0, 0, 0), 
            Color.FromArgb(0, 0, 255),
            Color.FromArgb(0, 234, 255),
            Color.FromArgb(0, 255, 0),
            Color.FromArgb(170, 0, 255),
            Color.FromArgb(235, 115, 115),
            Color.FromArgb(255, 0, 157),
            Color.FromArgb(255, 132, 0),
            Color.FromArgb(255, 223, 196),
            Color.FromArgb(255, 238, 0),
            Color.FromArgb(255, 255, 255),
            Color.FromArgb(165, 120, 92),
            Color.FromArgb(255, 97, 97),
            Color.FromArgb(27, 54, 56),
            Color.FromArgb(29, 56, 27),
            Color.FromArgb(43, 255, 0),
            Color.FromArgb(53, 56, 27),
            Color.FromArgb(201, 112, 100),
            Color.FromArgb(56, 28, 27),
            Color.FromArgb(194, 159, 127),
            Color.FromArgb(204, 145, 131),
            Color.FromArgb(133, 87, 72),
            Color.FromArgb(107, 70, 60),
            Color.FromArgb(72, 15, 77),
            Color.FromArgb(45, 46, 50),
            Color.FromArgb(255, 0, 0),
        };

        public static Bitmap ImageWithCode(Bitmap image)
        {
            Bitmap result = ResizeImage((Bitmap)image.Clone(), 2480, 3508);
            Graphics g = Graphics.FromImage(result);
            int xNum = 70;
            int yNum = 99;
            int xSize = result.Width / xNum;
            int ySize = result.Height / yNum;
            Pen blackPen = new Pen(Color.Black, 1);

            for (int x = xSize; x < result.Width; x = x + xSize)
            {
                PointF pointOne = new PointF(x, result.Height);
                PointF pointTwo = new PointF(x, 0);
                g.DrawLine(blackPen, pointOne, pointTwo);
            }
            for (int y = ySize; y < result.Height; y = y + xSize)
            {
                PointF pointOne = new PointF(result.Width, y);
                PointF pointTwo = new PointF(0, y);
                g.DrawLine(blackPen, pointOne, pointTwo);
            }
            int secondX = 1;
            for (int x = 0; x < image.Width; x++)
            {
                int secondY = 1;
                for (int y = 0; y < image.Height; y++)
                {
                    int ColorNum = 0;
                    Brush tempBrush = new SolidBrush(Color.White);
                    Color tempColor = Color.FromArgb(255, 255, 255);
                    double tempNum = int.MaxValue;
                    for (int a = 0; a < colorList.Length; a++)
                    {
                        var chromaticDistance = getChromaticDistance(image.GetPixel(x, y), colorList[a]);
                        if (chromaticDistance < tempNum)
                        {
                            tempColor = colorList[a];
                            tempNum = chromaticDistance;
                            ColorNum = a;
                        }
                        if (getChromaticDistance(image.GetPixel(x, y), Color.FromArgb(0, 0, 0)) > getChromaticDistance(image.GetPixel(x, y), Color.FromArgb(255, 255, 255)))
                        {
                            tempBrush = Brushes.Black;
                        }
                    }
                    g.DrawString(ColorNum.ToString(), new Font("Calibri", 20), tempBrush, secondX, secondY);
                    secondY += 35;
                }
                secondX += 35;
            }
            return result;
        }

        /// <summary>
        /// Resize the image to the specified width and height.
        /// </summary>
        /// <param name="image">The image to resize.</param>
        /// <returns>The resized image.</returns>
        public static Bitmap ResizeImage(Image image, int width, int height)
        {
            double oldWidth = image.Width;
            double oldHeight = image.Height;

            var widthRatio = width / oldWidth;
            var heightRatio = height / oldHeight;

            var factor = Math.Min(widthRatio, heightRatio);
            var destRect = new Rectangle(0, 0, (int)(factor * oldWidth), (int)(factor * oldHeight));
            var destImage = new Bitmap(width, height);

            destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            using (var graphics = Graphics.FromImage(destImage))
            {
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                using (var wrapMode = new ImageAttributes())
                {
                    /// TODO make good not strach
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                    graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }

            return destImage;
        }

        /// <summary>
        /// Change image pixel to need.
        /// </summary>
        /// <param name="image">The image to change.</param>
        /// <returns>Ready image.</returns>
        public static Bitmap MagicImage(Bitmap image)
        {
            colorList = AnalizColor((Bitmap)image.Clone());
            for(int x = 1; x < image.Width; x++)
            {
                for (int y = 1; y < image.Height; y++)
                {
                    Color tempColor = Color.FromArgb(255, 255, 255);
                    double tempNum = int.MaxValue;
                    for (int a = 0; a < colorList.Length; a++)
                    {
                        if(getChromaticDistance(image.GetPixel(x, y), colorList[a]) < tempNum)
                        {
                            tempColor = colorList[a];
                            tempNum = getChromaticDistance(image.GetPixel(x, y), colorList[a]);
                        }                      
                    }
                    image.SetPixel(x, y, tempColor);
                }
            }
            return image;
        }

        /// <summary>
        /// Make chromatic image.
        /// </summary>
        /// <param name="imageInput">Input image.</param>
        /// <returns>Chromatic image</returns>
        public static Bitmap ChromaticImage(Bitmap imageInput)
        {
            PixelFormat pxf = PixelFormat.Format24bppRgb;
            Rectangle rect = new Rectangle(0, 0, imageInput.Width, imageInput.Height);
            BitmapData bmpData = imageInput.LockBits(rect, ImageLockMode.ReadWrite, pxf);
            IntPtr ptr = bmpData.Scan0;
            int numBytes = bmpData.Stride * imageInput.Height;
            int widthBytes = bmpData.Stride;
            byte[] rgbValues = new byte[numBytes];
            Marshal.Copy(ptr, rgbValues, 0, numBytes);

            for (int counter = 0; counter < rgbValues.Length; counter += 3)
            {

                int value = rgbValues[counter] + rgbValues[counter + 1] + rgbValues[counter + 2];
                byte color_b = 0;

                color_b = Convert.ToByte(value / 3);


                rgbValues[counter] = color_b;
                rgbValues[counter + 1] = color_b;
                rgbValues[counter + 2] = color_b;

            }
            Marshal.Copy(rgbValues, 0, ptr, numBytes);

            imageInput.UnlockBits(bmpData);

            return imageInput;
        }

        /// <summary>
        ///Get Top 20 color on image.
        /// </summary>
        /// <param name="image">Image to geg color.</param>
        /// <returns>Color array.</returns>
        public static Color[] AnalizColor(Bitmap image)
        {
            List<Color> colorsList = new List<Color>();

            using (var bitmap = image)
            {
                decimal startX = 0;
                decimal startY = 0;
                decimal finishX = image.Width / 3;
                decimal finishY = image.Height / 3;
                for(int iter = 0; iter < 3; iter++)
                {
                    for(int iterY = 0; iterY < 3; iterY++)
                    {
                        var frame = new Rectangle((int)Math.Floor(startX), (int)Math.Floor(startY), (int)Math.Floor(finishX), (int)Math.Floor(finishY));

                        var colorsWithCount = GetPixels(cropImage(bitmap, frame))
                                                              .GroupBy(color => color)
                                                              .Select(grp =>
                                                                  new
                                                                  {
                                                                      Color = grp.Key,
                                                                      Count = grp.Count()
                                                                  })
                                                              .OrderByDescending(x => x.Count)
                                                              .Take(15);

                        for (var i = 0; i < colorsWithCount.Count(); i++)
                        {
                            if (i == 0)
                            {
                                colorsList.Add(Color.FromArgb(colorsWithCount.ElementAt(i).Color.R, colorsWithCount.ElementAt(i).Color.G, colorsWithCount.ElementAt(i).Color.B));
                            }
                            else
                            {
                                if (getChromaticDistance(colorsWithCount.ElementAt(i).Color, colorsWithCount.ElementAt(i - 1).Color) < 60 && !colorsList.Contains(Color.FromArgb(colorsWithCount.ElementAt(i).Color.R, colorsWithCount.ElementAt(i).Color.G, colorsWithCount.ElementAt(i).Color.B)))
                                {
                                    colorsList.Add(Color.FromArgb(colorsWithCount.ElementAt(i).Color.R, colorsWithCount.ElementAt(i).Color.G, colorsWithCount.ElementAt(i).Color.B));
                                }
                            }
                        }
                        startY = finishY;
                        finishY = finishY + image.Height / 3;

                    }

                    startX = finishX;
                    finishX = finishX + image.Width / 3;

                }                        
            }

            return colorsList.ToArray();
        }

        /// <summary>
        /// Get pixel list.
        /// </summary>
        /// <param name="bitmap">Image to treatment.</param>
        /// <returns>IEnumerable of color.</returns>
        private static IEnumerable<Color> GetPixels(Bitmap bitmap)
        {
            for (int x = 0; x < bitmap.Width; x++)
            {
                for (int y = 0; y < bitmap.Height; y++)
                {
                    string[] colors = Enum.GetNames(typeof(System.Drawing.KnownColor));
                    Color pixel = bitmap.GetPixel(x, y);
                    yield return pixel;
                }
            }
        }
        private static IEnumerable<Color> GetSystemColors()
        {
            Type type = typeof(Color);
            return type.GetProperties().Where(info => info.PropertyType == type).Select(info => (Color)info.GetValue(null, null));
        }


        private static Bitmap cropImage(Bitmap img, Rectangle cropArea)
        {
            Bitmap bmp = new Bitmap(cropArea.Width, cropArea.Height);
            using (Graphics gph = Graphics.FromImage(bmp))
            {
                gph.DrawImage(img, new Rectangle(0, 0, bmp.Width, bmp.Height), cropArea, GraphicsUnit.Pixel);
            }
            return bmp;
        }
        /// <summary>
        /// Get cromatic distance of color.
        /// </summary>
        /// <param name="colorOne">First color.</param>
        /// <param name="colorTwo">Second color.</param>
        /// <returns>return distance of two color.</returns>
        private static double getChromaticDistance(Color colorOne, Color colorTwo)
        {
            return Math.Sqrt((colorOne.R - colorTwo.R) * (colorOne.R - colorTwo.R) + (colorOne.G - colorTwo.G) * (colorOne.G - colorTwo.G) + (colorOne.B - colorTwo.B) * (colorOne.B - colorTwo.B));
        }
    }
}
