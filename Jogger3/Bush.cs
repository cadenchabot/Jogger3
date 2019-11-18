using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Jogger3
{
    /// <summary>
    /// Represents a bush object
    /// </summary>
    class Bush : GameObject
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="image"></param> The PictureBox of the bush
        public Bush(PictureBox image) : base(image)
        {
            Spawn();
        }
    }
}
