using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

using RayTracer.MathLib;


/**
    Scene construction and rendering for the ray tracer

    Author: LunarOwl
    Last Modified: 17th March 2016
*/

namespace RayTracer.Rendering
{
    class CScene
    {
        List<CPrimitive> m_objects                 // List of objects in the scene
                         = new List<CPrimitive>();
        CRCGColor        m_background_color;       // Background color
        CViewPlane       m_viewplane;              // Viewing plane
        CTracer          m_tracer;                 // Tracer object for ray tracing

        public CScene()
        {
            m_viewplane = new CViewPlane();
            m_tracer = new CTracer(); 
        }
            

        // Construct the scene and set the parameters
        public void BuildScene()
        {
            m_viewplane.hRes = 512;
            m_viewplane.vRes = 512;
            m_viewplane.PixelSize = 1;
            m_viewplane.Gamma = 1;

            CSphere sphere_one = new CSphere();
            sphere_one.center = new CPoint3(-45, 45, 40);
            sphere_one.radius = 50;
            sphere_one.Color = new CRCGColor(1, 0, 0);

            CSphere sphere_two = new CSphere();
            sphere_two.center = new CPoint3(0, 120, 0);
            sphere_two.radius = 60;
            sphere_two.Color = new CRCGColor(1, 1, 0);

            CSphere sphere_three = new CSphere();
            sphere_three.center = new CPoint3(-200, 45, 0);
            sphere_three.radius = 60;
            sphere_three.Color = new CRCGColor(1, 0.3f, 0.3f);

            CSphere sphere_four = new CSphere();
            sphere_four.center = new CPoint3(-170, 30, 0);
            sphere_four.radius = 60;
            sphere_four.Color = new CRCGColor(0.5f, 0.7f, 0.7f);

            CPlane plane = new CPlane();
            plane.Point = new CPoint3(0, -101, 0);
            plane.normal = new CVector3(0, 1, 0);
            plane.Color = new CRCGColor(0, 0.3f, 0.3f);

            //m_objects.Add(plane);
            m_objects.Add(sphere_one);
            m_objects.Add(sphere_two);
            //m_objects.Add(sphere_three);
            m_objects.Add(sphere_four);
            m_objects.Add(plane);
        }

        // Auxillary
        #region AUXILLARY FUNCTIONS
        public List<CPrimitive> Objects
        {
            get { return m_objects; }
        }

        public CRCGColor BackgroundColor
        {
            set { m_background_color = value; }
            get { return m_background_color; }
        }

        public CViewPlane ViewPlane
        {
            set { m_viewplane = value; }
            get { return m_viewplane; }
        }

        public CTracer Tracer
        {
            set { m_tracer = value; }
            get { return m_tracer; }
        }
        #endregion

        #region DEPRECATED
        // Renders the given scene
        // Note: deprecated with the introduction of camera classes
        //public void RenderScene()
        //{
        //    CRCGColor pixel_color = new CRCGColor();
        //    CRay      ray = new CRay(new CVector3(0, 0, 0), 
        //                             new CVector3(0, 0, -1));
        //    float     zw = 100;
        //    float     x, y;

        //    // Save to image
        //    m_image = new Bitmap(m_viewplane.hRes, m_viewplane.vRes);

        //    for (int r = 0; r < m_viewplane.vRes; r++) // Row
        //    {
        //        for(int c = 0; c < m_viewplane.hRes; c++) // Column
        //        {
        //            // Calculate the pixel location and establish the ray origin
        //            x = m_viewplane.PixelSize * (c - (float) 0.5 * (m_viewplane.hRes - 1));
        //            y = m_viewplane.PixelSize * (r - (float) 0.5 * (m_viewplane.vRes - 1));
        //            ray.origin = new CPoint3(x, y, zw);

        //            // Do you believe in magic?
        //            pixel_color = m_simpleTracer.TraceRay(ray,m_objects);

        //            m_image.SetPixel(c, r, ConvertTo256RGB(pixel_color));
        //        }
        //    }

        //    m_image.RotateFlip(RotateFlipType.RotateNoneFlipY);
        //    m_image.Save("Output.bmp");

        //}

        //// Converts colors from floating points to 256 byte representation
        //public Color ConvertTo256RGB(CRCGColor color)
        //{
        //    // Make sure the color values are between 0 and 1
        //    if (color.Red > 1) { color.Red = 1; }
        //    if (color.Red < 0) { color.Red = 0; }
        //    if (color.Green > 1) { color.Green = 1; }
        //    if (color.Green < 0) { color.Green = 0; }
        //    if (color.Blue > 1) { color.Blue = 1; }
        //    if (color.Blue < 0) { color.Blue = 0; }

        //    // Adjust brightness based on lighting (not implemented)
        //    if (m_viewplane.Gamma != 1.0)
        //    {
        //        color ^= m_viewplane.InvGamma;
        //    }

        //    int re = (int)Math.Floor(color.Red == 1.0 ? 255 : color.Red * 256.0);
        //    int gr = (int)Math.Floor(color.Green == 1.0 ? 255 : color.Green * 256.0);
        //    int bl = (int)Math.Floor(color.Blue == 1.0 ? 255 : color.Blue * 256.0);

        //    Color converted_color = Color.FromArgb(re, gr, bl);

        //    return converted_color;
        //}
        #endregion
    }
}
