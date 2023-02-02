using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    internal static class ClassicUtils
    {
        #region ReverseString
        public static string ReverseString(string str)
        {
            StringBuilder s = new StringBuilder();

            for (int i = str.Length-1; i >=0 ; i--)
            {
                s.Append(str[i]);
            }

            return s.ToString();
        }

        public static string ReverseString2(string str)
        {
            var arrayChar = str.ToCharArray();

            for (int i = 0; i <= str.Length/2; i++)
            {
                arrayChar[i] = str[str.Length - 1 - i];
                arrayChar[str.Length - 1 - i] = str[i];
            }

            return new string(arrayChar);
        }

        #endregion

        #region Palindrome
        internal static bool IsPalindrome(string str)
        {
            for (int i = 0; i <= str.Length/2; i++)
            {
                if (str[i] != str[str.Length-1 - i])
                    return false;
            }

            return true;
        }
        #endregion

        #region RemoveDuplicateCharacters
        internal static string RemoveDuplicateCharacters(string str)
        {
            Dictionary<char, int> dict = new Dictionary<char, int>();
            StringBuilder result = new StringBuilder();

            for (int i = 0; i < str.Length; i++)
            {
                var character = str[i];

                if (!dict.ContainsKey(character))
                {
                    dict.Add(character, 1);
                    result.Append(character);
                }
            }

            return result.ToString();
        }
        internal static string RemoveDuplicateCharacters2(string str)
        {            
            StringBuilder result = new StringBuilder();

            for (int i = 0; i < str.Length; i++)
            {
                var character = str[i];

                if (!result.ToString().Contains(character))
                {
                    result.Append(character);
                }
            }

            return result.ToString();
        }

        #endregion

        #region Substrings
        internal static List<string> FindAllSubstrings(string str)
        {
            List<string> result = new List<string>();

            for (int i = 0; i < str.Length; i++)
            {
                result.Add(str.ElementAt(i).ToString());

                for (int j = i+1; j < str.Length; j++)
                {
                    result.Add(str.Substring(i, j-i+1));
                }
            }

            return result;
        }
        #endregion

        internal static int[] RotateLeft(int[] array, int numberOfRotations)
        {
            numberOfRotations = numberOfRotations % array.Length;

            for (int i = 0; i < numberOfRotations; i++)
            {
                array = RotateArray(array);
            }

            return array;
        }

        private static int[] RotateArray(int[] array)
        {
            var result = array.Skip(1).Take(array.Length - 1).ToList();
            result.Add(array[0]);

            return result.ToArray();
        }

        internal static void CribaErastotenes(int n)
        {
            bool[] isPrime = new bool[n + 1];
            for (int i = 0; i <= n; i++)
            {
                isPrime[i] = true;
            }

            for (int p = 2; p < Math.Sqrt(n); p++)
            {
                if (isPrime[p])
                {                   
                    for (int i = 2; p * i <= n; i++)
                    {
                        isPrime[p * i] = false;
                    }
                }
            }

            for (int p = 2; p <= n; p++)
            {
                if (isPrime[p])
                {
                    Console.Write(p + " ");
                }
            }
        }

        internal static bool IsPrime(int n)
        {
            if (n % 2 == 0)
                return false;

            for (int i = 3; i <= Math.Sqrt(n); i+=2)
            {
                if (n % i == 0)
                    return false;
            }

            return true;
        }
    }
}
