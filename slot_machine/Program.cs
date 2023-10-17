using System;
using System.Collections.Generic;

namespace Slot_Machine
{
    static class Program
    {
        static void Main(string[] args)
        {
            const int CUSTOM_ROW_COUNT = 3; 
            const int CUSTOM_COLUMN_COUNT = 3; 

            Console.WriteLine("Welcome to the Amazing Slot Machine!");
            Console.WriteLine("Spin the reels and win big!");

            Console.WriteLine($"Match three symbols in any direction to win $");
            Console.WriteLine($"Get two lines of matching symbols to win $");
            Console.WriteLine($"Hit the Jackpot with three lines of matching symbols and win $");

            Console.WriteLine($"Ready to try your luck? A spin costs $");

            Random randomPickGenerator = new Random();

            List<string> slotSymbols = new List<string>()
            {
                "A", "1", "5", "7", "$", "M", "8", "9", "!", "#", "Q", "&", "C", "S", "Y", "V", "W", "R", "L", "F"
            };

            List<string> characterHolder = new List<string>();
            string[,] slots = new string[CUSTOM_ROW_COUNT, CUSTOM_COLUMN_COUNT];

            for (int row = 0; row < CUSTOM_ROW_COUNT; row++)
            {
                for (int col = 0; col < CUSTOM_COLUMN_COUNT; col++)
                {
                    int randomIndex = randomPickGenerator.Next(slotSymbols.Count);
                    slots[row, col] = slotSymbols[randomIndex];
                    Console.Write(slots[row, col] + " ");
                }
                Console.WriteLine(); 
            }
        }
    }
}