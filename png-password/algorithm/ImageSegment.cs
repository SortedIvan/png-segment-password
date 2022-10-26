using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace algorithm
{
    public class ImageSegment
    {
        private Guid id;
        private Bitmap segment;
        private bool is_password;
        private string pb_name;

        public ImageSegment(Bitmap segment, bool is_password)
        {
            this.id = Guid.NewGuid();
            this.segment = segment;
            this.is_password = is_password;
        }

        public Bitmap GetImage()
        {
            return this.segment;
        }

        public bool CheckIsPassword()
        {
            return this.is_password;
        }

        public string GetImagePosition()
        {
            return pb_name;
        }
        public void SetImagePosition(string position)
        {
            this.pb_name = position;
        }
    }
}
