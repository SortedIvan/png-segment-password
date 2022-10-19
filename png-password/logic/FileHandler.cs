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

        

        public List<Bitmap> segment_password_image(string path)
        {
            if (OperatingSystem.IsWindows())
            {
                Bitmap source = new Bitmap(path);
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

                return images;
            }
            return null;
        }
    }
}
