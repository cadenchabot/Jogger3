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
    public partial class frmLevel1 : Form
    {
        private Car[] cars;
        private Log[] logs;
        private Bush[] bushes;
        private Home[] homes;
        private Water water;
        private Difficulty difficulty;
        // Game variables
        int forwardMoves = 0;
        int points = 0;
        int time;
        int lives = 3;

        // Level variables
        const int WATER_START = 516;
        const int WATER_END = 118;
        const int JOGGER_AMOUNT = 50;
        public int screenLeft = 0;
        public int screenTop  = 0;
        public int screenRight;
        public int screenBottom;

        const int LANE1_CARS = 2;
        const int LANE2_CARS = 4;
        const int LANE3_CARS = 7;
        const int LANE4_CARS = 9;
        const int MAX_CARS = 10;

        const int LANE1_LOGS = 2;
        const int LANE2_LOGS = 4;
        const int LANE3_LOGS = 8;
        const int LANE4_LOGS = 10;
        const int LANE5_LOGS = 13;
        const int MAX_LOGS = 14;

        const int MAX_HOMES = 5;
        //public Timer JoggerMovementTimer;
        //public Timer KeyDelayTimer;
        //public Timer GameTimer;

        private Jogger jogger;

        

        public frmLevel1(string level)
        {
            InitializeComponent();
            difficulty = new Difficulty(level);
            time = difficulty.TIME;
            lblTime.Text = "Time: " + difficulty.TIME;

        }

        private void frmLevel1_Load(object sender, EventArgs e)
        {
            SetCars();
            SetLogs();
            SetHomes();
            SetBushes();
            SetScreen();
            jogger = new Jogger(picJogger, JOGGER_AMOUNT, cars, bushes, homes, logs, water, this);
        }

        private void SetBushes()
        {
            PictureBox[] bushImages = {picBush1, picBush2, picBush3};
            bushes = new Bush[bushImages.Length];
            for (int i = 0; i < bushImages.Length; i++)
            {
                bushes[i] = new Bush(bushImages[i]);
            }
        }

        private void SetScreen()
        { 
            screenRight = screenLeft + this.Width;
            screenBottom = (screenTop + this.Height) - 50;
        }

        private void SetHomes()
        {
            PictureBox[] homeImages = { picHouse1, picHouse2, picHouse3, picHouse4, picHouse5 };
            homes = new Home[homeImages.Length];
            for (int i = 0; i < homeImages.Length; i++)
            {
                homes[i] = new Home(homeImages[i]);
            }
        }

        private void SetLogs()
        {
            PictureBox[] logImages = {picLog1, picLog2, picLog3, picLog4, picLog5, picLog6, picLog7,
                picLog8, picLog9, picLog10, picLog11, picLog12, picLog13, picLog14};
            logs = new Log[logImages.Length];
            int i = 0;
            for (i = i; i < LANE1_LOGS; i++)
            {
                logs[i] = new Log(logImages[i], difficulty.RandomSpeed(), Directions.RIGHT, this);
            }
            for (i = i; i < LANE2_LOGS; i++)
            {
                logs[i] = new Log(logImages[i], difficulty.RandomSpeed(), Directions.LEFT, this);
            }
            for (i = i; i < LANE3_LOGS; i++)
            {
                logs[i] = new Log(logImages[i], difficulty.RandomSpeed(), Directions.RIGHT, this);
            }
            for (i = i; i < LANE4_LOGS; i++)
            {
                logs[i] = new Log(logImages[i], difficulty.RandomSpeed(), Directions.LEFT, this);
            }
            for (i = i; i < LANE5_LOGS; i++)
            {
                logs[i] = new Log(logImages[i], difficulty.RandomSpeed(), Directions.LEFT, this);
            }
        }

        private void SetCars()
        {
            PictureBox[] carImages = {picCar1, picCar2, picCar3, picCar4, picCar5,
                picCar6, picCar7, picCar8, picCar9, picCar10};
            cars = new Car[carImages.Length];
            for (int i = 0; i < LANE1_CARS; i++)
            {
                cars[i] = new Car(carImages[i], difficulty.RandomSpeed(), Directions.RIGHT, this);
            }
            for (int i = 0; i < LANE2_CARS; i++)
            {
                cars[i] = new Car(carImages[i], difficulty.RandomSpeed(), Directions.LEFT, this);
            }
            for (int i = 0; i < LANE3_CARS; i++)
            {
                cars[i] = new Car(carImages[i], difficulty.RandomSpeed(), Directions.RIGHT, this);
            }
            for (int i = 0; i < LANE4_CARS; i++)
            {
                cars[i] = new Car(carImages[i], difficulty.RandomSpeed(), Directions.LEFT, this);
            }
        }

        private void frmLevel1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                // Go back to menu
                frmMainMenu menu = new frmMainMenu();
                menu.Show();
                this.Dispose();
            }
            if (jogger.canMove == true)
            {
                jogger.canMove = false;
                if (e.KeyCode == Keys.Up)
                {
                    // Move forward and add points
                    jogger.SetDirection(Directions.UP);
                    JoggerMovementTimer.Enabled = true;
                    GetPoints();
                }
                else if (e.KeyCode == Keys.Down)
                {
                    // Move backwards and subtract points 
                    jogger.SetDirection(Directions.DOWN);
                    JoggerMovementTimer.Enabled = true;
                    forwardMoves--;
                }
                else if (e.KeyCode == Keys.Left)
                {
                    // Move left
                    jogger.SetDirection(Directions.LEFT);
                    JoggerMovementTimer.Enabled = true;
                }
                else if (e.KeyCode == Keys.Right)
                {
                    // Move right
                    jogger.SetDirection(Directions.RIGHT);
                    JoggerMovementTimer.Enabled = true;
                }
                KeyDelayTimer.Enabled = true;
            }
        }

        private void GetPoints()
        {
            forwardMoves++;
            points = forwardMoves;
            lblScore.Text = "Score: " + points;
        }

        private void frmLevel1_KeyUp(object sender, KeyEventArgs e)
        {
            // Disable the jogger's movement
            JoggerMovementTimer.Enabled = false;
        }

        private void JoggerMovementTimer_Tick(object sender, EventArgs e)
        {
            jogger.GetCoordinates();
            jogger.Move();
            jogger.KeepOnScreen();
            jogger.ReDraw();
            JoggerMovementTimer.Enabled = false;
        }

        private void KeyDelayTimer_Tick(object sender, EventArgs e)
        {
            jogger.canMove = true;
            KeyDelayTimer.Enabled = false;
        }

        private void GameTimer_Tick(object sender, EventArgs e)
        {
            time--;
            lblTime.Text = "Time: " + time;
            if (time == 0)
            {
                GameTimer.Enabled = false;
                GameOver();
            }
        }

        private void CheckLives()
        {
            lives = jogger.lives;
            if (lives == 2) picLives3.Visible = false;
            if (lives == 1) picLives2.Visible = false;
            if (lives == 0)
            {
                picLives1.Visible = false;
                GameOver();
            }
        }

        private void GameOver()
        {
            
        }

        private void CheckTimer_Tick(object sender, EventArgs e)
        {
            jogger.CheckCollisions();
            CheckWater();
            MoveCarsAndLogs();
        }

        private void MoveCarsAndLogs()
        {
            for (int i = 0; i < cars.Length; i++) cars[i].MoveCars();
            for (int i = 0; i < logs.Length; i++) logs[i].MoveLogs();
        }

        private void CheckWater()
        {
            if (jogger.bottom <= WATER_START && jogger.bottom >= WATER_END && jogger.onLog == false) jogger.LoseLife();
            if (jogger.top <= WATER_END)
            {
                jogger.top = WATER_END - 1;
                jogger.ReDraw();
                jogger.ReCalculate();
            }
        }

    }
}

