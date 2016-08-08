using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/**
    Representation of a Ray in 3D space

    Author: LunarOwl
    Last Modified: 17th March 2016
*/
namespace RayTracer.MathLib
{
    class CRay
    {
        CPoint3 m_origin;
        CVector3 m_direction;

        public CVector3 direction
        {
            set { m_direction = value; }
            get { return m_direction; }
        }

        public CPoint3 origin
        {
            set { m_origin = value; }
            get { return m_origin; }
        }

        public CRay(CPoint3 origin, CVector3 direction)
        {
            m_origin = origin;
            m_direction = direction;
        }
    }
}
