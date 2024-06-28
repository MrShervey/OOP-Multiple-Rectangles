using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOP_movement
{
    internal class characters
    {
        private int startposX, startposy;
        public PictureBox sprite = new PictureBox();
        private Random random = new Random();
        public characters(int x, int y, int red, int green, int blue) 
        { 
            this.startposX = x;
            this.startposy = y;
            sprite.Left = startposX;
            sprite.Top = startposy;
            sprite.BackColor = Color.FromArgb(red, green, blue);
        }
    }
    internal class movingCharacter : characters
    {
        private int speed;
        private int count = 50;
        private bool left = true;
        public movingCharacter(int x, int y, int s, int red, int green, int blue)
            :base(x,y,red,green,blue)
        {
            speed = s;
            Timer myTimer = new Timer();
            myTimer.Tick += new EventHandler(movement);
            myTimer.Interval = 25;
            myTimer.Start();

        }
        public void movement(object sender, EventArgs e)
        {
            if(left)
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
                if(count >= 100)
                {
                    left = true;
                }
            }
        }
    }

}
