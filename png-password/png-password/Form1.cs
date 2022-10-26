using algorithm;
using logic;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;


namespace png_password
{
    public partial class Form1 : Form
    {
        private FileHandler fileHandler;
        private GeometryHandler geo_handler;
        private RandomSegmentGenerator segment_generator;
        private string key_image_path = @"C:\png-segment-password\png-password\logic\test.jpg";
        private string logged_in_image = @"C:\png-segment-password\png-password\logic\test.png";
        private List<ImageSegment> currect_segments;
        private LoginHandler login_handler;
        public Form1()
        {
            InitializeComponent();
            this.geo_handler = new GeometryHandler();
            this.segment_generator = new RandomSegmentGenerator();
            this.login_handler = new LoginHandler();
            fileHandler = new FileHandler(geo_handler, segment_generator);
            pb_log.Visible = false;


        }

        private void PopulatePictureBoxes() 
        {
            List<PictureBox> picture_boxes = GetPictureBoxes(this);
            for (int i = 0; i < picture_boxes.Count; i++)
            {
                picture_boxes[i].Image = null;
            }
            List<ImageSegment> images16 = fileHandler.GetOneCycleOfImages(key_image_path);
            currect_segments = images16;
            System.Diagnostics.Debug.WriteLine(images16.Count + "is the count");
            int[] image_positions = Shuffle(15);
            for (int i = 0; i < image_positions.Length; i++)
            {
                picture_boxes[image_positions[i]].Image = images16[i].GetImage();
                images16[i].SetImagePosition(picture_boxes[image_positions[i]].Name);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PopulatePictureBoxes();
        }

        private static int[] Shuffle(int n)
        {
            var a = Enumerable.Range(0, n).ToArray();
            var random = new Random();
            for (int i = 0; i < a.Length; i++)
            {
                var j = random.Next(0, i);
                Swap(a, i, j);
            }
            return a;
        }

        private static void Swap(int[] a, int i, int j)
        {
            var temp = a[i];
            a[i] = a[j];
            a[j] = temp;
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


        private void Form1_Load(object sender, EventArgs e)
        {
            List<PictureBox> pictureBoxes = GetPictureBoxes(this);
            for (int i = 0; i < pictureBoxes.Count; i++)
            {
                pictureBoxes[i].DoubleClick += PictureBoxClick;
            }
        }

        private void LoggedIn()
        {
            //List<Bitmap> logged_in_images = fileHandler.segment_password_image(logged_in_image);
            //List<PictureBox> picture_boxes = GetPictureBoxes(this);
            Bitmap win_image = new Bitmap(logged_in_image);
            pb_log.Image = win_image;
            pb_log.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            pb_log.Visible = true;           
            //for (int i = 0; i < picture_boxes.Count; i++)
            //{
            //    picture_boxes[i].Image = null;
            //}
            //for (int i = 0; i < picture_boxes.Count; i++)
            //{
            //    picture_boxes[i].Image = logged_in_images[i];
            //}
        }

        private void PictureBoxClick(object sender, EventArgs e)
        {
            string clicked_pb = ((PictureBox)sender).Name;
            for (int i = 0; i < currect_segments.Count; i++)
            {
                if (clicked_pb.Equals(currect_segments[i].GetImagePosition()))
                {
                    if (currect_segments[i].CheckIsPassword())
                    {
                        System.Diagnostics.Debug.WriteLine("Correct!");
                        if (login_handler.GetCounter() == 3)
                        {
                            System.Diagnostics.Debug.WriteLine("You are now logged in!");
                            LoggedIn();
                            return;
                        }
                        login_handler.Correct();
                        PopulatePictureBoxes();
                        return;
                    }
                    else if (!currect_segments[i].CheckIsPassword())
                    {
                        System.Diagnostics.Debug.WriteLine("Wrong!");
                        login_handler.ResetCounter();
                        PopulatePictureBoxes();
                        return;
                    }
                    

                }
            }
        }
    }
}
