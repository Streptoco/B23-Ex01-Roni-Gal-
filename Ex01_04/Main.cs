using System;
using System.Text;

public enum eChoice { NumberAndDividesBy3 = 0, NumberAndDoesntDivideBy3, NotANumber }

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
    public static bool invalidInputChecker(string inputFromUser)
    {
        if (inputFromUser.Length != 6)
        {
            return false;
        }
        else if ((inputFromUser[0] >= 'a' && inputFromUser[0] <= 'z') || (inputFromUser[0] >= 'A' && inputFromUser[0] <= 'Z'))
        {
            for (int i = 1; i < inputFromUser.Length; i++)
            {
                if ((inputFromUser[i] < 'a' || inputFromUser[i] > 'z') && (inputFromUser[i] < 'A' || inputFromUser[i] > 'Z'))
                {
                    return false;
                }
            }
            return true;
        }
        else if (inputFromUser[0] >= '0' && inputFromUser[0] <= '9')
        {
            for (int i = 1; i < inputFromUser.Length; i++)
            {
                if (inputFromUser[i] < '0' || inputFromUser[i] >  '9')
                {
                    return false;
                }
            }
            return true;
        }
        else
        {
            return false;
        }    
    }
    public static bool isPalindrome(string inputFromUser)
    {
        if (inputFromUser.Length == 1 || inputFromUser.Length == 0)
        {
            return true;
        }
        else if (inputFromUser[0] == inputFromUser[inputFromUser.Length - 1])
        {
            StringBuilder sb = new StringBuilder(inputFromUser);
            return isPalindrome(sb.ToString(1, inputFromUser.Length - 2));
        }
        else
        {
            return false;
        }
    }

    public static eChoice doesItDivideByThree(string inputFromUser)
    {
        int parseResult;
        eChoice divisionByThreeResult;
        
        if (int.TryParse(inputFromUser, out parseResult))
        {
            divisionByThreeResult = parseResult % 3 == 0 ? eChoice.NumberAndDividesBy3 : eChoice.NumberAndDoesntDivideBy3;
        }
        else
        {
            divisionByThreeResult = eChoice.NotANumber;
        }

        return divisionByThreeResult;
    }

    public static int countUppercaseLettersInString(string inputFromUser)
    {
        int countNumberOfUpperLetters = 0;
        
        for (int i = 0; i < inputFromUser.Length; i++)
        {
            if (char.IsUpper(inputFromUser[i]))
            {
                countNumberOfUpperLetters++;
            }
        }

        return countNumberOfUpperLetters;
    }
}
