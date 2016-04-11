using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Zoomer
{
    public class Zoomer
    {
        Bitmap bmpScreenshot;
        Graphics graphics;
        PictureBox picturebox1;

        public Zoomer(Graphics graphics, PictureBox picturebox1)
        {
            this.picturebox1 = picturebox1;
            this.graphics = graphics;
        }
        public void createZoomBitmap()
        {
            Rectangle cropRect = new Rectangle(0, 0, 100, 100);
            //Create a new bitmap.
            bmpScreenshot = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height, PixelFormat.Format32bppArgb);

            //Create a graphics object from the bitmap.
            graphics = Graphics.FromImage(bmpScreenshot);

            //Take the screenshot
            graphics.CopyFromScreen(0, 0, 0, 0, Screen.PrimaryScreen.Bounds.Size, CopyPixelOperation.SourceCopy);

            //Save the screenshot
            bmpScreenshot.Save("Screenshot.png", ImageFormat.Bmp);
            for (int i = 0; i < 10; i++)
            {
                cropRect.X -= cropRect.X - i;
                cropRect.Y -= cropRect.Y - i;
                picturebox1.Image = bmpScreenshot.Clone(cropRect, bmpScreenshot.PixelFormat);
                System.Threading.Thread.Sleep(1000);
            }
            //return 
        }

    }
}
