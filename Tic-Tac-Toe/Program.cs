using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tic_Tac_Toe
{
    internal class Program
    {
        static char[] board = { '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        static int playerTurn = 1; // 1 for Player 1, 2 for Player 2
        static int choice; // User's choice for placement

        static void Main()
        {
            do
            {
                Console.Clear(); // Clear the console on each iteration
                Console.WriteLine("Player 1: X and Player 2: O");
                Console.WriteLine("\n");
                if (playerTurn % 2 == 0)
                {
                    Console.WriteLine("Turn Player 2");
                }
                else
                {
                    Console.WriteLine("Turn Player 1");
                }
                Console.WriteLine("\n");
                Board();

                // Check for valid input
                bool validInput = false;
                while (!validInput)
                {
                    string input = Console.ReadLine();
                    validInput = Int32.TryParse(input, out choice);

                    if (!validInput || choice < 1 || choice > 9 || board[choice - 1] == 'X' || board[choice - 1] == 'O')
                    {
                        Console.WriteLine("Invalid input. Please enter a number between 1 and 9 that has not been chosen.");
                        validInput = false;
                    }
                }

                // Mark the board with X or O based on the player turn
                if (playerTurn % 2 == 0)
                {
                    board[choice - 1] = 'O';
                    playerTurn++;
                }
                else
                {
                    board[choice - 1] = 'X';
                    playerTurn++;
                }

            } while (!CheckWin() && !CheckDraw());

            Console.Clear();
            Board();

            if (CheckWin())
            {
                if (playerTurn % 2 == 0)
                {
                    Console.WriteLine("Player 1 wins!");
                }
                else
                {
                    Console.WriteLine("Player 2 wins!");
                }
            }
            else
            {
                Console.WriteLine("It's a draw!");
            }

            Console.ReadLine();
        }

        private static void Board()
        {
            Console.WriteLine("     |     |      ");
            Console.WriteLine($"  {board[0]}  |  {board[1]}  |  {board[2]} ");
            Console.WriteLine("_____|_____|_____ ");
            Console.WriteLine("     |     |      ");
            Console.WriteLine($"  {board[3]}  |  {board[4]}  |  {board[5]} ");
            Console.WriteLine("_____|_____|_____ ");
            Console.WriteLine("     |     |      ");
            Console.WriteLine($"  {board[6]}  |  {board[7]}  |  {board[8]} ");
            Console.WriteLine("     |     |      ");
        }

        private static bool CheckWin()
        {
            // Check rows, columns, and diagonals for a win
            for (int i = 0; i < 3; i++)
            {
                if (board[i * 3] == board[i * 3 + 1] && board[i * 3 + 1] == board[i * 3 + 2])
                {
                    return true;
                }

                if (board[i] == board[i + 3] && board[i + 3] == board[i + 6])
                {
                    return true;
                }
            }

            if (board[0] == board[4] && board[4] == board[8])
            {
                return true;
            }

            if (board[2] == board[4] && board[4] == board[6])
            {
                return true;
            }

            return false;
        }

        private static bool CheckDraw()
        {
            // Check for a draw (all cells filled)
            foreach (char cell in board)
            {
                if (cell != 'X' && cell != 'O')
                {
                    return false; // There's an empty cell, game is not a draw
                }
            }

            return true; // All cells are filled, it's a draw
        }
    }
}
