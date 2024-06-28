using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOP_movement
{
    public partial class Form1 : Form
    {
        //Constructor for the form
        public Form1()
        {
            InitializeComponent();
            this.Size = new Size(800, 600);
            populateForm();
        }
        //Instantiate the base and derived classes
        private void populateForm()
        {
            Random random = new Random();
            //Instantiating 10 objects from the base classes with random values
            for (int x = 0; x < 10; x++)
            {
                //Random values for the constructor
                int posx = random.Next(0, 700);
                int posy = random.Next(0, 550);
                int r = random.Next(256);
                int g = random.Next(256);
                int b = random.Next(256);
                //Instantiating an object from the base class
                character newCharacter = new character(posx, posy, r, g, b);
                this.Controls.Add(newCharacter.sprite);
            }
            //Instantiating the moving derived class
            movingCharacter moving1 = new movingCharacter(350, 100, 2, 0, 0, 0, "h");
            this.Controls.Add(moving1.sprite);
            movingCharacter moving2 = new movingCharacter(350, 300, 7, 0, 0, 0, "h");
            this.Controls.Add(moving2.sprite);
            movingCharacter moving3 = new movingCharacter(650, 300, 5, 0, 0, 0, "v");
            this.Controls.Add(moving3.sprite);
        }

        private void Form1_Load(object sender, EventArgs e){}
    }
}
