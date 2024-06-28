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
        Player newPlayer = new Player(100, 100, 5, 150, 150, 100);
        //Constructor for the form
        public Form1()
        {
            InitializeComponent();
            this.Size = new Size(800, 600);
            this.KeyDown += Form1_KeyDown;
           
            populateForm();
        }
        //Instantiate the base and derived classes
        private void populateForm()
        {
            Random random = new Random();
            //Instantiating 5 objects from the base classes with random values
            for (int x = 0; x < 5; x++)
            {
                //Random values for the constructor
                int posx = random.Next(0, 700);
                int posy = random.Next(0, 550);
                int r = random.Next(256);
                int g = random.Next(256);
                int b = random.Next(256);
                //Instantiating an object from the base class
                Character newCharacter = new Character(posx, posy, r, g, b);
                this.Controls.Add(newCharacter.sprite);
            }
            //Instantiating the moving derived class
            MovingCharacter moving1 = new MovingCharacter(350, 100, 2, 0, 0, 0, "h");
            this.Controls.Add(moving1.sprite);
            MovingCharacter moving2 = new MovingCharacter(350, 300, 7, 0, 0, 0, "h");
            this.Controls.Add(moving2.sprite);
            MovingCharacter moving3 = new MovingCharacter(650, 300, 5, 0, 0, 0, "v");
            this.Controls.Add(moving3.sprite);
            //Instantiate the player

            this.Controls.Add(newPlayer.sprite);
        }
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            newPlayer.playerMovement(e.KeyCode);
        }

        private void Form1_Load(object sender, EventArgs e){}
    }
}
