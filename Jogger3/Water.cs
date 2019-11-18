using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Jogger3
{
    /// <summary>
    /// Represents a water object.
    /// </summary>
    class Water : GameObject
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="image"></param> The PictureBox associated with the water.
        public Water(PictureBox image) : base(image)
        {
            Spawn();
        }
        
    }
}
