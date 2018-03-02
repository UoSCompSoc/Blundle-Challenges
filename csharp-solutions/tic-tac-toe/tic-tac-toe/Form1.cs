using System;
using System.Windows.Forms;

//Imported for file access used by Hall of Fame
using System.IO;

namespace tic_tac_toe
{
    public partial class Form1 : Form
    {
        public string[,] gameGrid = new string[3, 3]; //store the grid in a 2D array like a chess board. where [0,0] is the top left corner and [2,2] is the bottom right
        public string currentPlayer;
        public string symbol;
        public string fileLoc = "hall-of-fame.txt";

        public int player1Score = 0;
        public int player2Score = 0;

        /// <summary>
        /// Constructor runs on form start
        /// </summary>
        public Form1()
        {
            InitializeComponent();
            newGame();
        }

        /// <summary>
        /// Create a new game 
        ///     - Clear the text from the buttons
        ///     - Reset the game board
        ///     - Update the win count
        /// </summary>
        private void newGame()
        {
            btn1.Text = "";
            btn2.Text = "";
            btn3.Text = "";
            btn4.Text = "";
            btn5.Text = "";
            btn6.Text = "";
            btn7.Text = "";
            btn8.Text = "";
            btn9.Text = "";

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    gameGrid[i, j] = "";
                }
            }

            lblPlayer1WinCount.Text = player1Score.ToString();
            lblPlayer2WinCount.Text = player2Score.ToString();

            symbol = "X";
            currentPlayer = txtBoxPlayer1.Text;
            lblPlayerSymbol.Text = symbol;
        }

        /// <summary>
        /// Check for a winner
        /// if at least one of the check methods returns true
        ///     - Print a well done message
        ///     - Use the current symbol to check which player has won
        ///     - Update the player scores
        ///     - Start a new game
        /// if no check method returns true, check that the game board isn't full
        /// In case of a full board, print a message declaring a draw and start a new game
        /// </summary>
        private void checkForWinner()
        {
            if(checkHorizontal() || checkVertical() || checkDiagonal())
            {
                MessageBox.Show("Well done " + currentPlayer);
                if(symbol == "X")
                {
                    player1Score++;
                }
                else
                {
                    player2Score++;
                }
                newGame();
            }
            else
            {
                if(checkFullBoard())
                {
                    MessageBox.Show("Draw!");
                    newGame();
                }
            }
        }

        /// <summary>
        /// Check for horizontal wins
        ///     - Loop from top to bottom, checking the board horizontally
        ///     - If the enteries for the; left, middle, and right enteries on the gameGrid are equal there is a 3 in a row
        ///     - return true declaring a win
        ///     - If the loop completes, there is no horizontal win, retrun false
        /// </summary>
        private bool checkHorizontal()
        {
            for (int i = 0; i < 3; i++)
            {
                if (gameGrid[i, 0].Length > 0 && gameGrid[i, 1].Length > 0 && gameGrid[i, 2].Length > 0)
                {
                    if (gameGrid[i, 0] == gameGrid[i, 1] && gameGrid[i, 1] == gameGrid[i, 2])
                    {
                        return true;
                    }
                }

            }
            return false;
        }

        /// <summary>
        /// Check for vertical wins
        ///     - Loop from left to right, checking the board vertically
        ///     - If the enteries for the; top, middle, and bottom enteries on the gameGrid are equal there is a 3 in a row
        ///     - return true declaring a win
        ///     - If the loop completes, there is no vertical win, retrun false
        /// </summary>
        private bool checkVertical()
        {
            for (int i = 0; i < 3; i++)
            {
                if(gameGrid[0, i].Length > 0 && gameGrid[1, i].Length > 0 && gameGrid[2, i].Length > 0)
                {
                    if (gameGrid[0, i] == gameGrid[1, i] && gameGrid[1, i] == gameGrid[2, i])
                    {
                        return true;
                    }
                }
               
            }
            return false;
        }

        /// <summary>
        /// Check for diagonal wins
        ///     - Check from top left to bottom right
        ///     - If the enteries are equal to each other there is a diagonal win -> return true
        ///     - Check from top right to bottom left
        ///     - If the enteries are equal to each other there is a diagonal win -> return true
        ///     - failing this, there are no diagonal wins -> return false
        /// </summary>
        private bool checkDiagonal()
        {
            if(gameGrid[1,1] != "")
            {
                if (gameGrid[1, 1] != "" && gameGrid[0, 0] == gameGrid[1, 1] && gameGrid[1, 1] == gameGrid[2, 2])
                {
                    return true;
                }
                else if (gameGrid[1, 1] != "" && gameGrid[0, 2] == gameGrid[1, 1] && gameGrid[1, 1] == gameGrid[2, 0])
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }

        /// <summary>
        /// Check for a full board
        ///     - Loop through left to right with a nested loop iterating from top to bottom - allowing all the grid slots to be checked
        ///     - If the grid slot being checked is blank, the board isn't full -> return false
        ///     - If the loops complete, each space on the board is taken and it is therefore full -> return true
        /// </summary>
        private bool checkFullBoard()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if(gameGrid[i,j] == "")
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        /// <summary>
        /// makeMove(int x, int y, Button btn)
        /// A method which groups together all the instructions which will be executed whenever a player makes a move
        /// int x: The x location of the button on the game grid
        /// int y: The y location of the button on the game grid
        /// Button btn: A pointer to the button which was pressed
        ///
        ///     - Check the space is free
        ///     - Use the button pointer to set the text of the button to the player's symbol
        ///     - Check for a winner
        ///     - If the current symbol is 'X' update the current player to be player2 and swap the symbol to be 'O'
        ///     - If the current symbol is 'O' update the current player to be player1 and swap the symbol to be 'X'
        ///     - Update the symbol sign, showing that it's the next players move
        /// </summary>
        private void makeMove(int x, int y, Button btn)
        {
            if(gameGrid[x,y] == "")
            {
                gameGrid[x, y] = currentPlayer;
                btn.Text = symbol;

                checkForWinner();

                if (symbol == "X")
                {
                    currentPlayer = txtBoxPlayer2.Text;
                    symbol = "O";
                }
                else
                {
                    currentPlayer = txtBoxPlayer1.Text;
                    symbol = "X";
                }
                lblPlayerSymbol.Text = symbol;
            }
        }

        /**
         * Button press events
         * On pressing a button that makes up the game board, call the makeMove method with the location [x,y] of the button and the button's object
         */
        private void btn1_Click(object sender, EventArgs e)
        {
            makeMove(0, 0, btn1);
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            makeMove(1, 0, btn2);
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            makeMove(2, 0, btn3);
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            makeMove(0, 1, btn4);
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            makeMove(1, 1, btn5);
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            makeMove(2, 1, btn6);
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            makeMove(0, 2, btn7);
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            makeMove(1, 2, btn8);
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            makeMove(2, 2, btn9);
        }

        /// <sumary>
        /// btnHallOfRecords
        /// A method which runs whenever the Hall of Records button is pressed
        /// Uses a file stream to read the hall of fame file
        /// The 'using' statement is C# safely contains any exceptions which may be thrown as well as closing and disposing of an object.
        ///</summary>
        private void btnHallOfRecords_Click(object sender, EventArgs e)
        {
            string hallOfFame = "";
            using (StreamReader sr = new StreamReader(fileLoc))
            {
                hallOfFame = sr.ReadToEnd();
            }
            MessageBox.Show(hallOfFame);
        }

        /// <sumary>
        /// btnEndGame
        /// A method which runs whenever the End Game button is pressed
        ///     - If player 1 has a higher score, append their details to the the file
        ///     - If player 2 has a higher score, append their details to the the file
        ///     - If the scores are equal there was a draw, append this to the file
        ///</summary>
        private void btnEndGame_Click(object sender, EventArgs e)
        {
            if(player1Score > player2Score)
            {
                using (StreamWriter sw = new StreamWriter(fileLoc, append: true))
                {
                    sw.WriteLine(txtBoxPlayer1.Text + ": " + player1Score);
                }
            }
            else if(player2Score > player1Score)
            {
                using (StreamWriter sw = new StreamWriter(fileLoc, append: true))
                {
                    sw.WriteLine(txtBoxPlayer2.Text + ": " + player2Score);
                }
            }
            else
            {
                using (StreamWriter sw = new StreamWriter(fileLoc, append: true))
                {
                    sw.WriteLine("DRAW");
                }
            }
        }
    }
}
