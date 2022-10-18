using logic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace png_password
{
    public partial class Form1 : Form
    {
        private FileHandler fileHandler;
        public Form1()
        {
            InitializeComponent();
            fileHandler = new FileHandler();

        }

        private void button1_Click(object sender, EventArgs e)
        {
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Bitmap bm = fileHandler.TestImageSaving()[15];
            e.Graphics.DrawImage(bm, 60, 60);
            base.OnPaint(e);
        }
    }
}
