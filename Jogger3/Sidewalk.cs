using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Jogger3
{
    /// <summary>
    /// Represents the sidewalk object.
    /// </summary>
    class Sidewalk : GameObject
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="image"></param> The PictureBox associated with the sidewalk.
        public Sidewalk(PictureBox image) : base(image)
        {
            Spawn();
        }
    }
}
