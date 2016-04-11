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


            //Create a new bitmap.
            bmpScreenshot = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height, PixelFormat.Format32bppArgb);
            // Create a graphics object from the bitmap.
            graphics = Graphics.FromImage(bmpScreenshot);

            // Take the screenshot from the upper left corner to the right bottom corner.
            graphics.CopyFromScreen( 0, 0, 0, 0, Screen.PrimaryScreen.Bounds.Size, CopyPixelOperation.SourceCopy);

            // Save the screenshot to the specified path that the user has chosen.
            bmpScreenshot.Save("Screenshot.png", ImageFormat.Bmp);

            graphics.DrawImage(bmpScreenshot, 0, 0 , 100, 100);
            Rectangle cropRect = new Rectangle(0, 0, 100, 100);

            Bitmap target = new Bitmap(cropRect.Width, cropRect.Height);

            graphics = Graphics.FromImage(target);

            graphics.DrawImage(bmpScreenshot, new Rectangle(0, 0, target.Width, target.Height),cropRect, GraphicsUnit.Pixel);
            
        }

    }
}
