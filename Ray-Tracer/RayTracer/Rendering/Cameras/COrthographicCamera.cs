using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using RayTracer.MathLib;

namespace RayTracer.Rendering.Cameras
{
    class COrthographicCamera : CCamera
    {
        public COrthographicCamera() : base()
        {

        }

        public override void RenderScene()
        {
            CRCGColor pixel_color = new CRCGColor();
            CRay ray = new CRay(new CVector3(0, 0, 0),
                                     new CVector3(0, 0, -1));
            float zw = 100;
            float x, y;

            // Save to image
            Image = new Bitmap(Scene.ViewPlane.hRes, Scene.ViewPlane.vRes);

            for (int r = 0; r < Scene.ViewPlane.vRes; r++) // Row
            {
                for (int c = 0; c < Scene.ViewPlane.hRes; c++) // Column
                {
                    // Calculate the pixel location and establish the ray origin
                    x = Scene.ViewPlane.PixelSize * (c - (float)0.5 * (Scene.ViewPlane.hRes - 1));
                    y = Scene.ViewPlane.PixelSize * (r - (float)0.5 * (Scene.ViewPlane.vRes - 1));
                    ray.origin = new CPoint3(x, y, zw);

                    // Do you believe in magic?
                    pixel_color = Scene.Tracer.TraceRay(ray, Scene.Objects);

                    Image.SetPixel(c, r, pixel_color.ConvertTo256RGB(Scene.ViewPlane.Gamma));
                }
            }

            Image.RotateFlip(RotateFlipType.RotateNoneFlipY);
            Image.Save("Output.bmp");
        }
    }
}
