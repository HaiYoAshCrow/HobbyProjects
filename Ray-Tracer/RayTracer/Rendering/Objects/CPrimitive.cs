using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using RayTracer.MathLib;

/**
    Abstract class for building primitive shapes

    Author: LunarOwl
    Last Modified: 17th March 2016
*/

namespace RayTracer.Rendering
{
    // Material for primitives
    struct Material
    {
        CRCGColor   m_color;
        CRCGColor   m_diffuse;
        CRCGColor   m_specular;
        float    m_reflective;    
    }

    // Types of primitives
    enum PrimitiveType
    {
        PLANE = 0,
        SPHERE = 1
    }

    enum HitTest
    {
        MISS = 0,
        HIT = 1,
        INSIDE = -1
    }

    abstract class CPrimitive
    {
        String   m_name;
        Material m_material;
        PrimitiveType m_type;
        CRCGColor m_color;
        float m_tMinValue;
        bool m_light;

        public CPrimitive(String name, PrimitiveType type)
        {
            m_name = name;
            m_type = type;
        }

        public String Name
        {
            set { m_name = value; }
            get { return m_name; }
        }

        public Material Mat
        {
            set { m_material = value; }
            get { return m_material; }
        }

        public PrimitiveType PType
        {
            set { m_type = value; }
            get { return m_type; }
        }

        public bool Light
        {
            set { m_light = value; }
            get { return m_light; }
        }

        public CRCGColor Color
        {
            set { m_color = value; }
            get { return m_color; }
        }

        public float tMin
        {
            set { m_tMinValue = value; }
            get { return m_tMinValue; }
        }

        abstract public int GetIntersect(CRay ray);
    }
}
