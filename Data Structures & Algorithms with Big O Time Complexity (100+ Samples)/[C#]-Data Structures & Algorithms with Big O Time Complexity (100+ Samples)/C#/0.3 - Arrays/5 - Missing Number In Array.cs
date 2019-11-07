using System.Windows;

namespace DataStructuresAndAlgorithms
{
    /*
   
    ===================================================================================================================================================================================================

    A given array contains series of N numbers from 1 to N in un-sorted order. 
    And only one number is missing and it is replaced with zero. Find the missing number.

    E.g. 1    3   5   2   7   0   8   10  9   4
    Missing Number is 6
        
        Get the array elements sum and subtract it from actual sum.

    Note: Use arithmetic progression to find the sum of numbers in O(1) Constant time.  n * (n1 + n) / 2

    http://en.wikipedia.org/wiki/Arithmetic_progression
    http://www.careercup.com/question?id=6228501199847424
    
    http://stackoverflow.com/questions/3492302/easy-interview-question-got-harder-given-numbers-1-100-find-the-missing-numbe?rq=1
    http://books.google.com/books?id=415loiMd_c0C&lpg=PP1&dq=muthukrishnan%20data%20stream%20algorithms&hl=el&pg=PA1#v=onepage&q=muthukrishnan%20data%20stream%20algorithms&f=false
    ===================================================================================================================================================================================================
    */
    partial class ArraySamples 
    {
        public static void FindMissingNumberInArray()
        {
            int[] inputArr = { 1, 3, 5, 2, 7, 0, 8, 10, 9, 4 };

            int arrayLen = inputArr.Length;
            int arraySum = 0;

            // O (N) Logic
            for (int lpCnt = 0; lpCnt < arrayLen; lpCnt++)
            {
                arraySum += inputArr[lpCnt];
            }
                     
            // O (N/2) Logic by using heap technique. May not be effcient for small blocks.

            //int num1 = 0;
            //int num2 = 0;
            //int Child1Idx = 0;
            //int Child2Idx = 0;

            //for (int lpCnt = 0; lpCnt < arrayLen/2; lpCnt++)
            //{
            //    Child1Idx = lpCnt * 2;
            //    Child2Idx = Child1Idx + 1;

            //    num1 = inputArr[Child1Idx];
            //    num2 = inputArr[Child2Idx];

            //    arraySum += num1 + num2;
            //}

            //Using arithmatic progression logic to find actual sum.
            int actualSum = 10 * (1 + 10) / 2;
            int missingNum = actualSum - arraySum;

            MessageBox.Show("Missing number is " + missingNum);
        }    
    }
}