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
        private double speed;
        public PictureBox sprite = new PictureBox();
        private Random random = new Random();
        public characters(int x, int y, double s, int red, int green, int blue) 
        { 
            this.startposX = x;
            this.startposy = y;
            this.speed = s;
            sprite.Left = startposX;
            sprite.Top = startposy;
            sprite.BackColor = Color.FromArgb(red, green, blue);
        }
    }

}
