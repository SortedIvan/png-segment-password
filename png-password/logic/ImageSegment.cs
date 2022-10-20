using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace logic
{
    public class ImageSegment
    {
        private Guid id;
        private Bitmap segment;
        private bool is_password;
         
        public ImageSegment(Bitmap segment, bool is_password)
        {
            this.id = Guid.NewGuid();
            this.segment = segment;
            this.is_password = is_password;
        }

    }
}
