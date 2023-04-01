using System;
using System.Text;

public enum eChoice 
{ 
  NumberAndDividesBy3, 
  NumberAndDoesntDivideBy3, 
  NotANumber,
}
namespace Ex01_04
{
    public class Program
    {

        public static void Main()
        {
            printMenuAndInteract();
        }

        public static void printMenuAndInteract()
        {
            Console.WriteLine("Please enter a string containing 6 chars");
            string inputFromUser = Console.ReadLine();

            // Check if the string is valid
            if (!invalidInputChecker(inputFromUser))
            {
                Console.WriteLine("Invalid input!");
                return;
            }

            // Check if it's a palindrome
            Console.WriteLine(isPalindrome(inputFromUser) ? "The string is a palindrome." : "The string isn't a palindrome.");

            // Check if the number divides by 3
            eChoice doesTheNumberDivideByThree = doesItDivideByThree(inputFromUser);
            if (doesTheNumberDivideByThree == eChoice.NotANumber)
            {
                Console.WriteLine("The string isn't a number.");
            }
            else if (doesTheNumberDivideByThree == eChoice.NumberAndDoesntDivideBy3)
            {
                Console.WriteLine("The string is a number, but it's not divisible by three.");
            }
            else
            {
                Console.WriteLine("The string is a number, and it is divided by three.");
            }

            // Check how many uppercase letters are there
            int countUpperCaseLetters = countUppercaseLettersInString(inputFromUser);
            Console.WriteLine($"The number of uppercase letters in the string is {countUpperCaseLetters}");
        }
        public static bool invalidInputChecker(string i_InputFromUser)
        {
            bool returnedBoolFromFunction = true;
            
            if ((i_InputFromUser[0] >= 'a' && i_InputFromUser[0] <= 'z') || (i_InputFromUser[0] >= 'A' && i_InputFromUser[0] <= 'Z'))
            {
                for (int i = 1; i < i_InputFromUser.Length; i++)
                {
                    if ((i_InputFromUser[i] < 'a' || i_InputFromUser[i] > 'z') && (i_InputFromUser[i] < 'A' || i_InputFromUser[i] > 'Z'))
                    {
                        returnedBoolFromFunction = false;
                    }
                }
            }
            else if (i_InputFromUser[0] >= '0' && i_InputFromUser[0] <= '9')
            {
                for (int i = 1; i < i_InputFromUser.Length; i++)
                {
                    if (i_InputFromUser[i] < '0' || i_InputFromUser[i] > '9')
                    {
                        returnedBoolFromFunction = false;
                    }
                }
            }
            else
            {
                returnedBoolFromFunction = false;
            }

            if (i_InputFromUser.Length != 6)
            {
                returnedBoolFromFunction = false;
            }

            return returnedBoolFromFunction;
        }
        public static bool isPalindrome(string i_InputFromUser)
        {
            bool returnedBoolFromFunction = true;
            if (i_InputFromUser[0] == i_InputFromUser[i_InputFromUser.Length - 1])
            {
                StringBuilder sb = new StringBuilder(i_InputFromUser);
                returnedBoolFromFunction = isPalindrome(sb.ToString(1, i_InputFromUser.Length - 2));
            }
            else
            {
                returnedBoolFromFunction = false;
            }
            return returnedBoolFromFunction;
        }

        public static eChoice doesItDivideByThree(string i_InputFromUser)
        {
            int parseResult;
            eChoice divisionByThreeResult;

            if (int.TryParse(i_InputFromUser, out parseResult))
            {
                divisionByThreeResult = parseResult % 3 == 0 ? eChoice.NumberAndDividesBy3 : eChoice.NumberAndDoesntDivideBy3;
            }
            else
            {
                divisionByThreeResult = eChoice.NotANumber;
            }

            return divisionByThreeResult;
        }

        public static int countUppercaseLettersInString(string i_InputFromUser)
        {
            int countNumberOfUpperLetters = 0;

            for (int i = 0; i < i_InputFromUser.Length; i++)
            {
                if (char.IsUpper(i_InputFromUser[i]))
                {
                    countNumberOfUpperLetters++;
                }
            }

            return countNumberOfUpperLetters;
        }
    }
}
