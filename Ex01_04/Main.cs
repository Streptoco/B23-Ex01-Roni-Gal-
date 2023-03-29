using System;
using System.Text;

public class Program
{
    public static void Main()
    {
        Console.WriteLine("Please enter a string containing 6 chars");
        string inputFromUser = Console.ReadLine();
        // Method to check the string
        if(!invalidInputChecker(inputFromUser))
        {
            Console.WriteLine("Invalid input!");
            return;
        }
        // Method to check if it's a palindrome
        Console.WriteLine(isPalindrome(inputFromUser) ? "The string is a palindrome." : "The string isn't a palindrome.");
        // Method to check if the number divides by 3
        // Method to check how many uppercase letters are there
    }
    public static bool invalidInputChecker(string inputFromUser)
    {
        if(inputFromUser.Length > 6)
        {
            return false;
        }
        else if (inputFromUser[0] >= 'a' && inputFromUser[0] <= 'z' || inputFromUser[0] >= 'A' && inputFromUser[0] <= 'Z')
        {
            for(int i = 1; i < inputFromUser.Length; i++)
            {
                if((inputFromUser[i] < 'a' || inputFromUser[i] > 'z') || (inputFromUser[i] < 'A' && inputFromUser[i] > 'Z'))
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
        if(inputFromUser.Length == 1)
            return true;
        else if (inputFromUser[0] == inputFromUser[inputFromUser.Length-1])
        {
            StringBuilder sb = new StringBuilder(inputFromUser);
            return isPalindrome(sb.ToString(1, inputFromUser.Length - 2));
        }
        else
        {
            return false;
        }
    }
}
