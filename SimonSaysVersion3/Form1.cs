using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//Juri Ilmjarv: 160013345					
//Andrew Aitken: 150011745

namespace SimonSaysVersion3
{
    public partial class SimonSays : Form
    {
        // Initializes and fixes the size of the form and prevents it from being re-sized and adds a background image
        public SimonSays()
        {
            InitializeComponent();

            this.BackgroundImage = Properties.Resources.simonsaysimg;

            this.MinimumSize = new Size(600, 600);
            this.MaximumSize = new Size(600, 600);
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void SimonSays_Load(object sender, EventArgs e)
        {

        }

        //Opens up the simon says game and hides the menu form
        private void playBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Game().Show();
            
        }

        //Exits application
        private void exitBtn_Click(object sender, EventArgs e)
        {
            //Close();
            Application.Exit();
        }

        //Opens up connect four player vs computer and hides the menu form
        private void connectFourBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            new connectFour().Show();
        }

        //Opens up connect four player vs player and hides the menu form
        private void connectFourPvP_Click(object sender, EventArgs e)
        {
            this.Hide();
            new connectFourTwoPlayer().Show();
        }
    }
}
