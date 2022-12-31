using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArenaBattle.Visibility
{
    public abstract class Visible
    {
        //Every hero will need position, size and image
        //and will be asign it like PictureBox
        public int x;
        public int y;
        public int width;
        public int height;
        public PictureBox hero = new PictureBox();
        public PictureBox bullet = new PictureBox();
        

    }
}
