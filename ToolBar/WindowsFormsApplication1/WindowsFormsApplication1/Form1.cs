using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : ShellLib.ApplicationDesktopToolbar
    {
        public Form1()
        {
            InitializeComponent();
            Size s = new Size(180, Screen.PrimaryScreen.WorkingArea.Size.Height);
            Size = s;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Edge = AppBarEdges.Left;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Edge = AppBarEdges.Right;
        }
    }
}
