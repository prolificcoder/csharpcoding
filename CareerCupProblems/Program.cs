using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CareerCupProblems
{
    class EvenOddComparer : IComparable
    {
        internal int item;
        public EvenOddComparer(int item)
        {
            this.item = item;
        }
        public int CompareTo(object obj)
        {
            int a = this.item;
            EvenOddComparer other = obj as EvenOddComparer;
            int b = other.item;
            if (a % 2 == 1 && b % 2 == 1)
                return b.CompareTo(a);
            else if (a % 2 == 1 && b % 2 == 0)
                return -1;
            else if (a % 2 == 0 && b % 2 == 1)
                return 1;
            else
                return a.CompareTo(b);

        }
   }

        class Program
        {

            static void Main(string[] args)
            {
                Program p = new Program();
                //string chars = "adbb";
                //string str = "ajfblkdasb";
                ////int[] ar = p.MinimumWindow(chars, str);
                ////Console.WriteLine(ar[0] + "  " + ar[1]);
                //EvenOddComparer[] evenOdd = new EvenOddComparer[7];
                //for (int i = 0; i < evenOdd.Length; i++)
                //{
                //    evenOdd[i] = new EvenOddComparer(i);
                //}

                //foreach (var item in evenOdd)
                //    Console.WriteLine(item.item);
                //Console.WriteLine("after sorting");
                //Array.Sort(evenOdd);
                //foreach (var item in evenOdd)
                //    Console.WriteLine(item.item);
                //p.RecSubSet("abcd");
                //foreach (string str in p.subsets)
                    //Console.WriteLine(str);
                //p.Permute("abc");
               // p.Sum(0924);
               // Console.WriteLine(p.Sum(0924));
                //Console.WriteLine(p.CountCannonballs(3));
               // p.Brackets(3);

            //    string st = "abcd";
            //    List<string> strs = new List<string>(){"s","bibs","st"};
            //    SuffixTree tree = new SuffixTree(st);
            //    foreach (string str in strs)
            //    {
            //        List<int> list = tree.GetIndexes(str);
            //        if (list != null)
            //            Console.WriteLine(str + ": " + list);
            //    }
                //int[] ar=new int[52];
                //for(int i =0;i<52;i++)
                //    ar[i]=i;
                //ar=p.Shuffle(ar);
                ////ar=ar.OrderBy(a => Guid.NewGuid()).ToArray();
                //foreach(int item in ar)
                //    Console.WriteLine(item);
                p.PrintPhoneWords(new int[] {4,2,5,4,0,2,5,5,7,7 });
            }

            void PrintPhoneWords(int[] number)
            {
                char[] chars = new char[number.Length];
                PrintPhoneWords(number, 0, chars);
            }
           void PrintPhoneWords(int[] number, int curDigit, char[] chars)
           {
               if (curDigit == number.Length)
               {
                   Console.WriteLine(chars);
               }
               else
               {
                   for (int i = 0; i < 3; i++)
                   {
                       chars[curDigit] = GetCharKey(number[curDigit], i);
                       PrintPhoneWords(number, curDigit + 1, chars);
                       if (number[curDigit] == 0 || number[curDigit] == 1)
                           return;
                   }
               }
           }

           private char GetCharKey(int p, int m)
           {
               if (p == 0 || p == 1)
                   return '0';
               int charValue = 'a'+(char)(3 * (p-2) + m);
               return (char)charValue; 
           }


            int[] Shuffle(int[] ar)
            {
                if (ar == null || ar.Length == 0) return ar;
                Random rand= new Random();
                for(int i=0;i<ar.Length;i++)
                {
                    int n= rand.Next(i,ar.Length-1);
                    Swap(ref ar[i],ref ar[n]);
                }
                return ar;
            }

            private void Swap(ref int p,ref int p_2)
            {
                int temp = p;
                p = p_2;
                p_2 = temp;
            }
            bool IsBalanced(string str)
            {

                if (str == null || str.Length == 0) return true;
                return IsBalanced(str, 0, str.Length);
            }
            bool IsBalanced(string str,int low, int high)
            {
                if (low > high)
                    return true;
                if (str[low] == str[high])
                    return IsBalanced(str, low + 1, high - 1);
                else return false;
            }
            int Sum(int num)
            {
                if (num <= 0)
                    return 0;
                else
                    return (num % 10)+ Sum(num / 10);
            }
            int CountCannonballs(int height)
            {
                if (height <= 0)
                    return 0;
                else
                    return height * height + CountCannonballs(height - 1);
            }

            List<string> subsets = new List<string>();
            void RecSubSet(string soFar,string rest)
            {
                if (rest == "")
                    subsets.Add(soFar);
                else
                {
                    RecSubSet(soFar + rest[0], rest.Substring(1));
                    RecSubSet(soFar, rest.Substring(1));
                }
            }
            void RecSubSet(string soFar)
            {
                RecSubSet("", soFar);
            }

            void Permute(string str)
            {
                Permute("", str);
            }
            void Permute(string soFar,string rest)
            {
                if (rest == "")
                    Console.WriteLine(soFar);
                for (int i = 0; i < rest.Length; i++)
                {
                    string next = soFar + rest[i];
                    string remaining = rest.Substring(0,i)+rest.Substring(i+1);
                    Permute(next, remaining);
                }
            }

            public void Brackets(int n)
            {
                for (int i = 1; i <= n; i++)
                {
                    Brackets("", 0, 0, i);
                }
            }
            private void Brackets(string output, int open, int close, int pairs)
            {
                if ((open == pairs) && (close == pairs))
                {
                    Console.WriteLine(output);
                }
                else
                {
                    if (open < pairs)
                        Brackets(output + "(", open + 1, close, pairs);
                    if (close < open)
                        Brackets(output + ")", open, close + 1, pairs);
                }
            }

            //http://www.careercup.com/question?id=3268664
            //Finding the minimum window in a string in which we can find all the chars in another string
            public int[] MinimumWindow(string chars, string str)
            {
                Dictionary<char, int> charhash = new Dictionary<char, int>();
                foreach (char c in chars)
                {
                    if (charhash.ContainsKey(c))
                        charhash[c]++;
                    else
                        charhash.Add(c, 1);
                }
                int minSoFar = str.Length;
                int minStart = 0, minEnd = 0;
                for (int i = 0; i < str.Length; i++)
                {
                    if (charhash.ContainsKey(str[i]))
                    {
                        Dictionary<char, int> tempCharHash = new Dictionary<char, int>(charhash);
                        if (tempCharHash[str[i]] == 1)
                            tempCharHash.Remove(str[i]);
                        else
                            tempCharHash[str[i]]--;
                        int restCount = chars.Length;
                        for (int j = i + 1; j < i + 1 + restCount && j < str.Length; j++)
                        {
                            if (tempCharHash.ContainsKey(str[j]))
                            {
                                if (tempCharHash[str[j]] == 1)
                                {
                                    tempCharHash.Remove(str[j]);
                                    if (tempCharHash.Count == 0)
                                    {
                                        if (minSoFar > j - i)
                                        {
                                            minSoFar = j - i;
                                            minStart = i; minEnd = j;
                                        }
                                        break;
                                    }
                                }
                                else
                                    tempCharHash[str[j]]--;
                            }
                            else restCount++;
                        }
                    }
                }
                return new int[] { minStart, minEnd };
            }

        }
        class SuffixTreeNode
        {
            char value;
            Dictionary<char, SuffixTreeNode> children = new Dictionary<char, SuffixTreeNode>();
            List<int> indexes = new List<int>();
            
            public void InsertString(string s, int index)
            {
                indexes.Add(index);
                if (s != null && s.Length != 0)
                {
                    value = s[0];
                    SuffixTreeNode child = null;
                    if (children.ContainsKey(value))
                    {
                        child = children[value];
                    }
                    else
                    {
                        child = new SuffixTreeNode();
                        children.Add(value, child);
                    }
                    string remainder = s.Substring(1);
                    child.InsertString(remainder, index);
                }
            }

            public List<int> GetIndexes(string s)
            {
                if (s == null || s.Length == 0)
                    return indexes;
                else
                {
                    char first = s[0];
                    if (children.ContainsKey(first))
                    {
                        string remainder = s.Substring(1);
                        return children[first].GetIndexes(remainder);
                    }
                }
                return null;
            }
        }
        public class SuffixTree
        {
            SuffixTreeNode root = new SuffixTreeNode();
            public SuffixTree(string s)
            {
                for (int i = 0; i < s.Length; i++)
                {
                    string suffix = s.Substring(i);
                    root.InsertString(suffix, i);
                }
            }
            public List<int> GetIndexes(string s)
            {
                return root.GetIndexes(s);
            }
        }
    }
