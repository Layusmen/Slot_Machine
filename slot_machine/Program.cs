﻿using System;


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

            // Check for a win on vertical lines
            bool verticalWin = false;
            for (int column = 0; column < CUSTOM_COLUMN_COUNT; column++)
            {
                if (slots_Output[0, column] == slots_Output[1, column] && slots_Output[1, column] == slots_Output[2, column])
                {
                    verticalWin = true;
                    //break; // Exit the loop as we've found a win
                }
            }

            // Check for a win on the diagonal lines
            bool diagonalWin = false;

            if (slots_Output[0, 0] == slots_Output[1, 1] && slots_Output[1, 1] == slots_Output[2, 2])
            {
                diagonalWin = true;
            }
            else if (slots_Output[0, 2] == slots_Output[1, 1] && slots_Output[1, 1] == slots_Output[2, 0])
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
