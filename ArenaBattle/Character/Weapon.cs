using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArenaBattle.Interfaces;
using ArenaBattle.Visibility;

namespace ArenaBattle.Character
{
    public class Weapon : Visible, IMove
    {

        public bool goRight;
        public bool goLeft;
        public int damage;
        public int horizontalSpeed { get; set; }
        public bool hitTarget;

        public Weapon(int damage, int horizontalSpeed, int x, int y)
        {
            hitTarget = false;
            this.damage = damage;
            this.horizontalSpeed = horizontalSpeed;
            hero.Width = 30;
            hero.Height = 30;
            hero.Location = new Point(x, y);
            hero.BackgroundImageLayout = ImageLayout.Stretch;
            hero.BackColor = Color.Transparent;
            
        }

        public void Move()
        {
            //bullet moving
            if (goRight)
            {
                hero.Left += horizontalSpeed;
            }
            if (goLeft)
            {
                hero.Left -= horizontalSpeed;
            }

        }
    }
}
