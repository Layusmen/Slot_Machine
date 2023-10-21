using System;

namespace Slot_Machine
{
    static class Program
    {
        static void Main(string[] args)
        {
            // Constants
            const int CUSTOM_ROW_COUNT = 3;
            const int CUSTOM_COLUMN_COUNT = 3;

            // First messages
            Console.WriteLine("Welcome to the Amazing Slot Machine!");
            Console.WriteLine("Spin the reels and win big!");

            Console.WriteLine("Match three symbols in any direction to win $");
            Console.WriteLine("Get two lines of matching symbols to win $");
            Console.WriteLine("Hit the Jackpot with three lines of matching symbols and win $");
            Console.WriteLine("Ready to try your luck? A spin costs $");

            // Random Generator
            Random randomPickGenerator = new Random();
            List<string> slotSymbols = new List<string>()
            {
                "A", "1", "5", "7", "$", "M", "8", "9", "!", "#", "Q", "&", "C", "S", "Y", "V", "W", "R", "L", "F"
            };

            string[,] slots_Output = new string[CUSTOM_ROW_COUNT, CUSTOM_COLUMN_COUNT];

            // Display the result
            Console.WriteLine("\nSlot Machine Results: \n");

            for (int row = 0; row < CUSTOM_ROW_COUNT; row++)
            {
                for (int col = 0; col < CUSTOM_COLUMN_COUNT; col++)
                {
                    int randomIndex = randomPickGenerator.Next(slotSymbols.Count);
                    slots_Output[row, col] = slotSymbols[randomIndex];
                    Console.Write(slots_Output[row, col] + "\t");
                }
                Console.WriteLine();
            }

            // Check for a win on horizontal lines
            bool horizontalWin = false;

            for (int row = 0; row < CUSTOM_ROW_COUNT; row++)
            {
                if (slots_Output[row, 0] == slots_Output[row, 1] && slots_Output[row, 1] == slots_Output[row, 2])
                {
                    horizontalWin = true;
                    break; // Exit the loop as we've found a win
                }
            }

            bool verticalWin = false;
            for (int column = 0; column < CUSTOM_COLUMN_COUNT; column++)
            {
                if (slots_Output[column, 0] == slots_Output[column, 1] && slots_Output[column, 1] == slots_Output[column, 2])
                {
                    verticalWin = true;
                    break; // Exit the loop as we've found a win
                }
            }
            // Check for a win on the diagonal lines


            // Check for a win and display the outcome
            if (horizontalWin && verticalWin)
            {
                Console.WriteLine("Congratulations! You won on both horizontal and vertical lines!");
            }
            else if (horizontalWin)
            {
                Console.WriteLine("Congratulations! You won on horizontal line!");
            }
            else if (verticalWin)
            {
                Console.WriteLine("Congratulations! You won on vertical line");
            }

            else
            {
                Console.WriteLine("Sorry, you didn't win on any line. Better luck next time!");
            }
        }
    }
}
