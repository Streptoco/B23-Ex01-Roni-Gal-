namespace Ex01_02
{
    using System;

    public class Program
    {
        public static void Main()
        {
            printDiamond(1, 9);
        }

        public static void printRow(int i_NumberOfStarsInRow, int i_NumberOfSpacesInRow, int i_FixedRowLength)
        {
            if (i_FixedRowLength == 0)
            {
                Console.Write('\n');
                return;
            }
            else if (i_NumberOfSpacesInRow > 0) 
            {
                Console.Write(" ");
                printRow(i_NumberOfStarsInRow, i_NumberOfSpacesInRow - 1, i_FixedRowLength - 1);
            }
            else if (i_NumberOfStarsInRow > 0) 
            {
                Console.Write("*");
                printRow(i_NumberOfStarsInRow - 1, i_NumberOfSpacesInRow, i_FixedRowLength - 1);
            }
            else 
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
