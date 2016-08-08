using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RayTracer.MathLib;


/**
    Tracer that traces the rays and tests for intersection with objects

    Author: LunarOwl
    Last Modified: 17th March 2016
*/

namespace RayTracer.Rendering
{
    class CTracer
    {
        public CTracer()
        {

        }

        // Perform the ray tracing
        public CRCGColor TraceRay(CRay ray, List<CPrimitive> objects)
        {
            CRCGColor pixel_color = new CRCGColor(0,0,0);
            float t = -1; 
            float t_min = 100000; //Some large arbitary value

            for (int i = 0; i < objects.Count; i++)
            {
                int  hit = objects[i].GetIntersect(ray);
                t = objects[i].tMin;
                // If hit, return with the color of the object 
                if (hit == 1 && t < t_min)
                {
                    t_min = t;
                    pixel_color = objects[i].Color;
                }
                else
                {
                    // Return black or any other arbitary color we please
                }
            }

            return pixel_color;
        }
    }
}
