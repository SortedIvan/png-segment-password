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
            Random random = new Random();
            randomized_segments.Add(CreateImageSegment(password_image[random.Next(0, 15)], true));
            for (int i = 0; i < random_images.Count; i++)
            {
                int image_nr = random.Next(0, 15);
                randomized_segments.Add(CreateImageSegment(random_images[i][image_nr], false));

            }
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
