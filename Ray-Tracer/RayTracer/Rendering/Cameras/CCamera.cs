using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using RayTracer.MathLib;

namespace RayTracer.Rendering.Cameras
{
    abstract class CCamera
    {
        CPoint3  m_eye;
        CPoint3  m_lookat;
        CVector3 m_up;
        CVector3 m_u, m_v, m_w;   // View-space co-ordinates
        CScene   m_scene;
        Bitmap   m_image;                  // Image to save to
        float    m_exposureTime;

        public CPoint3 Eye
        {
            set { m_eye = value; }
            get { return m_eye; }
        }

        public CPoint3 LookAt
        {
            set { m_lookat = value; }
            get { return m_lookat; }
        }

        public CVector3 Up
        {
            set { m_up = value; }
            get { return m_up; }
        }

        public CVector3 U
        {
            set { m_u = value; }
            get { return m_u; }
        }

        public CVector3 W
        {
            set { m_w = value; }
            get { return m_w; }
        }

        public CVector3 V
        {
            set { m_v = value; }
            get { return m_v; }
        }

        public CScene Scene
        {
            set { m_scene = value; }
            get { return m_scene; }
        }

        public Bitmap Image
        {
            set { m_image = value; }
            get { return m_image; }
        }

        public float ExposureTime
        {
            set { m_exposureTime = value; }
            get { return m_exposureTime; }
        }

        public void ComputerUVW()
        {
            m_w = m_eye - m_lookat;
            m_w.Normalize();
            m_u = m_up.Cross(m_w);
            m_u.Normalize();
            m_v = m_w.Cross(m_u);

            if (m_eye.x == m_lookat.x && m_eye.z == m_lookat.z && m_eye.y > m_lookat.y)
            { // camera looking vertically down
                m_u = new CVector3(0, 0, 1);
                m_v = new CVector3(1, 0, 0);
                m_w = new CVector3(0, 1, 0);
            }

            if (m_eye.x == m_lookat.x && m_eye.z == m_lookat.z && m_eye.y < m_lookat.y)
            { // camera looking vertically up
                m_u = new CVector3(1, 0, 0);
                m_v = new CVector3(0, 0, 1);
                m_w = new CVector3(0, -1, 0);
            }
        }

        abstract public void RenderScene();
        
    }
}
