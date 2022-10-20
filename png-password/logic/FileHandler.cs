using algorithm;
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
        private RandomSegmentGenerator segmentGenerator;
        private ImageAlgorithm image_randomizer;
        public FileHandler(GeometryHandler geo_handler, RandomSegmentGenerator segmentGenerator)
        {
            this.geo_handler = geo_handler;
            this.segmentGenerator = segmentGenerator;
            this.image_randomizer = new ImageAlgorithm();
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

        public List<Bitmap> segment_random_image(Bitmap source) 
        {
            if (OperatingSystem.IsWindows())
            {
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

        public List<List<Bitmap>> SegmentRandomImages()
        {
            List<List<Bitmap>> bitmaps = new List<List<Bitmap>>();
            List<Bitmap> unsegmented_images = segmentGenerator.GenerateRandomSegments();
            for (int i = 0; i < unsegmented_images.Count; i++)
            {
                bitmaps.Add(segment_random_image(unsegmented_images[i]));
            }
            return bitmaps;
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

        public List<ImageSegment> GetOneCycleOfImages(string image_password_path)
        {
            List<ImageSegment> final_images = image_randomizer.GenerateImageSegments(
                SegmentRandomImages(), segment_password_image(image_password_path));
            return final_images;
        }
    }
}
