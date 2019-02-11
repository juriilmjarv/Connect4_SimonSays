using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;

namespace SimonSaysVersion3
{
    public partial class Game : Form
    {

        Button[,] btn = new Button[2, 2];
        Button exitBtn = new Button();
        Label score = new Label();
        Button startBtn = new Button();

        Random r = new Random();
        List<int> pattern = new List<int>();
        bool playingPattern = false;
        int inList = 0;

        public Game()
        {
            InitializeComponent();

            this.BackColor = Color.Black;

            for (int i = 0; i < btn.GetLength(0); i++)
            {
                for (int j = 0; j < btn.GetLength(1); j++)
                {
                    btn[i, j] = new Button();
                    btn[i, j].SetBounds(100 + 250 * i, 100 + 250 * j, 100, 100);
                    btn[i, j].Click += new EventHandler(this.btnEvent_Click);
                    Controls.Add(btn[i, j]);
                }
            }
            btn[0, 0].BackColor = Color.DarkBlue;
            btn[0, 1].BackColor = Color.DarkRed;
            btn[1, 0].BackColor = Color.DarkGreen;
            btn[1, 1].BackColor = Color.Yellow;

            btn[0, 0].ForeColor = Color.White;
            btn[0, 0].Text = "Blue";

            btn[0, 1].Text = "Red";
            btn[1, 0].Text = "Green";
            btn[1, 1].Text = "Yellow";

            this.MinimumSize = new Size(600, 600);
            this.MaximumSize = new Size(600, 600);
            this.StartPosition = FormStartPosition.CenterScreen;


            exitBtn.SetBounds(450, 500, 120, 40);
            exitBtn.BackColor = Color.White;
            exitBtn.Click += new EventHandler(this.exitBtn_Click);
            exitBtn.Text = "Exit";
            Controls.Add(exitBtn);

            startBtn.SetBounds(15, 500, 120, 40);
            startBtn.BackColor = Color.White;
            startBtn.Click += new EventHandler(this.startBtn_Click);
            startBtn.Text = "Start";
            Controls.Add(startBtn);

            label1.SetBounds(240, 50, 120, 40);
            label1.ForeColor = Color.White;
        }


        void btnEvent_Click(object sender, EventArgs e)
        {
            if (((Button)sender).BackColor == Color.DarkBlue)
            {
                gameLoop(0);
            }
            else if (((Button)sender).BackColor == Color.DarkRed)
            {
                gameLoop(1);
            }
            else if (((Button)sender).BackColor == Color.DarkGreen)
            {
                gameLoop(2);
            }
            else if (((Button)sender).BackColor == Color.Yellow)
            {
                gameLoop(3);
            }
        }

        void gameLoop(int color)
        {

            if (playingPattern == true)
            {
                return;
            }
            if (pattern[inList] == color)
            {

                inList++;

            }
            else
            {
                MessageBox.Show("Your Final Score is : " + pattern.Count.ToString());
                inList = 0;
                pattern = new List<int>();
                new Thread(startGame).Start();
                
            }
            if (inList >= pattern.Count)
            {
                pattern.Add(r.Next(0, 4));
                inList = 0;
                new Thread(startGame).Start();
            }

            label1.Text = ("Score: " + pattern.Count.ToString());

        }

        void startGame()
        {
            playingPattern = true;
            foreach (int color in pattern)
            {
                if (color == 0)
                {
                    btn[0, 0].BackColor = Color.LightSkyBlue;
                    Thread.Sleep(400);
                    btn[0, 0].BackColor = Color.DarkBlue;
                }
                else if (color == 1)
                {
                    btn[0, 1].BackColor = Color.PaleVioletRed;
                    Thread.Sleep(400);
                    btn[0, 1].BackColor = Color.DarkRed;
                }
                else if (color == 2)
                {
                    btn[1, 0].BackColor = Color.LightGreen;
                    Thread.Sleep(400);
                    btn[1, 0].BackColor = Color.DarkGreen;
                }
                else if (color == 3)
                {
                    btn[1, 1].BackColor = Color.LightYellow;
                    Thread.Sleep(400);
                    btn[1, 1].BackColor = Color.Yellow;
                }

                Thread.Sleep(400);
            }
            playingPattern = false;
        }

        private void Game_Load(object sender, EventArgs e)
        {
            //pattern.Add(r.Next(0, 4));
            //new Thread(startGame).Start();
            
        }

        void exitBtn_Click(object sender, EventArgs e)
        {
            
            this.Close();
            new SimonSays().Show();
        }

        void startBtn_Click(object sender, EventArgs e)
        {
            pattern.Add(r.Next(0, 4));
            new Thread(startGame).Start();
            //this.Hide();
            //new SimonSays().Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
