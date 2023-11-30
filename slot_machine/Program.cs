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
            Console.WriteLine("- (A) Play all three horizontal lines with $2: Earn $20 for top line wins, $5 for base line wins.");
            Console.WriteLine("- (H) Play horizontal center line with $2: Earn $30.");
            Console.WriteLine("- (V) Play all vertical lines with $2: Earn $20 for first line wins, $5 for third line wins.");
            Console.WriteLine("- (C) Play vertical center line with $2: Earn $30.");
            Console.WriteLine("- (D) Play diagonals with $2: Earn $20 for any winning combination.");

            /* Console.Write("\nPlease choose a betting option (A, H, V, C, D): ");
            string bettingOption = Console.ReadLine().ToUpper();

             if (bettingOption == "A")
               {
                   PlayAllHorizontalLines();
               }
               else if (bettingOption == "H")
               {
                   PlayHorizontalCenterLine();
               }
               else if (bettingOption == "V")
               {
                   PlayAllVerticalLines();
               }
               else if (bettingOption == "C")
               {
                   PlayVerticalCenterLine();
               }
               else if (bettingOption == "D")
               {
                   PlayDiagonals();
               }
               else
               {
                   Console.WriteLine("Invalid betting option. Please choose a valid option from the list.");
               }

               */

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

                // Check for a win on horizontal lines
                int horizontalWinsCount = 0;

                for (int innerRow = 0; innerRow < slots_Output.GetLength(0); innerRow++)
                {
                    bool isHorizontalWin = true;

                    for (int column = 1; column < slots_Output.GetLength(1); column++)
                    {
                        // Compare the current symbol to the previous symbol in the row
                        if (slots_Output[innerRow, column] != slots_Output[innerRow, column - 1])
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

                
                // Check for a win on vertical lines
                int verticalWinsCount = 0;

                for (int column = 0; column < slots_Output.GetLength(1); column++)
                {
                    bool isVerticalWin = true;

                    for (int verticalRow = 1; verticalRow < slots_Output.GetLength(0); verticalRow++)
                    {
                        if (slots_Output[verticalRow, column] != slots_Output[verticalRow - 1, column])
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

            
                // Check for a win on diagonal lines
                int diagonalWinsCount = 0;

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
                    diagonalWinsCount++;
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
                    diagonalWinsCount++;
                }

                // Check for a win and display the outcome
                if (horizontalWinsCount > 0 || verticalWinsCount > 0 || diagonalWinsCount > 0)

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
}
