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
        private RandomSegmentGenerator segment_generator;
        private string key_image_path = @"C:\png-segment-password\png-password\logic\images\test.jpg";
        public Form1()
        {
            InitializeComponent();
            fileHandler = new FileHandler();
            this.segment_generator = new RandomSegmentGenerator();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<Bitmap> images16 = fileHandler.segment_password_image(key_image_path);
            List<PictureBox> picture_boxes = GetPictureBoxes(this);

            //for (int i = 0; i < picture_boxes.Count; i++) 
            //{
            //    picture_boxes[i].Image = images16[i]; 
            //    System.Diagnostics.Debug.WriteLine($"{picture_boxes[i].Name}");
            //}
            picture_boxes[0].Image = segment_generator.GenerateRandomSegment();
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
