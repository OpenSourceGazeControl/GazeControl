using System;
using System.Drawing;
using System.Windows.Forms;

namespace GazeToolBar
{
    class ReletiveSize
    {
        public static readonly Size formSize = new Size(Convert.ToInt32(Screen.PrimaryScreen.WorkingArea.Size.Width * ValueNeverChange.FORM_WEIGTH_PERCENTAGE), Screen.PrimaryScreen.WorkingArea.Size.Height);
        public static readonly Size btnSize = new Size(Convert.ToInt32(formSize.Width * 0.4), Convert.ToInt32(formSize.Height * 0.05));
        public static readonly int gap = btnSize.Height / 3;
        public static readonly Size panelSize = new Size(formSize.Width, btnSize.Height * 4 + gap * 3);
        public static readonly int btnPositionX = formSize.Width / 2 - btnSize.Width / 2;
        public static readonly int panelPositionY = formSize.Height / 2 - panelSize.Height / 2;
        public static int btnPostionY(int num)
        {
            if(num == 1)
            {
                return (num - 1) * btnSize.Height;
            }
            else
            {
                return (num - 1) * btnSize.Height + gap * (num - 1);
            }
        }
    }
}
