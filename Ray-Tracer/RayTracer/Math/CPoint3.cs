using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/**
    Representation of an arbitary point in 3D space

    Author: LunarOwl
    Last Modified: 17th March 2016
*/

namespace RayTracer.MathLib
{
    class CPoint3
    {
        float m_x, m_y, m_z;

        public CPoint3(float x, float y, float z)
        {
            m_x = x;
            m_y = y;
            m_z = z;
        }

        // Property access
        public float x
        {
            get { return m_x; }
            set { m_x = value; }
        }

        public float y
        {
            get { return m_y; }
            set { m_y = value; }
        }

        public float z
        {
            get { return m_z; }
            set { m_z = value; }
        }

        public static CPoint3 operator +(CPoint3 p1, CPoint3 p2)
        {
            return new CPoint3(p1.x + p2.x,p1.y + p2.y, p1.z + p2.z);
        }

        // Returns a vector between two points
        public static CVector3 operator -(CPoint3 p1, CPoint3 p2)
        {
            return new CVector3(p1.x - p2.x, p1.y - p2.y, p1.z - p2.z);
        }

        public override String ToString()
        {
            return "[" + m_x.ToString() + "," 
                       + m_y.ToString() + "," 
                       + m_z.ToString() + "]";
        }
    }
}
