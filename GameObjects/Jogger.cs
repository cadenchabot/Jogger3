using System;
using System.Drawing;
using System.Media;
using System.Windows.Forms;

namespace Jogger3
{
    /// <summary>
    /// Represents the main character.
    /// </summary>
    class Jogger : GameCharacter
    {
        private Car[]      cars;
        private Log[]      logs;
        private Bush[]     bushes;
        private Home[]     homes;
        private Sidewalk   sidewalk;
        private Water      water;
        private Form       level;

        public  bool onLog        = false;
        public  bool gameWon;
        public  bool canMove;
        public  int  lives        = 3;
        public  int  homesReached = 0;
        public  int  points       = 0;
        public  int  screenLeft;
        public  int  screenRight;
        public  int  screenTop;
        public  int  screenBottom;
        private Timer DeathTimer;

        public const int START_LEFT = 376;
        public const int START_TOP  = 759;

        
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="image"></param> The PictureBox associated with Jogger.
        /// <param name="amount"></param> The movement amount.
        /// <param name="cars"></param> The cars in the level.
        /// <param name="bushes"></param> The bushes in the level.
        /// <param name="homes"></param> The homes in the level.
        /// <param name="logs"></param> The logs in the level.
        /// <param name="water"></param> The water in the level.
        /// <param name="sidewalk"></param> The sidewalk in the level.
        /// <param name="level"></param> The level.
        public Jogger(PictureBox image, int amount, Car[] cars, Bush[] bushes, Home[] homes,
            Log[] logs, Water water, Sidewalk sidewalk, Form level) : base(image, amount)
        {
            this.cars = cars;
            this.bushes = bushes;
            this.homes = homes;
            this.logs = logs;
            this.water = water;
            this.sidewalk = sidewalk;
            this.level = level;
            Spawn();
            SetScreen();
            canMove = true;
            SetDeathTimer();
        }

        private void SetDeathTimer()
        {
            DeathTimer = new Timer();
            DeathTimer.Enabled = false;
            DeathTimer.Interval = 1000;
            DeathTimer.Tick += DeathTimer_Tick;
        }

        /// <summary>
        /// Sets the screen's sides.
        /// </summary>
        private void SetScreen()
        {
            screenLeft = 0;
            screenTop = 0;
            screenRight = screenLeft + level.Width;
            screenBottom = (screenTop + level.Height) - 50;
        }

        /// <summary>
        /// Checks jogger's collisons.
        /// </summary>
        public void CheckCollisions()
        {
            CheckBushes();
            CheckSidewalk();
            CheckCars();
            CheckLogs();
            CheckHomes();
            CheckWater();
            KeepOnScreen();
        }

        /// <summary>
        /// Checks if jogger is in the water and kills him if so.
        /// </summary>
        private void CheckWater()
        {
            if (IsCollidingWith(water) && onLog == false)
            {
                LoseLife();
                WaterSound();
            }
            if (top <= water.top)
            {
                top = water.top - 1;
                ReDraw();
                ReCalculate();
            }
        }

        private void WaterSound()
        {
            SoundPlayer player = new SoundPlayer(Jogger3.Properties.Resources.Splash);
            player.Play();
        }

        /// <summary>
        /// Keeps jogger in the middle of the sidewalk.
        /// </summary>
        private void CheckSidewalk()
        {
            if (IsCollidingWith(sidewalk))
            {
                StayOnObject(sidewalk);
                amount = 70;
            }
        }

        /// <summary>
        /// Keeps jogger on screen.
        /// </summary>
        public void KeepOnScreen()
        {
            if (left <= screenLeft)
            {
                left = screenLeft + 1;
            }
            else if (right >= screenRight)
            {
                left = screenRight - width - 1;
            }
            if (top <= screenTop)
            {
                top = screenTop + 1;
            }
            else if (bottom >= screenBottom)
            {
                top = screenBottom - height - 1;
            }
            ReDraw();
        }

        /// <summary>
        /// Checks if jogger has reached the end.
        /// </summary>
        private void CheckHomes()
        {
            for (int i = 0; i < homes.Length; i++)
            {
                if (IsCollidingWith(homes[i]))
                {
                    HomeReached();
                    homes[i].Kill();
                    homes[i].image.Image = Properties.Resources.JoggerFront;
                }
                if (homesReached == 5) gameWon = true;
            }

        }

        /// <summary>
        /// Actions when the end is reached.
        /// </summary>
        private void HomeReached()
        {
            homesReached++;
            StartPosition(START_LEFT, START_TOP);
            amount = 60;
            SuccessSound();
        }

        private void SuccessSound()
        {
            SoundPlayer player = new SoundPlayer(Jogger3.Properties.Resources.Success);
            player.Play();

        }

        /// <summary>
        /// Checks if jogger is on a log.
        /// </summary>
        private void CheckLogs()
        {
            onLog = false;
            for (int i = 0; i < logs.Length; i++)
            {
                if (IsCollidingWith(logs[i]))
                {
                    onLog = true;
                    StayOn(logs[i]);
                    amount = 55;
                    if (left <= 0 || right >= screenRight) LoseLife();
                }
            }
            CheckColor();

        }

        /// <summary>
        /// Sets jogger's color based on the background.
        /// </summary>
        private void CheckColor()
        {
            if (onLog) image.BackColor = Color.FromArgb(96, 57, 19);
            else image.BackColor = Color.Transparent;
        }

        /// <summary>
        /// Checks if jogger is colliding with a car.
        /// </summary>
        private void CheckCars()
        {
            for (int i = 0; i < cars.Length; i++)
            {
                if (IsCollidingWith(cars[i]))
                {
                    CarSound();
                    image.Image = Jogger3.Properties.Resources.Blood;
                    //LoseLife();
                    DeathTimer.Enabled = true;
                }
            }
        }

        private void CarSound()
        {
            SoundPlayer player = new SoundPlayer(Jogger3.Properties.Resources.CarCrash);
            player.Play();
        }

        /// <summary>
        /// Kills jogger.
        /// </summary>
        public void LoseLife()
        {
            image.Image = Jogger3.Properties.Resources.JoggerTopDown;
            Kill();
            lives--;
            StartPosition(START_LEFT, START_TOP);
            amount = 60;

        }

        /// <summary>
        /// Checks if jogger is colliding with a bush.
        /// </summary>
        private void CheckBushes()
        {
            for (int i = 0; i < bushes.Length; i++)
            {
                if (IsCollidingWith(bushes[i]))
                {
                    StickTo(bushes[i]);
                }
            }
        }

        private void DeathTimer_Tick(object sender, EventArgs e)
        {
            image.Image = Jogger3.Properties.Resources.JoggerTopDown;
            LoseLife();
            DeathTimer.Enabled = false;
        }

    }
}
