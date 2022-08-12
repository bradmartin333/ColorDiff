using System;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace ColorDiff
{
    public partial class Form1 : Form
    {
        protected bool ValidData;
        private string PathA, PathB;
        protected Image ImageA, ImageB;
        protected Thread GetImageThread;

        public Form1()
        {
            InitializeComponent();

            pictureBox1.AllowDrop = true;
            pictureBox1.DragEnter += PictureBox1_DragEnter;
            pictureBox1.DragDrop += PictureBox1_DragDrop;

            pictureBox2.AllowDrop = true;
            pictureBox2.DragEnter += PictureBox2_DragEnter;
            pictureBox2.DragDrop += PictureBox2_DragDrop;
        }

        private void PictureBox1_DragEnter(object sender, DragEventArgs e)
        {
            DoDragEnter(e, true);
        }

        private void PictureBox1_DragDrop(object sender, DragEventArgs e)
        {
            DoDragDrop(pictureBox1, ImageA);
        }

        private void PictureBox2_DragEnter(object sender, DragEventArgs e)
        {
            DoDragEnter(e, false);
        }

        private void PictureBox2_DragDrop(object sender, DragEventArgs e)
        {
            DoDragDrop(pictureBox2, ImageB);
        }

        private void DoDragEnter(DragEventArgs e, bool isA)
        {
            string filename;
            ValidData = GetFilename(out filename, e);
            if (ValidData)
            {
                if (isA)
                {
                    PathA = filename;
                    GetImageThread = new Thread(new ThreadStart(LoadImageA));
                } 
                else
                {
                    PathB = filename;
                    GetImageThread = new Thread(new ThreadStart(LoadImageB));
                }
                GetImageThread.Start();
                e.Effect = DragDropEffects.Copy;
            }
            else
                e.Effect = DragDropEffects.None;
        }

        private void DoDragDrop(PictureBox pbx, Image img)
        {
            if (ValidData)
            {
                while (GetImageThread.IsAlive)
                {
                    Application.DoEvents();
                    Thread.Sleep(0);
                }
                pbx.BackgroundImage = img;
            }
        }

        private bool GetFilename(out string filename, DragEventArgs e)
        {
            bool ret = false;
            filename = String.Empty;
            if ((e.AllowedEffect & DragDropEffects.Copy) == DragDropEffects.Copy)
            {
                Array data = ((IDataObject)e.Data).GetData("FileDrop") as Array;
                if (data != null)
                {
                    if ((data.Length == 1) && (data.GetValue(0) is String))
                    {
                        filename = ((string[])data)[0];
                        string ext = Path.GetExtension(filename).ToLower();
                        if ((ext == ".jpg") || (ext == ".png") || (ext == ".bmp")) ret = true;
                    }
                }
            }
            return ret;
        }

        protected void LoadImageA() => ImageA = new Bitmap(PathA);
        protected void LoadImageB() => ImageB = new Bitmap(PathB);
    }
}
