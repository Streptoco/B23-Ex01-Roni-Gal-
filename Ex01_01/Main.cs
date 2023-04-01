namespace Ex01_01
{
    using System;

    public class Program
    {
        public const int k_NumberOfIterations = 3;
        public const int k_DividingFactor = 24;
        public const int k_ByteSize = 8;

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
            for (int i = 0; i < k_NumberOfIterations; i++)
            {
                readNumberFromUser = Console.ReadLine();

                while (!isValid(readNumberFromUser))
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
                numberOfZerosInCurrentString = (float)(k_ByteSize - numberOfOnesInCurrentString);
                numberOfZerosInAllStrings += numberOfZerosInCurrentString;
            }

            sortAndPrintThreeDecimalsHighestToLowest(firstNumberInIteration, secondNumberInIteration, thirdNumberInIteration);

            Console.WriteLine($"The average number of zeros: {numberOfZerosInAllStrings / k_NumberOfIterations}");
            Console.WriteLine($"The average number of ones: {numberOfOnesInAllStrings / k_NumberOfIterations}");
            Console.WriteLine($"The number of numbers divided by 4 is {countNumberOfNumbersDividedByFour}");
            Console.WriteLine($"The number of palindromes is {countNumberOfPalindromes}");
            Console.WriteLine($"The number of descending series in numbers is {countNumberOfDescendingNumbers}");
        }

        public static void sortAndPrintThreeDecimalsHighestToLowest(int i_FirstNumber, int i_SecondNumber, int i_ThirdNumber)
        {
            int highest, lowest, middle;

            highest = Math.Max(Math.Max(i_FirstNumber, i_SecondNumber), i_ThirdNumber);
            lowest = Math.Min(Math.Min(i_FirstNumber, i_SecondNumber), i_ThirdNumber);
            middle = i_FirstNumber + i_SecondNumber + i_ThirdNumber - highest - lowest;

            Console.WriteLine($"The numbers in decimal form (from highest to lowest are: {highest}, {middle}, {lowest})");
        }

        public static bool isValid(string i_ReadNumberFromUser)
        {
            bool returnBoolFromFunction = true;

            for (int i = 0; i < k_ByteSize; i++)
            {
                if (i_ReadNumberFromUser[i] != '1' && i_ReadNumberFromUser[i] != '0')
                {
                    returnBoolFromFunction = false;
                }
            }

            if (i_ReadNumberFromUser.Length != k_ByteSize)
            {
                returnBoolFromFunction = false;
            }

            return returnBoolFromFunction;
        }

        public static int ConvertToDecimal(string i_BinaryString)
        {
            int convertedNumber = 0;

            for (int i = 0; i <= k_ByteSize - 1; i++)
            {
                int power = i_BinaryString[i] - '0';
                if (power != 0)
                {
                    convertedNumber += (int)Math.Pow(2, power * (7 - i));
                }
            }

            return convertedNumber;
        }

        public static float CountNumberOfOnesInString(string i_Number)
        {
            float count = 0;

            for (int i = 0; i < i_Number.Length; i++)
            {
                if (i_Number[i] == '1')
                {
                    count++;
                }
            }

            return count;
        }

        public static bool IsPalindrome(int i_Number)
        {
            int numberReversed = 0, numberCopy = i_Number, digit;

            while (i_Number != 0)
            {
                digit = i_Number % 10;
                numberReversed = (numberReversed * 10) + digit;
                i_Number = i_Number / 10;
            }

            return numberCopy == numberReversed;
        }

        public static bool AreDigitsDescendingSeries(int i_Number)
        {
            bool returnBoolFromFunction = true;
            while (i_Number / 10 != 0)
            {
                if (i_Number % 10 >= (i_Number / 10) % 10)
                {
                    returnBoolFromFunction = false;
                }

                i_Number = i_Number / 10;
            }

            return returnBoolFromFunction;
        }
    }
}