using ArenaBattle.Character;
using Timer = System.Windows.Forms.Timer;

namespace ArenaBattle
{
    public partial class Form1 : Form
    {
        Player1 firstPlayer;
        Player2 secondPlayer;

        Weapon bullet1;
        Weapon bullet2;

        public PictureBox arena = new PictureBox();

        ProgressBar firstHp = new ProgressBar();
        ProgressBar secondHp = new ProgressBar();
        Label timer = new Label();


        public Image firstBullet = Properties.Resources.bullet;
        public Image secondBullet = Properties.Resources.brain;

        public bool isGameOver;


        public Queue<Weapon> bullets1 = new Queue<Weapon>();
        public Queue<Weapon> bullets2 = new Queue<Weapon>();
        public int seconds = 120;






        public Form1()
        {

            InitializeComponent();

            //bool if game is over
            isGameOver = false;

            //Initialize arena
            Image terain = Properties.Resources.desert;//here you can change background {dungeon, desert, fantasy_forest, ruinded_fantasy_city}
            arena.Width = this.Width;
            arena.Height = this.Height;
            arena.BackgroundImage = terain;
            arena.BackgroundImageLayout = ImageLayout.Stretch;
            Controls.Add(arena);
            

            //initialize players
            firstPlayer = new Player1(145, 305, 100);
            secondPlayer = new Player2(950, 305, 100);

            //adding to arena
            arena.Controls.Add(firstPlayer.hero);
            arena.Controls.Add(secondPlayer.hero);


            //put in front of all
            firstPlayer.hero.BringToFront();
            secondPlayer.hero.BringToFront();


            //progressBar firstPlayerHp
            firstHp.Location = new System.Drawing.Point(21, 12);
            firstHp.Size = new System.Drawing.Size(477, 67);
            firstHp.TabIndex = 1;
            firstHp.Value = firstPlayer.hp;
            arena.Controls.Add(firstHp);

            //initialize bullets
            bullet1 = new Weapon(10, 10, 300, 10);
            bullet2 = new Weapon(10, 10, 300, 10);



            //progressBar firstPlayerHp
            secondHp.Location = new System.Drawing.Point(688, 12);
            secondHp.Size = new System.Drawing.Size(477, 67);
            secondHp.RightToLeftLayout = true;
            secondHp.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            secondHp.TabIndex = 1;
            secondHp.Value = secondPlayer.hp;
            arena.Controls.Add(secondHp);


            //LABEL TIME:
            Label time = new Label();
            time.AutoSize = true;
            time.Font = new System.Drawing.Font("Showcard Gothic", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            time.ForeColor = Color.AntiqueWhite;
            time.Location = new System.Drawing.Point(540, 12);
            time.Size = new System.Drawing.Size(131, 50);
            time.TabIndex = 0;
            time.Text = "TIME:";
            time.BackColor = Color.Transparent;
            arena.Controls.Add(time);

            //LABEL TIМER update
            timer.AutoSize = true;
            timer.Font = new System.Drawing.Font("Showcard Gothic", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            timer.ForeColor = Color.AntiqueWhite;
            timer.Location = new System.Drawing.Point(540, 60);
            timer.Size = new System.Drawing.Size(131, 50);
            timer.TabIndex = 0;
            timer.BackColor = Color.Transparent;
            arena.Controls.Add(timer);


            //
            Label name2 = new Label();
            name2.AutoSize = true;
            name2.BackColor = System.Drawing.Color.Transparent;
            name2.Font = new System.Drawing.Font("Showcard Gothic", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            name2.ForeColor = System.Drawing.Color.Yellow;
            name2.Location = new System.Drawing.Point(799, 80);
            name2.Size = new System.Drawing.Size(434, 15);
            name2.TabIndex = 0;
            name2.Text = "bai Ivan the nervous";
            arena.Controls.Add(name2);

            //////
            Label name1 = new Label();
            name1.AutoSize = true;
            name1.BackColor = System.Drawing.Color.Transparent;
            name1.Font = new System.Drawing.Font("Showcard Gothic", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            name1.ForeColor = System.Drawing.Color.Yellow;
            name1.Location = new System.Drawing.Point(24, 80);
            name1.Size = new System.Drawing.Size(348, 35);
            name1.TabIndex = 0;
            name1.Text = "Toshko the computer man";
            arena.Controls.Add(name1);


        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            //first player movement
            if (e.KeyCode == Keys.A)
            {
                firstPlayer.goLeft = true;
            }
            if (e.KeyCode == Keys.D)
            {
                firstPlayer.goRight = true;
            }
            if (e.KeyCode == Keys.W)
            {
                firstPlayer.goUp = true;
            }
            if (e.KeyCode == Keys.S)
            {
                firstPlayer.goDown = true;
            }





            //secont player movement
            if (e.KeyCode == Keys.Left)
            {
                secondPlayer.goLeft = true;
            }
            if (e.KeyCode == Keys.Right)
            {
                secondPlayer.goRight = true;
            }
            if (e.KeyCode == Keys.Up)
            {
                secondPlayer.goUp = true;
            }
            if (e.KeyCode == Keys.Down)
            {
                secondPlayer.goDown = true;
            }

            //we try to figure out that two players dont love each other 
            //if (firstPlayer.hero.Bounds.IntersectsWith(secondPlayer.hero.Bounds))
            //{
            //    firstPlayer.goRight = false;
            //    secondPlayer.goLeft = false;
            //}


            //Left and right bounds
            if (firstPlayer.hero.Left < 0)
            {
                firstPlayer.goLeft = false;
            }
            if (secondPlayer.hero.Right > this.Width - 20)
            {
                secondPlayer.goRight = false;
            }

            //Top bound
            if (firstPlayer.hero.Top < 150)
            {
                firstPlayer.goUp = false;
            }
            if (secondPlayer.hero.Top < 150)
            {
                secondPlayer.goUp = false;
            }

            //Down bound
            if (firstPlayer.hero.Bottom > this.Height - 100)
            {
                firstPlayer.goDown = false;
            }
            if (secondPlayer.hero.Bottom > this.Height - 100)
            {
                secondPlayer.goDown = false;
            }

            if (firstPlayer.hero.Right > Width / 2 - 20)
            {
                firstPlayer.goRight = false;
            }
            if (secondPlayer.hero.Left < Width / 2 + 20)
            {
                secondPlayer.goLeft = false;
            }


            firstPlayer.Move();
            secondPlayer.Move();

        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.A)
            {
                if (firstPlayer.goLeft == true)
                {
                    firstPlayer.goLeft = false;
                }
            }
            if (e.KeyCode == Keys.D)
            {
                if (firstPlayer.goRight == true)
                {
                    firstPlayer.goRight = false;
                }
            }
            if (e.KeyCode == Keys.W)
            {
                if (firstPlayer.goUp == true)
                {
                    firstPlayer.goUp = false;
                }
            }
            if (e.KeyCode == Keys.S)
            {
                if (firstPlayer.goDown == true)
                {
                    firstPlayer.goDown = false;
                }
            }


            //hitting secondPlayer 
            if (e.KeyCode == Keys.C)
            {


                bullet1 = new Weapon(10, 10, firstPlayer.hero.Left, firstPlayer.hero.Top + 70);
                bullet1.hero.BackgroundImage = firstBullet;
                bullets1.Enqueue(bullet1);
                arena.Controls.Add(bullet1.hero);

                if (bullet1.goRight)
                {
                    bullet1.goRight = false;
                }
                else
                {
                    bullet1.goRight = true;
                }


            }





            if (e.KeyCode == Keys.Left)
            {
                if (secondPlayer.goLeft == true)
                {
                    secondPlayer.goLeft = false;
                }
            }
            if (e.KeyCode == Keys.Right)
            {
                if (secondPlayer.goRight == true)
                {
                    secondPlayer.goRight = false;
                }
            }
            if (e.KeyCode == Keys.Up)
            {
                if (secondPlayer.goUp == true)
                {
                    secondPlayer.goUp = false;
                }
            }
            if (e.KeyCode == Keys.Down)
            {
                if (secondPlayer.goDown == true)
                {
                    secondPlayer.goDown = false;
                }
            }

            //hitting firstPlayer
            if (e.KeyCode == Keys.M)
            {
                bullet2 = new Weapon(10, 10, secondPlayer.hero.Right, secondPlayer.hero.Top + 70);
                bullet2.hero.BackgroundImage = secondBullet;
                bullets2.Enqueue(bullet2);
                arena.Controls.Add(bullet2.hero);

                if (bullet2.goLeft)
                {
                    bullet2.goLeft = false;
                }
                else
                {
                    bullet2.goLeft = true;
                }


            }

            bullet1.Move();
            bullet2.Move();
            firstPlayer.Move();
            secondPlayer.Move();
        }



        private void BulletTimer_Tick(object sender, EventArgs e)
        {

            foreach (Weapon bullet in bullets1)
            {
                if (bullet.goRight)
                {
                    bullet.hero.Left += bullet.horizontalSpeed;
                }

                if (bullet.hero.Bounds.IntersectsWith(secondPlayer.hero.Bounds) && bullet.hitTarget == false && secondPlayer.hp > 0)
                {
                    bullet.hitTarget = true;
                    secondPlayer.hp -= bullet.damage;
                    secondHp.Value = secondPlayer.hp;
                    bullet.hero.Visible = false;
                    

                }
            }



            foreach (Weapon bullet in bullets2)
            {
                if (bullet.goLeft)
                {
                    bullet.hero.Left -= bullet.horizontalSpeed;
                }

                if (bullet.hero.Bounds.IntersectsWith(firstPlayer.hero.Bounds) && bullet.hitTarget == false && firstPlayer.hp > 0)
                {
                    bullet.hitTarget = true;
                    firstPlayer.hp -= bullet.damage;
                    firstHp.Value = firstPlayer.hp;
                    bullet.hero.Visible = false;
                }
            }


            if (secondPlayer.hp <= 0 && isGameOver == false)
            {

                isGameOver = true;
                MessageBox.Show("Toshko Win!");
                bulletTimer.Stop();
            }

            if (firstPlayer.hp <= 0 && isGameOver == false)
            {
                isGameOver = true;
                MessageBox.Show("Bai Ivan Win!");
                bulletTimer.Stop();
            }

           
        }


        private void countdown_Tick(object sender, EventArgs e)
        {
            if (isGameOver)
            {
                countdown.Stop();
                MessageBox.Show("Tie!");
                bulletTimer.Stop();
            }
            if (seconds <= 0)
            {
                isGameOver = true;
            }

            bool needsZero = false;
            if (seconds % 60 < 10)
            {
                needsZero = true;
            }
            if (needsZero)
            {
                timer.Text = "0" + seconds / 60 + ":0" + seconds % 60;
            }
            else
            {
                timer.Text = "0" + seconds / 60 + ":" + seconds % 60;
            }

            seconds -= 1;
        }


    }
}