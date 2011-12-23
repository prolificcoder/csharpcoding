using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace Arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            int [,] matrix=new int[3,4]{{20,25,32,67},
                                        {18,23,40,88},
                                        {19,20,26,29}};
            Program p = new Program();
            //p.PrintMatrix(matrix);
            //int[] sorted = p.NArryMerge(matrix);
            //foreach (int item in sorted)
            //    Console.WriteLine(item);
            int [,] zeroMatrix=new int[4,6]{{1,0,1,0,1,0},
                                            {1,1,0,1,0,0},
                                            {1,0,1,1,0,0},
                                            {1,0,0,0,1,0},};
            int[,] sixteenMatrix = new int[4, 4]{{1,2,3,4},
                                                 {5,6,7,8},
                                                 {9,10,11,12},
                                                 {13,14,15,16},};
            int[,] twentyFiveMatrix = new int[, ]{{1,2,3,4,22},
                                                 {5,6,7,8,34},
                                                 {9,10,11,12,56},
                                                 {13,14,15,16,32},            
                                                 {79,714,715,716,732},};
            //Tuple<int,int,int> t =p.MaximumSubMatrix(zeroMatrix);
            //Console.WriteLine("Max of zeros" + t.Item1 + "at" + t.Item2 + "," + t.Item3);
            //p.PrintMatrixSpirally(matrix);

            int[] ar1 = { 11, 22, 33, 66, 100,-100,-100 };
            int[] s2 = { 6, 723,5 };
            int[] ar2 = { 2, 3, 1, 4, 5 };
            int[] ar3 = { 96,96,2, 34, 5, 34, 6,2,5,98,6,631 };
            int[] zeroOnes = { 0, 0, 0, 0,0,1, 1, 1, 1, 1 };
            int[] ar4 = { -5, 8, 22, 15, 13,0 };
            int[] ar5 = { 3,4,6,7,8,9,10 };
            int[] ar6 = { 8, -5, 4, 3, -1, -2, 2, 1 };
            int[] ar7 = { 2,-2,3,1,-4};
            int[] ar8 = { 1, 1, 1, 2, 2, 3, 4, 4, 4,4,4 };

            Console.WriteLine(p.InflextionPoint(zeroOnes));

            //int[] sorted = p.SortedMerge(s2, ar1);
            //foreach (var item in sorted)
            //    Console.WriteLine(item);

            //Console.WriteLine(p.NNumberOfElementsExist(ar8, 3));
            //int[] ar = p.RemoveDuplicatesSortedArray(ar8);
            //Tuple<int,int,int> t=p.SumOfSquaresInArray(ar5);
            //Console.WriteLine(t.Item1.ToString() + " " + t.Item2.ToString() + " " + t.Item3.ToString());
            // int[] ar = p.SubArrayLessOrEqualToKey(ar4, 20);
           // Console.WriteLine(p.MaxSubSequenceSum(ar5));
            //Tuple<int, int?> t = p.MaxAndSecondMax(ar3);
            //Console.WriteLine(t.Item1.ToString()+ " "+ t.Item2.ToString());
            //int[] ar = p.MaxAndSecondMax(zeroOnes);
           // ar3 = p.Rotate(ar1, 3);
            //p.ReArrangeArray(zeroOnes);
            //Console.WriteLine(p.ExistsOrLesser(ar1, 4));
            //p.Rotate(ar1, 3);
            //Console.WriteLine(p.FirstRepeatingElement(ar3,34+1));
            //Console.WriteLine(p.FindElementNotPresent(ar2, ar1));
            //int[,] rMatrix=p.RotateMatrix(matrix);
            //p.PrintMatrix(rMatrix);
            //int[] ar = p.ProductOfArray(ar3, ar2);
            //int[] ar=p.RemoveDuplicates(ar3);
            //if (ar == null) Console.WriteLine("no subarray");
            //else 
            

        }
        //Assuming no duplicates otherwise we have to repeat the logic once more
        int? InflextionPoint(int[]ar)
        {
            
            if (ar == null || ar.Length < 3) return null;
            int compareResult = ar[0].CompareTo(ar[1]);
            for (int i = 1; i < ar.Length-1; i++)
            {
                if (ar[i].CompareTo(ar[i + 1]) != compareResult)
                    return i + 1;
            }
            return null;
        }

        int[] SortedMerge(int[] ar1,int[] ar2)
        {
            if (ar1 == null || ar1.Length == 0) return ar2;
            if (ar2 == null || ar2.Length == 0) return ar1;
            if (ar1.Length < ar2.Length) { int[] temp = ar1; ar1 = ar2; ar2 = temp; }

            int end = ar1.Length-ar2.Length;
            int index1 = 0, index2 = 0;
            while (index1 < end && index2 < ar2.Length)
            {
                if (ar1[index1] <= ar2[index2])
                    index1++;
                else
                {
                    //Creating space at first spot
                    //end should never cross the array bound because we knew 
                    // we have place for elements at the end
                    while (end != index1)
                    {
                        ar1[end] = ar1[end-1];
                        end--;
                    }
                    ar1[index1] = ar2[index2];
                    index2++;
                    //Restarting end index
                    end = ar1.Length - ar2.Length + index2;
                }
            }
            while (end < ar1.Length)
            {
                ar1[end++] = ar2[index2++];
            }
            return ar1;
        }



        bool NNumberOfElementsExist(int[] ar, int n)
        {
            if (ar == null || ar.Length == 0)
                return false;
            int itemCount = 1;
            int item=ar[0];
            for (int i = 1; i < ar.Length; i++)
            {
                if (n <= itemCount)
                    return true;
                if (item == ar[i])
                    itemCount++;
                else
                {
                    item = ar[i];
                    itemCount = 1;
                }
            }
            return n <= itemCount;
        }

        int[] RemoveDuplicatesSortedArray(int[] ar)
        {
            if (ar == null || ar.Length < 2) return ar;
            int item=ar[0];
            BitArray ba = new BitArray(ar.Length);
            int index = 0;
            for (int i = 1; i < ar.Length; i++)
            {
                if (item == ar[i])
                {
                    ba[i] = true;
                    index++;
                }
                else
                    item = ar[i];
            }
            int[] uniqueArray = new int[ar.Length-index];
            index = 0;
            for (int i = 0; i < ar.Length; i++)
            {
                if(ba[i]==false)
                    uniqueArray[index++] = ar[i];
            }
            return uniqueArray;
        }


        int[] SpliceAddingToZero(int[] ar)
        {
            if (ar == null || ar.Length < 2) return ar;
            int[] counts=new int[ar.Length];
            int sum=0;
            for(int i=0;i<ar.Length;i++)
            {
                sum=sum+ar[i];
                counts[i]=sum;
            }
            Dictionary<int,int> countIndex=new Dictionary<int,int>();
            for(int i=0;i<counts.Length;i++)
            {
                if(counts[i]==0 && i>0)
                {
                  return ar.Take(i+1).ToArray();
                }
                //If the countIndex already has an element of the same counts
                //it means that we can form a zero starting from previous clashed 
                //count to this count
                if (countIndex.ContainsKey(counts[i]))
                {
                    int clashedCount = counts[i];
                    int firstIndex= countIndex[counts[i]]+1;
                    int numElementsInSubArray = i - countIndex[counts[i]];
                    return ar.Skip(firstIndex).Take(numElementsInSubArray).ToArray();
                }
                else
                    countIndex.Add(counts[i], i);
            }
            return null;
        }
        /*Test cases
         * [2,3,-1,2,-4]    [3,-1,2,-4]
         * [0,-3,3,2]       [0,-3,3]  starting with zero
         * [1,2,-3]         [1,2,-3] whole array
         * [2,3,-4]         null     nothing
         * [8,-5,4,3,1,-2,2,1]  [3,1,-2]  multiple slices first should return
         * [-1,-2,-3]      null  all negative
         * all positive
         * [2,-2,3,-1,-2] [2,-2] first two
         * null array 0, 1 array
         * 
         */ 
                 

        Tuple<int,int,int> SumOfSquaresInArray(int[] ar)
        {
            if (ar == null || ar.Length < 4) return null;
            Tuple<int, int, int> t=null;
            int end = ar.Length - 1;
            for (int start = 0; start < ar.Length - 3; start++)
            {
                int second = start + 1;
                while (second < end)
                {
                    if (ar[start] * ar[start] + ar[second] * ar[second] == ar[end] * ar[end])
                        return new Tuple<int, int, int>(ar[start], ar[second], ar[end]);
                    else if (ar[start] * ar[start] + ar[second] * ar[second] < ar[end] * ar[end])
                        second++;
                    else if (ar[start] * ar[start] + ar[second] * ar[second] > ar[end] * ar[end])
                        end--;
                }
            }
           return t;
        }

       

        void FindSquares()
        {
            int limit=100;
            for (int i = 1; i < limit; i++)
                for (int j = 1; j < limit; j++)
                    for (int k = 1; k < limit; k++)
                        if (i * i + j * j == k * k && (i<j && j<k))
                            Console.WriteLine(i+" "+ j+ " "+ k);
        }

        int MaxSubSequenceSum(int[] ar)
        {
            if (ar == null || ar.Length==0) return 0;
            int maxSoFar = 0;
            int maxEndingHere = 0;
            foreach (int item in ar)
            {
                maxEndingHere = Math.Max(maxEndingHere + item, 0);
                maxSoFar = Math.Max(maxSoFar, maxEndingHere);
            }
            return maxSoFar;
        }

        int[] SubArrayLessOrEqualToKey(int[] ar, int key)
        {
            if (ar == null) return null;
            //if (ar.Length == 0 && key == 0) return ar;
            if (ar.Length == 0 && key != 0) return null;
            Array.Sort(ar);
            int count = ar.Length - 1;
            while (count!=0)
            {
                int[] ar2=new int[count];
                Array.Copy(ar, ar2, count);
                int sum = ar2.Sum();
                if (ar2.Sum() <= key)
                    return ar2;
                count--;
            }
            return null;
        }

        bool TwoValuesSumToKeyExist(int[] ar, int key)
        {
            if (ar == null || ar.Length < 2) return false;
            Array.Sort(ar);
            int start = 0, end = ar.Length - 1;
            while (start < end)
            {
                int sum=ar[start] + ar[end];
                if (sum == key)
                    return true;
                else if (sum < key)
                    start++;
                else
                    end--;
            }
            return false;
        }

        Tuple<int,int?> MaxAndSecondMax(int[] ar)
        {
            if (ar == null || ar.Length == 0) return null;
            if (ar.Length == 1) return new Tuple<int, int?>(ar[0], null);
            int max,secondMax;
            if (ar[0] > ar[1])
            {
                max = ar[0];
                secondMax = ar[1];
            }
            else
            {
                max = ar[1];
                secondMax = ar[0];
            }
            foreach (int item in ar.Skip(2))
            {
                if (item > secondMax)
                {
                    if (item > max)
                    {
                        secondMax = max;
                        max = item;
                    }
                    else
                        secondMax = item;
                }
            }
            return new Tuple<int, int?>(max, secondMax);
        }

        int[] ArrangeZerosInEvenOnesInOdd(int[] ar)
        {
            if (ar == null || ar.Length == 0) return ar;
            int onePtr = 0, zeroPtr = 0;
            while (onePtr < ar.Length && zeroPtr < ar.Length)
            {
                while (onePtr < ar.Length)
                {
                    if (ar[onePtr] != 1)
                       onePtr++;
                    else if((onePtr % 2) == 0)
                        break;
                    else
                        onePtr++;
                }
                while (zeroPtr < ar.Length)
                {
                    if (ar[zeroPtr] != 0)
                        zeroPtr++;
                    else if ((zeroPtr % 2) != 0)
                        break;
                    else
                        zeroPtr++;
                }
                if(onePtr<ar.Length && zeroPtr<ar.Length)
                    Swap(ar, onePtr++, zeroPtr++);
            }
            return ar;
        }

        IEnumerable<int[]> ReturnIntegersMoreThanKTimes(int[] ar,int k)
        {
            var query = from numbers in ar
                        group numbers by numbers into grouped
                        where grouped.Count() >= k
                        select grouped.ToArray();
            return query;
           
        }

        void ReArrangeArray(int [] ar)
        {
            if (ar.Length <2)
                return ;
            int mid = ar.Length / 2;
            for (int i = 1; i <= ar.Length/2; i=i+2,mid=mid+2)
            {
                Swap(ar, i , mid );
            }
        }

        private void Swap(int[] ar, int m, int n)
        {
            int temp = ar[m];
            ar[m] = ar[n];
            ar[n] = temp;
        }

        int? ExistsOrLesser(int[] ar, int item)
        {
            if(ar==null||ar.Length==0)
                return null;
            int? small = null;
            for (int i = 0; i < ar.Length; i++)
                if (ar[i] == item)
                    return item;
                else if (small == null && ar[i] < item)
                    small = ar[i];
            return small;
        }

        int[] Rotate(int[] ar,int k)
        {
            if (k <= 0 || k > ar.Length - 1)
                return ar;
            //Reverse(ar, 0, k - 1);
            //Reverse(ar, k, ar.Length - 1);
            //Reverse(ar, 0, ar.Length - 1);
            //return ar;
            return ar.Skip(k)            // Start with the last elements
            .Concat(ar.Take(k))          // Then the first elements
            .ToArray();                 // Then make it an array
        }
        
        void Reverse(int[] ar,int start, int end)
        {
            while (start < end)
            {
                int temp = ar[start];
                ar[start] = ar[end];
                ar[end] = temp;
                start++;
                end--;
            }
        }

        int? FirstRepeatingElement(int[] ar, int maxRange)
        {
            BitArray bv = new BitArray(maxRange);
            for (int i = 0; i < ar.Length; i++)
            {
                if (bv[ar[i]] == true)
                    return ar[i];
                else 
                    bv[ar[i]] = true;
            }
            return null;
        }

        private int[] ProductOfArray(int[] ar1, int[] ar2)
        {
            int prod=1;
            for (int i = 0; i < ar2.Length; i++)
                prod = prod * ar2[i];
            for (int i = 0; i < ar1.Length; i++)
                ar1[i] = ar1[i] * prod;
            for (int i = 0; i < ar1.Length; i++)
                ar1[i] = ar1[i] / ar2[i];
            return ar1;
        }

        public int[] RemoveDuplicates(int[] ar)
        {
            //If array length is 1 or zero there could be no duplicates  
            if (ar.Length < 2) return ar;
            int size = ar.Length - 1;
            for (int i = 0; i < size; i++)
                for (int j = i + 1; j <= size; j++)
                    if (ar[i] == ar[j])
                    {
                        /**
                         * If duplicate found 
                         *       1)swap with the last element
                         *       2)reduce the artificial size of the array
                         *   3)Restart verification from the swapped element
                         */
                        int temp = ar[j];
                        ar[j] = ar[size];
                        ar[size] = temp;
                        size--;
                        j--;
                    }
            
             int[] ar2 = new int[size + 1];
             Array.Copy(ar, ar2, size + 1);
             return ar2;
        }
        int[,] RotateMatrix(int[,] matrix)
        {
            int[,] newMatrix=new int[matrix.GetLength(1),matrix.GetLength(0)];
            for (int i = 0; i < matrix.GetLength(0); i++)
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    newMatrix[j,i] = matrix[i,j];
                }
            return newMatrix;                        
        }

        int? FindElementNotPresent(int[] ar2, int[] ar1)
        {
            if (ar2.Length == 0 ||ar1.Length==0)
                return null;
            for (int i = 0; i < ar1.Length; i++)
            {
                int j=0;
                while (j < ar2.Length)
                {
                    if (ar1[i] == ar2[j])
                        break;
                    j++;
                }
                if (j == ar2.Length)
                    return ar1[i];
            }
            return null;
        }

        private void PrintMatrixSpirally(int[,] sixteenMatrix)
        {
            int maxR =sixteenMatrix.GetLength(0)-1;
            int minR = 0;
            int maxC = sixteenMatrix.GetLength(1) - 1;
            int minC = 0;
            while (true)
            {
                if ((minR <= maxR) && (minC <= maxC))
                {
                    PrintStint(sixteenMatrix, minR++, maxR--, minC++, maxC--);
                }
                else if ((minR <= maxR))
                {
                    PrintStint(sixteenMatrix, minR++, maxR--, minC, maxC);
                }
                else if ((minC <= maxC))
                {
                    PrintStint(sixteenMatrix, minR, maxR, minC++, maxC--);
                }
                else
                    break;
                
            }
        }

        private void PrintStint(int[,] sixteenMatrix, int minR, int maxR, int minC, int maxC)
        {
            for (int i = minC; i <= maxC; i++)
                Console.WriteLine(sixteenMatrix[minR,i]);
            for (int i = minR+1; i <= maxR; i++)
                Console.WriteLine(sixteenMatrix[i, maxC]);
            for (int i = maxC-1; i >= minC; i--)
                Console.WriteLine(sixteenMatrix[maxR, i]);
            for (int i = maxR-1; i > minR; i--)
                Console.WriteLine(sixteenMatrix[i, minC]);
        }

        Tuple<int,int,int> MaximumSubMatrix(int[,] matrix)
        {
            Tuple<int,int,int> max=new Tuple<int,int,int>(0,0,0);
            for (int i = 0; i < matrix.GetLength(0); i++)
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] == 0 )
                    {
                        int count=FindAdjacentZeroCount(matrix, i, j);
                        if (max.Item1 < count)
                        {
                            max = new Tuple<int, int, int>(count, i, j);
                        }
                    }
                }
            return max;
        }

        private int FindAdjacentZeroCount(int[,] matrix, int i, int j)
        {
          if( (i<0 || i>=matrix.GetLength(0)) || (j<0 || j>=matrix.GetLength(1) || matrix[i,j]!=0))
              return 0;
          else 
              return 1+FindAdjacentZeroCount(matrix,i-1,j)+FindAdjacentZeroCount(matrix,i+1,j)+
                  FindAdjacentZeroCount(matrix,i,j-1)+FindAdjacentZeroCount(matrix,i,j+1);
        }
        int[] NArryMerge(int[,] matrix)
        {
            int[] output = new int[matrix.GetLength(0) * matrix.GetLength(1)];
            int[] indexes = new int[matrix.GetLength(0)];
            int count=0;
            for (int i = 0; i < matrix.GetLength(0); i++)
                for (int j = 0; j < matrix.GetLength(1); j++)
                    output[count++] = GetMinimum(ref indexes, matrix);
            return output;
        }

         int GetMinimum(ref int[] indexes, int[,] matrix)
        {
            int min = FirstUnusedElement(indexes, matrix);
            int pos = 0;
            for (int i = 0; i < indexes.Length; i++)
            {
                if (indexes[i] < matrix.GetLength(1) && matrix[i, indexes[i]] < min)
                {
                    min = matrix[i, indexes[i]];
                    pos = i;
                }                
            }
            indexes[pos]++;
            return min;
        }
         int FirstUnusedElement(int[] indexes, int[,] matrix)
        {
            for (int i = 0; i < indexes.Length; i++)
                if (indexes[i] < matrix.GetLength(1))
                    return matrix[i,indexes[i]];
            return matrix[matrix.GetLength(0)-1, matrix.GetLength(1)-1];
        }

        void PrintMatrix(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
                for (int j = 0; j < matrix.GetLength(1); j++)
                    Console.WriteLine(matrix[i,j]);
        }
    }
    
}
