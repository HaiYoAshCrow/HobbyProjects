using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Threading;

using RayTracer.MathLib;
using RayTracer.Rendering;
using RayTracer.Rendering.Cameras;

namespace RayTracer
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            CScene scene = new CScene();
            scene.BuildScene();

            // Attach the scene to the camera for rendering
            COrthographicCamera orth_cam = new COrthographicCamera();

            // Orthographic Camera
            System.Console.WriteLine("Rendering Orthographic...");
            orth_cam.Scene = scene;
            orth_cam.RenderScene();

            // Pinhole camera
            System.Console.WriteLine("Rendering Pinhole...");
            CPinholeCamera pinhole_cam = new CPinholeCamera();
            pinhole_cam.Up = new CVector3(0, 1, 0);
            pinhole_cam.Eye = new CPoint3(0, 0, 500);
            pinhole_cam.LookAt = new CPoint3(0, 0, 0);
            pinhole_cam.ViewDistance = 500;
            pinhole_cam.Zoom = 1;
            pinhole_cam.ExposureTime = 1;
            pinhole_cam.ComputerUVW();

            pinhole_cam.Scene = scene;
            pinhole_cam.RenderScene();

            // Display
            System.Console.WriteLine("Finished Rendering!");
            DisplayImage(orth_cam.Image, "Orthographic Camera");
            DisplayImage(pinhole_cam.Image, "Pinhole Camera");

        }

        public static void DisplayImage(Bitmap image, String result_of)
        {
            Thread form_thread = new Thread((ThreadStart)delegate
            {
                // Display the rendering results
                Form f = new Form();
                PictureBox pictureBox = new PictureBox();
                pictureBox.Image = image;
                pictureBox.Dock = DockStyle.Fill;
                pictureBox.SizeMode = PictureBoxSizeMode.AutoSize;
                f.Controls.Add(pictureBox);
                f.AutoSize = true;
                f.Text = result_of;
                f.ShowDialog();
            });

            form_thread.Start();
        }
    }
}
