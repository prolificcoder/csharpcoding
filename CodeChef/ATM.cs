using System;
using System.Collections.Generic;
using System.Text;

namespace CodeChef
{
        class ATM
        {
            public static void Main()
            {
                string input;
                while ((input = Console.ReadLine()) != null)
                {
                    string[] iArgs = input.Split(' ');
                    if (((int.Parse(iArgs[0]) % 5) != 0) || (double.Parse(iArgs[0]) + 0.5 > double.Parse(iArgs[1])))
                    {
                        Console.WriteLine(iArgs[1]);
                    }
                    else
                    {
                        Console.WriteLine(double.Parse(iArgs[1]) - double.Parse(iArgs[0]) - 0.5);
                    }
                }
            }
        }
 
}
