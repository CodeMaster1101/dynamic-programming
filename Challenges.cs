using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace dynamic_programming
{

    internal class Challenges
    {

        //Fibonacci sequence
        internal static int FibonacciSequence(int n, IDictionary<int, int> memo)
        {
            if (n <= 2) return 1;
            if (memo.ContainsKey(n)) return memo[n];
            memo[n] = FibonacciSequence(n - 1, memo) + FibonacciSequence(n - 2, memo);
            return memo[n];
        }

        internal static int TwoDGridLayout(int m, int n, Dictionary<int, int> memo)
        {
            if (m == 0 || n == 0) return 0;
            if (m == 1 && n == 1) return 1;
            memo[n] = TwoDGridLayout(m - 1, n, memo) + TwoDGridLayout(m, n - 1, memo);
            return memo[n];
        }

        internal static bool CanSum(int target, int[] arr, Dictionary<int, bool> memo)
        {
            if (target == 0) return true;
            if (target < 0) return false;
            for (int i = 0; i < arr.Length; i++)
            {
                if (CanSum(target - arr[i], arr, memo))
                {
                    memo[target] = true;
                    return true;
                }
            }
            memo[target] = false;
            return false;
        }

        internal static int[]? HowSum(int target, int[] arr, Dictionary<int, int[]> memo)
        {
            if (memo[target] != null) return memo[target];
            if (target == 0) return new int[arr.Length];
            if (target < 0) return null;

            for (int i = 0; i < arr.Length; i++) 
            {
                int difference = target - arr[i];
                int[]? result = HowSum(difference, arr, memo);
                if (result != null)
                {
                    ResizeArray(ref result, arr[i]);
                    memo[target] = result;
                    return memo[target];
                }
            }
            return null;
        }

        internal static int[]? BestSum(int target, int[] arr, Dictionary<int, int[]> memo)
        {
            if (memo[target] != null) return memo[target];
            if (target == 0) return new int[1];
            if (target < 0) return null;

            int[]? shortestCombination = null;

            for (int i = 0; i < arr.Length; i++)
            {
                int currentNum = arr[i];
                int diff = target - currentNum;
                 var result = BestSum(diff, arr, memo);
                if (result != null)
                {
                    ResizeArray(ref result, currentNum);
                    if (shortestCombination == null 
                        || result.Length < shortestCombination.Length)
                    {
                        shortestCombination = result;
                    }
                }
            }
            memo[target] = shortestCombination;
            return memo[target];
        }

        internal static bool CanConstruct(string? target, string[] words, Dictionary<string, bool> memo)
        {
            if (target == "") return true;
            if (target == null) return false;
            if (memo.ContainsKey(target)) return memo[target];

            for (int i = 0; i < words.Length;i++)
            {
                string currentWord = words[i];
                string? diff = CalculateDiff(target, currentWord);
                bool result = CanConstruct(diff, words, memo);
                memo[target] = result;
                if (result) return true;
            }
            return false;
        }

        private static string? CalculateDiff(string target, string currentWord)
        {
            string? result = null;
            result = target.Replace(currentWord, string.Empty);
            if (result.Equals(target)) return null;
            return result;
        }

        private static void ResizeArray(ref int[] arr, int num)
        {
            Array.Resize(ref arr, arr.Length + 1);
            arr[arr.Length - 1] = num;
        }

        internal static String PrintArray(int[] array)
        {
            if (array is null) return "null";
            string x = "[";
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] != 0) x += array[i] + " ";
            }
            return x += "]";
        }


    }
}