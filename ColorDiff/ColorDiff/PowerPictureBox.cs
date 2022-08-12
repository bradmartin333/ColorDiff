using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace ColorDiff
{
    public partial class PowerPictureBox : UserControl
    {
        public List<int> Colors = new List<int>();

        private readonly List<Rectangle> Rects = new List<Rectangle>();
        private bool DrawingPost = false;
        private Point StartPoint = Point.Empty;
        private Point EndPoint = Point.Empty;

        private protected bool ValidData;
        private string ImagePath;
        private protected Image Image;
        private protected Thread GetImageThread;

        public PowerPictureBox()
        {
            InitializeComponent();

            PBX.MouseDown += PBX_MouseDown;
            PBX.MouseMove += PBX_MouseMove;

            PBX.AllowDrop = true;
            PBX.DragEnter += PBX_DragEnter;
            PBX.DragDrop += PBX_DragDrop;
        }

        #region Drawing ROI

        private void PBX_MouseDown(object sender, MouseEventArgs e)
        {
            switch (e.Button)
            {
                case MouseButtons.Left:
                    DrawingPost = !DrawingPost;
                    if (!DrawingPost)
                    {
                        UpdateOverlay(e.Button);
                        UpdateColors();
                        return;
                    }
                    break;
                default:
                    return;
            }

            StartPoint = ZoomMousePos(e.Location);
            EndPoint = StartPoint;
            PBX.Image = null;
            UpdateOverlay();
        }

        private void PBX_MouseMove(object sender, MouseEventArgs e)
        {
            if (DrawingPost)
            {
                EndPoint = ZoomMousePos(e.Location);
                UpdateOverlay();
            }
        }

        private void UpdateOverlay(MouseButtons btn = MouseButtons.None)
        {
            Bitmap bmp = new Bitmap(PBX.BackgroundImage.Width, PBX.BackgroundImage.Height);
            
            Rectangle newRect = new Rectangle(
                Math.Min(StartPoint.X, EndPoint.X),
                Math.Min(StartPoint.Y, EndPoint.Y),
                Math.Abs(EndPoint.X - StartPoint.X),
                Math.Abs(EndPoint.Y - StartPoint.Y));

            if (btn == MouseButtons.Left && newRect != Rectangle.Empty) Rects.Add(newRect);

            using (Graphics g = Graphics.FromImage(bmp))
            {
                if (DrawingPost) g.DrawRectangle(new Pen(Brushes.HotPink, (float)(Math.Min(bmp.Height, bmp.Width) * 0.005)), newRect);
                foreach (Rectangle rect in Rects)
                    g.DrawRectangle(new Pen(Brushes.HotPink, (float)(Math.Min(bmp.Height, bmp.Width) * 0.005)), rect);
            }

            PBX.Image = bmp;
        }

        private void UpdateColors()
        {
            Bitmap clone = (Bitmap)PBX.BackgroundImage.Clone();
            Colors.Clear();
            foreach (Rectangle rect in Rects)
                for (int i = rect.Left; i < rect.Right; i++)
                    for (int j = rect.Top; j < rect.Bottom; j++)
                    {
                        int c = clone.GetPixel(i, j).ToArgb();
                        if (!Colors.Contains(c)) Colors.Add(c);
                    }
            Application.OpenForms.OfType<Form1>().First().RefreshData();
        }

        /// <summary>
        /// Method for adjusting mouse pos to pictureBox set to Zoom
        /// </summary>
        /// <param name="click">
        /// Mouse coordinates
        /// </param>
        /// <returns>
        /// Pixel coordinates
        /// </returns>
        private Point ZoomMousePos(Point click)
        {
            Size pbxSize = PBX.Size;
            Size imgSize = PBX.BackgroundImage.Size;
            float ImageAspect = imgSize.Width / (float)imgSize.Height;
            float controlAspect = pbxSize.Width / (float)pbxSize.Height;
            PointF pos = new PointF(click.X, click.Y);
            if (ImageAspect > controlAspect)
            {
                float ratioWidth = imgSize.Width / (float)pbxSize.Width;
                pos.X *= ratioWidth;
                float scale = pbxSize.Width / (float)imgSize.Width;
                float displayHeight = scale * imgSize.Height;
                float diffHeight = pbxSize.Height - displayHeight;
                diffHeight /= 2;
                pos.Y -= diffHeight;
                pos.Y /= scale;
            }
            else
            {
                float ratioHeight = imgSize.Height / (float)pbxSize.Height;
                pos.Y *= ratioHeight;
                float scale = pbxSize.Height / (float)imgSize.Height;
                float displayWidth = scale * imgSize.Width;
                float diffWidth = pbxSize.Width - displayWidth;
                diffWidth /= 2;
                pos.X -= diffWidth;
                pos.X /= scale;
            }
            return new Point((int)pos.X, (int)pos.Y);
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            Rects.Clear();
            UpdateOverlay();
            UpdateColors();
        }

        #endregion

        #region Drag Drop Image

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
                if (e.Data.GetData("FileDrop") is Array data)
                    if ((data.Length == 1) && (data.GetValue(0) is string))
                    {
                        filename = ((string[])data)[0];
                        string ext = Path.GetExtension(filename).ToLower();
                        if ((ext == ".jpg") || (ext == ".png") || (ext == ".bmp")) ret = true;
                    }
            return ret;
        }

        protected void LoadImage() => Image = new Bitmap(ImagePath);

        #endregion
    }
}
