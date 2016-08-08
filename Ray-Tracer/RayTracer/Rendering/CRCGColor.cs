using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RayTracer.MathLib;
using System.Drawing;

/**
    A representation of a 3-colored point.

    Author: LunarOwl
    Last Modified: 17th March 2016
*/

namespace RayTracer.Rendering
{
    class CRCGColor
    {
        float m_r, m_g, m_b;

        public CRCGColor(float r, float g, float b)
        {
            m_r = r;
            m_g = g;
            m_b = b;
        }


        public CRCGColor()
        {
            m_r = 0;
            m_g = 0;
            m_b = 0;
        }

        public Color ConvertTo256RGB(float gamma)
        {
            // Make sure the color values are between 0 and 1
            if (m_r > 1) { m_r = 1; }
            if (m_r < 0) { m_r = 0; }
            if (m_g > 1) { m_g = 1; }
            if (m_g < 0) { m_g = 0; }
            if (m_b > 1) { m_b = 1; }
            if (m_b < 0) { m_b = 0; }

            m_r = (float) Math.Pow(m_r, gamma);
            m_g = (float)Math.Pow(m_g, gamma);
            m_b = (float)Math.Pow(m_b, gamma);

            int re = (int)Math.Floor(m_r == 1.0 ? 255 : m_r * 256.0);
            int gr = (int)Math.Floor(m_g == 1.0 ? 255 : m_g * 256.0);
            int bl = (int)Math.Floor(m_b == 1.0 ? 255 : m_b * 256.0);

            Color converted_color = Color.FromArgb(re, gr, bl);

            return converted_color;
        }

        #region Auxillary Operators

        // Assignments
        public float Red
        {
            set { m_r = value; }
            get { return m_r; }
        }

        public float Green
        {
            set { m_g = value; }
            get { return m_g; }
        }

        public float Blue
        {
            set { m_b = value; }
            get { return m_b; }
        }

        // Addition of two color points
        public static CRCGColor operator +(CRCGColor c1, CRCGColor c2)
        {
            return new CRCGColor(c1.m_r + c2.m_r, 
                              c1.m_g + c2.m_g, 
                              c1.m_b + c2.m_b);
        }

        // Multiplication of a scalar
        public static CRCGColor operator *(CRCGColor c1, float a)
        {
            return new CRCGColor(c1.m_r * a, 
                              c1.m_g * a, 
                              c1.m_b * a);
        }

        // Division by a scalar
        public static CRCGColor operator / (CRCGColor c1, float a)
        {
            return new CRCGColor(c1.m_r / a, 
                              c1.m_g / a, 
                              c1.m_b / a);
        }

        // Multiplication of two color points
        public static CRCGColor operator *(CRCGColor c1, CRCGColor c2)
        {
            return new CRCGColor(c1.m_r * c2.m_r, 
                              c1.m_g * c2.m_g, 
                              c1.m_b * c2.m_b);
        }

        // Power the points by a scalar
        public static CRCGColor operator ^(CRCGColor c1, float a)
        {
            return new CRCGColor((float) Math.Pow(c1.m_r,a), 
                              (float) Math.Pow(c1.m_g, a), 
                              (float) Math.Pow(c1.m_b, a));
        }

        #endregion
    }
}
