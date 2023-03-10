using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArenaBattle.Visibility;
using ArenaBattle.Interfaces;

namespace ArenaBattle.Character
{
    public class Player2:Visible, IMove
    {

        public int hp;
        public int horizontalSpeed { get; set; }
        public bool goLeft;
        public bool goRight;
        public bool goDown;
        public bool goUp;


        public Player2(int x, int y, int hp)
        {

            //we can modify this move speed later
            this.horizontalSpeed = 10;

            hero.Width = 150;
            hero.Height = 200;
            hero.Location = new Point(x, y);
            this.hp = hp;


            //add image to this hero and make it transparent
            hero.BackColor = Color.Transparent;
            Image secondPlayerImage = Properties.Resources.zombie;
            hero.BackgroundImage = secondPlayerImage;
            hero.BackgroundImageLayout = ImageLayout.Stretch;
            

        }


        public void Move()
        {
            //moving left, right, up and down
            if (goLeft == true)
            {
                this.hero.Left -= horizontalSpeed;
            }
            if (goRight == true)
            {
                this.hero.Left += horizontalSpeed;
            }
            if (goDown == true)
            {
                this.hero.Top += horizontalSpeed;
            }
            if (goUp == true)
            {
                this.hero.Top -= horizontalSpeed;
            }

            
        }
    }
}
