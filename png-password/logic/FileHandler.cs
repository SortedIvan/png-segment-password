using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace logic
{
    public class FileHandler
    {
        private GeometryHandler geo_handler;
        public FileHandler()
        {
            geo_handler = new GeometryHandler();
        }

        public Bitmap CropImage(Bitmap source, Rectangle section)
        {
            if (OperatingSystem.IsWindows())
            {
                var bitmap = new Bitmap(section.Width, section.Height);
                using (var g = Graphics.FromImage(bitmap))
                {
                    g.DrawImage(source, 0, 0, section, GraphicsUnit.Pixel);
                    return bitmap;
                }
            }
            return null;
        }

        

        public List<Bitmap> TestImageSaving()
        {
            if (OperatingSystem.IsWindows())
            {
                Bitmap source = new Bitmap(@"C:\png-segment-password\png-password\logic\images\test.jpg");
                List<Point> points = geo_handler.GetRectanglePointsFromImage(source);
                List<Rectangle> sections = new List<Rectangle>();
                Tuple<int, int> rectangle_size = geo_handler.GetSmallRectangleSize(source);
                List<Bitmap> images = new List<Bitmap>();
                for (int i = 0; i < points.Count; i++)
                {
                    sections.Add(new Rectangle(points[i], new Size(rectangle_size.Item1, rectangle_size.Item2)));
                }

                for (int i = 0; i < sections.Count; i++) 
                {
                    images.Add(CropImage(source, sections[i]));
                }

                //Rectangle section = new Rectangle(new Point(12, 50), new Size(150, 150));
                //Bitmap CroppedImage = CropImage(source, section);
                //System.Diagnostics.Debug.WriteLine("We be saving this shit.");
                //CroppedImage.Save("test.jpg", ImageFormat.Jpeg);
                //return CroppedImage;
                return images;
            }
            return null;
        }
    }
}
