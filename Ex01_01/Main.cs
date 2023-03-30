using System;
using System.Net.NetworkInformation;

public class Program
{
    public const int NUMBER_OF_ITERATIONS = 3;
    public const int DIVIDING_FACTOR = 24;
    public const int BYTE_SIZE = 8;
    // TODO: 1. check for kelet lo huki 2. 
    public static void Main()
    {
        float numberOfOnesInCurrentString = 0;
        float numberOfOnesInAllStrings = 0;
        float numberOfZerosInCurrentString = 0;
        float numberOfZerosInAllStrings = 0;
        int numberOfNumbersDividedByFour = 0;
        int countNumberOfPalindromes = 0;
        int countNumberOfDescendingNumbers = 0;
        Console.WriteLine("Please enter 3 binary numbers, each containing 8 digits.");
        for(int i = 0; i < NUMBER_OF_ITERATIONS; i++)
        {
            string readNumberFromUser = Console.ReadLine();
            while (readNumberFromUser.Length != BYTE_SIZE  && !isValid(readNumberFromUser))
            {
                Console.WriteLine("Please enter a VALID number!");
                readNumberFromUser = Console.ReadLine();
            }
            short numberConvertedToDecimalFromBinary = ConvertToDecimal(readNumberFromUser);
            numberOfOnesInCurrentString = CountNumberOfOnesInString(readNumberFromUser);
            numberOfOnesInAllStrings += numberOfOnesInCurrentString;
            numberOfZerosInCurrentString = (float)(BYTE_SIZE - numberOfOnesInCurrentString);
            numberOfZerosInAllStrings += numberOfZerosInCurrentString;
            if(numberConvertedToDecimalFromBinary % 4 == 0)
            {
                numberOfNumbersDividedByFour++;
            }
            if(IsPalindrome(numberConvertedToDecimalFromBinary))
            {
                countNumberOfPalindromes++;
            }
            if(AreDigitsDescendingSeries(numberConvertedToDecimalFromBinary))
            {
                countNumberOfDescendingNumbers++;
            }
        }
        Console.WriteLine($"The average number of zeros: {numberOfZerosInAllStrings / NUMBER_OF_ITERATIONS}\nThe average number of ones: {numberOfOnesInAllStrings / NUMBER_OF_ITERATIONS}");
        Console.WriteLine($"The number of numbers divided by 4 is {numberOfNumbersDividedByFour}");
        Console.WriteLine($"The number of palindromes is {countNumberOfPalindromes}");
        Console.WriteLine($"The number of descending serieses in numbers is {countNumberOfDescendingNumbers}");
    }

    public static bool isValid(string readNumberFromUser)
    {
        for(int i = 0; i < 8; i++)
        {
            if (readNumberFromUser[i] != 1 || readNumberFromUser[i] != 0)
            {
                return false;
            }
        }
        return true;
    }

    public static short ConvertToDecimal(string binaryString)
    {
        short convertedNumber = 0;
        for (int i = 0; i <= 7; i++)
        {
            short power = (short)(binaryString[i] - '0');
            if (power != 0)
            {
                convertedNumber += (short)Math.Pow(2, power * (7 - i));
            }
        }
        return convertedNumber;
    }

    public static float CountNumberOfOnesInString(string number)
    {
        float count = 0;
        for (int i=0; i<number.Length; i++)
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
