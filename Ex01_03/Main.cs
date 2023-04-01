using System;

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

    public static void printRow(int numberOfStarsInRow, int numberOfSpacesInRow, int fixedRowLength)
    {
        if (fixedRowLength == 0)
        {
            Console.Write('\n');
            return;
        }
        else if (numberOfSpacesInRow > 0) // Invoke the left space-bars in the pattern
        {
            Console.Write(" ");
            printRow(numberOfStarsInRow, numberOfSpacesInRow - 1, fixedRowLength - 1);
        }
        else if (numberOfStarsInRow > 0) // Invoke the stars in the pattern
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
        if (height < numberOfStars)
        {
            return;
        }

        printRow(numberOfStars, (height - numberOfStars) / 2, height);
        printDiamondRecursive(numberOfStars + 2, height);
       
        if (height == numberOfStars)
        {
            return;
        }
        printRow(numberOfStars, (height - numberOfStars) / 2, height);
    }

    public static void printDiamond(int numberOfStars, int height)
    {
        printDiamondRecursive(numberOfStars, height);
    }
}