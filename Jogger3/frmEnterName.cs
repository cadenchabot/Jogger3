using System;
using System.Windows.Forms;

namespace Jogger3
{
    public partial class frmEnterName : Form
    {
        public frmEnterName()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (txtName.Text == "") MessageBox.Show("Please enter a name.");
            else
            {
                Storage.currentName = txtName.Text;
                frmHighScores highScores = new frmHighScores();
                highScores.Show();
                this.Hide();
            }
        }

        private void frmEnterName_Load(object sender, EventArgs e)
        {
            if (Storage.currentScore > Storage.scoresList.Get(0) ||
                Storage.currentScore > Storage.scoresList.Get(1) ||
                Storage.currentScore > Storage.scoresList.Get(2) ||
                Storage.currentScore > Storage.scoresList.Get(3) ||
                Storage.currentScore > Storage.scoresList.Get(4) )
            {
                lblScore.Text = "You got a high score with: " + Storage.currentScore;
            }
            else
            {
                lblScore.Text = "You got a score with: " + Storage.currentScore;
            }
           
        }
    }
}
