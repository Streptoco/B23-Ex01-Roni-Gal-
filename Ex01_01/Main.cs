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
                readNumberFromUser = Console.ReadLine();
            }
            int currentNumberParsing = Convert.ToInt32(readNumberFromUser, 2);
            Console.WriteLine(currentNumberParsing);
        }
    }
}
