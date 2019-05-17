using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Jogger3
{
    /// <summary>
    /// Represents a Home object.
    /// </summary>
    class Home : GameObject
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="image"></param> The PictureBox associated with the home.
        public Home(PictureBox image) : base(image)
        {
            Spawn();
        }
    }
}
