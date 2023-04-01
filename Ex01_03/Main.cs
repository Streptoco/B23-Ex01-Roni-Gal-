﻿using System;
namespace Ex01_03
{
    public class Program
    {
        public static void Main()
        {
            PrintMenuAndInteract();
        }

        public static void PrintMenuAndInteract()
        {
            int heightInputFromUser;

            Console.WriteLine("Please enter the desired height of the diamond.");
            int.TryParse(Console.ReadLine(), out heightInputFromUser);

            if (heightInputFromUser == 0)
            {
                return;
            }
            else if (heightInputFromUser % 2 == 0)
            {
                heightInputFromUser--;
            }

            printDiamond(1, heightInputFromUser);
        }

        public static void printRow(int i_NumberOfStarsInRow, int i_NumberOfSpacesInRow, int i_FixedRowLength)
        {
            if (i_FixedRowLength == 0)
            {
                Console.Write('\n');
                return;
            }
            else if (i_NumberOfSpacesInRow > 0) // Invoke the left space-bars in the pattern
            {
                Console.Write(" ");
                printRow(i_NumberOfStarsInRow, i_NumberOfSpacesInRow - 1, i_FixedRowLength - 1);
            }
            else if (i_NumberOfStarsInRow > 0) // Invoke the stars in the pattern
            {
                Console.Write("*");
                printRow(i_NumberOfStarsInRow - 1, i_NumberOfSpacesInRow, i_FixedRowLength - 1);
            }
            else // Invoke the right space-bars in the pattern
            {
                Console.Write(" ");
                printRow(i_NumberOfStarsInRow, i_NumberOfSpacesInRow, i_FixedRowLength - 1);
            }
        }

        public static void printDiamondRecursive(int i_NumberOfStars, int i_Height)
        {
            if (i_Height < i_NumberOfStars)
            {
                return;
            }

            printRow(i_NumberOfStars, (i_Height - i_NumberOfStars) / 2, i_Height);
            printDiamondRecursive(i_NumberOfStars + 2, i_Height);

            if (i_Height == i_NumberOfStars)
            {
                return;
            }
            printRow(i_NumberOfStars, (i_Height - i_NumberOfStars) / 2, i_Height);
        }

        public static void printDiamond(int i_NumberOfStars, int i_Height)
        {
            printDiamondRecursive(i_NumberOfStars, i_Height);
        }
    }
}