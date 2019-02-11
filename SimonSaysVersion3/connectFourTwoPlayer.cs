using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

//Juri Ilmjarv: 160013345					
//Andrew Aitken: 150011745

namespace SimonSaysVersion3
{
    public partial class connectFourTwoPlayer : Form
    {


        static int ROW = 6;
        static int COLUMN = 7;
        Button[,] grid = new Button[ROW, COLUMN];
        int column;
        static bool checkWinner = true;
        static int turn = 0;
        Button startBtn = new Button();
        Button exitBtn = new Button();
        Label playerTurn = new Label();

        SoundPlayer backGroundMusic = new SoundPlayer(Properties.Resources.BackgroundMusic);

        public connectFourTwoPlayer()
        {
            InitializeComponent();
            backGroundMusic.Play();
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

            //Sets the size and background of the form and centres it in the middle of the screen
            this.MinimumSize = new Size(600, 600);
            this.MaximumSize = new Size(600, 600);
            this.BackgroundImage = Properties.Resources.Connect4background;
            this.StartPosition = FormStartPosition.CenterScreen;

            //Sets up the exit and start buttons
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
            startBtn.Visible = true;

            //Hides the game board until game is started
            foreach (var x in grid)
            {
                x.Visible = false;
            }

            //Set up label to display whos turn it is
            playerTurn.SetBounds(225, 500, 150, 40);
            playerTurn.Font = new Font("Century Schoolbook", 18);
            playerTurn.ForeColor = Color.Red;
            playerTurn.BackColor = Color.Transparent;
            playerTurn.Text= "Red's Turn";
            Controls.Add(playerTurn);

        }

        //The main running loop which calls the player and computers turns and checks for win coniditons by
        //calling the functions
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
            

                if (turn == 0)
                {
                
                    dropRed();
                playerTurn.ForeColor = Color.Yellow;
                playerTurn.Text = "Yellow's Turn";


                }
                else if (turn == 1)
                {
                
                dropYellow();
                playerTurn.ForeColor = Color.Red;
                playerTurn.Text = "Red's Turn";
                }
                
                    horizonalWin();
                    verticalWin();
                    diagonalWinBack();
                    diagonalWinFor();
                    checkIfFull();
                   
                
            

        }

        //Allows 1st the player to drop thier piece on the reds turn
        bool dropRed()
        {
           
                int count = 1;
                bool checkExit = true;
            if (turn == 0)
            {

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
            }
            turn = 1;
                return checkExit;
                
            
            
        }

        //Allows the 2nd player to drop thier piece on the yellows turn
        bool dropYellow()
        {
            
                int count = 1;
                bool checkExit = true;

            if (turn == 1)
            {
                while (checkExit)
                {
                    if (grid[ROW - 1, column].BackColor == Color.Blue)
                    {
                        grid[ROW - 1, column].ForeColor = Color.Yellow;
                        grid[ROW - 1, column].BackColor = Color.Yellow;
                        break;
                    }
                    else if (grid[ROW - 1, column].BackColor == Color.Red || grid[ROW - 1, column].BackColor == Color.Yellow)
                    {
                        if (grid[ROW - 1 - count, column].BackColor == Color.Blue)
                        {
                            grid[ROW - 1 - count, column].ForeColor = Color.Yellow;
                            grid[ROW - 1 - count, column].BackColor = Color.Yellow;
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
            turn = 0;
            return checkExit;
            
            
        }

        //Checks win conditions for horizonal
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

                            grid[row, col].ForeColor = Color.Black;
                            grid[row, col].Text = "X";
                            grid[row, col + 1].ForeColor = Color.Black;
                            grid[row, col + 1].Text = "X";
                            grid[row, col + 2].ForeColor = Color.Black;
                            grid[row, col + 2].Text = "X";
                            grid[row, col + 3].ForeColor = Color.Black;
                            grid[row, col + 3].Text = "X";


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

        //Checks win conditions for vertical win
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
                            grid[row, col].ForeColor = Color.Black;
                            grid[row, col].Text = "X";
                            grid[row + 1, col].ForeColor = Color.Black;
                            grid[row + 1, col].Text = "X";
                            grid[row + 2, col].ForeColor = Color.Black;
                            grid[row + 2, col].Text = "X";
                            grid[row + 3, col].ForeColor = Color.Black;
                            grid[row + 3, col].Text = "X";

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

        //Checks win conditions for back
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
                            grid[row, col].ForeColor = Color.Black;
                            grid[row, col].Text = "X";
                            grid[row + 1, col + 1].ForeColor = Color.Black;
                            grid[row + 1, col + 1].Text = "X";
                            grid[row + 2, col + 2].ForeColor = Color.Black;
                            grid[row + 2, col + 2].Text = "X";
                            grid[row + 3, col + 3].ForeColor = Color.Black;
                            grid[row + 3, col + 3].Text = "X";
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

        //Checks win conditions for diagonal
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
                            grid[row, col].ForeColor = Color.Black;
                            grid[row, col].Text = "X";
                            grid[row + 1, col - 1].ForeColor = Color.Black;
                            grid[row + 1, col - 1].Text = "X";
                            grid[row + 2, col - 2].ForeColor = Color.Black;
                            grid[row + 2, col - 2].Text = "X";
                            grid[row + 3, col - 3].ForeColor = Color.Black;
                            grid[row + 3, col - 3].Text = "X";

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

        //Checks if board is full, draw conditions
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

        //Displays player win message and gives user option to restart or exit
        void gameOverPlayer()
        {
            const string message = "Red WON!";
            const string caption = "Message";
            var result = MessageBox.Show(message, caption, MessageBoxButtons.RetryCancel);
            if (result == DialogResult.Retry)
            {
                //restart game
                //Application.Restart();
                //Environment.Exit(0);
                backGroundMusic.Stop();
                this.Close();
                new connectFourTwoPlayer().Show();


            }
            else if (result == DialogResult.Cancel)
            {
                //Exit game. Go to main menu
                backGroundMusic.Stop();
                this.Close();
                new SimonSays().Show();
            }
        }

        //Displays yellow win message and gives user option to restart or exit, not renamed for ease of use between forms
        void gameOverComputer()
        {
            const string message = "Yellow WON!";
            const string caption = "Message";
            var result = MessageBox.Show(message, caption, MessageBoxButtons.RetryCancel);
            if (result == DialogResult.Retry)
            {
                //restart game
                backGroundMusic.Stop();
                this.Close();
                new connectFourTwoPlayer().Show();
            }
            else if (result == DialogResult.Cancel)
            {
                //Exit game. Go to main menu
                backGroundMusic.Stop();
                this.Close();
                new SimonSays().Show();

            }
        }

        //Exits the current form and opens up the main menu
        void exitBtn_Click(object sender, EventArgs e)
        {
            backGroundMusic.Stop();
            this.Close();
            new SimonSays().Show();
        }

        //Starts the game and makes the game board visible to the user
        void startBtn_Click(object sender, EventArgs e)
        {
            checkWinner = true;
            foreach (var x in grid)
            {
                x.Visible = true;
            }
            startBtn.Visible = false;

        }

        private void connectFourTwoPlayer_Load(object sender, EventArgs e)
        {

        }

        //Menu strip option which displays help 
        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("How to play: \nClick on a column to place your piece. The piece will fall straight down, occupying the next available space within the column. " +
               "The objective of the game is to be the first to form a horizontal, vertical, or diagonal line of four of one's own discs.");
        }
    }
}
