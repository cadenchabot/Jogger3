using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Jogger3
{
    /// <summary>
    /// Represents a Car object
    /// </summary>
    class Car : GameCharacter
    {
        private int screenLeft;
        private int screenRight;
        private int screenTop;
        private int screenBottom;
        private Form level;

        /// <summary>
        /// Constructor for a car
        /// </summary>
        /// <param name="image"></param>
        /// <param name="amount"></param>
        /// <param name="direction"></param>
        /// <param name="level"></param>
        public Car(PictureBox image, int amount, int direction, Form level) : base(image, amount)
        {
            this.level = level;
            this.direction = direction;
            Spawn();
            SetScreen();
        }

        /// <summary>
        /// Sets the screen's sides
        /// </summary>
        private void SetScreen()
        {
            screenLeft = 0;
            screenTop = 0;
            screenRight = screenLeft + level.Width;
            screenBottom = (screenTop + level.Height) - 50;
        }

        /// <summary>
        /// Moves the cars from one end to the other and then returns them
        /// </summary>
        public void MoveCars()
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
