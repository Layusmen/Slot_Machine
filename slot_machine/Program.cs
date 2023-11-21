using System;
using System.Collections.Generic;

namespace Slot_Machine
{
    static class Program
    {
        static void Main(string[] args)
        {
            // Constants
            const int ROW_COUNT = 3;
            const int COLUMN_COUNT = 3;
            const int COST_ONE_LINE = 1;
            const int COST_TWO_LINES = 2;
            const int COST_THREE_LINES = 3;
            const int COST_THREE_LINES_ONE_VERTICAL = 4;
            const int COST_DIAGONAL = 1;

            const int WIN_AMOUNT_THREE_LINES = 20;
            const int WIN_AMOUNT_TWO_LINES = 8;
            const int WIN_AMOUNT_ONE_LINE = 4;
            const int WIN_AMOUNT_THREE_LINES_ONE_VERTICAL = 100;
            const int WIN_AMOUNT_DIAGONAL = 10;

            decimal moneyLeft = 0; // Declare the variable

            // First messages
            Console.WriteLine("Welcome to the Amazing Slot Machine!");
            Console.WriteLine("Spin the reels and win big!");

            // Random Generator
            Random randomPickGenerator = new Random();
            List<char> slotSymbols = new List<char>
            {
                'A', '1', '5', '7', '$', 'M', '8', '9', '!', '#', 'Q', '&', 'C', 'S', 'Y', 'V', 'W', 'R', 'L', 'F'
            };

            char[,] slots_Output = new char[ROW_COUNT, COLUMN_COUNT];

            // Display the result
            Console.WriteLine("\nSlot Machine Results: \n");

            for (int row = 0; row < ROW_COUNT; row++)
            {
                for (int col = 0; col < COLUMN_COUNT; col++)
                {
                    int randomIndex = randomPickGenerator.Next(slotSymbols.Count);
                    slots_Output[row, col] = slotSymbols[randomIndex];
                    Console.Write(slots_Output[row, col] + "\t");
                }
                Console.WriteLine();
            }

            // Check for a win on horizontal lines
            bool horizontalWin = false;
            for (int row = 0; row < slots_Output.GetLength(0); row++)
            {
                // Initialize a flag for the current row
                bool isHorizontalWin = true;

                for (int column = 1; column < slots_Output.GetLength(1); column++)
                {
                    // Compare the current symbol to the first symbol in the row
                    if (slots_Output[row, column] != slots_Output[row, 0])
                    {
                        // If any symbol is different, set the flag to false and break
                        isHorizontalWin = false;
                        break; // Added break statement
                    }
                }

                // If isHorizontalWin is still true, there is a win on this row
                if (isHorizontalWin)
                {
                    horizontalWin = true;
                    // You can also break here if you want to stop checking the other rows
                    break; // Added break statement
                }
            }

            // Check for a win on vertical lines
            bool verticalWin = false;
            for (int column = 0; column < COLUMN_COUNT; column++)
            {
                bool isVerticalWin = true;
                for (int row = 1; row < ROW_COUNT; row++)
                {
                    if (slots_Output[row, column] != slots_Output[0, column])
                    {
                        isVerticalWin = false;
                        break; // Added break statement
                    }
                }
                if (isVerticalWin)
                {
                    verticalWin = true;
                    break; // Added break statement
                }
            }

            // Check for a win on diagonal lines
            bool diagonalWin = false;

            // Check the main diagonal (top-left to bottom-right)
            bool isMainDiagonalWin = true;
            for (int i = 1; i < ROW_COUNT; i++)
            {
                if (slots_Output[i, i] != slots_Output[0, 0])
                {
                    isMainDiagonalWin = false;
                    break;
                }
            }
            if (isMainDiagonalWin)
            {
                diagonalWin = true;
            }

            // Check the secondary diagonal (top-right to bottom-left)
            bool isSecondaryDiagonalWin = true;
            for (int i = 1; i < ROW_COUNT; i++)
            {
                if (slots_Output[i, COLUMN_COUNT - 1 - i] != slots_Output[0, COLUMN_COUNT - 1])
                {
                    isSecondaryDiagonalWin = false;
                    break; // Added break statement
                }
            }
            if (isSecondaryDiagonalWin)
            {
                diagonalWin = true;
            }

            // Check for a win and display the outcome
            int totalWins = (horizontalWin ? 1 : 0) + (verticalWin ? 1 : 0) + (diagonalWin ? 1 : 0);

            switch (totalWins)
            {
                case 3:
                    Console.WriteLine($"Congratulations! You won on three lines! You get ${COST_THREE_LINES * 3} and win ${WIN_AMOUNT_THREE_LINES}!");
                    moneyLeft += WIN_AMOUNT_THREE_LINES - COST_THREE_LINES * 3;
                    break;
                case 2:
                    Console.WriteLine($"Congratulations! You won on two lines! You get ${COST_TWO_LINES} and win ${WIN_AMOUNT_TWO_LINES}!");
                    break;
                case 1:
                    Console.WriteLine($"Congratulations! You won on one line! You get ${COST_ONE_LINE} and win ${WIN_AMOUNT_ONE_LINE}!");
                    break;
                case 4:
                    Console.WriteLine($"Congratulations! You won on three horizontal lines and one vertical line! You get ${COST_THREE_LINES_ONE_VERTICAL} and win ${WIN_AMOUNT_THREE_LINES_ONE_VERTICAL}!");
                    break;
                case 5:
                    Console.WriteLine($"Congratulations! You won on the diagonal! You get ${COST_DIAGONAL} and win ${WIN_AMOUNT_DIAGONAL}!");
                    break;
                default:
                    Console.WriteLine("Sorry, you didn't win on any line. Better luck next time!");
                    break;
            }

            Console.WriteLine($"Your remaining balance: ${moneyLeft}");

            Console.WriteLine("\nDo you want to play again? (y/n) \n");

            string userInput = Console.ReadLine();

            if (userInput != null && userInput.Trim().ToLower() == "y")
            {
                Console.WriteLine("How much money are you willing to play with? Enter the amount:");
                if (decimal.TryParse(Console.ReadLine(), out decimal moneyLeftInput))
                {
                    if (moneyLeftInput > 0)
                    {
                        moneyLeft = moneyLeftInput;
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Exiting the game.");
                        return;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Exiting the game.");
                    return;
                }
            }
            else
            {
                Console.WriteLine("Thanks for playing! Goodbye.");
                Environment.Exit(0);
            }
        }
    }
}