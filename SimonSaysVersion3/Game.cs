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
using System.Media;

//Juri Ilmjarv: 160013345					
//Andrew Aitken: 150011745

namespace SimonSaysVersion3
{
    public partial class Game : Form
    {

        Button[,] btn = new Button[2, 2];
        Button exitBtn = new Button();
        Label score = new Label();
        Button startBtn = new Button();
        Button soundBtn = new Button();
        Button soundOnBtn = new Button();

        Random r = new Random();
        List<int> pattern = new List<int>();
        bool playingPattern = false;
        //bool sound = true;
        int inList = 0;
        //int soundSwitch =0;

        
        //Sets up the game sounds to be used in the game
        SoundPlayer Do = new SoundPlayer(Properties.Resources.DO);
        SoundPlayer Re = new SoundPlayer(Properties.Resources.RE);
        SoundPlayer Mi = new SoundPlayer(Properties.Resources.MI);
        SoundPlayer Fa = new SoundPlayer(Properties.Resources.Fa);

        public Game()
        {
            InitializeComponent();

            this.BackColor = Color.Black;

            //Prints out the buttons and spaces them across the form
            for (int i = 0; i < btn.GetLength(0); i++)
            {
                for (int j = 0; j < btn.GetLength(1); j++)
                {
                    btn[i, j] = new Button();
                    btn[i, j].SetBounds(120 + 200 * i, 100 + 200 * j, 150, 150);
                    btn[i, j].Click += new EventHandler(this.btnEvent_Click);
                    Controls.Add(btn[i, j]);
                }
            }
            //Sets the colour of the buttons
            btn[0, 0].BackColor = Color.DarkBlue;
            btn[0, 1].BackColor = Color.DarkRed;
            btn[1, 0].BackColor = Color.DarkGreen;
            btn[1, 1].BackColor = Color.Yellow;

            btn[0, 0].ForeColor = Color.White;
            btn[0, 0].Text = "Blue";

            btn[0, 1].Text = "Red";
            btn[1, 0].Text = "Green";
            btn[1, 1].Text = "Yellow";

            //Fixes the size of the form to prevent it being changed
            this.MinimumSize = new Size(600, 600);
            this.MaximumSize = new Size(600, 600);
            this.StartPosition = FormStartPosition.CenterScreen;

            //Sets up the start and exit button
            exitBtn.SetBounds(450, 500, 120, 40);
            exitBtn.BackColor = Color.White;
            exitBtn.Font = new Font("Century Schoolbook", 18);
            exitBtn.Click += new EventHandler(this.exitBtn_Click);
            exitBtn.Text = "Exit";
            Controls.Add(exitBtn);

            startBtn.SetBounds(15, 500, 120, 40);
            startBtn.BackColor = Color.White;
            startBtn.Font = new Font("Century Schoolbook", 18);
            startBtn.Click += new EventHandler(this.startBtn_Click);
            startBtn.Text = "Start";
            Controls.Add(startBtn);

            //soundBtn.SetBounds(225, 500, 150, 40);
            //soundBtn.BackColor = Color.White;
            //soundBtn.Font = new Font("Century Schoolbook", 18);
            //soundBtn.Click += new EventHandler(this.soundBtn_Click);
            //soundBtn.Text = "Sound Off";
            //Controls.Add(soundBtn);

            //soundOnBtn.SetBounds(225, 500, 150, 40);
            //soundOnBtn.BackColor = Color.White;
            //soundOnBtn.Font = new Font("Century Schoolbook", 18);
            //soundOnBtn.Click += new EventHandler(this.soundOnBtn_Click);
            //soundOnBtn.Text = "Sound On";
            //Controls.Add(soundOnBtn);

            label1.Font = new Font("Century Schoolbook", 18);

            //Mkaes the game buttons invisible until the start button has been pressed
            foreach (var x in btn)
            {
                x.Visible = false;
            }
        }

        
        //When the buttons are used/clicked plays sounds
        void btnEvent_Click(object sender, EventArgs e)
        {
            if (((Button)sender).BackColor == Color.DarkBlue)
            {
                
                    Do.Play();
                    gameLoop(0);
                
            }
            else if (((Button)sender).BackColor == Color.DarkRed)
            {
                
                    Re.Play();
                    gameLoop(1);
                
            }
            else if (((Button)sender).BackColor == Color.DarkGreen)
            {
                
                    Mi.Play();
                    gameLoop(2);
                
            }
            else if (((Button)sender).BackColor == Color.Yellow)
            {
                
                    Fa.Play();
                    gameLoop(3);
               
            }
        }

        //Runs the main game loop and contains the lose conditions as well as displaying end score
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

                const string caption = "Game Over";
                var result = MessageBox.Show("Game Over! " + "Score: " + pattern.Count.ToString(), caption, MessageBoxButtons.OK);
                if (result == DialogResult.OK)
                {
                    this.Close();
                    new Game().Show(); 
                }
            }
            if (inList >= pattern.Count)
            {
                label1.Text = ("Score: " + pattern.Count.ToString());
                pattern.Add(r.Next(0, 4));
                inList = 0;
                new Thread(startGame).Start();
            }

        }

        //Plays the game sequence and makes the buttons flash in pattern
        void startGame()
        {
            playingPattern = true;
            foreach (int color in pattern)
            {
                if (color == 0)
                {
                    Do.Play();
                    btn[0, 0].BackColor = Color.LightSkyBlue;
                    Thread.Sleep(400);
                    btn[0, 0].BackColor = Color.DarkBlue;
                }
                else if (color == 1)
                {
                    Re.Play();
                    btn[0, 1].BackColor = Color.PaleVioletRed;
                    Thread.Sleep(400);
                    btn[0, 1].BackColor = Color.DarkRed;
                }
                else if (color == 2)
                {
                    Mi.Play();
                    btn[1, 0].BackColor = Color.LightGreen;
                    Thread.Sleep(400);
                    btn[1, 0].BackColor = Color.DarkGreen;
                }
                else if (color == 3)
                {
                    Fa.Play();
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
            
        }
        //Closes the current form and open the main menu back up
        void exitBtn_Click(object sender, EventArgs e)
        {

            this.Close();
            new SimonSays().Show();
        }

        //Sets the game buttons to visible and starts the game pattern
        void startBtn_Click(object sender, EventArgs e)
        {
            foreach (var x in btn)
            {
                x.Visible = true;
            }
            startBtn.Visible = false;
            pattern.Add(r.Next(0, 4));
            new Thread(startGame).Start();
        }

        //Menu strip which has a help option to teach people the game instructions
        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            const string message = "After you press start, the game grid will appear. SIMON will give the first signal. Repeat the signal by pressing the same lens. SIMON will duplicate the first signal and add one. Repeat thes two signals by pressing the same lenses in order. Continue playing as long as you can repeat each sequence.";
            const string caption = "Help";
            var result = MessageBox.Show(message, caption, MessageBoxButtons.OK);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        //void soundBtn_Click(object sender, EventArgs e)
        //{
        //    soundSwitch = 0;
        //    if (soundSwitch == 0)
        //    {
       //         Do.Stop();
        //        Re.Stop();
        //        Mi.Stop();
        //        Fa.Stop();
        //    }
        //    soundBtn.Visible = false;
        //    soundOnBtn.Visible = true;
            

        //}

        //void soundOnBtn_Click(object sender, EventArgs e)
        //{
        //    if (soundSwitch == 1)
        //    {


         //   }

           // soundBtn.Visible = true;
            //soundOnBtn.Visible = false;

        //}


    }
}
