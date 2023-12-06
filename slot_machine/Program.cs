using System;

namespace Slot_Machine
{
    static class Program
    {
        static void Main(string[] args)
        {
            bool playAgain = true;

            while (playAgain)
            {
                //Constants
                const int ROW_COUNT = 3;
                const int COLUMN_COUNT = 3;
                const char HORIZONAL_LINE = 'A';
                const char VERTICAL_LINE = 'H';
                const char HOR_CENTER_LINE = 'V';
                const char VER_CENTER_LINE = 'C';
                const char DIAGONAL_LINE = 'D';
                //First messages
                Console.WriteLine("Welcome to the Amazing Slot Machine!");
                Console.WriteLine("Spin the reels and win big!");

                //Display betting options
                Console.WriteLine("To Spin, Press......");
                Console.WriteLine("- (A) Play all three horizontal lines with $2: Earn $20 for top line wins, $5 for middle or base line wins.");
                Console.WriteLine("- (H) Play all vertical lines with $2: Earn $20 for first line wins, $5 for second or third line wins.");
                Console.WriteLine("- (V) Play horizontal center line alone with $2: Earn $30.");
                Console.WriteLine("- (C) Play vertical center line with $2: Earn $30.");
                Console.WriteLine("- (D) Play diagonals with $2: Earn $20 for any winning combination.");

                Console.Write("\nPlease choose a betting option (A, H, V, C, D): ");
                char bettingOption = char.ToUpper(Console.ReadKey().KeyChar);
                Console.WriteLine();

                //Check if the betting option is valid
                if (bettingOption != HORIZONAL_LINE && bettingOption != VERTICAL_LINE && bettingOption != HOR_CENTER_LINE && bettingOption != VER_CENTER_LINE && bettingOption != DIAGONAL_LINE)
                {
                    Console.WriteLine("Invalid betting option. Please try again.");
                    return;
                }

                //Random Generator
                Random randomPickGenerator = new Random();
                List<char> slotSymbols = new List<char> { 'A', '1', '5', '7', '$', 'M', '8', '9', '!', '#', 'Q', '&', 'C', 'S', 'Y', 'V', 'W', 'R', 'L', 'F' };
                char[,] slots_Output = new char[ROW_COUNT, COLUMN_COUNT];

                //Display the result
                Console.WriteLine("\nSlot Machine Results: \n");

                //Ramdom Pick Generator
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

                if (bettingOption == HORIZONAL_LINE)
                {
                    Console.WriteLine("\nYou chose to play all three horizontal lines with $2: Earn $20 for top line wins, $5 for middle or base line wins.");

                    // check for a win on a specific horizontal line
                    bool horizontalWin = false; // set win to false 

                    for (int row = 0; row < slots_Output.GetLength(0); row++)
                    {
                        for (int column = 1; column < slots_Output.GetLength(1); column++)
                        {
                            // Compare the current symbol to the first symbol in the row
                            if (slots_Output[row, 0] != slots_Output[row, column])
                            {
                                // set to false
                                horizontalWin = false; // No win on this line
                                break;
                            }
                            horizontalWin = true; // Set to true 
                        }

                        // If horizontalWin is true, there is a win on this row
                        if (horizontalWin)
                        {
                            Console.WriteLine($"\nCongratulations! You win on the {(row == 0 ? "left" : (row == 1 ? "middle" : "right"))} Horizontal line!");
                            break; // Exit the loop if a win is found
                        }
                    }

                    // If horizontalWin is still false, there is no win on any row
                    if (!horizontalWin)
                    {
                        Console.WriteLine($"\nYou did not win on the Horizontal lines!");
                    }
                }

                //Check for a win on the vertical lines
                else if (bettingOption == VERTICAL_LINE)
                {
                    Console.WriteLine("\nPlay all vertical lines with $2: Earn $20 for first line wins, $5 for second or third line wins.");


                    bool verticalWin = true;
                    /// Function to check for a win on the specific vertical lines
                    for (int column = 0; column < slots_Output.GetLength(1); column++)
                    {
                        for (int row = 1; row < slots_Output.GetLength(0); row++)
                        {
                            // Compare the current symbol to the first symbol in the column
                            if (slots_Output[0, column] != slots_Output[row, column])
                            {
                                // If any symbol is different, set the flag to false and break
                                verticalWin = false; // No win on this line
                                break;
                            }
                        }

                        // If verticalWin is true, there is a win on this column
                        if (verticalWin)
                        {
                            Console.WriteLine($"\nCongratulations! You win on the {(column == 0 ? "top" : (column == 1 ? "middle" : "bottom"))} horizontal line!");
                        }

                    }
                    if (!verticalWin)
                    {
                        Console.WriteLine("\nYou did not win on the vertical line!");
                    }
                }

                //Check for a win on the horizontal center line.
                else if (bettingOption == HOR_CENTER_LINE)
                {
                    Console.WriteLine("\nPlay horizontal center line alone with $2: Earn $30.");


                    bool middleHorizontalWin = true;

                    for (int column = 0; column < slots_Output.GetLength(1); column++)
                    {

                        // check for a win on a specific vertical line
                        for (int row = 1; row < slots_Output.GetLength(0); row++)
                        {
                            // Compare the current symbol to the previous symbol in the specified column
                            if (slots_Output[row, column] != slots_Output[row - 1, column])
                            {
                                middleHorizontalWin = false; // No win on this line
                                break;
                            }
                        }
                        if (middleHorizontalWin)
                        {
                            Console.WriteLine($"\nCongratulations! You win on the horizontal middle line!");
                        }
                    }

                    if (!middleHorizontalWin)
                    {
                        Console.WriteLine("\nYou did not win on the horizontal middle line");
                    }
                }

                ///Check for a win on the Vertical Center line 
                else if (bettingOption == VER_CENTER_LINE)
                {
                    Console.WriteLine("\nYou chose to play vertical center line with $2: Earn $30.");

                    // Check for a win on a specific vertical line
                    bool verticalCenterWin = true;

                    for (int column = 0; column < slots_Output.GetLength(1); column++)
                    {

                        for (int row = 1; row < slots_Output.GetLength(0); row++)
                        {
                            // Compare the current symbol to the previous symbol in the specified column
                            if (slots_Output[row, column] != slots_Output[row - 1, column])
                            {
                                verticalCenterWin = false; // No win on this line
                                break;
                            }
                        }

                        if (verticalCenterWin)
                        {
                            Console.WriteLine($"\nCongratulations! You win on the {(column == 1 ? "center" : "")} vertical line!");
                        }
                    }
                    if (!verticalCenterWin)
                    {
                        Console.WriteLine("\nYou did not win on the Vertical Center line");
                    }

                }

                //Check for a win on diagonal lines
                else if (bettingOption == DIAGONAL_LINE)
                {
                    //set diagonal win at zero
                    //int diagonalWinsCount = 0;

                    //Check the main diagonal (top-left to bottom-right)
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
                        //diagonalWinsCount++;
                        Console.WriteLine("\nWin Detected on Main Diagonal");
                    }

                    //Check the secondary diagonal (top-right to bottom-left)
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
                        //diagonalWinsCount++;
                        Console.WriteLine("\nWin Detected on Secondary Diagonal");
                    }
                    if (!isSecondaryDiagonalWin && !isMainDiagonalWin)
                    {
                        Console.WriteLine("\nNo win Detected on any of the Diagonal lines");
                    }
                }

                else
                {
                    Console.WriteLine("\nInvalid betting option. Please try again.");
                }

                Console.Write("\nDo you want to play again? (press 'y' for yes, any other key for no): ");
                ConsoleKeyInfo key = Console.ReadKey();

                // Check if the pressed key is 'y' for yes
                playAgain = key.KeyChar == 'y' || key.KeyChar == 'Y';

                // Clear the console for the next round
                Console.Clear();
            }
            Console.WriteLine("Thanks for playing!");
        }
    }
}