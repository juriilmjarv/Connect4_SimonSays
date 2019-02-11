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
    public partial class connectFour : Form
    {
        static int ROW = 6;
        static int COLUMN = 7;
        Button[,] grid = new Button[ROW, COLUMN];
        int column;
        static bool checkWinner = true;
        Button startBtn = new Button();
        //Button exitBtn = new Button();

        public connectFour()
        {
            InitializeComponent();
            int i = 0;
            int j = 0;

            for (i = 0; i < COLUMN; i++)
            {
                for (j = 0; j < ROW; j++)
                {
                    grid[j, i] = new Button();
                    grid[j, i].SetBounds(100 + 55 * i, 100 + 55 * j, 50, 50);
                    grid[j, i].BackColor = Color.Blue;
                    grid[j, i].Text = Convert.ToString(i);
                    grid[j, i].ForeColor = Color.Blue;
                    grid[j, i].Click += new EventHandler(this.gridEvent_Click);
                    Controls.Add(grid[j, i]);

                }
            }


            this.MinimumSize = new Size(600, 600);
            this.MaximumSize = new Size(600, 600);
            this.StartPosition = FormStartPosition.CenterScreen;

            //exitBtn.SetBounds(450, 500, 120, 40);
            //exitBtn.BackColor = Color.White;
            //exitBtn.Click += new EventHandler(this.exitBtn_Click);
            //exitBtn.Text = "Exit";
            //Controls.Add(exitBtn);

            startBtn.SetBounds(15, 500, 120, 40);
            startBtn.BackColor = Color.White;
            startBtn.Click += new EventHandler(this.startBtn_Click);
            startBtn.Text = "Start";
            Controls.Add(startBtn);
        }

        void gridEvent_Click(object sender, EventArgs e)
        {
            if (((Button)sender).Text == "0")
                column = Int32.Parse("0");
            else if (((Button)sender).Text == "1")
                column = Int32.Parse("1");
            else if (((Button)sender).Text == "2")
                column = Int32.Parse("2");
            else if (((Button)sender).Text == "3")
                column = Int32.Parse("3");
            else if (((Button)sender).Text == "4")
                column = Int32.Parse("4");
            else if (((Button)sender).Text == "5")
                column = Int32.Parse("5");
            else if (((Button)sender).Text == "6")
                column = Int32.Parse("6");


            dropRed();
            dropRandom();
            horizonalWin();
            verticalWin();
            diagonalWinBack();
            diagonalWinFor();
            checkIfFull();

        }

        bool dropRed()
        {

            int count = 1;
            bool checkExit = true;


            while (checkExit)
            {
                if (grid[ROW - 1, column].BackColor == Color.Blue)
                {
                    grid[ROW - 1, column].ForeColor = Color.Red;
                    grid[ROW - 1, column].BackColor = Color.Red;
                    break;
                }
                else if (grid[ROW - 1, column].BackColor == Color.Red || grid[ROW - 1, column].BackColor == Color.Yellow)
                {
                    if (grid[ROW - 1 - count, column].BackColor == Color.Blue)
                    {
                        grid[ROW - 1 - count, column].ForeColor = Color.Red;
                        grid[ROW - 1 - count, column].BackColor = Color.Red;
                        break;
                    }
                }
                count++;

                if (count == ROW)
                {
                    break;
                }
            }
            return checkExit;
        }

        void dropRandom()
        {
            Random random = new Random();
            int r = random.Next(0, 7);
            int count = 1;

            while (true)
            {
                if (grid[ROW - 1, r].BackColor == Color.Blue)
                {
                    grid[ROW - 1, r].ForeColor = Color.Yellow;
                    grid[ROW - 1, r].BackColor = Color.Yellow;
                    break;
                }
                else if (grid[ROW - 1, r].BackColor == Color.Yellow || grid[ROW - 1, r].BackColor == Color.Red)
                {
                    if (grid[ROW - 1 - count, r].BackColor == Color.Blue)
                    {
                        grid[ROW - 1 - count, r].ForeColor = Color.Yellow;
                        grid[ROW - 1 - count, r].BackColor = Color.Yellow;
                        break;
                    }
                }
                count++;

                if (count == ROW)
                {
                    break;
                }
            }


        }

        bool horizonalWin()
        {
            while (checkWinner)
            {
                for (int row = 0; row < ROW; row++)
                {
                    for (int col = 0; col < COLUMN - 4; col++)
                    {
                        if (grid[row, col].BackColor == Color.Red &&
                           grid[row, col + 1].BackColor == Color.Red &&
                           grid[row, col + 2].BackColor == Color.Red &&
                           grid[row, col + 3].BackColor == Color.Red)
                        {
                            //FIX THIS!!!!!!!!!!!!!
                            grid[row, col].ForeColor = Color.Black;
                            grid[row, col].Text = "X";
                            grid[row, col + 1].Text = "X";
                            grid[row, col + 2].Text = "X";
                            grid[row, col + 3].Text = "X";
                            //FIX THIS!!!!!!!!

                            gameOverPlayer();
                            checkWinner = false;
                        }
                        else if (grid[row, col].BackColor == Color.Yellow &&
                           grid[row, col + 1].BackColor == Color.Yellow &&
                           grid[row, col + 2].BackColor == Color.Yellow &&
                           grid[row, col + 3].BackColor == Color.Yellow)
                        {
                            gameOverComputer();
                            checkWinner = false;
                        }
                    }
                }
                break;
            }
            return checkWinner;
        }

        bool verticalWin()
        {
            while (checkWinner)
            {


                for (int row = 0; row < ROW - 3; row++)
                {
                    for (int col = 0; col < COLUMN; col++)
                    {
                        if (grid[row, col].BackColor == Color.Red &&
                              grid[row + 1, col].BackColor == Color.Red &&
                              grid[row + 2, col].BackColor == Color.Red &&
                              grid[row + 3, col].BackColor == Color.Red)
                        {
                            gameOverPlayer(); // MessageBox
                            checkWinner = false;
                        }
                        else if (grid[row, col].BackColor == Color.Yellow &&
                               grid[row + 1, col].BackColor == Color.Yellow &&
                               grid[row + 2, col].BackColor == Color.Yellow &&
                               grid[row + 3, col].BackColor == Color.Yellow)
                        {
                            gameOverComputer();
                            checkWinner = false;
                        }
                    }
                }
                break;
            }
            return checkWinner;
        }


        bool diagonalWinBack()
        {
            while (checkWinner)
            {
                for (int row = 0; row < ROW - 3; row++)
                {
                    for (int col = 0; col < COLUMN - 3; col++)
                    {
                        if (grid[row, col].BackColor == Color.Red &&
                              grid[row + 1, col + 1].BackColor == Color.Red &&
                              grid[row + 2, col + 2].BackColor == Color.Red &&
                              grid[row + 3, col + 3].BackColor == Color.Red)
                        {
                            gameOverPlayer();
                            checkWinner = false;
                        }
                        else if (grid[row, col].BackColor == Color.Yellow &&
                               grid[row + 1, col + 1].BackColor == Color.Yellow &&
                               grid[row + 2, col + 2].BackColor == Color.Yellow &&
                               grid[row + 3, col + 3].BackColor == Color.Yellow)
                        {
                            gameOverComputer();
                            checkWinner = false;
                        }
                    }
                }
                break;
            }
            return checkWinner;
        }

        bool diagonalWinFor()
        {
            while (checkWinner)
            {
                for (int row = 0; row < ROW - 3; row++)
                {
                    for (int col = 6; col > 2; col--)
                    {
                        if (grid[row, col].BackColor == Color.Red &&
                             grid[row + 1, col - 1].BackColor == Color.Red &&
                             grid[row + 2, col - 2].BackColor == Color.Red &&
                             grid[row + 3, col - 3].BackColor == Color.Red)
                        {
                            gameOverPlayer();
                            checkWinner = false;
                        }
                        else if (grid[row, col].BackColor == Color.Yellow &&
                               grid[row + 1, col - 1].BackColor == Color.Yellow &&
                               grid[row + 2, col - 2].BackColor == Color.Yellow &&
                               grid[row + 3, col - 3].BackColor == Color.Yellow)
                        {
                            gameOverComputer();
                            checkWinner = false;
                        }
                    }
                }
                break;
            }
            return checkWinner;
        }

        bool checkIfFull()
        {
            while (checkWinner)
            {
                for (int row = 0; row < ROW; row++)
                {
                    for (int col = 0; col < COLUMN; col++)
                    {
                        if (grid[row, col].BackColor != Color.Blue &&
                            grid[row, col].BackColor == Color.Red &&
                            grid[row, col].BackColor == Color.Yellow)
                        {
                            MessageBox.Show("Nobody won, grid is full!");
                            checkWinner = false;
                        }
                    }
                }
                break;
            }
            return checkWinner;
        }


        void gameOverPlayer()
        {
            const string message = "YOU WON!";
            const string caption = "Message";
            var result = MessageBox.Show(message, caption, MessageBoxButtons.RetryCancel);
            if (result == DialogResult.Retry)
            {
                //restart game
                //Application.Restart();
                //Environment.Exit(0);
                Close();
                new connectFour().Show();


            }
            else if (result == DialogResult.Cancel)
            {
                //Exit game. Go to main menu
                Close();
            }
        }

        void gameOverComputer()
        {
            const string message = "COMPUTER WON!";
            const string caption = "Message";
            var result = MessageBox.Show(message, caption, MessageBoxButtons.RetryCancel);
            if (result == DialogResult.Retry)
            {
                //restart game
                Application.Restart();
                Environment.Exit(0);
            }
            else if (result == DialogResult.Cancel)
            {
                //Exit game. Go to main menu
                Close();
            }
        }
        void startBtn_Click(object sender, EventArgs e)
        {
            dropRed();
        }

        //void exitBtn_Click(object sender, EventArgs e)
        //{

          //  this.Close();
           // new SimonSays().Show();
        //}

        private void connectFour_Load(object sender, EventArgs e)
        {

        }
    }
}
