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
    internal class character
    {
        //seting attributes
        private int startposX, startposy;
        public PictureBox sprite = new PictureBox();
        //constructor
        public character(int x, int y, int red, int green, int blue) 
        { 
            this.startposX = x;
            this.startposy = y;
            sprite.Left = startposX;
            sprite.Top = startposy;
            sprite.BackColor = Color.FromArgb(red, green, blue);
        }
    }

    //Derived class
    internal class movingCharacter : character
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
            speed = s;
            direction = dir;
            Timer myTimer = new Timer();
            myTimer.Tick += new EventHandler(movement);
            myTimer.Interval = 25;
            myTimer.Start();
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
}
