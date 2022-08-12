namespace ColorDiff
{
    partial class Form1
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.TLP = new System.Windows.Forms.TableLayoutPanel();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.powerPictureBox1 = new ColorDiff.PowerPictureBox();
            this.powerPictureBox2 = new ColorDiff.PowerPictureBox();
            this.TLP.SuspendLayout();
            this.SuspendLayout();
            // 
            // TLP
            // 
            this.TLP.BackColor = System.Drawing.Color.LightGray;
            this.TLP.ColumnCount = 2;
            this.TLP.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TLP.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TLP.Controls.Add(this.richTextBox1, 0, 1);
            this.TLP.Controls.Add(this.powerPictureBox1, 0, 0);
            this.TLP.Controls.Add(this.powerPictureBox2, 1, 0);
            this.TLP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TLP.Location = new System.Drawing.Point(0, 0);
            this.TLP.Name = "TLP";
            this.TLP.RowCount = 2;
            this.TLP.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TLP.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.TLP.Size = new System.Drawing.Size(800, 450);
            this.TLP.TabIndex = 0;
            // 
            // richTextBox1
            // 
            this.TLP.SetColumnSpan(this.richTextBox1, 2);
            this.richTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox1.Location = new System.Drawing.Point(3, 353);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(794, 94);
            this.richTextBox1.TabIndex = 2;
            this.richTextBox1.Text = "";
            // 
            // powerPictureBox1
            // 
            this.powerPictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.powerPictureBox1.Location = new System.Drawing.Point(10, 10);
            this.powerPictureBox1.Margin = new System.Windows.Forms.Padding(10);
            this.powerPictureBox1.Name = "powerPictureBox1";
            this.powerPictureBox1.Size = new System.Drawing.Size(380, 330);
            this.powerPictureBox1.TabIndex = 3;
            // 
            // powerPictureBox2
            // 
            this.powerPictureBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.powerPictureBox2.Location = new System.Drawing.Point(410, 10);
            this.powerPictureBox2.Margin = new System.Windows.Forms.Padding(10);
            this.powerPictureBox2.Name = "powerPictureBox2";
            this.powerPictureBox2.Size = new System.Drawing.Size(380, 330);
            this.powerPictureBox2.TabIndex = 4;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.TLP);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "Form1";
            this.Text = "Color Diff";
            this.TLP.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel TLP;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private PowerPictureBox powerPictureBox1;
        private PowerPictureBox powerPictureBox2;
    }
}

