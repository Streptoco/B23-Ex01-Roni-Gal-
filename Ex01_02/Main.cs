using System;

public class Program
{
    public static void Main()
    {
        printDiamond(1, 9);
    }

    public static void printRow(int numberOfStarsInRow, int numberOfSpacesInRow, int fixedRowLength)
    {
        if (fixedRowLength == 0)
        {
            Console.Write('\n');
            return;
        }
        else if(numberOfSpacesInRow > 0) // Invoke the left space-bars in the pattern
        {
            Console.Write(" ");
            printRow(numberOfStarsInRow, numberOfSpacesInRow-1, fixedRowLength-1);
        }
        else if(numberOfStarsInRow > 0 ) // Invoke the stars in the pattern
        {
            Console.Write("*");
            printRow(numberOfStarsInRow - 1, numberOfSpacesInRow, fixedRowLength - 1);
        }
        else // Invoke the right space-bars in the pattern
        {
            Console.Write(" ");
            printRow(numberOfStarsInRow, numberOfSpacesInRow, fixedRowLength - 1);
        }
    }

    public static void printDiamondRecursive(int numberOfStars, int height)
    {
        if(height < numberOfStars)
        {
            return;
        }
        printRow(numberOfStars, (height - numberOfStars)/2, height);
        printDiamondRecursive(numberOfStars + 2, height);
        if(height == numberOfStars)
        {
            return;
        }
        printRow(numberOfStars, (height - numberOfStars)/2, height);
    }

    public static void printDiamond(int numberOfStars, int height)
    {
        printDiamondRecursive(numberOfStars, height);
    }
}
