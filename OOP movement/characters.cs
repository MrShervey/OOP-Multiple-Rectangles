using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOP_movement
{
    //Base class
    class character
    {
        //seting attributes
        private int startposX, startposy;
        public PictureBox sprite = new PictureBox();
        protected Timer myTimer = new Timer();
        //constructor
        public character(int x, int y, int red, int green, int blue) 
        { 
            this.startposX = x;
            this.startposy = y;
            this.sprite.Left = startposX;
            this.sprite.Top = startposy;
            this.sprite.BackColor = Color.FromArgb(red, green, blue);
            this.sprite.Width = 50;
            this.sprite.Height = 50;
            this.myTimer.Interval = 25;
            this.myTimer.Start();
        }
        public virtual void movement()
        { }
    }
    //player derived class
    class player : character
    {
        private int Speed = 0;
        public player(int x, int y, int s, int red, int green, int blue)
            : base(x, y, red, green, blue) //constructing the base class
        {
            this.sprite.Height = 25;
            this.sprite.Width = 50;
            this.Speed = s;
        }

        public new void movement(Keys key)
        {
            if (key == Keys.Left && base.sprite.Left > 5)
            {
                base.sprite.Left -= this.Speed;
            }
            else if (key == Keys.Right && base.sprite.Left < 730)
            {
                base.sprite.Left += this.Speed;
            }
            else if (key == Keys.Up && base.sprite.Top > 5)
            {
                base.sprite.Top -= this.Speed;
            }
            else if (key == Keys.Down && base.sprite.Top < 530)
            {
                base.sprite.Top += this.Speed;
            }
        }
    }
    
    //Derived class moving box
    class movingCharacter : character
    {
        //extra attributes for derived class
        private int speed;
        private int count = 50;
        private bool left = true;
        private bool up = true;
        private string direction;
        //constructor
        public movingCharacter(int x, int y, int s, int red, int green, int blue, string dir)
            :base(x,y,red,green,blue) //constructing the base class
        {
            this.speed = s;
            this.direction = dir;
            base.myTimer.Tick += new EventHandler(this.movement);

        }
        //Moving the picture box sprite
        public new void movement(object sender, EventArgs e)
        {
            if(direction == "h")
            {
                if (left)
                {
                    base.sprite.Left -= speed;
                    count--;
                    if (count <= 0)
                    {
                        left = false;
                    }
                }
                else
                {
                    base.sprite.Left += speed;
                    count++;
                    if (count >= 100)
                    {
                        left = true;
                    }
                }
            }
            else if (direction == "v")
            {
                if (up)
                {
                    base.sprite.Top -= speed;
                    count--;
                    if (count <= 0)
                    {
                        up = false;
                    }
                }
                else
                {
                    base.sprite.Top += speed;
                    count++;
                    if (count >= 100)
                    {
                        up = true;
                    }
                }
            }
        }
    }
}
