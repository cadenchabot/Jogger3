using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Jogger3
{
    /// <summary>
    /// Represents a log object.
    /// </summary>
    class Log : GameCharacter
    {
        private int screenLeft;
        private int screenRight;
        private int screenTop;
        private int screenBottom;
        private Form level;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="image"></param> The PictureBox associated with the log.
        /// <param name="amount"></param> The movement amount.
        /// <param name="direction"></param> The direction to move.
        /// <param name="level"></param> The level.
        public Log(PictureBox image, int amount, int direction, Form level) : base(image, amount)
        {
            this.level = level;
            this.direction = direction;
            Spawn();
            SetScreen();
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
        /// Moves the logs from one end to another and returns them.
        /// </summary>
        public void MoveLogs()
        {
            if (direction == Directions.RIGHT)
            {
                MoveRight();
                if (this.left > screenRight)
                {
                    left = screenLeft - 100;
                    Kill();
                    ReDraw();
                    ReCalculate();
                    Spawn();
                }
            }
            if (direction == Directions.LEFT)
            {
                MoveLeft();
                if (this.right < screenLeft)
                {
                    left = screenRight;
                    Kill();
                    ReDraw();
                    ReCalculate();
                    Spawn();
                }
            }
        }
    }
}
