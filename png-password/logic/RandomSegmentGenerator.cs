using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace logic
{
    public class RandomSegmentGenerator
    {
        private ClientFactory clientFactory;
        public RandomSegmentGenerator()
        {
            clientFactory = new ClientFactory();
        }

        public Bitmap GenerateRandomSegment()
        {
            List<Bitmap> random_images = new List<Bitmap>();
            for (int i = 0; i < 16; i++) 
            {
                random_images.Add(GenerateRandomImage());
            }

            return random_images[GenerateRandomNum(random_images)];

        }

        private int GenerateRandomNum(List<Bitmap> bitmaps)
        {
            Random random = new Random();
            return random.Next(0, bitmaps.Count);
        }

        private Bitmap GenerateRandomImage()
        {
            if (OperatingSystem.IsWindows()) 
            {
                string random_image_url = "https://api.lorem.space/image/movie?w=600&h=800";
                WebClient wc = new WebClient();
                byte[] image_byte = wc.DownloadData(random_image_url);
                MemoryStream stream = new MemoryStream(image_byte);
                return (Bitmap)Image.FromStream(stream);
            }
            return null;
        }

        //result.results[0].name.first
        //Root firstName = Task.Run(async () => await apiConnector.GetRandomName(true, "male")).Result;
        //    return firstName.results[0].name.first;

    }
}
