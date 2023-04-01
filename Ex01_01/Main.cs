using System;

public class Program
{
    public const int NUMBER_OF_ITERATIONS = 3;
    public const int DIVIDING_FACTOR = 24;
    public const int BYTE_SIZE = 8;
    public static void Main()
    {
        printMenuAndInteract();
    }

    public static void printMenuAndInteract()
    {
        int firstNumberInIteration = 0, secondNumberInIteration = 0, thirdNumberInIteration = 0;

        float numberOfOnesInCurrentString = 0, numberOfZerosInCurrentString = 0;
        float numberOfOnesInAllStrings = 0, numberOfZerosInAllStrings = 0;
        int countNumberOfNumbersDividedByFour = 0, countNumberOfPalindromes = 0, countNumberOfDescendingNumbers = 0;
        string readNumberFromUser;
        int numberConvertedToDecimalFromBinary;

        Console.WriteLine("Please enter 3 binary numbers, each containing 8 digits.");
        for (int i = 0; i < NUMBER_OF_ITERATIONS; i++)
        {
            readNumberFromUser = Console.ReadLine();

            while (readNumberFromUser.Length != BYTE_SIZE && !isValid(readNumberFromUser))
            {
                Console.WriteLine("Please enter a VALID number!");
                readNumberFromUser = Console.ReadLine();
            }

            numberConvertedToDecimalFromBinary = ConvertToDecimal(readNumberFromUser);

            if (i == 0)
            {
                firstNumberInIteration = numberConvertedToDecimalFromBinary;
            }
            else if (i == 1)
            {
                secondNumberInIteration = numberConvertedToDecimalFromBinary;
            } 
            else if (i == 2)
            {
                thirdNumberInIteration = numberConvertedToDecimalFromBinary;
            }

            if (numberConvertedToDecimalFromBinary % 4 == 0)
            {
                countNumberOfNumbersDividedByFour++;
            }

            if (IsPalindrome(numberConvertedToDecimalFromBinary))
            {
                countNumberOfPalindromes++;
            }

            if (AreDigitsDescendingSeries(numberConvertedToDecimalFromBinary))
            {
                countNumberOfDescendingNumbers++;
            }

            numberOfOnesInCurrentString = CountNumberOfOnesInString(readNumberFromUser);
            numberOfOnesInAllStrings += numberOfOnesInCurrentString;
            numberOfZerosInCurrentString = (float)(BYTE_SIZE - numberOfOnesInCurrentString);
            numberOfZerosInAllStrings += numberOfZerosInCurrentString;
        }

        sortAndPrintThreeDecimalsHighestToLowest(firstNumberInIteration, secondNumberInIteration, thirdNumberInIteration);

        Console.WriteLine($"The average number of zeros: {numberOfZerosInAllStrings / NUMBER_OF_ITERATIONS}");
        Console.WriteLine($"The average number of ones: {numberOfOnesInAllStrings / NUMBER_OF_ITERATIONS}");
        Console.WriteLine($"The number of numbers divided by 4 is {countNumberOfNumbersDividedByFour}");
        Console.WriteLine($"The number of palindromes is {countNumberOfPalindromes}");
        Console.WriteLine($"The number of descending serieses in numbers is {countNumberOfDescendingNumbers}");
    }

    public static void sortAndPrintThreeDecimalsHighestToLowest(int number1, int number2, int number3)
    {
        int highest, lowest, middle;

        highest = Math.Max(Math.Max(number1, number2), number3);
        lowest = Math.Min(Math.Min(number1, number2), number3);
        middle = number1 + number2 + number3 - highest - lowest;

        Console.WriteLine($"The numbers in decimal form (from highest to lowest are: {highest}, {middle}, {lowest}");
    }

    public static bool isValid(string readNumberFromUser)
    {
        for (int i = 0; i < 8; i++)
        {
            if (readNumberFromUser[i] != 1 || readNumberFromUser[i] != 0)
            {
                return false;
            }
        }

        return true;
    }

    public static int ConvertToDecimal(string binaryString)
    {
        int convertedNumber = 0;
        
        for (int i = 0; i <= 7; i++)
        {
            int power = binaryString[i] - '0';
            if (power != 0)
            {
                convertedNumber += (int)Math.Pow(2, power * (7 - i));
            }
        }

        return convertedNumber;
    }

    public static float CountNumberOfOnesInString(string number)
    {
        float count = 0;

        for (int i = 0; i < number.Length; i++)
        {
            if (number[i] == '1')
                count++;
        }

        return count; 
    }

    public static bool IsPalindrome(int number)
    {
        int numberReversed = 0, numberCopy = number, digit;
        
        while (number != 0)
        {
            digit = number % 10;
            numberReversed = (numberReversed * 10) + digit;
            number = number / 10;
        }

        return (numberCopy == numberReversed);
    }

    public static bool AreDigitsDescendingSeries(int number)
    {
        while (number / 10 != 0)
        {
            if (number % 10 >= (number / 10) % 10)
            {
                return false;
            }

            number = number / 10;
        }

        return true;
    }
}