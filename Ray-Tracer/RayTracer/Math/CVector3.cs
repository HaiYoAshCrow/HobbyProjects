using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/**
    Representation of a vector in 3D space

    Author: LunarOwl
    Last Modified: 17th March 2016
*/
namespace RayTracer.MathLib
{
    class CVector3 : CPoint3
    {
        public CVector3(float x, float y, float z) : base (x,y,z)
        {
        }

        // Addition
        public static CVector3 operator + (CVector3 v1, CVector3 v2)
        {
            return new CVector3(v1.x + v2.x, v1.y + v2.y, v1.z + v2.z);
        }

        // Subtraction between vectors
        public static CVector3 operator - (CVector3 v1, CVector3 v2)
        {
            return new CVector3(v1.x - v2.x, v1.y - v2.y, v1.z - v2.z);
        }

        // Dot Product 
        public static float operator * (CVector3 v1, CVector3 v2)
        {
            return (v1.x * v2.x) + (v1.y * v2.y) + (v1.z * v2.z);
        }

        // Vector Multiplication
        public static CVector3 operator ^(CVector3 v1, CVector3 v2)
        {
            return new CVector3((v1.x * v2.x), (v1.y * v2.y), (v1.z * v2.z));
        }

        // Scalar Multiplication
        public static CVector3 operator *(CVector3 v1, float scalar)
        {
            return new CVector3(v1.x*scalar, 
                               v1.y*scalar, 
                               v1.z*scalar);
        }

        // Scalar Multiplication
        public static CVector3 operator *(float scalar, CVector3 v1)
        {
            return new CVector3(v1.x * scalar,
                               v1.y * scalar,
                               v1.z * scalar);
        }

        // Scalar Division
        public static CVector3 operator /(CVector3 v1, float scalar)
        {
            return new CVector3(v1.x / scalar,
                               v1.y / scalar,
                               v1.z / scalar);
        }
        // Cross product between this vector and another
        public CVector3 Cross(CVector3 v)
        {
            return new CVector3((y * v.z) - (z * v.y),
                               (z * v.x) - (x * v.z),
                               (x * v.y) - (y * v.x));
        }

        // Get the magnitude of the vector
        public float GetMagnitude()
        {
            return (x * x + y * y + z * z);
        }

        // Get the normal of the vector
        public float GetNorm()
        {
            return (float) Math.Sqrt(GetMagnitude());
        }

        // Normalize the vector
        public void Normalize()
        {
            x /= GetNorm();
            y /= GetNorm();
            z /= GetNorm();
        }

        // Convert to a 4-element vector array
        public float[] ToArray4()
        {
            return new float[] { x, y, z, 1 };
        }

        // Converts a 4-element vector array to a 3 element vector
        public static CVector3 ToCVector3(float [] vec4)
        {
            return new CVector3(vec4[0],vec4[1],vec4[2]);
        }

    }
}
