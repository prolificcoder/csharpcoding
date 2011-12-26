using System;
using System.Collections.Generic;
using System.Text;

namespace CodeChef
{
    class PrimesRange
    {
        Dictionary<int, int> Primes = new Dictionary<int, int>();
        Dictionary<int, int[]> ranges = new Dictionary<int, int[]>();
        public static void Main()
        {           
            PrimesRange pr = new PrimesRange();
            string input = string.Empty;
            StringBuilder sb = new StringBuilder();
            int numRange=int.Parse(System.Console.ReadLine());
            for(int i =0; i<numRange;i++)
            {
                input = System.Console.ReadLine();
                string[] iArgs = input.Split(' ');
                pr.ranges.Add(i, new int[] { int.Parse(iArgs[0]), int.Parse(iArgs[1]) });
            }
            DateTime dt = DateTime.Now;
            for(int i =0; i<numRange;i++)
            {
                int min = pr.ranges[i][0];
                int max= pr.ranges[i][1];

                for (int j = min; j <= max; j++)
                {
                    if (pr.Primes.ContainsKey(j) || pr.IsPrime(j))
                    {
                        sb.AppendLine(j.ToString());
                        if (!pr.Primes.ContainsKey(j))
                        {
                            pr.Primes.Add(j, j);
                        }
                    }
                }
                sb.AppendLine();
            }
            Console.Write(sb);
            Console.WriteLine(dt +"time"+ System.DateTime.Now);
        }
        public bool IsPrime(int n)
        {
            for (int i = 2; i <= Math.Sqrt(n); i++)
                if (n % i == 0)
                    return false;
            return true;
        }
    }
}
