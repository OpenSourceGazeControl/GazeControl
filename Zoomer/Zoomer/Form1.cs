using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Zoomer
{
    public partial class Form1 : Form
    {
        Graphics graphics;
        public Form1()
        {
            InitializeComponent();
            graphics = this.CreateGraphics();

            //pictureBox1.Image = bmp;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Zoomer zoom = new Zoomer(graphics, pictureBox1);
            zoom.createZoomBitmap();
        }
    }
}
