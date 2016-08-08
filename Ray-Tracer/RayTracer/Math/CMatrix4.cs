using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/**
    Representation of a 4x4 Matrix

    Author: LunarOwl
    Last Modified: 17th March 2016
*/
namespace RayTracer.MathLib
{
    class CMatrix4
    {
        // NB: 1st index controls x, 2nd index controls y
        float[,] m_values = new float[4, 4];

        public CMatrix4()
        {
        }

        #region Basic Operations
        public float[,] elements
        {
            get { return m_values; }
        }

        /**
            Gets a specified row from the matrix

            Param: Row number
            Returns: Array containing row elements
        */
        public float[] GetRow(int row_number)
        {
            float[] row;
            switch (row_number)
            {
                case 1:
                    row = new float[] { m_values[0, 0], m_values[1, 0], m_values[2, 0], m_values[3,0] };
                    return row;
                case 2:
                    row = new float[] { m_values[0, 1], m_values[1, 1], m_values[2, 1], m_values[3, 1] };
                    return row;
                case 3:
                    row = new float[] { m_values[0, 2], m_values[1, 2], m_values[2, 2], m_values[3, 2] };
                    return row;
                case 4:
                    row = new float[] { m_values[0, 2], m_values[1, 2], m_values[2, 2], m_values[3, 3] };
                    return row;
                default:
                    Console.WriteLine("Warning! Invalid row specified! An empty array was returned!");
                    return new float[] { };
            };
        }

        /**
	        Sets a specified point from the matrix

        	Param: row, column, value
	        Returns: Nil
        */
        public void SetVal(int i, int j, float val)
        {
            m_values[i, j] = val;
        }

        /**
	        Sets a specified row from the matrix

        	Param: Row, Row number
	        Returns: Nil
        */
        public void SetRow(float[] row, int row_number)
        {
            switch (row_number)
            {
                case 1:
                    m_values[0, 0] = row[0];
                    m_values[1, 0] = row[1];
                    m_values[2, 0] = row[2];
                    m_values[3, 0] = row[3];
                    break;
                case 2:
                    m_values[0, 1] = row[0];
                    m_values[1, 1] = row[1];
                    m_values[2, 1] = row[2];
                    m_values[3, 1] = row[3];
                    break;
                case 3:
                    m_values[0, 2] = row[0];
                    m_values[1, 2] = row[1];
                    m_values[2, 2] = row[2];
                    m_values[3, 2] = row[3];
                    break;
                case 4:
                    m_values[0, 3] = row[0];
                    m_values[1, 3] = row[1];
                    m_values[2, 3] = row[2];
                    m_values[3, 3] = row[3];
                    break;
                default:
                    Console.WriteLine("Warning! Invalid row specified! No changes were made!");
                    break;
            };
        }

        /**
            Returns a string containing the matrix contents in a formatted string

            Params: Nil
            Returns: String
        */
        public override string ToString()
        {
            String row1 = "[" + m_values[0, 0].ToString()
                              + "," + m_values[1, 0].ToString()
                              + "," + m_values[2, 0].ToString() 
                              + "," + m_values[3, 0].ToString() + "]";

            String row2 = "[" + m_values[0, 1].ToString()
                              + "," + m_values[1, 1].ToString()
                              + "," + m_values[2, 1].ToString()
                              +"," + m_values[3, 1].ToString() + "]";
             
            String row3 = "[" + m_values[0, 2].ToString()
                  + "," + m_values[1, 2].ToString()
                  + "," + m_values[2, 2].ToString()
                  +"," + m_values[3, 2].ToString() + "]";

            String row4 = "[" + m_values[0, 3].ToString()
                  + "," + m_values[1, 3].ToString()
                  + "," + m_values[2, 3].ToString()
                  + "," + m_values[3, 3].ToString() + "]";

            return row1 + "\n" + row2 + "\n" + row3 + "\n" + row4;
        }
        #endregion

        #region Math Operations

        /**
            Matrix multiplcation with another matrix

            Params: Matrix 1, Matrix 2
            Returns: Combined Matrix
        */
        public static CMatrix4 operator *(CMatrix4 mat1, CMatrix4 mat2)
        {
            CMatrix4 new_matrix = new CMatrix4();
            for(int i = 0; i < 4; i++)
            {
                for(int j = 0; j < 4; j++)
                {
                    new_matrix.m_values[i, j] += mat1.m_values[i, j] * mat2.m_values[i, j];
                }
            }
            return new_matrix;
        }

        /**
            Matrix multiplcation with a vector - Transformation purposes

            Params:  Matrix, Vector
            Returns: Transformed Vector
        */
        public static CVector3 operator *(CVector3 vec, CMatrix4 mat)
        {
            // Expand the vector to 4 elements by adding a 1 at w
            float [] expanded_vec = vec.ToArray4();
            CVector3 transformed_vec = new CVector3(0, 0, 0);
            float [] row1 = mat.GetRow(1); float [] row2 = mat.GetRow(2);
            float [] row3 = mat.GetRow(3); float[] row4 = mat.GetRow(4);

            float t_x = row1[0] * expanded_vec[0] + row1[1] * expanded_vec[1]
                      + row1[2] * expanded_vec[2] + row1[3] * expanded_vec[3];

            float t_y = row2[0] * expanded_vec[0] + row2[1] * expanded_vec[1]
                      + row2[2] * expanded_vec[2] + row2[3] * expanded_vec[3];

            float t_z = row3[0] * expanded_vec[0] + row3[1] * expanded_vec[1]
                      + row3[2] * expanded_vec[2] + row3[3] * expanded_vec[3];

            // Not necessary but for completeness sake
            float t_w = row4[0] * expanded_vec[0] + row4[1] * expanded_vec[1]
                      + row4[2] * expanded_vec[2] + row4[3] * expanded_vec[3];

            transformed_vec.x = t_x;
            transformed_vec.y = t_y;
            transformed_vec.z = t_z;

            return transformed_vec;
        }

        /**
            Builds an identity matrix

            Params: Nil
            Returns: Identity Matrix
        */
        public static CMatrix4 GetIdentity()
        {
            CMatrix4 identity = new CMatrix4();
            identity.SetRow(new float[] { 1, 0, 0, 0 }, 1);
            identity.SetRow(new float[] { 0, 1, 0, 0 }, 2);
            identity.SetRow(new float[] { 0, 0, 1, 0 }, 3);
            identity.SetRow(new float[] { 0, 0, 0, 1 }, 4);

            return identity;
        }

        /**
            Builds an rotation matrix

            Params:  Axis letter, angle
            Returns: Rotation Matrix
        */
        public static CMatrix4 GetRotation(char axis, float angle)
        {
            CMatrix4 rotation_mat = new CMatrix4();
            switch(axis)
            {
                case 'x':
                    rotation_mat.SetRow(new float[] { 1, 0, 0, 0 }, 1);
                    rotation_mat.SetRow(new float[] { 0, (float) Math.Cos(angle), -(float)Math.Sin(angle), 0 }, 2);
                    rotation_mat.SetRow(new float[] { 0, (float) Math.Sin(angle), (float)Math.Cos(angle), 0 }, 3);
                    rotation_mat.SetRow(new float[] { 0, 0, 0, 1 }, 4);

                    break;
                case 'y':
                    rotation_mat.SetRow(new float[] { (float)Math.Cos(angle), 0, (float)Math.Sin(angle), 0 }, 1);
                    rotation_mat.SetRow(new float[] { 0, 1, 0, 0 }, 2);
                    rotation_mat.SetRow(new float[] { -(float)Math.Sin(angle), 0, (float)Math.Cos(angle), 0 }, 3);
                    rotation_mat.SetRow(new float[] { 0, 0, 0, 1 }, 4);
                    break;
                case 'z':
                    rotation_mat.SetRow(new float[] { (float)Math.Cos(angle), -(float)Math.Sin(angle), 0,0 }, 1);
                    rotation_mat.SetRow(new float[] { (float)Math.Sin(angle), (float)Math.Cos(angle), 0,0}, 2);
                    rotation_mat.SetRow(new float[] { 0, 0, 1, 0 }, 3);
                    rotation_mat.SetRow(new float[] { 0, 0, 0, 1 }, 4);
                    break;
            }
            return rotation_mat;
        }

        /**
            Builds an translation matrix

            Params:  Array of axis-values
            Returns: Translation matrix
        */
        public static CMatrix4 GetTranslation(float [] axis)
        {
            CMatrix4 translation_mat = CMatrix4.GetIdentity();
            translation_mat.SetVal(3, 0, axis[0]);
            translation_mat.SetVal(3, 1, axis[1]);
            translation_mat.SetVal(3, 2, axis[2]);
            return translation_mat;
        }

        /**
            Builds an scaling matrix

            Params:  Array of axis-values
            Returns: Scaling matrix
        */
        public static CMatrix4 GetScaling(float [] axis)
        {
            CMatrix4 translation_mat = CMatrix4.GetIdentity();
            translation_mat.SetVal(0, 0, axis[0]);
            translation_mat.SetVal(1, 1, axis[1]);
            translation_mat.SetVal(2, 2, axis[2]);
            return translation_mat;
        }

        #endregion
    }
}
