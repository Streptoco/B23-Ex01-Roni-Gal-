using System;
using System.Text;

public class Program
{
    public static void Main()
    {
        Console.WriteLine("Please enter a string containing 6 digits.");
        string inputFromUser = Console.ReadLine();
        while(!isInputValid(inputFromUser))
        {
            Console.WriteLine($"{inputFromUser} is an inavlid input. Please try again.");
            inputFromUser = Console.ReadLine();
        }
        Console.WriteLine($"There are {getNumberOfDigitsBiggerThanLastDigits(inputFromUser)} digits larger than the last digit.");
        Console.WriteLine($"The minimum digit is {getMinimumDigitsInNumber(inputFromUser)}");
        Console.WriteLine($"The number of digits divided by 3 is {getNumberOfDigitsDividedBy3(inputFromUser)}");
        Console.WriteLine($"The average of all digits is {getAverageOfDigits(inputFromUser)}");
    }
    public static bool isInputValid(string inputFromUser)
    {
        if(inputFromUser.Length != 6)
        {
            return false;
        }
        for(int i = 0; i < inputFromUser.Length; i++)
        {
            if (inputFromUser[i] < '0' || inputFromUser[i] > '9')
            {
                return false;
            }
        }
        return true;
    }
    public static int getNumberOfDigitsBiggerThanLastDigits(string inputFromUser)
    {
        int digitCounter = 0;
        for(int i = 0; i < inputFromUser.Length - 1; i++)
        {
            if ((inputFromUser[i] - '0') > (inputFromUser[inputFromUser.Length-1] - '0'))
            {
                digitCounter++;
            }
        }
        return digitCounter;
    }
    public static int getMinimumDigitsInNumber(string inputFromUser)
    {
        int minimumDigit = (inputFromUser[0] - '0');
        for(int i = 1; i < inputFromUser.Length; i++)
        {
            if ((inputFromUser[i] - '0') < minimumDigit)
            {
                minimumDigit = (inputFromUser[i] - '0');
            }
        }
        return minimumDigit;
    }
    public static int getNumberOfDigitsDividedBy3(string inputFromUser)
    {
        int numberCounter = 0;
        for(int i = 0; i < inputFromUser.Length; i++)
        {
            if ((inputFromUser[i] - '0') % 3 == 0)
            {
                numberCounter++;
            }
        }
        return numberCounter;
    }
    public static float getAverageOfDigits(string inputFromUser)
    {
        float digitsSummer = 0;
        for (int i = 0; i < inputFromUser.Length; i++)
        {
            digitsSummer += (inputFromUser[i] - '0');
        }
        return (digitsSummer / inputFromUser.Length);
    }
}