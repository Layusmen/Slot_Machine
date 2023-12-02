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
            Console.WriteLine("Press......");
            Console.WriteLine("- (A) Play all three horizontal lines with $2: Earn $20 for top line wins, $5 for middle or base line wins.");
            Console.WriteLine("- (H) Play horizontal center line with $2: Earn $30.");
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


            //Betting Options Statements
            if (bettingOption == "A")
            {

                Console.WriteLine("You chose to play all three horizontal lines with $2: Earn $20 for top line wins, $5 for middle or base line wins.");
                
                //Check for a win on horizontal lines
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

                    if (isHorizontalWin)
                    {
                        horizontalWinsCount++;
                        Console.WriteLine("Horizontal win detected in row " + innerRow + 1);
                        // You can customize the output message as needed
                    }
                    else
                    {
                        Console.WriteLine("You Lost! Try Again Next Time.");
                    }
                }

            }

            else if (bettingOption == "H")
            { Console.WriteLine("You chose to play horizontal center line with $2: Earn $30."); }
            
            
            else if (bettingOption == "V") { Console.WriteLine("You chose to play all vertical lines with $2: Earn $20 for first line wins, $5 for second or third line wins."); }
            else if (bettingOption == "C") { Console.WriteLine("You chose to play vertical center line with $2: Earn $30."); }
            else if (bettingOption == "D") { Console.WriteLine("You chose to play diagonals with $2: Earn $20 for any winning combination."); }
            else { Console.WriteLine("Invalid betting option. Please try again.");}
                
            //Check for a win on vertical lines
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
                    Console.WriteLine("Vertical win detected in column " + column + 1);
                    // You can customize the output message as needed
                }
            }
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