namespace Ex01_05
{
    using System;

    public class Program
    {
        public static void Main()
        {
            printAndInteract();
        }

        public static void printAndInteract()
        {
            Console.WriteLine("Please enter a string containing 6 digits.");
            string inputFromUser = Console.ReadLine();

            while (!isInputValid(inputFromUser))
            {
                Console.WriteLine($"{inputFromUser} is an inavlid input. Please try again.");
                inputFromUser = Console.ReadLine();
            }

            Console.WriteLine($"There are {getNumberOfDigitsBiggerThanLastDigits(inputFromUser)} digits larger than the last digit.");
            Console.WriteLine($"The minimum digit is {getMinimumDigitsInNumber(inputFromUser)}");
            Console.WriteLine($"The number of digits divided by 3 is {getNumberOfDigitsDividedBy3(inputFromUser)}");
            Console.WriteLine($"The average of all digits is {getAverageOfDigits(inputFromUser)}");
        }

        public static bool isInputValid(string i_InputFromUser)
        {
            bool returnedBoolFromFunction = true;
           
            for (int i = 0; i < i_InputFromUser.Length; i++)
            {
                if (i_InputFromUser[i] < '0' || i_InputFromUser[i] > '9')
                {
                    returnedBoolFromFunction = false;
                }
            }

            if (i_InputFromUser.Length != 6)
            {
                returnedBoolFromFunction = false;
            }

            return returnedBoolFromFunction;
        }

        public static int getNumberOfDigitsBiggerThanLastDigits(string i_InputFromUser)
        {
            int digitCounter = 0;

            for (int i = 0; i < i_InputFromUser.Length - 1; i++)
            {
                if ((i_InputFromUser[i] - '0') > (i_InputFromUser[i_InputFromUser.Length - 1] - '0'))
                {
                    digitCounter++;
                }
            }

            return digitCounter;
        }

        public static int getMinimumDigitsInNumber(string i_InputFromUser)
        {
            int minimumDigit = i_InputFromUser[0] - '0';

            for (int i = 1; i < i_InputFromUser.Length; i++)
            {
                if ((i_InputFromUser[i] - '0') < minimumDigit)
                {
                    minimumDigit = (i_InputFromUser[i] - '0');
                }
            }

            return minimumDigit;
        }

        public static int getNumberOfDigitsDividedBy3(string i_InputFromUser)
        {
            int numberCounter = 0;

            for (int i = 0; i < i_InputFromUser.Length; i++)
            {
                if ((i_InputFromUser[i] - '0') % 3 == 0)
                {
                    numberCounter++;
                }
            }

            return numberCounter;
        }

        public static float getAverageOfDigits(string i_InputFromUser)
        {
            float digitsSummer = 0;

            for (int i = 0; i < i_InputFromUser.Length; i++)
            {
                digitsSummer += (i_InputFromUser[i] - '0');
            }

            return digitsSummer / i_InputFromUser.Length;
        }
    }
}