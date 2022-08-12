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

        public void RefreshData()
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

            // These calcs would be harder with > 2 pbxs
            int intersect = powerPictureBox1.Colors.Intersect(powerPictureBox2.Colors).Count();
            int exclude = powerPictureBox1.Colors.Except(powerPictureBox2.Colors).Count();

            RTB.Text += $"Intersect: {intersect} colors\n";
            RTB.Text += $"Exclude: {exclude} colors\n";
        }
    }
}
