using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Jogger3
{
    /// <summary>
    /// Represesnts a game character.
    /// </summary>
    class GameCharacter: GameObject
    {
        public int amount, direction;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="image"></param> The PictureBox associated with the character.
        /// <param name="amount"></param> The movement amount of the character.
        public GameCharacter(PictureBox image, int amount) : base(image)
        {
            this.amount = amount;
            Spawn();
            GetCoordinates();
        }

        /// <summary>
        /// Moves the character upward by the movement amount.
        /// </summary>
        public void MoveUp()          
        {
            top = top - amount;
            ReDraw();
            ReCalculate();
        }

        /// <summary>
        /// Moves the character downward by the movement amount.
        /// </summary>
        public void MoveDown()       
        {
            top = top + amount;
            ReDraw();
            ReCalculate();
        }

        /// <summary>
        /// Moves the character left by the movement amount.
        /// </summary>
        public void MoveLeft()       
        {
            left = left - amount;
            ReDraw();
            ReCalculate();
        }

        /// <summary>
        /// Moves the character right by the movement amount.
        /// </summary>
        public void MoveRight()     
        {
            left = left + amount;
            ReDraw();
            ReCalculate();
        }

        /// <summary>
        /// Returns the character to a defined start position.
        /// </summary>
        /// <param name="startLeft"></param> The starting left coordinate.
        /// <param name="startTop"></param> The starting top coordinate.
        public void StartPosition(int startLeft, int startTop)
        {
            left = startLeft;
            top  = startTop;
            ReCalculate();
            ReDraw();
            Spawn();
        }

        /// <summary>
        /// Determines which direction to move.
        /// </summary>
        public void Move()
        {
            if      (direction == Directions.UP)    MoveUp();
            else if (direction == Directions.DOWN)  MoveDown();
            else if (direction == Directions.LEFT)  MoveLeft();
            else if (direction == Directions.RIGHT) MoveRight();
        }

        /// <summary>
        /// Sets the direction.
        /// </summary>
        /// <param name="direction"></param> The direction to set to.
        public void SetDirection(int direction)  
        {
            if      (direction == Directions.UP)    this.direction = Directions.UP;
            else if (direction == Directions.DOWN)  this.direction = Directions.DOWN;
            else if (direction == Directions.LEFT)  this.direction = Directions.LEFT;
            else if (direction == Directions.RIGHT) this.direction = Directions.RIGHT;
        }

        /// <summary>
        /// Sticks the character to a target object.
        /// </summary>
        /// <param name="target"></param> The object to stick to.
        public void StickTo(GameObject target)
        {
            if      (direction == Directions.UP)     top  = target.top + target.height + 1;
            else if (direction == Directions.DOWN)   top  = target.top - height - 1;
            else if (direction == Directions.RIGHT)  left = target.left - width - 1;
            else if (direction == Directions.LEFT)   left = target.left + target.width + 1;
            ReCalculate();
        }

        /// <summary>
        /// Keeps the character on a target character.
        /// </summary>
        /// <param name="target"></param> The charcater to stay on.
        public void StayOn(GameCharacter target)
        {
            top = target.top + (target.height / 2) - (height / 2);
            if (target.direction == Directions.LEFT)
            {
                left = left - target.amount;
            }
            else if (target.direction == Directions.RIGHT)
            {
                left = left + target.amount;
            }
            ReCalculate();
            //ReDraw();
        }

        /// <summary>
        /// Keeps a player in a target object.
        /// </summary>
        /// <param name="target"></param> The object to stay in.
        public void StayIn(GameObject target)
        {
            if      (top    <= target.top)      top  = target.top + 1;
            else if (bottom >= target.bottom)   top  = target.bottom - height - 1;
            else if (left   >= target.right )   left = target.right - width - 1;
            else if (left   <= target.left)     left = target.left + 1;
            ReCalculate();
        }

        /// <summary>
        /// Keeps the character on a target object.
        /// </summary>
        /// <param name="target"></param> The object to stay on.
        public void StayOnObject(GameObject target)
        {
            top = target.top + (target.height / 2) - (height / 2);
            ReCalculate();
        }

        /// <summary>
        /// Bounces the character off of a target object.
        /// </summary>
        /// <param name="target"></param> The object to bounce off of.
        public void BounceOff(GameObject target)
        {
            StickTo(target);
            if (direction == Directions.UP) direction = Directions.DOWN;
            else if (direction == Directions.DOWN) direction = Directions.UP;
            else if (direction == Directions.LEFT) direction = Directions.RIGHT;
            else if (direction == Directions.RIGHT) direction = Directions.LEFT;
        }
    }
}
