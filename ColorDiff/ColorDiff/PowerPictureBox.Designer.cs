namespace ColorDiff
{
    partial class PowerPictureBox
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PowerPictureBox));
            this.PBX = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.PBX)).BeginInit();
            this.SuspendLayout();
            // 
            // PBX
            // 
            this.PBX.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("PBX.BackgroundImage")));
            this.PBX.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.PBX.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PBX.Location = new System.Drawing.Point(0, 0);
            this.PBX.Name = "PBX";
            this.PBX.Size = new System.Drawing.Size(300, 300);
            this.PBX.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PBX.TabIndex = 0;
            this.PBX.TabStop = false;
            // 
            // PowerPictureBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.PBX);
            this.Margin = new System.Windows.Forms.Padding(10);
            this.Name = "PowerPictureBox";
            this.Size = new System.Drawing.Size(300, 300);
            ((System.ComponentModel.ISupportInitialize)(this.PBX)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox PBX;
    }
}
