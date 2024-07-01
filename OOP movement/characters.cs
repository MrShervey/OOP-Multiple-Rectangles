using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrackBar;

namespace OOP_movement
{
    //Base class
    internal class Character
    {
        //seting attributes
        private int startposX, startposy;
        public PictureBox sprite = new PictureBox();
        //constructor
        public Character(int x, int y, int red, int green, int blue)
        {
            this.startposX = x;
            this.startposy = y;
            sprite.Left = startposX;
            sprite.Top = startposy;
            sprite.BackColor = Color.FromArgb(red, green, blue);
        }
    }

    //Derived class
    internal class MovingCharacter : Character
    {
        //extra attributes for derived class
        private int speed;
        private int count = 50;
        private bool left = true;
        private bool up = true;
        private string direction;
        Timer myTimer = new Timer();
        //constructor
        public MovingCharacter(int x, int y, int s, int red, int green, int blue, string dir)
            :base(x,y,red,green,blue) //constructing the base class
        {
            base.sprite.Size = new Size(150, 50);
            speed = s;
            direction = dir;
            myTimer.Interval = 25;
            myTimer.Start();
            myTimer.Tick += new EventHandler(movement);
        }
        //Moving the picture box sprite
        public void movement(object sender, EventArgs e)
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
    internal class Player : Character
    {
        private int speed;
        public Player(int x, int y, int s, int red, int green, int blue)
            :base(x,y,red,green,blue)
        {
            speed = s;
            base.sprite.Size = new Size(50, 50);
        }
        public void movement(Keys key)
        {
            if (key == Keys.Left && base.sprite.Left > 5)
            {
                base.sprite.Left -= speed;
            }
            else if (key == Keys.Right && base.sprite.Left < 680)
            {
                base.sprite.Left += speed;
            }
            else if (key == Keys.Up && base.sprite.Top > 5)
            {
                base.sprite.Top -= speed;
            }
            else if (key == Keys.Down && base.sprite.Top < 500)
            {
                base.sprite.Top += speed;
            }
        }
    }
}
