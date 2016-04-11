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

        public Zoomer(Graphics graphics)
        {
            this.graphics = graphics;
        }
        public Bitmap createZoomBitmap()
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

            return bmpScreenshot.Clone(cropRect, bmpScreenshot.PixelFormat); ;
        }

    }
}
