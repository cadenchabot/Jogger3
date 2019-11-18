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
    public partial class frmMainMenu : Form
    {
        public frmMainMenu()
        {
            InitializeComponent();
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            frmDifficultySelection difficulty = new frmDifficultySelection();
            difficulty.Show();
            this.Dispose();
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            frmHowToPlay howToPlay = new frmHowToPlay();
            howToPlay.Show();
            this.Dispose();
        }

        private void btnHighScores_Click(object sender, EventArgs e)
        {
            frmHighScores highScores = new frmHighScores();
            highScores.Show();
            this.Dispose();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
