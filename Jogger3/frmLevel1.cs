using System;
using System.Drawing;
using System.Media;
using System.Windows.Forms;

namespace Jogger3
{
    /// <summary>
    /// The level 1 form.
    /// </summary>
    public partial class frmLevel1 : Form
    {
        // Level properties
        private Car[]      cars;
        private Log[]      logs;
        private Bush[]     bushes;
        private Home[]     homes;
        private Water      water;
        private Sidewalk   sidewalk;
        private Difficulty difficulty;
        private Jogger     jogger;

        // Game variables
        int forwardMoves         = 0;
        int points               = 0;
        int time;
        int lives                = 3;
        bool gameWon             = false;
        private int MIN_SPEED;
        private int MAX_SPEED;

        // Level variables
        const int  JOGGER_AMOUNT = 60;
        public int screenLeft    = 0;
        public int screenTop     = 0;
        public int screenRight;
        public int screenBottom;
       
        // Car variables
        const int LANE1_CARS     = 2;
        const int LANE2_CARS     = 4;
        const int LANE3_CARS     = 7;
        const int LANE4_CARS     = 9;

        // Log variables
        const int LANE1_LOGS     = 2;
        const int LANE2_LOGS     = 4;
        const int LANE3_LOGS     = 8;
        const int LANE4_LOGS     = 10;
        const int LANE5_LOGS     = 13;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="level"></param> The difficulty.
        public frmLevel1(string level)
        {
            InitializeComponent();
            difficulty = new Difficulty(level);
            MIN_SPEED = difficulty.MIN_SPEED;
            MAX_SPEED = difficulty.MAX_SPEED;
            time = difficulty.TIME;
            lblTime.Text = "Time: " + difficulty.TIME;

        }

        private void frmLevel1_Load(object sender, EventArgs e)
        {
            SetCars();
            SetLogs();
            SetWater();
            SetHomes();
            SetBushes();
            SetSidewalk();
            SetScreen();
            jogger = new Jogger(picJogger, JOGGER_AMOUNT, cars, bushes, homes, logs, water, sidewalk, this);
        }

        /// <summary>
        /// Sets the water.
        /// </summary>
        private void SetWater()
        {
            PictureBox waterImage = picWater;
            water = new Water(waterImage);
        }

        /// <summary>
        /// Sets the sidewalk.
        /// </summary>
        private void SetSidewalk()
        {
            PictureBox sidewalkImage = picSidewalk;
            sidewalk = new Sidewalk(sidewalkImage);
        }

        /// <summary>
        /// Sets the bushes.
        /// </summary>
        private void SetBushes()
        {
            PictureBox[] bushImages = {picBush1, picBush2, picBush3};
            bushes = new Bush[bushImages.Length];
            for (int i = 0; i < bushImages.Length; i++)
            {
                bushes[i] = new Bush(bushImages[i]);
            }
        }

        /// <summary>
        /// Sets the screen.
        /// </summary>
        private void SetScreen()
        {
            screenRight = screenLeft + this.Width;
            screenBottom = (screenTop + this.Height) - 50;
        }

        /// <summary>
        /// Sets the homes.
        /// </summary>
        private void SetHomes()
        {
            PictureBox[] homeImages = { picHouse1, picHouse2, picHouse3, picHouse4, picHouse5 };
            homes = new Home[homeImages.Length];
            for (int i = 0; i < homeImages.Length; i++)
            {
                homes[i] = new Home(homeImages[i]);
            }
        }

        /// <summary>
        /// Sets the logs.
        /// </summary>
        private void SetLogs()
        {
            PictureBox[] logImages = {picLog1, picLog2, picLog3, picLog4, picLog5, picLog6, picLog7,
                picLog8, picLog9, picLog10, picLog11, picLog12, picLog13, picLog14};
            logs = new Log[logImages.Length];
            int i = 0;
            int speed = Calculator.RandomSpeed(MIN_SPEED, MAX_SPEED);
            for (i = i; i <= LANE1_LOGS; i++)
            {
                logs[i] = new Log(logImages[i], speed, Directions.RIGHT, this);
            }
            speed = Calculator.RandomSpeed(MIN_SPEED, MAX_SPEED);
            for (i = i; i <= LANE2_LOGS; i++)
            {
                logs[i] = new Log(logImages[i], speed, Directions.LEFT, this);
            }
            speed = Calculator.RandomSpeed(MIN_SPEED, MAX_SPEED);
            for (i = i; i <= LANE3_LOGS; i++)
            {
                logs[i] = new Log(logImages[i], speed, Directions.RIGHT, this);
            }
            speed = Calculator.RandomSpeed(MIN_SPEED, MAX_SPEED);
            for (i = i; i <= LANE4_LOGS; i++)
            {
                logs[i] = new Log(logImages[i], speed, Directions.LEFT, this);
            }
            speed = Calculator.RandomSpeed(MIN_SPEED, MAX_SPEED);
            for (i = i; i <= LANE5_LOGS; i++)
            {
                logs[i] = new Log(logImages[i], speed, Directions.RIGHT, this);
            }
        }

        /// <summary>
        /// Sets the cars.
        /// </summary>
        private void SetCars()
        {
            PictureBox[] carImages = {picCar1, picCar2, picCar3, picCar4, picCar5,
                picCar6, picCar7, picCar8, picCar9, picCar10};
            cars = new Car[carImages.Length];
            int i = 0;
            int speed = Calculator.RandomSpeed(MIN_SPEED, MAX_SPEED);
            for (i = i; i <= LANE1_CARS; i++)
            {
                cars[i] = new Car(carImages[i], speed, Directions.RIGHT, this);
            }
            speed = Calculator.RandomSpeed(MIN_SPEED, MAX_SPEED);
            for (i = i; i <= LANE2_CARS; i++)
            {
                cars[i] = new Car(carImages[i], speed, Directions.LEFT, this);
            }
            speed = Calculator.RandomSpeed(MIN_SPEED, MAX_SPEED);
            for (i = i; i <= LANE3_CARS; i++)
            {
                cars[i] = new Car(carImages[i], speed, Directions.RIGHT, this);
            }
            speed = Calculator.RandomSpeed(MIN_SPEED, MAX_SPEED);
            for (i = i; i <= LANE4_CARS; i++)
            {
                cars[i] = new Car(carImages[i], speed, Directions.LEFT, this);
            }
        }

        /// <summary>
        /// Adds to the score and sets the label.
        /// </summary>
        private void GetPoints()
        {
            forwardMoves+= 5;
            points = forwardMoves;
            lblScore.Text = "Score: " + points;
        }

        /// <summary>
        /// Checks the lives.
        /// </summary>
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
            gameWon = jogger.gameWon;
            if (gameWon) GameOver();
        }

        /// <summary>
        /// Ends the game.
        /// </summary>
        private void GameOver()
        {
            GameTimer.Enabled = false;
            JoggerMovementTimer.Enabled = false;
            CheckTimer.Enabled = false;
            KeyDelayTimer.Enabled = false;
            if (gameWon)
            {
                MessageBox.Show("Level complete, you win.");
                Storage.currentScore = points * difficulty.MULTIPLIER + time;
                frmEnterName enterName = new frmEnterName();
                enterName.Show();
                this.Dispose();
            }
            else
            {
                points = points * difficulty.MULTIPLIER;
                MessageBox.Show("Game over.");
                GameOverSound();
                Storage.currentScore = points;
                frmEnterName enterName = new frmEnterName();
                enterName.Show();
                this.Dispose();
            }
        }

        private void GameOverSound()
        {
            SoundPlayer player = new SoundPlayer(Jogger3.Properties.Resources.GameOver);
            player.Play();
        }

        private void CheckTimer_Tick(object sender, EventArgs e)
        {
            jogger.CheckCollisions();
            CheckLives();
            MoveCarsAndLogs();
        }

        /// <summary>
        /// Moves the cars and logs.
        /// </summary>
        private void MoveCarsAndLogs()
        {
            for (int i = 0; i < cars.Length; i++) cars[i].MoveCars();
            for (int i = 0; i < logs.Length; i++) logs[i].MoveLogs();
        }

        private void JoggerMovementTimer_Tick(object sender, EventArgs e)
        {
            jogger.GetCoordinates();
            jogger.Move();
            jogger.KeepOnScreen();
            jogger.ReDraw();
            JoggerMovementTimer.Enabled = false;
        }

        private void frmLevel1_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Pause();
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

        private void Pause()
        {
            JoggerMovementTimer.Enabled = false;
            CheckTimer.Enabled = false;
            KeyDelayTimer.Enabled = false;
            GameTimer.Enabled = false;
            jogger.canMove = false;
            btnResume.Visible = true;
            btnQuit.Visible = true;
            btnResume.Enabled = true;
            btnQuit.Enabled = true;
        }

        private void frmLevel1_KeyUp_1(object sender, KeyEventArgs e)
        {
            // Disable the jogger's movement
            JoggerMovementTimer.Enabled = false;
        }

        private void KeyDelayTimer_Tick_1(object sender, EventArgs e)
        {
            jogger.canMove = true;
            KeyDelayTimer.Enabled = false;
        }

        private void GameTimer_Tick_1(object sender, EventArgs e)
        {
            time--;
            lblTime.Text = "Time: " + time;
            if (time == 0)
            {
                GameTimer.Enabled = false;
                GameOver();
            }
        }

        private void btnResume_Click(object sender, EventArgs e)
        {
            JoggerMovementTimer.Enabled = true;
            CheckTimer.Enabled = true;
            KeyDelayTimer.Enabled = true;
            GameTimer.Enabled = true;
            jogger.canMove = true;
            btnResume.Visible = false;
            btnQuit.Visible = false;
            btnResume.Enabled = false;
            btnQuit.Enabled = false;
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            frmMainMenu menu = new frmMainMenu();
            menu.Show();
            this.Hide();
        }
    }
}

