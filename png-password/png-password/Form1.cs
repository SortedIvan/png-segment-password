using algorithm;
using logic;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;


namespace png_password
{
    public partial class Form1 : Form
    {
        private FileHandler fileHandler;
        private GeometryHandler geo_handler;
        private RandomSegmentGenerator segment_generator;
        private string key_image_path = @"C:\png-segment-password\png-password\logic\images\test.jpg";
        public Form1()
        {
            InitializeComponent();
            this.geo_handler = new GeometryHandler();
            this.segment_generator = new RandomSegmentGenerator();
            fileHandler = new FileHandler(geo_handler, segment_generator);
            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<ImageSegment> images16 = fileHandler.GetOneCycleOfImages(key_image_path);
            List<PictureBox> picture_boxes = GetPictureBoxes(this);
            System.Diagnostics.Debug.WriteLine(images16.Count + "is the count");
            Random random = new Random();
            for (int i = 0; i < images16.Count; i++)
            {
                picture_boxes[i].Image = images16[i].GetImage();
            }
        }

        public List<PictureBox> GetPictureBoxes(Control control)
        {
            List<PictureBox> pictureBoxes = new List<PictureBox>();
            foreach (Control child in control.Controls)
            {
               if (child is PictureBox) 
               {
                   if (child.Name.StartsWith("pb"))
                   {
                       pictureBoxes.Add((PictureBox)child);
                   }
               }
            }
            return pictureBoxes;
        }

        private void pb15_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("shit works");
        }


    }
}
