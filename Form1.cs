using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimonSaysVersion3
{
    public partial class SimonSays : Form
    {
        public SimonSays()
        {
            InitializeComponent();

            this.MinimumSize = new Size(600, 600);
            this.MaximumSize = new Size(600, 600);
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void SimonSays_Load(object sender, EventArgs e)
        {

        }

        private void playBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Game().Show();
            
        }

        private void exitBtn_Click(object sender, EventArgs e)
        {
            //Close();
            Application.Exit();
        }


        private void btnConnectFour_Click(object sender, EventArgs e)
        {
            this.Hide();
            new connectFour().Show();
        }
    }
}
