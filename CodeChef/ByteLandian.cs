using System;
using System.Collections.Generic;
using System.Text;

namespace CodeChef
{
    class ByteLandian
    {
        static Dictionary<long, long> curMax= new Dictionary<long,long>();
        public static void Main()
        {
            string input=string.Empty;
            
            while ((input = System.Console.ReadLine()) != null)
            {   
                long inpVal = long.Parse(input);
                if (inpVal < 0 || inpVal > 1000000000)
                    return;
                Console.WriteLine(bankExgVal(inpVal));              
            }            
        }
        public static long bankExgVal(long inp)
        {
            if (curMax.ContainsKey(inp))
                return curMax[inp];
            else
            {
                long val = 0;
                if (inp < 12)
                    val = inp;
                else
                    val= Math.Max(inp, bankExgVal(inp / 2) + bankExgVal(inp / 3) + bankExgVal(inp / 4));
                curMax.Add(inp, val);
                return val;
            }
        }
    }
}
