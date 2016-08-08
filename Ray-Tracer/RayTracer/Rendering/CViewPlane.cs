using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/**
    Viewing plane for emulating vision field

    Author: LunarOwl
    Last Modified: 17th March 2016
*/

namespace RayTracer.Rendering
{
    class CViewPlane
    {
        int     m_hRes;         // Horizontal Resolution
        int     m_vRes;         // Vertical Resolution
        float   m_pixel_size;   // Pixel Size
        float   m_gamma;        // Monitor Gamma
        float   m_inv_gamma;    // 1/gamma 
        
        public CViewPlane()
        {

        }
        
        public int hRes
        {
            set { m_hRes = value; }
            get { return m_hRes; }
        }

        public int vRes
        {
            set { m_vRes = value; }
            get { return m_vRes; }
        }

        public float PixelSize
        {
            set { m_pixel_size = value; }
            get { return m_pixel_size; }
        }

        public float Gamma
        {
            set { m_gamma = value; m_inv_gamma = 1 / value; }
            get { return m_gamma; }
        }

        public float InvGamma
        {
            get { return m_inv_gamma; }
        }
    }
}
