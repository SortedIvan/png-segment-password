using logic;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace factories
{
    public class ImageSegmentFactory
    {
        public ImageSegmentFactory()
        {

        }

        public ImageSegment CreateImageSegment(Bitmap segment, bool is_password)
        {
            ImageSegment imageSegment = new ImageSegment(segment, is_password);
            return imageSegment;
        }

        public List<ImageSegment> CreateImageSegments()
        {

        }
    }
}
