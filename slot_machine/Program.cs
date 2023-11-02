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
            Console.WriteLine("Match three symbols in any direction to win $");
            Console.WriteLine("Get two lines of matching symbols to win $");
            Console.WriteLine("Hit the Jackpot with three lines of matching symbols and win $");
            Console.WriteLine("Ready to try your luck? A spin costs $");

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
                    }
                }

                // If isHorizontalWin is still true, there is a win on this row
                if (isHorizontalWin)
                {
                    horizontalWin = true;
                    // You can also break here if you want to stop checking the other rows
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

                    }
                }
                if (isVerticalWin)
                {
                    verticalWin = true;
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
                if (slots_Output[i, ROW_COUNT - 1 - i] != slots_Output[0, ROW_COUNT - 1])
                {
                    isSecondaryDiagonalWin = false;
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
