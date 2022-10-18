using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace logic
{
    public class GeometryHandler
    {
        public GeometryHandler()
        {

        }

        public Tuple<int, int> GetSmallRectangleSize(Bitmap image)
        {
            if (OperatingSystem.IsWindows())
            {
                int width_div = image.Width / 4;
                int height_div = image.Height / 4;
                return new Tuple<int, int>(height_div, width_div);
            }
            return null;

        }
        
        public List<Point> GetRectanglePointsFromImage(Bitmap image)
        {
            List<Point> points = new List<Point>();
            if (OperatingSystem.IsWindows())
            {
                
                int og_height = image.Height;
                int og_width = image.Width;

                int width_div = image.Width / 4;
                int height_div = image.Height / 4;

                // 0, 200 , 400, 600
                int[] widths = new int[] { 0, og_width - width_div * 3, og_width - width_div * 2, og_width - width_div };
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
            }

            return points;
        }


    }
}
