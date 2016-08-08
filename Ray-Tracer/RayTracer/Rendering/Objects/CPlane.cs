using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RayTracer.MathLib;

/**
    Representation of a mathematical plane

    Author: LunarOwl
    Last Modified: 17th March 2016
*/

namespace RayTracer.Rendering
{
    class CPlane : CPrimitive
    {
        CPoint3  m_point;          // Location of the plane
        CPoint3  m_localHitPoint;  // Where it passes through
        CVector3 m_normal;         // Plane Normal
        float    m_kEpsilon;

        public CVector3 normal
        {
            set { m_normal = value; }
            get { return m_normal; }
        }

        public CPoint3 Point
        {
            set { m_point = value; }
            get { return m_point; }
        }

        public CPoint3 LocalHitPoint
        {
            set { m_localHitPoint = value; }
            get { return m_localHitPoint; }
        }

        public float kEpsilon
        {
            set { m_kEpsilon = value; }
            get { return m_kEpsilon; }
        }

        public CPlane() : base("Ground Plane",PrimitiveType.PLANE)
        {
            m_kEpsilon = 0;
        }

        /**
            Checks for intersect between a ray and the plane

            Param: Ray
            Returns: 1/0 = Hit/Miss
        */
        public override int GetIntersect(CRay ray)
        {
            float t = (m_point - ray.origin) * m_normal / (ray.direction * m_normal);

            if(t > m_kEpsilon)
            {
                tMin = t;
                m_localHitPoint = ray.origin + t * ray.direction;
                return 1;
            }
            else
            {
                return 0;
            } 
        }
    }
}
