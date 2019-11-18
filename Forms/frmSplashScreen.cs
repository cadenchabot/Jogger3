using System;
using System.Windows.Forms;
using PermanentStorage;

namespace Jogger3
{
    public partial class frmSplashScreen : Form
    {
        public frmSplashScreen()
        {
            InitializeComponent();
        }

        private void frmSplashScreen_Load(object sender, EventArgs e)
        {
            FileHandler fileHandler = new FileHandler();
            Storage.scoresList = fileHandler.OpenIntList(Storage.pointsFileName);
            Storage.namesList  = fileHandler.OpenStringList(Storage.nameFileName);
        }

        private void SplashScreenTimer_Tick(object sender, EventArgs e)
        {
            frmMainMenu menu = new frmMainMenu();
            menu.Show();
            SplashScreenTimer.Enabled = false;
            this.Hide();
        }
    }
}
