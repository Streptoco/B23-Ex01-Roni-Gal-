using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Program
{
    // TODO: 1. check for kelet lo huki 2. 
    public static void Main()
    {
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

    public static short ConvertToDecimal(string readNumberFromUser)
    {
        short convertedNumber = 0;
        for(int i = 0;  i <= 7; i++)
        {
            short power = (short)(readNumberFromUser[i] - '0');
            if(power != 0)
            {
                convertedNumber += (short)Math.Pow(2, power * (7 - i));
            }
            Console.WriteLine(convertedNumber);
        }
        return convertedNumber;
    } // 11100110 => 230
}
