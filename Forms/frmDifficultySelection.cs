using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Jogger3
{
    public partial class frmDifficultySelection : Form
    {
        public frmDifficultySelection()
        {
            InitializeComponent();
        }

        private void btnEasy_Click(object sender, EventArgs e)
        {
            frmLevel1 level1 = new frmLevel1("easy");
            level1.Show();
            this.Dispose();
        }

        private void btnMedium_Click(object sender, EventArgs e)
        {
            frmLevel1 level1 = new frmLevel1("medium");
            level1.Show();
            this.Dispose();
        }

        private void btnHard_Click(object sender, EventArgs e)
        {
            frmLevel1 level1 = new frmLevel1("hard");
            level1.Show();
            this.Dispose();
        }
    }
}
