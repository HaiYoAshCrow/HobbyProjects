using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using RayTracer.MathLib;

namespace RayTracer.Rendering.Cameras
{
    class CPinholeCamera : CCamera
    {
        float m_view_distance;
        float m_zoom;

        public float ViewDistance
        {
            set { m_view_distance = value; }
            get { return m_view_distance; }
        }

        public float Zoom
        {
            set { m_zoom = value; }
            get { return m_zoom; }
        }

        public CPinholeCamera() : base ()
        {

        }

        public override void RenderScene()
        {
            CRCGColor pixel_color = new CRCGColor();
            CRay ray = new CRay(new CPoint3(0,0,0),new CVector3(0,0,0));
            int depth = 0; // Recursion depth

            Scene.ViewPlane.PixelSize /= m_zoom;
            ray.origin = Eye;

            float x, y = 0;

            // Save to image
            Image = new Bitmap(Scene.ViewPlane.hRes, Scene.ViewPlane.vRes);

            for (int r = 0; r < Scene.ViewPlane.vRes; r++) // Row
            {
                for (int c = 0; c < Scene.ViewPlane.hRes; c++) // Column
                {
                    x = Scene.ViewPlane.PixelSize * (c - (float)0.5 * (Scene.ViewPlane.hRes - 1));
                    y = Scene.ViewPlane.PixelSize * (r - (float)0.5 * (Scene.ViewPlane.vRes - 1));

                    ray.direction = GetRayDirection(x, y);
                    pixel_color = Scene.Tracer.TraceRay(ray, Scene.Objects);
                    pixel_color *= ExposureTime;

                    Image.SetPixel(c, r, pixel_color.ConvertTo256RGB(Scene.ViewPlane.Gamma));
                }
            }

            Image.RotateFlip(RotateFlipType.RotateNoneFlipY);
            Image.Save("Output_Pinhole.bmp");

        }

        CVector3 GetRayDirection(float x, float y)
        {
            CVector3 dir = U * x + V * y - W * m_view_distance;
            dir.Normalize();
            return dir;
        }
    }
}
