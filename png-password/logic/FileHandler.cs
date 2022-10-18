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

        

        public Bitmap TestImageSaving()
        {
            if (OperatingSystem.IsWindows())
            {
                Bitmap source = new Bitmap(@"C:\png-segment-password\png-password\logic\images\test.jpg");
                List<Point> points = new List<Point>();
                int og_height = source.Height;
                int og_width = source.Width;

                int width_div = source.Width / 4;
                int height_div = source.Height / 4;

                // 0, 200 , 400, 600
                int[] widths = new int[] { 0, og_width - width_div* 3, og_width - width_div * 2, og_width - width_div};

                // 0, 200, 400, 600
                int[] heights = new int[] { 0, og_height - height_div * 3, og_height - height_div * 2, og_height - height_div };

           
                for (int x = 0; x < heights.Length; x++)
                {
                    for (int y = 0; y < widths.Length; y++) 
                    {
                        points.Add(new Point(heights[x], widths[y]));
                        System.Diagnostics.Debug.WriteLine($"{heights[x]}, {widths[y]}");
                    }
                }


                //Rectangle section = new Rectangle(new Point(12, 50), new Size(150, 150));
                //Bitmap CroppedImage = CropImage(source, section);
                //System.Diagnostics.Debug.WriteLine("We be saving this shit.");
                //CroppedImage.Save("test.jpg", ImageFormat.Jpeg);
                //return CroppedImage;
            }
            return null;
        }
    }
}
