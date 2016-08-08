using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RayTracer.MathLib;

/**
    Representation of a mathematical sphere shell

    Author: LunarOwl
    Last Modified: 17th March 2016
*/
namespace RayTracer.Rendering
{
    class CSphere : CPrimitive
    {
        CPoint3  m_center;
        CPoint3  m_localHitPoint;
        CVector3 m_currentNormal;
        float    m_radius;
        float    m_kEpsilon;

        #region Auxillary Getters/Setters
        public CPoint3 center
        {
            set { m_center = value; }
            get { return m_center; }
        }

        public CPoint3 LocalHitPoint
        {
            set { m_localHitPoint = value; }
            get { return m_localHitPoint; }
        }

        public CVector3 CurrentNormal
        {
            set { m_currentNormal = value; }
            get { return m_currentNormal; }
        }

        public float radius
        {
            set { m_radius = value; }
            get { return m_radius; }
        }

        public float kEpsilon
        {
            set { m_kEpsilon = value; }
            get { return m_kEpsilon; }
        }


        #endregion

        public CSphere() : base ("Sphere", PrimitiveType.SPHERE)
        {

        }

        /**
            Checks for intersect of a ray and the sphere

            Param: Ray
            Returns: 1/0 = Hit/Miss
        */
        public override int GetIntersect(CRay ray)
        {
            float t; // Arbitary point on ray cast/intersection path
            CVector3 c_temp = ray.origin - m_center;
            float a = ray.direction * ray.direction;
            float b = 2 * c_temp * ray.direction;
            float c = c_temp * c_temp - m_radius * m_radius;
            float disc = b * b - 4 * a * c;
            if(disc < 0)
            {
                return 0;
            }
            else
            {
                float e = (float) Math.Sqrt(disc);
                float denom = 2 * a;
                t = (-b - e) / denom; // Pass One Test: Smaller root of Quadratic
                if(t > m_kEpsilon)
                {
                    tMin = t;
                    m_currentNormal = (c_temp + t * ray.direction) / m_radius;
                    m_localHitPoint = ray.origin + t * ray.direction;
                    return 1;
                }

                t = (-b + e) / denom; // Pass Two Test: Larger root of Quadratic
                if(t > m_kEpsilon)
                {
                    tMin = t;
                    m_currentNormal = (c_temp + t * ray.direction) / m_radius;
                    m_localHitPoint = ray.origin + t * ray.direction;
                    return 1;
                }
            }

            return 0;
        }
    }
}
