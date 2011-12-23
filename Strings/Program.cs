using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Strings
{
    enum Direction
    {
        NW=1,
        N=2
        //NE,
        //W,
        //SW,
        //S,
        //SE,
        //E,
    }
    class Program
    {
        static void Main(string[] args)
        {
            Program p=new Program();
            string sentence1 = "this is a new sentence this";
            string sentence2 = "this sentence has very few this words sis";
            //List<string> commonWords=p.FindCommonWords(sentence1,sentence2);
            //foreach (string str in commonWords)
               // Console.WriteLine(str);
            //Console.WriteLine(p.IsAnagram("tsih".ToCharArray(), "this".ToCharArray()));
            //List<string> dictionary = p.GetDictionaryWords();
            //Console.WriteLine(dictionary.Count);
            //Dictionary<string, List<string>> ana = p.FindAnagrams(dictionary);
            //Console.WriteLine(ana.Count);
            //FileStream fs = File.Create("anagrams.txt");
            //TextWriter tw= new StreamWriter(fs);
            //foreach (var sortedWord in ana.Keys)
            //{
            //    foreach (var word in ana[sortedWord])
            //        tw.Write(word+ " ");
            //    tw.WriteLine();
            //}
            string splitString = "abcdabd";
            string delims = "abde";
            //List<string> splits = p.Split(splitString, delims);
         //   foreach (string str in splits)
           //     Console.WriteLine(str);
           // Console.WriteLine(p.UniqueCharacters(splitString));
           // Console.WriteLine(p.Contains(splitString, delims));
           // Console.WriteLine(p.RemoveWordsNotStartingWithCharC("sa saa sa jit sa", 's'));
            //Console.WriteLine(p.CharPresentInStringWithDistanceD("bacddcabd",'b','d',1));
            //string gString = "{((ab)){{cd}}}(((";
            //Console.WriteLine(p.MaxTimesCharacterRepeated(gString));
            string chars = "this is a train";
            //List<string> dictionary = p.GetDictionaryWords();
            //List<string> words=p.FindAllWordsInString(chars,dictionary);
            //foreach (string str in words)
              //  Console.WriteLine(str);
            Console.WriteLine(p.ReverseWords(chars.ToCharArray()));
        }
        string TrimSpacesBetweenWords(string str)
        {
            if (str == null || str.Length == 0) return str;
            int index = 0;
            StringBuilder sb = new StringBuilder();
            while (index < str.Length)
            {
                while (index < str.Length && str[index] != ' ')
                {
                    sb.Append(str[index]);
                    index++;
                }
                sb.Append(' ');
                while (index < str.Length && str[index] == ' ')
                    index++;
            }
            return sb.ToString();
        }

        List<string> FindAllWordsInString(string str, List<string> dictionary)
        {
            List<string> strs = new List<string>();
            int start = 0, end = str.Length;
            while (start < end)
            {
                for (int i = start; i < end; i++)
                {
                    string curStr = str.Substring(i, end - i);
                    if (dictionary.Contains(curStr))
                        strs.Add(curStr);
                }
                end--;
            }
            return strs;
        }


        bool FindInCrossWord(char[,] crossword, char[] word)
        {
            if (crossword == null || word == null) return false;
            if (crossword.GetLength(0) == 0 || crossword.GetLength(1) == 0) return false;
            if (word.Length == 0) return true;
            bool found = false;
            for(int i=0;i<crossword.GetLength(0);i++)
                for(int j=0;i<crossword.GetLength(1);j++)
                    if (crossword[i, j] == word[0])
                    {
                         found |=SearchForWordInAllDirections(crossword,i,j, word);
                         if (found == true)
                             return found;
                    }
            return found;
        }

        private bool SearchForWordInAllDirections(char[,] crossword, int i, int j, char[] word)
        {
            bool found = false;
            if (i - 1 > 0 && j - 1 > 0 && crossword[i-1,j-i]==word[1])
                found |= SearchForWord(Direction.NW, crossword, word);
            return found;
        }

        private bool SearchForWord(Direction direction, char[,] crossword, char[] word)
        {
            return false;
        }



        int MaxTimesCharacterRepeated(string str)
        {
            Dictionary<char,int> charCount= new Dictionary<char,int>();
            foreach (char c in str)
            {
                if (charCount.ContainsKey(c))
                    charCount[c]++;
                else
                    charCount.Add(c, 1);
            }
            return charCount.Values.Max();
        }

        bool ValidateBraces(string str)
        {
            if (str == null || str.Length == 0)
                return true;
            Stack<char> st = new Stack<char>();
            foreach (char c in str)
            {
                if (IsLeftBrace(c))
                    st.Push(c);
                else if (IsRightBrace(c))
                {
                    if (st.Count != 0)
                    {
                        char top = st.Pop();
                        if (!IsMatchingBrace(c, top))
                            return false;
                    }
                    else 
                        return false;
                }
            }
            return st.Count == 0;
        }

        private bool IsMatchingBrace(char c, char top)
        {
            if (c == '}' && top == '{')
                return true;
            else if (c == ')' && top == '(')
                return true;
            return false;
        }
        private bool IsLeftBrace(char c)
        {
            return c == '{' || c == '(';
        }
        private bool IsRightBrace(char c)
        {
            return c == '}' || c == ')';
        }

        //int Compare(char[] str1, char[] str2)
        //{
        //    try{
        //    if (str1.Length == 0 && str2.Length == 0)
        //        return 0;
        //    int index1 = 0, index2 = 0;
        //    while (index1 < str1.Length && index2 < str2.Length)
        //    {
        //        if (Math.Abs(str1[index1] - str2[index2]) == 32)
        //            if (str1[index1] < str2[index2])
        //                str1[index1] = str1[index1];
        //            else
        //                str2[index1] = str2[index1] + 32;
        //    }
            
        //    }
        //    catch(ArgumentNullException at)
        //    {
        //        throw at;
        //    }
        //}


        bool CharPresentInStringWithDistanceD(string str, char a, char b, int d)
        {
            int ptr1 = 0, ptr2 = 0;
            while (true)
            {
                while (ptr1 < str.Length && str[ptr1] != a)
                    ptr1++;
                while (ptr2 < str.Length && str[ptr2] != b)
                    ptr2++;
                if (ptr1 == str.Length || ptr2 == str.Length)
                    return false;
                else if (Math.Abs(ptr1 - ptr2) <= d)
                    return true;
                else if (ptr1 < ptr2)
                    ptr1++;
                else
                    ptr2++;
            }
        }

        bool IsPalindrome (string str)
        {
            if (str == null) return false;
            if (str.Length < 2) return true;
            int start = 0, end = str.Length - 1;
            while (start < end)
            {
                if (str[start++] != str[end--])
                    return false;
            }
            return true;
        }

        string RemoveWordsNotStartingWithCharC(string str, char c)
        {
            if (str == null || str.Length == 0) return str;
            StringBuilder sb = new StringBuilder();
            int start = 0, end = 0;
            while (end < str.Length)
            {
                while (end < str.Length && str[end] != ' ')
                    end++;
                if (str[start] != c)
                    sb.Append(str.Substring(start, end - start+1));
                start = end + 1;
                end = start;
            }
            return sb.ToString();
        }

        bool Contains(string bigstr, string str)
        {
            if (bigstr == null || str==null ||bigstr.Length==0) return false;
            if (str.Length == 0) return true;
            if (str.Length > bigstr.Length) return false;
            for (int i = 0; i < bigstr.Length; i++)
            {
                if (bigstr[i] == str[0])
                {
                    int indexBigStr=i;
                    int indexStr = 0;
                    while (indexStr<str.Length && indexBigStr<bigstr.Length && bigstr[indexBigStr] == str[indexStr])
                    {
                        indexStr++;
                        indexBigStr++;
                    }
                    if (indexStr == str.Length)
                        return true;
                }
            }
            return false;
        }
        
        string UniqueCharacters(string str)
        {
            HashSet<char> uniques = new HashSet<char>();
            StringBuilder sb = new StringBuilder();
            foreach (char c in str)
                if (!uniques.Contains(c))
                {
                    sb.Append(c);
                    uniques.Add(c);
                }
            return sb.ToString();
        }
        List<string> Split(string str, string delimeters)
        {
            if (str == null) return null;
            if (str.Length == 0 ||delimeters==null || delimeters.Length==0) return new List<string> { str };
            List<string> strs = new List<string>();
            HashSet<char> delims = new HashSet<char>(delimeters);
            int start = 0, end = 0;
            while (end < str.Length)
            {
                while (end < str.Length && !delims.Contains(str[end]))
                    end++;
                if(start!=end)
                    strs.Add(str.Substring(start,end-start));
                start = end + 1;
                end = start;
                    
            }
            return strs;
        }

        List<string> GetDictionaryWords()
        {
            string path = @"C:\Users\satyajit\Documents\Visual Studio 2010\Projects\CareerCupProblems\Strings\dictionary.txt";
            List<string> words = new List<string>();
            string line;
            using (FileStream fs = File.OpenRead(path)) 
            using (TextReader reader = new StreamReader(fs))
            {
                while ((line = reader.ReadLine()) != null)
                    words.Add(line);
            }
            return words;
        }

        //Assuming the only delimeter is space
        //Also assuming case sensitivity in strings 
        //this != this? != tHis
        List<string> FindCommonWords(string sentence1, string sentence2)
        {
            if (sentence1.Length == 0 || sentence2.Length == 0)
                return null;
            List<string> commonWords = new List<string>();
            string[] strArr1 = sentence1.Split();
            Dictionary<string, int> strMap = new Dictionary<string, int>();
            foreach (string str in strArr1)
            {
                if (strMap.ContainsKey(str))
                    strMap[str]++;
                else
                    strMap.Add(str, 1);
            }
            string[] strArr2 = sentence2.Split();
            foreach (string str in strArr2)
            {
                if (strMap.ContainsKey(str))
                {
                    commonWords.Add(str);
                    if (strMap[str] > 1)
                        strMap[str]--;
                    else
                        strMap.Remove(str);
                }
            }
            return commonWords;
        }

        string LongestReapeatedSubString(string str)
        {
            int pos = 0;
            int maxCount = 0;
            for (int i = 0; i < str.Length; i++)
            {
                for(int j=i+1;j<str.Length;j++)
                    if (str[i] == str[j])
                    {
                        int count = GetMatchCount(str, i, j);
                        if (maxCount < count)
                        {
                            maxCount = count;
                            pos = i;
                        }
                    }
            }
            return new string(str.ToCharArray(),pos,maxCount);
        }
        private int GetMatchCount(string str, int index1, int index2)
        {
            int count = 0;
            while (index2 < str.Length && index1 < str.Length && str[index1] == str[index2])
            {
                count++; 
                index1++;
                index2++;
            }
            return count;
        }
        //Assume that string is \n terminated
        //So godzilla is of length 10 adding \n
        char[] ReverseCString(string str)
        {
            if (str.Length < 1) return null;
            char[] charArray = str.ToCharArray();
            int start = 0;
            int end = str.Length - 2;//extra 2 for \ and n characters
            while (start < end)
            {
                char temp = charArray[start];
                charArray[start] = charArray[end];
                charArray[end] = temp;
                start++; end--;
            }
            return charArray;
        }
        char[] ReverseWords(char[] str)
        {
            if (str == null) throw new ArgumentNullException();
            if (str.Length < 2) return str;
            int start = 0, end = 0;
            Reverse(str, 0, str.Length-1);
            while (end < str.Length)
            {
                while (end < str.Length && str[end] != ' ')
                    end++;
                Reverse(str, start, end - 1);
                end++;
                start = end;
            }
            return str;
        }

        //Reverse words based on space delimeter
        char[] ReverseWords2nd(string str)
        {
            int start = -1, end = -1, wordFound = 0;
            char[] charArray=str.ToCharArray();
             Reverse(charArray,0,str.Length-1);
            for(int i=0;i<charArray.Length;i++)
            {
                if(charArray[i] != ' ' &&wordFound==0)
                {
                    start=i;
                    wordFound=1;
                }
                //A special check for end of the word
                else if(wordFound==1&&(charArray[i]==' '||i==charArray.Length-1))
                {
                    wordFound=2;
                    end=i-1;
                    if(i==charArray.Length-1)
                        end=i;
                }
                if(wordFound==2)
                {
                    Reverse(charArray,start,end);
                    wordFound=0;
                }
            }
            return charArray;
        }
        char[] Reverse(char[] charArray,int start,int end)
        {
            while (start < end)
            {
                char temp = charArray[start];
                charArray[start] = charArray[end];
                charArray[end] = temp;
                start++; end--;
            }
            return charArray;
        }

        bool IsAnagram(char[] str1, char[] str2)
        {
            if (str1.Length != str2.Length)
                return false;
            Array.Sort(str1);
            Array.Sort(str2);
            for (int i = 0; i < str1.Length; i++)
                if (str1[i] != str2[i])
                    return false;
            return true;
        }
        Dictionary<string,List<string>> FindAnagrams(List<string> dictionary)
        {
            Dictionary<string, List<string>> anagrams = new Dictionary<string, List<string>>();
            foreach (string word in dictionary)
            {
                char[] charArray=word.ToCharArray();
                Array.Sort(charArray);
                string sorted=new string(charArray);
                if (anagrams.ContainsKey(sorted))
                    anagrams[sorted].Add(word);
                else
                    anagrams.Add(sorted, new List<string>() { word });
            }
            List<string> nonAnagrams = new List<string>();
            foreach (var sorted in anagrams.Keys)
                if (anagrams[sorted].Count == 1)
                    nonAnagrams.Add(sorted);
            foreach(string word in nonAnagrams)
                anagrams.Remove(word);
           
            return anagrams;
        }

    }
}
