using System;
using System.Collections.Generic;
using System.Text;

namespace CodeChef
{
    class LifeUniverse
    {
         public static void Main()
        {
            //1.Read file
            //2.Process data
            //3.Write into file
            string line;
            string output=null;

            // Read the file and display it line by line.
          
            while ((line = System.Console.ReadLine()) != null)
            {
                if (int.Parse(line) == 42)
                    break;
                output += line+"\n";
            }
            Console.WriteLine(output);
        }
    }
}
