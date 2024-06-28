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
        Panel panel1 = new Panel();
        public Form1()
        {
            InitializeComponent();
            panel1.Size = new Size(1000, 600);
            this.Controls.Add(panel1);
            populateForm();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            populateForm();
        }
        private void populateForm()
        {
            Random random = new Random();
            for (int x = 0; x < 10; x++)
            {
                int posx = random.Next(100, 400);
                int posy = random.Next(100, 400);
                int r = random.Next(256);
                int g = random.Next(256);
                int b = random.Next(256);
                characters newCharacter = new characters(posx, posy, r, g, b);
                panel1.Controls.Add(newCharacter.sprite);
            }
            movingCharacter moving = new movingCharacter(200, 200,5,0,0,0);
            panel1.Controls.Add(moving.sprite);
        }
    }
}
