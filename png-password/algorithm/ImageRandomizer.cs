using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace algorithm
{
    public class ImageAlgorithm
    {
        public ImageAlgorithm()
        {

        }

        public List<ImageSegment> GenerateImageSegments(List<List<Bitmap>> random_images, List<Bitmap> password_image)
        {
            List<ImageSegment> randomized_segments = new List<ImageSegment>();
            int[] used_numbers = new int[15];
            Random random = new Random();
            for (int i = 0; i < random_images.Count; i++)
            {
                int image_nr = random.Next(0, 15);
                if (!CheckNumberUsed(image_nr, used_numbers))
                {
                    randomized_segments.Add(CreateImageSegment(random_images[i][image_nr], false));
                }
            }
            randomized_segments.Add(CreateImageSegment(password_image[random.Next(0, 16)], true));
            return randomized_segments;
        }

        public bool CheckNumberUsed(int number, int[] used_numers)
        {
            for (int i = 0; i < used_numers.Length; i++)
            {
                if (number == used_numers[i])
                {
                    return true;
                }
            }
            return false;
        }

        public ImageSegment CreateImageSegment(Bitmap segment, bool is_password)
        {
            ImageSegment imageSegment = new ImageSegment(segment, is_password);
            return imageSegment;
        }

    }
}
