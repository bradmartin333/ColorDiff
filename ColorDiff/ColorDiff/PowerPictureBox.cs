using System;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace ColorDiff
{
    public partial class PowerPictureBox : UserControl
    {
        private protected bool ValidData;
        private string ImagePath;
        private protected Image Image;
        private protected Thread GetImageThread;

        public PowerPictureBox()
        {
            InitializeComponent();
            PBX.AllowDrop = true;
            PBX.DragEnter += PBX_DragEnter;
            PBX.DragDrop += PBX_DragDrop;
        }

        private void PBX_DragEnter(object sender, DragEventArgs e)
        {
            ValidData = GetFilename(out string filename, e);
            if (ValidData)
            {
                ImagePath = filename;
                GetImageThread = new Thread(new ThreadStart(LoadImage));
                GetImageThread.Start();
                e.Effect = DragDropEffects.Copy;
            }
            else
                e.Effect = DragDropEffects.None;
        }

        private void PBX_DragDrop(object sender, DragEventArgs e)
        {
            if (ValidData)
            {
                while (GetImageThread.IsAlive)
                {
                    Application.DoEvents();
                    Thread.Sleep(0);
                }
                PBX.BackgroundImage = Image;
            }
        }

        private bool GetFilename(out string filename, DragEventArgs e)
        {
            bool ret = false;
            filename = string.Empty;
            if ((e.AllowedEffect & DragDropEffects.Copy) == DragDropEffects.Copy)
            {
                if (e.Data.GetData("FileDrop") is Array data)
                {
                    if ((data.Length == 1) && (data.GetValue(0) is string))
                    {
                        filename = ((string[])data)[0];
                        string ext = Path.GetExtension(filename).ToLower();
                        if ((ext == ".jpg") || (ext == ".png") || (ext == ".bmp")) ret = true;
                    }
                }
            }
            return ret;
        }

        protected void LoadImage() => Image = new Bitmap(ImagePath);
    }
}
