using System.Windows;
using System.Collections;
using System;
using System.Collections.Generic;

namespace DataStructuresAndAlgorithms
{
    /*
    ===================================================================================================================================================================================================        
    A given array contains series of N numbers from 1 to N in un-sorted order. 
    And only one number is missing and it is replaced with another number which is alredy exists in the array. 

    Find the missing number and the repeated number.

    E.g. 1    3   5   2   7   3   8   10  9   4
    Missing Number is 6
    Repeated Number is 3

    Get the array elements sum and subtract it from actual sum.
    ===================================================================================================================================================================================================
*/
    partial class ArraySamples 
    {        
        public static void FindMissingAndRepeatedNumbersInArray()
        {
            IDictionary HashtableObj = new Hashtable(); 
            int[] inputArr = { 1, 3, 5, 2, 7, 3, 8, 10, 9, 4 };

            int arrayLen = inputArr.Length;
            int arraySum = 0;
            int repeatedNum =0;

            for (int lpCnt = 0; lpCnt < arrayLen; lpCnt++)
            {
                arraySum += inputArr[lpCnt];

                if (!HashtableObj.Contains(inputArr[lpCnt]))
                {
                    HashtableObj.Add(inputArr[lpCnt], inputArr[lpCnt]);
                }
                else
                {
                    repeatedNum = inputArr[lpCnt];
                }
            }

            //Using arithmatic progression logic to find actual sum. And remove the repeated number
            float actualSum = 10 * (1 + 10) / 2;
            float missingNum = actualSum - ( arraySum - repeatedNum) ;

            MessageBox.Show("Missing Number is " + missingNum + Environment.NewLine + "Repeated Number is " + repeatedNum);
        }

        /*
        Given an array of integers where 1 ≤ a[i] ≤ n (n = size of array), some elements appear twice and others appear once.

        Find all the elements of [1, n] inclusive that do not appear in this array.
        Could you do it without extra space and in O(n) runtime? You may assume the returned list does not count as extra space.

        E.g.    Input:  [4,3,2,7,8,2,3,1]
                Output: [5,6]  */

        public IList<int> FindDisappearedNumbers(int[] nums)
        {
            List<int> missingNums = new List<int>();

            if (nums == null || nums.Length == 0)
                return missingNums;

            // Visit array index positions based on the values and mark them as inverse (negative values). 
            // The index positions which doesn't have negatvie values are missing one's.

            for (int index = 0; index < nums.Length; index++)
            {
                // Use Math.Abs so that we get positve number for the numbers which are already visited and marked as negative.
                int absVal = Math.Abs(nums[index]) - 1;

                if (nums[absVal] > 0)
                    nums[absVal] = -nums[absVal];
            }

            //Now findout the positive numbers and consider their index + 1 as the missing numbers.
            for (int index = 0; index < nums.Length; index++)
            {
                if (nums[index] > 0)
                    missingNums.Add(index + 1);
            }

            return missingNums;
        }
    }
}