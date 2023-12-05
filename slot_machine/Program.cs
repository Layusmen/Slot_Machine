using System;

namespace Slot_Machine
{
    static class Program
    {
        static void Main(string[] args)
        {
            //Constants
            const int ROW_COUNT = 3;
            const int COLUMN_COUNT = 3;

            //First messages
            Console.WriteLine("Welcome to the Amazing Slot Machine!");
            Console.WriteLine("Spin the reels and win big!");

            //Display betting options
            Console.WriteLine("To Spin, Press......");
            Console.WriteLine("- (A) Play all three horizontal lines with $2: Earn $20 for top line wins, $5 for middle or base line wins.");
            Console.WriteLine("- (H) Play horizontal center line alone with $2: Earn $30.");
            Console.WriteLine("- (V) Play all vertical lines with $2: Earn $20 for first line wins, $5 for second or third line wins.");
            Console.WriteLine("- (C) Play vertical center line with $2: Earn $30.");
            Console.WriteLine("- (D) Play diagonals with $2: Earn $20 for any winning combination.");

            Console.Write("\nPlease choose a betting option (A, H, V, C, D): ");
            string bettingOption = Console.ReadLine().ToUpper();

            //Random Generator
            Random randomPickGenerator = new Random();
            List<char> slotSymbols = new List<char> { 'A', '1', '5', '7', '$', 'M', '8', '9', '!', '#', 'Q', '&', 'C', 'S', 'Y', 'V', 'W', 'R', 'L', 'F' };
            char[,] slots_Output = new char[ROW_COUNT, COLUMN_COUNT];

            //Display the result
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

            // Betting Options Statements
            if (bettingOption == "A")
            {
                Console.WriteLine("\nYou chose to play all three horizontal lines with $2: Earn $20 for top line wins, $5 for middle or base line wins.");

                // Function to check for a win on a specific horizontal line
                for (int row = 0; row < slots_Output.GetLength(0); row++)
                {
                    bool horizontalWin = true;

                    for (int column = 1; column < slots_Output.GetLength(1); column++)
                    {
                        // Compare the current symbol to the first symbol in the row
                        if (slots_Output[row, 0] != slots_Output[row, column])
                        {
                            // If any symbol is different, set the flag to false and break
                            horizontalWin = false; // No win on this line
                            break;
                        }
                    }

                    // If horizontalWin is still true, there is a win on this row
                    if (horizontalWin)
                    {
                        Console.WriteLine($"Congratulations! You win on the {(row == 0 ? "left" : (row == 1 ? "middle" : "right"))} Horizontal line!");
                    }
                    else
                    {
                        Console.WriteLine($"You did not win on the Horizontal lines!");
                    }
                }
            }
            
            else if (bettingOption == "H")
            {
                Console.WriteLine("\nYou chose to play horizontal center line with $2: Earn $30.");

                /// Function to check for a win on the specific vertical lines
                for (int column = 0; column < slots_Output.GetLength(1); column++)
                {
                    bool verticalWin = true;

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
                        Console.WriteLine($"Congratulations! You win on the {(column == 0 ? "top" : (column == 1 ? "middle" : "bottom"))} horizontal line!");
                    }
                    else
                    {
                        Console.WriteLine("You did not win on the vertical line!");
                    }
                }
            }
            
            else if (bettingOption == "V")
            {
                Console.WriteLine("\nYou chose to play all vertical lines with $2: Earn $20 for first line wins, $5 for second or third line wins.");
                // Check for wins on each vertical line
                bool isLeftVerticalWin = CheckVerticalWin(0);
                bool isMiddleVerticalWin = CheckVerticalWin(1);
                bool isRightVerticalWin = CheckVerticalWin(2);

                // Check if there is a win on any horizontal line
                if (isLeftVerticalWin || isMiddleVerticalWin || isRightVerticalWin)
                {
                    Console.WriteLine("Congratulations!");
                }
                else
                {
                    Console.WriteLine("\nYou Lost! Try Again Next Time.");
                }

                // Function to check for a win on a specific vertical line
                bool CheckVerticalWin(int column)
                {
                    for (int row = 1; row < slots_Output.GetLength(0); row++)
                    {
                        // Compare the current symbol to the previous symbol in the specified column
                        if (slots_Output[row, column] != slots_Output[row - 1, column])
                        {
                            return false; // No win on this line
                        }
                    }

                    Console.WriteLine($"Congratulations! You win on the {(column == 0 ? "left" : (column == 1 ? "middle" : "right"))} vertical line!");
                    return true; // Win detected on this line
                }
            }
            
            else if (bettingOption == "C")
            {
                Console.WriteLine("\nYou chose to play vertical center line with $2: Earn $30.");

                // Check for wins on each vertical line
                bool isMiddleVerticalWin = CheckVerticalWin(1);

                // Check if there is a win on any horizontal line
                if (isMiddleVerticalWin)
                {
                    Console.WriteLine("Congratulations!");
                }
                else
                {
                    Console.WriteLine("\nYou Lost! Try Again Next Time.");
                }

                // Function to check for a win on a specific vertical line
                bool CheckVerticalWin(int column)
                {
                    for (int row = 1; row < slots_Output.GetLength(0); row++)
                    {
                        // Compare the current symbol to the previous symbol in the specified column
                        if (slots_Output[row, column] != slots_Output[row - 1, column])
                        {
                            return false; // No win on this line
                        }
                    }
                    Console.WriteLine($"Congratulations! You win on the {(column == 1 ? "middle" : "")} vertical line!");
                    return true; // Win detected on this line
                }
            }

            else if (bettingOption == "D") { Console.WriteLine("You chose to play diagonals with $2: Earn $20 for either of the two diagonal win."); }
            else { Console.WriteLine("Invalid betting option. Please try again."); }

            //Check for a win on diagonal lines
            int diagonalWinsCount = 0;

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
                diagonalWinsCount++;
                Console.WriteLine("Diagonal Win Detected on Main Diagonal");
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
                diagonalWinsCount++;
                Console.WriteLine("Diagonal Win Detected on Secondary Diagonal");
            }
        }
    }
}