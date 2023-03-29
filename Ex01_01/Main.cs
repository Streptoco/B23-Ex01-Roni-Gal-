using System;
using System.Net.NetworkInformation;

public class Program
{
    // TODO: 1. check for kelet lo huki 2. 
    public static void Main()
    {
        short numberOfOnesInString = 0;
        short numberOfZerosInString = 0;
        Console.WriteLine("Please enter 3 binary numbers, each containing 8 digits.");
        for(int i = 0; i < 3; i++)
        {
            string readNumberFromUser = Console.ReadLine();
            while (readNumberFromUser.Length != 8  && !isValid(readNumberFromUser))
            {
                Console.WriteLine("Please enter a VALID number!");
                readNumberFromUser = Console.ReadLine();
            }
            short numberConvertedToDecimalFromBinary = ConvertToDecimal(readNumberFromUser);
            numberOfOnesInString = CountNumberOfOnesInString(readNumberFromUser);
            numberOfZerosInString = (short)((8 - numberOfOnesInString));
            Console.WriteLine(numberConvertedToDecimalFromBinary);
        }
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
            Console.WriteLine(convertedNumber);
        }
        return convertedNumber;
    }

    public static short CountNumberOfOnesInString(string number)
    {
        short count = 0;
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
