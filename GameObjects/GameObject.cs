using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Jogger3
{
    /// <summary>
    /// Represents an object in the game.
    /// </summary>
    class GameObject
    {
        public int left, right, top, bottom, width, height;

        public bool isAlive;

        public PictureBox image;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="image"></param> The PictureBox associated with the object.
        public GameObject(PictureBox image)
        {
            this.image = image;
            Spawn();
            GetCoordinates();
        }

        /// <summary>
        /// Gets the object's coordinates.
        /// </summary>
        public void GetCoordinates()   
        {
            left   = image.Left;
            top    = image.Top;
            width  = image.Width;
            height = image.Height;
            ReCalculate();
        }

        /// <summary>
        /// Calculates the object's right and bottom coordinates.
        /// </summary>
        public void ReCalculate()   
        {
            right = left + width;
            bottom = top + height;
        }

        /// <summary>
        /// ReDraws the PictureBox associated with the item.
        /// </summary>
        public void ReDraw()         
        {
            image.Left = left;
            image.Top = top;
        }

        /// <summary>
        /// Checks if the object is in a collision with a target object.
        /// </summary>
        /// <param name="target"></param> The object to check.
        /// <returns></returns> True or false.
        public bool IsCollidingWith(GameObject target)  
        {
            if (IsCollidingVertically(target) && IsCollidingHorizontally(target))
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Checks if the object is colliding horizontally with a target object.
        /// </summary>
        /// <param name="target"></param> The object to check.
        /// <returns></returns> True or false.
        private bool IsCollidingHorizontally(GameObject target)
        {
            if (target.isAlive && this.isAlive)
            {
                if ((left >= target.left && left <= target.right) ||
                    (right >= target.left && right <= target.right))
                {
                    return true;
                }
                else if ((target.left >= left && target.left <= right) ||
                         (target.right >= left && target.right <= right))
                {
                    return true;
                }
                return false;
            }
            return false;
        }

        /// <summary>
        /// Checks if the object is colliding vertically with a target object.
        /// </summary>
        /// <param name="target"></param> The object to check.
        /// <returns></returns> True or false.
        private bool IsCollidingVertically(GameObject target)
        {
            if (target == null) return false;
            if (target.isAlive && this.isAlive)
            {
                if ((top >= target.top && top <= target.bottom) ||
                    (bottom >= target.top && bottom <= target.bottom))
                {
                    return true;
                }
                else if ((target.top >= top && target.top <= bottom) ||
                         (target.bottom >= top && target.bottom <= bottom))
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Spawns the object.
        /// </summary>
        public void Spawn()
        {
            isAlive = true;
        }

        /// <summary>
        /// Kills the object.
        /// </summary>
        public void Kill()
        {
            isAlive = false;
        }

    }
}
