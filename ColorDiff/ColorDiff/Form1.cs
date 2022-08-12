using System.Linq;
using System.Windows.Forms;

namespace ColorDiff
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Timer_Tick(object sender, System.EventArgs e)
        {
            int min = int.MaxValue;
            int max = int.MinValue;

            RTB.Text = "";
            foreach (PowerPictureBox pbx in TLP.Controls.OfType<PowerPictureBox>())
            {
                int val = pbx.Colors.Count;
                if (val < min) min = val;
                if (val > max) max = val;
                RTB.Text += $"{pbx.AccessibleName}: {val} colors\n";
            }

            RTB.Text += $"Range: {max - min} colors";
        }
    }
}
