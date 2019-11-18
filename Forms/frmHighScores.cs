using System;
using System.Windows.Forms;
using PermanentStorage;

namespace Jogger3
{
    public partial class frmHighScores : Form
    {
        public frmHighScores()
        {
            InitializeComponent();
        }

        private void ShowMenu()
        {
            frmMainMenu menu = new frmMainMenu();
            menu.Show();
            this.Dispose();
        }

        private void frmHighScores_Load(object sender, EventArgs e)
        {
            GetScores();
            SetLabels();
        }

        private void SetLabels()
        {
            lblScore1.Text = "" + Storage.scoresList.Get(0);
            lblScore2.Text = "" + Storage.scoresList.Get(1);
            lblScore3.Text = "" + Storage.scoresList.Get(2);
            lblScore4.Text = "" + Storage.scoresList.Get(3);
            lblScore5.Text = "" + Storage.scoresList.Get(4);


            lblName1.Text = "" + Storage.namesList.Get(0);
            lblName2.Text = "" + Storage.namesList.Get(1);
            lblName3.Text = "" + Storage.namesList.Get(2);
            lblName4.Text = "" + Storage.namesList.Get(3);
            lblName5.Text = "" + Storage.namesList.Get(4);
        }

        private void GetScores()
        {
            if (Storage.currentScore > 0)
            {
                Storage.scoresList.Add(Storage.currentScore);
                Storage.namesList.Add(Storage.currentName);
                Storage.currentScore = 0;
                Sorter.SortScores(Storage.scoresList, Storage.namesList);
            } 

        }

        private void SaveScores()
        {
            FileHandler fileHandler = new FileHandler();
            fileHandler.Save(Storage.scoresList, Storage.pointsFileName);
            fileHandler.Save(Storage.namesList, Storage.nameFileName);

        }

        private void btnBack_Click_1(object sender, EventArgs e)
        {
            SaveScores();
            ShowMenu();
        }
    }
}

        
