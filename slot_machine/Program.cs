using System;

namespace Slot_Machine
{
    static class Program
    {
        static void Main(string[] args)
        {
            // Constants
            const int ROW_COUNT = 3;
            const int COLUMN_COUNT = 3;

            // First messages
            Console.WriteLine("Welcome to the Amazing Slot Machine!");
            Console.WriteLine("Spin the reels and win big!");

            // Display betting options
            Console.WriteLine("**Betting Options:**");
            Console.WriteLine("- Play all three horizontal lines with $2: Earn $20 for top line wins, $5 for middle or base line wins.");
            Console.WriteLine("- Play horizontal center line with $2: Earn $30.");
            Console.WriteLine("- Play all vertical lines with $2: Earn $20 for first line wins, $5 for second or third line wins.");
            Console.WriteLine("- Play vertical center line with $2: Earn $30.");
            Console.WriteLine("- Play diagonals with $2: Earn $20 for any winning combination.");

            // Prompt the user to choose a betting option
            Console.Write("\nPlease choose a betting option: ");
            string bettingOption = Console.ReadLine().ToLower();


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

            // Check for a win on vertical lines
            int verticalWinsCount = 0;

            for (int column = 0; column < slots_Output.GetLength(1); column++)
            {
                bool isVerticalWin = true;

                for (int row = 1; row < slots_Output.GetLength(0); row++)
                {
                    if (slots_Output[row, column] != slots_Output[row - 1, column])
                    {
                        isVerticalWin = false;
                        break;
                    }
                }

                if (isVerticalWin)
                {
                    verticalWinsCount++;
                }
            }

            // Output the result
            if (verticalWinsCount > 0)
            {
                Console.WriteLine($"Congratulations! You won on {verticalWinsCount} vertical lines!");
            }
            else
            {
                Console.WriteLine("Sorry, you didn't win on any vertical line. Better luck next time!");
            }


            // Check for a win on horizontal lines
            int horizontalWinsCount = 0;

            for (int row = 0; row < slots_Output.GetLength(0); row++)
            {
                bool isHorizontalWin = true;

                for (int column = 1; column < slots_Output.GetLength(1); column++)
                {
                    // Compare the current symbol to the previous symbol in the row
                    if (slots_Output[row, column] != slots_Output[row, column - 1])
                    {
                        isHorizontalWin = false;
                        break;
                    }
                }

                // If isHorizontalWin is still true, there is a win on this row
                if (isHorizontalWin)
                {
                    horizontalWinsCount++;
                }
            }

            // Output the result
            if (horizontalWinsCount > 0)
            {
                Console.WriteLine($"Congratulations! You won on {horizontalWinsCount} horizontal lines!");
            }
            else
            {
                Console.WriteLine("Sorry, you didn't win on any horizontal line. Better luck next time!");
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
                if (slots_Output[i, ROW_COUNT - 1 - i] != slots_Output[0, ROW_COUNT - 1])
                {
                    isSecondaryDiagonalWin = false;
                    break; 
                }
            }
            if (isSecondaryDiagonalWin)
            {
                diagonalWin = true;
            }

            // Check for a win and display the outcome
            if (horizontalWin || verticalWin || diagonalWin)
            {
                Console.WriteLine("Congratulations! You won!");
            }
            else
            {
                Console.WriteLine("Sorry, you didn't win on any line. Better luck next time!");
            }
        }
    }
}
