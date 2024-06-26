﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Runtime.Remoting.Messaging;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Algorithms
{
    //otro comment
    //comment
    internal class Program
    {
        #region cavityMap
       /*
       * Complete the 'cavityMap' function below.
       *
       * The function is expected to return a STRING_ARRAY.
       * The function accepts STRING_ARRAY grid as parameter.
       */

       private static List<string> CloneList(List<string> grid)
       {
           return Newtonsoft.Json.JsonConvert.DeserializeObject<List<string>>(Newtonsoft.Json.JsonConvert.SerializeObject(grid));
       }
       
       private static bool IsCavity(List<string> grid, int i, int j)
       {
           return grid[i][j] > grid[i - 1][ j] && grid[i][ j] > grid[i + 1][ j] && grid[i][j] > grid[i][ j- 1] &&
                  grid[i][j] > grid[i][ j + 1];
       }
       
       
        public static List<string> cavityMap(List<string> grid)
        {
            var result = CloneList(grid);
            for (int i = 1; i < grid.Count - 1; i++)
            {
                for (int j = 1; j < grid[i].Count() - 1; j++)
                {
                    if (IsCavity(grid, i, j))
                        result[i] = result[i].Substring(0,j) + "X"  + result[i].Substring(j+1, result[i].Length-j-1);
                }
            }

            return result;
        }
        #endregion
        
        #region serviceLane
        /*
         * Complete the 'fairRations' function below.
         *
         * The function is expected to return a STRING.
         * The function accepts INTEGER_ARRAY B as parameter.
         */

        private static bool isEven(int n)
        {
            return n % 2 == 0;
        }

        public static string fairRations(List<int> B)
        {
            int result = 0;
            
            if (B.All(b => isEven(b)))
                return result.ToString();
          
            for (int i = 0; i < B.Count; i++)
            {
                if (!isEven(B[i]))
                {
                    if (i + 1 < B.Count && !isEven(B[i + 1]))
                    {
                        result += 2;
                        B[i]++;
                        B[i+1]++;
                    }
                    else if (i - 1 >= 0 && !isEven(B[i - 1]))
                    {
                        result += 2;
                        B[i]++;
                        B[i-1]++;
                    }
                    else if (i + 1 < B.Count)
                    {
                        result += 2;
                        B[i]++;
                        B[i+1]++;
                    }
                    else
                    {
                        return "NO";
                    }
                }
            }

            return result.ToString();
        }
        #endregion
        
        #region serviceLane
        /*
         * Complete the 'serviceLane' function below.
         *
         * The function is expected to return an INTEGER_ARRAY.
         * The function accepts following parameters:
         *  1. INTEGER n
         *  2. 2D_INTEGER_ARRAY cases
         */

        public static List<int> serviceLane(int n, List<List<int>> cases, List<int> width)
        {
            var result = new List<int>();
            for (int j = 0; j < cases.Count; j++)
            {
                var entry = cases[j][0];
                var exit = cases[j][1];

                var range = width.GetRange(entry, exit - entry +1);
                result.Add(range.Min());
            }

            return result;
        }
        
        #endregion
        
        #region flatlandSpaceStations
        // Complete the flatlandSpaceStations function below.
        static int flatlandSpaceStations(int n, int[] c)
        {
            if (c.Count() == 1)
            {
                return Math.Max(c[0] - 0, n - c[0] -1 );
            }

            c = c.OrderBy(x => x).ToArray();

            int max = c[0], dist = 0;

            for (int i = 0; i < c.Count() - 1; i++)
            {
                dist = (c[i + 1] - c[i]) / 2;
                if (dist > max)
                    max = dist;
            }

            dist = n - c[c.Count() - 1] - 1;

            if (dist > max)
                max = dist;

            return max;

        }
        #endregion

        #region chocolateFeast

        /*
     * Complete the 'chocolateFeast' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts following parameters:
     *  1. INTEGER n
     *  2. INTEGER c
     *  3. INTEGER m
     */

        public static int chocolateFeast(int n, int c, int m)
        {
            int result = n / c;

            int wrappers = result;

            int newChocolates = 0;

            while (wrappers >= m)
            {
                newChocolates = (wrappers / m);
                result += newChocolates;

                wrappers = newChocolates + (wrappers % m);
            }

            return result;
        }

        #endregion

        #region workbook
        /*
    * Complete the 'workbook' function below.
    *
    * The function is expected to return an INTEGER.
    * The function accepts following parameters:
    *  1. INTEGER n
    *  2. INTEGER k
    *  3. INTEGER_ARRAY arr
    */

        public static int workbook(int n, int k, List<int> arr)
        {
            int result = 0;
            int totalPages = 0;
            for (int i = 0; i < arr.Count; i++)
            {
                var problemsNumber = arr[i];

                int pageNumber = 0;
                while (problemsNumber > 0)
                {
                    problemsNumber -= k;

                    pageNumber++;
                    totalPages++;

                    if (totalPages > (k * (pageNumber - 1)) && totalPages <= (problemsNumber >= 0 ? k * pageNumber : problemsNumber + (k * pageNumber)))
                        result++;
                }
            }

            return result;
        }
        #endregion

        #region howManyGames
        /*
     * Complete the 'howManyGames' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts following parameters:
     *  1. INTEGER p
     *  2. INTEGER d
     *  3. INTEGER m
     *  4. INTEGER s
     */

        public static int howManyGames(int topPrice, int discount, int minPrice, int budget)
        {
            // Return the number of games you can buy
            int count = 0;

            while (budget - topPrice >= 0)
            {
                count++;
                budget -= topPrice;
                topPrice -= discount;
                topPrice = Math.Max(topPrice, minPrice);
            }

            return count;
        }

        #endregion

        #region minimumDistances
        /*
    * Complete the 'minimumDistances' function below.
    *
    * The function is expected to return an INTEGER.
    * The function accepts INTEGER_ARRAY a as parameter.
    */

        public static int minimumDistances(List<int> a)
        {
            int minDistance = int.MaxValue;

            for (int i = 0; i < a.Count - 1; i++)
            {
                for (int j = i + 1; j < a.Count && j - i < minDistance; j++)
                {
                    if (a[i] == a[j])
                    {
                        var distance = j - i;

                        if (distance < minDistance)
                            minDistance = distance;
                    }
                }
            }

            return minDistance == int.MaxValue ? -1 : minDistance;
        }

        #endregion

        #region beautifulTriplets
        /*
     * Complete the 'beautifulTriplets' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts following parameters:
     *  1. INTEGER d
     *  2. INTEGER_ARRAY arr
     */

        public static int beautifulTriplets(int d, List<int> arr)
        {
            int count = 0;

            for (int i = 0; i < arr.Count - 2; i++)
                for (int j = i + 1; j < arr.Count - 1; j++)
                    if (arr[j] - arr[i] == d)
                    {
                        for (int k = j + 1; k < arr.Count; k++)
                            if (arr[k] - arr[j] == d)
                                count++;
                    }

            return count;
        }
        #endregion

        #region kaprekarNumbers
        /*
     * Complete the 'kaprekarNumbers' function below.
     *
     * The function accepts following parameters:
     *  1. INTEGER p
     *  2. INTEGER q
     */

        public static void kaprekarNumbers(int p, int q)
        {
            bool anyKraperNumber = false;
            for (int i = p; i <= q; i++)
            {
                if (IsKrapekarNumber(i))
                {
                    anyKraperNumber = true;
                    Console.Write(i + " ");
                }
            }

            if (!anyKraperNumber)
                Console.WriteLine("INVALID RANGE");
        }

        private static bool IsKrapekarNumber(int i)
        {
            var pow = Math.Pow(i, 2);

            string powStr = pow.ToString();

            string firstHalfStr = powStr.Substring(0, powStr.Length / 2);
            double firstHalfNumber = double.Parse(firstHalfStr != "" ? firstHalfStr : "0");

            string secondHalfStr = powStr.Substring(powStr.Length / 2);
            double secondHalfNumber = double.Parse(secondHalfStr != "" ? secondHalfStr : "0");

            return (firstHalfNumber + secondHalfNumber == i);
        }
        #endregion

        #region taumBday
        /*
     * Complete the 'taumBday' function below.
     *
     * The function is expected to return a LONG_INTEGER.
     * The function accepts following parameters:
     *  1. INTEGER b
     *  2. INTEGER w
     *  3. INTEGER bc
     *  4. INTEGER wc
     *  5. INTEGER z
     */

        public static long taumBday(long b, long w, long bc, long wc, long z)
        {
            long buyinBothColors = bc * b + wc * w;
            long buyinOnlyBlackColors = (bc * b) + (bc + z) * w;
            long buyinOnlyWhiteColors = (w * wc) + (wc + z) * b;

            return Math.Min(buyinBothColors, Math.Min(buyinOnlyBlackColors, buyinOnlyWhiteColors));
        }
        #endregion

        #region acmTeam

        /*
    * Complete the 'acmTeam' function below.
    *
    * The function is expected to return an INTEGER_ARRAY.
    * The function accepts STRING_ARRAY topic as parameter.
    */
        public static List<int> acmTeam(List<string> topic)
        {
            int maxSubject = int.MinValue, countMaxSubjects = 0;

            for (int i = 0; i < topic.Count - 1; i++)
            {
                for (int j = i + 1; j < topic.Count; j++)
                {
                    var max = GetMaxSubjectsBetweenTeams(topic[i], topic[j]);

                    if (max > maxSubject)
                    {
                        maxSubject = max;
                        countMaxSubjects = 1;
                    }
                    else if (max == maxSubject)
                    {
                        countMaxSubjects++;
                    }
                }
            }

            return new List<int>() { maxSubject, countMaxSubjects };
        }

        private static int GetMaxSubjectsBetweenTeams(string v1, string v2)
        {
            int result = 0;
            for (int i = 0; i < v1.Length; i++)
            {
                if (v1[i] == '1' || v2[i] == '1')
                    result++;
            }

            return result;
        }

        #endregion

        #region equalizeArray
        /*
     * Complete the 'equalizeArray' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts INTEGER_ARRAY arr as parameter.
     */

        public static int equalizeArray(List<int> arr)
        {
            var dict = arr.GroupBy<int, int>(x => x);
            var maxOcurrenceskeyValue = dict.FirstOrDefault(item => item.Count() == arr.Max(x => arr.Count(i => x == i)));

            return arr.Count - maxOcurrenceskeyValue.Count();
        }

        #endregion


        #region jumpingOnClouds
        /*
     * Complete the 'jumpingOnClouds' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts INTEGER_ARRAY c as parameter.
     */

        public static int jumpingOnClouds(List<int> c)
        {
            return jumpingOnCloudsRec(0, c);
        }

        private static int jumpingOnCloudsRec(int index, List<int> c)
        {
            if (index == c.Count - 1)
                return 0;

            int jumpDouble = int.MaxValue, jumpSimple = int.MaxValue;

            if (index + 2 <= c.Count - 1 && c[index + 2] != 1)
                jumpDouble = 1 + jumpingOnCloudsRec(index + 2, c);

            if (index + 1 <= c.Count - 1 && c[index + 1] != 1)
                jumpSimple = 1 + jumpingOnCloudsRec(index + 1, c);

            return Math.Min(jumpSimple, jumpDouble);
        }
        #endregion
        #region repeatedString
        /*
     * Complete the 'repeatedString' function below.
     *
     * The function is expected to return a LONG_INTEGER.
     * The function accepts following parameters:
     *  1. STRING s
     *  2. LONG_INTEGER n
     */

        public static long repeatedString(string s, long n)
        {
            int lengthStr = s.Length;

            long div = n / lengthStr;
            int mod = (int)(n % lengthStr);

            long countA = s.Count(x => x == 'a') * div;
            countA += s.Substring(0, mod).Count(x => x == 'a');

            return countA;

        }
        #endregion

        #region nonDivisibleSubset (Not resolved)
        /* Complete the 'nonDivisibleSubset' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts following parameters:
     *  1. INTEGER k
     *  2. INTEGER_ARRAY s
     */


        public static int nonDivisibleSubset(int k, List<int> s)
        {
            var combinations = Combinations(s);
            int maxNumber = int.MinValue;

            foreach (var combination in combinations)
            {
                if (AreAllItemsNotEvenlyDivisibleByK(combination, k) && combination.Count > maxNumber)
                {
                    maxNumber = combination.Count;
                }
            }

            return maxNumber;
        }

        private static List<List<int>> Combinations(List<int> source)
        {
            if (null == source)
                throw new ArgumentNullException(nameof(source));


            return Enumerable
              .Range(0, 1 << (source.Count))
              .Select(index => source
                 .Where((v, i) => (index & (1 << i)) != 0)
                 .ToList()).ToList();
        }

        private static bool AreAllItemsNotEvenlyDivisibleByK(List<int> combination, int k)
        {
            if (combination.Count == 1)
                return false;

            for (int i = 0; i < combination.Count - 1; i++)
            {
                for (int j = i + 1; j < combination.Count; j++)
                {
                    if ((combination[i] + combination[j]) % k == 0)
                        return false;
                }
            }

            return true;
        }

        #endregion

        #region cutTheSticks
        /*
     * Complete the 'cutTheSticks' function below.
     *
     * The function is expected to return an INTEGER_ARRAY.
     * The function accepts INTEGER_ARRAY arr as parameter.
     */

        public static List<int> cutTheSticks(List<int> arr)
        {
            List<int> result = new List<int>() { arr.Count };

            while (arr.Count > 1 && arr.Any(a => a != arr[0]))
            {
                arr = arr.Select(a => a - arr.Min()).Where(a => a != 0).ToList();
                result.Add(arr.Count);
            }

            return result;
        }
        #endregion

        #region appendAndDelete
        /*
    * Complete the 'appendAndDelete' function below.
    *
    * The function is expected to return a STRING.
    * The function accepts following parameters:
    *  1. STRING s
    *  2. STRING t
    *  3. INTEGER k
    */

        public static string appendAndDelete(string s, string t, int k)
        {
            return AppendAndDeleteRec(s, t, k) ? "Yes" : "No";
        }

        private static bool AppendAndDeleteRec(string s, string t, int k)
        {
            if (s == t && k == 0)
                return true;

            int i = 0;

            while (i < s.Length && i < t.Length && s[i] == t[i])
            {
                i++;
            }

            if (i < s.Length)
            {
                s = s.Substring(i);
            }
            else
            {
                s = "";
            }

            if (i < t.Length)
            {
                t = t.Substring(i);
            }
            else
            {
                t = "";
            }

            if (s != t)
            {
                k -= (s.Length); //the count of characters that i have to remove of s
                k -= (t.Length); //the count of characters that i have to add of t
            }

            if (k < 0)
                return false;

            if (k % 2 == 0)
                return true;

            k -= 2 * i;

            return (k >= 0);
        }
        #endregion

        #region jumpingOnClouds
        // Complete the jumpingOnClouds function below.
        static int jumpingOnClouds(int[] c, int k)
        {
            int i = 0, total = 100, n = c.Length;
            do
            {
                i = (i + k) % n;
                total -= (c[i] == 0 ? 1 : 3);
            }
            while (i != 0);

            return total;

        }
        #endregion 

        #region permutationEquation
        /*
        * Complete the 'permutationEquation' function below.
        *
        * The function is expected to return an INTEGER_ARRAY.
        * The function accepts INTEGER_ARRAY p as parameter.
        */
        public static List<int> permutationEquation(List<int> p)
        {
            List<int> result = new List<int>();
            for (int i = 0; i < p.Count; i++)
            {
                var indexI = p.IndexOf(i + 1) + 1;
                result.Add(p.IndexOf(indexI) + 1);
            }

            return result;
        }
        #endregion

        #region circularArrayRotation
        /*
    * Complete the 'circularArrayRotation' function below.
    *
    * The function is expected to return an INTEGER_ARRAY.
    * The function accepts following parameters:
    *  1. INTEGER_ARRAY a
    *  2. INTEGER k
    *  3. INTEGER_ARRAY queries
    */

        public static List<int> circularArrayRotation(List<int> a, int k, List<int> queries)
        {
            var times = k % a.Count;

            if (times != 0)
            {
                var first = a.GetRange(a.Count - times, times);
                var second = a.GetRange(0, a.Count - times);
                first.AddRange(second);
                a = first;
            }

            return queries.Select(x => a[x]).ToList();
        }

        public static List<int> circularArrayRotationSlow(List<int> a, int k, List<int> queries)
        {
            for (int i = 0; i < k % a.Count; i++)
            {
                a = GetRotationFast(a);
            }

            return queries.Select(x => a[x]).ToList();
        }

        private static List<int> GetRotationFast(List<int> a)
        {
            return new List<int>() { a[a.Count - 1] }.Union(a.Where((i, x) => i != a.Count - 1)).ToList();
        }

        private static List<int> GetRotation(List<int> a)
        {
            var lastElment = a[a.Count - 1];

            for (int i = a.Count - 1; i > 0; i--)
            {
                a[i] = a[i - 1];
            }

            a[0] = lastElment;

            return a;
        }
        #endregion

        #region saveThePrisoner
        /*
         * Complete the 'saveThePrisoner' function below.
         *
         * The function is expected to return an INTEGER.
         * The function accepts following parameters:
         *  1. INTEGER n : the number of prisoners
         *  2. INTEGER m : the number of sweets
         *  3. INTEGER s : the chair number to start passing out treats at
         */
        static int saveThePrisoner(int n, int m, int s)
        {
            if (s + m - 1 <= n)
            {
                return s + m - 1;
            }

            return (s + m - 1) % n == 0 ? n : (s + m - 1) % n;
        }
        #endregion

        #region viralAdvertising
        /*
    * Complete the 'viralAdvertising' function below.
    *
    * The function is expected to return an INTEGER.
    * The function accepts INTEGER n as parameter.
    */

        public static int viralAdvertising(int n)
        {
            if (n < 0) return 0;

            if (n == 1) return 2;

            int countLikes = 2, shared = 5;

            for (int i = 2; i <= n; i++)
            {
                shared = (shared / 2) * 3;
                countLikes += shared / 2;
            }

            return countLikes;
        }

        #endregion

        #region beautifulDays
        /*
    * Complete the 'beautifulDays' function below.
    *
    * The function is expected to return an INTEGER.
    * The function accepts following parameters:
    *  1. INTEGER i
    *  2. INTEGER j
    *  3. INTEGER k
    */

        public static int beautifulDays(int i, int j, int k)
        {
            int cont = 0;

            for (int n = i; n <= j; n++)
            {
                int reverseN = Reverse(n);

                if (Math.Abs(n - reverseN) % k == 0)
                    cont++;
            }

            return cont;
        }

        public static int beautifulDaysLinq(int i, int j, int k)
        {
            return Enumerable.Range(i, j - i + 1).Count(n => Math.Abs(int.Parse(string.Join("", n.ToString().Reverse())) - n) % k == 0);
        }

        private static int Reverse(int n)
        {
            return int.Parse(string.Join("", n.ToString().Reverse()));
        }

        #endregion

        #region pickingNumbers

        /*
    * Complete the 'pickingNumbers' function below.
    *
    * The function is expected to return an INTEGER.
    * The function accepts INTEGER_ARRAY a as parameter.
    */

        public static int pickingNumbers(List<int> a)
        {
            int maxSubArray = int.MinValue;

            foreach (var item in a.Distinct())
            {
                int subArrayPartPos = a.Count(e => item >= e && Math.Abs(item - e) <= 1);
                int subArrayPartNeg = a.Count(e => item <= e && Math.Abs(item - e) <= 1);
                int max = Math.Max(subArrayPartNeg, subArrayPartPos);

                if (max > maxSubArray)
                {
                    maxSubArray = max;
                }
            }

            //for (int i = 0; i < a.Count; i++)
            //{
            //    int subArrayPartPos = a.Count(e => a[i] >= e && Math.Abs(a[i] - e) <= 1);
            //    int subArrayPartNeg = a.Count(e => a[i] <= e && Math.Abs(a[i] - e) <= 1);
            //    int max = Math.Max(subArrayPartNeg, subArrayPartPos);

            //    if (max > maxSubArray)
            //    {
            //        maxSubArray = max;
            //    }
            //}

            return maxSubArray;
        }
        #endregion

        #region angryProfessor
        /*
   * Complete the 'angryProfessor' function below.
   *
   * The function is expected to return a STRING.
   * The function accepts following parameters:
   *  1. INTEGER k
   *  2. INTEGER_ARRAY a
   */

        public static string angryProfessor(int k, List<int> a)
        {
            return a.Count(s => s <= 0) >= k ? "NO" : "YES";
        }

        #endregion


        #region UtopianTree
        /*
   * Complete the 'utopianTree' function below.
   *
   * The function is expected to return an INTEGER.
   * The function accepts INTEGER n as parameter.
   */
        public static int utopianTree(int n)
        {
            if (n == 0)
                return 1;

            int height = 1;

            for (int i = 1; i <= n; i++)
            {
                if (i % 2 == 0)
                    height++;
                else
                    height *= 2;
            }

            return height;
        }

        #endregion
        #region climbingLeaderboard
        /*
         * Complete the 'climbingLeaderboard' function below.
         *
         * The function is expected to return an INTEGER_ARRAY.
         * The function accepts following parameters:
         *  1. INTEGER_ARRAY ranked
         *  2. INTEGER_ARRAY player
         */

        public static List<int> climbingLeaderboard(List<int> ranked, List<int> player)
        {
            List<int> result = new List<int>();

            if (!ranked.Any())
            {
                return player.Select(p => 1).ToList();
            }

            if (!player.Any())
            {
                return result;
            }

            player.Reverse();
            int currenIndexPlay = 0, rankedj = 0, currentRanked = 1, lastRankedj = ranked[0];

            int currentPlay = player[currenIndexPlay];


            for (int j = 0; j < ranked.Count; j++)
            {
                rankedj = ranked[j];

                if (currentPlay >= rankedj)
                {
                    if (rankedj < lastRankedj)
                    {
                        currentRanked++;
                    }

                    result.Add(currentRanked);

                    currenIndexPlay++;
                    while (currenIndexPlay < player.Count && player[currenIndexPlay] >= rankedj)
                    {
                        result.Add(currentRanked);
                        currenIndexPlay++;
                    }

                    if (currenIndexPlay == player.Count)
                    {
                        break;
                    }

                    currentPlay = player[currenIndexPlay];
                }
                else
                {
                    if (rankedj < lastRankedj)
                    {
                        currentRanked++;
                    }
                }

                lastRankedj = rankedj;
            }

            for (int i = currenIndexPlay; i < player.Count; i++)
            {
                if (player[i] == rankedj)
                    result.Add(currentRanked);
                else
                    result.Add(currentRanked + 1);
            }

            result.Reverse();

            return result;
        }
        #endregion

        #region designerPdfViewer
        /*
     * Complete the 'designerPdfViewer' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts following parameters:
     *  1. INTEGER_ARRAY h
     *  2. STRING word
     */

        public static int designerPdfViewer(List<int> h, string word)
        {
            var letters = new List<char>() {
                'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z'
            };

            var heights = word.Select(i => h[letters.IndexOf(i)]).ToList();

            return heights.Max() * word.Count();
        }
        #endregion

        #region hurdleRace
        /*
    * Complete the 'hurdleRace' function below.
    *
    * The function is expected to return an INTEGER.
    * The function accepts following parameters:
    *  1. INTEGER k
    *  2. INTEGER_ARRAY height
    */

        public static int hurdleRace(int k, List<int> height)
        {
            int max = height.Max();

            return k >= max ? 0 : max - k;
        }
        #endregion

        #region formingMagicSquare
        /*
    * Complete the 'formingMagicSquare' function below.
    *
    * The function is expected to return an INTEGER.
    * The function accepts 2D_INTEGER_ARRAY s as parameter.
    */

        public static int formingMagicSquare(List<List<int>> s)
        {
            //return formingMagicSquareRec(0, 0, new List<int>() {1,2,3,4,5,6,7,8,9 }, s);
            //var perms = GetPerms(new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9 });
            //List<List<List<int>>> allpermsmatrix = new List<List<List<int>>>();

            //foreach (var perm in perms)
            //{
            //    List<List<int>> res = new List<List<int>>();

            //    res.Add(perm.GetRange(0, 3));
            //    res.Add(perm.GetRange(3, 3));
            //    res.Add(perm.GetRange(6, 3));

            //    allpermsmatrix.Add(res);
            //}

            //var magicSquares = allpermsmatrix.Where(l => CheckIfFormingMagicSquare(l)).ToList();

            var magicSquares = new List<List<List<int>>>()
            {
                new List<List<int>>
                {
                    new List<int> { 8,1,6},
                    new List<int> { 3,5,7},
                    new List<int> { 4,9,2},
                },

                 new List<List<int>>
                {
                    new List<int> { 6,7,2},
                    new List<int> { 1,5,9},
                    new List<int> { 8,3,4},
                },

                  new List<List<int>>
                {
                    new List<int> { 2,9,4},
                    new List<int> { 7,5,3},
                    new List<int> { 6,1,8},
                },

                   new List<List<int>>
                {
                    new List<int> { 4,3,8},
                    new List<int> { 9,5,1},
                    new List<int> { 2,7,6},
                },

                    new List<List<int>>
                {
                    new List<int> { 6,1,8},
                    new List<int> { 7,5,3},
                    new List<int> { 2,9,4},
                },

                     new List<List<int>>
                {
                    new List<int> { 2,7,6},
                    new List<int> { 9,5,1},
                    new List<int> { 4,3,8},
                },

                      new List<List<int>>
                {
                    new List<int> { 4,9,2},
                    new List<int> { 3,5,7},
                    new List<int> { 8,1,6},
                },

                       new List<List<int>>
                {
                    new List<int> { 8,3,4},
                    new List<int> { 1,5,9},
                    new List<int> { 6,7,2},
                },
            };

            int minDiff = int.MaxValue;

            foreach (var magicSquare in magicSquares)
            {
                int diff = 0;
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        diff += Math.Abs(magicSquare[i][j] - s[i][j]);
                    }
                }

                if (diff < minDiff)
                    minDiff = diff;
            }

            return minDiff;
        }

        private static List<List<int>> GetPerms(List<int> numbers)
        {
            //List<int> perms = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            List<List<int>> res = new List<List<int>>();

            if (numbers.Count == 1)
            {
                return new List<List<int>>() { numbers };
            }

            for (int i = 0; i < numbers.Count; i++)
            {
                var list = new List<int>() { numbers[i] };
                var recList = GetPerms(numbers.Where(n => n != numbers[i]).ToList());

                var x = recList.Select(l => list.Union(l).ToList());

                res.AddRange(x);
            }

            return res;
        }

        #region commented dont work
        //private static List<int> GetPermsRec(List<int> numbers)
        //{
        //    if (numbers.Count == 1)
        //    {
        //        return numbers;
        //    }

        //    return new List<>
        //}



        //private static int formingMagicSquareRec(int v1, int v2, List<int> numbers, List<List<int>> s)
        //{
        //    int minDiff = 10000;

        //    if (CheckIfFormingMagicSquare(s))
        //        return 0;

        //    for (int i = v1; i < 3; i++)
        //    {
        //        for (int j = v2; j < 3; j++)
        //        {
        //            for (int k = 0; k < numbers.Count(); k++)
        //            {
        //                int n = numbers[k];

        //                PrintSquare(s);

        //                if (s[i][j] != n)
        //                {
        //                    int diff = Math.Abs(s[i][j] - n);

        //                    s[i][j] = n;

        //                    numbers.RemoveAt(k);

        //                    if (CheckIfFormingMagicSquare(s))
        //                    {
        //                        return diff;
        //                    }

        //                    if (diff + formingMagicSquareRec(i,j, numbers, s) < minDiff)
        //                    {
        //                        minDiff = diff + formingMagicSquare(s);
        //                    }
        //                }
        //            }
        //        }
        //    }

        //    return minDiff;
        //}

        //private static void PrintSquare(List<List<int>> s)
        //{
        //    Console.WriteLine("***********");

        //    for (int i = 0; i < 3; i++)
        //    {
        //        for (int j = 0; j < 3; j++)
        //        {
        //            Console.Write(s[i][j]);
        //        }
        //        Console.WriteLine();
        //    }

        //    Console.WriteLine("***********");
        //}

        #endregion



        private static bool CheckIfFormingMagicSquare(List<List<int>> s)
        {
            int sumRow = 0,
            sumCol = 0,
            sumDiagDer = 0,
            sumDiagIzq = 0;

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    sumRow += s[i][j];
                    sumCol += s[j][i];

                    if (i == j)
                    {
                        sumDiagDer += s[i][i];
                        sumDiagIzq += s[i][2 - i];
                    }
                }

                if (sumRow != 15 || sumCol != 15)
                    return false;

                sumRow = 0;
                sumCol = 0;
            }

            if (sumDiagDer != 15 || sumDiagIzq != 15)
                return false;

            return true;
        }
        #endregion

        #region CatAndMouse
        // Complete the catAndMouse function below.
        static string catAndMouse(int x, int y, int z)
        {
            int diffA = Math.Abs(x - z),
                diffB = Math.Abs(y - z);
            return diffA == diffB ? "Mouse C" : diffA < diffB ? "Cat A" : "Cat B";
        }
        #endregion

        #region GetMoneySpent
        /*
    * Complete the getMoneySpent function below.
    */
        static int getMoneySpent(int[] keyboards, int[] drives, int b)
        {
            int max = -1, sum = 0;

            for (int i = 0; i < keyboards.Count(); i++)
            {
                for (int j = 0; j < drives.Count(); j++)
                {
                    sum = keyboards[i] + drives[j];

                    if (sum <= b && sum > max)
                    {
                        max = sum;
                    }
                }
            }

            return max;
        }
        #endregion

        #region CountingValleys

        /*
    * Complete the 'countingValleys' function below.
    *
    * The function is expected to return an INTEGER.
    * The function accepts following parameters:
    *  1. INTEGER steps
    *  2. STRING path
    */

        public static int countingValleys(int steps, string path)
        {
            int level = 0;
            int countValleys = 0;

            for (int i = 0; i < steps; i++)
            {
                if (path[i] == 'D')
                {
                    if (level == 0)
                    {
                        countValleys++;
                    }

                    level--;
                }
                else
                {
                    level++;
                }
            }

            return countValleys;
        }
        #endregion

        #region PageCount
        /*
     * Complete the 'pageCount' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts following parameters:
     *  1. INTEGER n
     *  2. INTEGER p
     */

        public static int pageCount(int n, int p)
        {
            return Math.Min(p / 2, n % 2 == 0 ? (n + 1 - p) / 2 : (n + -p) / 2);
        }
        #endregion

        #region SockMerchant
        /*
    * Complete the 'sockMerchant' function below.
    *
    * The function is expected to return an INTEGER.
    * The function accepts following parameters:
    *  1. INTEGER n
    *  2. INTEGER_ARRAY ar
    */

        public static int sockMerchant(int n, List<int> ar)
        {
            return ar.GroupBy(a => a).Sum(a => a.Count() / 2);
        }
        #endregion

        #region BonAppetit
        /*
     * Complete the 'bonAppetit' function below.
     *
     * The function accepts following parameters:
     *  1. INTEGER_ARRAY bill
     *  2. INTEGER k
     *  3. INTEGER b
     */

        public static void bonAppetit(List<int> bill, int k, int b)
        {
            int sum = 0;
            for (int i = 0; i < bill.Count; i++)
            {
                if (i != k)
                {
                    sum += bill[i];
                }
            }

            sum = sum / 2;

            if (sum == b)
                Console.WriteLine("Bon Appetit");
            else
                Console.WriteLine(Math.Abs(sum - b));
        }
        #endregion

        #region DayOfProgrammer
        /*
    * Complete the 'dayOfProgrammer' function below.
    *
    * The function is expected to return a STRING.
    * The function accepts INTEGER year as parameter.
    */
        public static string dayOfProgrammer(int year)
        {
            DateTime dateTime = new DateTime(year, 1, 1);

            if (year > 1918)
            {
                return dateTime.AddDays(255).ToString("dd.MM.yyyy");
            }
            else if (year == 1918)
            {
                return dateTime.AddDays(255 + 13).ToString("dd.MM.yyyy");
            }
            else //< 1918
            {
                var days = 255;

                if (year % 4 == 0 && !(year % 400 == 0 || (year % 4 == 0 && year % 100 != 0)))
                {
                    days--;
                }

                return dateTime.AddDays(days).ToString("dd.MM.yyyy");
            }


        }

        #endregion

        #region MigratoryBirdsNoOpt

        /*
         * Complete the 'migratoryBirds' function below.
         *
         * The function is expected to return an INTEGER.
         * The function accepts INTEGER_ARRAY arr as parameter.
         */

        public static int migratoryBirdsNoOpt(List<int> arr)
        {
            return arr.Select(
                fe =>
                new { count = arr.Count(c => c == fe), element = fe })
                .OrderByDescending(m => m.count)
                .FirstOrDefault().element;
        }

        public static int migratoryBirdsDict(List<int> arr)
        {
            var dict = new Dictionary<int, int>();
            int maxReps = int.MinValue;
            int maxRepsValue = 0;

            for (int i = 0; i < arr.Count; i++)
            {
                var value = arr[i];

                if (dict.ContainsKey(value))
                {
                    dict[value]++;
                }
                else
                {
                    dict.Add(value, 1);
                }

                if (dict[value] > maxReps)
                {
                    maxReps = dict[value];
                    maxRepsValue = value;
                }
                else if (dict[value] == maxReps)
                {
                    if (value < maxRepsValue)
                    {
                        maxRepsValue = value;
                    }
                }
            }

            return maxRepsValue;
        }

        public static int migratoryBirds(List<int> arr)
        {
            var dict = new Dictionary<int, Tuple<int, int>>();


            for (int i = 0; i < arr.Count; i++)
            {
                var value = arr[i];

                if (dict.ContainsKey(value))
                {
                    dict[value] = new Tuple<int, int>(dict[value].Item1 + 1, dict[value].Item2);
                }
                else
                {
                    dict.Add(value, new Tuple<int, int>(1, i));
                }

            }

            return dict.OrderByDescending(d => d.Value.Item1).ThenBy(d => d.Key).First().Key;

        }
        #endregion

        #region DivisibleSumPairs
        /*
    * Complete the 'divisibleSumPairs' function below.
    *
    * The function is expected to return an INTEGER.
    * The function accepts following parameters:
    *  1. INTEGER n
    *  2. INTEGER k
    *  3. INTEGER_ARRAY ar
    */

        public static int divisibleSumPairs(int n, int k, List<int> ar)
        {
            int result = 0;

            for (int i = 0; i < ar.Count - 1; i++)
            {
                for (int j = i + 1; j < ar.Count; j++)
                {
                    if ((ar[i] + ar[j]) % k == 0)
                        result++;
                }
            }

            return result;
        }
        #endregion

        #region Birthday
        /*
    * Complete the 'birthday' function below.
    *
    * The function is expected to return an INTEGER.
    * The function accepts following parameters:
    *  1. INTEGER_ARRAY s
    *  2. INTEGER d
    *  3. INTEGER m
    */

        public static int birthday(List<int> s, int d, int m)
        {
            int result = 0;
            int sumContiguous = 0;

            int index = 0;

            while (index < s.Count)
            {
                for (int i = index; i < index + m && i < s.Count; i++)
                {
                    if (s[i] + sumContiguous <= d)
                    {
                        sumContiguous += s[i];

                        if (sumContiguous == d && i == index + m - 1)
                        {

                            // index = i;
                            result++;
                            break;
                        }
                    }
                    else
                    {

                        break;
                    }
                }

                sumContiguous = 0;
                index++;
            }

            return result;

        }

        #endregion

        #region BreakingRecords
        /*
   * Complete the 'breakingRecords' function below.
   *
   * The function is expected to return an INTEGER_ARRAY.
   * The function accepts INTEGER_ARRAY scores as parameter.
   */

        public static List<int> breakingRecords(List<int> scores)
        {
            if (scores.Count == 0)
            {
                return new List<int> { 0, 0 };
            }

            int maxRecord = scores[0];
            int minRecord = scores[0];
            int countMax = 0, countMin = 0;

            for (int i = 1; i < scores.Count; i++)
            {
                if (scores[i] > maxRecord)
                {
                    maxRecord = scores[i];
                    countMax++;
                }
                else if (scores[i] < minRecord)
                {
                    minRecord = scores[i];
                    countMin++;
                }
            }

            return new List<int>() { countMax, countMin };
        }
        #endregion

        #region GetTotalX
        /*
    * Complete the 'getTotalX' function below.
    *
    * The function is expected to return an INTEGER.
    * The function accepts following parameters:
    *  1. INTEGER_ARRAY a
    *  2. INTEGER_ARRAY b
    */
        public static int getTotalX(List<int> a, List<int> b)
        {

            int maxValueOfB = b.Max();
            int minValueOfA = a.Max();
            int result = 0;

            for (int i = minValueOfA; i <= maxValueOfB; i++)
            {
                if (DivideAllElements(a, i) && AllElementsDivide(b, i))
                    result++;
            }

            return result;
        }

        private static bool AllElementsDivide(List<int> b, int element)
        {
            return b.TrueForAll(i => i % element == 0);
        }

        private static bool DivideAllElements(List<int> a, int element)
        {
            return a.TrueForAll(i => element % i == 0);
        }
        #endregion

        /*
         * Complete the 'cosine_similarity' function below.
         *
         * The function is expected to return a DOUBLE.
         * The function accepts following parameters:
         *  1. INTEGER_ARRAY a_keys
         *  2. DOUBLE_ARRAY a_values
         *  3. INTEGER_ARRAY b_keys
         *  4. DOUBLE_ARRAY b_values
         */

        public static double cosine_similarity(List<int> a_keys, List<double> a_values, List<int> b_keys, List<double> b_values)
        {
            //List<double> aVectorComplete = GetCompletVector(a_keys, a_values);
            //List<double> bVectorComplete = GetCompletVector(b_keys, b_values);

            return (Prod(a_keys, b_keys, a_values, b_values)) / (Mag(a_values) * Mag(b_values));
        }

        public static double Prod(List<int> a_keys, List<int> b_keys, List<double> a_values, List<double> b_values)
        {
            double result = 0;

            for (int i = 0; i < a_keys.Count; i++)
            {
                var akey = a_keys[i];

                if (b_keys.Contains(akey))
                {
                    result += (a_values[i] * b_values[b_keys.IndexOf(akey)]);
                }
            }

            return result;
        }


        public static double Mag(List<double> a_values)
        {
            return Math.Sqrt(a_values.Select(a => Math.Pow(a, 2)).Sum());
        }

        private static List<double> GetCompletVector(List<int> a_keys, List<double> a_values)
        {
            List<double> vectorComplete = new List<double>();
            int lastIndex = -1;

            for (int i = 0; i < a_keys.Count; i++)
            {
                //FillVectorWithZeros(i, lastIndex);

                for (int j = lastIndex; j < a_keys[i] - 1; j++)
                {
                    vectorComplete.Add(0);
                }
                vectorComplete.Add(a_values[i]);
                lastIndex = a_keys[i];
            }

            return vectorComplete;
        }

        public static void fizzBuzz(int n)
        {
            for (int i = 0; i < n; i++)
            {
                if (i % 3 == 0 && i % 5 == 0)
                {
                    Console.WriteLine("FizzBuzz");
                }
                else if (i % 3 == 0 && i % 5 != 0)
                {
                    Console.WriteLine("Fizz");
                }
                else if (i % 3 != 0 && i % 5 == 0)
                {
                    Console.WriteLine("Buzz");
                }
                else
                {
                    Console.WriteLine(i);
                }
            }
        }

        #region Kangaroo
        /*
    * Complete the 'kangaroo' function below.
    *
    * The function is expected to return a STRING.
    * The function accepts following parameters:
    *  1. INTEGER x1
    *  2. INTEGER v1
    *  3. INTEGER x2
    *  4. INTEGER v2
    */

        public static string kangaroo(int x1, int v1, int x2, int v2)
        {
            if (v1 > v2 && (x2 - x1) % (v1 - v2) == 0)
                return "YES";
            else
                return "NO";
        }

        #endregion

        #region CountApplesAndOranges
        /*
     * Complete the 'countApplesAndOranges' function below.
     *
     * The function accepts following parameters:
     *  1. INTEGER s
     *  2. INTEGER t
     *  3. INTEGER a
     *  4. INTEGER b
     *  5. INTEGER_ARRAY apples
     *  6. INTEGER_ARRAY oranges
     */

        public static void countApplesAndOranges(int s, int t, int a, int b, List<int> apples, List<int> oranges)
        {
            Console.WriteLine(GetCountOfFruitsInHouse(apples, s, t, a));
            Console.WriteLine(GetCountOfFruitsInHouse(oranges, s, t, b));
        }

        private static int GetCountOfFruitsInHouse(List<int> fruits, int s, int t, int b)
        {
            int distance = 0;
            int count = 0;

            for (int i = 0; i < fruits.Count; i++)
            {
                distance = b + fruits[i];
                if (distance >= s && distance <= t)
                {
                    count++;
                }
            }

            return count;
        }

        #endregion

        #region GradingStudents
        /*
          * Complete the 'gradingStudents' function below.
          *
          * The function is expected to return an INTEGER_ARRAY.
          * The function accepts INTEGER_ARRAY grades as parameter.
          */

        public static List<int> gradingStudents(List<int> grades)
        {
            List<int> result = new List<int>();

            for (int i = 0; i < grades.Count; i++)
            {
                if (grades[i] < 38)
                {
                    result.Add(grades[i]);
                }
                else
                {
                    var nextMultipleOfFive = NextMultipleOfFive(grades[i]);

                    if (Math.Abs(grades[i] - nextMultipleOfFive) < 3)
                    {
                        result.Add(nextMultipleOfFive);
                    }
                    else
                    {
                        result.Add(grades[i]);
                    }
                }
            }

            return result;
        }

        private static int NextMultipleOfFive(int number)
        {
            int result = number / 5;

            return number % 5 == 0 ? number : (5 * (result + 1));
        }
        #endregion

        #region TimeConversion
        /*
             * Complete the 'timeConversion' function below.
             *
             * The function is expected to return a STRING.
             * The function accepts STRING s as parameter.
             */

        public static string timeConversion(string s)
        {
            return DateTime.Parse(s).ToString("HH:mm:ss");
        }
        #endregion

        #region BirthdayCakeCandles
        /*
     * Complete the 'birthdayCakeCandles' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts INTEGER_ARRAY candles as parameter.
     */

        public static int birthdayCakeCandles(List<int> candles)
        {
            int max = candles.Max();
            int ocurrences = 0;
            for (int i = 0; i < candles.Count; i++)
            {
                if (candles[i] == max)
                    ocurrences++;
            }

            return ocurrences;
        }

        public static int birthdayCakeCandlesSimple(List<int> candles)
        {
            return candles.Count(x => x == candles.Max());
        }


        public static int birthdayCakeCandlesBetter(List<int> candles)
        {
            int max = int.MinValue;
            int ocurrences = 0;

            for (int i = 0; i < candles.Count; i++)
            {
                if (candles[i] > max)
                {
                    max = candles[i];
                    ocurrences = 1;
                }
                else if (candles[i] == max)
                {
                    ocurrences++;
                }
            }

            return ocurrences;
        }
        #endregion

        #region MiniMaxSum
        /*
     * Complete the 'miniMaxSum' function below.
     *
     * The function accepts INTEGER_ARRAY arr as parameter.
     */

        public static void miniMaxSum(List<int> arr)
        {
            var longList = arr.Select(a => (long)a).ToList();
            longList.Sort();

            long min = longList.GetRange(0, 4).Sum();

            long max = longList.GetRange(1, 4).Sum();

            Console.WriteLine(min + " " + max);
        }

        #endregion

        #region Staircase
        /*
    * Complete the 'staircase' function below.
    *
    * The function accepts INTEGER n as parameter.
    */
        public static void staircase(int n)
        {
            for (int i = 1; i <= n; i++)
            {
                Console.WriteLine(FillSymbols(i, n));
            }
        }

        private static string FillSymbols(int i, int total)
        {
            return new String(' ', total - i) + new string('#', i);
        }

        #endregion

        #region PlusMinus
        /*
     * Complete the 'plusMinus' function below.
     *
     * The function accepts INTEGER_ARRAY arr as parameter.
     */

        public static void plusMinus(List<int> arr)
        {
            int total = arr.Count;
            int positives = 0, negatives = 0, zeros = 0;

            for (int i = 0; i < total; i++)
            {
                if (arr[i] > 0)
                    positives++;
                else if (arr[i] < 0)
                    negatives++;
                else zeros++;
            }

            Console.WriteLine((float)((float)positives / (float)total));
            Console.WriteLine((float)((float)negatives / (float)total));
            Console.WriteLine((float)((float)zeros / (float)total));
        }

        #endregion

        #region CompareTriplets
        public static List<int> compareTriplets(List<int> a, List<int> b)
        {
            List<int> result = new List<int>() { 0, 0 };

            for (int i = 0; i < a.Count; i++)
            {
                if (a[i] > b[i])
                {
                    result[0]++;
                }
                else if (a[i] < b[i])
                {
                    result[1]++;
                }
            }

            return result;
        }
        #endregion

        #region DiagonalDifference
        public static int diagonalDifference(List<List<int>> arr)
        {
            int leftToRightDiagonal = 0, rightToLeftDiagonal = 0;

            for (int i = 0; i < arr.Count; i++)
            {
                leftToRightDiagonal += arr[i][i];
                rightToLeftDiagonal += arr[i][arr.Count - i - 1];
            }

            return Math.Abs(leftToRightDiagonal - rightToLeftDiagonal);
        }
        #endregion
        
        #region libraryFine
        /*
     * Complete the 'libraryFine' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts following parameters:
     *  1. INTEGER d1
     *  2. INTEGER m1
     *  3. INTEGER y1
     *  4. INTEGER d2
     *  5. INTEGER m2
     *  6. INTEGER y2
     */

        public static int libraryFine(int d1, int m1, int y1, int d2, int m2, int y2)
        {
            var returnedDate = new DateTime(y1, m1, d1);
            var expectedDate = new DateTime(y2, m2, d2);

            if (returnedDate.CompareTo(expectedDate) <= 0)
                return 0;

            if (returnedDate.Year > expectedDate.Year)
                return 10000;
            
            if (returnedDate.Month > expectedDate.Month)
                return 500 * (returnedDate.Month - expectedDate.Month);
            
            if (returnedDate.Day > expectedDate.Day)
                return 15 * (returnedDate.Day - expectedDate.Day);

            return 0;
        }
        #endregion
        
        #region nonDivisibleSubset
        /*
     * Complete the 'nonDivisibleSubset' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts following parameters:
     *  1. INTEGER k
     *  2. INTEGER_ARRAY s
     */

        private static Dictionary<string, int> PrevValues = new Dictionary<string, int>();
        public static int nonDivisibleSubsetRec(int k, List<int> s, int index, List<int> subset)
        {
            if (index > s.Count - 1)
            {
                PrevValues[GetKey(index, subset)] = subset.Count;
                return subset.Count;
            }

            string key = "";
            
            if (canAddElementToSubset(k, s[index], subset))
            {
                key = GetKey(index +1 , subset);
                var notAddingNumber = PrevValues.ContainsKey(key) ? PrevValues[key] :  nonDivisibleSubsetRec(k, s, index + 1, subset);
                
                key = GetKey(index +1 , subset.Concat(new List<int>() {s[index]}).ToList());
                var addingNumber = PrevValues.ContainsKey(key) ? PrevValues[key] : nonDivisibleSubsetRec(k, s, index + 1, subset.Concat(new List<int>() {s[index]}).ToList());
                return Math.Max(notAddingNumber, addingNumber);
            }
            else
            {
                key = GetKey(index +1 , subset);
                return PrevValues.ContainsKey(key) ? PrevValues[key] :  nonDivisibleSubsetRec(k, s, index + 1, subset);
            }

        }

        private static bool canAddElementToSubset(int k, int number, List<int> subset)
        {
            return !subset.Any(s => (s + number) % k == 0);
        }
        
        private static string GetKey(int index, List<int> subset)
        {
            return index.ToString() + "," + String.Concat(subset, ",");
        }

        public static int nonDivisibleSubset2(int k, List<int> s)
        {
            var result = nonDivisibleSubsetRec(k, s, 0, new List<int>());

            PrevValues.Clear();
            return result;
        }
        #endregion

        static async Task Main(string[] args)
        {

            /*var result = serviceLane(4, new List<List<int>>()
                {
                    new List<int>() { 0, 3 },
                    new List<int>() { 4, 6 },
                    new List<int>() { 6, 7 },
                    new List<int>() { 3, 5 },
                    new List<int>() { 0, 7 },
                },
                new List<int>() { 2, 3, 1, 2, 3, 2, 3, 3 });*/
            
           /* var result = serviceLane(4, new List<List<int>>()
                {
                    new List<int>() { 2, 3 },
                    new List<int>() { 1, 4 },
                    new List<int>() { 2, 4 },
                    new List<int>() { 2, 4 },
                    new List<int>() { 2, 3 },
                },
                new List<int>() { 1,2,2,2,1 });
                */

           var result =  cavityMap(new List<string>() { "1112", "1912", "1892", "1234" });//cavityMap(new List<string>() { "989", "191", "111" });
                
             foreach (var item in result)
            {
                Console.WriteLine(item);
            }  

          /*  var result = nonDivisibleSubset( 4, new List<int>(){19,10,12,10,24,25,22});
            Console.WriteLine("el resultado de nonDivisibleSubset es" + result);
            
             result = nonDivisibleSubset( 3, new List<int>(){1,7,2,4});
            Console.WriteLine("el resultado de nonDivisibleSubset es: " + result);
            
             result = nonDivisibleSubset( 7, new List<int>(){278, 576, 496 ,727, 410 ,124, 338 ,149, 209, 702, 282, 718, 771, 575 ,436});
            Console.WriteLine("el resultado de nonDivisibleSubset es: " + result);
            */
            //var result =  compareTriplets(new List<int>() { 1, 2, 3 }, new List<int>() { 1, 4, 3 });

            // foreach (var item in result)
            //{
            //    Console.WriteLine(item);
            //}

            //plusMinus(new List<int>() { -4, 3, -9, 0, 4, 1 });

            //staircase(6);

            //miniMaxSum(new List<int>() { 256741038 ,623958417, 467905213, 714532089 ,938071625 });

            //Console.WriteLine(birthdayCakeCandles(new List<int>() { 4, 4, 1, 3, }));

            //  Console.WriteLine(timeConversion("12:00:00PM"));




            // var x = GetCompletVector(new List<int>() { 2, 4, 5, 8 }, new List<double>() { 7, 5, 12, 1 });

            //var y = cosine_similarity()

            // var result = birthday(new List<int>() { 2, 5, 1, 3 ,4 ,4, 3 ,5 ,1 ,1 ,2 ,1, 4 ,1 ,3, 3,4 ,2, 1 }, 18, 7);


            //var result = migratoryBirds(new List<int>() { 1, 2, 3, 3, 3, 5, 3, 4, 4, 3, 4, 4 });
            //var result = migratoryBirds(new List<int>() { 1 ,4 ,4 ,4 ,5 ,3 });

            //var result = migratoryBirds(new List<int>() {
            //    5,2,2,2,4,1,1,2,4,2,2,2,4,1,2,4,1,2,4,4,3,2,3,1,3,3,4,3,5,2,5,3,4,1,3,2,3,3,3,5,2,4,1,5,4,5,4,4,4,5,3,2,1,1,3,1,1,5,5,3,5,2,2,4,5,2,4,3,2,4,4,5,3,2,3,2,4,5,2,2,3,5,2,3,1,3,3,2,4,3,5,4,3,1,3,3,2,4,4,3,5,3,3,3,5,1,3,5,5,2,5,2,3,4,3,3,2,1,3,1,2,3,2,4,2,3,3,3,3,4,3,3,1,1,5,1,3,4,5,5,3,3,1,5,5,5,5,2,3,1,3,2,3,5,5,1,1,3,4,1,1,2,4,4,4,1,2,3,3,2,1,5,3,1,1,2,2,1,5,2,1,1,4,2,4,5,2,2,2,1,1,1,3,2,4,5,1,4,4,1,5,2,1,4,3,5,4,2,1,5,5,5,2,1,4,5,2,2,1,2,4,3,2,4,3,3,5,3,5,1,4,1,2,4,2,1,5,5,1,1,5,5,1,3,5,2,5,4,1,1,2,1,5,2,3,3,1,1,2,2,5,2,1,3,5,5,4,2,5,5,4,2,1,3,3,1,2,5,5,1,4,4,5,4,3,2,4,5,1,4,1,2,2,4,5,3,3,5,1,4,2,5,1,5,3,3,2,4,3,5,1,2,4,2,3,4,4,4,4,3,4,5,1,2,3,1,5,2,2,3,5,4,5,3,2,3,3,3,1,4,2,3,3,4,4,3,2,2,2,2,1,4,2,3,1,4,4,5,4,1,3,1,2,3,4,3,2,2,3,2,3,5,2,3,3,1,1,3,4,1,2,3,3,4,5,3,2,4,2,2,3,1,3,1,3,1,2,1,1,4,3,3,1,3,4,1,4,4,5,5,2,5,4,2,5,4,1,3,1,2,2,5,4,4,2,2,5,4,2,3,5,5,1,3,1,2,1,2,1,2,5,4,5,4,3,5,1,4,5,1,5,5,2,3,2,3,5,1,1,4,4,5,5,5,4,5,2,4,2,3,3,2,4,2,5,2,3,3,2,4,3,5,3,4,5,5,2,1,4,5,2,1,2,5,1,1,3,3,5,5,4,2,4,3,1,3,1,4,3,1,2,2,4,5,4,4,3,5,5,4,4,4,2,2,5,4,4,1,1,4,5,4,3,4,3,3,2,3,2,3,5,5,5,5,2,1,1,5,3,4,3,2,1,3,4,2,4,2,4,1,3,5,3,3,1,1,3,3,2,3,2,4,4,5,2,1,4,1,1,3,2,1,5,2,2,1,4,4,2,1,2,5,3,2,2,2,1,2,3,4,3,2,2,3,3,4,2,2,5,4,2,1,2,5,1,2,1,2,3,5,3,2,5,3,3,1,5,5,5,5,5,2,4,2,5,2,2,4,3,3,3,1,2,5,1,2,1,3,1,5,3,2,4,1,3,5,5,5,3,2,3,4,1,5,5,5,1,4,1,2,4,4,3,1,4,1,1,5,5,3,4,5,1,2,2,4,2,4,4,5,4,3,5,1,2,5,1,4,2,5,3,2,1,5,5,3,4,2,2,4,2,4,3,3,5,1,1,4,2,1,3,2,3,1,3,1,4,4,3,2,5,2,5,4,2,3,5,4,5,2,5,4,1,5,5,4,4,2,4,5,4,1,4,2,2,5,5,3,1,4,2,1,1,5,3,2,4,1,5,5,4,5,4,5,5,3,1,4,4,3,2,4,2,4,5,4,2,5,5,3,5,4,1,1,1,3,4,3,2,1,2,3,5,2,5,1,1,4,3,5,3,3,4,3,1,1,1,3,2,5,2,3,1,1,4,2,3,3,3,3,4,2,2,2,3,4,5,1,4,1,4,2,2,2,4,4,5,3,3,3,5,1,1,1,1,3,2,3,3,5,5,3,5,2,2,4,3,4,3,2,1,1,1,2,5,4,3,1,3,4,2,1,2,4,5,5,5,4,2,4,4,5,2,2,2,4,5,2,5,3,5,3,1,2,4,2,2,2,5,2,2,2,5,5,4,2,2,4,4,2,3,2,1,2,1,1,4,5,4,3,1,1,4,2,1,5,5,2,4,2,5,2,3,5,5,1,4,5,3,2,1,2,4,2,3,3,2,4,3,5,4,2,3,1,2,4,2,5,3,1,2,5,5,1,4,4,5,5,5,1,1,4,3,5,5,2,5,2,4,5,2,5,2,1,2,4,2,2,4,4,4,2,3,5,5,2,1,5,4,1,4,5,3,5,4,2,5,3,1,4,3,4,5,1,5,5,1,5,4,1,1,1,1,2,3,2,4,1,3,3,1,5,4,3,5,3,2,3,4,3,2,1,3,4,4,5,4,5,2,2,1,5,3,5,5,4,4,1,4,1,3,3,5,4,5,4,1,3,5,3,1,5,2,5,5,4,3,2,5,1,2,5,2,5,4,4,5,3,5,1,1,3,3,4,4,4,4,4,2,2,3,5,4,4,1,2,2,2,1,4,5,5,5,3,5,2,1,5,2,3,1,5,2,4,1,2,3,2,3,3,2,3,5,2,1,5,3,5,1,5,3,4,5,4,2,1,2,2,5,4,1,1,3,3,3,5,2,4,3,1,1,1,1,1,5,2,1,3,3,5,5,4,3,2,5,4,5,5,3,4,4,1,1,4,3,2,3,1,4,1,2,2,5,3,4,3,4,4,5,1,1,5,4,4,5,1,2,1,2,5,1,1,5,2,2,2,5,1,4,1,4,4,3,4,2,1,1,5,4,5,5,3,4,2,3,2,5,1,3,2,5,1,2,2,5,5,1,1,1,4,1,5,1,1,4,4,2,5,5,3,4,3,5,2,4,3,4,5,2,1,2,3,2,1,3,4,1,1,2,5,5,1,4,4,5,2,2,5,5,5,5,5,3,3,4,1,3,5,1,4,5,4,4,1,5,3,1,4,3,4,5,1,3,4,4,2,1,2,3,1,4,5,1,4,1,5,4,5,5,2,1,5,4,4,1,5,5,4,5,1,5,5,5,5,4,5,4,2,3,2,5,5,2,5,5,2,2,2,2,2,5,1,1,3,5,3,1,2,1,1,2,5,1,1,4,4,1,3,3,3,5,4,1,5,4,4,3,5,4,2,3,2,1,1,1,4,5,2,5,2,3,3,2,1,1,4,1,4,4,3,2,3,4,2,5,1,2,3,4,2,3,3,2,4,4,3,4,4,3,4,2,4,2,2,4,1,2,5,5,3,4,2,1,1,2,1,4,2,4,3,2,5,1,3,2,1,2,5,2,1,5,4,4,3,5,1,3,5,1,3,4,2,3,1,1,4,4,4,2,2,4,2,3,4,1,4,3,2,5,5,1,3,2,1,4,3,4,1,4,1,1,4,1,5,2,2,5,2,1,2,5,1,5,4,4,2,1,2,2,1,3,4,5,5,2,3,3,4,3,2,5,3,3,2,4,4,5,1,1,1,2,4,2,4,3,3,2,2,1,1,3,2,4,1,5,1,3,2,4,2,4,4,1,4,5,5,2,1,4,1,1,5,1,1,1,5,2,4,5,1,2,3,5,2,5,1,1,5,5,2,1,4,3,3,1,2,1,5,1,2,2,3,3,3,1,1,4,2,2,2,3,1,5,2,3,1,5,5,2,5,5,3,3,3,2,2,2,4,5,3,1,4,4,2,4,1,2,2,2,3,4,2,5,4,1,2,1,5,4,5,4,2,4,1,2,3,3,2,3,1,4,2,4,5,3,2,3,3,4,4,2,5,3,4,4,3,1,1,3,2,5,3,2,1,5,2,5,1,3,1,3,4,4,4,1,5,4,5,2,1,4,2,2,5,1,5,3,1,2,5,2,3,2,1,2,3,1,4,1,1,5,1,4,2,3,4,5,1,4,4,2,1,4,2,3,3,2,1,2,4,1,2,3,5,4,3,2,1,5,4,1,4,3,1,5,4,5,4,4,3,5,2,1,1,1,3,3,1,4,4,4,3,1,3,1,3,4,4,4,5,4,5,1,5,4,2,2,3,5,1,5,1,5,3,1,1,2,1,4,1,5,4,1,4,2,5,2,1,5,5,4,3,1,3,2,4,5,1,5,1,3,1,1,4,2,5,4,4,3,5,2,4,5,5,5,3,2,5,4,3,5,4,4,1,3,2,1,3,2,3,5,3,2,4,1,5,3,4,2,5,1,4,5,3,3,2,5,4,1,3,5,3,1,4,4,5,3,5,5,5,1,4,2,2,1,2,2,2,3,2,3,2,5,3,4,1,1,1,5,5,1,4,5,2,5,3,4,3,2,3,2,5,1,4,4,1,4,5,5,1,2,1,4,1,5,2,5,2,4,2,5,3,4,5,1,3,4,2,5,3,1,4,1,5,5,4,2,5,4,2,2,1,3,2,5,5,4,5,4,3,1,4,2,5,4,2,4,2,4,4,4,5,4,3,1,2,2,5,3,4,4,2,1,3,5,3,5,4,3,3,3,3,4,1,1,3,1,3,1,2,3,2,3,1,2,3,5,2,5,3,3,4,2,5,4,3,4,5,4,5,5,1,2,3,5,2,1,3,3,3,5,3,3,5,4,3,3,5,3,4,1,3,2,4,5,5,2,3,3,1,3,2,2,3,2,1,4,1,1,4,2,2,3,3,2,5,3,1,5,1,5,1,5,4,3,3,2,2,3,2,1,5,2,2,2,2,2,3,5,4,1,4,1,1,1,1,2,2,2,3,4,1,5,2,1,3,1,2,5,4,2,5,2,3,4,2,3,4,3,2,4,5,4,4,4,5,1,3,3,5,1,3,2,2,1,3,5,5,1,2,5,1,5,3,5,5,5,3,2,3,3,5,3,2,5,4,2,1,1,2,3,5,2,1,4,5,3,1,4,4,5,3,5,4,4,4,4,2,5,5,4,5,3,4,1,2,3,1,5,4,4,3,4,3,3,3,5,3,5,2,2,1,3,3,4,1,4,3,4,4,4,1,1,5,1,2,5,3,1,5,2,4,2,4,1,4,3,3,5,4,3,3,1,4,5,1,3,2,1,4,5,5,4,3,3,2,5,2,3,3,2,5,1,3,4,4,4,1,4,2,1,2,2,1,4,3,2,1,4,5,2,4,3,3,4,2,1,2,2,3,3,3,2,2,1,4,4,5,3,1,3,5,5,2,1,3,4,2,3,5,4,2,2,5,4,1,1,5,4,5,4,5,2,1,1,5,5,1,4,5,4,3,2,1,1,5,5,3,5,5,4,4,3,1,5,5,1,1,2,5,2,2,2,5,1,4,3,3,2,2,3,3,3,2,5,2,3,5,1,3,3,2,3,3,4,1,1,1,4,3,3,2,1,5,3,1,5,5,3,4,2,2,5,3,2,3,5,5,2,4,5,2,2,3,2,3,4,2,5,3,3,3,1,2,1,3,1,4,4,4,4,3,3,3,5,5,2,5,2,2,3,5,4,3,2,5,1,4,4,2,4,1,1,5,3,2,3,4,5,1,2,4,5,3,5,4,1,3,4,3,5,4,4,2,3,4,2,1,3,5,2,4,3,1,4,1,4,4,3,2,2,5,1,4,3,4,5,1,1,5,1,3,3,4,3,2,3,2,3,5,3,1,4,2,2,5,4,2,2,3,2,5,5,5,5,4,3,4,3,1,2,4,3,2,4,4,1,4,3,3,2,3,5,5,1,5,1,4,1,1,1,3,5,1,4,5,5,3,3,4,5,4,5,5,1,5,1,5,2,3,4,3,1,1,2,4,3,1,3,1,4,1,4,1,3,3,4,4,2,4,3,1,3,3,3,5,3,1,3,2,4,3,3,4,2,1,2,4,4,5,1,3,1,5,5,1,4,2,2,1,3,1,1,1,4,5,2,5,1,4,3,5,4,4,1,3,1,5,4,1,4,5,4,2,1,3,2,4,4,5,1,2,1,4,4,1,4,3,5,3,4,1,1,2,5,5,2,1,3,4,1,5,3,2,2,4,3,1,1,2,4,3,4,3,4,1,1,4,2,5,2,1,4,5,4,5,5,4,5,5,5,2,5,1,4,4,2,3,1,5,3,4,2,5,1,4,1,2,5,1,2,4,1,2,3,2,5,2,1,1,5,3,1,1,5,4,1,5,4,5,3,3,3,5,3,3,1,1,4,5,1,4,2,5,3,2,2,2,2,4,3,2,4,3,3,3,3,2,4,1,3,2,3,1,2,3,3,1,3,3,2,5,2,5,3,2,5,3,2,5,1,2,1,1,1,5,3,1,4,2,5,5,5,5,1,1,4,5,5,1,5,5,1,4,5,2,2,3,3,4,1,4,5,1,4,5,4,3,5,5,3,2,5,5,1,5,5,5,3,1,1,5,2,1,5,3,3,1,3,2,2,2,2,5,1,4,5,2,4,3,3,4,5,5,4,2,1,3,4,3,2,1,2,2,5,5,5,1,2,4,2,2,5,2,2,2,5,1,5,3,5,2,2,2,3,4,3,1,3,4,1,3,3,5,4,2,1,1,4,4,5,1,1,3,2,2,5,1,2,3,2,2,3,1,4,2,2,4,5,2,2,2,5,4,3,5,2,3,3,5,3,5,5,5,3,1,5,3,5,1,3,4,2,5,5,2,4,5,3,4,3,5,2,2,2,5,3,4,5,1,4,4,4,4,4,3,5,1,5,2,2,5,3,4,1,4,1,2,3,5,4,2,3,3,2,3,1,4,2,5,2,1,1,2,5,2,3,2,5,4,5,2,5,4,5,5,1,1,4,1,5,2,1,3,3,5,4,5,4,5,5,3,1,3,5,1,5,1,2,2,1,4,5,3,5,5,1,2,3,3,4,3,5,1,4,3,5,5,3,1,4,3,2,3,3,3,4,2,3,4,5,1,4,1,1,1,4,2,1,1,5,4,3,1,3,5,5,2,2,3,5,3,2,4,5,4,1,5,2,4,3,4,1,4,1,4,5,1,1,5,4,5,4,5,4,4,4,5,1,3,4,2,3,1,3,4,3,5,3,5,2,2,1,3,5,2,2,1,2,3,3,5,1,5,1,1,5,2,1,1,2,3,4,3,1,2,4,3,1,1,3,4,2,3,4,2,5,5,2,1,1,5,3,1,1,4,2,1,4,1,3,2,3,2,3,5,5,3,1,4,1,5,2,5,5,3,3,1,3,5,1,2,5,2,3,5,1,4,4,3,3,2,2,4,4,4,4,5,5,2,4,4,4,5,1,3,3,1,1,4,5,3,1,4,4,4,2,2,3,5,4,5,4,5,5,5,3,5,2,1,3,5,3,1,1,5,1,3,5,5,5,5,1,1,5,3,5,5,4,2,2,1,3,2,2,3,4,5,4,4,4,1,3,5,4,1,1,3,5,3,3,1,1,4,2,4,1,5,2,1,3,4,4,5,5,2,1,4,2,2,5,1,3,2,5,3,2,5,2,5,1,1,3,4,2,2,4,2,5,1,4,4,2,1,3,1,5,4,3,5,2,3,1,5,3,1,1,2,4,1,2,3,1,1,2,4,4,4,4,2,1,1,4,5,1,2,1,5,3,5,2,3,5,5,4,4,1,3,3,5,2,5,3,5,4,3,3,3,4,4,3,3,4,4,4,3,2,1,1,3,5,1,3,2,2,4,4,3,5,2,5,3,5,5,1,2,3,1,2,2,4,1,4,4,1,4,4,4,3,4,4,3,2,5,3,1,5,5,3,3,2,2,1,5,1,5,1,4,4,1,3,4,2,1,2,4,2,4,5,2,1,5,1,4,3,5,3,5,4,5,4,4,4,4,1,3,1,5,2,1,2,3,2,3,2,5,4,3,3,2,2,1,5,4,1,3,3,3,3,4,3,2,5,2,5,2,3,3,3,1,2,5,5,2,3,5,3,2,5,2,2,2,5,5,2,3,1,3,3,3,3,5,4,5,1,2,4,4,4,4,4,1,4,3,2,1,4,1,1,5,2,3,2,3,5,1,2,1,2,3,4,3,1,1,2,1,3,4,4,2,1,1,5,3,5,4,2,3,5,2,3,3,5,5,4,2,5,1,3,2,1,3,1,5,4,5,3,1,3,4,2,3,1,4,3,2,2,1,2,1,4,2,3,4,5,1,4,1,2,5,2,2,4,2,2,5,2,5,4,4,1,1,4,3,2,3,1,1,4,2,2,1,3,4,3,4,2,1,2,1,3,1,3,1,5,1,5,4,1,5,4,1,4,2,4,2,3,2,4,4,4,2,5,2,5,5,5,4,5,3,5,5,1,1,4,1,4,5,5,3,2,2,1,1,2,2,1,4,5,3,1,2,1,4,2,5,3,2,1,3,2,2,1,2,4,3,4,4,1,5,4,1,3,3,5,4,3,3,5,1,5,2,5,2,4,5,5,4,1,3,3,1,3,3,1,1,4,2,1,2,2,1,5,3,2,2,4,2,1,3,3,2,4,2,5,5,3,1,1,1,5,5,1,2,5,3,4,2,3,5,1,2,2,3,2,1,1,4,5,4,5,5,1,5,4,2,2,1,1,3,1,1,5,2,5,3,4,4,1,3,1,4,3,2,1,2,1,4,1,3,4,5,3,2,1,4,4,1,1,3,2,2,1,5,1,4,1,1,1,2,2,5,5,5,1,1,5,3,2,5,2,1,3,3,5,4,3,1,2,3,3,3,5,1,5,5,4,5,5,5,4,1,3,3,1,4,3,3,2,3,4,3,2,4,1,2,5,1,4,3,1,3,1,4,4,5,4,4,1,1,5,2,2,4,5,2,2,5,3,2,5,5,2,2,2,3,2,5,4,2,5,5,3,2,4,4,1,5,4,4,1,1,3,2,5,5,3,1,5,3,2,4,3,3,4,3,2,5,2,2,1,1,1,4,3,3,1,1,4,4,2,4,1,1,5,1,2,3,2,3,2,1,3,4,5,2,1,4,2,4,3,2,2,4,1,3,4,1,3,4,5,2,4,3,5,1,3,1,2,5,5,1,1,3,2,4,1,4,5,1,4,5,1,1,5,1,1,1,3,1,4,1,2,3,5,3,3,4,3,4,2,2,2,3,3,1,1,4,1,5,5,2,3,1,5,4,2,4,2,3,4,1,1,4,3,3,4,5,1,1,3,5,5,1,2,1,3,2,3,3,3,2,2,5,5,1,3,1,5,2,2,5,5,2,5,5,4,2,5,5,3,4,4,4,5,2,2,2,4,4,5,3,4,2,4,3,1,4,5,2,5,1,1,3,4,3,1,5,3,1,4,4,3,2,4,4,3,3,4,4,2,5,1,4,4,1,2,1,5,3,5,3,5,1,5,2,3,1,5,4,5,2,4,4,4,5,3,1,4,3,4,4,3,1,5,3,3,1,3,1,5,5,4,4,2,2,1,4,3,3,4,2,1,5,2,2,5,2,5,2,3,5,1,5,2,1,3,3,5,2,1,3,1,5,4,4,2,3,3,5,5,1,3,3,5,1,2,5,4,3,3,2,5,5,3,3,3,1,5,5,1,1,4,2,5,3,5,3,3,1,2,2,3,1,4,4,1,2,3,4,2,2,1,2,3,4,5,5,3,3,4,2,1,4,3,1,4,5,1,1,5,3,4,5,2,1,3,5,5,4,5,4,1,4,3,5,2,2,4,5,5,1,3,4,1,3,2,1,2,2,3,2,5,5,2,4,4,1,5,2,3,1,1,1,4,2,3,2,5,4,5,1,2,5,1,3,3,1,3,4,5,4,1,1,3,1,2,4,2,5,3,4,1,4,3,2,1,4,2,2,1,1,4,3,2,4,2,2,2,2,1,3,5,5,1,5,2,2,5,5,5,2,5,4,3,3,5,3,3,2,4,5,5,2,1,5,4,3,3,5,4,4,2,2,4,3,4,4,5,1,5,1,1,4,4,1,3,1,4,4,4,1,3,2,4,5,3,4,2,4,1,1,2,1,3,2,1,2,1,2,5,2,2,1,2,4,4,5,1,2,4,3,4,3,5,4,2,5,3,3,4,1,3,4,5,5,5,2,4,4,4,2,3,1,2,1,5,2,3,5,5,3,5,2,1,2,2,2,5,2,3,4,3,2,5,3,4,3,3,2,2,2,2,1,5,1,2,4,5,4,5,1,3,4,3,5,4,3,4,1,2,4,4,4,3,5,2,1,4,5,1,1,2,3,2,5,1,2,4,3,3,2,5,2,2,5,5,1,3,4,1,4,2,1,5,1,1,5,5,5,2,3,1,1,3,4,1,4,5,2,5,1,3,5,4,1,1,4,2,5,3,1,3,5,2,2,3,2,5,3,3,4,5,1,2,4,3,1,5,3,4,1,4,5,1,4,5,5,1,5,1,4,4,4,5,4,4,5,1,2,1,1,5,1,3,5,4,1,4,4,3,3,2,3,4,4,3,5,5,5,1,1,1,1,2,3,3,3,5,1,1,3,4,4,3,2,4,1,1,2,2,3,2,1,3,5,2,3,1,1,1,2,2,1,1,5,1,2,4,1,3,1,2,1,4,1,4,3,5,1,5,3,5,1,5,1,4,1,3,1,1,3,2,1,2,2,4,5,4,2,5,4,3,5,5,1,3,1,1,2,5,3,1,5,1,1,1,2,3,4,4,3,1,2,2,4,5,4,4,2,3,5,2,2,5,3,2,5,3,4,2,5,4,1,5,3,1,4,4,5,5,5,4,3,5,5,4,2,2,2,5,3,4,5,4,1,2,2,4,1,3,1,3,4,3,1,2,1,2,5,4,2,3,2,4,3,2,4,3,3,3,4,5,1,2,5,1,4,5,4,3,2,3,1,1,4,4,5,3,2,1,4,3,2,5,4,2,1,2,5,5,4,3,4,5,1,5,2,1,4,4,4,5,5,3,2,3,5,5,2,2,1,4,2,4,1,4,3,2,3,2,3,5,1,2,4,3,1,1,2,4,5,3,3,1,3,4,1,4,5,2,3,3,2,3,4,1,2,4,2,4,4,4,4,5,1,5,5,1,4,1,2,3,1,1,1,1,5,1,1,1,5,5,4,1,1,5,2,1,1,3,5,1,1,3,2,5,2,2,2,1,2,3,5,2,2,4,4,5,3,1,3,2,3,4,2,2,1,5,4,5,1,2,1,3,3,5,1,3,3,5,1,4,4,5,3,4,2,4,1,4,5,5,4,1,2,3,4,3,3,2,3,3,5,5,1,3,2,1,2,4,1,2,2,1,3,2,2,1,4,3,5,3,5,2,1,4,1,3,3,5,2,2,2,3,5,3,1,4,4,2,1,4,1,1,4,4,2,3,3,1,3,3,5,1,5,1,5,3,2,4,5,1,5,3,4,3,4,3,3,3,5,3,3,5,5,4,2,4,5,4,4,4,3,5,3,4,5,2,5,1,4,2,1,3,5,3,5,4,2,5,3,4,5,2,4,1,4,1,2,4,5,5,3,3,1,3,2,1,4,2,5,3,4,1,2,1,1,1,5,1,3,1,1,3,1,1,3,5,3,2,5,5,3,2,5,5,2,1,4,1,5,1,3,1,4,4,3,3,3,2,3,4,2,3,4,4,2,4,3,3,1,5,4,4,3,2,4,5,5,5,4,1,2,4,5,1,3,1,1,5,3,3,1,3,4,2,3,1,4,3,3,3,1,4,4,5,2,3,2,5,2,1,2,3,1,4,1,3,4,1,2,5,2,5,5,2,5,2,3,4,1,4,1,2,3,3,1,1,5,1,4,1,5,2,3,2,4,2,2,4,5,2,4,1,4,1,1,5,2,3,5,1,3,3,3,2,4,3,1,4,1,2,4,1,4,4,2,1,2,5,4,1,5,3,4,2,1,3,5,5,5,3,4,3,1,4,2,4,2,3,5,2,2,3,4,4,1,1,2,4,4,4,1,3,3,3,1,5,3,3,2,1,5,1,4,3,2,1,5,1,4,4,4,5,3,1,1,2,1,3,4,2,1,2,1,5,1,5,4,1,2,4,1,1,5,2,1,3,3,1,5,4,5,2,1,1,5,1,2,3,2,3,4,4,3,4,2,4,5,5,4,5,3,3,1,2,3,1,2,3,2,1,5,5,5,3,3,4,4,3,1,4,2,3,4,2,3,1,5,1,3,2,3,4,5,1,1,5,1,4,2,4,1,2,1,5,1,2,3,2,5,1,2,3,3,2,3,5,2,2,5,1,5,3,2,5,5,5,2,1,1,1,2,4,5,3,5,1,4,5,3,2,5,2,4,5,1,2,4,3,5,3,4,1,3,3,4,2,5,2,3,1,5,2,2,5,1,2,4,2,4,4,1,1,5,1,3,4,3,5,5,4,2,3,5,1,1,1,4,5,1,2,3,2,2,3,1,4,4,4,1,1,4,1,1,2,3,5,1,5,3,3,3,5,4,5,5,4,1,2,5,1,4,4,1,4,4,3,2,5,4,2,5,2,4,5,4,2,1,3,2,1,2,2,1,2,2,4,2,1,4,5,5,3,2,1,3,2,2,2,4,1,5,2,2,2,1,3,1,4,4,5,2,5,5,1,5,1,1,3,4,5,1,4,3,2,2,5,5,4,1,4,5,2,1,4,4,2,5,1,4,1,4,5,5,5,1,1,4,2,5,2,2,4,3,2,4,2,1,1,5,2,1,3,5,1,4,3,2,2,5,1,5,3,5,3,5,1,1,3,5,1,4,3,1,5,3,1,3,2,1,1,4,1,4,1,4,3,1,2,1,3,3,5,1,1,5,5,5,1,1,2,4,2,2,5,4,2,4,1,5,5,4,1,1,1,5,5,2,1,1,2,3,1,3,5,4,3,2,3,3,4,4,5,4,2,3,1,5,4,2,5,4,4,5,4,5,5,2,2,5,3,5,4,4,1,5,5,5,2,5,2,2,3,3,3,1,3,2,1,1,5,1,5,4,1,5,3,5,2,1,3,3,4,4,1,5,2,4,4,5,5,1,2,3,4,1,3,4,2,5,4,2,1,5,5,2,4,2,5,2,5,1,5,3,5,1,5,5,4,5,1,2,4,5,2,2,1,4,2,5,1,5,1,5,4,4,5,2,5,5,5,1,2,2,3,5,2,4,2,3,3,1,1,3,4,3,1,5,2,2,5,5,2,4,2,5,1,2,3,4,4,4,3,3,3,2,3,4,5,4,5,1,3,1,5,5,2,5,3,4,1,1,1,4,1,3,1,1,4,1,3,1,5,1,5,1,4,5,4,5,2,1,4,5,1,3,1,3,2,2,1,1,1,2,3,5,1,3,4,2,3,3,4,4,4,2,2,5,1,3,2,4,4,2,1,5,2,3,2,1,3,1,3,4,2,2,5,1,2,4,4,3,1,4,4,5,1,3,4,5,5,2,4,2,5,1,5,2,4,4,5,3,5,5,2,3,2,2,3,4,1,1,3,5,2,1,1,5,5,4,3,5,4,4,2,5,4,1,4,2,2,5,1,3,2,4,3,2,4,1,2,1,2,2,3,4,1,3,2,4,5,1,4,3,2,5,1,3,2,3,5,1,3,2,4,3,3,1,3,4,2,4,3,5,5,3,4,2,5,1,2,4,1,4,1,5,3,3,2,3,3,2,2,2,1,1,1,4,4,2,4,5,5,2,2,1,4,3,1,4,3,1,3,5,3,3,3,2,3,5,5,4,5,2,1,3,1,3,4,3,1,1,5,1,5,2,3,4,3,5,1,2,4,4,4,1,3,4,3,3,1,1,4,4,5,3,2,4,1,2,1,2,4,5,2,2,4,5,1,4,3,4,2,3,5,2,1,1,4,1,2,5,3,1,2,1,2,2,3,5,5,2,1,5,2,1,5,3,5,5,1,1,3,1,2,2,4,5,4,5,3,1,1,3,5,3,1,4,3,4,2,4,4,1,2,4,3,2,4,4,2,5,5,2,1,4,5,4,2,1,2,4,1,4,4,2,1,2,3,1,3,1,5,2,3,2,1,2,3,5,3,5,4,3,1,3,5,3,3,1,5,5,4,4,5,1,5,1,2,3,1,5,5,5,5,2,2,3,5,3,1,2,4,3,1,1,4,4,2,4,3,5,1,2,2,5,5,4,5,2,3,4,1,4,1,4,3,4,1,3,5,4,5,1,1,1,5,1,2,3,2,5,5,4,2,3,3,3,3,3,5,5,5,4,3,1,4,2,5,2,1,2,3,4,4,2,5,2,2,5,2,1,3,1,3,2,3,5,3,1,1,3,3,2,1,2,4,5,5,4,2,5,3,3,1,1,4,3,1,4,4,3,1,3,5,3,5,5,4,1,5,4,5,1,4,4,1,1,2,4,3,4,2,5,2,1,4,2,3,3,3,2,5,2,4,2,5,1,3,4,5,4,5,3,4,3,5,3,5,3,3,1,3,4,2,1,4,4,2,2,4,5,4,3,4,5,5,2,4,5,4,3,4,5,2,2,3,1,4,4,1,1,4,3,2,5,2,1,2,4,5,4,2,1,1,3,3,2,3,2,1,5,2,3,1,3,5,1,4,4,4,3,2,2,1,5,5,1,1,5,5,5,2,3,1,5,3,4,1,5,5,4,5,4,5,4,5,2,1,2,4,4,2,1,4,1,4,5,4,3,1,1,4,5,3,1,1,2,4,2,4,4,2,1,4,2,1,3,1,3,2,2,1,2,1,4,2,4,3,5,5,4,3,4,4,4,1,3,1,2,4,3,4,3,3,5,2,4,4,4,4,3,3,1,5,4,1,3,1,3,4,1,3,1,1,4,2,5,2,2,4,3,1,2,3,1,3,5,1,2,1,1,3,2,2,2,1,1,2,4,4,3,5,2,1,2,3,3,4,4,3,3,1,3,3,5,2,5,3,1,4,4,2,1,1,5,3,2,3,4,1,4,3,5,4,5,1,3,5,4,1,1,2,2,4,4,2,1,3,3,1,5,2,4,4,2,2,5,4,5,1,2,4,1,3,3,3,5,5,5,5,3,5,4,5,4,4,5,5,4,4,2,4,4,1,2,1,1,3,1,1,5,4,1,5,4,3,2,2,4,2,2,5,4,2,3,1,3,3,4,2,1,4,1,5,2,2,5,1,3,3,2,1,4,5,1,1,5,5,5,5,4,1,3,3,4,1,1,2,1,2,1,4,3,4,3,5,2,1,4,3,1,3,1,5,3,3,5,2,1,2,3,3,1,5,5,5,3,3,1,4,4,3,3,1,5,1,5,2,2,4,3,5,5,2,4,4,1,2,4,5,2,5,1,3,4,3,1,3,2,5,2,4,4,4,3,4,4,3,4,2,5,3,3,4,5,3,5,3,2,4,2,5,1,1,2,1,2,4,5,5,4,2,5,2,4,2,2,1,4,1,2,3,3,1,4,1,3,1,4,2,1,1,4,5,4,5,1,5,5,5,3,1,2,5,4,3,4,5,4,5,4,1,2,3,2,2,2,4,1,2,1,4,3,3,3,4,4,4,3,4,5,4,4,4,5,5,4,3,1,2,5,3,5,4,4,4,3,4,5,5,5,4,3,5,5,1,5,3,5,5,3,1,4,4,4,5,1,3,1,4,5,4,1,3,2,3,2,4,1,4,5,5,5,4,1,3,4,5,1,2,3,4,2,1,1,2,3,2,3,3,5,3,5,1,5,5,1,3,3,3,1,4,2,5,2,3,1,3,3,2,2,3,3,5,2,1,1,5,4,4,5,2,4,2,1,3,5,1,4,4,2,4,5,3,1,3,5,3,4,2,1,5,5,2,4,1,4,5,1,5,5,4,1,3,3,3,3,2,4,2,1,2,2,4,1,1,2,1,5,1,4,3,3,2,1,2,2,4,3,3,3,3,3,1,4,5,2,3,5,1,5,4,1,4,1,1,3,2,3,5,5,2,5,3,4,3,4,5,2,3,1,2,4,2,3,3,4,3,5,3,2,3,3,2,1,2,3,1,4,3,3,4,1,5,4,4,4,3,3,2,1,2,4,3,3,4,1,1,5,1,1,4,4,3,4,2,2,2,5,2,1,4,4,3,5,3,3,1,1,5,1,1,5,5,1,5,5,5,1,3,4,2,2,4,2,5,3,2,2,2,4,4,4,1,4,4,4,3,5,3,2,4,3,1,1,3,4,3,2,3,1,1,5,3,2,2,4,2,1,5,5,5,3,2,1,1,5,1,4,1,3,1,1,2,5,5,1,4,5,1,5,5,1,3,2,2,3,4,3,2,1,4,4,5,2,1,3,3,4,4,3,4,3,3,3,5,2,3,5,1,5,2,3,1,5,4,1,5,1,2,4,4,5,2,2,5,3,4,3,5,2,1,5,4,3,5,3,4,4,4,2,3,4,4,3,4,3,2,1,2,5,2,2,5,3,4,4,4,4,4,3,1,2,5,4,4,4,2,4,5,2,5,1,4,5,1,5,5,2,3,5,1,5,5,1,2,2,1,5,4,5,3,5,3,4,4,3,1,2,3,4,3,3,2,5,4,5,3,4,3,3,4,3,1,4,3,3,4,1,2,4,5,4,1,2,1,1,5,5,3,3,3,5,2,3,2,1,5,1,1,1,2,2,1,1,3,3,1,2,5,5,3,4,2,1,2,3,1,3,2,3,5,1,3,5,2,4,4,2,1,1,3,4,3,2,2,5,2,5,3,1,2,1,3,5,1,1,3,5,2,4,3,1,2,4,1,4,5,1,5,5,3,1,5,1,2,2,3,4,3,4,1,5,5,1,3,5,3,5,1,1,5,2,1,4,5,1,4,3,5,4,4,5,2,4,4,3,3,5,4,5,2,3,3,1,5,2,5,4,5,3,5,1,2,4,2,3,1,5,5,3,5,5,4,4,2,3,1,1,3,5,4,4,3,4,5,5,5,2,4,2,5,4,1,4,4,2,2,1,1,4,4,5,5,2,1,2,1,1,2,4,1,1,3,5,2,1,5,5,4,1,3,5,2,4,1,1,2,1,4,1,3,3,3,3,5,2,5,1,1,4,3,1,5,2,2,2,5,5,4,1,3,2,3,4,3,5,4,3,3,4,4,4,2,4,1,4,5,5,1,2,5,1,2,5,2,2,2,3,2,4,1,5,2,4,5,1,4,2,4,3,3,3,2,4,5,4,4,4,2,1,4,5,3,2,4,1,3,1,4,2,5,5,2,3,1,2,5,1,4,2,5,1,2,1,1,5,3,4,1,1,3,5,3,2,4,5,2,2,3,5,3,5,1,4,1,4,2,2,2,5,4,3,3,2,1,2,4,1,4,5,3,1,5,1,1,2,2,4,2,2,3,2,4,3,3,2,2,1,3,2,5,1,2,5,2,3,3,3,2,2,5,2,2,1,1,3,5,3,3,4,5,3,4,5,5,5,5,4,2,3,4,4,1,1,5,4,2,3,4,4,1,1,5,3,2,2,5,3,1,3,2,2,4,1,1,2,5,5,2,3,5,3,4,4,2,3,4,3,2,3,3,1,1,3,5,5,4,3,4,1,2,1,3,1,3,4,3,3,4,2,5,1,3,3,5,5,3,2,5,5,3,2,4,5,4,2,1,5,3,4,1,4,4,2,2,5,5,3,3,5,5,3,1,5,3,2,4,1,3,1,2,5,3,1,5,5,4,1,3,4,1,1,2,4,1,3,4,1,2,4,4,1,1,3,3,5,3,4,5,4,2,1,1,3,1,3,4,4,5,4,4,3,4,3,4,2,4,4,2,1,1,5,1,1,5,5,4,1,3,3,5,1,4,4,1,3,3,4,1,2,1,2,2,5,3,5,3,1,5,2,3,1,5,5,4,4,1,3,3,5,3,1,4,3,5,2,1,1,2,4,2,3,3,2,5,3,5,2,5,1,4,3,1,3,2,3,1,2,2,2,1,1,4,4,5,4,4,2,3,2,2,2,2,1,2,5,5,1,5,4,1,5,1,5,5,3,1,5,3,2,1,2,5,3,5,3,5,5,4,3,3,2,1,5,5,1,3,2,1,4,5,4,5,3,3,2,4,2,3,2,2,3,1,3,1,3,2,4,5,5,2,1,1,4,2,3,4,2,4,2,2,5,5,2,4,4,1,5,5,1,5,1,3,5,4,1,2,5,1,3,5,3,1,3,1,1,5,2,4,5,1,1,2,5,4,5,4,5,3,1,4,3,2,5,1,1,3,2,3,5,3,1,1,5,3,5,3,4,3,1,2,3,1,3,1,4,2,1,1,2,2,2,5,2,3,2,1,2,4,3,4,2,4,5,1,3,3,1,2,3,5,2,4,1,3,5,4,5,4,2,1,3,4,4,1,4,4,4,5,3,2,4,2,3,4,4,4,5,1,3,1,4,4,1,5,2,2,5,5,1,1,2,4,3,5,4,3,4,1,5,2,5,1,5,5,3,1,1,4,4,2,2,2,2,4,3,3,3,5,4,5,1,2,4,4,2,3,5,3,5,5,5,2,2,2,2,1,4,2,3,1,3,1,2,1,3,4,5,5,3,1,1,5,4,2,3,1,4,4,3,2,1,1,2,4,5,5,2,4,5,3,4,5,5,3,3,2,1,5,1,2,2,5,1,1,2,5,2,4,4,3,1,3,1,5,5,5,4,4,1,2,4,4,2,5,5,3,3,2,5,3,3,3,3,4,5,2,5,1,3,1,1,2,3,5,2,3,1,2,2,4,1,1,3,5,1,1,3,4,5,4,5,5,3,3,4,3,1,1,2,3,1,2,3,1,5,4,5,1,1,1,5,5,3,3,3,1,4,3,3,3,2,3,4,5,4,2,5,5,5,3,2,3,3,5,1,4,3,4,2,1,4,4,5,2,4,3,5,1,3,1,5,4,1,1,1,4,1,4,3,2,4,1,3,1,2,3,5,3,2,1,1,3,5,1,1,1,2,2,1,5,4,4,4,1,1,3,1,2,4,2,5,4,3,2,5,1,2,3,5,3,2,5,5,2,1,5,5,2,4,4,3,5,3,2,1,1,4,2,1,1,2,5,5,3,3,1,4,1,1,5,1,1,2,2,5,2,4,4,2,1,2,3,3,3,2,3,1,2,4,3,5,4,3,3,4,5,3,2,2,4,1,4,5,4,2,4,2,2,4,3,3,5,5,2,4,3,4,1,1,3,1,5,1,2,1,4,5,4,3,5,2,1,3,4,5,5,4,2,3,2,3,5,2,5,3,1,2,4,5,2,4,3,4,4,1,4,3,2,5,5,2,5,1,1,2,1,1,2,4,5,2,3,2,2,1,2,5,2,1,4,2,1,3,5,5,2,4,4,2,4,5,3,3,4,3,3,3,2,1,5,1,4,4,1,4,3,1,1,5,4,4,3,5,5,4,5,1,2,5,4,3,1,2,3,3,3,3,2,4,4,5,1,4,1,1,5,5,3,5,5,1,5,1,4,2,5,1,1,1,2,2,2,1,5,5,1,2,5,4,1,5,4,1,5,4,4,4,3,3,2,2,4,3,5,1,1,2,1,3,5,4,5,1,5,5,3,5,4,2,4,2,1,4,3,2,3,3,2,3,5,4,4,5,2,2,5,4,3,1,4,4,4,3,5,4,3,2,2,1,2,4,2,2,5,1,5,4,2,4,2,4,1,2,4,5,3,3,1,2,2,2,1,2,4,5,3,2,1,1,3,3,1,2,4,3,3,3,3,2,2,4,3,5,1,5,2,2,1,1,1,1,4,1,1,3,4,5,2,1,2,1,2,5,1,4,2,1,3,2,1,3,3,3,4,1,1,3,5,1,2,1,2,5,3,3,2,5,3,4,5,2,1,3,2,5,3,1,5,3,5,3,2,2,2,4,4,1,4,2,2,1,3,3,1,5,3,3,1,5,3,2,5,3,3,2,4,2,5,3,3,3,2,4,3,1,2,4,2,5,1,2,4,3,2,2,2,1,2,2,2,1,5,2,3,4,2,3,3,3,3,5,3,1,1,5,5,1,3,2,1,2,1,5,2,3,2,5,1,3,3,1,3,2,1,1,3,1,2,1,4,4,4,3,1,1,1,3,3,1,5,2,3,1,5,3,2,4,4,5,1,1,4,3,1,3,2,4,2,3,4,2,1,4,4,3,3,2,3,2,1,5,1,4,4,4,2,3,1,3,1,3,1,2,2,4,3,4,4,5,3,5,1,3,5,3,5,3,3,3,3,2,4,1,4,1,4,1,5,1,3,3,4,1,1,3,4,4,4,5,4,1,5,5,3,1,5,2,4,3,4,3,1,1,5,4,1,2,3,2,2,4,3,4,3,5,2,4,3,4,4,4,5,5,2,5,4,2,1,2,4,3,4,5,4,1,3,2,1,1,5,1,4,2,4,3,4,1,1,4,1,2,4,5,4,3,4,4,4,3,2,5,5,4,5,5,5,4,4,4,3,4,4,2,3,4,2,4,3,3,5,5,3,4,5,2,1,1,4,5,4,5,3,2,3,5,4,1,4,3,1,4,4,3,4,4,4,2,4,1,1,4,3,4,1,3,5,3,5,1,4,3,3,3,1,4,2,4,5,2,1,5,3,5,1,5,4,2,1,3,4,1,2,1,1,5,3,2,5,3,3,3,1,4,3,1,4,1,3,5,4,1,2,4,1,2,4,4,4,4,2,1,3,1,2,2,4,5,4,5,3,1,1,2,5,3,5,2,2,2,5,2,4,4,2,1,2,4,2,5,4,5,2,1,1,5,2,4,5,1,2,5,4,4,5,4,1,2,3,3,4,4,1,3,5,5,2,5,4,1,3,3,3,5,4,3,2,2,5,2,5,3,3,3,3,1,3,3,2,3,2,1,3,2,3,1,3,3,3,1,5,2,3,2,2,4,5,3,1,5,4,1,1,1,4,5,3,1,3,1,1,4,4,1,2,2,2,4,2,3,3,3,2,2,3,2,5,3,4,5,1,5,5,1,3,1,3,4,1,5,3,4,2,5,2,4,2,5,2,4,5,1,2,2,1,2,2,5,5,3,4,4,1,3,2,2,4,5,2,2,2,3,4,5,5,3,3,1,4,4,4,5,2,3,5,3,5,1,4,4,4,1,2,1,2,2,4,2,3,5,1,3,3,1,5,2,5,5,3,4,2,3,1,5,4,1,5,3,3,5,1,3,3,4,2,4,3,3,5,1,4,2,2,5,2,3,2,1,4,1,3,4,2,4,3,5,1,4,5,3,5,5,5,4,4,1,2,5,1,5,1,4,1,5,2,4,5,5,1,4,1,4,5,4,4,1,3,3,3,5,5,4,4,4,4,1,2,2,3,1,4,5,1,4,1,5,1,1,5,1,5,4,4,1,4,3,2,2,5,2,3,5,4,2,2,4,4,1,1,3,3,1,5,3,3,5,4,5,1,1,2,1,3,5,3,3,5,2,5,5,1,1,3,2,4,4,5,3,1,5,3,2,3,1,3,3,3,1,5,5,2,5,2,3,1,5,2,5,5,4,3,2,1,3,1,5,3,4,1,4,4,5,1,4,3,3,2,4,3,5,4,5,2,4,5,4,5,4,4,5,4,1,5,4,3,1,5,5,4,4,1,5,4,4,5,2,5,1,1,4,5,3,5,5,2,3,1,4,4,1,5,5,3,5,5,4,1,4,3,2,2,4,1,1,1,3,4,3,1,4,3,1,2,5,2,3,5,5,3,3,5,4,3,4,3,3,1,1,5,2,2,2,4,1,1,5,5,2,1,5,1,2,1,3,5,3,3,3,4,1,2,3,3,4,2,4,4,3,4,3,1,4,4,5,3,5,3,2,5,5,1,2,4,4,2,2,3,5,5,3,3,1,1,1,2,5,2,3,5,3,3,2,1,2,4,4,4,2,1,1,3,5,3,4,2,1,1,3,2,4,5,4,2,3,2,1,3,1,4,2,4,3,5,5,1,1,3,4,5,1,4,5,3,2,3,2,4,1,1,2,5,2,4,4,3,5,4,3,5,4,4,5,4,1,3,5,2,2,2,4,4,3,4,1,3,1,3,2,5,5,2,3,4,3,2,1,5,5,3,5,1,3,1,3,1,5,1,3,2,1,5,1,4,2,5,1,1,3,3,2,5,1,2,3,2,5,5,5,2,3,2,5,2,4,5,4,1,5,4,1,5,5,5,4,1,1,3,4,2,2,3,2,4,1,5,4,1,5,3,2,1,5,4,3,2,4,3,5,3,5,3,5,4,3,4,5,2,3,4,5,4,2,2,3,5,4,4,2,5,1,2,2,5,3,3,4,4,1,5,1,4,2,2,5,5,3,4,2,3,4,2,4,1,3,1,1,1,5,5,3,1,2,1,3,2,4,1,1,4,1,5,4,2,4,5,1,3,2,3,5,3,1,1,4,3,4,3,5,3,2,1,1,3,5,2,4,4,2,5,3,4,1,1,2,3,1,1,5,3,2,5,4,2,5,1,5,1,3,4,3,1,1,1,2,1,3,5,1,4,1,4,1,1,5,2,3,1,4,4,1,4,1,4,4,2,4,2,5,1,4,5,5,5,4,4,1,4,5,4,3,5,3,3,1,5,4,5,1,2,4,4,3,1,5,3,3,4,4,2,1,5,3,4,3,1,1,5,5,4,3,1,4,2,3,2,4,1,3,1,4,4,5,3,1,3,4,1,5,1,4,3,3,5,5,3,3,1,3,3,2,2,1,2,1,5,2,3,1,4,1,3,5,2,2,1,5,2,2,2,5,2,3,4,1,2,3,4,5,2,5,1,3,3,4,2,5,1,5,2,1,3,1,1,4,3,5,3,4,3,5,2,1,5,5,3,2,5,2,4,5,3,5,3,2,4,5,3,1,1,5,3,2,3,3,4,3,5,3,5,4,2,3,1,3,3,3,1,4,3,5,5,1,5,5,3,4,5,5,4,3,4,4,4,5,4,1,5,1,2,2,5,3,2,1,4,1,3,5,5,2,3,3,1,5,5,2,3,2,4,4,2,4,3,5,2,5,3,5,5,4,4,4,5,5,4,4,1,3,4,4,1,3,4,3,5,2,3,2,4,4,5,1,1,1,4,5,2,3,3,4,3,2,1,1,2,1,5,3,3,3,4,5,1,1,3,4,5,1,3,4,3,1,5,5,5,1,1,1,5,3,1,2,4,4,1,4,2,5,4,3,3,5,1,4,2,1,2,3,2,4,5,5,4,3,3,1,2,5,1,3,2,2,4,2,3,5,1,5,5,5,5,3,4,1,3,3,4,4,4,5,1,2,4,3,3,1,2,2,3,5,4,4,4,5,3,3,1,2,1,2,3,4,2,4,1,5,2,1,4,2,1,1,4,4,3,4,4,4,4,4,2,4,2,3,1,2,1,4,1,5,5,2,2,5,2,5,5,3,5,4,2,4,1,1,1,5,3,2,4,3,3,3,4,2,5,4,5,4,3,5,4,5,4,2,4,1,1,1,3,3,1,3,2,5,5,3,4,5,1,5,5,1,3,2,2,3,5,2,3,3,1,5,5,2,5,4,2,5,1,2,5,1,1,3,1,1,4,5,1,1,1,3,3,1,2,1,3,4,1,1,5,3,3,2,1,4,1,3,4,5,4,5,4,1,2,4,4,1,1,4,4,4,1,1,2,2,5,5,1,5,4,2,5,1,5,3,4,4,4,2,5,1,1,2,5,4,2,5,5,4,3,4,5,4,4,3,5,2,5,4,1,1,2,4,4,3,1,2,4,4,3,1,1,2,5,4,2,5,2,5,5,2,3,2,2,4,3,4,4,5,3,2,4,4,3,5,2,5,4,4,2,4,5,4,1,2,4,3,3,3,3,3,4,5,4,4,4,2,3,2,4,1,5,1,2,1,2,5,3,5,1,2,2,4,3,4,4,5,1,3,1,4,5,5,4,4,3,5,3,1,4,3,5,5,3,3,2,5,5,2,2,2,1,3,3,3,5,2,1,2,5,4,1,1,1,4,2,3,2,3,5,3,2,4,5,1,3,3,5,1,2,2,3,3,5,2,2,4,2,3,1,5,5,4,1,4,2,5,4,4,5,3,3,1,5,4,5,5,2,4,1,4,3,5,4,1,5,5,3,2,5,2,3,4,5,2,1,5,1,4,3,4,2,2,3,3,5,4,2,2,4,4,5,2,1,5,4,2,1,5,1,2,1,4,3,5,1,4,1,2,4,3,3,5,1,1,1,4,3,4,2,1,3,3,4,5,2,1,4,5,4,2,1,2,5,4,3,2,1,2,4,4,3,4,3,3,4,5,3,2,1,1,1,3,4,5,4,3,5,5,5,3,2,2,4,5,4,1,5,2,1,5,5,3,3,5,5,3,1,1,5,1,1,4,3,2,4,2,1,1,1,2,1,3,4,4,1,2,4,4,5,4,1,5,3,5,2,4,3,4,3,4,1,3,2,3,1,5,5,5,2,3,3,4,1,2,2,5,5,1,4,3,2,1,1,1,2,3,3,2,1,5,1,3,5,3,5,2,4,3,3,4,4,5,2,4,2,1,2,4,4,3,3,3,2,1,3,4,3,3,3,2,5,3,3,4,2,2,2,2,1,1,5,5,5,3,5,5,1,2,5,1,3,1,2,4,4,1,1,4,4,4,3,4,4,2,3,1,3,4,3,4,2,5,4,5,4,1,2,4,3,5,5,2,1,1,1,1,4,2,2,3,4,1,2,5,2,5,1,2,4,1,2,3,1,3,1,3,4,4,1,1,1,2,3,2,5,4,3,4,5,2,4,1,3,2,4,4,5,3,2,2,5,2,5,4,5,3,4,4,5,2,2,1,1,2,2,5,3,5,4,5,4,2,3,1,3,4,4,2,1,3,5,2,5,2,4,3,1,3,2,3,4,3,3,1,2,1,4,5,1,1,4,2,4,1,1,3,5,2,5,2,1,1,3,2,2,4,2,4,4,5,3,1,2,4,4,4,1,3,2,1,5,2,3,5,3,5,2,5,5,2,2,5,3,4,1,3,2,2,5,2,4,4,3,2,3,3,2,3,4,1,3,1,3,5,2,5,2,4,1,4,2,2,4,2,1,1,4,3,1,4,1,1,1,4,1,3,2,5,3,5,4,1,3,5,3,1,5,2,4,2,1,2,2,4,1,2,3,5,2,5,1,2,1,3,2,4,2,2,1,3,3,4,5,5,1,4,3,2,3,3,4,1,4,5,4,5,4,2,5,3,2,1,4,5,4,2,3,3,3,3,4,2,1,3,4,2,1,3,3,3,2,2,2,2,3,4,2,2,2,1,1,4,5,3,2,2,5,5,5,4,1,1,4,2,5,2,5,4,1,4,5,2,1,2,2,4,1,3,1,4,1,1,1,5,3,5,5,2,3,4,5,4,4,1,4,3,4,2,2,2,3,5,1,1,2,4,5,3,2,5,1,5,2,4,4,5,2,3,4,1,4,4,3,3,1,3,2,3,5,3,3,4,1,3,4,2,3,3,3,3,5,2,1,2,5,5,3,4,5,2,1,4,2,2,5,3,4,4,4,3,5,4,3,5,5,3,2,3,3,5,5,3,5,3,1,3,4,3,3,2,2,1,3,5,2,3,4,3,2,1,4,4,4,5,4,3,5,2,2,5,4,4,1,1,3,2,4,4,3,3,2,5,4,5,1,2,2,2,2,4,4,1,2,4,2,5,5,4,3,2,4,4,1,2,4,5,2,4,3,3,5,5,4,1,5,1,3,2,1,1,5,3,1,5,3,3,4,5,1,4,5,5,2,1,1,4,3,3,1,1,2,1,2,1,2,2,2,4,2,3,2,4,4,2,2,3,4,3,4,4,3,5,5,1,4,3,1,4,5,3,5,3,4,3,4,5,1,2,5,4,1,5,4,4,5,3,1,3,4,5,5,5,1,1,5,1,5,2,5,2,5,5,1,1,1,3,2,3,4,5,1,3,5,3,1,5,5,1,2,3,3,5,4,1,5,4,1,3,2,3,2,2,5,3,5,5,1,5,4,4,4,1,3,3,1,4,4,2,2,4,2,3,5,4,1,3,1,4,2,4,1,2,3,2,1,3,1,4,4,5,4,5,3,4,2,4,4,1,1,5,2,4,4,4,2,5,2,2,3,2,4,3,4,3,1,2,5,3,1,2,5,5,4,4,5,2,3,2,2,4,3,3,1,5,3,2,4,3,5,2,1,1,3,3,1,1,1,1,1,2,2,4,3,4,2,3,1,4,1,4,4,2,3,4,2,2,1,3,4,4,5,4,4,1,1,2,3,3,4,1,5,5,4,3,1,5,5,1,4,3,4,2,2,2,2,3,4,4,5,5,1,5,4,5,2,2,5,4,5,2,4,4,3,2,3,4,2,2,3,3,1,2,3,1,3,4,3,1,4,5,5,5,5,3,3,5,1,1,5,2,1,1,4,1,4,1,2,1,4,4,3,1,1,1,3,3,5,3,2,4,1,5,5,3,3,3,4,5,1,5,5,2,1,4,5,4,4,4,2,3,1,3,1,1,4,2,5,5,2,1,1,3,2,1,1,2,4,3,4,3,4,1,4,4,4,1,4,1,3,2,4,1,5,1,1,5,1,2,5,5,5,3,2,1,5,4,3,3,4,4,4,2,1,1,1,1,1,2,3,2,5,5,5,5,2,3,1,4,3,1,2,4,5,5,1,1,2,3,3,2,2,2,2,3,3,3,1,5,2,2,1,1,1,1,4,5,1,4,4,2,4,1,5,1,1,2,2,1,2,2,2,4,4,2,1,3,3,3,4,5,1,3,3,5,3,2,4,4,2,1,5,4,1,1,3,3,3,4,5,1,3,1,1,1,5,1,2,2,2,5,2,5,4,2,1,3,4,5,4,4,1,4,5,4,2,3,2,2,4,4,5,1,2,3,1,4,3,4,5,5,2,1,1,1,4,2,3,1,1,2,4,4,5,5,5,1,3,3,5,2,3,2,3,5,4,3,3,3,1,3,1,1,2,1,4,4,2,3,2,2,3,1,1,1,4,3,1,1,5,2,3,1,3,2,1,2,2,1,2,2,4,1,4,4,1,2,2,2,1,3,1,5,4,2,2,4,3,3,2,1,5,5,2,5,5,3,3,5,3,4,3,2,5,3,2,4,5,4,1,5,5,1,5,2,5,1,4,5,1,1,4,5,1,1,2,3,2,5,3,3,5,5,3,4,1,4,4,2,5,5,3,5,1,1,4,4,4,2,5,2,3,5,4,2,1,5,5,5,2,3,3,3,2,3,4,3,4,2,5,1,3,4,5,1,2,5,1,2,5,1,5,5,5,2,2,3,2,3,5,5,4,1,1,4,4,5,1,2,3,4,5,3,1,5,3,4,4,1,3,4,1,5,1,3,4,2,2,4,3,1,1,1,5,3,3,5,5,3,5,5,5,4,1,1,1,4,2,1,2,2,1,1,4,5,5,4,5,1,5,2,3,5,1,5,4,4,4,5,3,2,4,5,3,5,1,5,5,4,2,4,1,5,3,4,3,3,1,2,4,4,1,3,4,4,4,4,2,3,3,2,2,1,5,5,2,2,5,2,4,1,2,1,2,2,3,5,2,1,4,3,3,4,5,5,1,5,1,3,5,3,2,1,3,2,4,2,2,3,1,4,2,4,2,2,3,1,2,2,1,2,4,3,4,3,4,2,4,2,5,2,2,5,3,2,3,1,2,2,5,5,2,3,1,1,5,1,1,2,4,2,5,5,3,5,3,4,5,3,2,3,5,5,5,4,3,5,2,2,4,1,5,3,2,4,1,4,3,1,2,3,2,1,5,5,1,3,3,3,4,2,1,4,4,3,4,2,2,4,3,1,3,4,4,5,5,2,3,1,4,4,2,5,5,3,4,1,1,1,2,5,5,2,3,2,3,1,1,3,1,1,3,3,1,2,4,4,4,2,3,1,5,3,4,1,2,5,3,5,4,3,5,2,3,5,2,3,2,4,4,4,4,3,4,2,4,5,4,1,5,1,2,4,4,3,1,4,5,4,4,3,5,1,3,1,5,4,2,3,5,3,2,4,1,1,4,2,1,5,3,2,2,3,4,1,1,4,5,1,4,5,5,4,3,4,3,5,3,5,3,4,3,2,1,4,2,1,3,5,4,3,5,3,4,4,5,3,3,1,5,5,3,5,2,3,4,2,2,2,1,2,3,1,4,2,2,1,4,1,2,3,2,5,5,5,4,2,1,3,5,4,4,4,1,5,5,2,5,3,1,5,1,1,5,4,3,1,3,1,5,4,4,2,1,5,3,3,1,3,4,4,4,5,4,1,5,1,1,3,5,2,2,1,5,4,2,2,4,1,2,4,4,1,3,2,4,5,1,2,2,5,4,3,4,5,2,5,5,1,3,4,5,4,5,3,1,2,3,1,3,2,2,1,3,2,3,5,2,4,1,1,3,4,1,5,2,1,4,2,1,4,1,4,5,5,2,4,4,5,4,1,2,5,5,4,1,1,4,3,2,4,1,2,1,5,1,2,4,3,5,1,2,3,1,5,5,3,4,2,4,4,3,1,3,5,5,4,1,5,5,1,4,1,5,1,3,4,5,5,2,2,3,1,3,3,2,2,1,4,3,1,2,3,5,4,2,4,1,3,4,4,3,2,3,3,3,4,3,4,3,3,1,2,4,3,5,2,5,2,5,3,3,4,5,1,1,3,2,3,1,4,2,5,1,5,5,3,2,2,4,4,4,3,2,4,1,4,4,5,1,5,2,5,3,2,5,5,5,3,4,2,5,3,3,1,3,3,2,4,1,5,3,2,4,1,1,2,3,4,5,4,5,4,4,1,5,2,1,4,4,1,3,2,4,4,2,5,2,5,1,2,5,3,4,1,3,2,2,1,4,1,4,4,1,5,2,2,4,1,4,4,2,4,5,4,5,4,4,3,4,3,1,5,4,3,4,4,2,1,2,2,4,5,5,5,5,4,3,1,3,2,5,3,5,1,5,3,1,2,4,2,3,1,4,1,1,4,1,1,1,2,2,4,2,4,4,3,4,2,4,1,4,4,3,2,5,5,4,3,3,1,5,5,1,2,4,4,4,2,3,3,2,5,4,1,5,2,3,5,2,2,5,1,2,3,1,2,2,4,1,3,2,3,4,1,1,1,5,1,4,3,5,3,3,5,2,1,5,1,1,1,3,5,4,5,4,5,4,1,1,5,2,3,2,2,4,1,4,3,1,1,2,1,4,1,5,5,5,1,4,2,2,2,1,5,4,5,4,4,3,3,4,4,1,5,1,1,4,5,3,4,1,1,5,5,2,1,4,1,2,2,1,1,4,3,4,5,2,5,1,4,1,1,4,5,1,2,4,1,4,4,3,5,4,4,2,3,1,2,2,4,5,3,3,2,2,2,5,2,3,2,4,2,1,2,5,5,4,1,3,3,2,5,4,2,4,1,4,3,3,4,2,5,3,3,1,5,2,4,4,1,5,5,3,5,2,5,4,1,2,3,4,1,4,2,5,4,4,2,3,5,2,5,5,4,1,3,5,2,3,3,5,1,5,3,5,4,3,3,1,3,2,1,2,2,4,2,1,2,1,3,1,4,4,4,1,4,2,2,1,3,3,3,4,4,5,3,3,1,3,2,2,1,3,4,2,3,3,3,4,3,3,1,5,2,2,1,4,1,1,1,5,2,4,1,2,5,2,3,5,1,3,5,5,2,1,3,5,3,5,5,4,2,4,1,2,5,5,2,2,5,2,5,3,2,4,1,1,5,1,2,5,2,4,1,1,3,5,1,2,4,2,3,5,5,2,3,5,1,2,3,4,4,4,5,3,2,1,3,1,1,2,4,3,2,5,1,5,4,2,3,3,1,4,2,5,5,5,3,5,5,5,1,3,4,5,4,4,4,2,3,3,4,4,5,2,1,1,3,3,3,3,4,1,5,2,3,3,1,1,5,1,5,3,5,2,2,5,2,3,2,5,4,3,1,4,5,4,1,4,4,2,1,3,1,4,4,3,1,1,4,5,2,3,4,2,3,1,2,4,3,3,3,3,2,4,4,5,1,3,3,3,1,3,1,2,1,3,4,2,4,5,4,2,5,2,5,3,4,3,1,4,1,4,3,2,5,2,5,1,5,2,4,3,1,5,5,5,2,4,1,2,4,4,3,2,3,1,3,1,1,3,5,5,2,4,5,1,1,4,1,1,5,5,2,2,2,3,4,2,4,2,4,1,1,3,3,5,4,4,1,1,3,5,2,5,1,3,1,4,5,1,4,4,5,2,3,5,3,1,3,2,4,4,1,1,5,1,5,1,3,3,3,3,2,4,4,4,5,4,2,2,2,5,3,1,3,3,4,1,5,3,1,5,4,2,1,2,5,5,1,4,4,5,1,3,1,4,2,2,5,3,3,5,4,4,4,3,1,2,3,1,5,5,5,5,3,4,5,3,4,4,1,1,1,5,5,2,5,3,2,2,3,2,3,5,1,3,4,2,3,1,5,4,3,5,2,2,3,5,1,4,5,1,3,3,4,1,5,2,5,2,5,1,1,1,1,3,5,1,3,4,5,4,5,2,5,3,4,1,1,2,3,2,2,5,4,2,4,5,2,1,2,1,4,5,2,5,4,2,4,5,1,3,5,4,4,3,4,2,3,3,5,5,1,5,5,5,5,2,1,4,4,4,4,2,3,1,1,5,4,2,3,3,2,4,5,2,4,4,2,1,5,5,5,5,2,3,5,2,5,4,4,3,1,2,4,3,5,4,5,3,3,4,5,4,2,3,3,5,4,4,4,4,1,1,4,1,2,5,1,2,3,4,2,1,3,1,2,2,2,1,4,5,5,2,3,5,2,3,2,2,2,5,5,1,2,2,1,5,5,2,5,4,1,3,4,1,5,1,3,2,4,2,5,5,3,5,4,1,5,2,1,3,2,3,4,3,3,1,1,4,2,3,2,5,5,5,4,4,5,4,2,4,4,4,1,1,4,5,2,1,1,2,1,3,1,1,4,4,4,1,5,3,4,2,4,2,5,1,4,2,4,3,3,5,4,5,3,4,1,5,4,1,4,2,2,4,2,5,3,5,2,5,3,3,5,3,1,2,3,2,5,1,5,5,3,2,2,4,4,5,3,3,1,2,5,4,5,5,1,5,4,4,1,3,3,4,1,2,4,5,1,3,3,2,4,2,1,2,1,3,2,1,3,3,1,1,3,3,3,4,1,3,5,2,4,4,1,3,5,3,1,2,2,5,2,3,5,4,3,2,1,1,4,2,3,5,2,4,1,4,3,3,5,3,5,3,2,5,2,4,3,2,3,5,2,2,2,5,3,1,2,3,5,2,1,5,4,2,3,1,4,3,5,4,4,1,1,5,2,1,2,5,1,1,1,4,1,5,3,4,5,5,1,2,4,5,2,5,1,1,4,2,1,1,2,4,1,5,4,4,4,4,3,4,4,4,5,5,5,4,1,5,5,1,3,1,1,2,4,5,3,2,5,4,2,4,2,2,2,4,4,1,1,3,3,4,2,5,3,4,1,2,2,3,3,2,4,4,1,2,1,3,5,2,4,5,1,1,4,1,5,4,2,5,4,3,5,4,2,1,5,1,5,5,2,2,2,3,2,2,4,5,1,1,2,1,2,3,5,2,3,4,2,4,4,4,1,3,2,3,5,5,1,4,5,3,3,4,1,1,5,1,5,2,5,2,2,2,4,5,2,3,5,2,1,3,3,3,5,3,5,5,5,3,5,2,4,5,5,3,3,2,3,4,1,5,1,4,5,4,3,3,1,4,5,3,5,4,2,5,1,2,4,3,1,3,4,5,4,1,1,3,5,2,3,3,3,1,5,2,3,2,2,2,4,2,5,5,3,5,5,2,1,2,1,1,5,1,2,2,4,1,5,5,5,3,5,1,1,3,5,3,3,5,1,2,2,4,4,1,2,1,1,2,3,2,3,4,4,4,1,1,4,4,1,3,1,4,3,3,1,4,3,3,3,5,4,4,3,2,1,1,1,4,5,2,1,4,4,4,3,3,1,5,5,4,5,1,2,3,5,2,2,4,4,4,2,2,4,2,1,3,2,5,5,2,1,4,5,1,5,5,3,3,3,2,5,3,5,1,1,3,5,1,5,1,1,2,2,5,4,3,1,2,2,3,2,1,4,5,5,4,5,2,5,3,5,4,1,1,5,5,1,2,1,3,2,3,4,2,1,5,4,1,1,5,3,2,2,4,1,3,4,3,3,3,4,4,5,3,1,5,4,2,5,2,5,3,1,5,3,4,2,1,3,3,5,1,2,2,2,3,4,3,4,4,2,3,3,4,4,3,1,4,3,1,2,5,2,2,2,2,5,2,5,3,4,1,4,3,3,2,2,5,2,5,3,2,5,3,3,1,3,1,3,4,5,2,2,3,1,5,5,5,1,3,4,1,1,5,2,2,4,2,4,3,2,1,5,3,4,5,3,5,3,4,4,2,4,5,2,1,3,1,5,4,1,3,5,2,1,2,4,3,3,2,1,4,4,4,5,2,2,3,3,2,1,4,2,3,5,1,1,1,1,3,4,5,1,3,5,2,3,4,2,2,2,2,3,4,5,2,5,5,1,2,4,1,5,5,4,1,1,3,3,4,2,4,1,5,4,5,4,5,3,1,3,2,1,1,1,3,3,4,2,1,2,3,4,5,2,4,4,5,5,3,3,4,5,3,5,4,3,4,1,5,2,1,5,3,4,5,3,2,3,5,3,3,1,3,3,2,2,3,4,1,5,2,2,1,5,5,1,2,4,4,4,2,2,1,5,4,5,5,4,4,2,5,3,4,2,5,2,1,2,3,3,2,1,3,1,3,2,2,5,1,2,5,4,1,3,5,5,2,1,5,2,5,4,4,4,1,3,4,5,1,4,1,3,5,2,3,3,2,5,1,5,5,5,4,3,1,3,5,2,1,3,4,2,3,2,3,1,4,4,1,1,1,5,4,2,2,2,4,4,4,4,3,5,2,4,3,3,2,3,5,5,1,5,5,4,2,4,2,4,3,1,2,3,4,2,5,1,5,5,3,4,1,4,1,2,1,2,4,4,4,2,4,5,1,2,3,1,4,2,5,4,5,1,1,5,2,2,4,2,3,5,3,3,2,1,3,4,2,3,2,1,1,2,1,5,3,5,1,3,4,2,4,5,3,4,1,4,4,3,3,1,5,3,1,1,5,5,4,4,1,2,5,1,4,3,3,1,2,5,1,4,3,2,1,3,2,1,4,5,1,2,2,5,3,3,2,4,2,3,2,4,5,2,1,2,4,4,2,2,5,3,4,5,4,1,5,2,3,3,5,2,1,2,2,5,3,4,3,5,1,5,3,2,2,1,3,2,3,1,2,5,5,5,4,2,4,5,5,1,4,4,3,2,5,2,1,5,2,5,2,1,3,3,2,4,3,4,5,3,4,3,5,3,4,1,5,2,4,1,1,4,2,5,1,3,1,2,2,5,2,5,2,5,1,2,2,4,1,4,4,2,5,2,5,3,5,5,4,2,5,2,3,2,4,2,2,3,3,3,3,4,3,1,4,2,5,4,2,1,3,1,1,4,4,3,4,1,3,5,5,2,2,5,2,3,2,4,3,2,1,1,1,5,5,4,1,4,4,1,4,5,4,5,5,2,4,5,4,4,5,4,4,3,1,2,4,3,4,2,1,5,3,3,3,1,3,4,5,3,4,3,1,5,2,1,1,5,1,4,5,3,5,3,5,3,1,1,1,2,5,1,4,2,5,4,1,5,2,3,2,4,2,4,1,3,5,1,3,5,2,3,4,3,1,1,5,2,5,4,3,3,1,2,5,1,3,1,2,4,4,3,5,3,3,1,5,1,2,2,2,3,1,3,4,3,5,4,3,4,3,3,2,3,2,5,4,1,2,5,2,2,4,5,4,3,3,1,5,2,4,2,4,1,3,5,4,2,2,1,3,5,4,1,1,3,3,3,4,4,3,1,1,3,3,2,2,5,3,3,2,4,3,2,3,3,1,2,3,1,5,1,4,3,1,4,5,5,5,3,3,5,2,1,5,2,5,5,4,1,5,1,5,5,2,4,1,3,4,3,5,2,3,2,5,3,3,3,5,5,3,1,4,4,4,5,3,4,3,2,1,2,3,5,3,4,2,2,2,5,4,4,4,2,1,4,2,4,5,1,3,3,2,5,4,2,1,5,4,3,2,1,5,5,1,3,1,3,4,4,3,4,3,2,1,1,2,1,5,2,1,2,4,1,4,1,1,3,3,5,5,5,5,1,1,5,4,1,2,1,5,5,5,3,4,2,5,4,1,2,4,1,4,4,1,1,3,4,3,4,2,4,2,2,4,2,3,5,5,1,4,3,4,4,1,4,2,3,3,4,3,4,1,5,3,1,3,4,1,2,2,2,2,4,4,4,5,4,4,2,3,2,3,1,4,2,1,5,1,2,3,4,5,1,3,5,3,5,1,5,3,3,5,1,1,2,2,4,2,3,5,5,1,3,4,5,3,3,5,4,2,1,4,3,2,1,1,1,2,5,1,5,4,5,2,2,5,2,2,1,2,5,2,4,3,4,2,2,5,5,4,3,2,4,4,3,2,4,1,3,4,2,3,1,3,5,4,1,3,5,1,4,4,1,4,3,1,4,4,1,1,4,2,3,2,2,5,1,5,5,3,5,2,3,5,5,3,5,4,5,2,1,2,1,2,2,2,2,4,3,2,1,3,4,4,3,5,2,3,2,3,4,3,2,3,5,1,1,2,4,3,5,5,4,1,3,3,3,5,3,2,1,4,4,4,1,1,2,2,3,1,2,5,5,1,2,1,3,5,5,3,1,4,3,2,1,3,3,3,3,4,2,3,4,3,3,4,4,2,3,1,1,4,1,5,3,5,5,5,5,1,2,2,3,3,4,3,5,2,3,2,1,3,5,5,3,2,3,1,5,3,5,1,4,5,2,1,3,5,2,1,2,4,1,5,5,1,5,1,3,3,5,3,4,2,2,5,5,2,1,2,1,3,4,3,2,2,3,3,5,1,1,4,4,5,5,3,1,3,4,4,5,4,3,4,1,3,3,5,4,1,2,3,1,2,2,3,2,3,1,5,2,2,5,5,3,3,3,1,3,2,4,4,5,4,1,3,4,5,5,5,4,4,2,4,3,3,4,2,3,1,2,2,3,5,2,3,4,2,1,1,4,3,4,1,5,2,1,4,1,1,5,5,5,1,3,4,4,2,5,2,2,3,1,5,4,3,1,5,1,3,2,1,4,1,1,3,5,2,2,1,2,5,2,4,4,2,3,1,3,2,2,4,1,2,1,5,5,1,2,1,2,1,3,4,5,1,3,4,2,4,3,4,2,5,5,1,2,1,2,5,2,4,5,3,2,5,2,1,1,3,3,2,4,2,1,3,4,2,4,5,4,4,4,3,3,3,4,1,4,5,2,3,3,1,5,5,1,4,5,5,1,3,3,1,4,5,4,2,4,5,3,2,5,5,2,4,1,4,1,4,5,2,3,5,3,4,3,5,4,2,3,5,3,5,2,5,4,2,2,2,1,2,2,3,5,1,1,5,3,3,4,2,1,3,5,1,2,3,4,1,1,2,2,3,3,3,1,2,4,1,3,3,3,1,5,3,4,5,4,3,3,3,3,1,5,2,3,2,3,2,2,5,1,4,1,4,2,2,3,3,5,2,1,3,5,2,4,3,4,3,3,2,3,3,2,3,2,2,5,1,5,5,5,5,5,1,2,2,4,4,4,5,2,5,2,5,4,3,1,2,5,5,3,5,1,5,1,1,1,5,2,2,4,5,5,2,1,3,3,4,4,3,3,4,5,4,5,4,3,4,4,2,4,5,1,3,5,1,5,4,3,3,5,2,5,4,1,2,2,2,2,1,4,3,2,2,3,3,5,2,4,2,2,2,4,3,4,4,2,5,1,4,1,1,3,3,2,1,4,1,4,5,4,5,4,1,3,1,3,1,5,1,5,4,2,5,4,3,4,5,2,3,1,4,5,4,3,5,3,1,1,2,1,3,5,1,4,4,4,1,1,4,3,1,2,5,5,3,5,2,2,5,2,5,3,1,4,1,1,1,4,1,4,5,4,3,2,2,2,5,3,3,2,2,5,2,3,5,3,1,2,5,2,2,1,5,2,5,2,4,5,1,3,4,1,2,4,2,1,1,5,2,4,5,5,4,1,4,5,1,3,5,1,1,5,5,1,3,1,4,3,2,2,1,2,1,1,1,3,5,4,5,2,3,3,2,2,3,1,1,1,5,2,3,5,4,3,4,1,1,3,4,5,3,5,3,4,5,4,1,2,5,5,2,3,4,5,4,3,2,1,5,3,2,5,1,2,3,3,3,4,5,2,5,4,2,4,3,1,3,3,5,4,4,4,4,4,1,1,5,4,3,2,3,4,2,2,5,2,4,4,2,1,5,1,1,1,2,1,5,4,3,2,3,2,2,5,4,3,2,1,3,1,4,5,3,2,1,3,2,1,5,3,3,5,1,2,2,3,2,2,2,5,5,1,1,4,4,5,1,1,5,3,2,5,1,5,5,5,2,2,1,5,3,2,2,2,1,5,1,1,2,1,1,1,1,3,4,5,3,1,1,3,5,5,1,4,4,5,5,1,2,5,5,1,1,3,4,1,3,4,1,4,1,5,3,2,4,5,5,5,1,2,1,3,2,2,1,3,5,3,5,1,5,3,3,4,3,2,4,5,1,5,4,1,1,2,1,5,3,5,1,5,5,4,5,3,1,2,1,4,5,5,3,4,1,5,1,1,1,5,5,5,3,1,4,4,1,5,3,1,4,2,2,1,5,2,1,1,4,4,4,5,2,2,5,4,5,5,2,3,5,1,2,2,4,2,2,1,1,3,2,2,2,3,1,3,4,3,4,4,5,3,2,3,4,5,5,3,3,4,2,1,2,4,3,2,1,1,5,2,4,5,2,1,5,5,1,2,1,1,4,4,3,1,2,2,3,3,2,2,1,3,1,5,2,1,4,5,5,4,5,1,5,2,1,4,2,2,4,5,5,3,3,3,5,5,1,2,2,3,2,2,4,5,4,3,5,3,2,2,5,4,1,5,5,1,4,4,2,5,5,2,5,5,1,3,3,2,5,1,5,4,2,1,5,3,4,3,4,1,5,3,2,5,3,1,1,5,5,4,4,5,5,2,5,1,3,4,1,4,5,4,5,2,3,2,3,3,1,3,5,5,3,1,3,2,4,4,1,3,1,4,3,5,5,5,3,3,5,3,2,1,2,3,2,1,2,2,3,2,3,5,2,4,4,5,4,5,5,5,5,5,2,1,4,4,4,1,2,4,1,2,1,3,1,4,2,3,5,4,4,3,4,1,3,2,3,1,5,4,1,1,2,5,2,2,3,1,3,2,5,5,5,2,5,3,2,3,3,5,3,5,4,5,1,3,5,5,4,4,1,4,4,3,2,2,5,2,3,5,2,1,5,4,3,4,4,1,4,3,5,1,2,5,3,2,2,5,3,3,2,3,4,3,5,4,1,4,2,5,5,3,1,5,4,2,3,4,3,2,1,5,1,3,4,4,3,3,4,2,5,1,1,3,1,4,5,5,4,4,1,1,3,5,1,3,4,3,1,5,5,4,2,2,5,1,1,2,3,3,2,4,2,3,2,4,5,4,1,1,1,3,5,2,1,5,1,2,1,2,5,4,1,1,1,3,1,3,5,4,4,5,1,5,5,5,5,2,1,1,3,2,3,3,2,4,3,5,3,4,1,3,1,2,2,1,1,3,4,1,4,5,2,4,2,2,5,3,4,5,4,4,5,1,5,2,1,1,4,1,2,4,1,5,2,1,2,5,3,1,5,2,1,3,3,3,3,2,2,5,3,5,5,1,2,2,3,5,3,5,2,4,2,5,3,5,4,4,4,3,2,4,3,3,5,4,2,1,1,5,4,1,2,5,4,4,4,5,5,4,2,2,1,4,5,4,5,5,2,5,5,5,3,5,5,1,5,2,2,1,5,5,4,4,4,2,5,5,2,4,3,2,1,1,1,2,1,2,3,3,4,4,4,1,1,2,3,2,5,3,2,4,3,2,3,4,4,5,5,4,1,1,1,3,3,1,4,5,4,2,1,3,3,5,1,1,1,4,5,4,1,2,2,1,2,3,5,2,1,3,3,4,3,1,2,3,3,1,2,3,1,1,4,4,4,4,4,4,1,1,1,2,5,3,4,2,3,1,1,1,4,5,1,5,4,4,5,3,2,2,5,2,3,5,5,5,2,3,4,1,1,1,1,5,5,5,4,5,4,3,2,4,5,5,3,3,3,4,4,5,2,5,1,2,2,2,3,4,5,2,3,5,4,5,4,5,3,4,4,5,1,1,3,5,4,1,4,1,3,5,5,4,4,1,3,5,4,1,1,2,3,2,3,4,4,1,2,4,1,1,1,2,1,4,4,2,5,1,4,3,2,1,3,3,4,2,5,2,4,5,5,4,3,5,3,3,5,3,1,5,1,5,1,2,1,3,1,4,1,4,5,2,1,1,5,1,4,2,4,3,2,2,4,1,5,5,4,2,2,1,5,5,3,5,5,4,2,5,5,2,1,4,3,4,1,1,4,2,2,1,2,5,2,4,4,5,1,4,3,1,4,5,2,2,5,3,2,2,2,2,1,3,2,4,1,2,1,3,2,1,1,5,1,4,5,4,4,5,5,5,5,5,2,1,3,3,3,5,5,2,5,3,3,5,1,1,5,4,3,2,1,2,2,2,2,4,4,5,3,4,1,1,4,2,1,5,5,3,3,4,1,3,1,1,2,5,2,4,4,4,1,1,1,1,1,5,2,4,4,2,3,3,3,4,2,2,1,4,2,3,4,4,3,2,1,5,4,3,5,5,1,1,2,4,2,4,2,3,1,1,5,2,2,3,3,4,1,5,1,4,2,2,2,4,2,4,5,5,2,4,4,1,5,3,4,3,2,5,4,4,1,2,5,1,3,1,2,5,3,5,1,4,3,5,1,4,2,2,5,2,3,3,5,5,3,4,5,1,5,1,1,1,4,4,5,4,1,1,2,5,5,3,4,5,1,3,2,5,1,4,1,1,5,5,2,1,5,1,5,5,5,5,1,5,5,3,4,3,5,2,5,4,3,5,5,1,4,2,1,5,3,2,4,4,3,5,5,2,3,4,3,3,1,1,4,5,1,2,2,5,1,1,4,5,2,4,3,5,5,1,2,5,3,3,5,4,5,3,1,2,3,2,2,2,3,5,2,4,1,2,2,2,5,2,1,2,1,3,2,4,3,3,5,5,4,4,5,4,1,1,3,5,2,3,4,4,1,5,3,3,2,3,2,5,1,2,4,1,2,4,2,5,4,1,2,3,4,1,4,5,2,4,5,3,2,3,3,5,4,3,5,2,3,4,5,5,4,5,4,4,3,4,5,3,3,2,2,2,3,1,3,3,3,3,5,4,5,4,3,5,2,4,5,4,5,4,1,3,4,3,1,3,1,1,1,5,2,3,1,1,1,1,3,1,5,5,1,1,1,5,1,2,4,1,5,1,5,5,4,4,1,5,4,2,1,3,3,5,5,2,5,4,4,5,5,1,1,1,4,3,1,4,1,1,3,2,1,2,4,4,1,1,5,1,1,2,1,1,1,5,5,3,5,1,4,2,5,3,3,5,5,3,4,4,5,2,5,2,4,1,1,4,1,2,3,5,1,5,3,3,4,3,2,5,3,2,5,2,2,3,5,1,3,2,2,5,5,4,4,3,2,2,4,2,5,4,2,3,2,1,3,5,1,2,5,4,3,1,2,1,5,4,2,5,1,3,2,5,1,1,5,4,5,1,1,3,4,5,2,2,2,5,5,5,3,3,4,1,2,3,1,5,2,2,3,5,5,5,4,4,1,4,1,3,4,1,2,1,2,5,1,4,5,1,5,2,5,2,1,2,2,2,4,1,4,5,2,3,4,1,3,5,3,1,1,5,3,1,3,2,1,3,5,4,4,5,3,4,1,4,3,5,3,4,1,1,1,5,2,3,1,5,4,4,3,3,1,4,1,5,4,2,1,1,5,2,2,5,3,5,4,1,4,5,2,1,2,2,5,5,4,2,5,1,3,5,4,3,1,1,3,1,2,5,2,3,3,3,1,1,2,3,3,5,3,4,1,4,4,4,4,2,2,1,1,5,4,2,4,2,5,2,2,1,5,2,2,5,1,2,4,3,5,1,2,1,3,3,2,5,5,1,5,2,5,5,1,2,5,1,3,5,1,3,1,3,3,3,5,2,3,5,2,2,5,4,2,5,4,4,3,2,5,4,2,1,3,4,4,4,2,3,1,4,2,3,2,3,3,2,4,4,1,5,3,3,4,1,5,3,5,1,5,3,2,2,1,4,2,2,2,1,5,5,2,4,2,2,4,5,2,2,1,1,3,2,5,1,4,5,2,1,5,1,4,1,3,4,3,1,2,2,4,3,5,3,5,4,3,5,1,3,1,5,1,2,1,4,2,4,5,5,4,5,5,5,1,5,5,1,1,1,5,1,5,1,1,1,1,1,4,5,1,2,5,2,2,3,2,5,3,1,3,3,5,4,1,2,1,3,3,1,2,3,4,5,4,5,3,4,4,5,4,4,4,3,3,1,3,3,1,3,2,3,3,2,5,1,3,2,1,4,1,4,4,2,5,2,1,2,2,2,4,3,5,1,1,2,2,1,2,3,2,3,5,1,1,2,2,1,2,3,4,1,1,3,1,3,4,4,1,1,3,2,3,4,4,4,4,4,1,5,5,4,4,1,4,5,5,1,5,4,3,5,5,1,4,4,5,1,4,3,5,1,4,1,5,3,5,2,5,4,2,3,4,4,2,3,5,4,4,5,5,5,5,1,1,4,1,2,2,5,4,4,5,3,1,5,4,1,2,2,4,1,5,2,3,4,2,4,1,3,1,3,5,2,4,1,2,5,1,2,3,2,3,4,2,3,5,2,5,3,3,1,2,4,5,5,5,5,4,4,4,4,4,2,2,3,4,4,4,3,5,3,5,2,3,1,5,4,4,5,2,5,5,3,5,4,1,5,5,1,1,1,2,5,5,5,4,1,2,1,3,1,2,3,3,1,3,4,2,3,3,1,3,1,1,4,1,5,5,1,3,3,4,2,4,3,5,4,5,1,4,4,2,4,4,1,5,4,3,3,5,4,3,2,5,2,2,2,3,2,5,2,2,5,3,4,4,4,4,2,3,4,4,1,4,1,1,2,5,1,2,5,4,3,2,3,1,3,5,1,2,5,3,5,3,3,3,5,1,3,4,3,3,4,5,1,5,2,4,4,2,4,4,4,4,1,4,3,3,2,5,2,2,3,4,4,1,3,3,3,5,4,4,5,5,3,5,1,5,2,1,2,1,5,3,3,3,3,2,2,4,2,2,3,5,2,1,2,1,4,4,4,5,2,2,3,3,1,3,1,4,5,1,3,3,1,5,3,3,5,3,5,4,2,2,4,3,1,1,3,4,2,3,2,2,2,1,2,3,1,4,3,3,1,1,1,2,2,4,4,3,3,2,3,2,2,4,1,4,3,3,1,3,2,4,1,1,1,4,1,2,5,5,3,3,5,1,5,1,1,5,1,4,5,2,2,4,3,3,4,5,1,4,3,5,4,3,4,2,2,2,3,2,2,3,1,1,3,3,1,5,2,2,5,4,1,3,4,5,5,4,5,3,4,2,1,5,1,3,4,5,1,5,2,2,2,3,2,2,2,3,1,5,4,3,4,1,2,4,2,5,3,5,3,1,1,1,2,2,4,4,4,2,1,3,3,3,5,3,4,4,5,2,5,2,1,3,4,1,1,1,5,4,1,5,2,4,3,3,4,5,3,4,3,5,5,1,1,2,3,1,1,4,5,4,4,3,1,5,5,4,3,2,1,5,1,5,2,5,2,3,4,1,3,1,2,3,1,5,3,3,1,5,2,2,3,4,4,5,3,4,3,4,3,2,4,2,4,3,4,3,4,2,5,2,5,3,2,5,3,3,2,2,2,5,1,5,2,2,5,2,5,3,4,5,3,1,5,5,3,3,5,3,2,1,2,5,4,4,2,5,4,2,5,4,2,1,1,5,5,2,1,2,3,4,4,2,3,2,5,4,5,5,2,5,2,4,4,3,2,2,2,5,3,1,5,1,3,5,1,3,5,5,2,5,4,5,5,5,3,5,5,1,2,3,5,5,3,4,2,3,2,4,4,4,5,1,4,2,2,3,4,3,3,4,4,4,2,2,2,5,5,2,3,2,3,1,3,4,4,3,1,3,5,2,4,5,5,4,1,4,2,4,5,2,2,4,2,1,2,4,2,2,1,2,5,2,2,5,3,2,3,4,3,2,1,1,1,2,4,2,4,4,4,2,3,1,2,1,3,3,5,1,3,5,2,2,1,2,2,3,3,3,2,5,4,2,2,1,4,1,3,2,4,5,4,3,5,1,5,3,4,5,3,4,4,4,1,2,3,4,3,2,5,2,1,4,1,3,1,1,2,3,5,2,1,3,4,1,2,5,1,5,3,3,5,3,5,3,4,1,3,4,2,4,3,3,2,4,2,2,4,1,3,5,2,3,5,2,5,1,2,2,1,2,5,3,1,5,2,5,1,4,4,2,4,1,4,5,4,2,3,3,5,3,2,5,5,5,5,5,1,5,1,3,3,3,2,1,4,5,5,5,1,3,4,4,4,1,1,5,3,1,4,1,2,5,5,5,5,2,1,4,1,1,2,2,3,4,2,2,1,3,2,2,4,4,3,4,5,3,4,5,5,2,5,1,3,2,2,4,2,1,2,2,1,4,3,2,4,2,5,5,2,5,3,3,1,1,4,3,3,2,3,1,2,3,5,3,3,4,1,4,1,5,2,3,2,1,2,2,3,5,4,5,5,3,5,1,1,4,2,4,2,1,2,5,1,2,3,3,3,2,3,3,3,5,3,5,4,5,2,2,1,1,4,4,3,2,4,2,5,1,3,1,5,5,3,4,5,1,4,4,3,2,2,2,3,3,5,1,5,2,5,3,4,1,4,1,5,2,4,4,2,5,2,4,5,2,2,2,4,1,5,1,5,3,4,3,3,3,4,1,4,3,1,1,3,5,2,4,2,4,3,3,5,2,2,2,2,4,5,1,1,4,4,5,2,5,4,4,1,1,2,4,4,5,3,5,5,4,5,1,2,4,4,4,1,2,1,5,4,3,2,4,1,3,2,2,2,3,3,1,1,2,2,5,5,1,5,5,1,2,4,1,1,3,2,3,4,2,1,3,5,4,2,1,4,1,2,3,2,1,4,5,3,4,1,3,3,4,2,1,1,4,5,5,2,4,1,3,5,2,2,2,1,5,3,5,5,4,1,2,1,5,4,5,3,4,3,5,2,2,2,4,1,3,4,4,4,2,1,1,1,2,5,3,4,4,4,3,5,5,2,1,1,5,4,5,4,1,3,4,2,5,1,3,4,3,2,2,4,1,4,5,2,2,3,4,3,2,2,5,4,5,4,1,4,2,4,4,1,3,5,3,1,3,4,5,3,5,4,1,5,4,5,1,2,1,2,2,4,1,4,3,4,5,2,1,3,4,2,4,1,1,5,5,5,5,1,2,1,1,5,4,1,1,3,2,4,5,2,4,5,3,3,1,1,4,3,1,1,5,2,5,5,4,1,1,3,3,5,5,1,3,5,5,2,5,4,4,4,1,1,3,1,2,2,1,1,1,3,5,2,3,3,1,2,4,1,2,3,1,4,4,4,5,5,5,2,4,3,2,5,3,1,3,2,3,4,3,4,1,2,2,2,4,3,5,3,5,2,1,1,4,2,4,3,2,3,4,3,4,2,5,1,5,4,4,5,2,3,1,4,1,5,4,2,1,5,4,3,5,1,3,2,2,5,2,4,2,2,2,1,5,3,5,2,4,2,2,5,1,4,4,5,1,2,1,5,5,5,3,4,3,3,4,2,2,3,2,1,5,2,3,2,4,5,4,3,4,1,5,3,2,1,2,5,3,4,4,2,3,2,4,4,4,2,4,3,2,3,2,3,2,1,5,1,3,4,1,2,5,5,5,3,1,5,2,2,2,4,5,5,4,1,1,2,1,3,5,3,4,3,5,3,2,3,5,3,2,2,3,3,1,2,2,2,3,4,1,5,2,5,3,1,3,3,5,3,4,5,3,3,2,5,4,3,4,5,2,3,3,2,4,5,2,2,1,5,3,5,3,2,1,3,4,3,4,2,3,1,1,1,2,4,1,1,5,4,4,1,4,4,3,2,5,1,3,4,1,5,4,4,3,2,4,4,4,4,5,2,5,2,5,4,3,2,1,2,4,2,3,3,5,3,1,2,2,4,1,5,4,3,5,5,5,2,2,5,1,1,2,2,2,1,4,1,2,2,4,3,5,4,3,4,4,2,2,1,2,4,2,2,1,4,4,1,2,3,2,4,4,5,2,4,5,1,4,4,3,3,2,5,4,3,5,5,5,5,4,1,5,2,3,3,4,4,1,5,2,2,5,4,1,5,1,2,4,3,1,4,1,5,2,1,2,4,2,1,3,1,5,4,4,5,1,2,3,1,2,3,1,2,4,3,3,2,2,5,3,2,3,4,1,4,2,5,1,4,2,4,2,3,4,5,2,4,2,4,5,4,5,5,4,2,5,1,3,1,5,5,2,1,2,3,5,3,4,5,3,2,2,3,2,5,5,4,4,2,2,4,3,1,1,3,5,5,1,2,4,4,5,4,3,3,4,5,3,1,2,3,5,3,5,5,2,1,1,3,2,2,2,4,3,3,5,2,3,5,2,2,4,2,2,4,1,2,3,5,4,2,1,3,1,4,2,4,4,1,3,3,4,5,1,3,5,2,5,1,1,3,1,4,5,1,2,5,5,1,1,1,1,1,4,4,1,5,3,3,3,2,2,3,2,4,4,1,4,4,5,4,4,2,3,4,4,1,3,1,4,1,5,3,4,4,3,3,3,4,1,2,2,3,4,1,4,2,3,4,1,5,3,1,3,3,1,3,5,4,1,3,4,3,5,3,1,2,5,3,3,5,1,1,4,2,4,2,5,2,5,2,4,1,5,5,4,1,3,3,5,5,4,4,4,5,2,1,2,5,3,4,1,4,3,3,2,2,3,4,2,1,1,5,1,2,4,3,3,2,2,4,4,3,4,5,4,5,4,2,3,5,2,3,1,4,1,1,1,2,1,1,2,4,3,5,1,3,4,4,1,5,4,2,1,4,5,3,3,2,1,3,2,1,3,2,5,4,2,5,3,3,1,3,5,1,3,5,3,5,3,1,4,2,5,2,3,4,1,5,2,1,2,4,2,1,2,2,2,5,3,2,2,1,5,2,3,4,1,5,4,1,4,2,5,1,1,3,5,5,3,3,1,3,2,2,1,1,5,2,4,4,4,3,3,5,2,5,1,1,4,1,3,2,4,3,4,2,1,2,1,5,3,1,2,1,5,1,1,5,5,3,1,2,2,1,3,2,3,2,3,3,3,2,5,2,2,2,5,3,5,2,2,1,1,1,1,1,3,1,2,1,1,3,2,1,5,2,4,3,2,1,1,3,3,1,3,3,4,5,4,5,4,1,2,4,1,1,2,1,1,3,2,2,5,5,1,5,2,1,2,2,4,2,4,1,3,1,4,4,5,1,2,3,5,4,3,5,4,2,2,2,2,1,3,2,4,2,5,1,1,4,5,3,1,2,1,1,4,3,5,1,5,4,1,2,4,4,5,3,1,2,5,5,5,4,5,4,5,2,1,2,3,3,3,2,1,2,2,3,4,4,1,1,5,5,3,4,5,4,5,5,2,3,2,5,1,3,5,4,4,3,4,2,3,5,4,4,1,2,3,1,2,4,1,3,2,5,2,4,2,4,1,5,3,4,1,5,4,3,2,1,1,1,1,2,2,1,3,2,1,3,1,1,1,3,4,5,1,4,1,3,4,5,2,2,4,1,4,2,1,4,1,5,4,2,4,3,4,4,1,4,3,4,4,3,2,3,5,5,2,2,4,4,1,1,5,5,1,5,1,4,5,2,3,1,4,5,3,3,5,1,5,1,2,3,1,3,2,1,2,1,2,4,4,5,1,1,4,1,1,4,1,5,1,5,4,3,5,5,1,3,3,2,2,4,4,3,1,5,5,2,5,5,5,1,4,3,4,1,4,1,1,5,5,4,4,1,3,5,4,2,4,5,1,3,5,1,1,1,4,4,2,2,3,3,3,3,1,3,5,5,1,4,5,3,5,2,2,1,3,3,5,3,5,5,3,1,2,4,5,1,4,4,5,4,4,2,2,4,3,4,1,4,4,2,2,2,5,3,5,3,2,3,4,5,1,4,3,2,3,1,2,3,1,5,3,1,2,3,2,1,1,5,4,5,1,1,4,2,1,4,4,5,1,5,2,1,1,5,5,4,2,5,5,3,1,5,3,4,1,5,2,2,3,5,4,2,1,5,4,3,2,3,3,4,2,2,2,3,1,2,4,1,2,4,5,2,2,4,5,2,3,1,5,3,4,3,3,1,3,5,4,1,3,4,2,2,1,2,1,4,2,1,5,2,4,3,4,3,5,4,1,2,4,2,1,5,5,4,1,5,5,3,3,1,4,3,1,2,3,1,4,1,5,4,2,2,5,2,3,3,2,2,1,3,5,4,1,3,4,2,5,2,3,4,4,5,2,1,5,5,1,1,4,4,3,3,3,1,3,5,3,1,1,4,2,4,2,5,5,2,4,3,4,3,3,2,5,4,5,4,2,1,4,4,5,1,2,1,1,5,2,1,1,4,5,3,4,1,1,2,4,2,1,1,2,4,3,5,1,2,4,5,2,3,1,5,3,5,4,2,1,3,2,4,3,4,4,5,1,1,1,5,4,3,5,2,3,2,3,5,2,1,2,3,2,2,2,1,4,2,3,5,1,4,2,5,2,3,1,4,4,4,5,3,1,2,1,3,3,4,2,1,3,2,4,3,2,1,2,4,5,1,1,4,5,3,1,4,5,1,4,1,1,5,2,5,4,1,3,2,5,4,2,2,2,4,2,2,2,1,4,3,4,4,5,1,2,2,4,2,2,1,2,4,5,5,2,4,4,5,4,4,1,5,1,2,3,5,4,5,5,5,1,5,4,4,2,3,1,2,3,2,3,3,2,4,3,3,4,1,4,3,3,1,4,5,3,4,1,3,3,5,3,4,3,1,3,1,2,5,2,4,4,1,5,2,4,5,2,1,5,4,1,3,3,3,1,5,3,3,2,2,3,3,2,4,3,4,2,4,2,5,4,3,5,2,2,4,3,4,5,3,4,3,1,2,3,4,2,4,4,3,4,5,1,3,3,3,1,4,3,4,5,4,3,4,2,1,5,4,2,1,5,3,4,1,2,2,5,2,3,4,5,1,4,4,3,3,1,3,2,3,3,4,5,1,3,5,5,2,4,2,5,2,5,3,2,4,4,5,1,5,3,4,4,4,4,4,3,4,1,1,4,5,4,3,1,4,3,5,4,1,5,2,4,3,3,1,2,3,4,5,5,1,3,5,2,3,1,5,4,2,3,5,3,3,5,1,3,4,3,3,2,4,5,1,3,1,1,3,5,4,2,1,2,4,5,1,5,1,3,1,1,4,4,2,4,2,4,2,1,3,4,5,3,3,2,2,2,5,2,5,2,2,5,4,2,3,3,3,3,4,4,4,2,5,5,1,3,2,4,2,2,5,3,2,5,5,4,1,3,2,2,3,3,3,1,5,5,5,4,1,3,1,5,4,3,4,1,4,2,5,4,5,2,5,3,1,3,4,1,1,5,4,2,4,3,4,4,5,5,5,4,5,1,1,3,5,4,1,2,3,1,3,4,1,1,3,2,5,5,1,1,2,3,5,2,3,2,5,1,3,4,2,1,5,4,3,5,5,2,1,1,2,5,1,2,3,1,5,5,3,4,3,2,1,2,4,2,5,1,4,2,5,1,2,5,5,1,2,2,2,5,1,2,1,2,2,1,4,2,4,2,1,4,3,3,4,3,4,2,5,2,2,5,4,4,5,5,4,5,3,4,2,5,5,1,2,2,2,3,2,4,1,5,2,3,2,1,3,5,4,1,2,5,3,1,4,1,4,1,3,5,5,5,5,4,3,3,4,3,5,1,1,2,2,4,3,1,1,1,5,4,4,5,3,3,3,1,2,4,2,5,1,3,2,1,2,2,2,2,2,4,1,1,4,4,5,3,4,5,2,5,1,3,1,5,1,1,5,4,3,1,5,2,1,2,5,1,3,1,5,3,1,1,4,5,3,1,5,2,2,1,4,2,5,4,3,3,5,2,5,5,5,5,2,5,4,1,4,2,1,1,1,2,3,5,2,2,5,2,5,3,2,3,5,2,2,4,2,1,3,3,3,5,2,4,5,2,1,5,3,2,2,1,3,5,1,2,1,4,5,4,1,5,3,2,2,5,2,5,5,1,4,4,3,5,3,2,3,3,2,4,4,1,3,4,2,2,3,5,2,2,2,1,3,3,3,1,5,4,2,2,2,2,2,3,4,3,1,2,1,4,1,4,3,1,4,4,4,3,4,1,5,2,1,5,4,5,4,5,2,1,1,2,2,1,1,1,4,5,1,2,4,2,3,2,2,3,4,1,4,2,4,4,3,1,3,4,1,2,3,3,5,5,3,2,2,2,5,3,3,1,3,1,5,2,5,4,5,3,4,5,2,4,1,5,5,4,3,1,2,4,5,3,5,3,1,1,2,2,2,4,4,1,2,2,2,2,3,1,3,3,1,2,3,4,2,1,5,1,3,5,2,1,1,5,5,3,3,2,2,1,5,2,2,4,4,3,2,4,5,4,4,5,4,4,3,4,1,5,4,1,3,5,2,5,3,1,2,2,3,5,2,1,5,1,4,2,5,3,5,4,2,1,4,2,4,1,1,5,3,2,1,3,5,1,4,3,1,2,4,3,2,5,1,3,2,3,1,3,5,1,5,3,2,3,1,3,4,2,2,1,1,2,2,5,4,5,4,3,1,4,1,4,5,1,5,5,4,1,3,5,3,3,3,3,4,3,3,1,4,5,4,2,5,1,2,4,5,5,5,2,2,1,2,5,1,2,4,1,3,5,1,2,3,4,4,3,3,1,2,1,3,3,4,1,2,2,2,5,1,5,1,4,3,4,4,2,3,3,2,2,5,3,4,3,5,1,3,4,4,3,4,3,5,4,2,3,3,2,5,4,5,1,2,5,5,5,3,5,3,4,1,1,2,3,1,5,4,2,3,2,4,3,5,2,4,5,3,3,5,2,5,2,3,2,2,2,3,1,5,2,2,3,5,5,3,5,3,1,1,5,5,3,2,4,5,5,2,3,2,5,3,2,3,1,1,2,5,2,1,4,2,4,5,5,5,3,2,4,5,5,1,3,5,1,3,4,1,2,5,4,3,3,4,4,4,2,2,2,1,2,4,3,4,2,4,1,4,4,1,5,2,1,5,2,3,2,5,2,4,4,4,1,2,1,1,4,1,4,4,3,3,5,1,2,1,3,4,1,2,3,3,4,2,4,3,3,2,5,4,3,1,2,3,5,1,5,5,2,4,5,4,3,3,1,5,2,3,4,2,2,1,4,3,2,5,1,3,3,5,5,3,1,2,1,4,4,1,2,5,3,1,1,4,4,1,2,2,4,5,4,5,4,1,1,1,3,2,3,3,5,5,4,5,3,4,5,1,1,4,2,2,3,4,5,2,4,3,1,1,1,4,3,1,1,4,2,5,3,3,1,3,5,1,2,2,1,4,1,4,3,1,1,1,5,3,1,1,5,2,5,5,1,5,4,2,5,4,2,2,2,4,2,5,4,5,1,5,5,2,1,2,4,4,3,5,3,3,4,4,2,1,4,2,4,2,5,3,3,4,2,1,1,3,3,1,5,1,5,4,2,3,4,2,2,2,4,4,4,3,1,5,5,1,1,2,2,2,2,1,2,3,2,5,5,1,4,3,3,3,5,4,4,2,2,2,3,4,5,2,4,2,1,2,4,4,3,5,1,1,4,1,4,1,5,3,3,2,1,1,4,1,1,4,3,3,5,5,3,2,1,4,1,2,3,4,1,3,1,5,3,4,1,3,5,4,3,1,4,1,1,5,1,5,5,5,5,4,5,4,4,1,5,1,1,2,3,2,5,5,2,1,4,5,2,3,5,4,5,4,2,3,2,5,4,5,3,5,4,4,5,2,5,4,1,3,2,4,4,5,5,3,4,3,5,4,2,4,2,3,4,2,5,5,5,2,3,2,1,4,3,3,4,4,1,3,1,2,2,5,4,4,2,2,3,4,3,5,5,2,4,1,3,2,4,5,3,2,5,1,1,2,4,4,2,1,1,2,4,1,1,2,1,2,1,2,3,5,3,4,5,1,2,5,2,3,1,1,5,2,3,3,5,1,1,4,2,2,5,5,1,1,1,2,2,1,3,1,3,1,5,5,3,1,4,5,2,3,3,4,4,1,4,5,4,1,5,5,2,1,5,2,4,3,5,4,2,4,4,5,3,4,1,3,5,5,4,3,3,1,4,2,3,2,2,1,5,5,1,2,5,5,1,5,4,2,1,4,4,4,1,3,3,1,1,2,2,3,4,4,5,1,1,4,5,3,2,1,5,5,5,5,1,5,4,1,3,1,5,4,4,5,5,2,3,4,3,4,2,2,2,5,3,5,4,3,2,4,2,2,1,4,1,1,3,5,5,5,1,4,1,5,4,4,4,3,1,1,2,3,1,3,3,5,1,4,5,4,1,2,3,3,1,1,1,2,3,2,4,5,5,5,1,5,5,5,4,5,2,5,4,4,1,2,5,2,2,1,4,4,5,1,1,1,2,5,4,4,1,3,1,3,5,2,1,2,3,3,5,1,2,4,1,5,2,3,4,4,3,3,1,3,3,4,2,2,1,5,3,2,3,5,5,4,1,2,2,2,4,5,3,4,1,3,4,3,1,1,4,5,5,1,3,4,5,4,2,5,4,3,3,5,4,4,5,4,3,2,1,5,5,1,4,3,4,1,4,5,5,4,4,5,1,2,5,2,4,1,3,1,1,2,4,4,1,4,1,5,3,3,1,4,2,4,4,3,1,4,4,1,4,3,5,5,2,2,5,5,5,5,5,2,1,2,3,5,5,2,3,5,2,1,4,5,2,4,1,3,1,4,5,5,1,3,3,4,3,5,1,5,2,4,3,1,2,1,1,1,3,1,2,3,4,4,4,4,1,2,5,1,1,1,5,5,3,3,2,5,2,1,5,3,4,4,5,5,2,3,1,5,1,3,5,3,1,2,3,4,5,2,5,5,1,5,3,1,5,3,2,3,3,5,1,5,4,3,3,5,2,1,2,1,1,5,4,3,5,4,1,3,1,1,2,1,4,3,1,5,5,3,4,2,5,5,5,2,4,1,2,3,5,1,4,4,1,4,2,3,4,4,4,2,5,4,3,2,1,1,2,4,1,2,3,4,2,5,1,1,1,3,4,1,3,5,3,3,5,3,5,5,3,1,5,5,5,2,5,4,2,3,5,4,5,3,2,3,3,2,4,4,1,5,4,5,4,2,2,1,1,3,3,5,1,1,4,2,1,2,4,3,5,5,3,3,5,5,1,5,3,4,5,4,3,4,4,4,4,3,2,1,2,5,3,4,2,3,5,5,3,4,4,3,4,4,2,5,4,2,3,3,5,1,4,5,1,1,3,1,4,5,4,3,4,5,3,2,2,5,4,1,3,1,5,5,4,1,3,4,5,4,2,4,4,3,2,5,2,2,5,4,2,1,2,2,1,4,4,2,1,3,4,5,2,2,4,5,4,2,3,2,1,3,4,3,1,1,5,1,5,4,1,1,4,3,1,5,1,4,4,5,3,4,3,4,4,1,4,5,1,4,4,2,1,4,5,5,3,2,5,3,2,5,2,3,5,3,2,2,5,1,1,1,2,2,4,5,4,3,2,2,2,5,3,1,5,2,1,3,2,1,1,4,5,3,1,5,3,4,3,5,2,5,4,3,1,2,3,5,3,5,4,1,2,1,4,5,3,3,3,3,5,3,5,5,3,2,4,2,2,5,2,2,4,1,2,2,4,5,1,1,2,5,4,2,3,4,2,1,1,3,2,3,2,5,4,2,3,4,2,2,2,5,3,1,5,4,3,4,2,4,3,3,4,3,4,5,1,3,3,5,2,2,5,4,1,1,5,2,1,4,2,4,2,3,3,5,5,1,4,2,2,3,1,1,4,1,4,4,5,3,4,4,5,2,5,4,5,2,1,2,2,1,1,4,1,4,2,3,1,1,3,2,1,4,1,3,5,2,5,1,4,5,2,4,3,2,2,3,1,4,3,2,1,5,4,4,4,2,5,2,5,4,2,3,1,4,1,5,3,5,4,1,3,5,2,1,3,5,1,3,2,3,3,1,3,2,1,3,2,2,2,3,2,2,4,4,2,3,1,2,4,4,3,2,4,5,2,3,4,3,2,3,2,4,1,2,4,1,2,4,2,1,2,4,5,3,2,3,2,1,1,5,4,4,2,1,1,2,4,2,3,2,2,5,1,5,2,5,2,3,3,3,3,1,2,3,4,1,4,4,2,2,5,4,1,1,4,4,1,3,5,4,4,3,2,5,4,5,1,3,3,4,2,2,1,2,2,5,1,1,3,3,3,4,5,1,5,5,1,4,5,5,5,1,5,5,5,4,5,4,2,5,4,1,4,2,5,3,2,1,4,3,2,4,5,1,5,5,4,1,1,3,2,1,2,3,1,3,4,1,2,2,5,3,5,4,2,5,5,2,1,3,1,5,4,2,3,3,3,5,1,1,1,5,3,3,5,5,4,4,4,2,1,4,2,3,3,4,2,5,4,2,1,5,1,4,1,4,3,2,4,5,4,5,4,1,2,5,5,2,3,4,3,1,5,5,4,4,3,5,2,5,5,3,5,3,3,1,5,5,1,1,1,5,3,4,4,1,4,2,1,2,5,4,4,3,5,2,3,1,3,4,3,1,2,1,5,5,5,1,5,2,5,1,5,1,2,5,4,3,1,4,4,4,1,4,4,5,4,1,3,1,1,4,4,4,5,2,1,1,4,3,5,3,4,2,3,2,4,5,1,1,3,1,1,4,5,3,4,5,1,1,1,4,4,4,2,2,3,3,1,4,4,4,4,1,3,3,4,5,5,5,4,4,1,3,3,5,5,5,4,5,4,5,3,3,2,1,5,1,3,3,2,2,1,5,5,3,5,3,1,4,2,5,2,4,5,5,1,2,1,4,5,3,1,2,5,5,1,5,1,1,4,5,2,4,5,5,4,2,5,4,3,4,1,2,2,3,1,5,3,5,5,5,2,2,3,3,1,3,2,2,5,4,1,5,3,2,5,3,1,5,5,5,1,5,2,3,4,4,1,2,3,2,1,1,5,3,2,2,5,3,2,2,4,4,2,3,5,2,3,3,1,4,5,5,1,2,2,2,5,1,3,4,4,5,4,1,3,2,2,5,2,3,2,2,4,1,3,3,1,4,1,1,5,3,1,2,3,3,2,4,4,2,5,1,5,5,3,5,1,1,3,1,3,3,2,4,3,1,2,1,3,4,5,4,5,4,1,3,5,1,5,4,2,4,2,2,5,2,4,2,2,5,5,3,4,5,5,1,5,5,1,1,1,5,4,1,4,4,5,4,5,3,3,2,4,1,5,4,1,1,5,1,1,2,3,3,2,5,4,3,5,3,3,5,4,4,5,5,3,3,5,3,5,1,1,4,4,4,2,3,5,4,1,1,4,3,4,5,3,4,3,4,5,5,1,1,2,5,2,2,2,2,4,2,5,5,5,4,4,5,2,5,4,3,5,5,2,2,5,3,2,1,5,3,2,1,4,1,4,1,1,5,1,4,5,5,1,4,5,1,4,3,2,5,5,2,2,2,5,3,5,2,4,4,4,2,1,3,2,2,2,1,2,3,3,1,2,3,2,5,3,5,5,4,2,5,4,2,4,1,3,3,5,5,5,5,4,5,1,1,3,5,3,5,4,4,2,3,2,3,1,5,3,5,3,3,1,1,5,1,5,4,2,1,5,5,4,3,3,2,5,4,5,2,4,3,5,2,5,3,5,2,2,2,1,1,3,2,2,1,1,3,1,3,2,4,2,2,5,3,1,5,4,4,2,4,2,1,5,3,4,2,1,4,1,1,2,2,4,5,3,3,4,3,4,2,2,2,5,2,3,4,4,1,4,5,1,3,3,5,5,1,5,4,5,5,1,2,2,2,4,2,5,3,2,4,1,3,2,5,3,1,5,4,2,4,3,5,5,4,5,3,2,3,4,3,1,4,2,1,4,3,4,4,5,3,4,3,5,3,2,3,5,2,1,5,3,3,4,4,5,1,3,2,2,2,4,3,5,1,2,2,5,5,2,2,3,2,1,2,4,4,2,3,1,5,2,1,3,2,4,2,2,1,2,2,1,4,5,5,5,3,5,1,1,3,5,3,1,4,2,1,4,4,3,4,3,5,5,3,1,3,5,5,3,4,2,4,3,2,3,4,1,4,2,3,1,1,2,4,1,3,3,2,4,5,2,3,4,1,1,4,3,3,5,2,4,1,3,3,3,4,1,1,3,1,5,5,5,5,3,3,3,5,3,3,2,1,4,1,3,4,3,2,4,3,2,2,1,2,3,3,1,3,4,2,5,3,2,1,3,3,5,4,5,5,2,5,2,1,2,1,4,5,3,3,3,4,2,4,5,1,1,4,4,2,2,3,2,2,5,1,3,4,3,3,4,1,2,5,1,3,2,3,1,3,5,3,2,3,1,2,4,4,3,1,3,1,1,3,3,5,5,4,3,2,4,3,1,4,3,1,1,3,1,5,4,4,1,3,4,3,5,1,5,4,1,2,2,5,1,4,1,1,1,1,5,1,1,5,4,5,4,3,5,2,3,2,1,3,2,4,3,1,4,3,4,4,2,3,2,5,3,3,4,4,5,2,2,2,2,1,2,1,2,1,5,1,1,5,4,3,2,5,3,3,3,5,3,4,3,2,4,1,1,5,2,4,5,5,5,5,1,1,2,3,1,1,2,3,4,3,4,5,5,4,4,4,3,4,5,2,2,1,4,5,5,3,5,1,4,5,2,5,1,4,4,3,3,1,4,1,2,1,3,1,5,3,5,1,2,1,5,1,4,1,1,1,5,5,2,4,1,2,4,1,4,3,5,5,5,5,2,5,3,4,5,4,5,1,4,2,5,1,4,2,4,4,3,4,3,4,2,4,1,5,3,2,4,4,1,5,1,5,4,5,4,5,5,5,2,1,4,2,2,1,4,3,2,4,2,2,5,4,5,4,1,1,1,4,4,4,2,1,2,1,2,5,2,4,1,2,3,1,1,1,5,2,5,4,3,4,3,2,4,4,4,5,1,5,2,3,3,2,5,1,3,4,4,3,1,1,2,4,2,1,5,5,2,2,3,1,1,5,5,3,5,1,5,5,4,5,1,3,2,4,3,5,5,1,3,4,3,3,4,4,3,1,2,2,4,4,3,4,3,4,1,5,1,5,5,3,2,4,2,1,4,1,4,2,5,4,3,2,3,1,4,3,5,3,2,1,4,3,1,5,1,2,3,1,4,5,3,4,4,2,5,1,4,5,3,2,3,5,1,5,5,4,4,4,4,1,5,4,4,4,1,5,3,4,1,1,4,4,2,3,5,5,5,1,1,3,5,2,2,2,3,4,4,1,4,1,3,5,5,5,1,5,1,1,5,4,4,3,3,3,3,4,4,3,2,3,1,2,3,5,5,5,5,4,3,2,4,4,5,5,3,1,1,5,1,2,2,4,5,2,5,4,4,1,4,5,1,5,1,5,5,3,5,3,3,3,3,5,3,2,3,1,2,3,5,4,1,5,3,5,4,2,2,1,4,1,2,3,1,3,2,4,4,2,4,1,2,4,1,5,2,1,2,2,2,4,5,1,2,3,1,5,1,3,2,3,4,1,4,2,5,4,2,5,2,1,5,4,4,4,1,5,4,4,4,2,4,4,2,5,2,1,3,2,2,5,5,3,1,5,4,2,1,5,4,2,2,2,4,5,1,5,4,3,2,3,1,2,2,3,1,1,1,5,3,2,4,1,2,5,5,1,5,5,2,2,5,1,2,2,4,2,4,4,4,4,5,2,5,3,2,3,1,2,3,5,4,1,2,1,1,5,2,3,3,2,4,2,4,5,2,1,2,5,2,4,4,1,3,4,4,5,1,1,5,4,4,4,2,4,1,4,1,3,4,1,4,4,2,1,2,3,5,5,3,2,2,5,4,2,1,2,4,4,2,4,1,4,1,5,5,4,5,2,4,2,1,3,1,4,5,2,1,3,4,3,5,3,4,1,5,1,4,2,2,4,1,4,4,5,4,4,4,3,5,2,4,3,1,3,4,1,1,2,3,5,2,1,5,2,1,3,5,3,3,2,5,5,1,2,2,3,1,1,4,1,5,2,4,3,2,1,1,5,2,5,4,4,1,5,1,2,4,3,4,2,3,4,5,1,3,5,2,2,1,2,1,2,2,5,3,1,4,2,2,1,5,2,1,3,1,1,3,5,3,3,4,5,5,1,3,5,1,2,1,1,1,2,1,1,5,1,5,5,2,1,3,5,5,2,5,5,4,1,2,1,1,2,5,5,5,2,1,4,2,1,1,3,4,4,3,5,4,3,4,1,5,5,3,4,2,3,1,1,3,4,4,3,4,1,3,1,1,3,5,2,1,4,4,4,4,5,3,5,5,4,1,2,4,2,1,4,2,4,2,2,2,4,3,3,5,2,2,3,1,1,1,2,3,5,3,4,3,1,4,4,1,5,2,2,1,4,1,4,3,4,1,2,3,2,5,1,3,4,4,5,5,1,1,1,3,5,2,3,5,2,1,3,5,1,4,4,2,3,3,4,5,3,2,1,4,5,3,5,1,1,1,5,3,4,5,1,5,4,1,5,1,2,4,1,4,1,3,4,4,5,3,1,1,3,4,4,3,5,5,2,3,4,3,5,1,3,4,2,4,3,3,3,1,4,1,3,4,2,3,1,2,1,5,5,3,1,1,2,5,5,4,4,1,4,1,5,3,5,1,4,4,4,5,5,2,2,4,5,1,4,5,3,1,5,1,2,2,1,3,4,1,3,2,1,5,2,2,2,3,3,4,2,4,1,3,2,2,1,3,5,5,2,4,1,1,4,3,1,3,3,4,2,3,3,4,3,3,3,5,5,2,4,4,2,2,2,4,5,5,3,5,2,1,4,1,5,5,2,3,4,2,5,4,5,1,5,3,1,1,3,4,4,1,3,2,3,2,2,5,4,5,2,1,2,2,3,3,2,2,5,2,1,2,1,5,2,3,2,4,1,3,3,2,5,4,2,1,2,1,2,3,1,3,4,4,5,1,3,3,5,5,3,2,2,4,5,2,4,2,1,1,1,1,5,4,1,1,4,1,1,2,4,5,4,1,5,3,4,3,3,5,5,3,4,4,5,1,4,2,4,5,2,3,1,4,4,4,3,3,3,2,2,5,4,5,4,3,1,2,3,5,5,1,5,4,2,5,2,2,1,3,1,5,5,3,5,4,2,1,5,1,1,3,2,3,1,5,1,5,4,1,1,2,5,2,2,5,3,4,5,2,4,1,1,2,2,5,4,2,1,5,1,5,3,5,5,2,3,3,2,2,1,2,2,2,3,3,2,3,3,3,3,5,3,3,2,5,3,4,2,3,3,1,5,3,3,4,4,2,2,3,2,4,5,1,5,5,5,3,1,3,4,5,2,3,5,1,5,3,3,5,4,1,3,2,1,1,2,5,2,2,1,1,1,5,1,5,1,3,2,2,3,1,1,2,5,3,4,5,4,4,5,5,1,1,3,4,3,5,5,3,5,4,1,1,1,4,3,3,3,2,4,1,2,2,3,1,1,3,2,2,4,3,2,4,1,4,5,4,3,3,4,2,2,5,3,3,4,5,5,3,4,2,2,4,5,4,3,2,2,3,4,2,1,1,1,5,4,5,4,3,4,2,2,3,5,2,3,4,3,5,5,5,1,1,4,2,3,4,2,3,2,3,4,3,3,4,3,1,1,5,4,4,5,1,2,2,3,4,5,4,2,5,5,2,2,2,1,1,2,1,2,2,2,5,2,5,1,2,1,5,3,4,2,1,3,1,5,4,3,2,4,4,4,1,1,2,1,1,3,3,3,4,5,2,5,4,5,4,4,5,3,1,1,3,1,3,4,4,2,3,5,2,4,1,1,5,5,5,1,4,1,1,3,1,1,1,5,2,5,5,3,1,3,5,3,3,3,5,2,3,1,3,3,4,4,4,5,4,1,5,1,4,5,1,4,4,5,2,2,4,1,1,2,2,3,2,4,3,5,2,2,3,3,5,5,2,3,2,2,3,3,1,4,3,3,4,5,4,5,5,5,5,3,1,1,4,3,3,4,4,3,3,2,4,4,3,4,3,4,1,4,2,2,1,3,1,5,2,1,1,4,4,3,1,5,4,5,1,4,4,4,1,1,4,4,1,1,3,5,3,2,4,4,5,4,1,3,5,2,2,4,4,1,5,2,5,1,3,3,1,4,2,5,1,2,5,3,5,4,4,2,2,5,3,4,5,2,3,4,4,1,5,3,4,1,3,1,3,4,3,4,2,5,4,2,1,5,1,1,3,2,3,3,4,3,2,5,2,2,1,2,5,1,2,2,2,2,1,5,1,1,3,1,5,1,5,3,5,2,5,2,4,4,5,5,2,3,2,2,3,1,4,5,2,4,5,5,3,3,3,4,2,1,4,1,5,1,5,5,5,2,4,5,4,4,3,1,5,3,2,4,1,4,1,2,3,5,3,1,4,2,1,2,4,3,3,2,1,5,5,2,3,3,1,4,2,4,4,2,2,3,2,3,5,2,5,3,5,1,1,5,1,3,4,2,5,2,1,2,4,3,5,4,1,2,4,2,4,1,2,2,5,2,1,2,4,3,5,1,1,2,2,2,3,3,1,1,4,4,3,4,3,5,4,2,2,2,4,4,2,4,2,3,4,5,3,5,3,3,5,2,3,2,2,5,4,2,2,1,2,5,4,3,3,4,4,4,1,1,5,2,2,1,1,1,1,2,1,3,3,4,4,3,1,2,2,5,2,4,5,4,2,4,3,3,4,5,5,2,4,1,5,2,5,4,1,2,3,4,5,5,1,1,5,4,5,4,5,3,2,3,3,2,1,3,4,1,1,5,4,5,5,2,1,1,5,2,3,1,4,2,2,2,4,5,1,5,1,4,5,5,1,1,3,5,1,2,4,2,2,4,5,4,5,5,2,4,2,5,4,1,2,5,3,3,5,5,4,2,5,1,4,4,3,4,5,1,2,5,5,2,4,5,3,2,2,1,4,3,5,1,2,3,3,3,3,2,1,4,4,3,1,3,4,5,3,1,1,5,4,4,1,3,5,5,3,4,5,5,3,1,3,1,1,2,5,5,3,2,1,4,1,3,2,5,5,4,4,5,3,5,4,5,2,1,5,3,2,2,4,2,4,1,2,5,5,2,4,4,4,2,4,1,3,4,3,1,3,4,4,4,3,5,4,1,4,4,3,5,1,3,4,1,1,1,4,1,3,1,1,4,3,4,5,4,5,5,5,2,4,3,4,5,4,2,1,3,5,2,3,3,4,1,1,1,1,4,3,4,1,5,3,2,1,5,3,3,3,4,2,2,3,4,5,2,5,2,3,5,4,3,2,3,4,4,4,1,3,3,2,2,5,2,1,1,4,3,5,4,2,4,1,1,2,5,5,3,2,5,1,1,5,1,2,5,5,4,2,4,4,1,2,3,3,1,3,5,2,4,2,4,1,3,2,1,4,4,1,2,4,4,5,2,4,3,5,4,5,4,1,3,4,3,1,3,3,3,2,1,1,4,2,3,3,3,5,4,4,2,5,1,5,4,3,5,5,2,3,4,4,5,1,5,1,1,4,1,4,1,5,5,1,4,1,5,4,2,4,2,2,3,2,2,3,4,2,2,1,5,4,4,3,5,5,1,4,1,2,2,1,5,3,1,5,4,2,4,3,1,5,1,4,5,2,4,2,1,3,4,3,2,3,5,1,4,1,3,2,3,2,3,3,1,5,2,1,2,4,3,4,2,1,4,3,3,1,4,1,1,3,3,3,3,2,3,2,4,1,3,3,3,4,4,3,2,2,5,4,5,5,5,2,1,1,1,1,3,1,1,1,3,3,3,4,1,4,5,1,2,4,1,3,1,3,3,3,5,2,1,3,5,2,2,2,4,4,3,4,3,4,3,3,2,5,1,5,1,5,4,3,3,5,3,5,3,2,2,4,3,3,1,3,1,5,3,3,4,3,3,2,4,3,2,5,3,5,4,3,1,3,1,3,3,1,3,3,4,3,2,2,2,1,3,1,1,1,4,1,1,4,3,5,2,3,1,5,3,5,5,2,1,4,1,4,5,5,5,4,3,5,1,5,2,3,2,5,4,2,5,5,2,2,4,3,4,1,1,1,5,4,4,1,1,2,3,5,4,3,5,1,2,5,5,4,2,5,2,4,5,2,2,1,2,4,3,5,5,1,4,4,5,4,3,3,2,3,3,1,2,5,1,4,4,5,3,1,2,2,1,1,5,4,4,2,1,5,5,5,4,3,1,3,2,4,5,2,3,4,3,1,2,5,2,2,4,5,1,4,4,4,2,5,4,3,3,3,4,2,1,3,2,1,2,3,1,4,2,4,4,5,1,2,4,1,5,2,5,3,3,4,4,2,2,4,2,3,5,5,5,4,4,3,1,4,4,2,1,2,5,4,3,5,5,5,3,4,2,1,1,4,4,2,3,5,4,2,1,4,4,1,5,5,2,2,5,3,5,3,3,1,5,2,3,2,4,3,3,5,2,5,4,5,3,5,2,5,4,4,3,4,1,3,4,5,2,4,4,3,1,2,1,5,4,4,3,1,1,4,1,4,4,1,2,4,1,1,3,2,4,5,5,5,5,4,4,4,2,5,2,1,1,2,1,1,1,5,5,5,3,5,2,1,3,1,5,5,4,4,4,3,3,1,3,4,3,5,1,3,1,3,4,3,4,2,4,5,3,3,1,2,5,4,3,1,5,2,3,2,3,4,4,4,1,3,3,2,1,4,1,2,3,2,4,5,4,4,3,4,5,2,2,5,4,3,2,4,5,2,4,2,4,3,3,2,4,3,4,4,2,1,3,3,1,5,5,2,3,4,1,4,5,5,3,4,3,1,3,4,5,4,3,1,1,2,5,4,3,1,3,2,1,2,3,5,3,5,4,4,4,1,4,2,4,5,1,5,2,2,5,2,3,3,2,3,3,5,1,1,4,2,1,5,1,2,1,3,5,1,5,5,1,1,4,1,2,4,5,4,5,2,3,2,5,4,4,5,2,5,3,1,5,5,2,3,4,4,1,1,5,2,4,5,2,2,3,1,3,2,4,5,2,1,4,3,3,3,2,2,5,1,3,2,4,3,3,5,3,3,2,2,3,5,2,2,2,2,1,4,1,1,4,1,3,4,3,4,1,2,3,4,4,2,1,2,5,4,5,5,4,5,3,1,2,2,5,2,4,2,3,3,1,3,2,5,4,4,4,5,4,4,1,1,1,5,1,4,1,5,3,4,1,2,4,1,2,4,3,2,5,5,2,5,4,4,3,4,3,5,5,1,5,1,5,1,4,4,1,2,2,1,3,4,4,4,3,3,1,2,4,5,3,3,2,5,3,4,5,3,2,4,4,3,5,2,4,5,4,3,4,5,2,2,5,2,1,4,5,3,4,4,5,2,5,1,3,1,3,3,3,2,1,3,2,3,1,4,5,5,3,2,2,4,4,4,4,2,3,5,3,1,3,1,4,4,3,5,3,2,5,2,5,4,2,3,5,5,3,4,3,3,2,4,4,1,2,2,2,4,1,2,4,4,1,3,1,3,2,2,3,4,3,1,4,3,3,4,3,1,3,2,1,2,3,5,3,3,4,3,5,4,2,2,3,3,3,1,3,2,2,3,5,3,1,3,1,3,2,2,1,1,1,2,4,1,2,2,1,2,2,4,2,4,4,5,5,3,5,5,5,2,2,2,4,5,1,5,4,4,3,5,2,4,2,2,2,1,2,4,5,3,1,5,4,5,5,2,2,4,4,4,1,1,4,2,5,5,3,2,3,4,4,4,3,5,3,4,5,1,4,4,4,1,5,3,5,2,5,2,2,2,2,2,3,4,2,3,2,3,5,3,5,4,2,1,3,1,3,4,2,4,2,3,2,4,5,2,4,5,5,4,3,2,2,1,1,3,4,1,3,5,3,1,1,2,1,5,4,3,3,3,3,4,4,3,4,1,5,3,1,1,2,1,4,5,5,5,1,5,3,2,4,5,2,1,1,3,4,4,1,5,5,3,2,1,1,3,2,1,2,3,5,1,4,2,1,5,5,2,3,2,1,4,3,5,3,1,4,2,5,4,1,1,1,5,5,5,5,2,4,5,2,4,3,5,2,4,5,5,4,2,1,3,5,5,4,3,1,1,2,3,4,4,4,3,3,2,1,4,5,3,5,1,1,4,3,5,5,2,3,5,4,5,3,1,1,1,4,3,5,3,2,5,4,3,1,5,1,3,1,4,3,5,1,3,4,2,3,2,4,1,1,2,5,2,1,1,5,1,4,3,1,3,1,2,2,3,3,3,2,4,1,5,1,2,3,3,5,4,4,4,2,5,5,4,1,4,2,4,4,5,1,5,4,5,2,4,3,1,4,1,4,1,2,2,1,4,1,3,4,4,5,5,3,4,5,1,2,2,3,2,5,4,4,4,1,5,3,4,2,4,4,1,2,3,1,3,5,3,3,1,1,5,4,3,1,1,3,1,3,2,4,5,5,3,3,1,1,3,5,3,1,1,1,3,1,3,4,1,1,5,3,4,5,2,4,3,3,2,1,4,1,4,2,3,3,3,5,5,2,2,1,4,2,5,3,3,1,1,5,5,2,3,4,3,2,3,2,4,2,2,5,3,4,3,3,3,3,1,4,3,4,4,2,1,4,4,4,5,1,3,5,4,2,4,1,2,2,3,2,1,4,5,4,1,5,1,2,5,4,2,5,3,1,2,3,3,5,4,2,2,1,3,1,1,4,4,1,4,4,5,1,2,3,5,5,4,5,2,1,2,3,5,2,5,2,2,1,5,4,1,2,5,2,3,5,5,2,5,5,2,2,4,4,5,2,2,4,1,1,1,4,1,3,4,5,2,3,1,3,5,1,3,3,5,3,1,3,3,5,1,3,4,3,1,5,5,3,5,5,4,2,4,3,4,3,5,1,5,5,5,5,4,4,1,5,4,3,3,5,1,3,4,1,3,2,1,5,4,4,3,3,2,4,2,3,1,1,4,5,4,5,2,2,5,4,5,4,2,1,5,3,4,1,1,2,4,5,1,1,1,1,2,2,2,1,1,1,3,3,1,4,4,2,3,3,4,4,3,5,5,2,4,3,3,5,4,1,5,3,2,5,3,5,4,2,1,2,2,5,1,3,3,4,2,5,3,3,2,1,4,5,2,3,1,1,3,4,4,4,1,2,2,3,5,2,1,1,2,4,1,4,3,2,4,3,3,5,1,4,1,5,5,1,3,2,3,3,1,3,1,2,3,2,4,4,4,2,5,2,5,5,1,4,4,1,5,5,2,5,1,5,2,5,4,3,2,1,2,5,1,4,1,5,1,3,1,5,1,2,5,2,5,3,3,4,3,1,3,1,5,1,5,2,1,2,4,1,5,4,1,5,5,1,4,4,3,3,5,2,5,1,4,4,4,4,1,5,5,4,3,2,2,2,3,3,2,3,5,1,3,4,5,3,2,1,3,1,4,3,2,2,2,5,3,4,1,4,5,3,4,3,2,3,2,5,2,5,4,4,4,2,1,2,3,3,4,2,1,4,2,2,3,3,5,4,5,5,4,2,2,5,1,1,3,1,2,3,5,5,5,2,3,5,4,3,2,2,4,2,4,1,4,1,1,4,1,1,2,1,2,2,5,2,2,1,4,3,1,3,4,2,2,4,4,2,4,2,5,1,3,3,3,2,3,1,5,5,4,4,2,5,1,4,1,1,5,3,2,4,4,3,2,5,3,2,5,3,3,5,1,4,1,1,2,5,4,5,1,4,5,5,3,3,4,2,4,5,4,3,5,3,3,2,3,2,3,3,5,4,2,2,4,3,2,1,5,3,1,3,5,3,4,5,3,5,1,1,3,5,1,2,5,4,2,2,5,2,4,1,1,1,5,3,5,4,1,3,4,5,4,2,1,5,4,3,5,4,5,3,2,3,1,3,2,5,2,3,4,3,3,1,4,1,1,3,5,3,3,1,2,4,5,3,5,2,3,5,1,5,2,3,3,3,4,1,5,1,4,3,3,3,5,5,3,4,2,4,5,3,3,5,1,5,2,1,5,2,2,3,5,3,5,2,1,4,3,4,4,5,2,2,4,5,1,4,4,4,3,5,2,3,3,1,4,2,3,4,5,3,3,1,4,1,3,4,5,4,5,2,3,1,4,1,4,4,4,4,1,2,2,2,3,2,3,3,1,3,4,2,3,2,4,3,3,1,2,4,1,4,1,5,1,3,3,4,5,5,3,3,4,1,2,5,3,5,4,5,3,4,1,4,1,5,5,5,4,5,5,2,1,3,3,5,5,2,5,2,2,3,5,5,5,1,1,2,4,2,1,1,2,5,3,1,5,4,3,1,4,1,1,4,5,2,3,3,1,5,3,4,3,2,4,4,4,3,3,4,3,5,1,2,2,4,1,3,3,3,1,5,1,2,2,2,4,4,4,4,3,1,5,2,5,5,5,3,3,5,3,2,2,4,2,4,4,5,5,3,1,5,3,2,3,2,4,5,2,4,5,3,3,5,2,5,1,2,4,4,5,3,4,3,5,1,3,4,5,4,3,1,2,1,5,5,2,2,5,4,5,4,4,5,4,5,4,3,1,4,3,5,5,3,3,4,4,5,5,1,5,3,2,2,5,4,3,2,4,4,2,3,5,4,3,2,1,4,1,4,4,4,4,2,5,5,4,1,5,5,4,1,3,4,5,5,1,3,4,4,1,3,5,2,2,1,1,3,1,3,1,4,1,4,4,5,2,4,4,3,2,2,4,3,4,2,3,4,4,2,4,3,5,2,4,5,5,3,4,1,1,4,2,3,3,4,3,3,4,2,1,5,5,4,3,3,5,4,1,3,1,4,1,3,1,5,3,4,4,3,4,2,2,3,3,3,4,5,3,2,5,2,4,2,5,2,5,4,1,4,3,3,1,2,4,3,5,4,3,5,3,3,5,2,5,3,3,5,5,1,4,3,3,2,1,3,2,1,4,1,1,3,3,4,1,5,1,1,1,4,5,1,4,2,1,3,2,5,5,4,2,2,5,1,3,2,1,3,1,2,5,3,3,4,5,1,3,2,1,3,4,3,5,2,3,1,4,5,4,1,1,2,1,5,5,4,5,2,1,5,5,2,3,1,2,4,5,1,4,2,2,3,2,1,1,2,2,2,1,2,2,1,3,5,3,3,4,2,2,1,2,4,3,2,2,1,5,1,4,4,4,3,4,5,4,1,5,4,1,1,4,3,1,2,5,3,2,4,2,3,5,5,4,2,5,4,4,5,4,5,5,1,5,4,3,5,2,5,2,3,4,5,3,1,5,4,3,5,2,1,2,3,4,4,2,3,2,2,4,3,4,2,4,1,3,4,2,3,3,1,2,4,1,5,2,4,3,2,2,1,1,5,2,1,5,1,4,2,4,3,3,2,4,3,1,4,2,1,2,3,5,5,3,2,2,2,2,2,3,4,4,4,1,4,4,2,4,3,4,3,5,5,4,1,2,2,4,5,3,2,2,2,1,5,3,3,5,3,2,5,3,5,3,1,1,5,1,2,1,3,2,5,2,5,1,2,4,1,1,1,3,4,1,4,4,1,2,5,3,2,3,5,4,2,3,4,3,5,1,2,4,1,3,3,5,1,1,3,4,1,1,5,1,5,3,4,2,2,2,2,2,4,4,3,5,2,1,3,5,1,3,3,3,4,3,3,5,2,3,1,1,5,5,5,1,1,2,1,5,2,5,1,3,4,5,5,3,2,3,1,1,1,3,4,2,3,3,5,5,5,5,3,2,4,2,5,4,2,4,5,5,3,2,1,1,4,5,4,2,5,5,4,2,2,4,4,4,5,1,1,1,3,1,1,2,3,2,5,2,5,1,5,4,3,1,3,1,1,2,2,4,5,1,3,3,4,5,3,3,2,4,1,3,4,2,5,3,5,4,1,3,3,3,1,1,3,1,5,5,2,1,5,2,2,3,1,3,3,4,5,5,5,4,2,4,4,4,5,2,5,5,5,1,1,5,3,3,5,3,5,2,4,1,3,5,1,5,4,2,5,5,3,2,2,1,5,2,5,3,3,5,2,4,2,4,5,2,5,4,2,3,3,1,2,1,3,4,2,1,5,1,1,3,5,1,2,4,5,5,3,3,3,3,5,5,5,5,4,3,2,4,5,5,1,5,2,1,3,3,1,1,1,1,4,4,2,2,2,5,2,4,1,2,2,3,2,2,4,1,5,2,4,4,2,1,2,4,2,2,3,3,5,3,1,1,1,1,1,4,2,3,2,5,1,4,1,1,4,2,1,5,2,3,1,1,5,4,4,5,1,3,2,5,2,2,4,1,1,1,5,4,1,1,3,4,3,3,4,4,1,4,4,1,3,2,4,3,3,5,3,5,3,1,2,1,5,3,4,4,4,5,2,1,4,2,3,1,2,5,2,2,4,1,5,4,3,5,5,5,3,5,4,1,1,2,5,1,2,1,1,5,5,1,5,4,2,5,1,5,1,1,5,4,5,2,1,5,3,5,4,3,4,2,4,5,2,3,4,5,2,5,4,3,4,3,1,1,3,5,2,3,5,4,1,2,1,4,5,4,4,3,1,3,3,2,2,5,4,4,3,5,4,2,4,2,5,3,4,4,4,5,1,2,4,4,1,4,2,2,1,1,5,4,2,3,3,2,1,5,4,2,3,4,2,1,2,2,2,5,2,3,3,1,3,5,1,4,4,2,2,4,4,3,5,3,2,4,3,1,2,3,2,3,5,3,5,5,2,5,1,4,2,5,4,5,1,5,5,4,1,4,5,2,4,5,2,5,2,1,3,4,3,2,1,1,2,4,2,2,5,5,3,5,5,1,1,3,1,1,5,1,4,5,5,2,3,4,2,5,3,4,3,1,4,4,1,5,4,2,1,3,5,4,3,4,3,4,4,2,5,2,3,4,5,2,1,3,4,3,1,4,3,3,5,5,2,3,5,4,3,5,4,3,2,5,3,2,3,5,2,4,4,3,1,5,2,4,5,1,2,5,1,1,3,5,5,4,1,4,2,3,5,4,1,3,1,3,5,4,5,1,4,5,2,3,5,2,2,4,3,4,4,1,3,3,3,3,3,2,4,3,3,5,1,5,3,5,4,1,5,3,4,5,2,5,2,3,4,4,4,5,1,3,1,1,4,2,3,3,5,1,5,4,1,5,3,1,3,1,5,4,3,2,3,4,3,1,4,5,5,5,5,4,5,3,5,5,5,5,4,5,1,2,3,1,3,5,3,4,3,2,2,3,5,1,2,2,2,4,2,3,4,4,1,5,2,5,1,2,4,4,4,2,4,3,5,5,1,1,5,1,4,1,1,4,1,4,5,3,3,4,4,1,3,5,1,2,2,5,3,4,2,1,3,5,3,1,4,5,5,4,3,1,5,2,2,4,4,5,3,5,1,2,5,2,1,5,5,3,2,4,4,5,5,3,2,4,4,2,4,1,2,2,5,5,4,4,2,2,4,4,3,5,1,1,5,4,2,4,4,3,5,2,5,3,3,1,3,1,5,5,2,4,4,5,5,5,5,2,1,3,5,5,4,3,1,2,2,3,2,5,1,2,1,4,5,4,5,5,3,1,3,2,2,4,1,1,2,3,2,2,1,2,5,4,1,2,2,2,1,3,5,1,1,4,5,1,2,2,1,1,4,4,4,1,4,4,5,2,2,2,5,4,3,4,1,3,3,4,2,2,4,2,5,1,1,5,5,4,1,5,3,1,3,4,2,3,3,3,3,5,3,2,5,3,2,3,5,4,1,5,1,3,2,3,4,1,2,1,2,2,5,1,2,3,5,1,3,1,1,4,3,3,2,3,3,1,3,2,1,1,1,3,2,4,5,4,2,3,4,2,3,5,2,2,5,2,5,5,3,2,5,5,3,5,1,4,4,2,2,4,1,4,4,3,5,3,3,5,3,1,2,4,4,5,4,3,3,1,3,5,5,5,4,1,4,1,2,5,4,1,1,5,4,2,2,4,1,1,3,3,4,5,1,1,1,5,2,4,3,5,1,5,5,2,3,5,5,2,4,5,1,2,1,3,1,3,5,1,5,1,4,1,2,5,2,4,5,4,3,4,1,5,1,3,4,2,5,1,1,4,3,4,3,5,4,5,2,3,3,5,5,2,2,5,5,5,2,4,5,2,1,1,1,3,2,4,5,1,2,5,4,3,3,4,1,3,2,4,4,2,3,4,5,2,2,3,5,4,3,5,1,2,5,2,2,5,2,2,4,1,3,3,5,3,3,1,4,5,4,4,1,5,3,1,2,2,5,5,4,2,5,2,3,2,2,4,1,2,5,2,1,2,3,2,1,3,3,3,2,3,1,1,5,3,2,2,1,4,1,3,2,5,1,4,4,3,2,3,5,3,5,5,4,3,5,2,5,4,1,5,3,2,4,2,3,2,3,4,4,2,2,1,3,2,3,1,5,2,5,1,4,2,3,4,5,2,4,1,3,5,1,1,5,4,2,2,3,5,2,5,3,2,5,4,4,3,3,5,3,4,2,3,2,2,4,4,3,3,3,5,5,1,4,1,3,5,1,1,2,1,1,1,5,3,5,4,4,3,1,1,5,1,5,2,1,2,4,1,2,1,4,2,1,3,3,3,2,4,4,1,5,4,1,2,5,4,4,1,4,3,5,4,2,1,5,2,3,3,4,2,2,3,2,4,2,5,5,4,3,1,3,3,1,5,3,4,1,4,2,4,3,4,2,1,3,3,4,4,3,3,4,5,3,4,2,1,1,5,4,2,5,3,2,5,3,1,5,4,3,4,4,5,5,5,2,4,3,3,3,2,3,4,2,1,1,2,3,5,4,3,3,1,3,1,1,2,1,4,3,1,3,5,2,4,2,1,4,4,4,1,1,3,4,5,1,1,4,1,3,4,5,2,3,2,3,5,5,4,3,4,2,4,5,3,4,4,5,1,4,3,2,2,4,4,4,3,5,2,3,3,4,3,3,4,2,2,2,1,1,5,3,2,4,4,5,1,3,4,4,4,1,4,3,1,4,3,1,1,5,1,2,2,1,3,5,5,2,1,1,4,5,2,3,4,2,5,4,5,3,1,5,4,2,3,2,1,4,2,3,2,3,1,2,5,4,5,4,3,5,3,3,1,5,5,4,1,5,3,1,5,3,4,3,1,4,2,2,2,2,1,5,2,1,3,1,5,5,4,1,3,4,3,2,3,1,4,5,4,4,5,1,2,3,1,4,5,1,1,4,5,1,1,1,4,2,3,5,5,2,4,4,5,5,2,4,5,1,3,5,2,2,2,3,5,5,5,5,4,1,1,1,1,2,5,1,3,5,4,2,1,4,3,2,1,2,5,2,3,1,3,3,1,3,2,3,5,4,5,3,1,2,3,5,1,1,1,4,5,4,4,5,5,4,4,1,3,5,3,2,2,1,2,5,2,3,3,1,4,5,3,4,4,5,4,3,1,3,3,3,1,1,1,2,1,3,2,2,1,3,4,5,2,5,3,4,1,1,5,4,5,5,1,4,4,2,4,5,3,2,5,3,3,1,2,2,1,3,2,1,3,3,2,1,2,3,5,3,3,1,2,5,4,2,1,3,4,4,2,5,4,2,5,1,3,2,4,3,2,5,5,5,3,1,1,4,2,5,5,3,5,4,5,3,5,5,1,3,5,5,4,2,1,5,1,5,4,5,1,1,5,2,2,2,1,1,1,1,1,5,2,2,3,3,1,3,3,4,1,3,4,1,3,1,2,2,2,3,3,2,4,2,4,3,4,4,1,5,4,5,2,1,4,2,1,5,1,5,4,2,3,4,4,1,2,4,1,2,5,5,1,1,3,3,4,2,5,2,3,1,5,2,3,3,3,5,2,4,2,5,1,2,4,5,5,2,3,3,1,2,1,1,3,2,3,5,2,2,4,2,3,2,1,1,4,4,2,2,5,5,4,1,5,3,2,3,1,4,2,2,5,5,3,3,2,2,3,3,1,5,5,3,4,3,4,3,3,1,1,4,4,2,3,2,5,3,3,4,3,2,5,3,4,3,4,5,1,2,2,5,4,3,5,2,1,2,2,5,3,3,4,4,3,4,4,1,3,4,3,4,2,3,3,1,5,4,2,5,4,1,5,2,5,2,1,5,1,3,5,2,2,2,3,3,2,4,4,4,1,4,4,5,3,4,2,1,5,1,1,2,4,4,4,1,4,5,3,5,4,1,5,4,1,4,2,5,1,2,1,4,2,5,2,4,3,2,3,3,5,4,2,5,1,4,2,5,3,4,1,3,5,3,2,1,4,5,1,4,3,2,3,5,1,5,4,2,4,1,3,4,2,4,2,5,3,3,4,5,4,2,1,2,4,2,5,2,2,2,2,5,3,1,2,1,1,2,3,3,1,5,3,3,1,5,3,4,4,1,2,1,5,4,2,3,4,2,1,2,2,5,2,1,2,2,2,1,3,2,1,3,1,4,2,1,1,1,1,1,2,2,3,5,4,4,5,4,4,3,4,1,3,3,4,4,2,3,2,2,2,4,1,1,1,4,4,3,3,3,1,2,2,5,1,2,4,5,5,5,1,3,4,3,5,5,3,2,2,4,3,1,5,3,2,2,3,5,3,3,2,4,2,2,5,5,1,5,3,3,3,2,1,2,2,2,2,5,5,5,5,5,3,2,4,2,2,1,1,1,1,3,4,4,3,1,1,4,4,1,5,3,5,2,1,2,1,1,2,5,5,4,1,5,1,3,2,4,4,4,1,4,2,1,3,1,3,1,3,4,5,3,5,3,2,3,4,3,1,3,5,1,5,1,4,4,2,4,1,2,3,1,5,2,4,3,3,3,1,2,3,2,2,2,3,3,4,3,5,4,3,3,5,3,1,4,5,5,4,1,1,1,5,2,3,1,5,2,5,2,4,1,5,1,5,2,2,5,4,1,2,5,2,3,5,2,1,3,4,3,3,2,4,3,5,1,2,3,4,5,1,2,2,2,2,5,4,3,5,3,2,1,2,3,3,4,4,2,1,3,2,5,2,3,4,5,1,5,4,1,4,5,4,2,1,4,1,5,2,3,1,5,4,4,2,2,3,4,3,1,1,1,4,1,1,1,2,2,1,5,5,4,3,3,1,4,2,2,2,4,2,4,1,1,4,3,4,1,1,4,2,4,4,4,2,4,1,1,5,5,4,3,3,2,3,5,4,3,5,3,2,3,2,5,4,3,2,5,5,3,4,5,2,4,4,1,4,3,5,1,5,2,1,1,2,3,5,3,2,1,2,3,2,2,5,3,4,1,2,4,2,3,2,5,5,5,5,2,4,2,4,1,1,3,2,2,5,5,2,4,3,2,5,3,2,5,1,5,1,4,1,2,3,3,5,2,4,5,3,2,3,2,1,3,4,2,2,2,4,3,1,1,3,4,2,2,4,4,1,4,3,2,1,2,2,4,5,3,3,3,2,4,4,2,1,3,5,2,2,5,5,5,4,3,2,4,1,2,1,2,1,4,2,3,5,2,4,2,5,4,4,1,5,1,3,2,3,4,1,2,5,4,1,2,4,5,2,1,5,1,2,4,5,4,3,4,4,4,5,2,5,1,2,2,2,5,3,3,1,3,5,2,5,4,5,3,4,4,2,2,4,3,2,1,2,4,4,3,4,3,3,3,4,2,4,4,3,5,3,3,3,3,3,5,5,4,3,4,3,4,4,5,5,5,2,1,5,1,2,1,3,5,3,4,3,1,1,2,1,4,3,5,4,2,2,1,1,1,3,2,1,4,3,4,4,2,1,5,1,2,1,3,1,5,2,1,3,1,2,3,4,2,2,5,3,2,5,3,5,4,1,4,4,5,3,1,2,2,5,2,2,2,4,4,1,1,2,2,2,5,4,4,2,1,3,5,1,3,2,1,2,1,3,4,2,1,3,2,4,3,4,3,5,2,4,3,4,1,4,4,4,3,2,1,1,2,1,1,2,4,5,1,3,3,3,5,2,2,5,4,1,2,5,1,3,4,1,5,4,2,4,5,5,4,4,2,5,3,2,3,1,1,2,4,3,1,5,4,1,2,1,1,3,2,5,1,2,4,1,3,3,1,2,4,1,1,4,1,1,1,5,3,3,1,1,5,2,5,1,4,1,5,5,1,2,1,1,5,5,5,1,3,1,1,2,4,3,3,5,4,1,1,4,2,3,4,3,4,1,5,5,3,3,5,2,4,4,2,4,1,2,5,1,4,5,4,1,1,5,1,3,3,5,5,5,3,4,4,2,3,1,2,5,5,2,3,4,4,2,5,5,2,2,4,5,4,1,4,4,5,1,1,1,2,5,1,5,1,4,3,1,4,4,3,5,3,1,3,2,5,5,2,2,2,5,2,2,4,2,3,3,2,3,2,5,1,1,3,4,3,1,3,4,5,1,5,1,2,1,5,2,4,5,3,5,4,1,1,5,5,4,1,3,3,2,3,4,5,3,5,5,5,3,5,4,2,3,4,1,3,1,4,1,4,4,3,1,3,1,3,5,5,3,4,5,3,4,4,3,3,4,2,1,4,4,1,1,1,4,3,2,3,5,3,1,1,3,1,2,4,1,4,4,1,4,1,3,4,3,5,3,5,4,1,1,3,1,1,4,3,3,5,1,1,4,5,1,3,4,2,4,4,4,5,3,3,3,1,4,2,5,4,1,1,5,1,3,3,5,3,3,5,3,5,3,5,1,2,2,1,1,4,4,3,3,4,3,4,4,1,1,4,3,4,2,2,4,3,5,5,2,5,4,1,5,3,1,2,1,3,1,2,1,3,3,1,3,1,2,2,3,2,5,2,4,1,1,2,4,4,5,1,5,4,1,4,2,4,2,2,4,1,4,5,5,1,5,3,4,3,5,4,3,5,1,2,4,3,2,3,1,5,5,3,3,5,4,3,5,2,5,1,2,5,2,1,5,3,2,1,1,4,2,1,1,3,2,2,5,3,2,1,4,5,3,2,2,1,1,4,2,4,1,1,3,3,1,3,2,4,3,1,4,5,4,2,3,2,5,2,2,3,2,2,4,5,4,1,4,4,4,1,3,2,1,5,2,3,1,5,2,2,4,1,5,3,2,3,5,4,1,1,5,2,3,5,4,3,4,2,5,1,2,2,1,3,3,5,4,5,4,4,2,5,5,2,5,3,2,5,3,3,3,2,1,3,1,1,2,3,4,3,5,1,4,5,2,1,4,3,5,4,4,4,5,1,1,1,3,2,5,3,4,4,2,5,1,1,3,2,3,1,3,3,5,3,1,2,1,4,2,2,3,2,5,2,5,5,1,2,2,5,2,4,1,1,1,4,3,5,1,4,4,3,5,3,2,1,3,5,3,1,5,4,2,2,1,5,5,4,1,3,1,3,2,1,2,5,5,3,3,4,2,5,1,5,2,5,4,4,3,1,1,5,2,5,1,5,3,3,3,2,5,1,4,3,4,5,1,2,1,3,4,4,1,1,3,5,1,4,2,4,1,1,1,4,1,3,4,2,1,3,3,3,4,4,4,2,4,3,5,5,5,2,5,3,5,5,4,2,2,2,3,5,4,4,1,3,2,4,2,1,1,1,5,4,5,2,4,5,5,2,5,5,4,3,4,1,5,3,1,2,4,5,2,2,1,1,2,1,1,4,2,1,3,1,4,2,3,5,3,4,3,5,2,1,3,3,5,1,1,1,2,4,1,4,5,5,3,3,1,5,1,2,3,3,5,1,1,4,5,2,5,3,2,1,5,4,5,3,5,3,3,4,3,1,3,1,4,2,4,4,4,2,1,2,2,1,2,2,2,5,1,2,4,2,2,1,2,5,4,1,1,2,4,2,3,1,3,5,3,3,5,4,5,5,1,4,1,1,2,1,1,3,5,4,5,3,5,5,1,2,2,1,5,2,3,5,1,5,1,3,3,2,1,2,2,3,4,2,4,2,2,3,5,2,3,5,4,4,4,5,3,5,5,3,2,2,3,2,5,3,2,1,2,4,4,3,5,5,2,4,1,4,1,3,1,1,4,3,1,5,1,4,2,4,3,2,1,2,1,2,1,3,3,4,4,5,4,5,5,3,4,5,4,1,4,2,2,3,1,2,3,1,2,1,5,4,4,1,4,3,2,3,5,2,1,5,2,5,1,1,4,2,5,5,2,5,5,3,1,3,3,2,4,5,2,1,1,3,3,4,3,4,3,3,5,3,1,1,3,2,1,4,5,1,3,2,5,5,5,1,5,4,5,4,5,3,1,2,1,4,2,4,4,5,1,2,2,4,5,5,5,4,2,2,4,1,4,2,4,3,3,4,1,1,4,5,1,5,5,2,4,3,2,2,2,3,3,2,4,1,1,1,2,3,5,5,2,4,4,3,3,1,3,3,5,5,5,5,1,3,5,3,2,5,2,4,3,4,5,1,2,2,4,1,1,2,5,4,3,3,2,1,5,5,3,1,4,2,4,5,3,2,4,3,2,1,4,1,4,4,3,1,4,4,5,4,1,1,1,3,4,5,5,1,2,3,3,4,2,1,3,2,5,1,2,5,1,5,4,4,5,3,2,1,4,1,4,1,2,1,1,3,1,4,4,1,2,2,1,5,3,3,5,2,5,4,1,2,1,2,5,3,5,5,4,3,3,2,4,3,4,2,3,3,5,4,1,4,4,4,1,4,1,3,1,5,2,2,5,1,2,1,1,2,2,2,5,3,2,5,1,1,1,3,4,5,5,4,5,3,5,3,2,5,5,1,4,1,2,5,3,4,5,3,4,1,3,5,3,4,5,4,4,2,3,5,1,5,4,1,1,5,4,4,1,1,1,3,1,4,2,2,1,3,5,3,3,5,1,2,1,5,5,5,4,4,3,2,2,3,5,1,5,1,4,4,1,1,2,3,5,5,4,5,2,3,5,1,5,3,1,5,1,2,2,3,5,4,5,5,4,4,5,5,4,5,2,5,2,5,1,5,1,1,3,3,4,1,3,5,4,3,5,1,5,3,4,2,1,1,5,5,1,5,1,2,2,1,4,1,4,4,4,1,2,1,5,3,5,1,1,3,1,3,5,3,5,3,5,3,4,2,2,4,3,5,2,4,1,5,3,4,3,1,5,3,3,3,1,1,1,3,2,2,2,5,5,1,4,4,5,3,3,5,1,1,5,3,4,2,4,4,5,1,3,1,4,1,3,3,2,4,5,4,3,3,3,4,5,2,1,3,2,4,4,4,4,3,5,4,5,2,2,1,2,5,1,5,4,3,3,3,4,5,2,3,4,2,3,4,2,5,5,1,5,5,2,4,4,5,1,1,3,4,1,4,4,3,5,3,2,1,2,1,5,1,5,5,1,3,4,3,1,5,1,2,3,2,5,1,2,2,3,5,2,4,3,2,1,5,5,5,4,4,2,3,1,1,5,2,4,3,2,5,1,4,4,4,5,1,3,3,2,3,4,1,2,3,2,3,4,2,2,2,4,4,4,5,4,5,3,4,1,1,5,5,5,3,1,3,3,3,1,1,3,1,3,5,4,1,3,3,1,2,4,4,3,4,5,1,3,4,3,2,5,2,5,5,5,3,5,1,3,1,2,2,5,2,5,3,5,1,1,5,2,3,4,3,4,5,4,1,1,4,2,5,1,1,5,3,4,1,4,1,1,2,4,2,4,1,3,1,2,2,4,3,3,3,3,1,3,4,4,3,3,5,1,2,1,2,4,5,1,2,2,2,3,2,3,4,1,3,1,4,3,3,2,2,3,1,2,5,5,1,4,5,3,4,3,1,4,5,2,2,4,1,4,2,2,4,3,3,4,5,5,2,4,4,3,2,1,1,2,3,4,5,4,3,3,2,3,4,5,5,2,5,3,4,3,2,4,5,2,2,2,5,1,3,3,3,1,2,1,1,1,1,3,5,4,2,1,5,3,1,4,5,5,5,2,1,2,2,5,4,5,1,1,4,4,5,4,2,1,4,3,4,2,2,3,3,2,5,3,5,4,4,4,3,3,2,4,3,5,5,2,3,1,5,3,4,5,4,1,3,5,2,4,1,5,5,3,5,2,1,5,2,3,4,3,2,1,3,5,1,2,1,5,2,4,5,4,1,5,3,2,2,5,2,2,4,5,5,1,5,2,1,3,2,1,2,2,2,3,2,3,2,2,4,2,4,2,3,3,5,5,4,4,1,4,1,1,5,1,1,4,2,2,4,3,5,3,2,5,2,3,4,5,5,2,4,2,2,5,4,1,1,4,1,1,3,1,4,3,5,2,1,1,5,2,1,3,5,4,3,3,3,5,1,3,4,1,2,4,2,1,3,2,4,2,5,3,2,2,1,3,1,2,4,3,2,5,5,1,2,2,5,4,5,4,3,2,4,5,2,1,2,3,1,1,2,3,4,5,4,4,3,4,4,2,4,1,4,2,3,1,3,5,1,4,5,2,2,4,5,4,1,1,5,2,4,2,5,2,2,5,2,1,2,1,1,3,3,4,5,3,1,2,4,5,2,2,5,4,4,1,4,1,1,3,2,5,3,1,5,1,2,1,5,1,3,4,4,2,1,5,4,2,2,2,3,2,2,5,3,5,2,2,1,3,3,1,3,5,3,4,5,1,2,4,4,3,2,5,2,4,4,2,4,1,5,5,5,1,3,3,1,3,2,2,3,1,3,1,1,5,4,4,2,2,5,1,1,1,2,5,1,2,5,5,2,3,5,1,4,5,5,2,2,5,5,1,4,5,5,1,3,2,3,5,3,1,4,5,4,5,2,3,3,4,5,4,1,3,1,1,2,4,2,4,5,5,5,1,5,4,3,1,5,1,1,2,5,2,3,3,1,1,3,4,3,1,1,2,1,1,4,4,3,2,2,2,4,1,1,3,1,3,3,3,2,3,2,4,4,4,2,4,2,2,5,3,2,3,5,1,3,3,2,2,1,5,2,4,2,1,3,4,1,2,3,3,3,3,1,3,4,3,5,4,4,4,2,2,3,1,4,2,5,1,2,5,2,1,3,4,5,2,4,5,3,5,1,3,5,4,3,2,5,5,2,4,2,1,4,5,1,4,5,3,3,1,3,2,4,5,2,3,4,5,4,5,5,5,1,1,5,4,1,3,4,4,5,4,1,5,5,2,3,5,5,1,4,4,5,3,1,4,5,4,5,5,2,1,5,2,2,4,4,5,1,5,5,4,3,1,2,3,2,4,5,2,4,3,5,3,2,1,3,5,3,5,4,1,1,5,1,4,4,1,3,3,4,2,1,2,3,4,5,3,3,1,2,1,4,4,1,4,5,3,5,3,3,3,5,5,4,2,3,4,3,4,4,3,2,4,5,1,1,1,4,2,5,5,1,2,3,3,1,3,3,4,2,1,5,2,2,3,4,5,5,5,4,1,2,2,3,5,1,1,4,4,4,2,2,3,2,1,4,1,1,1,5,2,3,5,3,2,1,3,3,5,3,5,3,4,4,2,4,3,5,1,4,4,1,1,2,5,5,1,2,5,2,2,1,5,2,1,1,5,4,3,2,1,4,2,5,4,3,3,2,1,3,5,2,1,2,1,4,2,4,3,4,2,2,4,1,5,3,4,4,1,1,2,1,1,2,2,1,1,4,2,2,1,1,3,1,2,4,5,2,3,5,5,2,3,4,1,1,3,2,1,5,2,1,3,5,2,5,2,3,5,4,2,5,4,3,2,3,4,1,4,5,3,4,5,1,4,3,4,5,4,1,2,5,2,2,1,1,2,4,4,1,4,4,4,2,3,1,1,2,1,3,2,5,3,1,1,2,3,4,3,1,4,1,2,1,2,2,3,4,2,4,5,3,3,1,2,5,3,2,1,5,3,1,5,4,3,4,2,1,5,1,5,5,4,5,3,3,3,1,5,2,4,2,5,2,1,4,3,3,5,1,5,2,1,5,2,4,5,2,2,5,2,3,4,4,4,1,1,2,1,3,4,4,5,1,4,4,1,1,3,2,2,1,5,5,4,4,3,5,3,3,1,5,3,4,3,3,3,3,2,3,3,4,3,4,1,4,4,1,2,2,2,3,3,5,1,4,4,2,3,5,3,5,1,1,5,1,2,4,2,1,5,4,2,2,1,3,4,5,5,4,3,5,4,1,3,1,5,3,3,4,5,3,1,1,4,3,1,3,5,3,4,3,2,5,5,3,4,1,4,2,1,5,5,1,4,4,1,2,1,1,1,5,3,1,4,1,1,5,1,3,3,3,2,2,4,4,2,1,2,5,5,3,5,1,2,1,1,5,4,5,5,4,2,3,1,4,3,4,4,2,3,1,2,4,3,3,1,2,2,4,3,3,3,5,2,5,2,3,1,4,5,5,3,3,2,1,3,3,4,3,5,3,2,5,1,4,4,4,3,1,1,1,1,1,3,2,3,1,5,1,4,3,3,5,1,2,2,3,5,4,4,1,1,4,2,4,3,2,5,2,4,2,5,5,4,4,1,5,2,2,3,5,2,2,1,2,5,5,5,1,2,5,5,1,4,1,4,2,2,3,1,3,4,4,5,3,4,5,3,1,5,2,4,4,1,3,5,3,5,4,5,5,2,4,2,4,3,2,3,2,5,4,1,4,5,4,2,1,5,4,1,5,5,5,4,1,5,4,2,5,4,4,3,1,4,3,2,5,4,1,5,1,4,2,4,4,2,2,3,3,5,5,2,3,4,2,4,4,1,1,4,1,4,4,1,5,4,3,2,2,1,3,2,4,3,3,4,2,4,5,2,1,1,2,2,1,4,2,2,5,4,3,4,4,1,2,3,4,5,1,5,4,4,1,1,2,3,3,3,2,2,2,3,4,1,3,4,3,2,4,1,2,4,4,5,4,4,3,5,1,5,5,5,3,1,3,5,4,2,5,2,1,4,4,3,2,1,4,3,3,1,2,5,2,5,3,4,3,5,5,4,4,5,1,2,4,4,5,3,3,2,2,1,2,5,4,4,4,3,3,5,4,1,2,2,1,1,5,3,2,2,2,3,4,5,1,3,1,4,2,1,3,5,2,5,5,5,2,2,5,5,3,4,4,3,4,3,2,2,5,5,2,3,1,2,4,3,4,5,5,4,2,4,1,2,3,1,5,4,2,2,1,3,4,2,4,1,1,4,2,1,2,4,2,3,3,3,3,1,4,1,3,3,3,1,1,5,2,2,2,2,1,1,4,4,1,1,3,3,2,1,1,5,1,4,2,4,2,2,4,1,2,3,5,2,2,5,3,2,5,2,2,2,2,3,2,2,4,1,2,5,5,3,1,1,3,3,5,2,1,1,2,5,3,2,3,3,4,1,5,4,4,4,3,1,4,2,2,3,2,4,5,3,5,4,3,5,2,4,4,3,3,4,5,5,4,2,2,3,5,3,1,5,3,5,2,2,3,1,5,1,1,4,1,1,2,2,4,2,3,4,5,2,3,5,2,4,5,4,5,4,1,2,2,4,3,4,2,5,5,2,3,4,2,1,5,5,4,2,4,3,4,3,5,5,3,4,2,2,1,1,5,4,3,1,4,5,3,4,3,3,3,4,1,1,5,2,5,2,5,5,5,3,2,4,4,4,4,2,1,5,2,1,4,1,1,1,4,5,3,3,2,5,3,1,4,2,3,4,3,2,4,2,4,4,5,3,1,5,4,3,3,4,4,2,3,3,1,1,1,1,3,3,4,3,1,3,3,4,4,1,5,1,1,4,1,5,3,5,1,5,3,5,2,1,4,2,3,5,1,4,2,4,1,4,4,3,1,2,5,4,3,4,5,5,3,4,1,5,5,2,5,2,3,5,3,4,4,5,4,5,4,1,5,2,3,5,3,2,2,3,3,2,5,3,1,3,1,4,4,2,5,5,1,3,2,2,1,5,3,5,5,2,3,3,4,4,3,1,3,2,3,1,3,3,1,4,4,5,2,4,3,2,2,4,1,2,1,2,4,4,2,1,4,3,3,4,2,2,2,1,2,1,3,2,3,4,5,4,1,1,2,1,3,3,1,4,5,4,5,4,1,1,1,5,3,3,2,3,3,4,5,3,1,3,1,1,5,1,1,4,4,4,4,4,4,5,4,4,3,4,4,4,1,4,4,2,4,1,1,1,4,3,5,1,2,1,1,4,1,2,1,1,1,2,3,5,1,1,2,1,3,1,2,4,4,3,1,5,1,1,5,4,5,5,3,4,5,1,2,2,1,4,5,1,1,1,4,3,1,4,5,2,4,5,3,1,3,2,1,4,5,2,5,2,5,5,4,3,3,3,4,5,4,5,2,3,2,5,5,5,4,3,3,4,3,3,5,5,2,2,3,5,4,2,2,5,5,3,3,4,1,2,1,1,2,2,4,1,5,2,3,4,5,5,2,1,1,1,2,3,5,3,1,4,1,3,3,1,5,3,3,5,4,1,4,5,3,1,1,1,4,1,5,1,3,3,1,2,3,3,4,1,3,4,2,1,1,3,4,3,1,3,5,5,3,4,2,3,2,3,3,4,2,3,5,2,1,4,5,3,1,2,3,2,5,2,1,4,5,5,2,4,3,2,3,1,5,2,2,2,2,5,1,2,1,5,2,3,5,5,4,1,3,5,5,1,4,3,1,1,1,1,3,4,1,4,2,5,2,1,3,1,3,4,4,4,1,3,5,4,4,5,2,5,3,1,1,1,4,3,4,2,2,3,2,3,5,1,1,5,1,2,4,1,1,2,1,1,3,5,1,5,2,3,1,3,4,1,1,2,5,3,1,5,3,3,4,4,1,5,2,5,2,1,5,2,4,3,4,2,4,4,5,1,2,2,4,1,4,4,4,3,5,4,2,2,2,3,3,4,4,5,5,4,2,4,5,2,2,2,4,2,3,3,1,1,1,2,3,2,4,2,5,4,2,4,4,2,4,1,4,5,5,5,3,2,2,2,3,2,2,4,3,1,2,3,1,1,3,2,1,3,3,4,3,5,1,3,4,5,4,4,1,1,1,5,2,3,5,2,4,1,3,4,2,1,3,1,4,3,3,3,5,1,3,1,4,1,4,2,4,3,1,3,4,3,3,3,3,3,3,4,1,4,1,2,4,1,2,2,5,5,4,2,3,1,2,2,5,3,2,2,2,1,3,3,3,3,5,1,4,2,2,2,2,4,1,4,3,2,2,3,1,2,4,5,5,4,4,5,3,1,1,3,3,1,2,3,2,2,4,2,1,2,5,4,3,3,2,3,5,2,1,3,1,2,4,1,5,2,2,3,3,1,4,3,3,2,3,3,5,2,2,1,4,5,2,2,4,1,2,4,2,5,1,3,3,1,2,4,1,1,1,5,1,4,5,1,1,1,5,2,5,3,2,4,2,4,4,3,3,1,5,3,2,4,1,1,1,4,5,4,2,3,1,4,4,1,5,3,2,4,5,3,2,1,2,3,1,4,5,5,4,2,3,2,3,5,5,2,5,1,5,5,2,1,5,2,2,2,3,3,1,2,3,3,5,5,4,3,5,5,5,3,1,3,2,4,5,1,5,3,5,5,3,5,2,4,2,5,3,5,2,2,1,2,4,5,1,5,5,5,4,3,2,4,4,3,4,5,4,4,5,3,3,1,1,1,3,3,4,4,4,2,1,3,5,3,3,4,1,1,1,5,3,5,3,2,1,3,2,2,5,3,3,5,1,1,3,2,4,1,4,2,1,1,2,4,5,5,3,3,4,2,5,4,5,2,3,3,3,5,5,2,3,4,5,4,3,2,4,2,1,4,3,1,3,5,4,4,2,5,5,2,3,1,5,4,2,3,5,2,4,4,2,1,3,5,4,3,3,4,5,3,3,1,5,1,4,4,1,1,5,4,1,4,3,1,1,1,1,3,5,1,5,5,2,1,2,2,3,4,1,5,1,4,5,2,2,4,5,2,2,2,1,5,3,2,2,3,3,5,4,5,3,5,5,2,2,2,2,2,5,5,5,3,1,5,5,1,2,5,2,4,3,1,2,4,5,5,4,1,4,5,3,1,5,3,2,1,2,2,3,5,2,4,2,2,2,5,1,5,5,1,5,4,5,3,5,3,5,2,4,5,4,3,1,4,2,1,4,4,4,4,2,4,2,3,4,1,3,2,4,2,1,2,1,1,1,1,3,3,1,5,1,2,3,5,4,4,3,3,5,4,2,3,1,1,2,2,1,5,5,3,1,2,5,3,1,4,4,1,2,1,3,3,5,3,2,1,1,5,5,3,4,3,2,3,2,1,4,5,5,1,1,4,3,4,5,2,1,3,5,1,2,1,4,1,3,4,3,4,3,3,4,2,5,4,3,5,2,2,5,1,1,3,5,4,3,3,3,5,5,5,3,4,2,4,2,3,5,2,3,2,1,5,5,3,3,3,1,1,5,2,4,4,5,5,3,5,2,3,1,2,1,2,4,4,5,5,3,2,5,5,4,3,3,5,4,5,4,5,2,3,1,4,4,1,1,4,5,3,5,2,3,1,2,4,3,2,5,2,4,5,5,1,4,5,3,4,1,5,3,5,5,5,5,3,3,5,3,3,2,1,5,2,3,1,4,5,1,2,3,4,3,5,3,1,3,1,2,1,1,5,4,3,4,3,3,3,1,4,3,2,4,3,4,5,3,3,5,2,2,1,2,2,2,1,5,1,2,2,1,2,5,4,5,4,2,4,4,1,2,5,1,5,5,5,1,5,1,2,2,2,2,3,4,5,1,2,5,3,1,3,3,3,2,2,5,5,4,4,5,5,4,2,2,1,2,5,5,5,4,5,5,1,2,2,5,1,4,2,5,4,2,3,3,3,3,3,5,3,3,1,5,5,1,5,3,1,2,2,1,2,3,4,3,5,2,2,2,2,4,5,3,1,4,5,4,1,2,3,1,2,4,5,5,1,1,5,3,3,3,3,2,4,5,1,2,2,5,4,3,4,5,3,1,5,3,2,5,2,4,2,3,3,4,3,5,4,1,1,4,1,1,3,4,5,1,1,1,3,2,4,2,1,5,3,2,5,2,5,4,5,2,4,1,5,3,4,2,4,3,5,4,3,1,2,3,4,4,1,2,3,2,4,5,1,3,3,3,1,5,4,1,4,4,4,3,1,4,4,5,2,5,1,3,4,2,3,1,3,5,4,5,2,2,5,2,3,3,2,3,5,4,2,5,5,5,4,5,5,3,1,4,1,5,2,3,5,4,4,5,1,5,2,4,3,1,3,2,2,3,4,5,5,3,3,2,3,4,1,2,4,5,3,3,1,2,2,1,4,4,5,3,2,4,3,1,5,2,1,5,3,4,4,2,2,5,4,1,4,4,2,1,5,1,5,4,4,4,5,2,2,2,3,4,1,2,1,5,4,3,3,4,2,4,2,1,3,2,4,1,4,1,4,4,4,5,2,2,2,4,1,2,1,1,3,3,5,2,5,4,4,2,1,4,1,4,5,2,4,4,2,3,5,2,2,5,5,1,5,4,1,1,3,5,5,5,4,1,2,4,3,3,4,2,2,5,5,5,3,2,1,2,2,4,2,5,3,3,3,4,2,3,2,2,5,3,5,2,1,5,2,4,4,1,5,2,5,1,1,5,2,4,1,4,2,2,1,4,5,4,4,3,4,2,3,3,4,2,2,3,5,1,2,1,1,5,4,1,3,3,5,3,2,5,5,3,3,2,2,1,2,2,5,5,3,4,2,2,2,4,2,4,2,1,4,1,2,5,2,1,4,2,2,5,1,3,3,2,4,4,4,4,5,2,1,3,3,5,2,3,3,3,2,5,2,5,1,1,3,3,2,3,4,5,2,2,3,1,3,3,3,2,1,3,1,4,1,1,4,2,3,4,5,1,2,4,3,2,3,5,3,5,4,4,5,3,4,1,3,3,4,4,5,4,1,3,2,3,2,3,2,1,4,2,2,3,5,3,1,4,1,1,2,3,5,5,5,1,1,3,4,3,5,4,2,2,1,5,5,3,2,3,4,5,3,1,2,5,3,5,4,1,4,3,1,4,2,5,3,2,3,2,3,1,5,1,4,3,1,1,2,5,4,5,1,5,1,5,4,5,4,5,3,4,3,2,5,5,3,4,2,1,4,2,5,2,1,2,3,5,2,2,4,3,2,5,1,3,4,2,1,1,3,3,1,2,2,3,4,4,2,1,4,3,3,4,1,2,5,2,1,5,2,4,4,3,4,5,3,5,1,1,5,1,1,4,5,4,2,5,3,4,5,1,4,5,2,3,5,2,4,5,2,4,4,4,3,2,2,3,4,1,1,4,2,2,5,1,2,5,4,2,1,4,3,1,3,4,2,3,1,2,4,4,3,4,1,3,2,2,1,1,3,3,4,5,5,3,5,4,4,2,3,5,3,5,1,3,3,1,3,3,5,2,2,1,5,3,5,4,5,3,1,5,2,1,3,2,5,1,5,3,3,5,5,3,3,1,2,5,5,5,2,1,5,4,2,5,1,1,2,2,1,1,3,3,5,5,2,4,4,4,5,4,3,1,5,3,2,1,2,2,4,1,1,5,2,2,5,3,3,5,3,5,2,2,4,1,1,4,4,5,4,3,2,1,3,1,5,4,1,5,2,5,1,4,2,5,1,1,4,1,5,5,4,5,5,2,5,3,2,4,3,4,3,4,4,2,3,3,4,1,4,4,5,3,1,3,5,3,5,5,3,2,4,1,5,3,5,1,2,4,5,3,1,2,2,5,3,3,3,5,5,2,2,2,2,5,1,2,2,3,2,1,1,4,3,4,2,4,5,4,2,4,1,5,4,4,3,3,3,2,2,3,4,3,3,5,2,1,1,3,3,2,2,2,5,1,4,1,3,4,5,2,4,5,2,3,2,2,3,1,2,3,5,2,5,5,1,2,2,4,2,5,2,2,2,1,2,5,2,3,2,3,2,3,5,3,3,4,4,5,4,2,2,3,2,1,2,3,5,4,1,1,5,5,3,3,3,4,4,5,5,5,5,4,2,4,2,2,1,1,4,2,3,5,2,3,3,1,5,4,5,2,1,5,5,3,2,1,2,2,2,2,5,4,3,3,5,1,4,5,4,2,5,5,4,2,4,3,3,5,1,4,2,2,3,3,4,3,3,2,3,1,3,4,4,1,5,5,1,3,5,4,5,4,3,2,4,4,4,1,1,4,5,4,3,4,1,2,4,2,5,4,1,5,5,1,3,1,3,1,3,5,3,3,3,2,1,1,5,1,4,1,2,3,4,5,4,3,5,5,5,4,4,1,3,5,4,3,5,5,3,5,3,2,1,3,4,2,1,2,4,5,2,5,1,2,1,2,2,3,2,4,3,1,5,2,1,4,4,3,2,4,2,2,4,5,4,2,2,1,2,4,3,5,1,4,4,1,4,1,4,2,2,4,2,3,3,2,1,2,2,3,2,4,2,1,1,4,5,3,2,2,1,4,5,4,1,4,3,2,4,1,1,2,3,2,5,2,5,1,5,4,4,3,4,1,1,4,2,2,3,1,3,5,4,1,4,5,1,5,1,1,4,3,5,4,3,1,5,3,2,2,3,4,5,5,2,2,3,3,1,4,1,4,3,3,4,2,1,3,2,3,3,1,2,4,3,2,3,3,1,3,5,3,3,3,1,2,4,1,3,2,5,2,3,1,4,3,1,4,2,2,5,2,2,2,5,1,1,2,3,2,3,5,5,5,5,2,4,2,3,3,5,2,4,2,1,5,1,3,3,4,2,5,2,4,3,5,5,1,4,5,1,4,1,5,3,4,5,1,2,4,4,4,1,2,2,5,4,2,5,4,4,2,4,2,5,4,2,4,2,2,1,2,1,4,2,4,1,2,4,1,1,4,3,1,1,5,1,3,3,1,2,5,4,1,3,1,3,3,5,1,2,1,2,2,3,5,5,5,1,1,4,2,1,2,2,1,4,3,2,1,3,4,5,2,3,3,3,2,2,5,4,3,5,5,5,1,4,4,4,5,4,3,4,5,2,2,2,3,4,4,2,1,1,5,1,5,1,4,4,2,5,3,2,3,3,5,2,3,3,4,4,5,3,1,5,1,2,2,5,1,5,2,2,2,2,2,1,2,1,1,5,1,2,5,2,3,4,3,2,4,5,3,1,5,2,5,4,2,2,1,3,2,2,3,3,5,5,5,2,5,4,3,2,5,4,3,1,2,3,2,4,1,1,4,3,2,2,2,3,2,4,3,2,5,2,5,3,2,3,1,4,4,2,4,2,1,3,1,1,2,4,4,5,1,2,2,3,3,1,4,2,1,3,2,2,2,4,5,2,1,2,1,1,5,5,4,4,4,1,3,3,4,3,1,1,1,4,4,2,2,4,1,4,3,4,1,1,5,4,5,3,4,3,1,2,2,2,2,2,4,4,1,3,5,1,3,4,4,5,4,2,4,1,5,2,3,5,1,5,2,2,5,5,5,1,4,1,1,4,3,5,3,2,4,3,3,5,4,5,2,5,4,4,4,5,3,5,4,1,2,2,2,3,4,4,3,4,1,3,3,2,4,5,5,1,2,5,2,2,5,2,5,5,4,4,4,1,1,4,5,4,5,2,3,1,3,3,4,5,1,3,5,1,3,1,4,5,3,1,2,4,2,2,5,2,4,2,4,1,4,2,4,4,3,4,2,2,4,3,2,2,4,3,3,4,3,5,2,5,3,3,5,4,2,5,2,5,4,3,4,2,1,2,3,4,4,3,4,3,3,2,4,2,5,5,4,2,4,5,1,1,2,4,4,3,1,1,3,1,2,2,2,5,2,3,2,5,3,2,1,3,4,1,3,2,1,5,4,3,4,4,1,5,5,5,3,2,3,1,4,5,3,1,2,1,3,3,2,1,1,3,3,2,5,5,1,1,2,1,5,4,5,5,5,4,3,5,4,1,5,4,2,3,4,2,3,2,5,1,5,4,3,3,3,4,5,4,3,5,3,2,3,3,2,3,3,2,1,5,2,1,2,4,2,3,3,4,5,5,2,2,1,5,3,3,5,2,1,1,2,2,2,5,5,5,4,4,4,2,3,3,4,1,4,1,2,3,3,3,4,4,1,4,3,3,1,5,4,3,5,4,4,1,4,5,5,4,5,4,4,5,3,2,3,3,1,5,1,3,5,1,5,1,4,3,2,1,3,4,1,5,5,5,5,4,1,5,3,3,4,1,3,4,5,2,2,2,3,3,5,5,3,4,3,4,1,2,5,4,2,2,1,3,5,1,3,1,3,5,4,2,3,2,2,3,3,2,4,3,1,3,2,5,3,4,5,5,2,1,2,5,5,4,1,5,3,5,1,2,5,5,3,1,5,4,1,2,3,2,3,3,1,5,2,4,4,4,5,2,2,2,2,4,2,4,5,1,4,1,2,2,1,5,4,1,3,3,5,4,5,5,4,3,3,5,3,2,3,2,5,5,1,1,1,2,2,1,4,3,1,2,4,3,2,4,5,3,1,3,3,4,4,5,3,5,2,4,4,4,3,2,3,1,2,1,4,4,2,1,1,1,5,4,5,4,2,2,2,4,2,1,5,4,3,3,1,5,1,3,2,2,2,2,5,5,2,4,5,2,5,5,3,5,3,2,1,1,2,4,4,2,1,2,2,4,1,2,5,4,3,3,4,1,3,5,5,1,2,3,2,5,2,3,3,4,1,3,3,5,5,5,2,1,4,2,1,5,5,5,3,5,4,1,2,5,1,2,2,4,4,5,3,5,2,3,4,1,4,1,4,2,1,2,4,5,2,3,1,1,5,3,5,5,2,4,3,1,4,3,2,4,2,4,2,4,5,2,2,2,1,1,4,2,4,5,4,4,4,1,2,5,2,4,3,3,3,5,1,2,3,5,2,5,2,1,4,4,1,5,5,5,3,3,5,3,1,4,5,3,2,2,4,1,5,3,4,2,4,5,4,2,2,3,4,2,5,2,2,1,3,3,2,4,2,2,3,2,2,5,3,5,2,5,5,4,4,5,3,3,4,1,3,1,4,4,4,1,5,2,2,3,3,2,1,4,4,1,2,4,2,4,1,1,5,5,4,1,4,4,3,1,4,2,4,5,5,1,1,2,4,2,4,1,2,1,1,2,1,5,5,2,1,1,1,4,5,3,5,5,5,2,3,4,4,5,1,2,3,4,5,1,1,2,3,3,3,5,4,2,3,2,3,2,3,1,5,4,5,4,2,1,5,3,4,1,2,3,2,1,2,4,1,1,3,5,1,1,4,2,4,3,1,1,5,3,1,3,4,5,5,5,1,1,3,2,4,5,2,3,5,4,4,2,1,1,2,1,3,4,1,4,4,1,3,1,3,3,4,3,2,1,2,3,3,1,1,4,2,4,1,1,3,4,5,3,5,2,1,1,2,5,4,3,3,4,1,4,5,2,3,5,2,4,2,3,2,5,3,3,1,2,4,3,5,1,2,5,1,5,1,2,2,5,4,4,4,2,5,5,1,3,5,3,5,2,2,2,4,4,2,2,4,5,3,4,2,5,3,5,1,1,1,5,3,1,1,3,3,1,1,1,1,1,2,5,1,2,3,3,4,3,3,4,1,1,4,1,3,1,5,5,5,5,1,1,3,2,1,2,4,3,4,4,1,4,4,4,1,2,1,4,5,5,3,4,5,4,3,2,1,2,5,2,1,4,1,1,5,2,4,5,3,4,4,4,4,4,5,2,3,5,1,4,3,5,2,2,3,3,3,5,2,4,2,5,3,4,4,3,2,3,4,4,5,5,2,5,3,1,1,5,3,5,5,4,1,2,5,3,4,2,5,2,2,5,4,1,4,1,4,2,4,4,2,2,1,2,4,4,2,1,3,5,1,4,3,1,5,5,4,2,3,1,4,5,4,1,4,2,1,1,2,2,5,4,2,2,2,2,3,5,1,3,4,2,5,5,4,4,4,4,4,4,5,5,1,5,5,5,5,5,5,4,1,4,2,1,3,3,3,3,3,3,5,2,3,1,5,3,5,1,2,2,1,5,5,3,1,5,1,1,4,1,1,3,3,2,1,5,5,2,5,1,4,2,1,1,1,3,4,5,3,5,5,3,3,1,2,5,4,4,3,4,3,4,3,4,5,1,2,1,5,4,5,1,1,1,5,4,3,4,4,3,1,2,4,1,1,4,5,2,5,3,2,3,1,4,3,1,1,1,4,2,2,4,4,2,2,1,1,2,2,5,1,4,1,5,1,3,1,3,2,3,4,3,4,4,1,2,4,2,1,5,5,4,4,1,3,3,3,4,1,3,2,3,3,4,5,2,2,5,4,5,1,2,1,2,4,4,1,5,4,1,5,4,3,5,2,3,2,1,3,5,4,1,4,5,5,3,3,5,1,2,4,2,4,4,5,3,2,5,2,2,4,5,1,4,1,3,4,4,2,4,2,1,5,4,4,4,1,5,2,2,3,4,1,5,2,5,5,1,2,2,5,2,1,2,5,5,4,5,4,3,3,5,4,5,4,1,2,2,3,1,2,3,4,5,2,5,1,3,3,5,1,5,2,5,5,1,1,2,5,3,2,4,5,4,5,2,2,2,4,3,5,3,1,5,2,2,2,2,2,1,2,3,1,1,2,5,2,5,1,2,2,3,2,4,1,2,3,1,1,4,2,2,3,2,5,1,4,5,4,3,4,4,3,1,1,4,5,1,5,4,1,5,3,1,3,2,4,3,5,1,5,3,5,4,2,3,3,1,2,3,4,5,4,1,4,5,3,5,2,3,5,5,3,2,3,5,4,1,1,5,4,2,3,4,3,5,3,1,4,2,2,3,1,4,4,4,4,4,3,3,3,1,4,5,5,2,1,5,2,2,2,4,1,5,4,2,1,4,4,1,4,2,2,1,3,4,5,3,3,1,4,2,1,2,5,4,2,2,1,2,1,1,4,2,5,1,5,1,1,1,3,2,5,4,1,2,1,4,5,4,2,4,1,3,1,3,5,1,1,5,5,4,4,2,5,4,2,1,3,4,3,2,2,2,3,3,4,3,4,4,1,3,1,4,1,1,5,1,5,5,1,3,4,5,3,3,2,3,1,3,2,1,1,2,3,1,4,4,1,3,3,3,2,4,3,5,1,5,4,5,3,4,2,5,3,2,4,1,5,5,4,5,4,2,3,4,2,5,1,5,2,3,2,4,3,2,1,4,5,4,2,3,3,3,4,4,2,3,1,2,3,5,2,2,5,3,3,2,5,2,1,1,4,3,5,1,1,3,1,3,2,1,5,2,3,2,3,2,3,3,2,2,4,1,1,3,1,1,3,4,4,3,3,1,2,1,3,5,5,1,2,2,2,2,5,4,3,4,5,4,3,3,3,4,3,1,4,1,1,3,3,5,3,1,5,5,3,1,3,2,2,1,1,4,1,2,3,5,2,2,5,1,4,5,2,2,1,5,1,2,1,2,1,1,5,3,4,3,3,3,1,1,3,5,1,5,5,5,5,5,4,5,2,4,5,4,2,1,2,2,2,4,3,2,2,5,1,4,3,2,1,1,5,3,5,5,3,1,2,2,4,3,5,3,1,5,4,1,4,3,1,5,4,3,4,3,5,4,3,4,3,5,3,3,5,4,4,5,3,3,4,2,5,1,1,2,3,2,5,5,3,2,5,4,1,5,4,3,3,4,5,2,1,3,3,4,5,5,2,5,3,4,1,2,5,4,3,3,5,5,2,1,3,1,2,3,2,4,5,1,1,1,5,3,5,4,4,5,1,2,5,4,4,1,5,4,2,4,2,2,1,2,1,1,4,2,3,2,5,3,1,3,1,4,1,5,5,5,1,4,1,4,4,3,2,4,2,3,2,3,1,4,3,5,3,3,5,1,2,2,1,1,1,3,1,3,3,4,4,4,2,1,5,4,3,1,3,3,5,1,3,3,1,2,4,5,2,3,4,3,4,4,2,5,2,1,5,3,4,3,2,5,1,1,3,4,2,1,3,4,1,2,5,1,1,3,1,1,4,2,1,4,1,4,5,5,3,2,1,2,4,1,3,5,2,4,1,1,3,4,3,4,3,5,5,3,4,3,2,5,1,3,2,4,5,2,3,1,2,3,3,5,4,2,1,3,5,3,4,4,5,2,2,5,1,1,2,4,4,2,3,2,1,1,4,5,5,2,4,4,5,2,2,3,3,3,1,2,5,1,3,4,1,5,5,3,5,4,2,5,4,1,2,5,1,1,3,5,1,5,3,4,2,3,5,4,5,4,5,1,2,2,3,2,3,1,1,2,2,2,2,5,1,2,3,4,5,1,1,1,4,3,1,5,5,1,5,5,1,3,2,3,1,1,1,5,4,4,5,4,2,5,5,5,5,5,5,2,5,5,1,5,3,1,3,5,2,2,5,1,4,5,3,3,5,4,1,5,5,1,5,2,4,2,3,1,1,1,1,2,2,4,5,3,1,3,2,2,1,4,5,5,1,3,4,1,4,1,3,4,5,2,3,1,3,3,4,4,5,2,3,2,1,2,5,1,1,2,2,5,5,1,1,4,5,2,2,5,2,1,5,5,5,1,2,4,4,4,1,2,5,3,5,3,1,2,2,3,3,2,2,2,4,2,1,3,5,5,4,1,1,4,5,1,2,2,4,2,2,5,5,4,1,3,1,4,5,5,4,5,3,3,2,2,5,1,1,3,2,2,5,4,4,5,1,4,2,2,5,2,4,5,2,3,5,1,3,5,4,4,2,2,1,3,4,1,5,2,1,1,4,3,1,5,3,4,2,4,2,5,4,3,4,5,3,5,1,3,5,3,3,1,4,4,3,5,3,5,5,3,5,4,3,5,5,1,2,5,3,4,3,4,1,5,4,5,3,1,3,1,5,2,3,1,1,1,1,5,5,5,5,3,1,2,3,5,2,3,3,5,3,5,3,1,2,3,5,5,4,3,3,3,2,4,4,1,3,3,2,2,1,4,3,5,5,4,4,1,2,5,5,5,5,3,3,1,3,5,1,1,3,5,1,4,5,4,4,4,1,1,2,5,4,4,5,3,4,3,1,2,5,5,1,2,5,2,3,4,1,5,2,4,3,3,3,5,5,1,2,3,1,2,2,4,2,3,4,1,1,1,3,5,3,1,2,1,1,3,5,2,2,5,3,4,4,2,2,1,2,1,2,5,3,3,3,5,4,5,2,2,3,5,2,1,1,5,4,1,5,5,1,5,4,3,1,2,1,4,5,3,3,2,2,5,1,2,5,3,1,1,2,3,4,1,1,5,1,1,3,4,1,4,2,5,5,3,3,2,4,5,3,2,3,3,4,1,4,3,2,1,1,3,2,3,4,1,1,1,1,5,4,5,1,5,3,3,5,3,4,3,2,4,3,2,5,4,1,5,5,4,2,3,3,3,5,2,1,5,3,4,3,4,1,2,2,3,2,4,5,3,3,4,5,3,2,5,5,1,2,5,5,1,2,2,4,1,2,1,3,3,2,3,1,3,2,4,4,3,4,5,3,2,1,1,4,3,4,4,4,2,4,1,5,3,1,2,1,1,2,2,1,1,2,5,3,1,1,4,3,4,1,4,4,2,2,3,2,3,1,2,2,5,4,4,3,4,2,1,5,1,3,2,5,4,3,5,3,3,2,1,4,4,1,2,3,1,1,5,4,4,2,4,4,5,1,4,1,1,4,1,2,4,5,1,3,3,4,2,1,4,3,4,5,2,4,4,1,1,2,4,5,2,5,2,4,1,1,1,5,2,4,4,1,4,3,3,1,2,4,1,2,5,4,1,5,1,5,1,1,4,1,3,3,3,2,2,5,3,4,2,3,2,3,1,2,4,1,4,1,2,2,1,4,2,2,4,2,4,1,4,3,2,3,3,1,3,1,1,3,2,2,5,3,5,4,5,4,5,1,3,4,1,1,3,2,2,2,1,5,2,1,4,1,1,3,4,5,4,3,5,1,4,2,5,4,4,5,4,4,1,1,4,4,4,5,4,4,1,2,4,5,4,4,2,2,3,1,1,1,3,5,3,2,5,2,3,3,4,1,2,1,4,3,2,4,4,4,3,2,2,4,2,1,4,1,2,1,4,3,5,3,3,1,2,1,3,5,1,4,5,2,4,1,1,5,3,3,2,3,3,1,3,1,5,5,3,5,2,1,2,5,4,5,4,4,5,5,1,4,1,4,1,5,3,3,4,5,5,5,4,3,2,4,4,4,2,1,1,5,2,5,2,1,4,5,3,3,5,3,5,4,2,4,1,4,5,3,4,4,5,3,5,5,1,1,3,1,4,5,3,4,2,3,4,5,5,2,4,4,4,5,5,3,4,1,4,5,1,5,1,2,2,4,3,3,5,5,2,1,5,2,1,1,3,5,3,1,2,2,2,1,4,4,1,3,4,5,3,4,1,4,1,3,4,1,4,1,5,2,3,2,2,4,2,3,3,4,1,1,2,1,2,5,3,3,4,4,5,3,2,1,1,2,1,1,4,4,2,1,4,3,4,4,3,4,5,3,5,1,3,3,4,2,1,2,4,2,2,5,4,3,2,5,5,4,5,2,5,5,2,3,3,2,3,2,4,5,4,3,5,5,4,4,4,3,3,5,4,2,5,4,1,1,4,5,4,4,2,1,5,4,1,3,2,5,5,4,1,1,4,4,1,2,3,1,3,1,4,4,1,3,3,3,2,2,4,3,3,4,3,5,2,4,5,2,2,5,3,2,4,2,2,5,1,4,2,1,4,1,2,5,3,4,5,3,1,2,1,2,5,1,1,4,2,2,5,2,1,3,2,1,2,5,4,4,5,5,2,2,4,5,4,4,4,3,2,2,5,3,3,5,2,2,3,4,3,2,1,4,3,1,2,2,2,1,2,3,1,3,1,3,5,5,4,2,4,4,3,2,4,1,4,1,3,5,2,2,4,3,4,3,5,4,2,2,1,3,5,2,2,1,1,3,2,5,3,5,3,4,2,5,2,5,4,2,1,3,1,2,3,3,4,1,1,4,1,3,5,1,1,5,5,5,4,2,5,1,2,5,5,5,1,5,1,2,5,3,3,1,2,1,2,2,1,4,2,5,1,3,2,5,1,3,3,3,5,3,3,4,4,2,5,4,5,4,2,1,4,4,3,4,1,4,5,1,2,3,4,3,4,2,5,2,1,3,4,4,3,2,3,1,2,3,4,3,4,3,2,4,5,2,4,2,5,5,2,2,4,2,2,5,5,2,4,4,4,1,1,5,4,1,4,4,3,4,5,4,5,2,2,4,2,4,5,3,5,2,2,1,5,1,5,3,1,4,3,4,5,1,1,5,3,4,4,3,1,4,3,3,3,1,4,2,1,4,2,2,2,2,2,1,1,5,5,5,5,3,4,4,2,2,4,4,2,4,5,3,2,4,4,5,1,1,2,4,5,1,1,4,3,3,3,5,1,5,3,5,3,5,3,5,5,1,2,2,1,5,1,3,5,1,5,5,3,4,2,3,4,4,4,3,5,5,4,1,2,4,1,4,1,4,1,3,1,4,4,5,5,2,5,4,3,3,5,1,2,5,5,5,1,1,4,1,5,4,1,2,3,2,4,4,1,5,3,4,2,5,4,4,4,2,4,1,3,5,2,4,5,5,3,1,2,3,1,4,4,3,4,4,5,3,3,5,1,3,5,1,4,1,4,1,2,1,4,4,2,1,1,5,4,4,2,1,5,4,1,3,1,5,2,5,2,2,2,3,1,5,4,3,2,2,4,2,2,1,5,2,5,3,1,5,1,5,4,3,1,2,1,2,4,2,5,1,1,3,4,3,5,5,3,2,5,2,1,2,5,3,2,4,2,5,4,5,2,3,5,4,1,2,2,5,1,5,1,2,2,3,5,5,5,1,1,4,2,4,5,5,1,3,5,3,1,1,2,1,2,5,1,5,1,1,2,5,5,4,1,2,5,2,4,4,2,3,4,5,2,5,5,3,1,4,1,5,2,1,5,5,4,2,3,4,2,2,1,1,5,1,2,1,2,3,3,3,3,1,1,2,4,3,1,3,5,5,5,5,1,5,3,3,3,3,5,5,5,2,1,1,5,2,3,1,4,1,3,3,1,4,1,5,3,1,5,5,5,1,1,3,3,3,3,5,1,3,1,5,3,1,5,3,1,1,4,1,2,4,5,1,4,3,5,5,4,4,5,2,2,2,5,4,5,5,1,1,1,2,4,5,2,5,4,1,4,3,3,4,4,1,1,1,4,1,1,5,2,3,2,1,1,4,4,4,1,1,2,3,2,5,1,1,3,5,5,2,1,1,3,5,1,3,3,3,4,2,5,3,4,4,5,1,5,4,3,2,4,1,2,4,5,2,5,2,5,5,2,5,5,1,4,1,4,4,2,1,2,5,3,1,3,1,5,3,1,2,2,3,5,5,5,4,1,5,2,2,4,4,4,3,5,1,4,1,4,3,1,1,2,2,5,4,4,2,1,3,1,2,1,4,4,2,3,3,4,5,4,5,1,4,2,1,1,1,4,2,4,5,5,4,4,5,1,4,2,3,4,4,2,5,4,2,5,2,5,4,4,2,4,4,2,4,5,1,3,4,1,1,3,1,1,2,5,4,1,5,5,5,3,3,5,4,2,3,5,1,2,4,3,1,1,5,1,5,1,4,5,1,3,1,4,1,4,1,2,3,1,1,2,4,3,3,5,3,5,3,3,2,4,4,3,2,1,4,2,2,4,2,4,5,1,2,5,1,5,2,2,2,1,4,2,4,4,4,1,2,1,2,3,3,1,1,4,3,3,3,3,1,3,5,2,2,4,2,3,1,5,3,5,3,5,4,2,2,2,1,3,2,4,4,3,5,3,2,1,1,4,4,4,2,2,4,2,3,3,5,3,1,1,3,2,2,1,1,2,4,2,4,4,4,4,1,1,2,1,1,4,3,1,5,1,1,2,2,5,4,1,5,1,1,1,2,3,2,3,1,1,1,2,5,4,1,3,3,4,1,4,1,4,4,1,5,2,2,3,1,4,5,4,4,4,3,5,2,1,3,2,2,2,1,1,2,1,1,4,2,3,4,1,5,4,3,1,1,3,4,5,4,4,4,4,4,3,1,3,3,3,4,2,1,1,5,1,2,5,2,3,5,2,5,4,3,4,3,1,1,3,1,2,2,2,4,2,2,2,1,1,2,1,2,4,4,3,1,1,2,5,5,2,1,3,1,5,5,3,2,2,5,1,1,5,1,1,4,1,3,5,4,4,2,4,2,1,1,1,4,2,5,2,4,1,2,1,1,3,1,4,2,2,5,4,5,1,4,4,2,5,2,3,3,3,2,3,1,3,2,3,1,2,5,2,5,2,5,3,5,5,3,4,4,5,4,5,5,2,1,1,2,1,5,3,1,1,3,2,3,5,2,5,3,3,2,4,5,4,1,1,2,2,4,4,5,2,1,5,1,4,5,5,1,3,2,4,4,3,5,4,5,2,1,4,2,3,2,1,2,3,5,5,2,1,2,4,1,2,5,1,4,3,5,2,4,5,1,2,2,2,1,3,4,1,4,4,4,5,3,4,3,1,3,4,2,5,5,3,1,2,4,3,5,1,4,5,2,3,2,4,3,1,1,1,2,2,2,4,1,5,3,5,2,1,4,3,5,1,3,2,1,4,4,1,2,2,2,5,4,4,5,4,4,1,4,5,2,2,4,4,3,5,2,1,2,2,2,3,1,4,2,2,3,1,1,2,1,2,5,3,2,1,1,4,4,5,3,4,5,5,3,4,2,5,5,3,3,2,5,2,1,5,3,2,5,2,4,3,5,5,4,3,5,4,5,3,2,3,4,4,5,4,2,2,1,3,1,1,3,4,3,1,2,4,2,1,3,2,4,1,3,3,5,3,5,1,2,4,5,5,2,3,4,2,2,5,4,5,3,2,1,2,3,2,4,3,4,2,2,4,1,4,2,2,1,5,4,2,1,3,1,2,4,4,5,3,4,2,1,5,4,4,3,5,4,1,1,3,4,1,5,1,2,1,3,1,2,1,1,5,3,3,5,1,5,3,5,2,2,2,1,4,3,4,3,3,4,1,1,4,3,2,4,1,5,1,3,2,4,3,4,4,4,1,4,1,2,1,5,4,4,2,1,2,2,5,1,3,5,2,4,5,3,5,3,1,3,3,1,1,1,4,5,4,3,4,5,3,5,3,3,1,2,4,2,3,1,4,5,4,1,5,4,3,4,2,2,5,2,1,1,1,5,4,2,5,1,4,2,1,2,5,4,5,1,3,4,4,4,2,3,5,4,4,5,4,3,5,2,2,4,2,1,3,4,1,5,1,3,2,2,5,3,3,1,5,1,3,2,4,3,5,2,3,2,5,3,3,2,4,2,2,2,2,3,3,3,1,3,4,2,1,1,1,1,3,5,3,4,5,5,3,1,1,2,2,3,3,3,3,3,4,3,4,4,3,1,3,2,5,2,2,5,1,1,4,3,5,2,3,5,4,3,1,1,4,1,2,4,2,4,4,4,5,4,5,1,1,5,4,3,4,1,4,5,5,2,4,2,2,5,5,5,3,2,4,1,3,2,2,1,3,5,4,5,2,3,1,2,4,1,3,4,2,2,3,5,1,3,2,4,4,3,4,3,2,2,5,5,1,1,3,5,2,3,4,3,4,2,2,1,2,2,4,4,3,4,1,3,3,3,1,4,5,4,1,5,4,5,2,5,3,2,5,5,5,1,4,2,5,1,5,2,1,4,2,1,4,4,2,4,5,3,4,1,2,3,2,3,3,3,2,5,2,3,4,5,5,1,1,2,4,2,5,3,2,4,3,4,4,5,5,1,1,1,5,2,1,3,1,3,1,1,1,1,3,5,4,3,1,4,1,2,1,4,3,4,3,3,5,4,1,4,2,4,2,1,5,4,4,5,1,4,3,5,4,4,4,4,1,3,2,1,1,5,4,4,3,2,1,5,3,4,4,1,4,2,2,4,5,1,3,3,2,5,1,1,3,2,5,5,5,1,2,5,2,1,1,4,2,5,4,3,1,1,1,5,4,3,5,2,5,2,1,5,4,5,5,1,5,4,1,5,1,5,3,2,3,3,4,3,5,5,2,2,2,1,2,3,2,2,4,3,2,3,1,5,2,3,3,4,3,3,2,1,3,2,5,1,5,4,1,5,2,3,3,1,3,3,3,2,5,3,3,4,5,2,1,3,5,5,1,3,5,1,4,3,2,5,5,3,5,4,3,4,3,2,3,3,2,2,3,5,5,4,4,2,4,4,4,1,5,2,3,2,1,5,4,5,1,5,1,2,5,4,3,2,1,5,2,2,1,5,1,1,2,1,3,4,5,4,3,1,1,3,4,2,3,5,3,4,4,3,1,4,1,3,2,1,1,4,3,5,1,1,4,5,2,2,3,4,3,5,2,1,2,3,4,3,2,3,4,4,4,5,5,2,2,5,1,4,4,4,5,1,4,2,4,2,2,3,5,3,2,5,2,1,2,2,2,1,4,4,1,3,3,1,1,5,3,5,4,1,1,3,4,3,2,4,1,2,1,1,2,1,5,1,3,4,3,2,5,3,4,2,4,3,1,2,4,5,3,5,2,5,4,5,2,1,4,4,1,1,1,3,2,2,4,1,3,3,1,3,1,4,1,4,3,2,3,3,4,3,5,2,2,5,4,2,5,3,4,2,1,4,4,1,5,4,4,1,3,3,3,4,1,5,5,2,5,1,1,1,5,3,3,2,4,5,5,2,4,4,3,4,4,1,1,2,4,4,2,5,3,2,2,4,5,1,1,2,4,3,2,2,2,4,4,5,1,3,5,2,1,4,3,2,2,4,4,3,5,1,5,2,1,4,2,1,2,1,4,5,2,2,2,4,3,5,3,1,2,2,2,3,5,1,5,4,4,2,3,5,2,3,1,4,4,5,5,3,3,4,4,1,5,3,4,4,2,3,2,1,4,3,1,2,3,3,5,4,2,1,1,3,1,1,3,2,1,1,1,2,5,5,5,4,1,1,3,4,2,2,2,2,2,3,2,3,1,1,3,4,3,5,1,2,3,2,4,3,1,5,3,2,5,4,4,2,5,2,5,2,1,2,1,5,1,4,5,2,2,3,5,1,3,3,5,1,2,5,5,3,3,5,2,2,3,2,2,5,5,4,4,2,4,5,1,4,1,3,3,5,2,3,3,2,1,4,1,1,4,5,2,2,3,3,4,5,2,2,5,5,5,4,1,1,2,4,3,2,3,4,1,5,4,1,2,4,2,1,5,4,1,1,1,5,5,1,2,3,1,2,2,1,4,1,5,1,4,1,3,1,3,1,1,5,3,3,3,1,2,3,2,2,1,2,4,1,4,4,5,1,4,2,5,1,2,1,4,3,2,3,5,3,1,1,4,1,3,1,1,3,5,4,5,5,5,2,4,2,1,3,1,1,1,4,1,3,5,4,1,1,4,1,4,1,3,5,4,5,4,2,5,3,1,4,1,2,5,4,1,1,1,1,1,4,3,3,4,2,4,2,1,4,5,5,3,2,2,4,1,4,3,5,1,5,4,2,3,3,2,1,1,3,1,2,2,3,1,2,5,3,3,5,1,2,3,4,2,5,2,3,1,5,1,4,2,4,5,4,5,2,1,1,5,2,5,4,5,5,4,2,5,5,2,1,4,4,3,3,5,3,4,4,3,2,3,3,2,4,3,2,2,1,1,1,5,1,1,5,1,1,5,4,2,2,1,3,3,4,5,5,3,3,5,3,1,4,3,3,1,4,2,2,4,1,5,5,1,5,1,3,5,3,2,2,2,5,3,4,2,2,4,5,5,1,1,2,4,2,5,1,5,2,2,1,3,2,1,4,4,1,4,1,4,3,4,4,2,3,3,2,5,5,3,4,3,3,4,5,1,5,5,2,5,1,2,3,4,1,5,1,1,1,1,4,1,4,5,3,2,5,5,4,1,3,3,3,3,5,2,4,5,5,2,3,5,4,5,1,4,3,2,2,3,1,1,4,3,4,5,5,4,3,1,3,3,1,5,4,3,2,2,1,4,2,1,2,5,5,2,4,4,3,1,2,2,5,4,5,4,4,5,3,5,5,4,1,4,5,5,2,2,4,2,1,3,1,2,5,5,1,5,5,4,2,2,5,3,1,5,4,5,5,4,3,3,3,5,5,5,1,4,5,3,4,2,1,1,5,2,4,3,1,2,4,2,2,1,4,5,1,4,2,2,2,3,5,3,1,1,4,3,5,1,4,3,2,4,1,5,2,4,4,1,2,1,1,1,3,1,4,5,4,5,1,1,2,2,1,3,4,1,1,4,3,3,1,2,5,1,2,5,4,1,2,1,4,4,1,1,3,2,4,3,4,2,5,1,1,4,1,3,5,1,5,5,1,5,3,4,5,3,4,4,3,1,4,4,5,5,5,4,1,2,3,2,5,4,2,4,5,1,4,3,1,1,1,2,4,3,4,1,2,4,2,1,5,4,4,1,3,5,1,2,3,3,3,4,3,5,1,4,1,2,5,1,5,5,2,4,1,3,5,2,3,1,1,2,1,4,3,3,2,2,4,5,4,2,2,2,5,4,5,2,1,4,4,3,1,3,2,4,4,2,5,3,2,3,5,3,3,1,2,2,5,4,1,4,1,5,1,5,4,2,5,5,5,2,3,4,1,4,3,4,1,4,5,1,2,4,2,1,3,4,4,3,1,1,2,4,1,5,2,1,5,3,5,2,2,3,2,2,5,4,4,3,4,2,5,1,3,1,4,1,3,5,1,3,1,2,4,1,4,3,2,5,3,3,3,2,4,2,5,2,1,2,4,1,4,4,3,5,2,4,2,4,4,3,2,1,5,5,3,5,5,1,3,2,4,4,1,4,1,5,1,1,4,3,4,2,5,1,4,5,4,1,2,1,1,2,5,2,3,2,1,1,2,4,4,3,2,5,2,2,3,5,5,1,3,2,5,3,5,1,1,1,2,5,3,1,4,5,5,3,2,1,4,3,3,4,1,5,3,2,3,4,5,5,2,4,1,3,1,1,4,2,4,2,4,2,4,2,3,3,4,3,1,5,5,4,1,3,2,4,3,4,4,1,5,1,1,2,3,3,3,3,5,3,4,5,2,4,4,1,3,5,1,4,3,4,2,1,1,1,3,1,1,2,2,3,1,4,5,5,5,3,3,3,1,2,2,2,4,4,4,1,5,2,2,1,5,1,2,3,2,5,3,4,2,5,3,4,4,5,4,2,2,2,3,3,2,4,3,4,1,3,1,5,3,5,1,5,3,1,4,5,1,1,2,1,3,3,4,5,1,5,4,1,3,4,2,4,2,1,5,2,3,1,2,2,3,5,2,3,5,5,1,3,2,1,5,2,5,5,5,1,4,5,2,5,4,1,1,4,4,5,4,4,3,1,4,2,2,3,1,3,2,4,2,1,3,2,1,3,1,2,1,4,1,1,3,4,4,5,2,5,2,4,2,4,5,2,5,2,4,2,4,3,2,4,3,4,5,5,2,5,5,4,5,1,1,5,2,4,3,5,5,1,3,3,5,5,4,2,2,4,5,2,1,5,5,3,2,1,4,3,2,5,3,5,5,4,4,1,1,2,4,5,2,4,3,4,4,1,4,5,3,4,1,3,4,4,3,3,2,4,5,2,5,5,2,2,1,5,3,5,1,5,4,5,2,5,5,5,2,3,4,3,1,2,2,1,2,5,4,1,2,3,2,2,1,5,3,5,3,2,5,2,5,3,1,1,5,1,4,2,3,4,3,1,3,4,3,3,4,5,1,5,1,4,3,5,3,4,5,2,3,4,5,3,1,3,3,5,3,4,2,5,2,4,1,3,4,5,2,4,1,3,1,1,1,2,2,5,1,2,1,2,1,5,1,1,1,2,3,3,1,4,2,3,2,1,4,2,3,5,1,4,4,5,4,1,2,3,1,2,2,4,4,5,3,3,1,2,2,3,4,4,3,1,4,5,2,3,4,1,3,1,1,4,2,4,3,5,2,3,3,4,2,4,5,5,5,1,2,1,5,2,2,5,4,1,4,1,1,4,1,1,5,2,5,2,1,2,3,5,4,1,4,1,4,2,2,4,4,1,2,5,4,3,5,1,4,2,3,3,4,1,1,3,3,5,1,1,3,1,2,4,5,2,4,4,1,4,2,3,4,3,1,4,4,2,3,5,5,1,2,2,3,1,4,5,2,3,4,4,4,2,4,4,5,1,1,1,5,4,1,1,1,4,5,2,4,1,3,4,5,3,3,4,2,4,4,4,4,1,4,1,4,2,2,5,5,1,2,1,1,1,5,4,4,3,4,3,3,1,1,1,1,5,4,5,1,4,3,1,3,5,3,4,3,5,4,5,5,5,2,4,1,1,4,3,3,2,3,2,2,4,1,1,4,3,2,1,3,4,5,5,5,3,1,4,3,5,4,5,1,1,5,2,2,5,3,2,4,2,1,5,2,1,2,3,4,3,5,3,2,1,2,4,3,4,2,4,2,1,5,1,4,4,2,3,4,1,2,5,3,1,4,4,5,4,5,5,3,5,1,4,4,2,2,4,5,5,1,2,1,1,1,1,2,4,4,3,1,4,1,1,2,1,2,1,2,4,2,2,5,2,2,3,2,2,1,3,3,1,4,4,2,2,5,1,1,3,1,2,2,1,2,4,4,3,2,5,2,5,1,3,3,3,5,4,3,1,3,4,4,5,3,5,1,4,5,2,2,1,2,4,3,3,2,5,1,1,4,1,1,3,1,4,5,5,3,1,1,3,2,2,5,2,2,5,1,2,3,4,1,5,2,1,2,4,2,5,2,5,4,5,2,4,4,4,1,2,2,1,5,1,4,4,1,5,5,2,1,1,1,5,3,1,3,4,2,1,4,4,2,5,3,5,3,5,3,4,2,5,5,5,1,3,1,4,4,3,1,4,1,2,5,5,3,2,4,3,2,4,2,3,5,4,3,3,2,2,1,1,5,5,2,5,1,2,2,3,2,4,2,2,3,2,3,5,4,4,4,4,5,2,1,3,2,3,1,3,4,3,5,1,3,2,5,4,5,3,2,4,3,1,5,1,1,1,5,2,3,1,1,3,2,2,4,4,1,2,4,5,3,5,4,4,1,1,5,2,1,4,1,5,2,3,2,2,4,4,5,5,3,1,1,3,5,2,5,5,5,5,3,5,3,2,2,2,1,1,2,3,3,2,2,3,3,5,1,1,3,1,4,5,1,5,5,2,5,3,1,5,5,1,5,2,5,5,4,4,2,5,1,2,1,3,5,5,4,3,5,1,5,2,2,5,4,1,4,4,5,1,2,5,1,3,4,2,4,3,4,3,2,3,2,2,5,1,3,2,2,3,5,1,2,1,4,1,4,5,5,5,3,3,3,5,4,5,4,5,3,2,5,5,4,2,5,4,2,2,1,4,4,3,2,2,5,4,5,5,1,1,1,2,2,2,5,3,1,5,1,2,3,2,5,4,5,1,2,5,2,4,5,2,1,3,3,3,3,1,5,3,3,4,3,2,3,2,5,3,5,3,3,1,1,1,5,3,5,4,5,5,5,5,3,4,3,5,1,4,4,1,2,4,4,2,2,3,4,2,3,4,1,5,1,2,3,4,1,1,5,3,2,1,2,3,5,4,1,3,3,4,3,3,2,3,3,5,4,5,1,3,5,3,2,4,3,1,5,2,1,3,1,1,5,4,4,1,1,1,1,4,5,5,3,4,5,5,3,3,2,5,1,3,2,1,1,1,3,4,5,1,5,3,1,5,1,4,2,3,3,4,1,4,4,1,2,4,5,1,4,5,3,5,5,3,5,5,3,5,5,5,5,3,5,3,1,5,4,5,5,2,4,1,5,2,4,2,3,4,3,4,3,5,2,1,3,5,5,4,1,2,4,4,2,2,5,2,1,3,4,1,1,2,3,2,3,3,4,3,4,3,2,4,1,1,4,1,1,3,5,5,2,5,4,4,2,4,1,2,5,5,3,5,2,4,4,2,2,2,4,2,3,1,2,5,5,3,3,3,5,1,1,3,2,3,2,4,3,3,1,1,2,4,4,5,3,1,3,5,3,3,2,3,3,4,1,1,3,3,5,4,4,3,1,1,4,4,1,5,1,1,2,2,3,4,2,3,5,5,3,2,5,2,3,5,1,5,5,3,2,2,5,1,3,2,2,3,1,5,2,1,3,1,4,2,2,1,4,2,3,4,1,2,3,5,5,3,1,5,3,2,4,3,2,3,2,3,2,1,5,1,4,4,5,2,5,3,1,4,3,1,1,5,1,2,5,4,5,4,2,2,1,5,5,3,2,2,5,5,2,2,2,4,5,5,2,5,3,2,1,1,4,4,1,1,3,2,4,4,5,3,2,3,2,2,2,2,2,3,2,4,3,2,3,4,5,1,5,5,2,5,4,3,3,1,4,2,2,1,2,2,1,2,1,5,1,1,2,2,5,1,2,2,3,5,1,5,3,5,1,2,5,1,1,2,2,3,2,3,2,3,2,5,1,3,4,1,3,5,5,2,3,5,1,3,3,2,5,5,4,1,4,1,4,1,1,1,2,3,3,4,4,2,2,2,3,5,5,5,2,4,5,5,3,2,2,2,4,5,5,1,4,1,4,5,2,1,2,5,1,4,1,3,2,4,3,4,4,4,4,2,2,5,3,3,1,3,2,2,4,3,1,1,1,3,5,5,1,4,3,1,5,1,2,4,4,4,5,1,1,2,1,2,2,5,2,1,1,5,1,3,1,1,2,5,5,1,1,2,2,5,5,5,5,2,3,5,2,3,3,4,5,5,1,1,5,1,5,4,4,1,5,3,4,3,3,2,3,4,5,3,3,5,3,4,4,2,2,5,3,1,3,4,2,2,2,5,2,1,5,4,4,5,3,1,5,3,2,1,2,5,1,4,4,2,3,3,3,1,5,5,3,5,5,4,5,2,3,5,1,5,2,3,2,3,1,5,2,2,1,5,1,1,2,3,3,5,1,4,2,4,3,3,2,3,3,5,2,2,1,4,1,3,3,4,5,2,1,3,4,4,1,2,5,2,4,4,4,3,1,5,5,2,1,2,2,4,2,2,5,3,5,2,3,1,5,4,4,4,2,4,4,5,1,5,2,4,1,4,4,5,4,1,1,2,4,4,2,1,1,5,3,2,3,3,4,2,5,1,3,4,4,4,4,2,1,5,2,5,1,3,2,4,4,1,4,2,4,4,5,5,1,3,1,5,4,1,5,4,1,1,5,5,3,5,3,1,1,2,1,2,5,5,3,2,2,1,2,1,5,1,1,2,5,2,5,4,5,2,4,4,1,5,3,1,2,3,1,2,2,4,5,1,3,5,3,1,3,5,5,1,4,2,1,3,5,1,3,5,2,5,2,1,3,2,4,2,3,3,3,2,4,3,3,5,3,1,1,1,1,5,5,2,3,4,3,1,1,2,1,2,1,5,3,3,2,5,5,3,1,2,4,1,2,5,4,2,5,2,5,2,3,5,3,4,5,2,4,3,1,3,1,1,3,5,1,2,3,1,3,5,3,2,3,1,1,5,5,5,5,3,4,4,1,3,3,5,2,4,3,2,2,3,2,5,4,3,3,4,4,2,1,3,1,3,4,3,4,2,2,3,1,4,4,1,5,4,4,4,4,4,1,5,1,5,4,3,4,5,2,3,2,1,2,3,2,1,2,3,1,1,5,5,3,4,5,4,3,4,4,2,1,2,5,1,1,2,1,3,3,5,3,3,2,2,2,3,5,1,4,5,2,3,3,1,3,4,5,3,1,1,2,3,4,5,3,3,4,5,2,4,2,5,3,4,5,5,1,5,5,1,4,1,4,2,4,4,4,5,3,1,3,2,3,4,1,4,5,1,1,4,1,5,3,4,2,1,3,4,2,1,5,5,3,2,3,4,1,2,1,3,5,3,4,4,1,2,5,3,2,4,1,3,3,2,5,5,5,1,4,2,3,2,3,2,5,5,3,3,3,2,3,3,4,2,5,1,5,1,4,3,4,2,2,1,5,2,5,4,1,5,1,2,2,5,5,5,4,5,5,4,2,3,5,2,3,1,2,1,5,2,2,1,1,3,4,3,5,5,2,4,2,4,4,2,1,5,3,1,4,4,1,1,5,1,5,3,5,2,5,5,4,1,5,2,5,5,3,4,1,2,1,5,3,5,2,1,2,1,5,3,1,3,1,2,2,1,3,4,3,2,4,5,1,3,4,4,5,2,2,1,2,2,3,3,5,4,4,3,1,2,5,1,2,1,5,4,2,2,4,5,5,5,3,2,3,1,4,5,3,4,4,2,4,4,3,2,1,1,1,4,2,1,5,2,4,1,5,4,4,5,5,1,4,2,4,5,5,2,1,5,4,2,2,2,1,3,4,3,3,4,4,5,2,2,1,4,1,2,5,3,5,2,4,4,5,1,3,5,2,4,3,2,4,5,4,2,4,5,4,5,3,2,1,5,3,2,2,3,2,1,5,4,4,4,2,2,4,4,5,2,5,2,2,4,1,2,5,1,4,5,1,1,4,2,2,1,2,3,1,4,2,2,5,4,4,1,1,4,3,5,5,2,4,1,4,4,4,4,3,1,5,2,4,3,5,3,4,2,3,4,4,4,1,4,1,1,4,4,2,4,4,3,4,5,2,2,5,2,5,4,3,4,2,2,3,3,1,3,3,4,3,3,5,3,2,4,3,1,4,2,1,2,2,3,1,3,5,1,1,2,1,3,5,5,2,5,2,1,4,3,2,5,3,1,4,1,3,2,1,3,1,5,5,3,1,1,1,2,1,2,5,1,3,5,2,5,3,3,2,1,2,3,1,4,5,2,3,2,4,4,2,1,3,3,1,3,2,4,2,5,5,3,5,2,4,4,3,4,3,5,1,2,3,3,4,4,2,4,2,4,5,4,5,4,5,1,1,4,5,4,3,3,2,2,5,2,4,4,1,4,5,3,4,4,2,2,3,5,1,1,1,3,4,2,5,2,2,3,3,4,2,4,3,1,5,1,1,1,5,2,3,1,1,3,1,1,1,4,5,5,3,2,4,3,3,4,3,1,1,1,4,1,2,5,3,1,1,4,3,5,3,3,1,5,1,3,5,4,2,3,4,2,1,2,2,4,5,1,1,5,4,2,3,1,1,3,5,5,4,1,1,1,5,3,4,5,4,3,2,2,5,1,5,2,3,5,1,4,3,5,5,1,1,4,4,1,1,3,5,2,5,3,3,1,2,2,5,4,5,3,3,5,3,3,2,4,5,1,4,1,5,1,2,3,4,1,4,5,4,2,1,1,3,5,2,5,2,4,4,4,3,5,3,4,4,5,4,2,4,1,1,4,4,1,5,3,3,1,3,4,4,3,2,5,4,4,3,3,2,2,4,5,2,4,3,4,5,1,1,2,5,4,2,2,5,3,3,5,5,5,3,4,1,2,1,1,1,4,4,4,4,1,1,1,4,4,4,4,2,5,2,3,1,3,1,5,1,5,4,2,3,2,3,5,3,3,2,5,2,2,5,1,3,4,3,3,3,5,2,3,4,1,1,2,3,1,3,5,2,2,1,5,4,4,2,5,3,4,1,3,2,2,1,1,3,5,5,1,1,5,1,4,5,2,4,2,1,2,4,3,5,2,2,1,5,4,3,3,5,2,3,1,2,2,4,5,2,5,2,3,1,5,4,5,3,4,3,5,4,1,4,5,4,1,3,1,2,3,4,2,2,4,5,4,4,3,5,3,2,1,5,5,3,5,2,4,1,3,1,4,4,4,4,2,1,4,3,5,2,1,3,3,4,2,4,2,3,1,3,1,4,1,4,1,3,1,4,2,3,2,4,3,5,2,5,1,3,3,3,2,3,1,3,1,1,5,4,4,1,1,3,3,4,5,2,4,5,5,5,1,2,1,5,1,3,4,3,3,5,3,3,3,1,2,4,3,5,1,5,2,2,5,5,2,4,5,3,4,3,4,1,4,5,4,5,2,2,3,1,2,4,3,2,2,1,1,2,5,3,1,5,1,2,5,4,1,1,4,1,1,5,3,5,3,4,3,2,2,4,2,4,5,1,3,4,3,1,2,1,3,3,3,4,2,3,4,3,5,1,5,4,1,5,5,3,3,2,5,5,4,4,3,2,2,1,3,5,1,5,3,5,1,2,2,3,2,5,4,1,5,1,1,5,5,1,1,4,5,1,2,3,4,1,5,1,4,3,4,3,4,1,3,3,1,1,1,4,1,5,4,5,1,4,1,3,3,1,4,4,5,5,4,5,5,5,5,3,4,5,5,1,4,2,2,2,3,5,5,3,1,3,1,1,5,2,3,3,4,3,1,3,5,4,4,2,1,2,4,2,1,2,1,4,1,5,3,2,5,1,2,3,1,1,4,5,2,3,2,2,5,5,1,3,2,3,5,3,2,4,2,5,2,4,1,4,2,5,2,4,5,3,3,2,1,3,3,3,1,4,5,4,1,5,5,3,4,2,1,1,1,1,4,3,4,2,1,5,4,5,5,4,3,1,5,1,4,3,4,1,1,5,4,3,5,2,4,4,3,3,3,2,3,3,5,5,3,3,5,4,5,2,5,4,2,1,4,3,5,2,5,3,1,1,2,4,3,4,3,2,4,3,3,3,5,4,4,4,3,4,4,5,4,3,1,3,5,3,1,4,5,2,3,2,1,2,2,3,2,2,5,2,3,2,5,5,5,5,1,2,5,3,3,5,4,5,3,2,5,5,5,3,3,2,4,1,4,1,4,1,5,4,1,2,5,4,1,2,3,1,4,4,5,3,3,1,5,3,3,1,5,4,2,4,4,1,5,5,1,2,3,4,2,5,3,3,3,2,3,1,5,5,3,1,2,4,4,5,4,3,3,3,1,4,1,4,5,1,3,4,4,1,5,5,5,4,5,3,3,5,4,1,3,1,5,4,2,1,2,3,4,4,4,1,1,3,5,3,3,2,5,3,2,3,4,4,2,4,1,4,1,3,4,4,5,3,2,2,3,2,2,1,1,4,5,1,5,4,4,1,2,1,2,3,4,1,2,4,4,4,1,1,2,2,1,1,4,1,2,5,5,2,1,4,2,3,1,2,2,4,2,1,5,5,4,3,4,5,4,2,2,3,4,1,2,3,3,5,1,1,2,5,5,2,3,3,4,4,3,1,1,1,5,1,2,2,4,1,5,1,1,3,4,4,4,2,3,3,2,3,5,1,3,5,3,2,2,1,1,1,5,2,3,3,3,2,4,4,2,2,4,5,4,3,4,2,3,2,3,3,3,5,1,3,1,4,1,4,2,3,5,3,4,2,1,2,4,4,4,3,4,2,5,5,5,1,5,2,1,5,1,4,1,4,4,3,3,4,3,5,2,5,2,3,2,2,2,2,4,5,1,1,3,2,2,2,4,4,4,4,2,4,2,3,2,4,3,1,5,1,2,3,4,2,5,5,5,4,3,1,4,4,2,4,4,3,4,5,5,1,2,5,1,1,1,2,1,5,4,4,1,2,4,3,2,2,4,5,5,4,1,2,3,5,3,1,1,3,1,4,4,1,2,1,4,5,3,1,5,5,2,4,1,1,3,1,1,3,2,3,5,4,1,4,1,5,4,3,2,2,2,1,1,5,5,4,3,5,1,3,1,5,2,4,5,1,1,2,4,1,4,2,5,3,5,1,4,5,5,4,4,4,1,1,2,3,2,4,2,5,5,5,2,4,2,2,3,1,1,5,5,2,4,1,2,2,2,3,1,4,3,3,3,4,4,5,2,2,3,2,1,5,4,4,1,5,2,2,3,3,1,1,1,4,4,1,5,3,2,2,5,5,1,3,4,4,2,4,3,4,1,4,1,2,5,2,1,4,5,5,5,3,4,3,5,1,5,5,4,4,2,5,3,4,1,5,3,2,1,5,2,1,2,3,5,2,5,1,4,2,1,4,5,2,1,3,1,2,5,1,2,5,5,1,3,3,4,1,5,3,2,3,4,1,1,2,3,4,5,1,3,4,4,4,1,1,3,2,2,4,5,2,3,5,2,5,1,5,1,1,3,5,1,5,3,3,1,5,3,1,1,2,1,5,2,1,4,2,5,4,1,1,5,5,4,1,2,1,1,1,3,5,1,5,2,5,5,3,2,4,4,1,2,4,1,2,4,5,5,1,3,3,5,3,2,2,5,5,5,1,5,4,3,5,1,3,5,5,2,1,2,3,2,4,5,1,5,4,4,1,4,5,5,3,1,4,5,4,3,5,4,2,3,3,1,1,4,5,2,5,3,1,5,5,4,4,3,3,3,5,3,5,2,1,3,1,4,5,2,5,2,3,2,1,2,4,3,3,1,4,4,4,3,3,1,1,3,4,2,5,4,3,5,5,1,1,5,3,4,1,2,3,4,3,1,2,3,4,4,4,4,5,3,1,3,3,5,3,1,2,3,2,3,4,5,2,4,2,4,3,1,5,1,1,1,1,1,5,4,3,1,3,2,1,3,3,4,1,4,2,4,5,1,4,2,1,2,5,5,2,4,2,1,5,4,3,2,3,4,5,4,1,1,5,1,3,3,5,3,2,5,5,1,2,1,2,4,1,2,5,4,4,3,2,2,2,3,3,5,5,1,2,4,3,3,1,1,3,3,2,2,5,1,5,5,3,3,2,2,4,2,4,5,4,1,1,4,1,2,3,3,2,5,4,5,1,1,3,3,1,1,4,1,4,5,3,5,4,5,1,2,4,3,2,2,2,4,5,4,4,1,5,5,4,1,5,3,5,3,4,5,5,5,2,3,1,3,3,5,1,4,3,3,5,4,2,1,1,5,5,1,1,2,4,4,2,5,5,2,5,4,4,2,3,2,4,5,5,4,5,2,2,1,4,1,1,4,4,3,5,3,3,4,1,4,4,4,2,2,4,3,2,4,4,1,4,3,4,4,3,5,3,5,1,3,4,1,3,1,2,4,4,3,5,3,2,1,1,2,1,1,2,4,1,2,4,3,4,1,4,2,4,5,1,3,1,1,2,5,1,5,5,2,3,3,5,5,4,1,2,1,2,2,1,2,3,1,4,1,2,1,3,1,3,3,4,3,1,4,2,5,1,5,4,4,5,4,3,5,1,5,3,3,1,4,3,3,1,5,5,2,3,3,5,1,3,2,1,1,4,1,2,5,5,5,3,5,5,5,2,3,5,3,3,3,1,3,2,5,3,2,1,1,4,2,5,4,1,2,2,3,1,2,1,2,5,2,3,1,4,1,5,5,5,5,5,3,5,3,1,3,3,4,4,3,5,4,4,3,3,4,1,4,3,4,3,5,3,2,5,4,3,3,5,4,3,1,4,4,4,5,1,5,5,3,1,5,4,4,4,5,1,5,4,2,4,3,2,4,3,3,2,4,1,4,4,3,1,2,3,3,3,2,3,3,5,4,3,3,1,1,2,4,2,2,3,2,1,3,3,5,1,4,1,1,5,1,5,3,4,2,1,4,3,3,1,1,5,3,4,5,3,4,1,3,5,1,3,3,5,4,4,5,2,4,1,2,1,3,1,4,2,3,3,1,2,5,2,2,4,2,4,3,5,4,2,2,1,5,2,5,4,5,5,5,4,2,5,4,4,4,4,2,5,4,4,3,5,4,4,3,4,1,2,5,4,5,1,2,1,3,2,1,2,2,1,2,1,5,3,3,4,3,3,4,4,1,1,3,1,1,1,1,1,3,3,5,5,5,5,4,5,4,4,5,4,5,5,4,5,4,2,3,1,5,3,4,5,1,3,1,1,3,1,2,2,3,3,2,1,2,5,3,1,5,4,2,3,4,4,5,2,1,2,5,3,3,4,4,1,1,1,3,2,1,5,5,4,1,4,1,2,4,4,2,2,3,2,5,5,2,3,4,2,2,1,4,1,3,3,1,4,2,1,5,5,2,4,4,3,3,1,4,4,3,2,2,4,1,1,5,4,1,1,4,1,2,5,1,5,1,4,2,1,5,3,4,2,5,5,1,5,2,3,2,2,1,3,3,2,3,5,4,4,4,5,2,4,2,2,2,1,1,5,5,1,2,2,3,2,2,3,5,3,3,2,3,5,2,2,4,3,2,2,5,3,4,1,4,3,5,1,1,5,1,3,4,4,5,3,2,3,4,4,4,5,2,5,3,1,5,2,5,5,1,2,3,5,3,3,5,1,1,2,4,5,5,2,4,4,1,4,4,2,1,1,2,1,5,3,3,1,3,4,3,3,2,1,2,3,2,2,2,3,5,1,5,3,5,4,3,3,2,1,5,3,4,1,1,4,5,4,5,2,3,4,1,1,3,4,3,2,5,4,1,2,5,3,1,5,4,4,2,2,3,1,2,1,1,4,3,1,1,3,3,1,5,3,5,2,2,4,1,5,3,5,3,1,2,5,2,5,3,2,5,3,2,3,2,5,4,1,4,2,5,2,4,5,3,4,3,1,1,2,3,4,1,1,5,5,1,1,3,3,3,5,2,2,5,2,3,5,1,3,3,4,2,4,5,3,4,1,3,3,2,1,5,5,5,3,1,3,5,4,5,3,1,5,5,2,1,5,3,5,3,1,3,1,1,5,5,3,5,3,1,4,2,4,4,1,1,5,5,5,1,5,2,3,1,2,1,3,3,3,4,4,2,4,4,5,2,5,1,4,5,5,1,3,5,1,5,2,4,3,5,2,4,1,5,5,2,3,5,5,1,2,1,2,3,2,1,3,5,4,5,5,2,4,3,5,1,4,2,3,4,2,1,5,3,5,5,5,2,5,1,5,5,5,4,4,2,5,3,2,1,1,1,5,5,5,2,5,1,2,5,1,5,4,2,5,3,4,2,3,5,2,4,1,3,2,5,2,4,4,4,5,3,3,3,2,4,2,1,2,3,4,5,5,1,2,1,1,4,3,5,2,5,3,3,5,1,4,4,1,4,2,5,1,5,5,5,2,3,5,2,4,3,2,4,2,1,3,2,4,1,5,2,3,5,3,2,5,4,4,2,4,3,1,3,2,3,4,4,2,5,5,1,2,5,1,1,2,2,3,2,5,5,5,5,3,4,3,2,5,3,4,2,5,5,3,2,1,5,4,4,3,1,4,2,1,5,2,5,1,5,4,4,1,5,1,2,2,4,1,4,2,3,2,4,4,2,3,5,4,5,2,4,5,3,1,5,3,4,3,3,3,1,3,5,4,3,3,4,5,3,4,1,1,2,5,2,3,4,4,3,4,2,1,2,1,3,4,3,4,2,4,3,2,5,4,1,4,3,3,5,1,5,1,3,5,3,4,4,5,2,5,1,4,3,2,1,4,2,4,1,5,1,3,5,5,5,2,3,4,2,2,3,5,5,2,3,4,3,3,2,4,3,5,3,2,4,5,2,5,4,1,5,4,1,1,1,3,5,4,3,5,3,4,4,2,4,2,2,4,4,1,3,2,1,4,5,3,2,3,5,3,4,3,4,2,3,1,1,5,2,1,5,4,1,1,4,1,3,1,4,2,4,4,1,5,5,1,2,4,1,4,3,3,1,3,3,2,4,5,2,4,5,4,4,1,5,5,4,4,2,5,4,1,5,2,5,5,1,2,1,2,4,5,2,3,3,2,3,2,4,1,5,5,1,1,3,5,3,4,2,3,5,3,4,4,1,2,1,3,4,1,3,3,2,2,1,2,4,3,3,1,2,1,5,3,4,1,4,3,3,4,5,3,4,3,4,4,2,1,3,5,3,5,2,5,5,4,4,5,1,5,3,2,3,3,3,5,5,4,3,2,5,2,3,4,1,1,5,2,3,1,4,3,2,3,4,4,3,4,2,3,2,1,2,3,4,5,4,5,3,4,5,3,3,2,1,2,1,3,4,1,5,5,4,4,5,5,4,2,1,2,2,3,5,2,4,3,2,4,2,2,4,2,1,5,2,5,3,5,4,5,5,1,1,4,4,4,3,5,5,5,4,4,5,2,3,3,1,2,3,2,4,1,5,2,2,3,2,2,2,2,2,2,4,4,4,3,1,2,1,2,5,2,1,4,1,5,4,3,3,3,2,5,1,2,2,2,5,2,1,5,5,3,4,2,3,4,3,2,2,5,5,3,1,5,4,1,5,2,1,4,4,3,2,4,2,1,1,4,2,3,4,4,3,5,5,5,5,1,1,3,4,4,5,5,4,5,3,2,1,2,4,2,5,3,3,1,1,3,3,3,2,3,4,1,1,5,5,1,2,5,3,5,5,3,1,1,3,5,1,1,3,3,4,1,4,4,2,2,1,3,5,2,1,2,3,5,3,3,3,1,3,2,4,3,2,5,4,3,3,3,2,3,2,1,4,2,2,2,3,3,2,1,5,2,1,1,4,3,4,5,2,2,2,3,2,5,2,4,2,1,4,5,5,3,4,3,5,4,1,4,1,4,1,3,2,1,3,5,4,3,2,3,2,4,1,3,5,4,1,4,5,4,2,4,4,3,4,2,4,4,1,2,2,4,2,1,2,3,5,3,3,1,5,3,3,1,3,5,4,4,4,2,5,2,2,2,4,5,4,1,4,5,3,2,3,5,1,4,3,2,4,4,4,4,3,4,2,5,2,3,2,5,1,2,2,1,3,1,1,1,5,2,2,2,4,1,4,2,4,4,5,4,4,5,3,3,4,2,5,4,5,5,4,5,2,4,3,2,3,5,1,5,2,5,3,3,3,4,5,3,3,2,2,4,1,4,2,1,2,4,5,3,2,5,4,5,1,3,5,1,4,2,5,2,2,5,5,1,4,3,1,2,2,1,3,4,2,5,1,2,1,3,5,1,1,5,3,5,2,4,3,1,4,3,1,1,5,2,5,2,1,4,4,2,2,4,5,5,4,1,5,3,5,4,4,3,1,5,5,5,5,4,4,3,4,2,5,3,4,4,5,1,1,5,1,2,3,2,1,3,5,3,5,5,5,3,2,3,1,3,2,1,5,2,4,2,2,1,5,3,2,5,4,2,2,4,1,4,1,2,5,3,4,5,1,2,2,5,3,3,3,1,4,1,5,3,1,4,2,1,1,5,4,5,2,5,4,5,3,3,2,5,3,2,4,2,1,1,4,3,5,2,5,3,2,1,2,3,1,3,3,5,3,4,5,3,1,5,4,1,3,2,4,3,5,2,5,1,4,5,5,5,3,1,4,2,2,3,2,5,3,4,3,2,4,2,4,4,1,5,4,5,2,2,2,3,4,5,3,1,2,3,4,1,3,2,2,3,1,1,2,4,4,3,5,3,4,1,2,3,3,4,2,5,3,3,1,1,1,1,3,3,2,3,2,5,3,4,4,4,2,5,2,4,2,4,5,2,1,4,4,5,5,3,4,1,3,2,1,1,4,2,1,2,3,3,5,2,1,5,3,2,2,3,5,5,3,1,1,2,5,1,3,5,5,4,5,5,1,2,5,4,4,3,5,5,4,5,5,4,5,3,5,1,1,2,3,3,5,3,1,5,1,4,2,4,2,5,5,5,1,5,4,4,5,4,2,3,5,4,4,1,3,5,4,1,5,1,4,5,4,3,5,3,2,3,5,1,1,1,3,5,2,1,4,2,4,2,5,1,4,3,5,2,5,2,2,1,3,3,3,5,3,5,5,2,2,3,3,1,3,1,1,4,3,1,4,1,1,1,4,5,2,5,3,4,3,3,2,4,2,3,1,3,4,4,5,4,4,5,2,2,4,2,3,3,4,3,2,4,3,4,4,4,1,4,3,4,5,2,5,2,1,5,5,1,1,3,5,4,5,1,2,4,2,1,2,1,2,2,4,5,2,3,5,4,2,4,1,2,1,5,1,5,3,4,5,5,4,3,3,3,3,5,4,3,1,5,4,1,1,3,2,1,2,4,1,4,5,2,3,4,1,3,2,4,2,3,5,3,2,5,2,3,3,1,3,3,1,5,3,5,2,4,1,3,2,3,2,3,2,2,2,2,3,3,2,1,4,3,3,4,5,3,1,2,3,1,5,3,5,3,2,2,4,5,1,4,4,3,3,2,2,4,3,2,4,1,4,4,2,4,2,2,3,4,2,5,3,4,1,4,1,5,5,4,5,4,5,5,4,2,3,5,5,1,2,1,1,3,2,5,2,3,5,2,5,5,4,3,2,5,1,5,5,2,1,3,1,1,2,5,4,5,3,5,2,5,5,2,4,4,1,5,4,3,2,5,5,1,3,4,1,1,1,4,2,1,5,3,5,1,1,1,4,2,4,1,1,1,5,1,4,1,1,4,1,1,4,3,2,3,3,3,1,4,4,4,4,2,3,4,2,2,1,4,3,1,3,2,4,1,3,5,1,1,2,1,3,3,2,1,4,3,4,1,1,2,5,1,4,3,4,5,3,1,4,2,4,5,5,4,4,1,3,5,2,1,1,5,1,2,5,2,3,5,5,2,5,1,2,2,3,4,1,5,4,2,5,5,4,2,2,2,4,3,4,4,4,4,1,5,5,5,4,1,5,5,1,4,2,4,1,3,1,3,2,2,1,2,5,1,2,3,4,2,5,3,4,3,4,1,5,1,1,5,3,1,4,3,4,1,2,1,2,1,2,5,1,5,5,2,4,5,1,3,4,5,4,2,1,4,2,2,5,4,2,2,4,5,1,5,2,2,3,4,1,4,5,5,1,2,2,4,1,4,4,2,1,1,3,3,5,4,3,1,3,5,3,4,3,3,3,5,5,4,3,2,2,5,4,4,5,2,3,1,4,2,1,5,1,5,4,4,3,2,4,2,4,4,1,4,1,2,3,4,2,4,3,5,1,4,2,5,5,2,2,5,5,5,3,5,4,4,3,4,1,5,1,1,5,5,3,4,2,2,1,5,2,3,1,3,3,3,4,5,3,5,3,4,5,2,2,1,5,3,5,3,3,3,2,1,2,3,5,4,1,3,5,3,5,2,4,1,5,3,4,4,3,5,1,5,1,4,1,3,5,4,3,1,1,5,2,4,1,1,4,2,2,4,2,4,3,1,4,4,2,5,5,1,2,1,3,2,2,2,3,1,2,3,3,3,1,1,2,3,3,1,1,1,2,3,2,2,1,4,1,5,1,4,3,2,1,2,4,1,2,5,3,4,5,3,2,5,4,1,3,3,3,2,1,3,1,1,4,1,3,5,2,5,5,4,5,4,5,1,1,5,1,1,1,2,2,5,1,4,5,1,3,3,4,1,5,3,4,3,1,3,3,3,1,4,5,3,1,2,5,4,5,2,3,4,3,5,5,1,5,4,5,5,2,5,2,5,2,1,1,4,5,2,4,5,3,4,4,1,2,4,4,5,3,5,5,3,1,1,1,4,2,2,2,1,5,5,2,3,1,5,1,5,4,3,5,3,3,4,1,5,4,2,4,1,3,5,2,1,4,4,2,1,5,4,3,3,3,1,4,4,4,2,1,4,5,1,3,5,3,3,3,3,3,5,1,4,4,4,3,2,2,3,2,1,4,2,4,4,2,4,5,2,1,3,4,1,5,1,3,1,3,2,3,5,1,3,5,2,4,5,1,3,3,5,5,3,4,4,5,1,4,3,4,3,3,3,1,3,5,2,2,1,4,5,5,3,3,4,1,2,1,1,2,1,4,5,3,3,3,5,1,5,5,5,3,2,4,1,4,5,4,1,3,2,4,1,1,5,5,5,4,2,2,5,4,3,2,2,4,2,4,2,5,4,5,3,3,1,2,1,1,5,2,1,4,1,2,4,2,5,4,1,1,4,4,2,3,2,3,3,5,2,4,3,2,4,4,2,2,2,3,3,4,5,2,2,3,2,4,5,3,5,3,1,4,1,1,2,2,3,2,4,5,4,1,3,1,5,4,3,5,5,3,1,1,1,4,1,5,2,1,2,1,5,3,4,1,1,4,2,3,3,3,1,1,4,2,2,3,4,3,4,3,3,4,2,1,5,3,4,2,2,4,5,2,3,3,4,2,1,4,3,4,5,2,4,1,4,3,3,1,1,1,2,3,1,1,5,5,2,1,4,3,3,2,3,5,2,2,2,2,1,4,4,2,5,4,5,2,2,5,2,3,2,1,3,2,2,2,5,4,2,5,1,2,5,4,3,4,2,4,3,1,4,2,1,3,5,4,5,4,3,5,1,1,5,4,2,1,3,4,2,4,1,3,4,4,2,5,4,5,5,2,3,3,5,5,4,3,5,3,4,3,2,1,1,2,5,1,1,2,1,2,4,1,4,4,1,1,5,1,4,1,1,1,1,4,3,3,4,2,2,1,3,4,3,1,3,2,2,1,3,1,3,4,3,3,3,5,3,1,5,1,5,1,4,5,5,5,3,2,1,5,1,1,1,1,3,3,1,4,3,4,4,5,4,4,3,3,4,5,5,4,1,5,2,4,2,4,5,2,1,4,2,4,1,3,1,4,3,4,5,5,3,5,3,1,3,4,4,4,1,2,2,2,3,1,2,2,4,1,1,3,4,3,2,1,4,1,4,3,2,3,2,3,1,1,1,5,3,3,2,3,3,5,5,1,4,4,2,2,3,2,2,1,5,2,3,3,3,5,5,1,5,5,4,3,2,5,1,5,2,3,4,1,4,2,2,5,1,3,4,2,4,5,3,5,5,3,4,3,3,2,2,2,2,1,4,1,4,5,2,3,5,4,5,3,5,5,5,1,4,2,1,4,2,2,3,5,5,1,1,2,1,4,1,4,3,2,4,2,1,3,1,2,5,4,3,1,1,4,2,3,1,4,4,3,1,5,4,5,4,2,2,1,1,5,3,2,4,3,3,3,1,2,2,5,3,1,1,1,3,5,2,2,4,3,3,3,2,3,2,2,1,2,4,2,4,1,2,2,5,2,1,1,5,2,1,2,5,1,1,3,1,5,5,1,5,5,3,1,4,5,2,4,2,1,3,5,5,2,3,1,3,4,4,5,3,3,3,4,5,5,2,1,2,3,2,1,5,1,2,1,2,1,5,4,3,2,5,5,2,3,2,5,3,5,2,2,3,3,2,3,2,5,4,5,3,3,5,4,3,1,3,4,3,4,4,5,5,4,5,4,5,2,2,5,3,1,4,1,3,5,1,4,2,5,2,2,1,4,5,4,1,3,5,3,5,1,3,1,5,3,2,3,1,1,5,3,5,1,5,2,4,1,1,4,5,2,2,4,4,4,5,2,2,5,3,5,4,1,3,1,2,5,2,4,1,4,1,2,4,4,4,4,5,1,3,2,4,2,5,5,3,4,5,2,4,4,3,2,3,4,2,4,3,3,2,2,2,1,2,1,4,3,5,1,3,2,4,5,3,3,4,4,5,2,1,5,2,4,3,3,4,1,5,4,5,4,4,5,4,3,3,1,4,1,2,3,5,4,4,2,2,5,5,5,3,4,5,1,1,3,4,2,1,3,4,1,3,3,5,3,2,1,4,1,5,4,3,4,4,2,3,4,5,1,2,3,3,2,3,4,4,2,2,1,5,1,3,1,2,2,5,4,5,3,4,4,2,5,1,4,1,1,4,4,1,4,4,5,4,3,3,3,5,1,2,5,3,4,4,4,3,5,4,5,5,5,3,4,1,4,4,5,4,4,4,4,4,5,2,2,1,2,2,4,5,1,3,1,5,3,2,1,4,4,5,4,3,4,1,3,1,4,1,3,1,3,5,4,1,5,5,5,1,5,1,2,2,4,5,3,5,3,2,3,3,5,5,4,3,5,5,2,1,2,4,5,4,5,4,2,4,4,1,3,1,2,2,3,1,5,5,2,3,5,3,3,3,5,4,1,2,5,2,1,2,5,1,1,1,2,3,3,2,3,4,1,2,1,3,4,3,2,3,4,3,4,4,4,5,3,2,5,3,1,1,2,5,4,3,2,4,1,3,5,4,1,2,2,1,1,2,4,3,2,3,1,2,1,4,5,3,2,1,2,4,3,4,2,5,3,3,4,3,3,3,3,1,3,4,5,5,4,3,1,5,4,1,5,1,2,4,4,5,5,1,3,5,3,5,5,2,3,4,2,2,5,1,4,1,3,2,5,3,2,2,3,2,4,2,3,5,1,4,1,3,2,3,4,5,4,1,2,3,2,1,2,1,2,2,4,2,5,1,4,3,4,3,3,3,3,4,5,3,5,3,2,2,5,5,4,3,5,4,3,1,4,5,1,1,2,4,3,5,1,4,2,3,3,1,1,2,4,5,3,4,3,5,4,1,1,5,2,5,2,2,3,2,5,1,1,1,3,4,5,1,1,2,3,2,3,5,5,1,3,5,5,2,3,5,3,2,1,5,2,2,3,4,1,4,5,5,1,5,5,3,1,3,4,5,3,5,4,3,4,1,2,5,4,5,2,3,4,3,1,4,3,5,5,2,5,1,1,3,4,3,3,1,4,5,1,3,2,2,1,5,2,4,3,5,2,4,4,4,5,2,5,2,5,5,5,3,4,5,5,2,5,4,3,5,3,4,5,3,5,4,4,2,3,4,3,2,3,4,2,2,3,4,5,1,5,2,2,3,2,4,5,2,3,3,5,2,4,3,5,3,2,5,4,4,3,3,1,4,5,3,4,2,1,3,4,2,1,3,1,2,1,1,2,5,4,3,2,1,1,2,5,3,1,5,5,5,5,5,2,4,3,4,1,5,3,2,4,2,3,2,3,5,4,2,1,1,2,5,2,3,2,1,3,5,4,2,1,5,3,5,4,3,1,1,5,2,1,1,5,1,1,1,3,3,4,4,3,2,3,3,5,3,2,5,5,3,1,1,5,1,2,5,1,1,2,2,1,3,3,5,5,3,3,1,2,4,4,5,3,5,1,2,3,2,3,5,3,5,5,4,3,3,3,1,5,4,4,4,5,1,1,4,3,5,2,1,1,4,4,4,3,1,5,4,3,3,4,4,2,3,4,5,3,1,3,1,2,5,5,1,3,3,4,2,4,2,1,3,3,4,5,5,5,1,5,4,1,5,3,1,2,4,5,4,1,5,5,4,3,5,3,3,1,3,5,2,3,5,2,5,2,4,4,4,3,3,1,1,4,1,3,1,3,4,5,2,5,1,5,4,2,5,4,3,2,2,4,1,4,1,4,3,5,2,4,5,1,3,3,5,4,2,2,4,3,4,2,3,3,4,5,2,1,5,5,5,3,3,5,2,3,1,4,5,2,2,5,2,4,1,4,3,5,4,3,4,2,1,3,4,5,3,1,5,4,1,2,3,5,1,3,2,4,2,5,1,5,1,1,4,1,2,3,1,2,3,2,4,2,1,2,3,2,1,1,4,2,4,4,4,3,2,1,5,3,4,1,2,4,3,5,5,5,2,4,5,4,2,3,5,4,5,2,3,3,1,3,5,5,5,3,5,5,5,5,5,1,3,3,5,1,4,3,5,1,4,3,4,1,4,2,2,3,2,5,1,2,5,1,4,2,5,4,4,4,4,2,5,1,4,3,5,4,4,2,5,5,5,5,4,1,3,2,5,4,4,3,1,3,3,3,4,2,4,1,3,3,4,3,5,1,4,1,3,3,2,3,4,3,5,4,1,4,5,5,1,3,1,1,3,3,4,5,2,4,4,1,1,2,2,5,4,5,3,3,2,3,1,5,1,1,4,5,1,3,5,4,4,5,1,4,1,1,3,2,1,2,1,2,1,4,4,4,4,3,3,4,3,1,1,5,3,1,5,5,2,2,5,1,4,4,1,4,2,4,4,2,3,1,2,2,3,5,2,3,3,2,5,3,1,3,5,4,2,2,4,4,3,2,3,3,3,5,1,5,5,3,1,2,4,5,2,1,4,3,4,3,3,1,5,5,5,3,2,2,5,4,3,5,3,3,5,4,3,2,1,3,1,4,4,2,5,2,3,1,2,4,2,3,4,3,4,5,1,2,1,1,4,2,5,4,4,4,5,3,1,5,4,2,2,1,1,4,4,2,5,5,3,4,2,5,5,2,2,1,2,2,1,3,1,5,3,1,4,2,5,5,3,2,5,3,4,2,1,3,2,1,3,1,4,2,5,1,5,2,4,3,2,5,4,3,3,2,5,2,1,4,3,1,4,4,4,4,3,3,5,5,3,2,3,3,2,2,2,1,2,5,3,3,1,3,4,5,5,4,3,1,3,3,4,5,2,1,4,4,1,5,2,4,4,5,4,1,3,1,2,4,1,4,1,1,2,2,1,1,5,5,1,4,4,4,5,1,5,1,4,3,3,5,2,3,3,3,1,3,1,1,3,4,5,5,2,4,1,4,1,3,5,4,1,4,4,3,2,1,3,1,2,4,4,1,1,2,4,4,2,3,1,1,1,2,5,3,4,4,5,1,2,2,5,2,1,2,5,1,3,5,4,5,1,2,3,5,5,4,2,5,5,2,3,2,3,3,3,1,2,1,1,1,4,3,1,2,5,2,3,4,3,1,1,3,4,3,1,4,1,3,1,5,1,4,1,3,5,3,1,1,3,3,4,1,3,5,4,3,3,1,1,1,4,1,2,2,1,1,4,2,4,4,3,4,5,5,3,3,5,2,4,4,5,3,3,5,5,5,4,3,2,1,2,1,4,4,4,4,5,5,2,2,5,1,4,3,5,3,5,4,3,5,1,1,4,2,3,1,2,2,2,1,2,2,1,5,3,2,1,4,1,4,4,1,5,5,5,3,5,5,1,1,5,5,5,5,3,4,2,3,5,2,2,5,4,1,2,2,5,4,2,3,2,3,5,2,1,2,4,4,4,4,3,1,2,3,5,2,4,1,3,3,4,4,4,1,1,5,4,3,4,4,5,4,5,2,2,2,2,2,1,5,5,4,3,5,4,4,5,5,1,2,2,1,5,3,4,4,2,4,4,5,2,1,5,5,2,5,3,4,4,2,4,1,1,3,4,5,2,1,5,2,5,3,3,1,4,4,4,3,1,5,4,5,4,2,5,4,1,5,4,2,5,3,2,3,3,3,1,4,2,5,2,1,3,5,1,3,4,2,2,4,2,5,1,5,2,5,2,4,5,4,1,4,5,1,5,1,1,4,3,4,5,2,5,1,1,3,2,5,2,5,1,1,2,4,4,2,3,5,3,5,2,4,5,2,3,3,1,5,3,1,2,3,2,4,4,5,1,1,2,1,3,2,2,5,2,1,2,2,2,4,5,1,2,5,1,5,4,3,4,4,3,4,2,4,1,5,1,1,2,2,3,3,3,2,2,3,2,2,4,2,4,5,2,1,2,3,5,3,3,4,5,4,3,1,1,5,5,3,1,3,3,2,3,3,2,4,4,4,5,5,4,2,4,5,5,2,1,3,4,2,3,5,4,5,2,4,3,5,1,4,3,4,2,4,5,2,1,5,3,4,5,3,4,5,1,1,2,4,4,4,5,5,2,2,5,2,3,5,5,1,3,5,2,4,1,5,3,2,3,2,5,4,5,5,4,3,3,2,2,2,3,1,2,4,3,2,2,5,2,3,3,1,1,2,5,3,2,5,2,4,5,5,2,3,2,4,3,5,1,5,5,5,3,3,4,3,5,5,3,5,3,2,2,4,2,5,3,5,1,3,1,2,3,3,3,2,1,1,4,2,3,4,5,4,1,5,1,3,1,1,3,4,4,3,5,3,5,2,4,2,1,2,4,3,4,1,2,1,4,1,1,3,4,4,5,1,1,1,3,4,2,1,2,5,1,4,3,4,1,5,1,5,4,3,1,4,2,5,1,4,3,5,4,4,1,1,1,4,3,1,3,4,4,4,5,1,1,1,5,3,5,2,3,1,1,1,3,4,2,1,5,4,1,4,4,1,4,1,5,2,2,3,5,4,4,5,2,1,1,1,3,4,5,4,5,5,3,4,2,2,5,3,2,3,2,4,3,3,5,4,5,1,1,3,4,4,5,5,4,4,1,3,4,4,2,2,3,4,5,5,3,1,5,4,2,3,1,3,1,2,2,3,2,1,3,1,3,1,5,5,5,4,2,1,2,3,5,4,2,2,3,1,3,5,4,5,1,3,2,1,5,3,3,1,2,3,2,2,4,1,2,3,4,1,2,5,5,5,3,2,1,2,3,4,4,2,3,4,1,2,1,2,1,4,4,1,4,1,5,1,4,2,2,5,5,3,2,4,1,3,5,4,4,3,1,3,1,4,3,2,3,5,5,3,2,2,4,5,1,1,5,3,4,5,4,5,5,2,3,1,1,5,2,2,1,2,5,2,2,5,4,5,1,3,4,3,2,3,3,1,4,2,4,4,4,4,5,3,1,5,3,3,1,1,3,5,1,4,4,2,5,1,5,3,1,3,3,1,5,3,3,5,5,3,2,5,4,1,1,1,1,5,1,5,3,1,1,5,5,3,2,4,4,1,5,1,3,3,3,4,5,2,3,5,4,4,5,2,5,1,4,1,4,2,2,4,3,2,4,5,3,1,4,3,3,5,2,5,3,2,1,3,4,1,5,5,3,3,1,4,1,5,2,5,2,1,1,2,1,4,5,3,3,1,2,5,1,4,5,3,5,5,3,1,2,3,2,5,1,3,2,5,4,2,2,5,5,2,5,4,2,1,3,3,3,1,5,5,5,4,4,2,3,5,3,5,2,4,3,2,2,5,3,4,3,4,1,4,5,2,1,5,3,1,5,4,4,3,3,4,5,3,3,3,4,4,3,3,4,2,1,1,5,2,2,1,3,3,5,5,3,4,5,4,4,1,4,4,3,4,5,3,3,3,2,4,2,2,5,5,1,3,3,5,3,1,3,1,5,1,1,4,5,4,2,5,5,1,4,2,2,4,4,1,4,4,4,1,3,5,5,4,3,2,2,1,4,2,2,5,3,5,1,1,4,3,5,2,2,2,5,4,2,2,3,5,3,2,3,4,4,5,4,5,5,3,5,2,2,4,5,2,4,2,1,4,2,5,3,3,2,4,3,1,3,2,3,3,2,4,3,3,1,1,2,3,1,4,3,2,4,2,2,1,5,1,1,2,5,1,5,1,2,3,5,1,3,2,1,1,4,2,4,1,5,1,4,5,5,4,4,3,4,4,5,3,4,3,1,2,5,1,2,5,2,3,3,1,5,1,2,4,3,2,1,2,2,4,2,2,2,4,3,5,4,4,2,5,1,3,3,2,2,5,2,5,2,2,4,1,4,2,5,1,2,5,2,3,4,3,2,4,5,5,4,5,4,3,3,4,4,1,3,3,2,5,3,3,1,4,3,2,5,3,3,5,4,1,4,1,5,5,5,5,2,1,5,4,2,5,4,5,3,1,2,5,3,2,2,5,2,1,5,4,1,2,2,3,2,3,4,2,4,3,1,2,1,1,2,3,2,2,2,4,2,1,5,4,1,5,4,2,3,3,5,1,5,3,4,4,4,2,3,1,3,1,2,3,2,4,5,4,5,3,5,3,2,1,5,4,3,1,4,5,5,1,2,2,4,3,5,4,2,3,5,1,3,5,1,4,1,3,4,3,5,4,4,4,3,4,1,2,4,1,4,1,5,5,1,3,5,3,3,2,3,2,5,2,4,5,1,1,5,3,4,3,2,2,2,5,2,4,2,4,4,4,3,5,1,1,1,3,4,5,5,4,1,5,3,1,2,1,2,1,3,4,4,1,3,4,4,1,2,2,3,5,5,4,3,1,2,3,4,4,1,5,5,5,4,1,1,4,1,5,2,2,1,5,2,1,4,5,2,1,5,1,5,2,2,1,4,5,1,1,4,1,3,2,4,5,5,4,1,5,3,4,4,3,1,5,3,4,4,2,2,2,5,2,3,3,5,3,2,2,1,5,3,1,5,5,1,4,5,5,3,3,2,2,3,2,4,2,5,4,3,2,5,5,4,4,2,4,3,1,2,4,3,1,4,1,5,2,5,2,4,3,1,2,4,1,3,1,3,1,4,5,4,5,4,5,5,2,1,5,2,2,3,4,5,1,3,5,4,4,2,3,5,3,2,2,5,1,4,2,3,3,5,1,3,1,5,2,5,3,3,3,4,3,3,4,1,4,3,2,3,3,1,5,1,4,5,3,1,3,1,5,5,2,2,1,2,1,1,1,5,1,1,3,5,2,3,1,3,4,5,5,2,1,3,2,3,1,3,4,2,2,2,4,3,5,2,2,3,3,4,1,1,2,3,5,5,3,4,3,2,5,3,1,1,1,2,4,4,2,5,4,5,1,2,3,1,3,3,4,1,3,3,1,4,3,4,4,3,1,4,4,1,3,2,4,3,5,3,5,5,1,3,5,5,2,3,5,4,1,3,2,1,3,5,2,1,4,5,3,2,1,2,1,4,3,1,5,2,1,2,3,2,5,1,4,3,2,2,5,1,1,3,4,5,5,1,4,4,4,4,4,2,4,2,2,3,4,4,4,1,4,3,3,2,4,1,1,4,2,3,2,4,1,2,4,3,4,5,1,1,3,1,3,1,2,4,5,2,3,2,4,2,3,3,2,3,2,2,3,3,4,1,2,1,1,4,1,5,4,1,5,5,4,1,1,2,4,3,4,5,3,1,1,5,1,3,5,1,2,3,2,5,3,2,5,4,4,3,1,2,5,5,1,2,4,2,5,4,1,4,2,2,4,5,1,1,5,5,4,3,1,3,5,4,5,2,5,4,1,2,2,3,2,4,5,2,5,5,1,3,2,2,1,1,3,4,2,2,2,3,1,3,2,4,2,1,5,1,1,2,5,3,4,5,5,1,3,3,5,4,5,3,5,1,2,4,1,2,4,5,3,3,1,1,1,2,5,3,3,4,3,4,4,5,2,2,2,1,2,2,5,3,3,2,3,5,5,2,1,3,5,1,4,5,4,2,4,3,2,3,2,2,3,3,3,2,3,1,1,2,4,3,3,5,4,1,4,4,2,4,5,3,2,5,1,3,1,5,3,5,3,1,3,1,5,1,4,4,4,4,5,3,4,4,5,4,3,5,2,4,1,3,2,1,5,1,5,4,5,2,1,1,3,4,4,2,5,5,5,1,3,2,5,2,5,4,3,5,5,3,1,5,3,4,2,3,4,1,1,1,3,4,1,1,4,4,3,3,5,1,2,4,5,4,5,3,5,4,3,5,4,5,2,1,1,3,5,2,4,2,3,3,1,2,5,1,2,3,5,1,4,3,4,4,1,2,1,5,1,5,4,4,1,1,5,4,4,1,1,4,5,2,2,3,4,5,3,2,1,3,1,3,4,5,5,2,1,2,3,4,1,1,1,1,1,4,1,1,3,1,2,5,2,3,5,5,5,4,3,4,5,2,2,5,1,2,4,4,2,2,3,1,2,5,2,5,4,1,5,3,4,4,1,1,1,5,2,5,2,2,4,5,4,1,5,5,2,1,1,1,3,3,2,5,5,5,1,5,5,4,1,2,5,4,5,3,1,5,2,5,1,1,4,3,4,2,3,3,1,1,3,5,1,5,2,5,1,2,1,1,5,4,3,3,3,3,2,3,2,4,5,4,1,1,5,1,2,1,2,1,3,2,5,4,3,1,4,4,2,4,4,4,5,1,2,3,3,5,3,1,3,2,1,5,5,2,1,2,4,2,1,1,2,1,5,3,2,3,2,5,2,1,5,3,2,1,2,2,2,5,2,2,4,3,2,3,4,5,4,1,2,3,4,5,2,5,2,5,3,3,1,1,2,3,1,2,5,3,4,2,3,2,5,3,2,5,2,4,2,3,3,5,1,1,1,1,2,2,2,4,2,4,4,2,5,3,2,5,2,4,1,1,4,2,5,3,3,2,2,4,3,4,3,2,3,3,2,3,4,3,1,5,1,1,4,4,1,3,5,2,5,3,4,2,4,4,1,2,3,2,4,2,5,5,1,3,5,1,4,1,1,4,3,2,2,2,1,4,1,4,2,2,5,1,1,2,1,5,2,1,4,2,3,3,5,2,5,1,2,1,3,5,4,1,1,1,1,1,1,2,3,3,5,2,4,3,5,1,1,3,3,3,4,4,1,3,4,4,5,4,1,2,5,2,4,2,5,5,2,3,5,2,3,3,5,5,1,3,2,2,3,3,2,5,5,3,4,3,3,4,4,2,2,1,4,5,4,1,2,1,4,2,2,1,2,1,5,1,1,1,1,5,4,2,5,2,2,5,5,5,4,4,1,3,3,4,4,4,4,2,1,1,3,3,5,2,3,2,2,4,1,4,3,4,1,2,5,5,4,3,4,1,3,2,5,5,5,5,1,1,3,2,2,3,3,4,5,4,2,2,3,1,5,1,4,4,4,4,1,3,1,2,4,5,2,3,1,1,2,4,5,1,4,1,4,3,2,4,2,4,2,4,2,4,4,1,4,1,2,1,1,5,2,3,5,3,5,4,2,3,1,4,5,1,3,4,5,5,3,5,4,3,3,1,4,3,3,1,5,1,5,4,5,5,2,3,4,1,1,3,5,3,3,5,3,1,1,1,4,1,4,3,4,3,2,1,1,5,5,5,2,3,2,4,5,5,4,5,3,5,1,5,1,1,2,3,3,5,4,1,1,2,1,2,3,3,5,4,2,5,3,5,5,4,5,5,5,2,5,4,1,3,5,1,3,4,1,3,2,3,3,5,5,4,4,3,2,3,2,5,3,1,3,1,4,2,5,4,2,2,4,2,5,3,5,2,1,3,3,5,5,1,5,4,5,2,2,4,2,1,3,4,2,5,5,3,3,4,4,2,2,3,5,4,2,3,4,1,1,3,5,2,2,4,4,1,3,1,1,3,2,3,4,5,3,1,5,2,2,4,2,2,3,2,3,2,3,3,5,5,3,1,1,4,1,2,5,5,5,3,3,1,3,1,4,5,5,5,2,2,2,5,1,1,4,3,2,4,3,3,4,5,5,5,2,1,2,1,3,3,1,5,4,5,4,5,5,2,3,5,5,3,3,5,3,2,2,4,3,2,1,1,1,5,3,3,5,3,4,5,3,2,1,5,4,5,2,1,1,5,1,2,2,4,5,4,1,4,3,2,3,5,5,5,1,1,4,5,2,4,1,2,5,1,3,2,3,3,5,1,3,1,3,5,5,1,5,2,2,5,5,5,1,1,5,4,3,5,3,5,4,4,3,4,5,1,5,4,5,1,4,5,5,4,4,5,3,1,5,2,3,1,1,5,5,1,1,3,1,1,5,2,3,2,3,1,4,1,2,2,5,1,4,4,5,2,1,4,5,2,1,2,5,2,4,3,4,2,1,1,1,3,3,5,5,4,1,3,2,2,4,4,2,1,1,3,2,2,4,5,5,4,3,5,1,2,3,1,4,3,2,5,5,3,4,2,3,3,1,1,1,4,3,3,5,1,4,2,5,5,4,4,4,3,2,5,1,5,5,2,4,5,5,2,4,4,5,2,1,3,5,4,1,4,3,2,1,5,3,2,1,5,1,4,1,4,2,2,1,4,2,1,4,3,2,3,3,5,3,3,4,5,4,1,2,4,1,5,3,5,2,2,3,2,4,2,2,2,1,5,2,5,5,1,5,2,4,2,5,2,4,5,1,3,1,5,2,4,4,2,5,1,1,1,1,1,3,4,5,4,1,3,2,2,1,5,2,4,3,1,5,1,2,1,3,1,3,1,4,5,5,3,2,2,3,4,1,5,1,4,5,3,1,5,5,2,5,5,4,1,2,1,1,3,2,5,5,3,2,4,1,1,1,3,5,3,1,2,5,1,4,3,5,2,4,2,4,4,1,3,2,5,4,1,2,2,4,5,1,1,2,4,5,5,1,4,4,4,2,5,5,4,3,3,5,3,3,3,1,2,2,4,5,2,5,2,3,2,4,2,2,5,2,4,3,1,1,5,3,1,5,4,3,4,5,1,3,1,1,5,4,1,2,4,5,1,1,4,2,5,5,4,3,1,5,4,3,4,4,1,3,1,4,1,4,4,5,2,5,5,5,1,4,3,1,3,3,4,5,3,1,2,3,1,5,1,2,1,5,1,1,5,2,5,1,4,5,5,2,3,1,1,2,5,2,5,4,4,1,1,3,1,1,1,4,1,4,4,2,3,3,5,1,4,4,2,4,5,2,2,2,4,2,5,5,4,5,4,5,4,4,2,1,5,3,4,4,3,4,5,2,2,2,4,4,5,4,2,1,2,3,3,2,4,2,5,2,4,1,3,1,1,4,2,4,4,3,3,1,1,3,2,1,1,3,3,1,3,1,4,2,1,5,3,5,1,5,5,1,3,1,3,4,5,2,1,3,5,3,5,4,5,4,4,1,1,1,1,3,3,1,3,2,4,3,2,4,4,1,2,5,3,1,5,2,1,5,4,1,3,4,4,4,5,3,2,5,1,2,1,5,2,1,4,4,4,5,5,3,3,1,1,3,3,3,2,1,2,3,2,3,5,4,3,4,1,4,3,2,1,2,4,1,2,5,5,4,2,3,2,5,5,4,4,2,1,5,3,3,5,5,3,1,2,3,5,5,1,5,1,5,4,5,5,5,1,5,4,3,2,4,4,4,1,4,4,1,1,2,3,4,5,1,5,4,3,1,4,2,3,5,2,4,4,2,1,5,3,5,1,1,3,2,4,3,4,2,2,5,2,1,4,1,1,4,2,2,4,5,2,1,5,3,3,5,1,5,5,2,4,4,2,2,5,2,3,2,1,2,2,2,1,5,2,3,1,4,3,1,3,3,1,3,3,1,3,1,5,5,3,2,5,5,5,4,4,1,3,3,5,1,5,4,2,1,3,1,1,4,5,4,4,2,5,1,5,3,4,1,3,2,3,2,5,5,5,4,2,5,5,2,5,3,3,4,3,4,4,3,3,2,3,1,1,3,1,3,1,4,1,5,3,5,1,2,4,1,5,4,3,3,1,4,4,3,3,1,4,4,5,5,2,3,2,2,2,5,5,1,4,3,5,3,3,2,5,5,1,2,4,5,4,2,1,3,4,1,5,1,1,4,1,4,2,4,2,5,2,1,2,4,3,3,1,2,2,1,5,5,2,4,3,3,3,2,3,5,2,2,4,2,1,2,2,3,4,4,1,4,1,2,4,3,4,1,1,3,2,2,3,2,4,5,1,1,4,4,1,4,1,3,2,1,4,3,4,4,1,1,1,2,2,4,3,1,4,2,1,5,4,1,3,5,3,5,4,5,4,4,3,4,4,5,2,2,4,1,3,5,5,2,1,2,1,5,3,5,4,3,1,2,3,2,1,4,3,5,5,2,5,2,2,2,2,3,4,1,5,3,2,5,3,3,3,4,2,5,5,5,4,4,5,3,1,1,4,3,3,3,5,2,1,4,2,1,1,1,3,3,1,1,5,4,4,1,3,4,1,5,3,4,4,2,4,5,5,4,2,1,4,3,3,1,2,1,3,1,3,3,2,5,5,5,4,2,3,2,5,2,4,5,1,3,2,5,5,5,3,5,3,1,5,1,5,5,4,4,2,4,2,4,3,5,4,2,1,2,4,1,1,2,3,1,3,4,4,5,3,4,1,4,1,5,5,4,1,4,4,4,5,4,2,1,2,5,1,4,1,1,4,4,4,1,5,3,5,3,4,2,3,1,3,1,3,2,2,4,1,4,5,2,1,4,5,4,5,4,3,1,2,4,4,1,1,2,5,3,5,3,3,4,4,3,5,2,1,5,5,5,2,1,1,1,3,2,4,3,5,4,3,4,5,5,2,2,4,4,4,3,5,4,1,4,1,3,1,4,1,3,1,4,1,5,2,2,3,1,2,1,1,2,2,5,4,2,4,3,5,3,3,3,2,2,2,2,2,3,5,5,3,5,2,1,5,2,4,2,3,4,2,5,1,4,1,1,5,3,4,3,3,1,3,3,4,1,1,2,5,1,5,1,3,2,1,1,1,2,3,4,5,5,3,2,2,2,5,3,4,2,3,3,1,3,2,5,3,1,3,2,3,4,2,4,2,5,3,5,1,3,1,4,1,1,3,5,1,5,2,3,2,3,1,2,4,3,3,3,2,1,5,3,4,1,4,4,3,5,5,5,4,2,4,4,5,5,4,1,1,4,2,4,3,4,4,5,5,3,1,1,3,2,4,1,2,3,5,4,4,4,1,3,5,4,1,2,5,2,2,3,3,3,1,1,2,1,3,4,5,2,4,1,5,1,2,2,4,2,4,3,5,3,3,1,4,1,5,3,1,2,4,3,5,2,2,1,3,1,2,4,1,4,1,5,4,4,4,5,1,3,4,5,4,3,5,5,2,2,5,4,4,2,5,5,5,4,4,1,2,4,4,2,4,4,4,5,4,2,1,1,2,5,3,5,3,1,4,4,1,3,4,1,4,3,2,4,2,4,5,1,4,1,3,3,5,1,5,2,4,2,1,2,3,3,3,3,5,2,3,5,3,1,3,3,2,4,2,3,5,1,5,5,3,4,1,4,4,1,4,4,4,5,4,1,4,1,5,3,2,2,1,2,1,3,4,2,1,4,2,4,4,5,1,4,2,5,1,1,2,2,3,4,3,5,2,5,5,3,5,1,5,5,4,2,4,4,1,5,3,2,2,1,5,5,4,4,5,4,3,1,2,4,4,1,1,3,5,1,5,1,5,4,4,5,1,2,3,3,4,3,1,3,5,3,3,2,2,3,5,2,2,3,2,1,1,4,4,2,3,2,2,3,5,1,4,4,1,1,2,3,4,5,3,2,4,3,3,4,2,5,4,1,5,2,5,3,4,4,5,2,4,5,4,4,4,5,2,3,5,3,3,3,5,2,1,3,5,5,1,4,5,2,3,4,5,5,1,2,3,5,1,4,1,2,2,3,3,1,5,5,4,3,3,3,4,4,2,5,5,2,2,2,1,2,3,3,2,3,3,4,5,2,4,5,5,2,5,1,4,4,1,4,1,3,1,5,4,4,3,1,5,3,2,1,4,5,4,1,1,2,5,1,5,4,2,1,2,4,2,2,4,4,4,3,3,3,2,3,2,4,1,4,3,3,1,2,2,3,4,3,2,5,2,2,4,2,1,2,4,2,2,5,3,1,3,2,5,5,2,2,5,3,2,2,2,4,4,4,3,3,2,1,5,4,4,3,4,4,3,5,2,1,2,2,1,3,3,3,3,5,5,4,5,4,2,2,4,4,5,1,4,3,5,3,4,2,4,5,5,1,1,5,5,3,4,4,2,5,4,1,2,1,2,4,1,4,4,3,1,2,4,3,1,4,1,5,1,3,3,2,4,4,5,2,5,2,2,4,5,4,3,4,1,2,4,1,1,2,5,1,4,1,3,1,3,4,2,1,1,5,2,5,2,3,5,4,5,5,3,5,4,4,1,1,1,4,5,5,3,4,2,5,4,5,2,1,1,5,4,4,4,1,3,3,4,5,1,3,3,1,4,1,2,3,3,5,2,2,3,5,3,3,1,1,1,2,1,2,1,5,2,3,3,3,3,4,2,3,4,2,2,4,4,3,3,4,4,4,2,2,3,3,3,2,3,2,3,3,3,5,1,1,1,1,5,4,1,2,4,1,5,5,3,1,3,2,3,1,3,2,2,3,5,1,5,1,5,2,3,5,5,3,1,3,2,1,2,5,5,2,2,3,3,2,5,3,4,2,1,3,5,4,3,1,4,4,3,3,2,2,2,5,2,2,4,3,4,2,1,4,5,5,5,3,4,2,2,3,1,2,5,3,2,4,3,3,5,2,1,3,5,2,5,3,4,2,5,5,2,2,1,2,5,4,4,3,2,5,5,1,3,3,3,5,3,4,5,5,4,3,3,4,4,5,4,5,2,4,5,2,2,4,3,4,4,3,4,2,3,3,2,1,1,5,4,1,2,2,3,5,3,5,4,1,1,2,1,2,1,1,2,3,3,5,5,1,4,3,5,1,1,5,5,5,1,2,2,4,2,3,5,4,1,4,4,1,4,4,5,3,2,2,4,4,3,4,1,3,4,5,2,3,4,4,4,5,4,3,4,1,5,5,5,4,4,2,4,3,2,5,4,4,5,5,1,1,5,4,4,4,3,4,5,3,1,2,1,2,4,4,2,5,1,2,3,3,3,5,4,1,5,2,3,2,1,5,2,5,3,1,3,2,4,2,3,1,3,2,1,4,3,3,1,2,2,3,2,2,5,5,3,1,4,1,3,4,4,1,3,1,3,3,4,1,1,5,1,2,5,2,5,2,3,3,4,5,2,3,1,1,2,5,3,2,2,1,1,1,1,4,4,2,4,2,5,4,3,3,2,1,3,4,1,5,5,5,4,5,5,3,2,2,1,5,1,4,3,1,1,3,3,2,2,3,1,3,4,3,2,5,4,4,2,3,4,3,4,2,3,1,4,3,3,5,1,3,3,5,5,5,2,2,1,1,4,4,5,1,1,3,5,2,2,1,4,3,4,4,5,2,2,5,4,4,4,1,1,3,4,4,3,2,4,3,4,3,5,5,5,3,4,2,4,4,5,3,5,3,5,5,2,4,1,3,1,2,3,5,1,4,1,2,1,1,4,5,1,5,4,2,1,3,2,5,3,1,3,1,3,3,5,3,5,4,4,1,2,4,5,4,5,5,3,3,4,3,1,1,3,4,3,2,5,2,1,3,4,1,3,1,5,1,1,5,3,5,4,3,5,4,1,3,3,5,1,4,1,2,4,5,3,3,2,4,5,2,4,1,2,4,5,1,2,5,2,4,3,2,5,4,4,1,2,2,2,2,1,4,2,4,5,1,1,4,5,3,1,2,3,3,4,3,5,3,2,1,1,4,2,5,4,4,4,4,5,4,2,3,1,2,5,3,2,3,3,3,2,5,3,2,5,3,3,4,5,2,5,4,4,4,1,3,2,4,3,3,5,3,4,3,4,4,3,4,1,4,1,3,5,4,1,5,2,2,5,2,2,3,1,5,4,1,4,4,2,5,1,2,5,4,5,2,3,1,4,1,2,4,1,1,4,5,2,3,2,5,1,5,1,5,5,1,3,1,4,5,2,3,5,5,4,1,3,2,5,1,1,4,1,2,4,2,4,2,5,3,1,3,2,3,1,3,5,4,1,2,5,4,5,5,5,5,4,1,2,4,2,3,3,3,2,5,1,4,3,4,3,4,2,3,1,2,2,5,2,5,1,3,3,4,4,2,1,3,3,2,5,3,2,3,5,3,4,4,3,2,3,4,5,1,4,3,2,2,4,4,2,2,5,1,5,5,1,4,3,5,4,2,4,4,1,5,4,4,1,4,5,1,2,1,1,1,3,2,2,2,4,5,1,4,1,2,5,3,2,5,4,2,4,5,4,3,2,2,5,1,3,5,2,5,2,3,4,3,1,5,5,2,5,2,2,1,4,1,3,4,4,2,3,5,1,4,1,3,4,5,3,5,2,2,4,1,2,1,3,4,3,3,4,4,1,5,4,3,2,2,2,3,4,4,4,1,1,1,4,5,3,2,3,5,2,3,3,3,2,3,4,3,4,2,2,3,5,4,1,3,5,3,3,3,1,4,2,3,2,2,1,3,2,4,2,5,5,3,2,3,4,2,1,2,1,4,3,2,2,4,5,1,5,1,3,4,2,2,5,1,4,2,1,5,3,1,1,1,1,1,2,3,3,1,2,3,4,1,3,4,1,3,2,2,1,5,1,5,2,3,4,4,1,4,5,3,3,4,5,4,4,4,2,3,1,5,4,5,2,2,5,5,4,3,5,5,1,4,4,1,1,5,1,3,1,5,2,2,1,4,5,1,2,2,5,5,4,5,3,3,3,5,4,5,2,5,1,1,2,5,5,4,5,3,3,2,3,1,5,2,1,2,4,3,2,3,5,5,1,5,4,4,4,4,4,4,5,1,5,1,4,2,5,3,2,3,1,2,4,2,3,4,2,2,5,5,3,2,2,3,4,3,2,4,2,3,4,1,4,4,5,4,4,5,4,3,1,5,5,2,4,5,3,3,4,1,3,4,3,4,2,5,5,5,2,1,4,2,3,5,3,5,5,1,3,2,5,4,4,4,3,5,3,3,4,4,3,1,4,5,3,3,5,4,5,3,1,2,2,4,5,1,2,4,4,5,4,1,3,2,3,5,2,1,5,2,5,3,1,1,3,3,4,4,5,3,2,2,1,4,5,2,2,4,2,4,4,4,4,5,2,2,3,4,4,3,5,1,1,3,1,3,1,2,3,2,2,5,3,4,2,2,2,1,1,3,4,5,5,5,1,4,5,5,1,5,3,5,3,2,1,2,1,1,3,4,4,4,1,5,3,5,5,5,1,3,1,4,5,5,2,5,2,1,4,2,4,1,2,4,5,1,1,1,1,3,1,2,3,5,3,5,1,4,4,3,4,2,3,1,1,2,3,4,5,1,2,2,5,5,2,1,3,4,1,5,5,3,1,3,1,3,4,5,2,2,4,2,3,3,4,2,4,3,5,4,2,3,1,5,4,1,3,3,4,4,2,3,3,2,1,4,1,2,5,3,1,3,2,1,4,3,5,3,1,4,2,2,4,2,1,5,4,4,2,5,5,2,3,2,1,4,1,2,2,1,5,2,1,2,2,4,2,5,4,1,3,1,3,1,5,1,1,5,1,3,1,5,4,1,5,5,5,3,5,2,2,4,3,3,1,5,5,1,2,5,4,5,2,1,1,5,4,3,5,1,4,1,1,3,5,1,3,1,1,3,1,1,5,5,5,3,4,5,4,5,3,5,5,3,5,4,1,3,2,3,4,3,2,4,1,1,4,3,2,5,2,4,5,2,3,3,4,3,4,4,4,3,5,1,4,3,4,1,1,5,2,2,1,3,3,3,5,3,2,2,5,5,2,5,4,2,4,3,4,1,2,1,5,4,4,5,1,5,1,4,1,1,5,3,3,5,2,3,3,2,1,5,3,2,3,4,2,1,4,1,3,2,3,1,4,2,2,2,2,4,5,1,4,4,2,2,3,2,2,5,2,4,2,5,4,4,3,3,3,2,3,5,3,2,2,3,5,4,4,4,3,2,3,2,2,4,3,1,1,3,3,3,3,1,5,2,5,1,1,4,1,5,1,1,2,3,1,3,2,1,1,5,2,5,1,2,4,5,4,1,3,3,4,4,4,4,3,5,2,4,3,3,2,4,5,3,5,1,3,1,4,2,1,2,2,3,4,4,3,4,3,1,2,4,2,3,5,3,3,2,4,2,1,1,2,1,5,1,5,4,1,5,1,4,1,4,1,2,2,3,3,2,5,2,2,4,1,5,4,4,3,3,5,5,3,4,3,2,1,3,4,3,5,5,2,3,2,5,4,5,3,4,5,1,2,1,5,4,1,4,2,3,5,3,1,3,5,4,5,3,3,2,1,3,3,2,4,2,2,2,1,2,1,4,1,5,1,5,1,2,4,3,4,4,5,3,2,3,4,5,3,3,5,3,1,2,2,3,1,5,2,1,4,5,1,4,2,4,3,1,4,1,3,4,2,4,4,3,4,2,5,2,5,4,4,2,4,4,4,4,3,3,2,4,5,2,4,5,3,5,1,3,5,4,5,3,1,4,4,1,4,5,1,5,4,4,1,3,2,4,5,4,2,5,4,4,5,3,4,4,1,1,3,5,4,5,5,3,1,3,5,3,1,2,1,1,5,1,3,5,3,5,2,3,2,5,1,5,5,4,3,4,3,4,1,3,1,5,5,4,2,4,3,4,3,3,3,2,3,3,2,3,2,2,1,3,4,5,1,3,2,1,4,1,3,1,5,3,4,1,5,1,2,2,2,1,2,1,1,4,4,5,2,2,3,1,1,4,2,4,2,5,5,3,4,2,3,4,1,3,4,4,5,1,3,3,3,4,2,5,3,5,5,3,5,4,2,5,4,1,1,1,5,1,1,2,2,2,4,1,1,5,2,2,4,4,4,2,5,5,2,2,2,2,3,3,4,3,2,3,1,5,5,4,1,4,3,4,1,3,4,5,2,5,5,5,4,3,4,2,4,2,1,4,3,1,4,5,3,2,2,2,1,3,2,2,5,1,4,5,3,5,5,1,2,2,4,4,2,2,1,1,2,4,4,3,4,2,4,1,2,1,4,2,1,3,3,5,1,2,1,5,3,2,4,2,1,1,4,1,3,5,5,5,3,5,4,1,5,1,2,1,3,3,3,2,5,2,5,3,2,5,5,4,1,4,3,1,5,3,3,3,1,1,3,1,3,5,3,5,2,2,1,5,3,1,3,1,3,4,4,1,4,1,3,1,4,1,4,1,3,4,5,5,1,3,5,3,5,1,3,5,5,3,2,4,2,4,1,5,4,3,4,3,3,4,1,5,5,5,2,2,5,1,5,3,1,4,2,1,3,1,4,4,2,1,1,4,4,1,4,5,2,4,5,4,2,3,4,4,4,3,2,1,3,2,3,5,1,3,5,5,4,5,2,3,3,1,5,4,1,5,4,1,5,5,2,4,4,3,1,1,3,3,5,1,2,3,2,4,5,4,4,2,2,2,3,4,1,4,2,3,4,5,2,1,1,4,2,4,2,5,2,1,4,4,4,3,1,3,3,1,3,4,2,2,4,2,3,5,2,1,3,4,2,4,1,1,1,1,5,3,3,4,3,5,2,3,2,5,2,3,2,1,3,2,3,3,5,3,5,3,1,5,3,5,1,1,2,1,1,2,2,5,5,1,4,5,4,5,4,3,5,2,1,5,2,2,1,1,1,3,5,3,4,5,4,2,3,4,1,4,1,5,2,3,1,5,5,1,1,3,4,1,2,4,1,3,5,4,5,4,3,1,4,5,1,1,1,1,3,2,5,1,1,4,4,1,3,4,5,5,3,3,4,1,5,4,5,5,5,3,4,5,4,2,3,1,3,1,1,5,2,1,4,1,3,4,1,3,4,4,2,1,1,2,1,1,4,2,1,3,1,1,1,1,5,4,2,3,4,1,4,1,2,2,4,5,1,4,4,5,3,3,3,1,2,4,1,3,5,2,1,4,4,4,4,1,3,2,1,4,4,4,3,1,1,4,5,2,3,4,3,1,3,5,1,1,4,1,5,1,3,5,5,5,4,5,2,5,5,5,2,2,5,5,1,1,5,2,3,1,4,3,1,5,5,2,5,4,4,5,1,5,3,3,3,2,2,4,4,4,4,2,3,2,5,2,3,2,4,1,3,2,5,3,3,2,2,3,3,4,5,5,2,2,3,1,5,4,1,3,4,3,4,2,3,5,5,3,3,1,5,2,3,4,2,4,1,3,1,2,2,3,4,4,3,3,3,3,5,4,3,1,3,2,3,4,4,4,2,3,5,1,1,3,2,5,1,1,3,2,3,3,5,4,1,5,1,1,5,5,4,4,2,1,5,4,3,5,5,3,5,5,3,5,1,4,1,2,1,4,1,5,4,5,3,4,5,3,1,4,4,2,5,5,4,1,3,2,3,4,3,5,2,2,3,1,1,5,3,5,1,4,5,5,1,4,5,5,5,2,4,3,3,2,2,1,4,3,1,4,4,3,1,4,5,5,1,1,4,5,2,5,2,3,2,1,4,5,2,2,5,3,2,4,2,1,4,3,4,5,1,5,1,5,2,5,1,3,3,1,2,5,5,3,4,4,3,5,2,3,1,3,5,5,3,3,1,3,1,2,1,2,2,5,3,1,2,4,4,1,2,1,5,5,1,4,5,4,5,2,2,3,4,4,2,2,3,3,2,5,4,3,4,4,2,5,3,2,5,1,5,1,2,2,3,5,2,4,1,3,2,2,4,5,2,5,4,5,2,5,4,4,4,1,4,3,4,4,2,2,2,4,2,2,5,5,2,5,5,2,1,2,4,5,3,5,4,3,2,4,1,2,5,2,2,2,2,2,4,3,3,5,2,4,2,3,1,5,5,3,1,1,2,5,1,1,3,5,4,3,5,1,5,5,4,4,5,5,4,4,3,3,4,5,2,3,3,2,2,1,2,3,4,3,5,2,3,4,2,2,5,5,1,3,4,1,1,4,4,1,3,4,1,4,5,5,5,4,2,5,5,2,4,5,1,5,1,3,4,2,5,3,2,4,1,1,3,4,5,3,1,5,4,5,4,1,5,3,3,1,5,1,3,5,3,4,4,4,3,1,1,5,1,4,2,2,5,3,1,3,3,1,2,3,1,3,3,1,2,3,5,5,1,5,2,5,2,4,2,4,3,3,5,2,5,5,3,5,5,4,1,5,4,5,4,4,2,5,4,3,1,5,4,5,5,1,4,2,3,3,2,2,2,1,4,1,2,2,5,4,1,2,4,2,5,2,3,2,3,4,1,1,4,5,1,3,3,1,3,2,2,1,3,5,3,2,2,5,1,4,1,3,4,3,5,1,2,3,2,2,3,3,1,2,3,3,2,4,4,5,4,2,2,2,1,5,2,5,5,4,5,5,3,3,1,4,4,5,2,5,3,2,2,3,3,5,5,1,1,2,4,5,4,3,3,3,4,2,2,1,3,3,1,4,3,2,4,4,5,4,2,2,5,5,3,5,2,2,2,4,5,2,1,2,4,5,2,5,1,2,5,4,1,4,4,2,1,1,4,3,5,5,4,2,5,5,1,1,1,1,2,3,3,4,1,3,3,5,4,1,2,2,1,4,4,3,4,5,5,4,1,1,4,4,5,4,4,3,1,5,3,3,2,4,3,3,4,2,4,4,3,4,2,1,4,1,1,1,5,4,5,4,1,1,1,4,1,2,5,5,2,3,3,2,5,5,5,5,5,4,4,4,4,4,5,2,1,4,5,1,3,3,4,1,3,2,5,3,4,2,3,3,5,5,4,3,2,5,1,1,4,1,2,2,2,4,5,5,5,4,5,5,2,3,3,3,4,5,1,4,4,2,5,4,4,3,2,4,2,2,4,4,2,2,2,2,5,3,4,1,1,5,4,1,3,2,2,3,4,1,3,4,2,5,2,3,1,3,3,4,5,4,2,2,3,5,4,4,4,2,1,1,2,3,3,5,5,2,1,2,5,1,5,3,5,1,1,2,4,1,4,4,3,1,5,2,2,2,4,1,1,2,4,3,1,2,3,4,3,3,4,5,1,4,2,3,5,4,2,4,1,4,2,1,5,4,1,5,2,2,3,4,2,3,3,2,4,2,4,3,4,2,2,4,5,2,2,5,1,1,4,4,1,3,3,5,1,2,3,4,1,4,5,1,4,4,2,1,5,2,3,5,5,1,4,1,5,4,3,3,4,4,4,4,3,5,2,2,5,1,2,1,1,3,3,5,4,1,5,4,3,4,5,1,1,2,2,3,5,3,5,4,1,3,4,4,2,1,1,1,2,5,1,3,5,1,4,4,3,4,1,5,4,4,1,2,3,1,4,2,4,4,3,3,5,4,3,5,4,3,4,3,1,5,3,2,5,1,5,3,2,2,4,3,1,1,5,3,4,2,2,1,4,1,2,2,4,2,4,2,1,2,5,3,5,1,5,5,5,2,1,2,5,2,4,1,3,5,5,2,1,1,1,3,2,1,3,3,5,5,5,1,5,1,4,5,3,1,5,3,1,3,2,2,5,1,5,1,5,4,2,1,5,2,4,3,2,2,4,2,5,2,3,4,2,3,5,4,4,5,4,1,4,3,5,5,1,3,4,5,3,3,4,3,3,4,4,4,3,2,3,3,5,5,2,2,3,1,4,5,4,1,2,4,5,1,4,1,1,1,4,1,4,4,4,3,2,5,5,3,2,2,5,1,3,5,3,4,2,3,1,4,4,4,4,1,5,2,4,5,2,4,3,5,2,1,3,2,3,3,2,3,4,2,3,1,2,3,3,4,2,3,3,2,3,4,3,4,2,3,2,3,2,4,5,1,4,1,2,1,2,5,4,1,4,3,4,5,1,2,3,4,3,2,1,2,3,4,5,1,5,1,1,4,3,4,2,4,3,5,5,3,4,2,3,2,1,3,5,4,2,3,1,3,3,3,4,5,1,1,2,2,1,3,3,3,4,2,3,5,4,5,2,4,5,3,3,2,1,5,5,3,1,2,3,1,3,1,1,5,4,4,2,2,2,1,2,2,1,2,3,4,1,3,1,2,2,3,5,5,1,5,1,4,1,4,4,2,2,3,3,3,1,5,5,2,1,3,4,1,2,2,3,2,1,2,5,5,5,3,1,5,2,2,3,3,2,4,4,2,3,1,5,3,5,2,4,1,3,2,5,2,4,3,3,1,5,5,3,2,2,1,2,2,3,4,5,3,3,3,1,5,5,4,1,3,2,2,2,3,4,2,1,4,3,5,3,4,1,2,4,5,1,5,5,1,5,4,1,3,2,4,1,2,4,3,5,1,4,3,4,5,2,5,3,4,2,4,1,5,1,5,3,4,2,2,2,4,5,3,1,2,3,1,2,5,1,3,4,2,5,3,2,2,5,4,5,4,3,1,2,5,4,1,2,1,5,4,3,1,1,2,1,2,5,2,3,3,3,5,1,3,4,1,5,3,5,5,1,3,1,4,1,1,2,5,4,2,3,5,3,1,4,5,5,3,3,1,1,3,3,3,2,2,2,2,2,1,1,4,1,5,1,1,3,5,5,3,2,2,3,3,5,3,5,5,1,5,5,3,1,4,3,3,4,4,1,3,5,1,1,4,3,3,3,3,3,4,4,3,3,1,1,4,5,2,1,2,5,5,5,1,3,5,4,3,5,4,3,4,4,4,1,2,5,5,1,5,1,3,5,5,3,2,4,5,4,1,1,4,5,5,2,3,1,5,5,4,1,5,1,4,4,5,5,2,2,5,2,1,1,4,4,3,2,3,4,3,5,3,1,5,4,5,2,4,1,4,1,1,3,2,2,2,3,4,1,3,2,3,5,2,2,2,4,2,3,3,5,5,2,3,3,2,4,4,5,5,3,3,3,2,4,4,3,1,4,4,4,4,4,2,4,1,4,4,2,4,4,4,4,5,1,5,4,3,4,2,5,3,1,2,1,3,2,5,4,3,3,3,5,3,3,2,4,2,2,4,5,2,1,3,4,5,5,2,2,1,1,1,1,2,1,4,1,1,2,5,3,3,4,1,4,5,4,1,2,5,3,5,3,4,4,2,1,5,3,4,3,3,1,5,3,3,2,2,4,4,4,4,2,5,1,5,5,1,4,2,4,4,4,5,4,1,4,1,4,5,1,2,4,5,1,5,2,5,3,5,1,5,4,4,2,4,2,1,3,1,3,4,1,4,3,4,5,2,2,2,5,1,1,5,5,4,3,1,2,2,2,1,2,1,4,5,4,1,1,3,3,2,3,1,5,2,1,3,5,4,3,4,3,3,2,1,1,4,5,2,1,2,4,3,2,4,4,4,4,4,3,2,1,5,5,4,1,4,2,5,1,1,3,4,5,4,4,3,5,5,2,3,5,1,4,3,1,3,3,5,5,3,4,1,1,5,3,5,1,3,5,3,4,4,3,3,3,2,2,3,1,3,1,2,4,2,4,3,5,3,4,1,1,4,5,4,1,3,2,4,4,2,1,2,2,2,5,2,4,5,2,1,2,1,5,5,2,3,1,2,3,3,2,4,1,1,2,3,2,4,5,2,3,3,5,5,3,5,1,1,4,1,2,5,5,5,2,1,4,3,1,5,2,3,5,4,2,4,2,5,3,5,1,4,4,2,4,3,2,4,4,3,1,1,4,4,4,1,2,2,3,2,1,1,4,2,3,5,5,2,5,2,4,5,4,4,2,1,1,2,1,4,5,2,2,5,2,5,1,5,5,5,4,1,2,5,4,4,2,2,2,2,3,3,4,4,4,4,2,1,2,5,5,3,1,5,5,1,3,5,4,4,3,1,4,1,1,5,2,2,5,5,1,3,5,2,3,5,4,4,3,1,5,2,5,2,1,1,1,1,4,4,4,3,2,5,2,4,1,1,4,1,5,1,3,3,3,3,2,4,5,3,4,2,2,5,4,1,4,2,3,3,2,4,3,5,5,3,4,4,2,3,3,3,5,5,3,1,3,1,1,1,4,1,1,2,5,5,3,1,1,1,4,3,1,2,1,5,2,5,1,5,1,3,1,5,4,5,4,4,5,5,5,2,2,3,3,5,3,3,5,5,4,3,5,2,2,5,3,2,3,2,5,3,2,1,1,1,4,3,2,3,5,1,2,1,5,2,3,2,4,5,1,4,4,4,3,4,3,1,2,2,2,1,5,3,5,1,1,3,4,4,2,1,3,3,1,2,1,2,5,4,4,5,3,5,4,1,3,4,3,5,1,3,4,1,4,3,2,3,2,5,1,2,2,1,3,2,1,4,3,4,2,4,2,1,2,5,1,3,3,4,2,5,3,5,2,5,3,5,5,5,4,5,1,3,1,1,2,4,2,5,3,3,1,4,3,4,4,1,4,4,5,2,3,2,2,4,1,1,5,1,5,3,5,3,5,3,1,1,1,2,3,3,3,5,3,2,2,1,3,1,5,3,1,2,1,1,1,4,5,1,2,1,5,1,5,1,1,5,1,3,2,4,3,4,5,4,5,2,5,2,5,2,2,4,2,1,1,4,5,4,2,3,1,3,4,1,5,3,5,4,2,2,1,3,1,3,1,3,1,3,5,1,5,3,5,4,5,1,4,1,4,4,5,5,5,5,5,4,1,4,2,5,1,5,4,1,3,5,5,5,1,3,1,5,4,1,4,4,4,4,3,4,1,1,2,1,3,1,2,3,4,2,5,2,1,1,4,5,2,2,1,2,4,3,5,1,4,1,2,3,4,3,1,2,1,2,2,4,5,2,3,4,3,3,2,4,5,5,1,2,5,4,5,2,2,3,1,2,2,3,2,5,1,3,2,4,4,1,4,2,5,2,4,1,4,1,4,2,2,4,4,5,5,3,5,5,3,3,4,1,4,5,4,4,4,2,1,1,2,2,4,4,2,2,1,1,3,2,5,5,5,1,5,3,3,4,5,4,1,1,5,2,2,1,2,5,4,2,3,3,3,4,3,4,4,2,1,3,5,2,5,4,2,4,2,5,4,4,1,4,2,5,2,2,1,1,2,1,5,5,4,4,1,3,5,1,3,2,4,4,4,5,1,3,4,1,3,5,3,4,1,3,3,2,5,5,4,5,5,2,1,1,5,2,2,3,3,3,3,2,1,4,5,2,2,5,5,4,3,3,4,1,2,5,1,2,5,4,5,1,4,3,3,2,2,3,5,5,5,4,3,3,4,5,5,3,3,4,4,4,3,5,5,4,1,1,3,3,2,1,3,4,2,5,3,5,5,5,1,3,3,2,2,1,1,1,4,4,1,1,5,1,2,2,1,3,4,1,3,4,5,4,4,5,3,1,2,5,4,4,2,3,5,5,1,3,4,4,2,1,5,1,4,4,2,1,5,4,2,2,3,5,1,4,4,2,4,1,5,2,3,3,2,1,3,5,2,1,1,1,1,4,4,1,5,4,4,3,3,5,1,3,1,5,3,4,1,1,4,5,3,3,3,5,3,5,3,3,2,1,2,2,3,5,2,2,2,2,5,2,5,2,5,2,5,1,1,4,2,2,5,4,2,4,5,4,2,1,2,3,4,5,2,5,1,2,4,2,1,1,4,5,3,1,2,5,1,2,1,1,1,4,2,1,1,4,4,3,5,2,1,4,3,4,2,1,1,3,3,3,5,4,3,3,2,4,3,1,4,4,1,4,3,2,3,5,5,5,2,4,2,3,5,5,3,5,5,2,1,5,3,3,4,5,2,2,2,4,3,1,3,4,1,4,1,3,5,2,1,5,5,4,4,4,1,5,2,1,2,1,4,5,5,2,1,5,2,1,4,5,3,5,5,4,3,2,5,1,2,3,3,2,2,4,1,3,1,2,4,5,5,1,5,2,2,2,4,5,3,3,5,2,3,4,1,3,1,1,3,1,5,5,4,5,2,1,2,1,4,2,1,3,2,2,2,2,2,2,2,5,1,2,1,1,3,2,5,5,2,5,3,5,3,5,1,2,4,2,2,1,3,2,5,2,3,5,5,4,2,5,5,3,4,1,1,2,3,3,5,3,3,4,1,2,2,5,2,1,4,3,1,2,5,2,1,3,4,2,3,3,1,1,5,4,3,1,2,5,4,5,1,1,4,2,3,3,5,5,1,3,3,4,1,5,5,4,1,5,5,2,3,5,5,5,4,4,2,5,5,2,2,4,5,1,1,3,1,2,3,1,5,4,2,2,3,1,4,1,4,5,4,3,5,5,3,5,3,3,2,2,1,2,3,3,5,3,3,5,4,5,4,1,4,4,1,5,5,1,2,4,5,2,4,1,2,2,2,5,1,5,1,2,5,4,1,3,4,2,4,1,4,3,1,3,4,4,4,4,3,2,2,1,3,5,5,3,3,1,3,4,4,3,2,1,3,2,5,2,2,2,1,1,5,3,1,5,4,1,2,3,1,3,4,1,5,2,1,5,2,2,4,4,1,4,2,5,4,4,4,1,3,4,1,3,4,1,5,3,2,2,3,3,5,5,3,5,5,2,1,1,1,4,3,5,5,1,3,3,3,5,5,2,5,1,3,3,1,4,2,2,1,5,4,5,2,1,3,4,4,2,3,5,5,3,1,1,2,3,5,2,2,1,2,4,5,2,2,1,4,2,4,3,5,4,1,3,1,1,5,5,3,2,5,2,4,1,1,1,3,1,5,3,3,4,4,1,3,1,2,4,3,1,3,3,5,2,3,5,2,5,3,1,4,4,3,4,5,2,5,4,3,2,1,5,1,4,4,4,1,2,5,1,1,2,5,5,1,4,5,4,5,1,4,1,2,3,1,2,1,3,1,3,4,5,1,2,1,2,2,3,4,1,5,1,3,4,4,3,2,4,3,5,3,4,5,3,4,4,1,3,2,1,3,2,4,1,3,5,2,2,4,1,5,4,4,4,2,2,1,5,2,5,3,1,2,2,2,2,3,2,5,3,4,3,1,4,1,2,5,2,3,4,5,1,5,4,4,3,2,2,4,4,3,5,5,3,3,3,2,1,3,2,3,4,1,1,4,3,4,3,5,4,2,2,3,5,4,1,5,5,4,5,4,1,1,5,2,5,1,2,2,4,4,4,2,5,5,2,2,4,3,5,4,3,3,5,2,4,3,1,2,4,4,5,4,5,3,3,2,1,2,3,2,4,1,4,1,1,1,2,3,5,3,1,2,3,2,1,2,3,1,1,3,2,4,5,5,2,1,5,5,2,3,1,3,4,5,5,5,3,1,5,4,5,5,3,3,1,3,5,2,1,4,1,3,1,5,5,2,5,2,4,1,1,1,2,1,5,3,5,4,1,2,2,4,4,4,3,2,3,2,5,5,2,5,2,1,3,1,3,1,4,2,1,2,4,4,4,1,2,2,2,4,4,5,5,4,2,5,5,1,1,5,4,3,4,5,4,5,3,2,3,5,5,2,3,2,2,2,1,5,3,4,1,2,2,2,1,1,2,3,1,3,2,4,4,2,5,3,4,5,2,5,2,1,1,4,3,3,4,2,1,5,3,2,2,2,5,1,1,1,1,2,5,2,2,4,1,1,5,5,3,3,5,3,3,5,2,5,1,4,3,2,1,3,5,1,2,5,3,5,3,2,4,3,3,5,1,2,2,1,5,4,3,3,1,5,1,5,3,1,1,1,1,4,2,4,2,1,4,1,5,2,4,4,3,2,5,4,3,1,5,1,5,2,5,2,1,3,4,3,5,2,2,4,4,5,4,3,5,2,3,1,1,5,5,5,4,3,5,4,2,2,3,5,5,1,3,2,3,1,2,4,2,3,5,4,4,5,1,3,1,2,5,4,3,3,3,2,3,3,5,4,3,4,2,5,5,3,5,1,4,5,1,5,3,5,1,2,2,5,5,4,2,5,4,3,5,5,3,1,3,4,4,4,3,4,3,1,2,1,3,3,4,3,3,2,4,3,4,2,1,3,3,4,5,5,5,2,2,5,3,1,4,4,5,2,1,2,1,4,4,1,2,2,3,1,3,1,3,1,4,3,5,1,2,1,3,1,2,3,1,5,4,2,5,5,4,1,2,3,2,2,4,5,3,5,5,1,1,3,2,3,4,5,5,1,2,5,4,1,5,5,2,1,3,4,4,1,2,5,3,5,2,3,5,4,4,1,3,2,2,4,1,4,1,3,1,5,3,2,1,2,4,5,4,1,4,3,5,2,3,5,4,5,2,3,3,2,1,3,3,1,1,3,5,5,5,2,2,5,5,3,2,1,2,1,2,4,5,1,5,4,5,5,3,5,4,4,3,4,5,4,4,5,5,1,2,3,2,4,5,4,2,5,3,3,2,3,4,3,5,2,4,5,1,1,3,3,2,3,5,3,2,2,4,3,2,1,2,4,3,1,4,2,4,4,1,4,4,5,2,5,2,1,2,3,3,1,3,4,3,4,3,2,3,5,2,1,4,1,5,1,1,5,2,3,5,3,2,4,3,2,2,2,4,4,4,3,2,2,2,2,2,5,2,2,1,4,1,2,1,2,3,1,2,4,3,5,2,2,2,2,3,2,2,5,5,4,2,2,5,1,4,2,3,5,4,4,3,3,1,2,1,5,4,2,3,2,3,5,3,2,2,1,5,4,1,3,1,1,5,5,3,1,2,5,2,5,3,3,1,4,4,2,5,2,1,2,2,5,3,5,4,5,4,5,1,3,3,2,1,1,3,5,4,4,5,2,2,5,2,1,1,1,2,3,1,4,5,3,4,4,5,5,2,3,4,3,3,5,4,2,1,4,5,3,5,3,1,2,1,1,3,2,1,1,3,2,4,5,1,4,3,1,4,5,1,3,1,1,1,1,4,5,5,3,4,2,5,4,5,2,1,3,3,2,2,3,5,1,5,5,5,5,3,4,2,3,3,4,2,4,3,1,4,2,3,5,2,1,3,3,3,4,3,2,5,3,5,2,2,3,3,1,5,2,5,3,2,4,3,1,2,1,2,5,2,2,3,5,5,3,2,4,1,1,1,1,5,2,3,1,5,5,3,4,5,3,3,4,1,4,3,2,4,1,3,4,1,5,2,1,3,3,3,5,4,3,3,4,3,2,5,3,4,4,4,5,3,1,1,5,3,1,3,3,3,1,4,2,3,5,1,2,2,2,3,2,1,1,5,1,3,4,5,5,3,3,4,3,3,1,3,5,5,1,2,2,4,5,3,1,3,5,5,2,4,3,2,2,1,4,4,3,1,2,2,4,1,1,2,4,3,5,1,3,1,1,3,2,2,2,2,3,5,5,2,1,2,1,4,4,4,5,2,5,2,5,1,3,4,1,3,1,3,2,3,5,3,3,2,5,3,3,4,1,1,2,5,3,5,3,5,5,3,3,4,2,4,3,2,2,4,2,3,3,3,2,3,2,3,2,3,5,2,4,1,5,3,5,5,1,2,1,1,4,2,1,4,4,1,2,3,1,5,1,2,5,4,4,3,4,1,3,3,3,4,3,2,1,5,2,5,4,1,2,5,5,1,4,2,4,4,1,3,3,3,1,1,2,5,2,1,3,4,3,5,3,5,4,1,1,1,4,2,2,5,1,2,2,4,2,2,5,3,4,4,2,5,1,2,2,5,2,1,3,3,3,4,1,1,4,2,1,5,5,1,2,5,5,3,4,3,5,4,5,1,2,2,2,5,2,2,2,3,3,4,1,5,4,4,4,4,2,4,4,2,3,4,4,3,5,3,2,5,1,4,3,5,2,2,3,2,5,4,4,1,3,4,4,1,2,5,4,5,4,4,1,3,1,1,2,5,4,3,5,4,4,5,3,3,5,3,4,1,1,4,3,4,1,5,4,4,5,4,5,4,5,5,1,3,2,3,1,2,2,5,1,1,5,2,3,2,1,3,4,5,4,5,2,3,2,5,3,5,2,3,4,1,5,4,2,5,3,1,2,5,3,2,2,4,3,2,2,5,5,1,2,3,4,4,5,2,1,4,3,1,4,3,3,1,4,5,3,3,4,3,5,3,4,5,4,3,3,1,3,1,2,2,5,3,4,2,5,4,5,5,4,1,3,3,2,2,3,1,4,5,3,5,4,5,1,4,1,2,1,1,3,4,4,3,4,3,2,2,1,2,5,4,2,2,4,3,4,4,5,2,5,2,4,5,5,1,3,3,2,1,5,1,5,2,3,2,3,2,3,1,4,4,5,5,1,3,3,1,5,5,4,5,3,4,2,5,3,4,2,3,1,5,2,3,5,2,4,5,1,4,2,3,5,4,1,2,4,2,5,5,1,3,5,4,5,1,2,1,1,5,1,4,4,3,5,2,3,5,3,1,5,3,3,1,3,2,5,2,1,1,2,1,1,2,3,4,2,2,5,3,2,2,4,4,4,1,5,1,1,3,3,2,5,2,1,3,5,2,4,4,4,4,4,5,3,5,1,4,1,3,3,5,1,4,1,2,3,5,2,1,5,1,5,3,2,3,4,4,3,2,1,1,2,3,2,2,1,5,5,2,3,2,4,2,3,1,4,3,4,5,2,1,5,3,1,3,1,3,3,2,4,4,5,4,4,3,5,3,4,4,2,1,4,5,5,1,4,2,5,2,2,3,3,4,4,4,1,2,5,2,3,5,1,5,3,4,2,2,2,1,2,2,5,4,1,3,3,2,1,5,4,4,5,5,3,3,4,3,5,1,4,2,2,1,3,2,3,5,2,4,3,3,4,3,2,4,1,2,3,4,2,3,2,5,4,1,3,3,4,1,4,2,2,3,1,4,4,5,1,3,3,2,2,5,3,5,1,4,2,1,5,3,4,1,2,1,3,1,1,5,5,2,2,5,4,3,2,1,3,1,3,4,2,3,2,3,4,3,4,1,3,3,5,1,3,5,1,3,5,1,2,4,1,1,3,1,4,2,5,2,3,4,5,1,5,2,4,2,5,1,4,1,4,3,5,1,3,5,3,2,3,1,5,5,4,5,1,1,2,4,5,4,4,4,4,1,5,5,2,4,1,2,2,5,1,1,3,1,1,1,2,2,2,2,2,5,2,2,4,3,2,4,5,5,1,4,5,3,3,4,4,5,3,5,5,3,1,5,1,3,3,1,4,5,3,2,3,5,2,1,3,5,2,5,4,5,5,3,1,2,5,5,4,1,5,5,4,1,4,3,3,5,2,4,5,1,2,2,5,4,5,3,2,3,1,4,4,4,1,5,5,4,4,3,1,4,4,1,2,1,2,5,5,3,5,5,2,1,2,3,1,3,3,4,5,2,2,3,4,2,3,3,3,1,4,4,4,5,2,1,1,2,5,5,3,4,4,3,2,5,3,1,3,4,5,4,5,2,4,2,5,1,3,4,1,4,1,5,1,3,2,3,3,1,1,1,4,1,3,3,5,4,2,4,1,3,1,3,4,4,1,1,2,5,3,2,1,1,5,1,1,1,3,5,2,1,4,3,3,2,2,4,3,3,1,3,1,2,2,1,2,1,5,1,2,1,3,1,3,5,2,2,4,2,5,4,3,4,4,2,3,2,4,1,4,4,4,5,5,5,5,1,5,2,3,5,1,3,4,3,3,1,2,4,1,2,3,2,1,3,3,2,1,4,1,5,5,4,2,1,3,3,5,5,2,1,1,3,2,3,4,2,5,2,3,2,2,1,3,2,4,5,3,4,5,1,5,3,1,2,2,2,3,3,1,2,5,2,5,5,2,2,3,3,4,1,1,1,2,1,2,4,2,1,2,4,2,2,3,5,5,2,5,1,5,3,5,1,2,4,4,1,1,5,1,5,4,4,3,1,5,5,3,4,5,2,4,3,1,5,1,3,5,5,1,4,4,2,3,2,4,2,2,3,4,4,3,2,2,2,5,4,5,4,2,2,2,5,5,3,4,4,4,4,2,2,3,4,5,4,2,1,4,3,3,3,1,2,4,2,3,2,2,3,5,4,5,1,2,3,1,4,3,2,1,4,1,4,3,2,1,1,1,2,2,4,5,3,2,5,4,1,3,3,5,3,5,5,5,2,5,2,4,3,3,4,1,4,4,4,5,3,1,5,3,3,3,1,4,4,5,1,5,3,2,4,4,4,1,3,1,1,4,1,5,2,1,1,1,4,2,2,1,2,2,5,3,3,3,4,2,1,4,1,1,4,1,5,1,5,2,4,1,4,4,2,2,3,1,2,4,3,5,5,1,1,3,3,3,4,5,3,2,1,4,3,5,5,1,5,4,2,1,5,4,2,3,5,4,5,3,2,1,1,2,5,2,1,2,2,3,2,5,3,4,4,1,2,3,3,3,3,3,3,5,5,4,2,2,2,1,1,4,5,2,3,4,1,4,4,3,5,1,4,3,2,1,4,4,4,4,2,2,1,1,1,3,4,1,2,5,2,4,5,1,4,1,1,4,3,3,3,1,3,1,3,5,3,1,2,1,5,4,3,3,3,2,2,4,5,5,3,1,2,3,1,4,5,1,3,2,4,2,4,5,3,3,5,5,4,2,3,1,2,2,5,4,3,2,4,2,3,4,1,5,3,3,2,2,3,5,1,1,2,4,1,3,5,3,4,1,4,4,5,4,1,5,3,5,5,4,5,4,4,2,1,1,2,5,1,5,3,3,4,2,4,5,4,4,1,4,4,2,3,4,4,1,1,3,1,5,2,3,4,1,2,3,1,3,5,5,3,3,3,1,5,2,1,1,1,5,2,3,5,4,2,3,1,1,2,1,2,2,4,1,4,5,5,5,2,5,4,4,3,5,1,5,4,4,4,2,1,2,3,4,2,1,5,1,5,5,4,1,3,4,1,4,2,5,1,3,1,1,1,3,2,4,1,4,2,4,2,2,1,5,2,1,5,5,4,1,2,5,2,2,5,1,1,1,4,5,4,1,1,3,4,2,4,4,1,1,3,2,4,5,3,1,1,3,3,4,2,1,1,5,5,5,1,1,3,1,3,4,5,2,2,5,3,1,4,3,1,1,1,4,2,1,4,3,4,5,5,3,2,3,2,5,2,1,2,5,3,2,2,2,5,1,4,5,4,3,1,4,4,1,3,3,1,3,4,3,4,2,4,4,5,3,3,4,5,1,4,1,3,3,4,2,1,4,3,2,1,5,1,4,5,4,3,2,1,2,1,4,5,5,1,2,5,3,4,2,4,5,4,3,2,2,2,2,2,3,4,1,5,3,5,1,1,5,1,1,4,4,2,3,3,2,1,1,3,5,5,1,5,4,1,5,1,1,3,2,1,3,3,3,5,5,1,1,1,1,3,5,4,4,3,1,1,4,4,2,5,2,1,1,2,3,5,1,4,5,1,4,3,1,3,2,3,3,2,1,2,3,5,2,2,3,2,2,2,1,3,3,5,4,2,3,3,5,3,2,2,1,4,3,5,2,3,2,1,2,5,4,2,5,4,3,4,5,1,1,4,5,1,4,3,1,1,5,1,5,4,5,3,2,4,2,4,1,4,5,5,1,5,2,1,5,5,5,4,1,3,3,5,3,1,2,4,3,2,1,5,3,5,2,1,4,5,2,2,3,3,3,3,3,4,5,3,3,4,4,4,5,2,1,1,4,3,4,2,4,2,1,1,4,2,3,1,1,1,1,2,4,2,1,3,3,3,2,2,3,3,5,3,1,3,2,1,2,2,5,4,5,1,3,3,4,5,4,5,1,3,5,3,1,4,4,2,3,4,1,2,3,2,2,2,5,4,2,5,5,2,3,1,4,5,5,4,3,3,2,3,5,2,2,5,5,3,2,4,2,1,4,3,5,5,4,1,3,2,4,2,4,3,1,5,5,4,4,5,5,5,5,5,2,5,1,4,4,3,2,5,5,1,2,3,2,2,2,2,3,5,3,1,2,2,1,3,3,4,1,5,2,5,2,5,4,4,5,4,5,4,5,5,3,1,5,4,2,5,2,5,4,1,5,3,3,1,5,1,4,2,1,2,1,1,1,5,5,5,1,3,4,5,2,4,3,4,3,5,3,4,2,2,4,4,5,5,2,5,5,4,5,2,1,3,2,1,1,4,2,3,4,3,1,1,1,3,2,3,3,5,4,3,5,4,1,4,4,1,4,2,1,5,3,2,4,3,4,4,5,4,5,1,5,4,4,5,1,1,5,1,4,1,4,2,4,3,5,1,1,3,5,2,2,5,4,4,5,5,2,1,1,3,4,4,4,4,4,1,2,5,1,5,1,1,4,1,3,5,5,4,5,4,1,3,3,3,5,3,1,2,3,1,5,2,2,2,1,3,3,3,3,4,1,4,4,2,1,4,4,1,3,4,3,1,2,5,5,2,5,1,2,2,4,4,4,1,3,2,5,3,4,4,3,1,3,5,2,2,3,5,4,3,4,1,2,3,1,1,3,2,3,1,1,3,4,2,1,4,4,5,4,2,2,5,3,5,5,1,3,3,1,3,3,1,3,1,1,5,3,4,5,2,1,1,5,4,5,2,4,1,5,3,2,5,4,4,3,3,4,1,3,5,3,1,2,5,5,2,4,2,1,2,3,2,4,3,3,5,5,2,4,4,1,5,1,2,5,5,2,4,5,4,5,3,2,3,5,4,5,5,1,4,2,2,2,3,1,2,4,5,5,2,5,2,4,2,5,4,1,3,2,5,3,4,4,5,2,4,5,4,3,5,5,1,4,2,4,2,1,5,1,4,1,2,4,2,5,2,2,5,1,1,3,1,1,4,5,2,3,1,5,5,5,2,2,4,2,5,3,2,1,1,4,3,1,2,4,3,1,2,2,3,2,4,5,5,5,2,2,4,1,3,5,5,5,3,3,2,1,2,4,5,3,2,3,1,4,1,1,1,3,4,2,4,3,5,4,5,2,3,1,2,1,2,3,2,3,4,3,5,5,2,3,5,5,4,3,2,4,5,5,2,5,4,2,2,2,2,3,5,5,2,4,1,5,3,4,1,2,5,2,5,5,1,4,3,1,1,2,2,1,1,2,3,3,1,2,4,2,1,3,2,3,3,1,5,3,4,4,5,1,4,3,5,2,3,2,5,5,2,1,3,2,2,2,5,1,4,4,4,5,3,3,5,5,3,2,3,3,2,2,5,1,4,3,1,5,4,2,1,5,3,1,3,1,4,4,3,1,2,2,5,3,2,1,5,2,4,1,4,3,5,4,2,3,2,1,4,5,4,2,1,3,3,5,5,1,2,1,1,1,3,3,1,3,3,1,5,1,3,1,5,2,5,1,3,3,5,4,1,5,5,4,5,1,4,5,2,4,1,3,3,2,2,3,1,3,5,4,4,2,2,3,2,2,1,1,1,4,5,4,2,5,4,1,5,3,1,2,1,2,1,3,2,5,3,2,1,1,5,4,4,1,3,3,3,3,4,3,3,3,4,2,2,3,1,3,1,2,1,1,2,5,3,3,4,4,3,4,1,4,2,3,4,4,1,2,4,2,3,5,2,2,3,3,5,5,2,1,1,1,2,4,2,5,3,1,5,2,2,4,1,5,1,4,1,3,1,4,1,5,1,1,4,3,5,2,2,2,4,3,2,4,5,5,5,2,2,4,1,5,2,3,5,2,5,2,2,3,2,3,4,1,3,2,4,3,1,3,3,3,3,4,2,5,3,3,1,3,5,5,2,2,5,4,3,1,5,5,3,2,1,4,4,5,3,5,5,1,3,1,3,2,5,2,4,2,5,2,1,3,5,3,3,2,2,2,2,1,3,2,2,1,4,3,1,5,5,3,1,3,2,5,4,1,4,5,4,1,1,5,3,3,5,4,5,4,3,2,5,4,1,3,2,1,2,2,4,3,4,1,2,2,5,5,2,5,5,3,2,2,3,4,1,1,4,3,2,2,1,1,5,2,4,5,3,2,2,2,5,1,1,2,5,3,5,5,4,2,1,4,1,4,1,2,1,4,5,2,5,1,5,4,2,5,2,1,4,1,1,2,5,5,2,2,5,1,1,3,3,4,2,1,1,5,4,1,5,3,5,1,1,4,3,1,3,2,5,5,1,3,5,4,1,1,1,2,2,2,2,2,5,2,5,2,1,3,5,4,2,3,3,5,2,5,1,2,2,2,2,4,3,5,4,3,5,1,3,2,2,5,4,5,5,5,2,5,5,3,4,4,4,1,1,2,3,2,1,1,2,5,1,4,2,4,4,4,4,4,1,3,3,4,2,2,3,4,4,2,1,1,4,5,3,4,5,3,5,5,3,5,1,1,2,2,5,1,4,2,4,5,1,2,2,5,3,4,3,5,4,4,1,1,5,4,5,3,2,2,1,5,4,2,3,3,1,4,1,2,1,4,2,3,1,1,1,2,1,4,4,3,3,5,4,4,1,3,2,4,2,3,4,1,1,5,1,3,4,2,3,4,5,1,5,5,5,4,1,3,3,1,1,4,1,3,3,2,4,3,3,3,2,4,1,2,1,1,4,2,5,2,4,3,5,2,2,2,4,1,2,2,2,5,1,2,2,2,1,3,3,1,2,2,5,2,3,2,5,1,5,4,2,2,5,2,2,5,1,2,1,2,5,3,1,3,2,1,2,3,3,1,4,4,5,2,5,3,5,1,4,1,1,4,5,1,5,1,2,3,3,2,4,1,4,1,2,2,5,5,5,5,5,3,4,2,4,5,1,3,2,1,4,3,1,5,1,5,1,3,4,3,4,5,2,5,3,4,5,4,4,1,4,4,4,4,4,5,2,4,1,2,1,5,4,1,1,3,3,2,5,4,5,1,2,5,1,4,2,2,2,5,4,4,3,1,5,1,4,2,1,1,1,1,1,1,1,5,5,4,1,3,1,1,4,5,3,5,1,2,3,2,4,5,1,5,2,5,5,1,2,2,5,5,2,5,1,3,2,4,3,1,3,5,3,5,4,3,2,2,1,2,4,1,4,4,3,5,1,3,3,5,1,4,2,3,4,5,2,3,2,4,1,5,2,1,4,1,3,5,5,1,1,1,2,5,5,5,1,1,1,5,5,3,2,5,5,1,3,5,5,5,5,5,2,5,4,4,4,4,1,4,2,2,2,3,5,1,1,2,3,2,3,2,1,2,4,1,3,2,1,3,4,1,4,3,4,3,1,1,4,2,2,2,2,3,1,5,4,5,3,3,2,3,5,2,5,3,5,4,2,1,3,2,4,4,3,4,5,1,1,4,5,4,2,3,1,3,4,2,4,2,1,5,3,2,3,3,4,3,1,1,1,5,5,3,2,5,1,3,2,3,1,5,1,3,2,5,4,3,2,5,5,3,3,1,2,1,2,5,1,5,1,5,5,2,4,4,4,2,5,3,4,1,5,5,4,3,3,2,1,3,5,2,1,5,3,2,1,1,5,2,3,5,2,1,4,3,1,1,2,3,4,1,3,5,1,4,5,3,3,1,1,5,1,5,2,4,1,1,5,2,1,3,1,3,4,2,1,3,2,4,3,1,5,4,4,2,3,4,5,4,1,4,1,4,4,1,3,5,2,3,2,3,3,2,3,1,4,4,4,3,5,5,4,1,2,2,2,1,5,1,2,2,5,2,2,4,1,5,3,3,5,4,3,1,5,2,3,3,3,3,1,5,3,5,2,3,3,3,4,3,2,4,1,5,1,1,4,1,5,4,5,3,2,5,1,3,2,3,1,3,5,5,5,1,1,1,5,4,3,5,1,4,3,3,5,3,5,1,3,4,4,3,4,5,3,4,2,4,4,3,5,3,3,3,3,5,4,2,4,4,1,3,5,1,4,4,3,1,1,1,3,4,1,4,1,4,4,2,4,4,3,5,3,5,1,4,5,1,5,3,4,5,3,2,5,5,5,1,2,4,4,2,3,3,4,4,3,2,4,3,2,2,1,3,1,1,3,4,3,1,1,3,5,4,5,3,2,1,4,1,2,2,5,4,4,2,1,5,2,2,1,5,3,1,1,1,5,4,2,3,3,1,4,2,5,1,2,5,4,2,1,4,5,4,1,1,4,2,4,2,4,5,3,3,1,1,3,3,1,5,1,5,2,5,3,4,4,1,5,5,3,1,2,1,5,3,4,1,1,1,1,1,1,1,2,4,1,5,3,4,4,3,4,1,5,2,5,3,4,2,5,1,2,1,4,4,2,5,5,3,2,1,1,3,4,4,4,3,3,4,5,5,2,1,5,1,5,4,2,2,3,5,3,1,5,4,4,5,5,1,5,3,3,5,3,3,1,1,4,1,1,4,4,1,1,4,2,2,3,1,3,1,1,5,2,2,1,3,5,2,3,3,1,5,3,3,4,1,1,5,5,4,4,2,3,2,1,4,2,5,5,3,1,4,2,1,4,2,5,5,2,4,1,5,2,2,3,4,2,3,2,3,3,4,2,3,4,1,1,1,2,2,2,1,3,2,5,3,1,3,2,5,2,2,4,5,1,5,1,5,3,4,3,4,4,2,5,2,4,5,1,3,2,4,2,3,5,2,5,1,1,2,1,5,4,1,4,1,2,1,4,5,3,2,4,2,3,4,5,4,1,2,1,1,5,2,1,1,5,3,1,2,4,5,5,3,3,4,3,5,1,4,1,3,1,5,2,4,4,3,2,3,5,2,3,4,5,1,4,2,2,5,2,5,1,3,4,5,4,1,4,3,1,1,5,5,4,1,2,1,1,4,4,2,1,4,1,3,5,2,4,4,4,4,5,1,3,4,3,1,3,2,1,1,2,2,4,1,4,5,5,2,4,5,1,1,5,5,5,3,3,3,1,4,5,2,3,2,2,1,5,5,5,5,1,5,3,2,4,3,4,2,5,4,2,3,3,2,5,4,1,5,5,1,2,3,5,4,5,3,1,4,3,4,3,4,2,4,4,1,4,2,1,1,5,1,3,1,1,1,2,2,2,3,1,1,5,5,1,2,5,3,1,2,2,1,3,3,1,3,2,2,1,3,5,4,1,5,3,1,1,4,2,2,3,4,5,3,5,2,4,3,2,4,5,4,3,3,5,3,3,3,4,5,2,5,1,2,3,5,5,5,5,4,2,1,1,2,2,1,3,4,5,3,4,3,5,4,5,3,3,2,3,3,3,5,4,1,2,3,5,3,2,3,3,3,2,2,2,3,4,1,2,1,1,2,2,5,1,1,3,1,1,1,3,4,5,2,1,1,5,4,3,4,5,2,3,2,4,3,5,3,1,4,2,2,2,4,5,2,5,5,2,4,2,5,1,3,1,2,3,2,3,1,5,1,2,5,4,4,3,2,3,2,5,4,4,2,5,3,5,3,5,4,2,4,3,1,2,1,4,4,4,4,3,1,1,2,5,3,4,2,2,2,4,3,3,1,5,2,5,3,1,4,3,3,2,5,5,4,5,4,3,2,3,4,2,1,4,4,1,3,1,3,5,4,4,3,5,2,1,4,2,3,2,3,2,3,2,2,4,1,3,5,2,5,1,2,4,2,5,2,5,2,5,4,2,1,1,2,2,4,3,1,4,3,5,2,5,5,1,3,1,5,2,1,5,1,4,1,2,5,4,5,4,5,1,5,1,3,1,4,4,2,4,5,3,5,1,3,1,4,1,3,5,1,4,2,2,5,3,1,5,3,5,1,1,2,2,1,5,3,1,2,2,4,4,4,3,1,3,2,2,1,1,3,2,4,2,4,1,1,2,1,5,3,1,3,5,4,2,2,1,4,1,1,3,3,5,5,1,5,5,1,5,3,1,4,5,1,5,2,4,5,1,4,5,4,2,2,4,1,4,3,4,1,1,1,2,2,1,2,4,4,2,4,4,2,3,3,2,4,4,5,1,2,2,4,2,5,5,5,2,2,2,5,1,5,5,3,1,1,1,4,5,5,3,3,2,3,5,4,5,4,1,1,4,5,3,5,2,5,5,4,1,3,3,1,5,5,1,4,4,1,5,3,5,4,1,2,1,5,2,2,4,2,2,1,2,4,2,3,3,3,1,5,5,4,5,4,2,2,1,5,2,1,5,5,2,3,3,1,5,2,4,4,1,3,2,5,1,2,1,5,3,3,3,2,3,3,4,2,1,4,2,3,3,3,5,4,2,4,5,5,1,5,2,4,4,3,1,2,2,1,4,4,4,1,5,3,5,1,2,3,5,5,3,4,3,4,3,3,3,4,2,5,4,3,5,4,2,2,3,3,5,2,3,5,3,3,3,5,5,2,1,1,3,1,1,4,1,2,1,3,5,4,1,4,1,5,4,4,2,2,5,3,2,2,2,5,2,1,1,5,3,4,5,1,5,5,1,2,2,2,4,4,5,5,4,1,4,4,5,5,5,5,2,3,3,3,5,1,5,5,5,1,3,2,5,4,3,2,4,2,4,1,3,1,5,1,2,5,2,4,2,5,5,4,1,4,4,5,1,1,5,2,4,1,5,5,1,2,4,4,1,4,3,1,2,4,1,2,1,4,5,2,5,2,5,1,1,2,5,2,1,1,1,3,3,5,2,5,1,3,1,2,3,4,3,1,2,4,4,4,2,1,1,4,2,3,4,1,3,3,4,3,4,4,3,2,1,2,3,2,3,1,3,3,5,4,1,1,1,3,3,4,5,5,5,3,1,2,1,2,3,4,5,4,5,4,1,5,1,3,1,4,1,2,5,1,4,3,4,2,4,2,3,3,4,5,5,5,2,5,3,3,5,3,5,1,4,3,2,1,2,2,4,1,5,3,3,1,2,2,4,5,5,4,4,1,2,1,5,2,2,4,1,2,5,4,1,3,3,1,1,1,3,3,4,1,1,4,3,2,2,3,1,3,5,4,1,3,4,2,2,2,2,4,1,3,1,3,2,5,2,2,2,1,3,3,4,2,3,4,2,1,4,1,5,4,5,1,4,5,3,4,5,3,4,5,1,3,4,2,5,3,3,4,4,5,4,1,5,4,1,1,1,3,3,1,5,1,2,2,2,5,3,1,2,4,1,1,1,3,3,3,2,5,4,2,1,5,1,3,4,4,4,5,4,2,4,5,3,5,5,5,3,5,3,1,2,1,3,1,2,5,1,1,5,1,3,4,5,2,2,4,5,2,2,5,4,5,1,2,2,2,4,1,3,2,2,2,5,3,2,2,2,2,4,3,3,3,4,3,1,3,2,5,5,4,5,2,4,2,4,4,2,4,2,5,3,2,4,3,2,3,5,4,2,3,2,4,4,5,3,5,3,2,2,3,2,1,1,3,5,1,1,3,2,2,2,2,5,3,2,2,1,4,1,4,4,2,3,5,5,1,3,4,4,1,1,2,1,4,5,3,1,1,5,1,1,2,4,1,2,2,5,1,2,1,5,2,5,5,2,4,5,4,4,4,3,1,5,5,4,4,1,2,4,2,4,2,2,3,2,5,5,1,2,1,4,5,3,5,3,2,2,1,4,1,4,1,4,1,5,4,2,1,5,2,3,3,5,4,2,1,1,4,5,2,4,1,1,3,4,2,5,2,5,5,4,1,5,1,3,2,3,2,4,4,2,5,3,3,3,2,2,1,1,3,4,1,4,5,3,3,4,4,5,1,1,2,3,3,4,4,4,5,5,3,2,3,3,4,3,2,1,3,1,2,3,4,5,1,3,1,4,4,1,5,1,2,1,5,3,2,4,1,5,3,5,3,1,2,4,4,2,4,2,4,1,1,2,2,1,1,2,1,3,5,4,4,4,4,3,5,5,4,3,3,2,2,1,5,2,3,5,3,3,5,4,3,4,2,2,2,3,5,3,4,1,1,2,1,5,4,1,1,4,2,4,2,3,4,3,5,1,4,2,4,1,2,2,3,1,5,2,4,3,3,1,1,3,2,1,4,4,1,5,2,5,3,3,1,5,2,4,4,3,3,1,5,1,2,1,5,1,3,2,5,1,3,1,4,2,3,3,2,2,4,3,3,4,1,2,3,4,5,5,1,2,1,5,1,2,1,2,1,3,5,2,4,5,5,2,2,1,5,5,3,3,3,3,2,1,3,2,4,3,1,3,1,4,3,5,3,4,1,1,2,5,2,3,2,2,5,1,3,2,5,5,1,3,2,5,2,2,1,4,4,1,5,1,4,3,1,1,4,1,4,2,2,2,1,2,4,5,1,5,3,2,3,5,1,5,3,2,2,2,5,3,3,5,1,2,5,5,2,5,4,2,1,3,4,4,3,4,2,4,5,1,5,4,5,3,3,5,2,3,3,4,1,2,4,2,3,3,4,3,3,5,1,3,4,2,3,3,2,2,2,3,3,1,2,2,1,1,2,1,1,5,2,1,2,5,1,4,1,4,4,3,3,3,3,1,2,3,5,3,4,4,5,1,5,4,4,5,2,2,1,5,2,2,3,3,1,2,5,1,3,3,1,5,4,2,3,5,2,2,4,4,2,1,2,5,3,4,5,3,1,3,4,3,2,3,3,1,3,2,5,3,4,3,5,2,3,4,2,4,5,3,4,1,2,4,3,3,2,2,4,3,1,4,3,4,3,2,5,1,1,1,5,1,3,4,5,2,4,4,4,2,5,3,4,2,3,1,5,4,4,3,2,1,2,5,4,5,4,4,3,1,1,5,1,3,2,1,4,2,3,2,2,3,4,1,3,5,3,5,1,5,1,3,1,1,2,2,3,4,2,1,1,3,3,2,1,5,3,2,2,4,5,1,5,2,1,3,3,5,3,2,3,2,2,4,1,4,2,2,2,5,2,5,5,2,1,4,2,5,1,5,1,5,4,2,1,4,3,1,4,5,1,5,5,2,2,3,4,3,2,5,2,5,5,1,1,1,4,2,3,5,4,2,4,5,2,4,5,2,2,3,3,2,3,4,3,4,4,4,2,1,4,4,5,5,2,4,5,1,1,4,1,1,3,3,2,1,2,5,5,3,3,1,1,4,4,5,2,3,5,2,3,5,3,5,3,5,3,5,5,5,3,2,1,3,2,2,4,4,2,5,2,3,5,5,1,1,3,3,3,5,1,4,1,2,3,1,2,3,3,3,2,2,3,3,2,3,5,4,5,2,5,2,3,2,1,5,3,2,2,5,4,1,4,3,3,1,1,3,2,1,3,4,5,5,1,1,4,1,2,3,4,1,5,3,1,1,4,5,3,4,1,2,3,5,4,1,3,4,5,5,4,2,1,2,2,2,3,5,5,4,4,5,5,5,1,5,4,3,3,5,4,5,5,3,4,5,2,2,2,3,3,3,1,2,1,3,2,2,4,1,1,1,5,3,3,1,4,1,2,3,2,4,4,1,2,5,1,4,3,4,3,3,3,3,5,4,2,3,1,4,1,5,1,5,2,1,3,4,1,2,3,1,2,5,1,1,4,3,3,2,3,1,1,2,2,1,5,3,3,4,4,2,4,1,3,5,5,2,1,5,4,3,1,1,1,3,4,3,1,2,3,2,4,4,5,1,3,1,4,1,5,5,1,3,3,5,3,3,3,1,5,4,5,3,1,5,1,3,5,3,5,5,1,1,5,4,4,1,5,5,1,4,1,1,2,4,4,2,5,4,3,4,2,3,2,5,2,4,2,4,5,3,1,5,3,5,5,1,4,1,2,3,3,4,1,1,3,5,4,1,1,3,2,3,1,2,4,4,1,2,1,5,1,5,2,2,4,3,4,2,5,5,4,3,5,2,3,1,3,4,5,2,1,4,2,3,3,5,1,2,1,1,2,3,4,4,1,5,1,2,5,2,2,4,3,2,4,2,1,1,4,3,4,2,2,1,3,5,1,2,4,4,5,4,5,3,2,4,2,3,3,4,3,4,2,2,3,4,3,5,1,3,3,5,5,3,1,3,5,5,3,5,1,2,5,5,2,5,1,1,1,5,2,5,3,4,3,4,2,1,1,3,3,2,4,1,5,5,1,3,1,5,3,1,5,5,5,4,1,3,4,4,5,1,3,2,3,3,2,1,3,3,5,5,2,4,4,4,1,4,2,1,2,3,5,2,5,4,5,2,5,3,2,1,3,5,2,2,5,1,2,4,5,3,4,1,5,3,2,3,4,5,1,2,2,4,3,5,5,1,2,4,1,4,1,4,2,5,4,5,3,1,1,4,4,3,4,5,4,3,1,5,3,4,3,1,2,3,4,3,3,1,5,3,3,1,1,4,3,2,3,3,5,5,3,5,4,2,1,1,3,5,2,1,2,3,1,5,1,5,3,1,2,2,1,5,4,4,4,5,2,4,4,4,4,2,2,5,4,1,4,2,5,4,4,4,3,3,1,2,1,4,5,2,3,2,1,2,1,5,1,4,2,1,3,1,4,2,4,5,3,1,5,2,5,1,1,1,5,4,4,2,4,3,3,3,3,3,3,3,3,2,5,4,3,3,2,3,2,2,2,5,4,2,4,3,1,5,1,1,4,5,1,2,4,2,1,4,2,1,2,2,1,2,4,4,3,4,1,5,4,3,3,5,1,4,2,2,2,1,2,4,1,2,4,5,4,2,4,4,1,5,1,2,5,5,4,3,2,2,4,5,5,4,4,5,4,3,1,2,1,1,2,4,3,4,2,5,1,1,3,1,1,2,3,5,5,1,3,4,1,5,2,2,1,2,4,1,4,1,3,3,4,4,5,5,3,1,5,4,1,1,5,3,5,2,4,2,4,3,2,5,4,1,4,3,5,3,1,2,5,3,1,4,3,5,4,2,3,2,2,2,3,4,5,5,1,3,3,5,4,2,3,4,2,1,1,3,5,5,3,5,5,3,1,5,3,2,4,3,1,2,4,1,3,3,3,3,2,1,5,2,1,1,5,2,5,4,4,5,2,3,1,1,4,3,2,4,3,4,3,4,3,1,4,4,3,2,1,2,2,3,2,1,3,5,1,2,3,1,1,4,4,5,4,3,4,5,5,5,4,3,1,5,3,2,1,4,2,4,2,4,4,4,1,3,1,1,5,2,3,1,2,5,1,5,3,1,5,4,2,1,1,3,4,2,5,2,5,3,5,1,4,4,2,5,4,3,3,3,5,3,3,5,2,4,1,5,1,5,3,4,2,1,1,2,4,2,1,2,4,3,1,4,4,4,1,5,4,3,3,3,3,4,1,1,2,4,3,1,3,3,4,4,3,4,3,2,4,5,4,1,4,3,1,2,1,1,4,2,3,4,5,5,2,5,2,3,1,5,5,2,2,1,1,3,3,5,1,1,5,2,1,3,4,4,4,5,5,3,4,1,1,2,5,3,5,3,2,1,2,5,4,3,2,5,3,2,4,1,4,1,1,5,5,3,4,2,5,1,1,2,1,4,5,4,4,1,2,4,1,5,5,4,3,4,3,4,5,2,3,1,1,4,4,4,2,5,2,1,4,2,1,2,1,1,2,5,3,2,3,5,5,3,1,5,3,1,5,2,2,2,2,3,3,1,2,4,2,2,1,2,1,3,3,2,5,2,1,5,1,5,5,4,3,5,2,3,3,2,4,3,3,2,4,3,1,3,2,1,1,2,5,2,4,5,5,1,4,2,4,2,2,1,5,2,1,5,1,2,5,1,5,4,4,3,4,1,3,2,5,3,4,4,3,5,4,5,2,3,3,5,3,3,5,5,4,5,5,4,4,5,5,5,3,1,2,5,2,1,5,1,3,3,1,1,5,2,3,2,2,2,3,1,5,4,4,2,1,3,4,1,2,2,2,3,3,1,2,4,3,1,5,4,5,1,3,1,1,3,2,2,5,2,2,2,1,4,1,4,1,1,1,3,3,4,5,2,5,1,5,3,5,2,4,4,5,4,4,1,4,4,2,4,3,1,2,1,4,4,2,4,2,5,2,2,4,5,2,3,3,4,3,3,5,5,4,3,4,4,3,5,4,4,5,2,2,4,1,5,1,5,3,1,4,3,5,1,4,2,3,3,5,5,2,5,2,3,3,1,3,1,2,2,5,5,2,5,4,4,3,3,4,2,3,2,5,1,4,3,4,1,2,3,3,2,4,2,3,1,4,1,3,4,1,1,3,4,5,5,5,5,5,5,3,1,4,5,2,1,5,2,3,1,2,2,2,5,5,5,4,2,1,2,2,4,4,2,5,1,1,2,2,1,2,2,2,4,4,2,5,5,3,1,1,3,2,2,1,5,5,2,2,5,5,4,5,3,3,2,3,4,2,2,3,1,4,4,5,3,3,5,5,5,4,3,2,1,2,3,3,3,3,2,5,3,4,4,5,1,4,5,4,5,1,3,2,4,5,2,1,5,4,5,1,1,5,4,5,4,5,2,5,1,1,2,5,3,1,2,1,3,1,3,4,2,1,1,3,1,5,5,1,4,1,4,1,2,3,1,5,1,5,1,1,4,2,2,4,3,2,1,1,3,2,3,1,2,3,3,1,2,3,3,2,3,4,1,1,3,3,3,1,5,2,3,3,2,1,1,3,1,2,2,3,3,4,1,4,4,3,2,2,1,5,5,4,3,1,4,5,4,2,2,1,1,2,5,2,5,2,4,4,4,2,5,3,3,1,2,1,3,2,5,5,4,2,1,4,2,4,3,2,5,4,3,1,2,3,1,4,4,2,1,4,3,1,2,3,4,3,2,3,3,4,3,3,1,1,2,1,3,3,3,1,2,3,1,5,1,2,4,2,4,1,1,4,3,3,1,1,5,5,1,1,4,5,4,1,2,2,1,1,5,1,5,3,3,4,5,3,5,3,4,3,4,1,5,2,1,5,2,2,4,3,1,2,2,3,5,5,4,3,5,2,1,3,2,4,1,3,4,4,3,1,5,3,3,4,3,4,4,4,4,5,3,4,2,1,5,3,5,1,1,2,2,1,4,1,3,2,1,1,1,4,1,5,1,4,3,4,1,4,1,1,3,1,4,5,5,1,4,5,3,4,1,5,2,2,5,3,2,2,4,5,2,2,4,1,1,4,3,4,4,4,5,5,3,2,5,5,5,2,5,3,5,3,3,2,3,5,1,4,1,2,3,3,2,4,2,5,4,4,3,2,5,3,3,2,2,5,5,2,5,5,1,3,4,5,3,5,2,5,3,1,3,5,3,2,1,4,3,3,4,1,4,1,1,5,5,1,4,4,1,5,4,1,2,2,4,4,2,3,1,4,2,2,2,2,2,4,3,4,5,2,5,1,4,5,5,3,1,2,2,3,4,3,5,1,4,1,3,3,2,4,2,4,3,5,5,1,3,2,5,5,5,2,1,4,3,1,2,2,4,2,5,3,2,5,5,3,3,4,5,3,4,1,4,3,3,4,2,4,1,1,3,1,2,3,1,4,1,5,4,4,1,4,2,2,4,2,1,3,1,1,1,3,5,4,3,4,2,3,5,5,5,1,5,1,3,2,3,2,5,4,4,3,4,4,3,4,2,1,1,3,2,1,1,4,1,4,4,5,4,4,1,1,2,5,2,3,5,2,1,2,2,1,4,1,2,2,1,3,5,1,3,1,3,5,4,5,5,3,4,5,1,4,2,4,5,4,4,2,3,5,1,2,3,4,1,2,1,2,1,3,5,1,3,4,4,2,2,3,2,5,4,4,3,4,5,3,1,1,3,3,4,2,4,1,5,3,4,1,5,2,2,1,3,1,1,5,5,4,1,3,5,1,4,5,4,2,5,5,2,1,3,5,1,2,4,4,3,1,2,2,4,1,4,3,2,2,3,3,5,2,2,2,3,4,2,2,3,5,4,4,3,1,3,3,2,3,4,4,1,1,5,4,1,5,3,3,1,3,2,5,1,2,4,4,4,2,3,1,1,5,2,5,3,1,1,4,3,5,5,4,4,1,1,1,1,3,4,1,4,2,4,5,4,2,1,5,3,1,3,2,4,1,1,2,2,1,5,2,3,4,4,1,4,3,5,4,1,4,4,2,3,1,5,5,1,5,2,1,2,4,5,3,3,4,4,2,1,5,4,1,4,3,4,5,3,4,2,5,2,3,3,5,5,2,3,5,5,3,1,1,5,2,2,1,4,4,3,5,3,2,2,3,5,5,4,2,3,3,4,4,5,5,3,2,3,5,3,5,4,4,1,3,4,4,2,2,2,5,1,3,4,1,2,3,2,1,4,1,1,2,3,5,4,5,4,3,4,2,2,4,1,1,5,2,3,4,3,2,1,3,1,5,5,5,2,5,3,5,1,3,2,3,1,3,2,1,4,4,4,3,5,1,4,4,2,3,4,5,4,3,1,3,3,2,3,2,5,2,1,2,3,4,3,5,4,4,5,1,3,4,3,5,5,2,5,5,1,4,1,4,1,1,1,5,4,1,2,4,5,1,5,2,5,5,2,4,3,3,1,4,1,1,5,4,5,2,3,3,1,4,2,4,2,5,3,3,4,5,5,2,1,3,4,1,1,2,2,2,2,1,5,1,3,5,3,3,3,2,1,1,5,5,4,3,3,2,4,3,2,2,1,5,1,1,3,1,4,5,1,5,4,4,2,5,4,5,2,5,2,4,2,4,3,2,3,3,5,5,2,3,4,5,3,2,1,2,2,2,3,4,3,5,1,3,2,4,1,1,1,5,2,4,3,3,4,3,1,3,5,1,5,4,3,2,3,3,5,2,3,2,5,1,5,3,4,1,5,4,4,3,5,5,4,4,3,5,4,4,2,1,1,3,1,5,1,3,2,5,5,1,4,3,3,5,3,3,3,3,4,5,1,3,2,1,1,4,1,4,2,1,4,4,3,1,2,2,4,1,3,5,5,3,2,3,1,2,4,2,5,2,5,1,3,1,2,3,2,4,2,5,1,4,4,3,3,1,5,3,4,3,5,1,3,4,3,1,4,4,5,2,4,3,5,2,1,3,5,4,1,1,3,1,5,4,4,4,1,3,4,2,4,1,3,5,2,2,5,4,2,5,2,2,2,1,2,5,5,5,3,4,5,4,3,4,1,2,1,2,5,3,5,2,5,5,3,1,5,2,5,2,4,4,3,4,5,2,1,2,3,5,3,3,5,3,1,3,4,2,3,3,2,4,2,3,3,1,5,2,4,5,4,4,5,2,1,4,5,4,1,2,5,3,3,4,5,5,4,1,4,3,4,2,1,1,1,3,2,5,5,1,5,5,3,5,3,3,5,1,4,1,3,3,2,2,1,2,3,3,5,3,4,3,3,4,1,4,4,1,2,3,4,4,1,3,3,3,3,1,4,4,1,3,3,1,1,2,4,5,5,1,2,1,4,1,3,5,2,1,1,1,3,3,3,1,5,5,5,1,4,2,3,1,2,3,4,1,2,5,2,1,5,3,4,3,1,1,1,1,4,2,1,4,5,1,2,4,5,5,3,2,4,2,5,3,2,2,4,1,5,2,5,4,2,3,1,3,3,4,3,2,3,3,2,3,5,3,4,5,2,1,4,1,5,3,2,5,1,4,2,1,2,2,4,4,2,5,1,1,3,2,1,4,3,3,4,3,5,1,4,2,5,5,1,4,5,3,2,1,3,2,1,4,2,5,2,2,5,3,1,4,3,1,2,1,5,2,2,2,1,5,3,1,4,3,2,5,4,4,2,3,4,4,4,1,3,1,2,4,4,1,1,3,2,3,1,1,3,4,2,4,2,2,3,5,2,5,2,5,3,5,3,2,3,1,5,5,3,5,4,2,3,3,4,4,2,3,4,3,3,2,2,4,2,3,1,2,5,2,1,2,5,1,5,2,1,3,5,4,5,1,1,3,3,4,4,3,3,2,1,2,4,2,3,3,4,1,3,5,1,3,3,1,5,3,2,4,1,4,3,2,4,1,5,3,1,3,4,3,2,3,5,5,5,3,4,1,4,5,4,1,5,2,3,3,1,2,5,5,2,5,4,2,1,3,4,3,2,3,3,4,2,2,3,1,2,3,5,5,5,2,4,5,4,1,3,3,2,4,2,5,3,5,1,4,4,5,4,3,4,1,1,3,1,3,5,1,5,4,2,5,3,4,3,4,2,2,2,3,2,5,4,5,3,1,1,4,5,5,1,2,3,4,1,4,2,5,2,4,4,2,3,1,4,1,3,3,3,4,1,3,4,1,2,5,1,1,2,3,3,3,1,2,1,2,1,5,2,4,5,3,4,5,5,3,4,3,4,3,5,4,1,2,4,4,5,3,1,5,5,3,2,4,2,5,5,4,1,5,1,2,2,4,2,4,2,3,2,3,5,2,4,4,3,4,5,1,1,5,2,5,1,5,4,3,1,5,5,1,2,4,1,1,3,3,3,2,2,5,5,3,1,3,5,4,3,3,1,4,5,5,1,2,2,5,3,4,4,5,3,3,5,1,2,5,1,1,5,1,2,2,2,1,3,1,2,3,3,5,3,3,3,4,5,2,1,3,2,2,4,1,2,2,3,5,1,3,3,3,4,5,2,2,3,3,1,4,4,2,5,2,1,3,4,3,2,3,3,4,1,5,4,1,5,1,2,4,2,1,5,4,2,2,2,5,4,1,3,5,4,2,1,5,2,5,1,5,2,4,2,3,1,2,3,5,5,3,3,3,5,5,3,2,4,3,2,4,5,4,4,5,1,1,1,4,3,4,3,5,3,1,2,4,2,1,5,5,2,4,4,1,3,1,2,3,3,5,1,1,1,5,1,2,4,1,2,3,4,3,3,5,5,4,2,2,5,4,1,5,2,3,5,3,4,4,1,1,4,1,3,1,3,2,1,1,2,1,1,3,4,2,3,5,2,2,2,2,2,1,5,3,1,5,3,1,2,3,5,2,1,3,2,5,3,1,3,4,1,4,1,2,3,2,1,2,4,2,2,5,3,3,3,3,3,4,4,3,2,5,2,1,5,4,2,2,3,1,2,2,2,5,4,1,3,3,5,5,3,5,2,1,2,4,5,2,5,4,2,3,5,3,3,4,4,3,5,1,1,4,1,1,2,5,1,3,2,5,4,2,4,4,2,1,4,4,2,1,4,1,3,1,1,4,2,5,5,1,3,5,1,5,4,2,3,3,1,2,1,3,3,2,5,2,3,1,1,1,1,5,5,2,5,4,5,4,2,4,1,4,2,1,3,5,2,3,1,1,1,3,3,2,3,3,4,3,2,5,5,4,4,1,1,2,1,5,4,5,2,3,5,1,5,2,4,1,1,1,1,3,1,1,4,1,1,2,1,5,2,5,1,1,5,4,2,4,4,2,2,3,3,1,5,1,3,4,3,4,2,4,4,2,4,2,5,2,3,1,4,2,1,1,5,3,1,5,2,1,1,4,5,3,4,1,1,3,2,4,5,4,5,1,2,3,2,1,2,4,5,4,1,2,4,3,2,2,5,2,4,4,5,5,5,4,3,4,4,4,5,5,5,5,4,1,1,3,5,4,5,3,5,3,2,5,5,5,5,1,3,2,2,2,2,2,1,3,4,3,2,4,1,2,3,3,1,1,5,3,5,4,1,1,3,1,2,2,5,4,4,4,2,5,1,4,5,1,5,3,1,5,1,5,4,4,2,3,2,5,5,2,1,4,5,3,1,1,5,4,2,1,3,5,1,2,5,3,5,5,1,4,1,5,3,3,4,5,5,1,5,5,2,4,4,5,2,4,1,3,3,1,3,5,2,5,5,4,1,5,1,5,1,1,2,2,1,1,2,1,5,1,3,5,1,5,4,5,2,1,2,5,4,1,4,2,1,3,4,3,1,4,4,2,5,1,4,2,5,2,2,2,3,3,2,3,3,5,4,4,1,3,1,3,3,5,2,2,2,1,3,3,2,5,2,4,2,3,4,3,2,1,3,5,4,4,1,3,3,4,4,3,1,5,3,1,4,2,4,1,1,1,4,5,4,4,1,1,1,4,2,5,5,3,5,4,3,2,5,3,5,4,3,1,2,3,3,5,3,4,3,5,1,2,5,3,4,2,2,3,2,3,4,2,3,2,1,2,2,2,4,3,1,4,2,1,5,3,5,3,2,5,4,4,1,5,5,4,3,1,1,2,1,4,4,3,2,2,1,1,5,1,2,2,5,1,4,1,1,4,5,2,3,3,1,5,4,1,3,4,2,2,5,2,4,4,2,4,1,5,5,4,3,2,1,2,4,4,5,1,3,5,4,3,3,3,4,2,2,4,5,4,4,1,2,1,5,4,2,5,4,4,3,3,3,1,3,2,4,1,1,1,3,4,4,5,1,4,4,1,4,4,4,1,2,3,4,4,5,5,2,4,1,3,3,2,4,3,2,3,1,3,1,5,5,2,3,1,1,4,2,1,3,1,2,2,3,4,2,1,2,5,1,5,1,2,3,3,1,5,5,5,2,4,3,4,4,1,3,3,1,4,4,4,1,2,1,3,5,1,5,4,5,4,2,5,3,1,2,5,3,1,2,5,2,1,4,3,5,3,2,5,2,4,3,4,2,4,1,4,1,1,3,5,2,1,5,1,1,1,2,3,2,4,5,5,4,4,1,3,5,3,2,5,1,3,2,5,2,5,1,2,1,1,3,4,5,3,2,5,4,2,4,3,5,2,4,2,1,3,2,2,4,3,1,2,5,4,1,1,1,2,3,2,2,5,2,5,2,1,5,4,2,1,3,4,3,4,3,4,4,1,3,5,5,2,2,4,1,4,4,3,4,1,2,5,2,1,2,1,3,3,5,2,5,3,4,3,3,2,5,4,1,3,3,5,3,4,4,3,2,4,2,4,1,4,3,1,4,3,2,3,4,4,3,5,4,4,3,5,5,3,2,3,1,3,5,3,4,2,1,5,2,2,3,3,4,1,3,2,1,2,2,2,3,1,4,2,5,4,5,3,3,1,1,3,4,1,2,5,1,4,2,5,1,2,5,1,2,2,3,5,3,1,1,1,5,4,4,3,5,3,3,4,3,5,1,1,1,2,5,3,2,3,5,4,2,3,1,2,4,4,1,2,5,4,3,2,2,2,4,4,1,5,2,5,5,4,2,1,4,3,4,2,1,2,4,2,5,1,4,1,1,1,5,3,5,5,4,3,1,3,4,1,3,4,5,1,2,4,3,3,4,1,1,1,3,2,1,2,1,1,2,5,3,5,1,2,2,1,2,1,2,4,5,5,1,1,2,1,4,2,5,5,3,1,4,3,3,5,2,1,1,4,4,4,4,3,5,1,4,5,3,1,4,5,1,3,5,2,2,3,2,1,1,5,1,1,1,2,4,5,3,1,4,1,3,2,2,1,4,3,1,5,3,5,5,2,1,5,4,2,1,4,4,1,2,1,2,4,4,4,5,3,5,5,2,3,1,5,2,1,1,1,2,2,3,1,4,3,3,2,5,1,3,4,4,5,2,1,4,5,5,5,1,5,2,2,2,1,3,2,1,3,1,1,2,3,5,1,4,4,1,3,4,3,1,4,2,5,4,5,4,1,3,2,4,2,1,2,3,1,5,3,3,1,4,3,3,2,4,3,2,3,5,2,3,1,3,4,2,5,4,5,3,1,1,2,2,1,3,3,1,1,3,1,5,4,3,3,4,5,5,4,5,3,3,3,3,1,1,2,5,5,5,4,4,3,4,2,3,2,1,2,3,5,5,4,4,2,5,5,2,3,3,4,3,4,1,3,1,3,4,2,2,3,5,4,5,5,4,4,5,1,1,3,5,2,2,2,2,3,4,5,4,5,1,1,4,5,3,2,3,3,3,3,2,4,1,2,2,1,2,1,2,2,4,4,2,4,3,3,4,3,5,5,1,1,1,2,2,2,5,2,2,3,3,4,3,1,3,5,5,5,5,5,2,4,1,2,1,1,3,2,3,2,2,5,2,4,4,4,5,5,1,1,5,3,1,2,4,4,1,4,3,3,3,4,3,5,5,3,4,1,3,2,1,2,4,3,4,5,4,3,3,5,3,1,1,3,5,5,2,4,2,5,1,3,2,3,4,3,4,1,1,4,3,4,3,4,3,1,2,2,5,2,2,2,4,5,5,3,2,2,2,2,1,4,3,4,5,2,5,2,5,2,2,5,4,3,3,2,2,3,5,4,4,5,5,4,4,2,4,2,2,3,1,1,5,2,2,2,4,5,5,5,4,5,2,1,1,3,2,4,3,2,4,3,3,5,5,5,2,2,1,5,3,2,3,3,1,5,2,3,1,5,4,4,4,3,5,1,4,4,3,1,1,1,1,5,2,3,3,5,3,3,4,4,2,1,4,2,3,2,1,4,3,3,3,3,5,1,2,2,1,4,4,2,3,5,3,5,1,3,4,4,5,3,2,1,2,2,5,4,4,4,4,4,3,2,4,1,2,2,2,1,4,4,4,3,5,1,4,2,4,4,3,4,1,4,1,3,1,2,1,4,3,3,5,3,1,2,4,3,3,2,4,1,3,2,3,5,3,1,1,5,5,5,2,4,2,2,1,3,3,4,3,1,1,2,2,3,5,3,4,5,1,5,1,4,5,1,5,5,1,2,5,5,4,1,2,4,4,1,4,5,2,5,1,4,5,1,3,2,2,3,2,1,1,2,3,3,4,5,1,4,5,4,3,5,1,5,1,4,2,5,1,2,4,5,1,3,1,3,1,2,3,5,5,3,1,5,4,5,3,1,3,4,1,3,5,2,3,2,4,1,2,3,2,5,4,1,3,2,1,1,5,5,5,4,5,4,5,3,4,4,2,2,5,2,5,3,1,1,5,1,4,2,3,4,4,5,1,1,1,3,4,4,2,5,2,3,3,4,4,5,1,2,2,3,3,5,2,3,3,2,2,2,3,3,5,2,4,3,5,2,3,2,5,1,2,4,3,3,2,3,5,5,2,4,2,5,1,1,1,3,2,5,4,2,1,4,1,4,3,3,3,1,2,4,3,1,2,3,3,2,3,4,1,5,3,4,1,1,5,4,5,2,3,2,2,5,4,4,3,1,5,1,1,1,4,4,5,4,3,5,3,1,2,5,1,1,4,4,5,4,4,3,1,4,2,1,3,5,1,2,5,5,3,1,2,1,2,5,3,1,1,1,1,3,2,3,2,4,5,2,1,4,5,1,5,5,1,1,1,5,3,1,4,3,4,3,5,1,3,2,2,5,2,3,2,4,4,3,2,4,2,3,5,3,1,4,5,2,1,2,1,2,1,1,1,2,1,3,3,1,4,5,3,5,3,5,4,3,5,3,4,2,5,2,5,2,2,5,2,1,3,4,2,3,1,1,1,5,2,3,1,3,3,5,4,5,5,3,3,2,4,4,2,2,1,5,2,5,5,5,4,4,4,5,5,3,1,1,5,3,2,2,4,3,4,3,2,5,5,5,4,5,2,2,1,3,1,2,1,5,5,5,2,5,3,1,4,5,3,3,1,5,2,3,5,5,5,5,4,2,4,4,4,4,5,2,3,1,1,3,2,1,4,1,5,5,4,1,2,3,2,3,3,1,5,3,3,1,1,4,1,2,4,2,3,5,5,2,5,4,3,2,3,3,3,3,5,1,4,4,2,1,4,2,5,1,1,3,5,5,5,5,3,3,3,2,1,3,3,3,4,1,4,1,1,3,1,3,3,3,3,3,5,2,4,3,2,1,4,2,3,1,4,2,3,3,1,1,4,2,2,1,4,5,4,3,2,1,4,4,1,2,5,1,2,3,2,2,1,3,4,4,4,4,1,4,3,1,2,4,1,5,4,2,4,5,2,4,4,4,3,4,4,5,4,5,3,4,4,2,2,2,2,3,5,2,4,2,5,3,5,5,5,3,1,5,1,4,4,3,5,1,2,3,2,3,3,4,4,5,5,3,3,5,1,1,4,2,5,4,3,5,3,4,4,5,5,1,5,5,5,4,3,4,1,1,2,5,2,2,5,5,2,1,5,5,2,3,3,4,3,4,3,1,5,3,2,3,4,3,4,3,3,3,3,2,1,4,1,4,4,5,2,1,4,2,2,5,1,1,1,3,3,2,2,2,3,5,3,5,5,1,2,4,2,2,1,2,4,1,3,5,2,5,2,4,2,5,5,1,2,3,2,5,4,4,1,5,2,1,1,2,3,1,1,2,1,5,5,3,3,2,1,1,2,5,1,1,2,5,3,4,4,5,4,2,3,1,5,1,3,4,5,5,3,3,3,5,4,3,3,5,1,4,4,4,2,3,2,2,1,3,1,5,1,2,5,4,2,1,2,2,4,1,2,3,5,5,1,5,1,2,1,3,3,5,3,3,5,1,2,4,5,4,5,4,4,1,5,5,3,1,1,2,4,3,2,2,3,4,5,5,5,3,3,4,2,3,3,2,4,3,5,1,2,1,2,4,5,2,2,4,1,5,1,4,5,3,5,1,3,3,3,2,1,4,2,2,5,4,1,2,5,2,4,4,1,1,1,4,2,1,1,1,2,3,5,3,5,2,3,3,3,2,2,1,1,1,3,4,2,2,3,5,5,3,4,4,4,5,1,5,2,3,1,3,1,5,3,3,5,1,1,2,5,3,5,3,1,1,2,4,4,4,1,5,5,5,4,4,5,4,2,5,4,5,3,2,4,2,2,3,3,3,1,3,5,3,2,4,1,5,4,3,3,4,5,4,1,5,3,3,4,1,4,2,5,5,1,1,5,1,1,5,3,4,3,5,5,2,1,2,5,3,5,2,4,2,5,5,1,3,5,5,5,4,5,3,5,2,5,3,2,4,4,3,4,4,5,3,1,2,4,4,3,3,5,3,4,4,2,4,3,2,3,4,2,5,4,2,2,2,2,2,2,3,4,1,1,4,1,3,3,1,2,3,5,3,2,2,5,2,5,1,4,3,5,3,5,4,2,5,3,3,3,3,2,4,3,1,4,3,5,2,2,2,4,2,4,4,5,2,4,3,5,1,2,3,2,4,1,3,5,4,4,4,4,1,5,5,1,4,3,1,3,4,5,1,3,2,4,4,2,2,4,1,2,2,2,4,3,3,3,1,1,4,1,4,1,5,4,1,1,3,1,2,1,5,3,3,1,2,4,2,1,5,3,3,4,2,2,2,5,1,2,4,2,2,3,5,4,5,4,1,4,2,5,4,5,5,3,1,4,2,4,2,4,1,3,4,3,3,5,3,2,3,5,3,2,1,3,5,1,3,3,3,3,5,3,3,1,3,1,2,5,5,4,2,3,5,4,3,4,4,5,5,4,2,2,4,2,1,1,3,4,2,5,4,3,1,4,2,4,5,5,5,3,5,1,4,2,5,2,1,3,2,5,5,5,4,3,4,4,2,4,3,4,5,2,3,3,4,2,3,3,5,2,5,3,1,1,3,1,2,3,2,1,1,4,4,2,3,4,5,5,4,5,1,1,2,3,1,4,5,1,1,2,1,5,4,3,1,4,1,2,3,5,3,2,2,4,2,2,5,4,4,4,5,5,3,4,4,5,2,3,3,1,1,1,4,2,4,2,4,3,3,1,5,4,5,2,2,5,4,4,1,5,3,1,2,5,4,2,1,5,2,5,5,4,5,5,5,4,3,1,1,4,5,3,2,1,2,2,1,4,2,1,5,5,5,2,3,2,1,1,4,3,5,3,3,2,5,4,3,4,1,2,2,2,4,4,5,2,5,4,3,4,4,2,2,4,3,5,5,2,5,1,1,1,5,5,1,3,4,2,5,3,5,2,3,2,3,2,3,3,4,2,1,5,5,1,4,2,1,3,5,5,4,4,3,2,5,3,5,4,1,3,5,3,4,3,2,1,1,4,3,4,5,2,4,4,4,5,1,4,4,5,1,2,2,3,2,4,3,3,1,1,3,3,5,4,1,5,1,4,5,3,2,5,5,5,1,5,3,4,4,1,2,3,1,3,4,1,3,1,1,2,4,4,4,4,5,3,3,5,1,3,4,5,4,2,4,2,3,5,4,4,2,1,3,1,1,2,5,3,2,2,3,1,1,5,1,3,4,5,2,3,5,3,3,3,5,2,4,3,5,3,4,3,3,5,2,5,1,4,1,1,5,1,5,3,5,5,5,2,5,1,5,5,3,4,2,4,2,2,4,2,2,2,5,2,3,3,5,1,4,3,3,3,3,4,4,4,5,4,1,3,5,5,5,4,1,2,5,1,2,2,1,4,1,5,2,2,1,1,1,3,2,3,1,1,2,4,3,3,1,2,3,4,4,4,3,1,4,2,2,1,3,1,5,5,5,1,2,2,2,4,2,5,4,2,4,1,4,5,1,4,4,4,1,1,2,1,3,1,5,2,1,1,5,2,1,2,4,2,1,5,5,2,4,3,5,4,5,4,2,1,2,1,1,5,2,5,5,3,2,3,1,5,5,1,5,2,2,3,5,5,1,3,4,1,2,5,4,5,4,2,2,4,4,2,2,1,5,4,4,4,4,3,3,1,3,3,3,2,1,3,4,5,1,5,5,1,1,4,2,5,3,5,3,1,2,5,4,3,1,5,4,5,2,3,3,1,1,3,4,2,5,2,1,3,2,3,5,3,2,3,2,4,5,2,1,5,2,2,5,4,4,2,4,1,3,4,5,1,1,1,5,2,4,2,2,5,5,3,2,3,5,5,4,3,5,4,5,2,5,3,4,4,3,5,2,1,4,2,3,1,3,4,2,5,5,2,4,4,5,5,5,5,1,5,5,1,3,3,2,1,5,1,2,1,3,3,2,2,1,3,4,2,3,4,5,5,4,4,3,5,1,3,3,4,5,3,3,2,5,4,1,5,1,4,3,5,3,1,2,5,1,3,4,5,3,5,1,4,1,2,2,5,1,2,1,1,2,5,3,3,1,1,2,1,4,5,2,5,3,3,4,3,2,1,3,3,3,3,5,3,4,1,4,5,2,5,4,1,4,2,1,5,4,2,5,3,5,5,1,2,3,3,3,4,1,5,4,4,3,3,3,5,3,2,2,2,1,2,1,2,2,3,3,4,2,4,5,4,4,1,5,5,4,1,4,1,3,5,5,5,2,2,4,3,4,2,4,2,5,5,5,2,3,3,4,4,5,1,3,2,4,1,4,4,5,3,5,4,3,5,5,3,2,4,4,2,4,5,1,2,3,5,3,2,1,5,3,3,4,5,3,3,5,1,1,1,4,4,4,2,4,5,2,4,2,2,4,3,1,2,1,3,5,4,5,3,4,3,4,1,3,1,2,1,4,5,1,3,3,4,1,3,3,5,3,4,2,2,1,1,4,1,2,1,4,3,4,2,2,3,2,5,3,5,4,3,1,3,3,4,1,2,1,2,4,2,1,2,4,5,3,4,2,1,5,3,4,4,2,1,4,5,2,3,4,5,5,5,4,4,4,2,3,4,1,2,3,1,1,3,2,5,4,5,5,1,1,3,3,4,3,3,4,2,5,5,5,2,3,4,4,4,1,4,1,3,4,5,4,1,4,5,2,4,5,3,4,5,5,5,2,2,3,2,2,4,1,1,2,2,3,4,5,2,3,5,3,4,4,5,4,5,1,3,1,3,3,2,1,4,5,1,3,4,2,3,2,5,2,2,3,5,5,5,5,2,5,4,4,5,2,1,2,5,1,5,5,3,5,1,3,4,5,5,1,5,3,2,4,1,5,5,1,2,3,2,1,1,3,2,4,3,2,5,2,2,3,4,5,3,2,1,5,3,5,2,5,5,2,5,3,1,3,4,4,5,2,1,3,2,4,3,1,1,3,1,3,4,1,3,5,3,4,3,3,1,1,4,5,1,4,1,4,5,3,3,1,4,4,5,5,1,4,2,5,5,2,5,3,5,5,4,5,1,3,5,5,5,5,2,3,3,1,3,2,4,2,1,5,5,2,1,4,3,2,5,3,5,3,1,2,5,2,2,4,3,3,3,2,4,2,3,3,5,4,3,2,3,3,2,1,2,4,1,2,2,1,2,1,4,1,5,4,3,5,1,4,4,5,2,5,3,4,4,2,5,4,5,3,3,3,4,3,1,5,5,5,1,4,3,1,2,1,1,3,3,5,4,2,4,2,2,2,2,3,4,3,3,5,3,1,4,5,1,5,5,3,5,1,4,2,2,2,1,4,5,2,3,3,2,2,1,2,1,5,1,2,1,3,5,3,4,4,5,2,4,4,5,5,5,5,4,3,1,3,5,4,5,1,3,4,5,5,5,2,1,3,5,3,2,4,4,5,3,2,3,3,1,4,1,2,5,5,1,5,5,1,5,1,1,1,5,3,2,5,2,3,5,5,2,2,1,1,5,3,3,5,4,5,4,4,5,3,1,3,1,5,3,1,5,2,5,4,5,5,4,5,4,1,4,2,1,3,4,3,1,1,4,3,4,1,1,2,5,5,3,5,3,3,5,4,5,2,1,4,1,1,1,4,4,3,3,1,4,1,1,3,2,5,1,3,1,1,1,3,4,5,5,2,3,3,2,3,4,2,2,4,4,1,5,2,3,5,1,5,2,5,2,5,2,5,4,4,1,3,2,2,1,4,1,1,3,3,4,2,1,5,5,3,2,4,3,2,4,2,1,3,5,3,3,1,5,3,5,5,1,1,5,4,4,1,4,2,4,5,2,2,2,3,5,2,3,2,1,3,5,2,1,1,3,4,2,3,5,3,3,4,2,3,1,1,1,2,2,2,5,5,2,2,4,4,5,3,5,4,3,5,5,3,5,4,1,3,3,1,5,2,3,5,2,5,4,1,3,1,4,4,4,4,3,4,5,5,5,4,1,2,5,4,1,2,3,4,5,1,5,5,4,2,3,5,3,1,4,3,3,5,4,3,1,4,4,2,1,2,4,2,4,3,4,3,3,3,5,5,4,2,1,4,4,5,2,1,5,5,2,3,2,2,4,3,2,5,1,4,3,1,3,5,2,5,4,3,5,4,3,4,4,1,2,3,5,1,5,5,3,3,2,3,2,3,4,2,3,5,1,4,1,2,2,2,1,5,3,3,3,2,1,4,2,2,1,5,3,4,1,2,1,5,1,1,3,4,5,3,1,5,4,1,1,1,3,5,2,4,5,3,2,3,3,5,4,2,2,5,1,4,4,4,2,1,3,3,3,3,1,1,3,3,5,3,2,5,1,2,1,5,4,2,3,3,3,1,1,4,1,3,1,5,3,2,3,1,2,4,5,1,4,2,2,1,5,4,3,1,1,5,5,2,5,3,1,1,5,2,1,5,4,3,3,4,2,2,5,5,3,1,3,1,1,2,3,5,2,5,5,4,3,4,5,1,5,1,1,5,5,5,2,5,1,5,5,5,5,1,5,4,3,5,3,5,4,3,2,3,3,3,5,2,4,4,4,5,3,5,1,2,2,1,2,2,2,5,4,3,5,2,5,5,2,1,3,1,2,3,2,1,1,2,1,1,3,5,5,4,4,3,1,5,5,1,3,3,2,2,3,2,5,4,5,4,5,4,2,5,5,1,4,5,5,3,1,1,2,1,2,3,1,3,1,1,4,4,1,2,5,2,4,3,1,5,3,3,5,4,1,4,4,5,5,2,3,2,3,1,2,1,2,3,3,5,5,3,3,3,4,2,2,5,4,4,2,2,4,4,1,3,4,2,1,4,2,4,3,2,1,1,2,3,5,3,3,4,5,2,1,1,2,1,1,4,2,1,2,4,4,2,2,1,4,2,5,1,1,1,4,3,4,5,4,4,1,2,4,3,4,2,1,4,2,5,4,5,1,3,4,3,5,1,3,5,3,1,4,3,1,5,3,4,2,2,4,1,2,4,5,5,1,1,1,1,5,1,5,4,4,5,5,5,1,2,3,2,2,1,3,2,5,3,3,1,2,2,2,5,2,1,3,4,1,4,2,4,1,5,1,3,2,4,2,1,4,4,4,1,3,4,3,1,1,3,2,2,2,2,2,3,1,4,5,5,5,2,2,1,1,2,2,1,4,3,4,4,2,2,1,5,2,2,3,1,5,5,5,5,3,2,4,4,1,4,4,5,3,4,4,4,5,4,3,5,5,1,3,4,3,2,4,3,5,2,1,5,4,2,4,1,2,5,5,1,2,4,5,2,2,1,4,1,4,2,2,2,1,3,4,2,4,2,2,3,1,2,5,4,5,3,3,2,1,5,2,5,3,1,5,3,1,5,2,4,1,3,3,5,3,2,5,2,1,3,1,2,5,5,1,2,3,2,3,1,2,3,1,2,2,4,2,2,5,4,3,5,1,5,3,5,5,4,3,5,1,1,1,4,3,3,4,1,4,2,3,3,1,3,1,4,3,2,3,2,3,2,1,1,5,4,2,5,3,2,5,1,2,5,4,2,2,1,1,5,3,3,5,3,1,3,4,5,4,2,4,5,5,5,5,4,2,5,3,5,4,5,4,4,2,4,2,4,5,1,5,1,3,2,1,5,3,3,4,4,5,5,3,1,5,1,4,1,1,4,3,3,5,4,2,1,1,1,4,3,1,1,3,1,1,1,2,5,4,2,5,1,1,5,5,5,2,1,1,5,4,2,3,4,1,5,4,4,1,3,3,1,4,5,3,5,1,2,4,3,3,5,5,2,4,2,1,3,2,3,3,3,1,4,1,3,5,5,2,5,4,1,2,4,1,5,1,2,5,2,5,1,4,1,2,4,1,2,3,1,3,4,3,5,1,4,4,2,4,5,3,1,2,2,5,4,4,5,5,5,3,4,5,2,1,5,1,3,2,4,2,4,3,5,5,4,5,2,2,3,1,2,5,3,2,2,1,1,1,5,5,3,4,2,5,1,5,1,1,4,4,2,2,2,1,2,2,4,5,4,1,5,5,4,1,1,3,4,5,5,4,3,2,4,5,4,5,3,2,5,4,3,5,1,4,5,2,4,2,4,2,2,1,1,4,1,2,1,2,5,3,5,4,2,1,2,2,2,2,4,3,4,5,1,3,1,3,5,3,3,2,2,4,3,5,4,3,2,1,1,5,4,1,1,4,2,2,4,5,3,1,2,2,4,1,5,5,3,3,4,3,5,3,2,5,3,3,1,1,1,2,3,3,2,3,1,5,3,2,1,4,5,3,4,2,4,5,1,3,5,3,5,2,1,2,1,3,5,2,1,5,1,5,4,3,1,2,5,2,4,1,4,3,5,2,2,1,3,3,5,3,5,1,4,5,1,2,5,2,4,5,1,2,4,1,5,1,5,4,2,5,1,1,3,2,1,5,4,4,1,1,3,1,3,4,1,5,3,5,5,4,4,3,5,3,4,2,4,3,2,5,3,4,4,3,2,2,1,5,2,3,4,5,4,4,5,1,5,5,1,5,1,2,3,3,3,3,3,1,4,3,5,4,1,4,1,3,4,1,3,3,4,3,3,5,2,3,4,4,2,3,1,2,5,4,4,2,2,4,4,1,3,2,1,2,4,4,2,3,2,1,1,3,2,2,1,3,4,4,4,3,3,4,2,1,4,4,2,1,1,2,4,3,4,3,2,3,1,2,5,4,5,3,3,3,1,1,1,1,5,2,5,3,5,4,4,5,3,4,5,5,4,3,4,2,3,2,2,3,2,3,4,3,1,5,5,3,3,4,1,1,1,4,1,3,4,3,4,2,2,2,3,2,2,2,1,3,4,1,1,4,5,4,5,1,1,1,1,3,3,5,5,3,5,4,5,1,1,1,5,3,2,3,4,5,4,5,3,5,2,1,1,3,3,4,2,2,3,2,4,1,4,1,3,5,2,4,4,3,4,1,2,1,4,5,1,5,4,4,3,2,4,4,5,4,5,4,2,1,1,1,4,1,1,4,2,5,3,4,4,4,1,2,3,1,1,3,4,5,1,2,1,5,4,1,2,3,5,5,5,4,2,1,5,2,3,3,5,5,2,3,5,5,2,5,3,4,2,1,2,5,5,5,2,2,5,1,5,2,2,5,4,2,3,1,1,5,3,2,3,4,2,1,2,4,1,1,2,3,1,1,5,1,2,5,2,2,1,4,5,5,1,1,4,2,4,1,4,3,1,3,3,1,4,2,4,1,4,1,4,5,3,1,3,5,1,4,5,2,2,3,3,1,5,5,3,3,1,1,3,3,3,2,3,5,1,3,4,2,4,1,3,2,1,2,1,5,1,1,4,2,3,4,4,4,4,3,3,5,5,3,2,4,2,2,1,3,4,5,3,2,3,1,1,3,5,1,4,4,5,2,1,3,1,4,3,5,1,1,2,1,2,2,4,3,2,4,4,4,5,4,5,5,1,4,4,1,4,5,4,5,2,5,5,1,1,5,2,3,2,4,3,4,3,4,4,3,1,2,1,4,1,1,1,5,3,3,1,1,4,1,2,2,5,1,5,3,2,5,3,3,3,5,1,5,1,3,1,3,1,1,4,1,4,2,5,1,2,2,5,3,2,3,5,4,3,2,4,5,3,2,4,3,5,3,2,4,5,1,3,3,5,4,1,1,4,4,1,5,4,4,3,3,5,4,2,2,4,1,5,3,4,2,4,3,1,5,3,4,4,2,4,3,3,2,2,2,2,2,3,2,5,2,3,4,1,4,1,2,2,3,3,4,1,2,1,2,2,1,2,4,3,5,5,3,4,5,3,3,2,3,1,4,2,1,2,2,2,5,2,1,3,5,4,2,1,3,3,4,2,2,2,2,5,3,5,4,2,1,4,1,5,4,5,1,5,4,3,5,3,5,1,2,1,5,1,1,2,5,1,3,2,3,3,4,1,5,3,1,1,2,1,4,1,1,1,4,4,4,4,3,5,5,2,5,1,4,4,5,4,3,3,2,3,4,4,1,2,1,4,1,3,4,2,4,1,5,3,4,5,5,2,1,5,1,4,4,4,5,2,4,2,4,5,1,4,1,4,4,5,3,3,5,2,5,3,2,5,2,3,3,1,2,5,1,1,2,5,4,4,5,1,5,4,5,3,5,1,4,3,5,1,3,4,2,5,2,1,2,1,3,2,5,1,4,5,4,5,5,2,5,2,1,1,2,3,4,5,3,3,5,1,2,5,5,5,3,4,3,2,4,4,1,1,1,1,2,2,3,2,3,2,1,5,1,2,5,2,2,1,2,4,4,1,1,3,4,2,2,3,4,2,2,5,5,1,2,1,2,5,3,4,2,1,3,1,1,5,2,1,2,3,4,2,4,4,3,4,2,3,1,1,1,2,5,1,3,4,3,5,2,5,5,5,4,4,4,2,5,5,4,1,5,5,4,4,2,4,1,2,3,4,1,3,3,1,5,2,4,2,3,3,5,3,4,1,5,4,1,4,2,4,1,3,1,4,4,2,3,5,5,2,3,4,2,3,4,3,5,5,2,5,5,5,3,4,5,2,5,1,5,5,3,3,1,1,5,4,2,3,5,4,2,1,3,4,2,4,2,5,5,3,5,5,1,5,4,3,5,4,3,1,2,4,4,5,5,5,3,2,5,1,2,1,2,2,2,5,1,4,3,4,3,4,5,4,1,2,2,5,5,1,2,5,4,3,1,4,5,2,3,3,1,2,5,3,1,2,5,4,2,4,1,1,5,3,2,1,5,1,1,5,2,2,2,1,5,1,2,2,5,5,5,5,1,4,1,2,1,5,5,2,4,5,4,4,2,4,5,2,3,1,5,1,2,2,1,1,1,4,2,3,1,2,3,3,4,5,3,3,1,4,5,3,2,4,4,5,2,4,5,3,5,1,2,1,3,4,1,4,1,1,5,2,1,2,3,3,4,2,3,1,2,3,4,2,5,4,4,3,3,4,2,2,1,1,2,5,3,2,5,1,1,5,4,5,2,5,3,1,1,4,4,3,3,4,3,1,5,4,4,1,1,1,3,1,5,1,4,4,4,3,1,3,2,4,3,4,2,1,3,4,3,1,4,4,4,3,5,5,4,1,1,2,3,4,1,3,2,5,2,4,1,3,2,1,1,5,3,5,1,2,5,4,3,3,3,5,5,4,3,4,4,3,2,1,1,3,3,3,3,1,3,4,2,1,5,2,4,4,2,4,3,3,4,5,3,2,4,4,5,4,3,5,3,4,4,2,5,5,1,3,1,5,4,2,1,5,2,4,1,3,2,2,1,2,3,4,2,4,1,4,3,2,1,2,2,5,3,3,4,5,3,2,4,1,3,2,2,3,2,4,2,4,2,4,5,1,1,1,5,3,4,3,5,3,1,5,5,2,2,1,5,4,3,5,1,4,2,2,5,3,5,1,1,4,2,3,1,1,5,1,3,4,2,5,3,4,2,4,2,4,5,2,3,1,1,1,5,2,1,1,1,4,4,2,1,3,1,4,5,3,2,4,1,3,5,5,1,5,2,5,2,3,4,4,3,4,1,4,2,4,4,2,1,1,4,3,3,2,4,4,3,4,1,3,2,5,3,3,4,3,4,5,5,4,4,1,4,1,3,1,5,1,3,3,1,3,2,4,1,5,5,4,2,2,5,4,2,4,4,2,1,2,2,3,5,1,1,4,1,5,3,5,2,3,4,1,1,1,1,1,4,4,5,3,3,4,5,5,5,4,4,5,1,4,2,1,1,5,4,2,4,4,3,5,5,4,4,3,1,3,4,3,2,2,5,5,1,5,2,5,3,2,3,5,3,3,4,4,5,3,4,5,1,1,2,2,4,5,1,4,2,3,2,1,3,4,5,5,4,5,4,2,2,1,3,1,3,2,2,5,4,3,1,5,4,3,4,1,1,5,5,4,5,3,2,4,4,1,1,4,1,4,3,1,1,4,3,2,1,5,4,1,2,2,3,1,4,3,4,2,4,2,2,1,2,4,3,1,3,4,1,2,3,1,5,1,1,5,1,3,1,1,5,2,1,3,4,4,3,1,3,1,4,5,2,4,5,4,2,4,2,4,5,3,2,4,3,3,3,3,2,3,3,4,4,3,1,2,5,5,3,1,5,2,2,1,3,3,4,1,5,2,3,2,5,5,4,4,4,5,3,4,5,2,1,3,1,4,3,3,3,4,3,4,1,2,1,1,2,2,3,4,1,3,2,5,3,4,5,3,5,3,2,1,5,1,3,5,4,3,4,3,1,1,3,2,2,3,4,2,1,5,1,4,3,5,4,2,2,3,3,4,2,3,1,5,3,2,3,4,2,4,4,3,3,4,3,2,2,4,5,3,4,1,2,1,5,5,4,5,1,3,3,3,4,4,3,3,3,4,5,3,5,5,4,1,3,4,1,5,2,1,3,4,3,5,1,4,3,3,4,1,3,2,4,5,4,1,2,3,2,4,2,2,4,5,4,3,3,3,1,2,4,4,1,2,2,1,2,1,4,4,3,3,4,1,4,2,2,5,5,4,3,4,1,5,2,3,2,2,3,3,2,4,4,3,1,4,5,1,4,3,3,5,2,4,3,1,3,3,4,4,2,5,3,2,2,1,3,2,5,1,3,4,5,5,1,1,5,3,2,1,5,5,1,5,4,5,5,2,2,5,1,1,3,2,5,2,2,3,4,3,3,3,4,2,5,4,2,1,3,3,5,1,5,5,5,4,2,4,1,4,4,3,3,3,1,3,3,3,5,5,2,2,5,4,3,5,1,3,1,4,1,4,1,2,2,2,5,3,4,4,2,5,1,2,5,3,4,2,3,3,4,2,5,5,5,3,2,2,1,4,3,5,4,1,2,4,5,3,4,5,3,1,1,3,3,4,2,2,1,4,4,3,4,5,4,1,4,2,3,4,3,3,5,1,3,3,3,5,2,5,4,5,2,5,1,5,1,2,5,2,1,4,2,5,4,2,2,4,5,1,5,5,4,5,3,3,4,4,4,4,1,5,3,2,4,4,1,2,2,2,4,5,2,2,2,3,1,5,4,2,3,1,1,3,1,2,3,1,4,2,4,5,3,2,2,2,5,1,1,3,1,4,4,3,2,2,5,2,5,4,2,3,5,2,5,1,4,3,4,2,3,3,3,5,2,4,5,2,3,1,2,3,2,1,5,4,2,5,5,2,3,4,1,2,1,3,5,3,3,1,4,3,2,2,5,4,1,2,5,4,1,1,2,5,2,1,2,2,4,1,3,3,3,3,1,1,2,1,2,5,3,2,2,1,2,2,2,2,4,1,1,1,5,2,1,1,1,5,2,5,1,2,5,3,4,1,3,1,5,5,1,2,2,1,4,5,4,4,4,1,5,3,5,3,4,1,3,3,2,3,1,2,5,2,1,5,5,1,3,1,3,4,5,1,3,3,3,1,3,5,3,3,5,4,1,1,1,4,2,3,5,1,5,1,4,2,2,1,2,5,3,1,4,5,3,1,5,1,5,4,1,4,1,1,5,3,2,3,3,5,5,4,1,4,1,4,5,4,2,3,4,3,4,1,2,5,4,3,5,1,5,2,3,5,4,2,4,4,3,1,1,2,2,3,3,5,4,4,4,5,2,5,3,3,3,4,3,5,3,4,4,3,3,4,1,5,5,1,2,4,4,3,3,1,1,2,4,2,5,1,2,4,3,3,1,4,3,4,2,4,4,4,1,5,1,4,2,4,5,2,2,4,5,1,5,1,3,1,4,5,5,1,2,2,1,2,2,5,5,3,4,4,2,2,2,1,2,2,3,3,1,4,4,3,4,4,2,1,1,3,5,5,5,4,4,2,1,1,1,5,5,5,2,1,4,3,5,2,5,5,1,4,3,4,1,4,5,3,4,1,1,2,4,5,1,2,5,4,1,5,2,1,2,2,1,3,5,2,3,1,5,5,5,4,4,3,1,4,1,1,1,5,5,3,4,2,3,5,5,3,3,5,2,5,4,4,3,5,4,4,1,2,1,1,1,3,3,1,5,4,4,5,1,1,3,5,1,5,2,5,5,4,3,4,3,4,2,5,3,1,3,5,3,4,1,1,1,2,4,3,5,1,4,3,1,4,1,3,5,3,4,3,2,4,5,3,5,1,5,1,2,4,4,3,2,1,2,2,3,1,1,5,4,3,3,2,4,3,5,4,5,1,5,2,2,5,5,4,4,4,1,3,1,1,1,1,1,2,3,1,3,4,1,1,3,1,4,2,1,3,1,1,3,4,4,1,4,5,2,2,2,2,4,1,4,2,5,3,1,5,3,4,5,3,4,3,1,3,4,5,5,1,3,3,2,1,5,2,2,4,4,1,3,1,5,3,5,2,4,3,1,3,5,2,4,3,2,4,5,2,5,3,3,2,1,2,5,4,2,1,3,4,1,4,2,2,3,2,5,2,3,2,2,3,2,1,3,4,4,3,2,3,4,4,5,2,1,3,1,5,2,3,4,1,1,5,3,3,3,3,2,3,3,5,4,5,1,3,1,2,2,2,5,1,5,5,2,2,2,4,4,4,3,5,5,1,4,1,3,4,1,1,4,1,4,4,1,4,1,3,5,3,3,2,4,3,1,4,4,3,4,3,5,4,4,3,3,4,1,1,4,5,1,2,2,4,2,4,1,2,2,4,2,5,5,4,2,2,3,3,4,2,5,4,2,5,2,4,2,3,4,2,4,3,3,3,1,5,4,2,4,5,5,3,3,4,1,4,5,2,4,5,4,4,5,5,4,2,4,4,5,5,3,3,2,2,5,4,3,4,1,2,4,4,1,3,5,1,1,2,4,3,1,1,2,5,4,3,2,1,1,3,5,5,2,1,5,4,2,5,4,3,4,3,3,5,1,3,3,5,2,4,3,1,2,2,4,2,5,5,1,2,3,2,5,5,5,3,3,4,4,1,4,5,4,1,5,3,2,5,5,5,2,2,3,2,2,5,3,5,2,3,2,2,2,1,3,3,3,1,4,2,2,3,5,3,3,4,5,1,1,2,3,3,5,5,5,3,1,4,3,5,2,4,5,2,3,3,3,5,3,4,5,3,1,5,2,1,1,5,5,4,1,3,4,5,2,4,5,5,4,5,5,2,4,5,5,2,1,4,5,5,2,3,5,1,2,5,4,3,2,2,2,5,2,3,4,2,5,1,1,5,4,2,3,1,2,4,1,5,5,5,4,4,1,5,4,3,5,1,3,5,4,4,2,5,4,3,3,5,3,3,4,1,3,5,2,3,5,4,4,3,1,3,3,3,2,3,2,5,3,3,1,2,3,1,1,4,4,1,3,3,1,2,3,1,1,5,1,1,3,4,4,2,5,1,1,2,2,5,2,4,1,2,5,1,4,4,3,4,1,4,3,3,5,4,4,2,3,3,5,5,4,4,3,5,4,3,1,2,5,1,3,4,5,5,3,1,3,5,5,1,5,2,4,2,4,1,2,3,1,1,3,1,3,4,2,2,3,2,4,4,5,4,3,4,3,2,1,2,5,1,5,5,3,2,2,1,4,1,3,1,3,3,3,3,4,4,3,1,3,3,2,4,5,1,3,5,3,2,5,5,1,4,3,4,3,4,3,2,3,2,3,2,3,1,1,1,4,4,2,4,3,4,5,4,1,2,3,3,4,3,3,1,4,5,4,2,3,3,2,2,3,4,5,2,1,3,3,1,3,3,2,4,4,2,3,2,3,4,1,2,5,1,4,1,1,2,5,5,5,4,5,3,4,5,2,3,4,2,1,1,5,1,5,4,5,1,3,1,1,3,1,4,2,4,3,1,4,3,1,4,4,3,5,5,3,3,3,5,5,4,1,1,3,2,3,1,5,4,2,1,2,2,5,4,2,5,3,5,4,5,2,1,3,1,5,4,5,2,3,2,1,1,4,1,3,2,1,2,2,2,5,3,4,2,4,2,3,1,2,3,2,2,3,5,1,3,4,3,3,2,1,3,5,2,1,4,2,1,5,2,3,1,5,4,4,3,1,4,4,3,5,4,1,4,4,5,4,4,1,4,1,2,3,5,5,5,2,4,2,4,5,5,5,4,4,5,4,2,5,1,5,2,1,3,1,1,3,1,3,1,3,3,1,3,4,4,3,4,4,4,4,5,1,2,3,5,2,2,2,3,1,4,2,3,1,3,5,5,1,5,3,3,3,2,4,5,3,1,1,3,5,2,4,1,5,5,4,5,4,5,3,3,1,4,5,1,2,5,3,5,5,4,2,1,1,3,4,4,1,2,4,5,4,3,1,2,5,5,3,1,2,2,2,2,5,5,3,2,4,4,2,3,3,2,2,5,4,5,1,3,3,2,1,2,4,3,4,1,3,5,3,5,1,2,5,4,2,1,1,4,2,2,4,1,3,4,5,3,4,2,4,1,3,3,2,1,5,2,2,2,2,1,1,1,1,2,2,1,2,3,5,1,3,5,2,4,4,2,2,5,3,2,4,2,4,3,2,1,5,1,2,3,4,4,3,5,4,4,2,3,2,5,5,3,1,5,3,1,3,3,2,4,3,5,5,4,2,3,1,4,3,5,5,3,1,2,2,2,3,1,1,3,3,2,3,3,1,2,3,1,2,1,4,4,1,4,2,2,3,5,5,5,2,2,1,2,3,2,5,2,2,2,5,1,4,5,3,1,1,1,5,5,2,5,4,2,2,2,4,3,4,1,1,2,2,5,3,3,1,4,1,4,2,1,2,5,1,1,2,1,3,1,3,3,1,5,3,2,2,5,5,3,5,3,1,3,1,2,2,5,4,4,5,2,4,5,5,4,4,2,4,5,1,5,1,4,2,2,1,3,3,2,2,4,3,3,1,4,4,1,2,2,1,1,4,1,1,1,1,3,3,5,1,3,2,3,3,2,1,4,1,3,4,1,4,1,2,2,4,5,1,2,2,3,4,3,4,2,3,1,2,3,1,2,4,2,2,3,3,3,4,4,5,5,2,1,3,3,3,3,1,2,1,5,1,4,3,4,1,3,4,4,1,3,2,4,4,2,5,4,1,4,4,2,5,2,4,3,1,4,4,2,5,4,2,5,1,3,1,5,1,4,4,4,3,1,5,5,5,1,3,5,1,4,5,5,1,3,3,3,1,5,2,2,2,4,5,3,1,3,2,2,5,2,3,3,3,4,5,1,3,2,2,1,2,4,3,5,2,4,5,4,5,4,5,4,1,2,4,5,4,2,2,1,2,2,2,5,4,5,5,5,2,2,2,1,3,2,4,5,4,5,5,2,4,5,3,2,1,4,3,2,2,4,4,3,1,4,5,5,1,5,5,2,2,4,1,4,2,5,3,2,1,5,1,5,4,3,5,3,1,4,5,4,3,1,3,4,5,1,4,1,1,4,4,4,2,2,4,3,2,4,3,2,3,1,3,1,1,2,4,1,5,2,2,3,3,5,2,1,1,1,1,3,5,3,3,1,1,2,3,3,5,2,4,2,1,5,4,2,2,1,5,5,5,3,3,2,5,2,4,3,2,2,4,2,3,3,2,1,2,4,5,2,4,4,4,4,3,5,4,1,1,5,2,2,1,2,4,5,2,4,4,5,5,3,2,5,3,4,2,3,4,2,2,3,3,1,3,2,3,1,4,3,2,1,3,4,5,4,4,3,4,5,1,4,4,3,2,4,3,2,2,3,4,3,2,1,3,5,4,1,3,5,3,3,2,3,4,5,4,3,1,3,1,3,1,5,2,4,3,4,5,1,5,5,2,5,3,4,1,3,2,5,3,2,4,4,5,5,1,5,2,5,1,5,4,5,4,1,1,2,3,4,1,2,4,2,5,4,1,1,1,1,4,5,1,1,3,2,4,1,2,5,1,4,3,2,5,5,3,3,4,4,5,4,2,3,4,2,4,5,2,4,4,4,4,5,3,4,4,2,2,3,1,1,3,1,4,3,4,2,2,5,3,5,5,3,1,4,5,2,2,4,5,1,3,4,2,3,2,5,1,2,1,4,2,5,3,4,3,2,2,1,2,2,4,1,5,4,4,3,2,2,5,5,5,5,1,3,2,3,1,2,5,5,4,5,1,2,5,5,4,4,5,4,5,4,5,4,2,1,2,1,1,5,4,4,5,4,4,2,4,4,2,5,2,5,2,1,4,2,5,5,4,3,2,1,5,2,2,3,1,3,3,5,2,5,2,4,3,1,3,1,5,3,2,5,1,4,1,3,4,4,2,3,3,1,2,1,1,5,3,1,2,4,5,2,3,5,5,2,5,5,4,3,2,1,3,1,1,5,1,4,5,1,1,4,1,5,5,1,3,2,1,1,5,2,3,2,4,1,2,5,2,3,3,5,2,1,3,5,2,2,5,2,3,2,3,3,5,1,1,1,2,1,1,3,3,1,5,3,4,2,5,3,1,1,1,4,1,3,1,3,4,3,2,4,4,3,3,3,1,1,4,1,2,3,2,1,5,2,5,2,3,5,1,5,4,4,3,1,2,4,2,2,1,3,1,3,2,2,4,4,1,3,2,1,1,4,2,2,1,5,2,1,1,2,4,5,2,5,3,4,2,3,2,5,4,3,3,2,2,1,5,4,2,2,3,3,3,3,4,2,1,4,4,1,4,4,4,4,1,1,1,3,4,3,2,2,4,2,4,1,1,2,4,4,2,4,2,4,4,2,1,4,1,4,1,1,1,2,2,4,3,2,4,5,2,1,3,1,5,4,1,2,3,2,2,3,2,3,3,3,3,2,3,1,4,3,1,5,1,1,2,3,3,5,5,2,1,3,2,3,3,1,4,2,4,2,1,2,5,4,4,4,4,3,3,5,4,1,2,1,1,5,4,5,5,3,5,2,3,3,3,5,3,4,4,2,1,5,5,5,5,2,1,3,5,4,1,5,1,4,1,4,1,5,3,2,2,5,2,5,4,3,4,2,1,5,1,2,2,1,2,3,3,4,4,1,2,4,5,4,4,4,3,2,5,5,3,4,5,2,2,1,1,4,2,2,4,4,2,3,3,1,4,1,5,1,1,1,1,2,3,1,5,5,5,4,3,4,2,2,5,3,2,5,5,5,5,4,1,1,3,2,1,2,5,2,3,4,3,4,1,4,3,2,4,3,5,1,5,2,1,2,1,5,2,4,1,1,1,3,5,1,2,2,3,5,5,3,2,5,5,1,3,4,2,2,5,4,3,4,4,5,4,4,3,5,2,1,1,2,5,5,5,5,2,2,5,3,3,3,5,5,2,3,2,1,1,5,3,2,4,4,3,5,1,1,1,2,3,5,1,5,2,2,4,1,3,4,5,3,1,1,4,3,4,1,1,4,1,5,2,3,5,4,4,1,2,2,3,4,3,2,3,5,4,2,4,3,5,4,1,4,5,4,3,1,2,1,4,5,1,2,1,5,5,3,1,1,4,3,4,1,3,2,2,5,5,2,1,3,2,4,3,5,1,3,1,1,1,5,5,4,3,5,5,5,2,5,4,2,1,3,2,2,1,3,5,1,4,3,3,4,4,1,2,4,3,5,1,5,5,3,1,1,1,4,2,4,1,3,5,5,3,1,4,3,5,2,4,4,3,2,2,3,2,5,5,4,2,3,1,5,5,3,2,4,2,5,4,3,3,2,4,5,4,3,2,3,2,4,5,1,1,4,5,5,1,4,1,2,3,4,3,4,2,3,5,2,5,3,1,4,3,5,1,1,5,3,5,1,1,1,5,4,3,4,1,3,1,3,3,4,1,1,1,4,1,3,2,4,4,4,5,1,5,4,4,2,1,1,3,4,1,5,2,4,1,3,2,3,2,3,2,2,2,3,5,5,4,3,5,2,2,4,2,1,2,3,5,2,1,1,2,2,1,5,1,5,5,5,2,1,4,2,5,1,3,3,4,3,1,5,2,2,4,3,4,1,3,1,4,3,1,3,1,3,3,5,3,1,3,2,2,2,4,4,4,2,2,1,4,4,2,5,4,1,4,4,4,1,3,1,5,2,5,2,1,4,5,3,2,2,5,3,4,4,2,2,5,3,2,3,2,2,3,4,4,2,1,5,4,2,2,1,3,1,4,3,4,3,5,4,5,3,5,1,2,5,1,5,3,4,2,3,1,3,4,4,1,3,5,4,5,1,2,2,1,2,4,3,4,2,3,1,3,1,4,5,5,4,4,3,5,3,1,3,4,3,4,2,4,5,4,2,3,2,4,1,4,1,4,3,3,4,2,1,2,2,1,4,4,3,3,1,3,3,1,1,1,1,2,5,2,3,5,4,5,4,3,2,2,3,2,4,5,4,2,5,3,5,3,2,3,1,2,1,3,2,3,2,3,2,3,3,2,2,4,2,5,1,1,3,4,1,2,1,5,4,5,5,4,4,5,2,5,2,4,3,5,3,3,3,5,5,5,3,4,4,2,4,4,4,3,2,3,5,3,4,1,3,2,3,5,4,1,1,4,1,5,2,2,5,5,4,1,1,5,5,4,1,1,5,5,3,1,3,4,2,3,1,5,4,5,4,1,5,2,3,5,2,3,1,2,3,2,5,3,3,5,4,3,4,1,4,5,1,3,4,2,5,4,3,1,4,1,5,1,1,2,1,2,1,1,5,5,3,3,3,2,5,3,4,3,4,5,4,2,2,5,5,1,4,5,4,1,1,1,1,5,3,3,3,5,1,2,1,5,4,1,4,4,4,5,5,2,4,3,2,1,5,2,4,5,5,1,5,2,1,2,1,1,2,1,4,4,3,5,1,1,2,5,5,1,4,2,1,5,1,1,3,4,3,3,4,1,4,3,2,4,2,3,4,4,4,5,5,3,5,1,2,4,3,2,1,4,1,1,5,3,1,5,4,1,4,1,1,4,1,2,1,2,1,1,1,1,3,3,4,1,2,5,3,2,5,5,3,3,3,4,2,1,1,4,5,4,3,3,1,5,3,2,4,5,5,3,1,4,5,4,2,1,5,5,3,4,4,2,1,3,5,1,2,3,2,1,4,1,5,5,1,3,5,4,2,3,4,4,3,3,1,1,2,4,4,4,4,1,5,1,4,5,4,3,2,1,1,2,2,4,2,5,4,2,5,2,5,1,3,2,2,3,1,3,5,1,2,5,5,5,2,5,3,4,4,5,5,5,4,3,4,4,2,2,4,5,2,2,1,2,5,5,1,1,4,5,5,3,5,4,5,5,2,5,3,2,3,2,5,2,1,5,2,2,1,5,2,1,1,5,3,2,5,2,3,5,5,2,4,3,4,3,4,4,5,3,3,1,1,3,4,1,1,4,1,3,3,3,4,1,2,2,3,3,5,2,5,4,5,5,4,1,4,5,2,4,4,4,5,3,1,4,5,1,2,2,5,3,4,1,5,3,1,2,2,3,4,2,3,4,1,4,5,2,3,2,1,3,1,3,4,4,2,4,5,3,1,4,3,5,5,4,2,3,4,5,4,1,2,2,5,3,4,2,2,2,2,3,4,2,5,1,1,5,5,1,2,4,2,3,1,2,4,2,5,1,5,2,5,4,3,3,5,4,1,4,2,1,3,1,5,2,2,3,4,3,2,1,1,4,4,1,3,4,4,3,5,5,2,3,2,2,3,2,2,2,4,4,5,4,1,5,4,2,5,3,4,4,4,4,3,1,2,1,2,4,1,3,2,2,4,3,3,3,2,3,3,1,1,1,3,4,1,4,5,2,3,4,2,5,1,3,1,4,2,5,4,5,3,1,4,1,4,5,4,4,3,2,1,5,1,4,2,5,3,5,3,2,4,3,3,2,3,2,3,5,4,4,3,4,3,4,2,1,2,1,3,1,2,5,5,3,3,2,5,2,1,5,1,2,5,4,4,2,3,4,2,2,5,2,3,1,3,4,4,3,5,4,5,3,4,2,3,3,3,1,1,2,2,3,5,5,5,1,3,3,1,1,2,5,4,5,4,1,5,4,3,2,4,4,3,3,5,5,1,5,4,5,5,4,3,1,3,4,5,5,3,3,2,1,5,5,4,4,4,2,2,2,2,3,2,4,2,3,1,1,1,2,2,5,1,4,5,1,3,5,3,4,2,2,3,2,4,3,1,5,4,3,5,2,1,1,4,5,4,1,1,2,3,4,3,2,4,3,4,4,2,4,1,5,2,5,5,1,2,1,4,1,4,1,2,3,4,3,2,2,3,4,1,3,2,5,5,4,2,1,5,2,2,1,4,3,3,3,5,5,4,1,1,1,2,5,5,5,2,1,1,3,2,3,4,3,2,2,1,1,3,3,3,2,2,1,1,4,5,5,1,3,4,5,5,3,5,4,5,2,2,1,5,1,1,5,2,4,2,4,1,2,4,3,5,5,3,4,1,5,4,2,3,2,1,1,2,5,2,5,4,5,2,1,2,3,2,5,4,2,5,1,3,3,1,4,2,4,4,2,5,4,5,2,1,3,5,4,5,4,5,1,5,2,2,1,2,4,1,4,2,1,2,1,5,1,3,5,3,5,5,4,1,5,1,2,1,2,1,1,1,2,5,4,5,2,3,1,5,2,5,3,3,1,2,4,4,3,4,1,3,1,3,3,5,1,4,5,4,2,3,4,1,5,2,5,3,1,2,4,2,1,3,1,2,1,4,1,1,5,5,3,3,5,5,3,5,1,2,2,2,1,4,2,2,1,1,5,1,2,1,1,1,3,3,4,4,4,2,2,1,4,4,1,3,3,2,3,4,4,2,4,4,3,4,4,4,2,5,5,3,1,5,4,5,5,2,4,2,5,2,4,3,2,1,4,1,2,3,5,1,1,5,4,2,4,1,2,3,1,5,1,5,2,4,1,2,5,3,4,1,4,4,1,2,4,3,4,5,4,1,1,3,3,5,3,3,5,1,5,3,5,4,2,1,2,1,1,2,3,5,4,3,5,4,1,1,2,4,1,2,1,4,2,3,5,3,1,1,5,1,3,1,3,5,4,4,1,5,1,3,5,2,4,1,1,4,2,3,4,4,5,4,4,4,3,2,4,3,5,1,1,2,4,1,2,1,1,2,3,5,3,4,3,3,5,2,2,4,4,4,3,2,2,3,3,3,2,5,5,1,2,4,4,1,4,5,3,3,3,1,3,2,1,1,3,3,4,3,5,1,4,4,4,3,3,2,4,5,1,3,4,1,1,3,1,5,1,3,1,1,3,1,4,5,5,5,2,3,5,5,1,3,5,3,2,1,1,2,4,4,5,2,3,5,1,4,3,2,1,1,1,4,3,1,1,5,3,4,5,2,3,2,2,1,3,4,5,3,5,5,4,2,5,5,1,1,5,5,5,2,1,5,5,1,1,3,1,4,4,2,4,4,2,5,4,1,5,2,3,1,1,1,1,3,4,4,5,5,2,5,1,2,5,5,5,4,1,1,4,2,3,4,3,4,2,5,5,1,3,1,1,2,1,4,2,5,2,4,5,4,4,3,4,4,3,5,5,1,1,2,3,4,2,5,4,2,5,5,2,2,2,4,2,4,1,3,5,5,5,1,1,2,4,2,1,1,5,3,4,1,1,5,4,2,4,4,4,4,4,2,3,3,2,1,3,4,2,4,1,2,5,4,2,2,5,2,4,5,1,3,1,4,4,3,3,3,3,5,2,2,1,2,1,4,5,2,4,1,2,4,4,1,1,1,2,2,3,4,2,4,4,2,3,1,4,1,5,1,3,2,1,4,5,3,2,5,3,4,3,3,1,5,4,5,2,5,1,1,2,2,1,1,1,3,1,3,1,2,1,5,1,5,5,3,5,1,2,1,5,1,4,1,3,5,4,2,4,1,2,3,2,4,3,4,2,2,4,4,1,5,2,3,3,2,3,4,3,2,5,5,1,5,2,3,1,5,5,5,1,5,2,1,3,5,1,4,5,4,5,3,5,5,5,3,5,2,5,2,2,4,3,5,4,5,1,5,5,5,5,2,3,3,5,3,4,2,4,4,1,3,4,4,5,5,2,4,1,2,4,4,5,5,2,2,3,4,4,2,5,1,2,4,5,3,5,1,5,5,5,2,5,1,1,5,5,4,4,3,1,1,5,5,2,2,3,5,2,3,5,5,4,1,3,2,3,1,3,1,5,3,2,3,1,1,1,1,2,4,5,1,5,4,3,5,5,1,5,3,2,5,2,1,4,1,2,4,1,3,3,2,3,4,1,1,5,4,1,5,4,5,3,1,2,5,5,5,1,1,1,4,3,1,5,1,1,2,2,4,3,4,3,1,2,4,4,5,1,4,4,2,4,3,4,4,5,3,5,1,3,4,4,3,4,2,4,3,5,5,2,1,1,2,4,5,2,2,1,3,5,4,3,4,4,5,3,1,5,5,2,4,4,5,5,3,2,2,2,4,4,4,3,3,3,4,1,5,2,3,3,5,3,2,2,2,5,5,5,4,2,3,5,2,1,2,5,1,2,1,3,5,2,5,2,4,3,2,2,3,2,4,3,4,4,2,1,3,5,3,5,5,5,1,3,2,1,5,3,3,1,4,3,5,5,1,3,5,2,1,3,4,1,1,1,2,4,4,4,5,1,5,4,5,1,5,4,1,5,4,3,2,2,5,2,2,5,5,2,4,3,1,4,3,3,5,1,3,5,2,2,4,3,2,1,5,3,1,2,2,1,5,2,3,1,5,5,4,1,1,5,4,1,2,3,5,2,4,2,5,1,2,1,4,2,5,2,1,5,4,1,5,4,2,1,4,2,5,3,5,4,5,3,5,1,1,2,5,1,1,5,2,5,1,4,4,1,4,4,3,1,3,5,4,2,1,3,5,1,5,4,3,5,5,5,1,5,1,1,2,4,2,5,1,1,1,2,3,2,1,5,5,1,3,5,2,3,4,1,5,3,1,1,4,2,2,3,2,4,4,4,1,2,5,1,3,1,4,5,3,2,2,5,5,2,2,3,1,3,3,5,4,3,4,3,3,1,4,3,4,4,4,5,5,3,2,1,4,5,3,5,3,2,5,5,5,2,5,2,1,2,2,5,3,1,4,4,4,1,4,1,5,2,2,3,4,3,1,2,4,4,3,2,3,2,1,4,5,2,5,5,3,3,4,2,3,4,2,1,5,5,4,1,1,2,5,1,2,5,3,4,1,1,2,5,5,2,4,5,5,2,5,4,3,4,5,2,5,5,1,5,2,2,3,4,4,4,3,5,3,5,1,4,1,4,3,3,4,2,2,4,2,2,3,2,4,2,5,2,5,2,2,2,4,4,1,4,1,1,2,3,2,5,2,2,1,1,5,3,1,4,2,1,2,3,3,2,3,3,2,5,1,1,3,3,4,1,1,1,5,3,3,3,1,3,2,3,5,1,2,4,4,4,1,3,5,3,5,4,5,2,2,1,4,2,5,4,2,4,3,1,2,1,5,1,1,3,4,5,1,5,4,1,3,3,3,1,4,2,5,4,5,4,5,4,4,2,5,3,5,1,5,2,3,4,4,1,5,2,1,1,2,2,5,3,4,1,1,2,2,3,4,2,4,5,2,1,5,4,3,5,2,1,2,1,2,4,5,5,3,4,3,5,2,4,4,3,4,5,4,3,3,3,3,1,2,5,2,1,5,1,5,4,3,1,3,4,2,2,4,5,2,1,1,1,3,1,3,1,4,3,5,1,4,5,3,3,4,1,2,5,5,2,2,5,3,5,5,2,5,4,4,3,4,2,1,3,1,3,4,1,4,5,5,4,5,1,1,3,4,2,2,3,3,4,3,2,3,4,1,5,5,4,3,5,1,4,3,1,2,3,4,5,5,3,3,2,2,5,4,3,2,3,1,4,1,2,4,1,5,1,4,5,4,3,4,4,2,3,2,3,4,1,1,3,3,3,5,1,5,1,3,1,3,3,4,5,4,2,1,2,3,5,1,2,3,4,3,4,2,4,3,3,4,1,2,1,1,3,5,5,4,2,5,3,1,3,4,4,3,1,5,5,2,5,5,5,5,1,1,2,1,3,4,5,5,2,1,5,1,4,1,1,1,5,4,1,3,1,5,5,5,2,4,5,2,3,3,5,1,3,4,4,4,3,4,1,3,4,2,2,5,2,4,4,2,4,4,2,2,5,3,1,5,5,2,2,4,2,5,3,2,5,4,3,1,4,4,5,2,3,2,2,2,3,4,5,5,2,5,3,5,4,5,5,3,3,3,4,2,3,2,4,4,1,3,4,3,3,3,5,1,1,4,3,4,1,1,5,3,3,2,4,1,2,3,2,2,1,2,1,5,4,5,2,5,3,4,3,3,3,1,4,3,1,3,4,2,5,1,5,4,2,5,2,2,3,3,5,3,4,3,3,3,1,3,1,1,2,4,3,3,2,1,3,1,3,3,3,4,5,4,3,3,2,4,4,5,5,2,4,1,2,4,1,5,5,2,5,1,5,2,2,4,5,3,3,3,5,3,4,4,4,3,5,1,1,5,3,1,4,5,4,2,5,1,4,1,5,3,3,3,2,3,5,4,4,5,3,4,2,3,3,3,4,1,1,1,5,4,3,4,4,3,3,4,2,3,1,5,5,4,2,1,4,1,1,5,1,3,3,2,5,2,4,5,2,5,1,3,3,4,3,4,2,4,5,4,3,4,1,4,5,5,2,3,2,1,1,3,5,5,2,2,4,1,5,3,1,2,4,1,5,3,2,5,1,2,2,4,1,2,5,5,2,2,2,3,3,3,5,3,1,2,5,3,4,3,4,5,3,1,2,1,2,3,5,4,1,3,1,3,2,1,1,5,4,3,3,3,4,4,4,3,2,3,4,5,1,3,1,3,3,3,5,1,2,4,2,2,2,5,2,5,2,5,4,4,5,4,3,4,1,5,1,4,3,2,3,1,5,4,2,1,4,5,4,5,4,1,5,3,2,5,2,2,2,3,4,4,2,5,4,3,2,4,2,4,1,2,5,4,5,2,1,4,5,4,1,1,4,3,2,4,1,3,2,5,5,4,5,4,1,3,3,2,5,1,4,3,5,1,4,3,4,1,4,5,5,2,5,3,5,5,5,3,2,1,4,3,3,5,1,2,5,1,1,1,1,2,5,1,4,5,2,5,5,3,1,3,1,3,2,1,2,4,2,5,2,2,3,4,5,3,4,1,1,5,3,1,5,1,3,3,2,1,2,4,4,1,4,3,5,3,1,4,2,5,4,5,5,2,1,5,4,5,2,5,2,1,1,2,1,5,3,3,4,2,1,5,2,4,5,1,1,4,5,1,4,2,3,4,1,5,2,3,5,3,1,5,5,2,4,3,1,2,4,3,3,1,4,1,1,2,1,5,1,4,4,2,4,2,1,3,5,4,3,5,4,4,4,2,1,4,3,3,5,1,3,2,1,5,2,1,4,3,2,5,4,2,1,3,2,2,3,3,2,3,2,2,4,2,3,2,5,5,4,4,4,4,3,1,1,3,2,1,1,5,5,5,3,2,3,2,3,3,5,1,4,2,5,2,4,1,4,3,2,1,1,1,5,3,3,3,2,2,3,1,2,1,1,5,3,5,1,5,2,3,5,1,1,3,5,5,3,1,3,1,3,1,1,4,1,1,5,2,4,4,4,4,2,4,4,2,5,2,5,5,3,3,2,4,3,2,2,4,3,2,1,2,5,3,2,2,2,3,4,1,1,3,1,5,2,1,1,4,1,1,3,4,5,3,4,2,1,1,3,5,2,5,2,1,1,1,1,3,1,5,3,1,1,5,2,3,1,2,2,3,4,4,2,1,4,4,4,2,4,3,1,4,2,4,1,3,5,3,4,4,4,1,2,3,2,3,3,1,5,1,2,2,2,5,5,3,5,4,5,2,1,3,3,5,5,4,5,2,2,4,1,1,1,1,5,2,3,4,4,2,4,2,5,1,3,2,3,3,2,5,1,3,2,2,2,1,1,2,2,2,3,4,5,2,2,4,5,3,3,1,3,2,3,2,2,3,2,1,3,5,3,1,3,2,3,1,1,1,2,2,4,4,2,1,5,5,5,2,3,3,3,2,4,5,5,2,2,1,4,5,5,2,1,5,5,1,3,1,2,4,3,4,4,4,4,3,1,5,2,5,1,5,3,5,1,4,4,2,3,1,2,1,1,4,4,1,3,5,1,4,4,3,5,4,3,5,1,1,3,5,3,4,2,5,1,5,3,3,1,5,1,5,2,2,3,1,5,2,3,5,4,2,1,2,4,3,2,3,2,3,2,5,3,4,4,1,2,5,1,2,2,2,5,3,3,2,2,1,3,4,1,2,4,2,3,3,4,1,1,2,5,4,1,2,4,3,2,2,3,4,3,2,2,3,3,1,4,5,5,3,4,5,5,1,5,1,3,1,2,2,1,4,2,4,4,4,3,4,2,2,3,2,2,3,3,5,5,5,3,2,2,1,2,3,1,4,2,3,1,1,3,4,2,4,2,5,4,3,2,3,2,1,1,2,5,4,3,4,2,5,2,5,2,3,1,5,1,3,5,2,2,1,1,5,1,5,2,1,1,4,4,1,5,5,1,4,1,1,4,1,2,2,5,4,5,5,2,1,4,4,3,5,3,1,1,3,1,1,4,5,4,1,4,1,1,4,4,2,1,2,4,1,5,3,5,5,5,5,3,1,4,4,4,2,4,1,4,2,3,1,2,1,1,1,3,3,4,5,3,5,3,4,4,4,2,4,4,4,2,1,3,5,2,2,4,5,1,4,4,1,1,5,5,3,3,5,2,5,1,2,2,4,4,2,2,2,3,2,4,1,5,4,2,3,1,5,4,1,2,2,5,1,4,2,4,5,1,3,3,5,4,5,3,5,3,2,2,1,5,3,5,4,2,2,1,2,4,4,2,5,4,4,4,1,4,1,5,1,3,5,3,1,4,4,4,5,4,5,3,1,2,2,4,2,2,3,4,5,3,5,1,4,2,3,5,1,1,3,3,1,1,5,1,2,2,1,3,3,1,5,1,4,5,3,4,1,2,4,3,4,5,3,5,1,3,4,1,2,2,2,3,4,5,1,2,2,3,5,2,4,2,4,2,4,2,1,1,4,5,4,4,3,5,3,5,4,1,1,2,2,4,4,1,4,1,3,3,1,1,3,1,1,3,4,2,4,2,5,1,3,3,2,5,2,5,5,3,4,2,2,3,5,3,1,2,1,4,4,4,3,5,2,1,2,4,2,2,2,4,3,4,3,5,3,3,5,4,5,3,2,3,4,3,2,4,2,4,1,3,3,1,5,5,2,2,3,4,2,3,4,5,5,1,5,4,2,4,1,1,3,2,1,2,2,2,2,2,3,3,2,3,1,3,3,3,1,3,4,3,2,3,4,2,2,1,2,2,5,2,1,2,5,5,4,5,3,1,4,1,5,4,4,4,1,2,5,3,2,4,5,4,1,4,3,5,5,3,1,1,4,2,3,1,3,5,1,2,2,5,2,2,5,5,5,4,4,1,3,5,3,2,5,3,5,4,4,1,3,4,4,1,4,2,3,4,3,1,3,1,1,4,3,5,1,1,5,4,4,4,5,1,5,1,1,1,1,5,1,2,1,5,4,4,2,4,5,1,5,5,3,5,1,2,4,5,1,3,1,2,4,1,5,3,2,1,1,1,1,3,1,1,2,5,3,3,1,3,4,2,5,5,3,3,5,1,1,2,4,5,5,5,3,2,1,3,1,5,3,3,3,3,5,2,3,4,5,2,5,5,4,5,2,2,2,1,1,2,2,3,2,2,2,2,4,1,4,2,1,1,2,5,5,1,5,5,3,5,5,3,3,4,4,2,4,4,2,1,2,5,1,1,2,2,2,4,4,4,1,4,3,4,2,3,2,5,1,4,4,5,3,3,3,1,4,1,5,4,4,2,2,1,3,1,3,2,4,5,2,4,2,3,3,5,3,3,1,4,2,5,3,5,1,4,5,1,3,1,5,5,5,3,2,5,1,5,4,5,2,5,4,5,4,5,2,5,5,2,1,2,4,5,3,1,2,1,2,2,3,2,5,4,1,4,5,2,2,1,5,4,2,4,3,2,2,1,5,1,1,1,5,5,5,5,5,3,3,5,3,4,3,1,5,2,5,5,1,1,3,3,4,5,4,5,3,3,5,1,3,4,3,5,2,5,2,2,5,5,1,1,4,2,4,4,3,1,2,1,2,3,5,5,2,3,4,2,3,4,3,5,1,4,3,4,5,4,2,1,1,2,2,1,3,3,2,5,5,3,4,3,3,4,4,5,5,2,3,4,3,3,4,4,1,3,2,5,5,3,3,3,1,3,2,1,2,1,4,4,3,1,2,2,2,3,1,3,1,5,2,4,3,4,2,5,3,1,4,1,2,3,2,3,1,2,2,1,1,2,4,1,5,2,2,2,4,3,1,2,1,2,1,1,5,4,2,1,2,2,4,5,2,4,2,4,3,2,3,2,1,4,3,1,3,2,4,4,1,3,5,4,3,5,3,2,4,4,2,3,1,1,4,2,2,1,3,5,4,5,5,4,3,2,5,5,3,3,4,5,2,1,4,5,3,3,1,1,4,2,2,1,2,2,2,3,2,1,3,3,3,1,4,4,1,2,3,3,4,5,1,2,2,5,2,3,4,4,3,4,3,4,1,5,2,2,5,2,4,3,2,4,3,4,3,5,1,2,5,3,2,1,1,1,4,4,2,1,5,3,4,1,3,1,5,1,1,1,2,2,4,1,5,1,2,2,2,4,2,5,3,1,2,4,1,4,2,1,4,4,1,4,2,4,2,3,2,1,2,4,3,5,1,5,5,2,2,4,5,2,1,1,4,1,3,2,3,4,5,2,5,5,2,2,1,4,1,1,1,4,3,2,4,1,2,4,1,3,1,2,4,4,5,3,1,4,1,3,3,1,1,2,1,3,4,3,1,2,2,1,4,2,3,3,1,3,5,1,4,3,5,1,1,5,3,1,4,4,2,2,2,1,5,2,1,1,2,1,2,2,2,2,2,4,4,1,5,5,1,3,4,5,1,5,3,3,4,4,1,4,4,5,5,1,3,1,2,4,2,2,5,1,3,2,3,2,5,4,3,1,4,3,3,3,1,4,4,4,5,1,1,4,4,1,2,1,5,1,1,5,1,2,5,5,5,4,5,4,4,5,3,1,4,2,1,1,5,2,2,5,4,3,1,3,2,3,3,1,2,1,3,1,4,5,4,3,5,2,2,5,2,3,1,2,4,2,2,3,1,2,5,1,1,4,3,5,1,2,3,4,4,1,1,1,2,1,5,3,5,1,4,5,1,5,3,1,4,1,5,2,2,1,2,1,3,3,3,3,3,1,2,2,1,2,2,3,3,3,3,4,4,2,5,4,1,4,2,4,2,2,5,4,2,1,2,1,4,1,2,4,2,2,2,4,2,2,5,3,1,5,3,3,4,4,4,5,3,3,3,1,4,4,1,4,2,5,5,1,4,5,5,4,4,2,2,5,1,4,4,5,4,5,4,4,4,4,5,5,4,3,3,4,2,3,1,1,2,1,4,3,5,1,3,1,5,5,4,3,5,4,1,3,1,2,2,1,3,2,2,1,4,4,5,4,2,3,4,5,5,4,1,4,3,1,4,1,4,1,3,2,3,2,3,5,3,1,4,4,4,1,1,2,5,4,4,2,3,2,1,3,4,2,2,1,4,1,3,2,5,2,5,2,5,5,1,2,1,2,3,4,3,4,4,3,2,2,5,1,1,5,2,3,3,2,5,3,5,4,4,3,1,5,2,1,1,1,4,4,3,5,5,2,2,4,1,1,5,5,4,2,1,1,2,2,5,4,5,5,1,5,3,2,3,1,4,5,5,4,3,1,4,3,2,3,5,3,4,1,3,2,4,4,4,2,4,3,3,2,3,2,3,5,1,1,1,4,4,3,1,2,4,3,1,2,4,5,1,5,5,4,5,1,4,4,3,2,4,5,2,2,5,1,1,2,2,3,3,4,5,5,4,5,3,4,3,5,3,1,5,5,4,2,5,4,2,4,4,4,4,3,2,1,4,1,2,1,2,5,4,5,3,3,2,5,1,1,2,4,3,1,1,5,5,3,1,2,1,3,3,3,1,3,5,1,3,1,3,4,5,4,4,4,4,3,5,3,3,3,3,5,2,3,1,4,2,1,5,3,3,5,1,1,3,5,2,3,4,3,1,1,2,3,5,4,1,2,1,4,4,3,3,1,4,5,2,2,2,1,2,2,2,5,4,5,5,4,2,1,1,4,4,5,2,4,5,2,3,4,2,4,2,3,3,2,1,2,5,5,2,1,4,3,4,2,5,3,4,3,2,3,5,1,2,2,2,4,4,1,2,2,2,2,4,3,4,4,5,2,2,1,1,1,2,1,3,3,2,3,2,2,3,5,2,5,2,1,3,1,2,3,5,5,4,5,4,4,2,3,2,4,5,3,5,3,4,2,1,1,4,1,2,1,3,5,1,1,1,4,1,4,3,5,5,2,4,4,3,4,1,5,3,5,4,3,1,3,5,5,3,3,4,5,5,3,1,1,4,3,3,2,5,3,2,1,2,4,4,2,5,1,1,5,1,1,3,3,4,2,4,3,2,3,1,2,4,4,4,4,3,5,3,4,4,1,2,3,3,3,1,1,3,3,4,3,2,4,3,2,5,5,3,3,2,2,3,5,2,5,4,5,5,5,1,1,2,4,5,3,5,3,3,1,2,1,3,5,2,1,3,2,4,2,2,5,1,3,1,1,4,1,2,4,4,2,3,1,5,5,3,1,2,1,4,4,5,2,5,4,5,5,2,1,5,5,5,4,5,2,2,3,4,2,1,2,1,1,3,4,1,2,2,3,3,3,2,5,3,2,2,2,3,2,4,1,4,1,2,4,2,3,5,4,5,2,2,4,2,2,5,5,3,3,2,2,4,3,4,4,4,3,2,1,5,5,4,4,1,3,2,1,3,4,3,5,2,1,1,5,1,2,2,2,4,3,3,2,4,1,4,5,5,5,3,5,4,3,5,1,3,2,5,4,1,3,1,1,5,1,2,5,2,5,3,1,2,4,5,2,5,2,4,5,3,2,4,1,3,1,5,2,1,2,5,2,1,3,2,2,3,2,5,3,1,4,1,1,4,2,5,5,4,4,4,2,3,2,1,3,1,1,2,1,3,5,2,3,4,1,1,1,2,3,1,3,4,4,2,1,5,3,3,2,2,4,3,4,5,4,3,5,1,1,4,1,4,4,2,4,4,4,1,1,3,3,5,3,3,1,1,4,1,2,3,1,3,1,4,3,3,2,4,5,1,5,3,1,4,2,1,1,3,2,3,1,1,1,2,3,3,2,2,5,4,4,1,1,5,2,5,5,5,1,3,5,4,1,5,1,4,1,2,3,3,5,4,1,2,4,2,3,3,3,1,5,5,5,4,5,1,4,1,1,2,4,3,2,3,2,1,1,2,4,3,2,5,4,2,3,4,2,5,4,4,3,4,2,2,3,2,5,3,3,1,1,1,4,5,2,2,4,2,3,1,5,5,4,2,4,3,1,4,4,5,4,2,1,3,2,5,1,2,2,5,5,1,1,2,2,3,1,1,1,2,1,4,1,4,3,5,1,1,2,1,1,3,1,3,3,5,5,3,2,3,3,3,1,3,2,2,1,5,3,3,3,4,2,4,5,5,5,5,5,1,2,1,4,4,4,5,3,1,5,3,1,2,2,3,4,4,1,5,5,4,5,5,1,1,2,5,1,5,4,1,4,3,4,1,1,2,1,2,4,1,4,2,5,5,5,3,2,2,3,2,5,2,3,3,2,1,2,3,5,2,3,3,3,2,2,3,2,5,5,3,5,2,3,4,1,1,1,1,4,2,1,2,2,5,1,3,3,1,5,5,1,3,4,5,4,3,1,5,5,2,2,2,3,4,5,3,5,1,5,1,5,5,1,2,2,4,4,4,2,2,2,2,3,3,5,5,1,3,2,1,4,5,5,3,2,2,3,4,4,3,4,3,4,1,1,5,1,5,3,1,4,5,2,2,5,4,2,2,5,3,3,5,2,2,2,3,5,4,4,4,5,5,4,2,3,3,4,3,4,1,1,2,5,4,1,4,4,2,1,2,2,5,5,3,5,1,1,5,4,2,5,1,1,1,2,3,5,1,4,5,2,1,2,2,3,3,2,1,5,4,1,2,4,3,5,4,2,4,4,3,4,3,5,4,2,5,3,4,5,3,5,5,4,5,2,2,3,1,2,3,5,4,5,3,4,5,1,5,1,4,2,1,4,4,1,4,5,4,1,1,3,2,5,2,2,4,5,4,3,5,2,2,1,5,1,4,3,3,4,2,5,5,5,3,3,2,1,5,3,3,2,4,2,3,3,2,2,5,3,3,5,3,4,5,4,1,4,4,5,2,1,5,2,3,3,5,3,3,1,2,2,2,5,4,4,5,3,3,2,2,4,1,3,5,1,4,1,5,5,5,2,1,1,1,2,5,3,1,4,4,5,4,1,2,3,3,5,2,5,4,2,3,2,2,2,3,4,2,5,4,3,5,4,5,4,2,4,1,2,4,1,1,1,4,4,3,5,3,3,5,2,3,4,1,3,4,5,1,2,5,4,3,2,1,2,4,5,2,2,5,5,2,4,1,5,1,3,2,3,4,4,1,2,2,4,2,4,5,2,2,1,1,3,4,1,1,4,5,1,5,2,1,3,2,5,1,2,2,3,5,1,4,2,5,1,3,2,5,1,2,1,3,1,3,3,3,2,1,4,2,2,1,3,1,3,5,1,4,1,3,1,2,3,3,3,1,5,1,5,3,4,4,1,2,1,4,3,2,2,2,1,4,5,5,5,5,2,2,2,2,4,1,1,1,4,2,5,1,5,2,5,3,2,5,3,2,4,1,5,3,2,4,5,3,1,1,4,3,5,1,1,1,5,5,4,5,3,5,1,3,4,4,3,5,2,3,4,5,3,1,2,3,4,5,2,2,5,3,5,3,5,3,4,2,3,1,1,4,4,5,1,1,2,2,1,1,3,5,1,5,3,1,5,5,3,4,3,1,5,2,4,4,5,3,1,2,5,5,5,5,5,2,5,4,5,4,4,1,4,3,1,2,5,4,4,4,2,3,4,1,2,4,3,4,3,4,4,3,4,5,4,5,2,5,4,5,3,5,1,1,3,5,1,5,3,2,3,1,2,5,5,5,1,2,2,3,5,5,1,5,3,3,1,5,3,3,1,5,3,4,1,3,4,5,4,5,3,2,3,3,4,4,2,5,4,1,3,5,5,2,3,1,1,3,1,4,1,5,2,5,5,3,4,5,2,4,2,4,4,5,2,3,3,3,3,1,2,2,5,4,3,2,3,4,3,1,5,4,2,5,5,5,1,5,2,5,4,4,1,5,3,3,2,3,2,3,2,3,5,3,1,4,2,2,4,4,1,3,2,3,3,3,2,3,5,4,1,3,2,5,1,3,2,1,4,5,3,3,5,2,3,5,4,1,1,5,2,2,3,2,2,2,4,2,5,1,3,1,2,5,4,3,3,4,3,2,1,4,5,2,2,2,3,5,3,2,1,4,3,4,3,4,5,5,1,3,3,3,1,1,1,1,3,1,1,3,2,5,4,5,3,1,3,4,3,4,5,2,4,5,1,3,2,4,3,4,1,5,1,3,1,2,3,1,3,4,3,5,2,2,4,5,3,1,4,3,2,5,2,1,2,2,5,3,3,3,5,3,1,5,2,2,3,4,5,3,5,2,4,4,3,2,1,1,5,5,5,5,3,1,5,5,3,3,5,1,4,4,5,1,4,5,3,5,4,3,2,4,5,5,2,2,3,1,2,2,5,3,4,5,5,5,1,5,1,1,4,2,5,4,5,3,3,3,4,3,5,3,2,1,4,5,5,5,5,3,5,2,1,4,2,2,2,3,5,1,1,5,4,2,1,3,4,4,1,4,4,4,4,4,4,3,2,2,1,2,5,2,5,1,5,2,4,1,5,2,4,5,3,5,1,2,5,4,2,2,5,1,4,2,2,5,3,3,1,4,2,5,2,2,4,5,3,5,2,4,1,3,1,2,1,4,1,2,4,3,1,3,4,3,1,2,3,2,2,4,2,1,3,4,2,5,4,4,5,2,4,1,1,4,2,1,1,5,4,4,3,2,3,1,2,4,2,4,4,5,1,4,2,5,3,1,1,4,5,5,1,1,5,3,3,5,1,2,1,3,2,2,3,3,3,5,5,1,5,5,4,3,5,2,3,1,2,1,5,5,5,1,4,3,2,3,2,5,4,1,3,4,2,1,2,5,2,2,2,2,5,3,4,2,2,5,1,4,5,3,4,3,3,2,2,3,3,1,5,5,5,4,1,5,1,3,4,2,3,3,5,1,2,1,1,1,5,4,5,2,2,1,5,4,2,2,5,5,1,5,1,5,1,1,2,2,1,2,3,2,3,4,3,2,1,1,5,3,1,1,2,4,3,2,1,3,5,1,4,3,1,1,5,2,3,2,2,3,5,1,1,5,5,2,4,2,5,1,2,3,2,4,5,5,1,2,2,1,3,3,5,4,5,5,5,5,2,4,5,5,4,3,1,1,5,1,2,3,4,1,3,2,1,1,5,5,3,2,3,5,3,1,1,1,1,3,4,4,1,2,3,4,3,1,2,5,1,1,2,1,4,1,5,3,1,2,1,3,1,3,1,5,4,1,3,2,4,2,1,5,1,5,5,2,3,3,4,1,3,1,1,1,5,4,4,5,5,3,3,3,5,3,4,5,5,1,4,1,2,5,2,5,2,5,4,3,5,4,4,2,5,3,5,3,4,5,5,3,2,2,5,1,5,2,3,2,1,4,5,1,1,5,3,4,5,5,1,5,3,4,3,3,2,4,4,5,4,1,2,3,5,4,5,5,4,4,5,4,4,2,4,4,2,5,5,3,1,5,2,2,5,3,1,3,1,5,2,4,1,3,5,1,4,5,2,1,3,1,2,3,3,4,5,4,3,3,3,2,5,2,4,5,3,5,1,3,5,2,2,5,3,4,3,3,3,3,1,3,1,3,3,4,1,2,5,1,1,5,2,4,1,3,3,4,2,3,5,4,1,5,2,5,1,3,3,1,4,1,1,4,5,4,4,4,3,4,4,5,1,3,2,4,5,4,5,3,1,1,4,3,5,4,1,1,4,2,5,5,1,3,3,3,1,1,2,5,1,1,2,4,4,5,5,2,1,2,2,3,5,2,5,2,4,5,4,3,4,5,4,4,4,4,1,4,2,4,1,3,4,5,2,5,2,1,2,1,5,4,4,3,5,5,5,2,4,1,2,5,2,1,1,5,5,1,3,5,1,3,1,2,1,1,1,1,5,3,4,4,5,5,1,4,3,4,4,2,4,1,5,5,3,3,2,5,2,5,5,5,1,2,4,2,2,4,3,1,3,1,3,5,1,1,5,5,5,3,3,2,1,4,5,3,5,1,1,2,4,5,4,3,4,5,3,3,2,5,1,3,1,5,5,4,1,3,2,4,1,4,3,1,1,1,2,3,5,1,3,4,3,1,1,5,2,4,1,1,3,2,5,1,4,1,2,5,5,2,4,4,5,5,5,1,4,3,3,3,5,5,3,5,4,4,5,3,4,3,5,4,4,3,3,2,4,5,3,2,4,4,2,5,1,4,1,4,2,3,4,1,4,5,4,3,1,3,2,4,1,5,3,5,2,3,2,1,1,1,3,5,1,1,4,4,5,2,4,3,4,3,1,3,2,1,5,1,1,1,3,2,4,5,3,4,5,5,2,5,3,4,1,5,3,3,4,1,4,5,1,5,3,4,5,2,3,5,4,3,2,3,4,4,4,3,3,5,5,5,1,3,1,2,3,3,5,5,5,2,1,3,5,5,1,1,1,3,5,1,1,1,2,3,4,1,1,3,2,4,2,2,1,2,3,4,3,2,2,1,3,1,5,5,5,1,3,4,3,2,2,1,1,1,5,1,2,1,4,2,4,4,5,5,5,2,3,3,3,2,5,2,3,2,5,2,2,2,1,3,5,2,1,5,4,2,3,2,5,3,5,5,1,1,1,5,5,2,3,3,5,2,3,1,3,2,2,1,1,3,1,2,1,1,2,2,4,4,4,1,2,1,2,3,5,2,2,3,1,3,2,1,5,1,4,4,4,4,2,2,3,5,2,1,5,5,2,3,1,1,5,1,4,2,3,1,3,1,3,1,3,3,3,1,1,1,5,3,4,5,5,4,3,2,1,1,5,4,3,1,1,4,3,1,4,1,3,3,2,3,5,2,4,5,3,5,2,5,5,3,3,1,5,1,4,1,2,5,5,2,3,2,5,2,2,4,1,3,1,5,1,4,4,1,2,2,5,2,2,3,3,4,5,3,1,1,4,1,2,1,4,4,3,4,1,3,3,1,2,3,1,1,4,3,3,4,3,3,3,3,5,2,1,5,1,4,3,2,3,2,2,1,2,5,5,2,1,3,5,4,1,5,2,1,4,5,3,2,2,3,5,3,5,4,1,5,2,3,2,3,5,3,2,3,5,1,2,3,5,2,5,1,4,4,3,5,3,2,1,1,1,4,2,2,4,2,3,3,4,1,2,1,4,2,1,5,3,2,3,1,1,1,5,3,1,1,1,4,2,3,4,1,2,2,2,5,1,2,5,1,3,2,4,4,5,3,1,2,4,4,4,5,2,5,1,5,2,4,5,4,1,5,3,5,3,2,3,5,1,5,2,2,2,3,1,3,2,2,5,3,1,4,4,3,2,3,3,5,1,5,5,5,5,4,3,3,4,1,5,3,4,1,2,2,2,1,1,5,2,1,1,5,1,3,2,1,1,4,3,4,3,5,2,1,5,2,5,4,5,4,1,5,3,1,3,3,5,1,5,1,5,3,1,5,3,4,4,2,4,4,2,4,1,2,1,2,1,1,2,1,4,4,4,3,1,1,3,5,2,3,2,4,4,1,4,5,2,3,4,5,4,2,5,5,1,1,1,5,5,1,5,1,5,5,5,2,5,4,3,2,4,3,5,1,5,2,5,3,2,2,3,3,1,2,4,4,2,5,1,3,4,3,2,4,4,1,3,2,4,4,3,3,1,4,4,5,3,4,4,3,1,1,2,1,3,1,5,3,5,2,4,5,1,4,1,2,4,1,5,3,5,3,5,3,3,3,5,1,4,5,5,1,5,5,4,4,3,2,4,4,1,1,5,2,1,2,3,4,4,1,5,1,1,2,1,3,3,1,2,1,1,2,2,1,4,2,2,4,5,5,4,2,5,4,3,2,1,5,2,5,4,4,4,2,2,2,5,5,2,2,1,4,5,4,2,3,2,2,1,5,4,1,4,1,5,5,2,5,4,4,4,1,1,3,3,4,2,1,1,5,2,5,5,2,4,1,3,3,1,5,5,1,5,5,2,1,5,2,2,4,2,4,3,1,3,3,2,2,5,2,2,2,1,1,3,3,4,2,5,5,1,1,3,1,2,4,2,3,5,2,1,2,5,2,4,3,4,5,5,4,2,3,5,4,2,4,3,2,1,2,5,3,5,3,5,2,1,5,3,3,1,2,3,4,1,4,4,2,2,3,4,3,2,2,1,1,4,3,1,3,3,2,2,2,2,1,4,5,1,3,2,2,3,3,3,5,2,4,5,2,4,1,1,2,5,2,3,3,3,1,3,1,5,5,1,5,2,3,3,2,1,2,3,1,2,4,5,5,1,3,5,5,1,5,2,5,5,1,2,5,2,2,5,5,1,4,4,4,3,2,3,2,2,2,3,3,2,3,1,3,5,5,5,3,3,1,1,5,5,4,4,1,5,1,5,5,3,2,2,3,3,4,2,2,4,1,1,3,2,3,4,3,3,4,2,5,1,4,5,2,1,2,3,5,2,1,2,3,3,4,5,5,1,4,2,5,5,4,4,2,5,5,5,3,1,4,5,5,1,3,3,5,5,4,5,5,2,1,4,1,2,5,2,1,3,4,3,2,2,5,1,5,3,3,1,5,2,4,4,1,4,3,4,2,3,3,2,4,4,2,2,2,5,2,4,5,2,3,1,5,3,2,3,2,1,3,3,1,1,5,4,2,1,3,2,2,4,2,1,1,4,1,4,3,3,4,3,1,1,1,3,2,3,4,5,5,4,2,1,1,1,4,5,1,2,5,2,2,3,1,1,5,4,2,1,5,1,5,4,4,1,4,2,2,1,3,5,1,2,5,2,1,5,1,2,4,3,4,4,3,4,2,3,5,1,5,2,1,5,5,2,3,1,4,3,3,3,4,2,2,4,1,5,3,4,2,3,1,5,3,5,4,3,2,1,4,4,1,4,3,4,4,5,5,1,3,3,2,4,5,1,2,3,5,4,5,4,1,1,1,4,5,4,1,3,5,4,5,2,2,3,5,5,1,5,3,4,4,4,3,3,1,3,3,3,3,5,5,3,2,5,4,4,2,1,1,1,3,1,4,5,5,2,3,2,2,5,3,3,1,1,1,1,5,2,5,3,2,2,3,2,2,4,3,5,1,3,5,5,2,1,2,4,5,4,2,5,1,3,1,5,3,5,2,5,3,2,2,5,1,5,5,4,1,1,3,1,3,1,3,5,3,5,2,2,1,4,3,2,2,4,1,1,2,4,3,4,4,2,4,2,1,3,5,5,5,2,4,3,2,1,1,1,3,5,4,4,1,4,2,3,5,5,3,4,1,3,2,4,1,3,3,1,2,4,4,2,2,3,1,1,2,1,2,2,5,5,4,4,5,5,4,4,4,1,4,1,2,5,5,5,5,1,1,1,2,4,1,2,1,5,5,5,4,4,2,5,5,1,2,1,1,1,4,1,1,2,4,3,1,2,3,2,2,5,4,2,1,1,5,5,3,1,4,2,3,5,4,1,1,4,3,4,1,4,5,1,1,2,2,2,3,5,4,2,4,2,3,4,1,4,5,3,4,4,5,4,5,2,1,5,5,3,3,4,2,5,1,3,4,3,5,1,4,4,5,1,2,5,2,3,1,2,4,1,4,5,3,2,1,1,3,1,3,2,1,1,1,2,1,4,2,4,5,5,2,5,5,2,5,4,5,2,4,2,2,1,5,4,4,2,3,5,5,4,3,4,3,5,3,3,5,3,4,3,1,1,3,5,4,4,1,1,1,4,5,2,1,4,5,1,4,1,2,3,2,3,3,3,4,1,3,1,5,3,3,5,3,5,2,4,2,4,4,2,5,1,1,2,5,5,3,5,5,3,3,4,2,4,4,1,4,5,2,1,1,5,4,3,2,2,2,1,3,3,1,4,1,2,2,1,1,3,3,5,3,1,5,1,4,2,1,1,4,1,5,4,5,3,1,2,2,2,5,4,4,5,2,4,4,4,3,2,2,5,1,5,3,1,4,4,3,5,5,3,4,4,4,3,3,2,3,5,5,3,3,1,2,1,1,2,2,3,2,3,1,1,2,2,4,1,4,5,1,2,4,3,3,3,5,5,2,5,5,3,5,2,2,2,2,5,1,1,5,4,1,3,2,1,4,1,5,4,2,1,1,2,4,2,1,4,2,4,1,5,3,5,1,2,4,1,3,2,1,3,5,5,3,2,1,5,5,5,2,1,2,2,2,4,5,1,3,5,1,4,5,1,1,3,1,5,1,2,3,3,2,1,1,5,2,4,4,2,5,4,3,2,4,5,5,2,2,5,2,2,5,3,5,1,5,2,5,1,1,5,1,5,2,1,1,4,1,4,1,4,4,5,3,4,2,3,1,3,1,5,3,2,2,2,2,1,5,4,3,3,5,4,1,5,2,5,3,5,4,4,3,3,5,3,4,2,2,3,4,3,2,4,4,3,4,4,3,2,4,1,2,3,4,3,4,2,3,5,1,5,5,2,5,2,4,2,4,3,1,5,4,2,1,1,3,4,2,2,3,1,2,4,3,4,5,5,3,2,2,4,2,5,3,4,1,2,4,3,5,3,1,1,3,1,1,4,4,1,1,4,2,3,3,1,3,1,3,5,5,4,2,1,2,1,1,5,3,5,2,5,5,2,2,2,4,1,1,3,3,4,3,3,5,5,1,1,1,3,2,1,1,4,2,3,2,4,2,2,2,3,3,1,2,1,4,5,4,1,2,2,1,2,2,2,3,2,5,1,5,5,4,1,3,3,3,5,3,5,5,1,5,1,3,5,4,3,4,5,1,5,2,2,4,3,4,2,2,3,3,3,1,5,2,2,5,2,2,4,2,3,2,1,4,3,1,3,1,5,1,3,4,5,4,3,1,1,1,2,4,4,2,5,1,5,3,4,4,1,2,2,2,1,5,1,4,2,2,3,2,2,2,1,5,5,1,3,3,5,1,3,2,1,5,1,5,5,4,1,3,1,3,2,5,3,1,5,5,2,3,3,2,4,1,5,4,3,2,3,4,2,5,4,2,2,1,2,5,3,4,2,5,5,2,5,2,5,3,2,2,1,2,1,4,5,4,5,5,5,1,2,1,4,2,3,2,3,1,5,5,3,5,1,5,3,3,3,1,4,2,4,1,2,5,4,5,3,1,4,4,4,2,3,3,2,5,4,3,2,1,3,5,1,3,1,3,2,2,5,5,5,2,3,4,3,2,4,1,5,2,5,3,3,4,3,3,5,5,4,3,4,3,1,5,2,4,1,1,2,2,5,2,2,1,3,2,4,4,3,2,5,5,5,5,1,3,2,2,3,4,4,4,1,1,3,2,4,1,5,2,2,2,3,3,4,3,5,4,4,1,5,5,4,5,1,5,3,1,1,2,3,3,4,5,4,1,2,5,1,5,5,4,5,3,5,1,3,2,3,3,4,2,4,5,4,1,1,3,5,4,1,1,5,4,5,5,1,4,2,2,4,5,2,1,4,4,4,4,5,5,3,3,3,4,5,2,4,3,2,5,3,3,1,2,2,4,2,4,5,5,4,2,1,4,1,1,5,4,5,2,2,4,1,5,5,1,4,5,4,3,5,1,1,3,5,5,5,5,2,5,2,4,5,1,4,4,3,2,2,2,1,3,5,2,5,4,1,3,1,3,1,1,5,1,5,4,2,3,3,4,2,4,4,2,2,5,2,2,3,5,3,5,5,5,1,4,1,5,5,3,3,5,2,4,2,2,5,1,5,4,5,1,3,5,2,1,5,1,1,3,5,2,2,1,5,1,2,2,5,2,1,3,5,5,5,2,3,2,1,3,5,4,3,2,2,2,2,2,4,1,3,3,2,5,2,5,3,5,2,2,5,5,5,1,4,2,3,2,4,4,5,4,4,4,4,4,2,3,4,2,2,2,1,1,2,3,3,2,5,4,5,3,2,2,5,3,3,1,4,5,3,5,3,2,5,2,2,3,1,3,4,2,5,1,2,5,5,3,1,5,5,3,1,5,5,2,5,3,2,3,1,5,5,1,5,2,4,3,4,1,1,1,5,2,4,5,3,3,2,3,2,4,5,1,1,3,4,2,2,2,3,3,1,1,3,5,2,3,1,4,3,4,4,4,2,1,4,5,3,3,5,1,4,5,4,3,1,2,1,3,4,2,1,3,1,2,4,2,2,2,4,5,4,1,3,5,1,3,4,5,3,2,3,3,5,1,5,4,4,5,3,5,3,5,3,2,4,5,4,3,3,1,1,5,4,2,1,3,2,5,2,4,5,3,1,5,3,2,3,4,2,1,4,3,4,4,3,2,2,1,5,2,5,1,5,4,4,4,5,4,3,2,1,4,4,3,5,1,5,2,3,5,5,3,5,5,2,5,4,3,3,5,2,1,2,5,4,3,5,3,2,1,2,4,3,5,4,3,3,1,1,3,4,2,2,1,1,1,1,4,5,3,1,4,4,1,1,4,2,1,2,3,2,1,2,5,4,1,3,5,2,5,2,5,3,1,1,5,1,5,1,3,1,3,2,3,2,1,5,4,3,3,1,2,5,5,4,2,1,3,2,3,5,4,5,5,4,3,2,5,1,2,2,5,3,1,3,2,5,4,5,2,5,5,4,4,2,3,4,5,4,5,5,2,4,1,4,1,3,4,5,1,3,1,3,5,4,3,3,4,5,3,4,3,5,5,4,3,3,4,2,4,4,2,3,2,3,4,5,3,3,3,5,1,1,3,2,5,4,2,3,1,5,4,1,3,3,5,1,4,4,3,2,1,4,2,1,5,1,3,4,5,1,4,1,3,1,1,5,5,4,4,4,5,5,2,4,1,2,1,4,3,1,1,1,2,5,5,4,1,2,5,5,4,2,4,2,4,2,1,3,3,3,2,2,4,4,4,2,1,1,3,5,4,4,3,1,1,5,3,2,3,4,1,2,3,3,1,2,1,3,4,2,4,2,1,2,1,4,1,4,4,2,1,2,5,2,3,1,4,5,2,3,3,3,3,1,1,5,5,4,5,1,3,4,5,2,3,4,2,3,1,3,4,2,5,4,5,2,2,4,4,5,1,4,3,4,3,1,4,4,4,5,4,3,3,2,3,3,3,1,1,4,5,4,4,3,1,3,2,5,1,4,4,4,5,1,3,5,2,3,2,4,3,1,2,5,3,2,1,5,4,2,1,5,2,3,2,2,3,1,2,5,4,5,5,1,5,4,5,4,2,4,1,5,2,5,4,2,3,1,5,2,4,3,4,5,4,5,2,2,2,2,5,3,1,4,5,3,3,5,4,4,5,3,1,1,3,1,4,3,4,4,5,4,4,1,5,3,2,5,4,2,4,2,3,1,1,4,5,5,1,1,1,1,5,5,3,4,5,5,5,1,5,3,2,4,4,3,4,5,4,4,5,2,2,3,2,5,5,4,5,1,3,4,2,5,2,1,5,2,1,1,5,1,2,1,1,2,5,1,1,5,3,2,2,1,3,2,1,3,2,3,1,5,5,4,4,1,3,2,4,2,4,4,5,2,5,1,3,1,5,5,2,3,5,3,4,5,3,5,4,5,3,5,3,2,5,2,1,4,2,2,1,5,3,2,1,5,3,4,2,3,3,4,3,5,3,3,2,4,1,1,2,4,5,5,1,5,4,5,5,1,1,5,3,2,4,5,2,5,2,1,2,1,2,3,2,5,1,4,4,4,5,2,2,2,5,5,5,4,4,1,4,3,5,1,3,4,2,3,2,2,4,1,1,3,4,4,2,5,2,4,3,3,2,2,3,3,1,4,5,3,1,1,1,4,5,1,2,2,4,1,5,2,5,4,2,5,2,1,5,5,3,2,5,3,5,3,1,1,2,3,3,2,1,5,3,1,5,5,4,5,3,2,3,1,5,2,5,2,3,5,1,3,2,3,3,4,5,3,1,2,3,2,2,5,3,4,5,5,5,1,3,4,2,2,1,5,2,3,5,5,2,1,3,5,2,5,5,1,1,2,3,5,1,4,5,1,5,1,2,4,1,3,4,5,3,2,3,3,2,5,5,5,3,5,5,4,3,3,5,5,3,1,5,3,1,5,3,5,2,5,1,5,4,5,1,1,5,2,1,3,5,4,2,5,3,1,1,4,1,3,3,2,5,5,2,4,1,4,5,4,5,4,2,2,1,5,5,5,1,4,3,1,1,1,2,1,5,4,2,4,1,1,3,4,3,2,2,3,4,1,4,5,5,1,1,4,4,3,4,1,2,4,4,4,2,5,5,3,5,1,1,5,4,3,3,4,1,1,5,2,2,1,2,5,2,4,3,5,2,5,2,5,1,1,1,3,5,4,3,1,3,4,1,2,5,2,2,1,2,4,5,5,4,5,1,4,5,2,2,3,5,1,3,4,2,3,1,3,4,3,3,2,3,3,1,5,3,3,3,3,1,4,4,3,4,2,3,3,1,2,2,1,2,1,4,2,3,2,2,2,2,4,3,4,1,1,4,3,2,5,2,5,5,4,2,3,3,4,5,2,2,3,1,3,1,3,5,1,2,5,3,3,5,5,2,1,4,4,3,2,5,3,4,4,5,1,3,5,5,4,2,1,2,2,5,4,4,4,3,4,3,2,3,3,2,2,2,5,2,2,5,5,3,3,3,4,2,2,1,2,4,1,4,3,1,5,4,5,4,1,2,2,1,3,5,5,2,2,4,3,5,4,4,4,2,4,2,2,2,3,4,3,1,1,3,3,5,2,2,2,4,3,2,3,1,5,1,2,3,1,2,1,2,4,4,2,3,5,5,5,4,5,3,4,4,4,5,5,4,3,1,4,3,2,4,5,3,5,3,2,4,1,1,4,2,2,1,1,3,5,2,4,1,2,4,3,4,1,1,2,2,1,1,3,2,1,1,5,2,3,5,4,5,5,3,4,1,1,5,1,1,1,2,1,4,4,3,3,5,4,5,2,1,1,2,1,2,1,2,2,5,2,3,1,3,1,1,1,1,5,4,3,2,3,4,5,5,1,5,2,5,5,5,4,2,1,2,2,2,3,1,3,1,5,3,1,1,1,1,3,1,4,3,5,5,1,5,1,3,2,5,2,4,5,3,2,4,5,2,5,5,3,3,4,1,5,3,5,1,1,5,4,4,1,1,2,3,4,4,1,1,5,2,3,4,4,3,1,3,5,4,4,1,4,4,1,1,3,4,2,5,2,4,3,3,3,1,2,2,3,3,1,2,5,3,2,1,4,5,5,3,4,3,4,4,1,4,4,1,1,5,3,5,3,4,5,4,3,2,2,2,1,4,3,4,3,5,1,2,1,2,2,2,4,1,2,5,2,5,2,3,4,1,2,4,5,1,5,1,1,3,2,2,4,5,4,3,4,5,1,4,3,3,4,4,1,5,1,1,1,4,3,2,2,3,3,4,5,5,5,2,1,5,5,1,4,5,3,3,5,3,2,5,1,3,2,1,5,2,4,2,4,2,4,3,3,3,3,5,4,4,4,1,5,5,4,3,3,2,3,1,3,2,5,4,2,1,5,2,3,1,2,4,4,4,3,2,5,3,2,2,2,5,1,1,5,1,5,5,2,2,1,4,5,1,1,5,2,4,3,3,3,4,5,3,3,1,3,2,4,1,5,5,3,3,1,5,5,3,3,3,3,5,4,5,3,4,1,4,2,3,1,1,3,5,1,2,1,1,1,2,5,3,5,2,5,1,3,2,2,1,4,3,5,3,4,3,3,4,2,4,5,1,1,2,3,3,3,3,3,4,2,5,5,3,5,2,3,3,3,1,3,4,5,3,2,2,5,5,4,2,5,4,3,5,3,4,3,4,4,5,3,3,5,5,3,2,2,3,5,5,3,1,5,2,3,4,2,3,2,3,1,4,1,1,1,2,4,2,1,2,4,2,4,1,4,3,2,5,4,4,1,2,5,2,3,4,1,4,3,4,1,1,4,4,4,1,2,4,4,5,3,5,1,2,1,4,3,1,5,1,5,2,3,2,2,4,4,4,4,4,2,3,3,3,5,4,1,2,2,2,4,3,1,2,1,2,2,5,4,2,4,3,5,2,2,4,5,2,1,3,1,1,4,4,4,4,3,1,3,1,1,3,4,4,3,1,5,4,1,3,1,1,5,1,5,4,5,2,4,1,5,4,4,5,1,4,5,3,5,4,1,4,5,4,5,2,4,2,3,5,1,4,1,1,1,2,3,4,1,2,1,2,2,3,3,2,4,1,3,2,3,5,4,3,4,3,5,5,2,5,5,3,2,2,1,4,1,4,2,5,4,3,4,1,3,5,5,2,3,3,3,5,2,1,3,3,1,1,4,2,2,1,2,5,4,2,5,5,1,3,2,5,2,5,3,4,4,5,3,3,3,4,3,2,5,5,3,5,2,2,1,4,1,1,1,5,4,3,3,2,5,1,5,1,1,2,1,1,4,2,4,3,1,5,3,2,5,5,4,2,5,4,3,3,1,2,3,5,2,1,3,3,2,4,4,5,3,3,4,3,4,3,5,3,4,3,2,4,3,4,3,4,1,3,5,5,3,5,2,4,5,5,1,5,4,2,1,1,4,4,2,3,2,3,2,1,2,1,5,1,2,2,4,5,5,2,3,1,1,1,3,4,2,2,4,3,3,5,3,2,4,5,2,4,4,4,4,1,2,2,2,1,2,2,2,2,5,2,2,5,1,3,3,2,1,4,5,3,1,4,2,2,5,2,3,3,3,2,3,5,3,3,2,5,3,1,2,2,2,4,3,4,3,3,2,3,4,4,4,2,1,3,4,3,3,4,3,1,5,3,1,3,4,3,1,2,2,3,2,5,2,4,5,2,1,2,4,3,4,4,5,1,3,2,5,4,1,2,3,3,2,4,2,5,2,2,2,1,3,4,1,5,1,5,2,2,1,5,5,4,1,2,5,4,2,1,1,3,4,3,3,2,1,3,3,3,5,5,2,2,3,2,5,3,3,2,4,2,2,1,4,1,5,5,1,1,3,4,3,5,5,1,5,5,3,4,4,2,4,1,4,3,5,1,5,5,2,3,4,3,1,1,1,3,3,5,3,4,5,2,2,1,2,4,5,1,5,3,4,3,2,5,5,1,5,5,5,3,4,1,1,3,1,3,3,5,1,5,3,3,3,2,2,3,2,5,4,1,1,3,4,2,4,5,3,1,3,5,4,1,5,4,1,2,4,3,5,2,4,4,4,4,5,1,4,3,3,3,4,2,1,5,3,1,5,1,5,1,1,4,2,3,5,5,3,5,4,4,2,5,3,1,3,3,2,3,3,2,4,2,4,4,2,4,3,1,1,1,2,2,1,4,4,1,2,4,5,4,4,1,2,3,2,3,5,5,1,2,2,3,3,4,5,2,1,2,4,3,5,2,3,3,1,4,5,5,5,4,1,1,3,5,1,2,1,3,3,3,5,5,1,5,4,4,2,2,2,2,3,4,5,4,3,3,5,3,2,5,1,1,4,1,1,5,5,4,4,3,5,5,1,2,2,1,1,2,5,5,5,1,2,1,3,2,4,3,1,5,5,1,5,4,4,3,5,5,4,1,4,5,5,1,5,3,5,2,4,4,1,3,3,3,5,5,4,4,1,4,5,5,2,3,5,2,4,3,2,5,2,3,5,5,3,3,1,5,5,2,3,2,5,1,5,5,4,1,5,2,1,3,4,2,4,1,3,2,2,5,3,5,1,1,1,4,3,3,3,4,3,1,3,5,1,1,1,3,4,5,4,4,2,1,1,2,4,2,4,1,3,4,4,1,1,4,1,4,3,1,5,3,5,2,1,4,4,1,4,2,4,5,3,1,2,5,4,2,4,3,1,4,5,4,5,1,3,4,3,1,2,5,3,5,3,4,1,1,2,1,4,3,5,5,2,3,1,5,2,2,1,5,1,5,5,5,2,1,2,3,2,1,1,3,5,2,4,1,3,1,4,5,4,2,4,4,5,4,1,4,4,5,5,2,5,2,1,5,1,4,5,4,3,1,5,2,4,1,4,1,5,5,2,1,4,2,3,2,3,2,5,5,2,3,5,1,2,3,4,5,2,3,4,1,2,1,5,3,2,2,3,5,4,3,5,2,2,5,3,3,2,2,1,2,2,4,2,5,5,2,1,4,3,5,2,2,2,1,3,5,5,4,5,4,2,2,3,1,4,3,3,4,5,3,2,5,2,2,1,5,4,3,4,1,4,4,2,5,3,1,4,4,5,5,5,3,4,4,3,1,4,4,1,3,3,5,1,2,2,1,1,3,4,5,3,3,5,3,4,3,3,2,2,3,2,3,3,1,4,3,2,4,3,4,2,1,2,3,3,1,3,2,3,4,3,3,2,3,1,5,5,3,4,5,3,1,3,1,1,1,4,1,3,1,1,1,3,1,2,1,4,3,3,4,5,2,3,1,1,3,5,1,5,5,4,1,5,1,5,3,4,5,1,1,5,4,4,2,1,1,4,4,5,1,1,4,4,4,3,4,1,4,4,2,2,5,1,4,4,3,5,2,5,1,2,1,4,1,4,3,1,1,1,5,2,4,4,5,2,3,5,5,5,1,2,4,1,2,4,1,1,3,5,5,5,4,1,3,2,4,5,5,3,5,3,1,1,1,4,3,3,4,5,1,1,3,5,5,4,3,5,3,1,2,2,5,2,5,2,5,1,2,3,1,4,1,1,5,4,3,3,1,2,2,5,2,5,4,3,1,4,3,5,1,1,4,1,3,1,1,1,2,3,5,1,2,1,5,5,5,5,5,3,2,2,4,2,1,5,5,4,2,3,1,2,1,5,2,2,5,5,5,3,5,2,3,3,5,5,3,2,2,3,2,1,2,1,2,4,4,5,1,4,3,1,5,3,2,4,4,3,2,3,3,5,4,2,5,4,2,3,3,3,5,3,2,2,2,5,1,4,1,3,5,4,4,4,4,2,2,5,1,4,5,4,2,2,5,4,4,3,2,4,2,2,5,3,4,2,4,4,5,2,4,5,3,3,3,5,1,5,4,4,4,2,5,2,5,3,4,3,1,1,1,5,1,2,5,2,1,3,3,2,4,3,2,2,4,5,4,1,2,1,2,3,4,5,2,3,3,4,1,5,4,4,1,1,5,3,1,4,4,5,2,1,3,4,4,1,1,5,4,1,2,5,3,1,3,3,5,4,3,5,1,3,4,3,4,2,3,1,3,4,5,3,3,2,4,4,1,1,5,1,3,4,5,3,4,5,2,2,4,3,5,2,5,3,3,2,2,3,2,2,4,3,2,2,5,2,4,1,2,2,5,2,2,1,3,5,3,3,5,5,4,2,1,4,1,1,2,1,5,5,5,4,1,2,4,4,3,1,2,4,4,1,4,3,2,2,3,1,1,2,3,4,2,1,5,1,3,4,1,5,1,1,3,2,1,2,1,5,2,1,3,1,4,1,2,3,2,2,1,1,2,4,1,2,3,5,2,3,2,4,4,4,1,5,4,2,3,1,5,4,3,5,3,3,1,3,2,2,2,5,4,2,2,2,1,1,4,4,2,1,3,5,2,3,1,2,1,4,1,2,4,2,3,4,5,2,3,5,1,4,4,4,2,5,4,4,2,5,3,3,2,3,1,5,2,4,4,1,1,4,1,3,4,3,3,5,5,3,3,5,5,4,1,3,5,1,4,2,1,3,4,1,2,3,4,4,1,1,5,1,4,5,2,1,3,1,2,1,2,2,5,1,4,5,5,2,3,4,4,4,5,1,3,4,4,4,5,2,4,1,5,3,5,5,3,2,1,5,3,3,2,5,5,3,3,1,3,1,3,4,3,2,2,3,3,2,1,1,2,3,1,3,1,3,5,2,3,3,2,2,1,5,3,1,4,3,3,5,1,4,2,2,5,4,3,1,2,2,1,4,2,4,3,2,4,2,3,5,2,2,1,4,4,3,3,2,1,3,2,2,5,1,5,3,5,4,1,3,4,2,2,4,2,2,1,4,1,3,5,3,3,4,3,5,5,5,2,2,3,3,4,3,1,2,1,3,4,3,1,1,4,5,1,4,2,4,1,2,2,5,1,2,1,2,4,1,5,5,1,4,1,4,3,3,5,5,4,2,3,2,3,1,2,3,1,4,1,2,3,4,3,1,3,4,4,3,3,5,2,3,2,3,3,1,1,3,5,1,4,1,3,1,2,1,1,4,3,2,2,1,5,2,2,3,4,4,3,5,5,1,2,4,2,5,3,2,5,3,3,5,4,1,5,5,5,5,1,3,3,5,2,3,5,3,4,5,5,4,1,3,5,1,5,4,5,1,1,2,5,4,1,4,1,4,4,5,5,5,1,3,3,2,1,3,3,2,1,4,1,3,5,5,3,4,4,1,4,4,1,2,4,4,3,1,1,5,5,4,3,5,2,2,2,1,3,2,1,5,4,3,4,1,2,1,1,2,4,5,5,5,3,5,5,4,1,1,2,2,4,5,5,3,4,1,4,1,3,4,4,1,2,5,3,1,2,1,4,3,3,2,5,2,1,3,4,4,1,5,1,1,3,3,3,3,4,3,2,2,2,1,3,3,5,3,3,3,2,1,5,2,3,4,1,5,3,5,3,5,2,5,2,3,1,5,4,5,5,5,2,5,4,5,3,2,2,2,3,3,4,1,3,4,4,2,3,4,1,2,1,1,1,2,1,5,4,2,2,3,2,2,4,2,1,4,1,4,3,4,1,2,3,5,2,4,4,1,2,4,3,3,1,3,5,4,1,2,5,5,4,1,3,4,5,2,3,1,3,4,5,2,3,2,3,3,1,2,3,5,5,3,5,2,5,5,2,4,2,4,3,5,2,2,5,2,2,5,1,3,3,5,4,4,1,3,4,1,5,1,1,1,2,4,5,1,3,1,4,1,1,1,5,4,3,2,2,3,5,2,3,3,1,1,3,5,2,1,5,1,5,5,4,1,1,4,2,1,4,5,1,4,2,1,1,1,3,3,2,2,1,1,4,4,5,1,1,4,1,1,4,1,2,3,2,4,2,3,2,3,3,3,5,3,5,4,3,3,2,5,4,1,2,5,1,3,5,3,5,5,4,3,1,3,3,5,2,4,1,5,5,3,4,5,4,4,5,4,5,2,1,5,3,3,5,2,3,1,1,4,1,1,1,4,2,3,3,4,2,3,4,2,5,2,3,3,5,3,5,3,4,2,4,1,5,1,5,3,3,4,4,1,5,1,1,2,1,3,5,2,5,2,1,1,3,4,4,4,4,4,1,2,1,5,2,2,5,1,5,3,5,4,2,2,1,2,4,3,1,5,2,2,2,4,2,3,2,2,5,1,5,2,3,5,4,3,1,5,5,5,1,1,3,4,3,3,3,5,5,2,3,1,3,5,4,4,3,1,1,4,4,5,1,3,4,2,2,1,1,2,4,5,1,3,1,3,5,4,3,5,4,5,3,1,5,1,5,5,5,3,3,2,1,2,5,1,3,3,5,5,2,2,4,3,1,4,4,3,4,1,1,3,4,2,4,5,4,4,4,1,3,3,5,3,4,3,4,5,2,3,1,2,2,5,3,5,3,4,4,2,4,2,4,3,2,3,1,5,3,2,4,1,3,2,2,4,3,1,1,1,5,5,4,5,2,4,4,1,4,4,2,5,5,1,4,2,2,1,2,4,4,1,5,2,4,3,3,5,2,1,3,3,2,3,1,2,2,3,1,2,4,2,3,5,4,5,5,4,4,3,2,1,5,1,1,1,1,2,3,4,1,5,1,3,5,5,2,5,1,3,5,3,5,4,1,4,3,5,4,2,5,5,5,2,4,3,4,2,3,5,3,2,5,3,5,5,3,5,2,3,1,3,2,4,1,4,4,5,3,3,2,2,4,2,1,3,5,3,1,1,2,1,3,3,4,2,4,1,3,3,3,3,4,4,1,5,4,5,1,5,5,2,4,4,5,3,1,1,2,5,5,2,3,4,5,5,1,4,3,5,3,5,5,2,4,5,2,4,1,5,5,1,2,2,2,1,5,1,5,1,2,1,3,2,5,4,3,5,1,5,1,2,1,4,2,3,3,5,1,2,5,3,5,1,1,5,4,1,2,1,2,1,2,5,4,1,3,2,1,2,1,4,4,4,5,3,4,1,3,1,3,4,1,1,5,3,4,1,2,4,4,5,1,4,5,5,3,2,2,4,5,2,5,1,1,3,1,1,5,2,5,2,3,5,4,4,2,4,4,4,2,2,1,1,1,3,5,3,4,1,5,3,4,4,2,3,4,5,1,3,5,1,4,4,2,2,2,4,5,2,1,1,4,5,4,3,5,5,4,4,2,2,1,3,1,3,2,4,1,4,4,1,1,1,2,5,1,1,3,3,3,4,4,4,1,4,4,4,1,1,4,4,3,4,1,5,2,5,1,3,1,4,2,1,2,5,5,1,5,2,4,4,3,4,3,4,2,3,3,4,1,4,2,1,5,4,3,4,1,1,2,3,2,4,5,3,3,2,4,3,4,3,1,3,3,1,4,5,1,5,1,5,3,1,1,2,4,5,2,3,4,2,4,4,1,2,1,5,1,5,1,1,2,1,2,3,1,2,3,1,3,5,3,5,3,3,5,1,5,3,4,5,4,5,5,4,5,2,2,4,1,4,1,3,5,5,1,5,3,5,4,4,4,3,4,1,3,4,5,1,3,3,4,2,1,2,3,2,5,4,1,1,5,1,5,1,1,1,4,2,1,3,5,4,4,5,3,5,1,1,5,4,2,1,1,4,2,2,1,2,4,5,5,4,4,4,1,3,3,1,2,5,3,4,3,1,2,2,5,4,5,1,1,5,3,2,4,1,3,2,3,3,3,2,2,5,1,1,3,4,5,4,5,3,4,3,1,5,1,5,5,1,2,2,3,3,1,3,1,1,3,2,2,1,1,3,5,3,4,4,5,5,3,1,1,3,1,2,4,2,4,1,2,3,4,2,4,4,1,5,3,5,4,1,5,3,3,2,3,5,3,3,4,5,1,4,1,3,3,3,2,5,5,3,3,3,5,1,1,3,2,1,2,2,1,1,1,2,4,1,5,1,1,5,5,3,4,1,3,3,5,3,2,3,5,3,1,1,4,2,4,5,4,1,1,3,2,1,2,3,4,4,3,2,5,4,4,3,3,5,3,3,4,5,3,1,5,1,4,2,2,1,4,5,3,3,3,1,4,2,2,4,3,1,4,3,4,2,3,2,1,5,5,2,3,1,4,1,5,1,4,4,3,1,5,2,4,5,2,1,2,1,5,2,4,2,3,2,1,4,2,2,5,5,5,1,5,1,3,3,5,3,4,4,1,4,5,4,5,3,1,3,1,1,3,4,4,2,3,5,1,3,5,3,2,4,1,2,4,1,3,4,3,5,1,3,1,1,4,5,2,5,4,5,3,5,3,1,4,4,4,2,4,1,5,1,1,4,4,2,4,1,1,3,3,5,5,2,2,1,1,5,3,3,3,1,1,3,3,2,1,1,1,3,2,2,4,5,1,2,4,2,1,3,5,5,5,5,2,1,3,2,5,2,1,3,2,3,4,1,4,1,5,3,3,4,2,4,1,2,4,5,4,1,4,5,5,3,1,1,3,4,1,2,5,5,1,3,4,5,2,3,3,4,3,3,5,1,1,5,1,5,1,2,2,1,1,2,4,3,2,4,3,3,1,4,1,2,5,3,5,4,5,1,3,1,2,3,5,4,5,3,3,1,4,3,3,5,2,2,4,5,2,5,1,4,1,4,5,5,3,2,4,4,5,2,3,2,2,2,2,4,3,3,1,4,4,5,4,1,3,3,2,1,5,5,2,5,2,1,2,1,4,4,1,5,3,3,1,4,1,2,3,1,2,2,4,4,2,4,1,5,4,3,5,1,4,3,4,1,5,2,3,5,3,3,3,1,5,1,5,1,5,5,1,3,2,5,5,2,1,5,3,1,2,2,2,2,4,5,3,5,3,5,1,5,1,4,2,1,4,4,3,5,4,1,3,5,3,4,3,3,3,3,4,2,5,3,1,2,5,4,4,5,4,4,4,2,3,3,5,3,5,1,3,1,3,4,4,2,2,4,1,1,1,5,2,1,1,3,5,1,4,5,3,1,1,4,2,2,2,3,4,5,5,4,5,1,1,1,5,4,5,4,5,4,5,5,4,5,2,4,4,2,3,4,4,5,3,4,5,3,2,2,1,2,4,3,5,1,5,2,3,4,5,4,1,3,5,5,5,3,1,1,4,5,3,2,1,4,4,5,2,1,4,2,1,3,5,2,5,1,3,5,1,1,5,3,2,2,4,1,1,3,2,1,3,4,4,4,5,5,4,2,1,4,2,5,3,5,5,5,1,1,1,2,2,5,2,5,2,4,5,1,4,1,3,4,3,5,5,1,1,4,4,3,5,1,4,4,3,4,4,1,4,3,4,3,1,2,4,2,2,3,2,3,1,1,4,4,3,1,1,2,3,2,4,1,3,3,5,5,4,4,3,3,4,1,4,2,3,2,5,4,5,3,5,2,2,5,2,5,3,2,4,2,3,1,5,5,2,2,5,4,5,3,4,2,1,2,2,4,3,5,4,4,4,5,1,4,2,5,5,3,3,4,2,4,4,3,1,1,3,5,1,3,2,4,2,4,1,2,3,4,4,3,1,4,4,1,3,5,4,4,1,1,3,5,2,3,5,3,2,3,1,1,2,3,5,5,2,4,1,3,2,1,4,2,4,5,2,5,1,4,2,3,4,5,1,1,2,3,5,3,4,3,2,1,5,3,1,2,4,3,5,4,5,2,3,2,2,2,1,3,4,5,1,4,2,2,4,3,2,3,3,5,2,5,5,2,4,5,1,4,5,5,4,1,3,2,2,2,5,1,4,1,2,4,3,2,1,3,3,4,3,3,4,2,4,4,4,2,3,1,3,2,1,4,4,3,1,4,3,2,4,2,2,4,5,2,2,4,3,3,3,5,4,3,5,1,5,1,3,4,4,1,2,5,5,4,2,4,2,2,4,5,2,1,5,5,1,3,4,3,3,2,5,3,3,1,1,5,2,2,2,2,1,1,2,2,1,1,4,3,2,4,4,3,2,1,3,5,5,1,2,2,2,3,4,4,3,2,2,3,1,1,3,5,1,5,1,4,2,1,5,1,3,1,3,2,3,2,2,2,3,1,5,5,2,5,5,2,1,5,4,2,5,3,2,2,1,5,1,5,2,2,5,2,1,4,2,3,3,5,2,3,4,1,2,3,4,3,1,3,2,2,1,1,1,3,2,1,1,4,2,2,5,4,1,2,1,5,5,4,4,2,4,1,4,1,5,5,5,4,4,3,4,5,5,5,3,3,3,5,4,1,3,1,4,2,3,3,2,5,5,4,3,5,5,4,5,2,3,3,5,2,4,2,5,4,4,2,4,1,2,1,1,4,1,1,1,5,1,2,4,3,4,5,2,3,5,5,3,1,5,1,1,4,1,5,5,1,4,3,1,4,3,2,4,1,2,4,3,5,3,4,3,5,1,5,2,5,1,3,3,5,2,4,4,5,5,1,4,1,2,3,1,3,4,5,2,5,2,4,3,2,3,3,3,4,1,2,3,5,2,1,1,4,5,3,5,3,2,4,3,2,3,1,4,1,3,3,1,4,3,5,4,5,2,2,3,4,1,3,5,2,1,3,5,1,4,5,3,5,1,5,4,1,1,3,2,2,3,3,2,5,2,5,5,1,3,1,1,1,4,5,5,4,4,2,4,3,3,5,3,4,4,5,4,4,2,2,3,5,1,3,1,1,2,3,5,2,3,2,4,3,2,3,1,4,4,2,2,1,3,4,4,3,2,3,5,5,1,4,4,1,3,3,5,5,5,3,2,4,3,4,5,5,4,2,1,4,2,4,2,2,3,1,1,2,3,2,4,2,3,3,3,3,5,1,5,4,4,5,3,1,4,1,4,5,5,2,4,5,3,1,3,4,4,4,5,2,2,5,4,5,3,2,2,5,5,1,3,4,4,5,5,5,3,4,5,1,5,4,2,2,5,4,1,5,3,2,2,1,2,3,5,1,2,3,5,3,2,2,3,1,5,4,4,5,1,2,5,3,5,5,5,4,3,1,3,5,3,4,5,4,2,4,2,1,4,3,4,1,4,4,4,3,5,2,1,4,5,2,5,4,2,5,1,3,2,5,4,4,5,5,2,4,2,1,5,3,3,4,5,3,2,4,3,5,1,3,1,2,5,1,1,2,2,5,2,3,4,3,3,1,1,5,4,1,4,5,2,4,1,2,2,4,3,5,4,5,4,5,1,2,3,1,4,3,2,3,3,2,1,3,5,4,4,1,2,2,2,4,2,2,4,4,1,2,4,3,1,3,2,4,3,4,1,3,1,5,3,1,5,4,4,2,5,2,2,3,1,2,2,4,5,1,1,5,4,1,3,5,4,5,1,1,4,2,5,4,2,4,5,5,2,2,1,1,5,5,4,2,2,2,4,5,3,3,5,2,1,2,2,4,5,5,1,5,3,1,1,3,2,3,4,2,1,4,3,5,1,4,4,5,1,5,5,4,5,3,3,5,3,3,5,5,3,1,4,3,1,1,2,5,3,2,5,1,5,2,1,2,5,1,4,2,5,5,2,2,2,1,3,1,2,5,3,3,5,2,3,4,4,2,5,1,4,1,1,5,1,5,4,5,4,3,3,5,5,3,4,4,1,5,1,5,2,5,5,5,2,5,5,4,4,5,1,5,4,3,4,2,3,3,2,2,5,5,1,2,3,3,2,3,3,3,3,3,4,5,4,1,5,5,4,2,2,4,3,1,1,3,4,2,4,1,2,2,2,1,3,3,1,3,1,5,3,3,1,3,4,5,2,1,4,1,3,5,4,1,4,1,2,1,2,2,5,5,4,1,1,5,4,3,4,5,1,1,3,5,4,1,4,5,1,3,3,1,3,3,3,1,1,4,4,4,3,5,3,4,3,2,2,5,1,3,2,4,1,3,4,2,5,3,3,2,3,3,2,1,1,3,3,4,4,1,4,3,1,2,1,3,4,2,5,5,2,2,5,1,5,3,4,2,4,2,1,5,1,3,3,3,3,4,5,1,4,3,1,4,5,5,5,3,3,5,3,5,2,5,3,3,2,2,3,1,1,3,1,3,1,2,5,1,1,3,3,2,4,1,3,4,5,4,4,4,1,3,4,2,4,2,1,1,3,2,4,2,1,4,5,2,4,3,3,2,3,1,2,4,3,4,3,2,4,4,5,1,5,4,2,3,5,4,4,4,4,3,3,1,2,4,3,1,5,2,4,3,2,1,5,1,5,5,4,1,1,1,1,4,5,3,5,1,4,1,1,2,3,1,3,3,3,1,2,2,2,4,5,5,4,4,4,2,3,1,5,4,4,4,3,1,3,1,2,3,2,5,4,2,4,3,5,3,1,3,5,3,3,3,4,1,1,3,4,5,1,3,2,2,1,2,5,5,3,2,1,1,1,5,5,4,4,2,2,2,5,4,1,1,4,4,5,2,3,4,4,4,3,1,3,4,4,2,2,4,3,3,5,3,1,1,5,4,5,3,5,2,4,1,5,4,2,5,3,2,4,5,3,4,2,2,5,3,1,4,5,5,1,5,1,3,3,3,3,1,1,2,1,2,1,2,1,4,3,2,3,5,2,5,5,2,3,2,1,1,1,5,5,5,2,5,3,3,5,5,3,3,2,4,1,2,3,1,1,5,4,5,2,3,5,4,5,5,5,3,3,4,1,2,5,5,3,2,4,3,3,1,4,4,2,2,1,2,2,3,4,1,2,4,2,3,3,5,5,4,3,5,3,3,3,5,1,2,4,5,3,4,2,2,4,5,1,2,3,2,3,5,2,4,1,3,2,1,5,2,3,1,5,2,3,2,1,3,3,1,1,5,1,4,3,3,1,4,4,1,4,3,4,1,2,2,4,3,5,2,2,3,3,4,4,1,2,1,4,4,2,4,3,3,1,5,2,1,2,2,5,2,3,4,3,3,1,1,2,3,1,3,2,2,3,4,4,4,4,1,3,4,1,3,2,5,2,1,5,3,2,2,2,1,5,3,3,4,4,4,2,1,1,1,4,3,1,5,2,2,3,2,3,1,4,2,5,1,4,4,3,2,5,4,4,2,3,1,2,3,5,5,2,1,2,3,5,3,5,4,3,3,4,1,2,1,5,1,1,2,4,4,1,1,3,4,2,5,3,2,3,3,5,3,5,4,4,2,5,2,4,2,4,3,5,1,5,4,5,5,3,2,5,5,4,3,5,5,3,5,5,2,4,2,2,1,5,5,1,4,5,5,4,5,5,5,5,2,5,4,5,3,4,2,2,1,4,2,1,1,4,1,4,2,3,4,3,2,1,3,5,4,1,3,4,2,4,3,1,5,3,1,5,4,3,3,3,4,3,2,1,3,2,2,1,5,4,4,2,2,2,3,3,4,5,4,2,5,5,2,2,5,1,1,1,1,4,3,3,2,1,1,3,2,1,3,5,3,4,2,4,5,4,3,5,1,2,1,2,2,2,4,5,4,2,3,5,3,5,4,5,4,3,2,5,1,5,5,4,1,5,2,4,3,2,3,3,1,3,3,3,2,1,3,5,5,3,4,5,1,3,4,2,4,1,2,5,4,3,4,1,2,2,4,4,4,1,3,3,5,2,5,5,4,1,1,5,5,3,3,3,1,2,4,5,3,2,1,5,3,1,1,1,1,3,5,2,4,5,1,2,5,3,4,4,5,5,5,3,5,4,5,2,4,3,3,4,2,1,5,1,3,5,4,4,2,2,2,4,3,1,3,3,3,3,1,1,1,4,4,4,5,5,4,1,3,2,2,3,2,2,5,2,5,4,3,1,2,5,2,5,3,1,4,3,4,2,1,2,1,3,5,5,3,4,1,1,5,1,3,5,1,5,2,4,4,1,3,1,5,1,5,2,5,3,4,1,4,3,5,3,3,4,5,1,5,1,2,5,3,3,4,5,3,3,3,5,2,2,5,3,3,5,2,1,4,2,1,4,2,2,5,2,1,5,1,2,1,3,2,4,2,1,3,1,5,1,3,1,5,2,4,4,1,1,2,4,2,2,2,3,2,4,3,5,5,2,4,5,1,4,1,1,5,3,1,1,3,2,3,4,4,5,3,3,1,3,2,4,3,3,1,5,1,2,2,3,2,1,4,5,4,4,3,5,4,3,4,4,1,1,4,2,4,5,2,2,3,1,1,5,5,5,1,2,3,2,1,3,3,4,5,3,4,4,4,1,1,4,3,1,2,3,2,1,5,1,4,3,5,5,5,5,4,4,3,5,3,4,2,5,5,2,3,4,4,2,3,4,5,3,2,5,1,3,4,4,5,4,1,4,1,5,1,4,4,1,2,2,4,3,5,1,1,5,2,3,4,4,2,2,2,1,4,3,1,2,2,2,2,2,5,3,2,5,5,4,1,3,1,4,4,1,4,5,3,2,5,1,2,2,4,4,4,3,1,4,3,2,3,1,5,1,4,5,4,3,1,4,2,1,2,5,2,2,5,3,1,3,1,4,3,4,1,5,4,5,5,3,3,1,5,4,3,5,4,4,2,1,4,3,5,1,1,3,5,1,4,4,3,3,2,4,5,5,2,3,1,3,5,5,5,2,2,3,3,4,4,1,2,2,1,5,2,4,2,3,2,5,3,5,4,4,3,2,1,4,5,5,2,5,2,4,5,2,5,2,3,1,4,1,3,5,2,2,3,1,4,1,2,3,1,1,2,2,2,3,2,4,1,1,2,3,3,4,2,3,4,5,4,1,5,4,5,5,4,5,3,2,5,2,2,5,5,1,4,1,5,5,3,4,5,5,4,4,2,4,5,4,2,3,2,2,3,2,3,3,3,1,3,4,4,5,1,5,5,5,3,3,2,3,2,1,5,3,4,1,1,4,4,2,2,4,2,2,4,5,5,1,2,4,4,2,1,4,1,3,2,3,4,5,4,2,3,3,1,3,4,2,5,4,3,3,4,4,4,4,4,1,3,5,1,5,5,1,2,2,4,5,1,5,5,1,5,2,1,1,3,3,3,5,1,1,2,2,5,5,4,1,1,1,3,3,5,5,4,3,1,2,4,2,4,1,1,1,1,1,2,5,3,4,5,1,3,2,4,4,5,2,1,1,3,1,4,2,2,1,1,5,2,3,3,5,4,2,2,5,1,1,2,4,5,5,4,2,3,1,3,2,3,2,1,4,1,2,2,4,5,3,4,5,3,1,4,1,3,4,5,1,4,2,3,5,2,5,1,4,4,1,3,3,1,1,4,4,4,4,2,4,2,3,5,5,2,1,4,5,5,2,3,3,1,3,5,1,2,1,4,3,1,1,5,2,2,2,5,1,3,5,5,5,1,2,4,2,5,5,1,2,4,3,3,2,4,1,5,3,2,2,5,1,3,4,4,2,1,4,5,1,1,4,3,1,4,4,5,3,1,2,5,3,3,4,4,3,2,1,5,1,5,4,4,4,3,4,3,3,5,1,5,1,5,3,3,5,1,2,2,2,1,1,2,4,3,2,2,4,1,4,3,3,3,1,2,3,4,5,1,5,4,5,2,3,3,5,4,3,1,4,1,2,3,1,1,4,3,4,4,4,3,5,4,5,5,2,3,5,5,4,2,2,4,1,2,1,2,4,4,5,4,5,1,4,2,3,2,4,2,2,4,1,2,3,1,2,5,4,3,2,5,2,4,4,3,5,2,3,4,5,3,4,5,2,1,1,1,5,3,4,4,4,5,2,3,2,4,4,1,3,3,4,4,5,4,2,2,2,2,4,5,4,4,1,4,4,5,3,2,1,4,1,2,3,1,2,3,2,3,2,4,1,1,4,3,3,3,1,1,1,2,5,1,4,3,1,1,3,3,4,5,5,5,5,4,5,4,3,4,2,2,5,3,3,3,2,4,2,5,3,5,5,5,3,3,5,4,2,1,3,4,3,4,1,4,2,5,2,2,2,5,1,3,1,3,3,3,4,4,5,2,5,2,5,3,2,1,4,5,3,3,1,2,5,4,4,5,1,5,1,1,3,5,5,2,1,4,3,3,2,2,1,1,2,3,2,4,4,2,3,1,2,4,2,1,3,4,1,3,5,2,5,4,1,1,2,5,1,2,2,2,1,5,3,2,4,3,5,4,4,5,3,5,1,2,5,1,5,5,5,2,5,3,3,2,2,2,4,3,4,3,1,3,4,2,1,4,2,2,5,1,3,2,1,4,1,5,2,3,1,2,2,3,2,3,1,1,3,3,5,3,4,4,5,2,1,3,3,5,3,5,2,4,1,4,3,2,3,1,4,2,1,1,2,4,3,5,2,2,1,3,5,2,1,1,3,2,4,4,4,3,1,2,1,4,2,2,2,5,3,2,3,2,2,4,1,5,1,2,3,1,2,2,4,5,2,2,2,1,1,5,4,1,1,5,1,4,1,2,4,4,4,5,1,5,3,1,5,5,5,1,1,3,3,3,5,4,2,3,3,1,1,5,5,4,3,5,4,3,1,4,3,3,5,2,2,2,2,1,4,5,1,5,1,5,1,5,5,4,2,4,4,2,2,5,1,1,1,5,3,1,5,4,1,1,4,4,1,2,1,2,2,2,4,3,4,2,4,2,3,4,3,5,2,4,3,4,5,2,2,2,2,1,5,3,5,1,3,3,4,1,3,3,5,5,5,3,4,3,2,4,5,3,2,2,2,2,3,4,5,3,1,2,4,4,1,4,4,5,2,2,1,2,2,2,1,1,2,5,1,3,3,3,2,4,4,2,3,3,4,2,3,2,5,4,4,1,2,4,3,5,5,2,5,3,4,4,4,3,2,1,4,1,4,4,5,3,2,2,3,3,1,2,5,5,4,1,2,2,1,5,5,4,1,4,3,3,1,3,4,2,4,1,3,3,2,5,2,4,3,5,4,3,5,1,3,2,1,5,4,1,3,5,2,2,1,1,3,2,2,1,3,3,2,1,3,5,5,4,1,1,1,2,4,1,4,4,1,3,5,2,1,3,4,2,1,2,3,4,4,1,1,4,5,5,3,5,5,3,5,5,5,1,2,5,1,3,1,2,5,5,1,4,1,2,1,1,1,5,2,1,1,3,3,1,5,3,2,1,4,3,4,1,5,3,5,5,1,5,1,4,5,5,2,3,2,4,4,5,3,2,3,1,5,5,2,1,4,3,5,5,4,5,5,2,5,4,2,2,2,3,5,4,5,4,2,4,3,3,1,2,3,3,1,4,2,4,4,4,5,5,5,5,1,5,5,2,5,1,4,2,3,1,3,1,5,3,4,1,4,3,5,1,3,4,4,3,5,5,4,4,4,2,1,3,2,1,4,3,3,4,2,1,2,2,1,5,5,2,2,4,3,5,5,3,1,1,2,1,2,5,4,5,3,4,2,4,2,5,5,3,4,5,4,3,3,4,1,5,3,1,3,1,2,3,5,1,4,2,4,1,3,4,4,5,1,5,2,2,3,2,1,4,3,1,4,3,1,1,1,3,5,1,4,3,1,5,4,2,3,5,1,3,5,4,1,5,1,4,5,2,2,1,4,3,4,3,3,5,2,3,4,1,4,3,4,4,2,5,4,1,1,1,4,4,4,5,2,4,2,4,3,2,1,2,3,1,2,3,1,3,3,5,3,2,1,5,4,1,5,1,1,5,3,2,1,3,3,4,5,3,5,3,2,1,3,4,5,1,3,5,3,5,1,4,5,5,3,2,2,4,1,1,3,5,5,3,4,2,5,5,3,3,4,2,1,5,3,3,4,2,2,3,2,5,3,1,1,3,4,3,3,4,1,4,3,2,5,2,3,5,4,4,3,5,1,3,2,5,4,5,1,2,5,2,3,4,1,1,3,5,1,1,3,1,2,1,2,4,1,2,5,3,2,4,1,1,5,1,2,2,2,4,2,3,2,5,5,4,1,2,3,3,4,1,2,1,4,3,1,2,3,3,5,1,5,2,3,4,1,1,4,4,1,4,5,3,2,2,2,5,1,1,5,5,1,3,1,1,2,4,2,3,4,2,5,1,5,5,5,4,2,4,3,2,3,1,4,1,2,3,2,3,5,3,1,3,1,5,3,2,2,2,5,4,1,1,1,1,3,3,2,2,4,1,3,1,3,3,1,4,2,1,1,5,1,2,4,4,4,5,2,5,1,2,5,5,3,3,3,2,4,5,1,4,5,4,2,4,3,2,3,4,3,2,4,3,2,5,5,3,1,3,3,2,5,4,5,2,2,5,5,4,3,5,3,5,1,5,5,4,1,3,3,5,1,1,5,1,1,2,5,3,1,1,5,4,4,1,2,5,3,5,5,1,4,3,5,4,1,5,4,3,4,5,2,2,4,5,1,4,2,5,4,3,2,2,1,2,2,3,5,3,4,3,5,3,2,3,3,3,2,3,2,4,5,4,1,5,1,1,5,2,2,2,4,5,3,3,2,5,1,4,2,1,5,2,5,4,2,5,4,2,4,3,4,4,3,3,2,2,5,2,1,1,4,5,4,3,1,3,1,3,4,5,1,3,5,1,5,1,5,4,3,5,1,1,3,1,3,4,5,5,2,2,4,5,5,5,2,3,1,5,3,5,5,4,2,5,4,4,5,5,2,3,5,1,4,5,3,3,1,4,3,2,3,2,2,5,1,1,5,4,3,2,5,5,3,2,4,5,1,1,2,4,4,5,4,4,1,1,2,2,4,5,1,1,3,4,5,4,1,3,3,5,1,5,4,1,1,5,2,1,5,1,3,4,5,2,1,3,1,3,1,3,5,3,1,4,1,3,2,3,5,2,5,4,4,3,5,3,1,5,4,4,5,1,2,2,2,3,2,4,3,4,2,3,5,4,4,3,3,1,5,2,3,3,3,5,2,4,1,3,4,1,2,4,5,4,4,1,5,5,2,3,4,5,3,3,5,2,4,5,1,2,2,2,5,1,4,2,1,1,4,5,3,4,5,5,2,1,5,3,5,3,3,4,3,5,3,3,1,3,3,2,4,2,5,5,3,4,2,5,3,5,2,4,5,5,2,1,4,1,1,4,5,1,5,1,4,5,2,4,1,2,5,3,3,2,4,5,4,4,2,3,2,1,1,4,5,2,1,5,5,3,1,5,1,3,2,3,2,5,4,5,4,3,2,1,3,4,3,1,1,3,5,5,2,5,1,2,2,2,3,3,5,3,3,2,1,3,1,4,3,3,5,5,3,2,2,3,4,1,3,5,4,2,3,2,2,4,4,5,1,5,4,4,5,5,2,3,3,1,4,2,4,1,2,1,4,5,1,4,5,2,5,4,5,3,4,5,5,4,1,4,2,3,5,2,4,5,4,4,2,5,4,2,5,3,3,5,5,2,2,3,1,2,1,5,4,3,4,5,3,4,5,2,2,1,4,3,4,5,5,4,5,3,5,4,4,2,4,3,3,1,3,1,2,4,5,3,1,5,5,4,4,4,4,1,2,3,3,3,1,1,1,3,1,5,2,5,3,5,4,5,1,3,4,3,5,4,4,4,4,4,1,1,5,4,5,1,5,3,2,5,3,4,3,3,3,2,5,3,5,2,4,5,5,4,3,3,5,3,3,2,2,1,1,1,3,5,4,5,2,5,3,3,1,5,2,1,1,2,1,2,3,2,5,3,3,2,3,1,2,4,1,5,3,4,1,5,1,5,4,3,4,5,3,5,2,1,3,3,2,3,5,1,2,5,3,1,1,2,4,5,2,1,5,5,3,5,1,5,3,3,3,1,5,1,4,5,4,1,1,2,1,2,4,3,1,5,3,2,2,2,3,5,2,4,4,1,3,1,5,3,3,3,3,4,4,3,3,5,4,5,2,4,5,4,2,2,1,1,1,2,4,5,4,3,1,3,1,5,3,2,3,5,5,3,2,5,4,3,1,5,3,5,5,5,3,3,4,4,5,2,1,1,3,3,1,5,4,5,4,2,2,5,1,5,4,2,4,2,1,1,5,2,3,4,4,5,4,5,5,3,4,5,1,2,3,5,1,2,3,2,2,2,4,3,1,3,1,3,3,3,2,3,5,3,4,3,3,1,4,1,3,5,4,1,3,3,3,1,3,4,2,4,1,3,5,2,4,5,1,3,1,2,2,5,4,5,3,4,1,2,5,4,2,4,5,4,2,1,5,2,2,3,5,5,2,1,2,5,5,1,2,4,5,5,4,5,5,5,2,4,2,3,3,5,1,3,2,4,5,3,4,1,1,4,2,1,5,5,1,3,4,4,3,5,3,4,4,3,4,2,4,4,1,5,3,5,4,5,1,1,1,5,2,4,1,5,5,4,3,3,1,3,2,5,4,2,1,2,5,2,4,3,5,5,4,3,4,1,3,5,4,5,2,3,1,2,4,5,5,3,2,4,5,3,5,4,5,1,3,3,3,3,2,4,4,5,2,1,3,2,4,5,2,2,1,2,5,1,4,1,1,3,2,5,1,4,3,4,1,1,5,5,3,3,2,1,5,5,1,4,1,3,3,3,4,2,3,3,1,2,4,3,4,1,3,1,3,1,3,1,4,2,3,5,2,5,2,3,5,5,1,1,2,3,2,4,2,2,5,5,2,3,5,3,2,2,5,3,1,3,3,4,1,4,5,3,2,5,4,3,2,2,5,5,3,1,4,2,1,3,1,1,5,4,1,4,5,5,1,5,1,2,5,1,3,4,2,5,4,1,2,3,4,4,2,1,2,4,4,3,1,2,2,2,1,3,4,1,5,5,3,5,3,3,2,2,4,4,2,1,1,4,4,1,2,2,4,1,1,2,4,2,1,4,3,5,2,3,2,1,1,1,1,1,5,5,1,2,4,5,4,2,2,3,5,2,1,2,4,5,5,3,4,1,1,3,5,1,3,5,2,1,1,5,3,5,5,3,3,3,3,5,5,2,3,5,1,5,2,5,5,4,1,3,3,4,5,1,4,1,3,2,2,2,3,1,3,4,4,5,2,1,3,4,1,1,3,3,4,4,2,3,4,3,2,1,5,4,3,1,2,2,3,3,3,1,4,4,2,2,2,2,3,1,4,5,3,4,1,2,2,3,3,2,1,5,4,4,5,4,5,1,5,3,1,4,1,1,5,4,2,1,4,1,3,3,4,4,4,1,2,2,4,3,1,3,4,4,5,1,3,4,3,1,4,1,1,3,1,2,5,1,2,5,2,5,5,2,2,1,2,5,3,1,3,3,1,2,3,3,3,5,3,2,2,4,3,1,2,3,1,5,3,4,1,1,4,2,5,4,3,1,5,3,3,3,2,2,1,2,4,2,2,3,4,1,3,3,3,1,5,3,4,3,3,5,4,3,2,3,5,5,4,3,5,3,5,1,1,2,1,4,1,2,1,5,1,5,3,2,1,1,3,5,4,1,1,3,4,2,1,5,3,3,5,5,2,1,4,1,4,3,1,5,3,5,3,3,4,3,4,4,5,5,5,5,4,1,4,5,4,4,1,5,5,5,1,3,5,3,2,5,3,3,5,4,3,3,2,4,5,1,3,4,2,5,5,3,4,2,3,1,1,5,4,1,2,2,3,5,1,1,5,5,5,4,1,2,4,5,4,3,3,5,4,1,1,1,5,3,5,4,3,1,5,1,5,1,3,5,2,5,5,1,4,3,2,3,2,5,1,1,1,3,1,1,3,3,4,1,5,2,4,5,3,5,1,5,5,2,5,3,1,2,5,3,5,1,1,4,3,1,1,5,5,1,5,4,1,3,4,5,4,1,5,1,3,4,2,4,2,3,1,1,5,4,5,5,3,3,1,3,2,2,3,2,1,2,5,2,4,1,3,5,1,3,2,2,4,2,2,5,3,3,2,5,1,2,5,1,4,4,3,4,4,1,5,1,1,1,3,5,4,1,3,4,3,2,3,3,1,2,2,5,3,3,1,4,5,5,5,4,2,1,5,5,3,3,4,1,1,4,3,3,3,2,5,2,3,2,4,2,5,5,5,1,1,5,4,5,5,4,5,3,4,5,4,2,1,4,5,3,4,2,1,2,2,2,2,3,3,3,5,4,2,1,2,5,3,5,4,2,5,3,4,4,3,2,1,1,1,4,2,5,2,3,3,4,2,5,5,5,2,2,2,3,1,4,5,3,1,4,4,2,3,1,4,3,2,5,3,4,1,3,1,1,3,5,2,1,4,3,2,4,2,3,2,1,3,2,4,4,5,4,2,2,5,5,1,4,2,5,2,5,2,2,2,5,4,3,5,5,5,2,3,4,5,1,4,2,1,1,5,2,3,2,1,1,3,3,3,1,5,5,2,4,4,2,5,4,4,4,4,2,4,3,4,5,2,4,4,4,5,4,2,5,5,2,5,3,2,5,3,5,1,2,4,4,4,4,4,4,1,3,5,3,2,2,5,1,4,1,2,1,1,4,5,3,5,2,4,4,2,1,4,3,4,2,5,5,3,5,1,4,1,2,1,4,3,4,2,5,1,1,2,1,5,5,1,2,3,4,5,4,1,2,4,4,5,3,3,3,5,2,3,4,5,1,5,2,5,3,3,2,2,3,3,4,3,2,1,4,2,2,1,5,4,1,5,4,2,3,5,1,1,4,4,3,4,1,1,3,4,4,4,5,2,3,4,4,5,5,3,2,1,4,3,3,1,1,3,5,1,4,3,4,3,4,4,2,1,3,2,1,3,1,2,5,1,2,1,4,1,4,4,4,1,2,1,3,4,1,5,4,5,3,3,4,5,1,1,2,3,2,2,1,1,2,4,3,3,1,2,3,1,1,3,5,4,3,4,2,1,4,2,4,1,4,1,3,4,1,4,5,5,2,2,5,3,5,2,2,3,3,4,1,5,2,1,5,3,4,2,4,3,4,1,2,5,1,1,5,1,2,5,1,3,3,4,3,5,4,1,4,2,5,4,4,3,3,1,4,5,5,5,4,3,4,1,5,5,2,3,4,3,3,2,3,2,4,1,1,4,1,2,3,2,4,2,2,2,4,2,1,4,2,2,4,1,3,1,4,1,2,3,5,3,5,5,1,2,1,2,4,5,5,5,2,3,3,4,3,2,1,5,1,3,4,2,5,1,3,5,2,1,1,4,2,1,2,5,2,1,4,1,3,4,4,4,1,1,2,5,1,4,1,1,4,2,4,4,4,1,3,5,4,5,5,2,4,3,1,2,5,2,1,2,3,2,5,1,4,5,3,5,2,1,1,5,2,5,5,5,2,4,3,3,4,2,5,4,5,5,4,3,3,1,5,5,5,2,1,3,3,1,3,3,1,4,1,2,1,4,1,1,4,4,5,4,1,2,5,1,2,4,2,1,1,3,5,1,1,3,2,5,2,2,4,3,3,4,3,4,5,3,3,1,3,4,1,5,4,5,1,1,3,5,4,3,4,3,5,3,2,5,4,5,4,2,1,2,2,3,3,1,2,3,5,3,2,1,5,3,5,1,5,1,4,3,5,4,5,2,3,3,2,1,4,5,2,1,4,5,4,5,1,4,2,4,1,5,4,3,4,1,5,2,2,3,3,4,4,2,5,3,1,3,3,3,4,3,1,5,3,4,1,3,2,5,2,3,5,2,3,5,1,4,3,5,3,2,1,1,4,1,2,3,3,3,2,2,2,1,1,3,5,4,1,4,4,4,1,1,5,4,4,3,4,1,2,5,3,5,3,1,4,5,3,1,2,2,3,3,4,4,2,5,1,4,3,1,1,5,5,2,1,3,1,3,2,4,3,4,1,1,5,2,1,1,4,2,1,1,4,4,1,3,1,1,4,2,3,2,5,3,3,3,3,2,4,2,4,2,4,5,2,1,1,3,4,4,3,3,2,2,4,5,3,3,4,1,2,4,3,5,2,1,1,5,3,1,5,5,3,2,5,1,5,1,4,2,5,3,3,4,2,3,2,5,5,1,3,1,4,1,1,3,3,5,3,4,3,4,1,4,4,2,3,2,1,2,2,4,4,5,5,3,1,3,1,4,5,4,3,4,3,1,2,4,1,3,5,4,4,1,4,2,5,1,5,3,3,3,5,5,5,1,5,1,3,4,1,2,2,2,5,5,5,5,2,3,4,4,3,4,5,5,4,4,3,2,1,1,2,2,1,4,4,3,2,4,3,4,4,5,1,1,3,4,1,3,5,5,3,4,1,3,2,3,2,2,4,4,3,4,4,1,1,4,2,3,5,4,1,2,5,3,5,3,4,3,1,3,5,5,5,1,4,2,4,2,3,2,3,3,3,4,5,1,4,1,5,3,4,4,1,1,5,2,3,2,2,5,3,4,5,5,1,2,1,5,2,1,5,1,5,2,4,2,1,5,3,2,3,5,5,3,3,3,1,1,5,2,4,2,2,4,4,2,4,2,2,2,1,3,1,4,1,5,3,3,1,2,2,5,5,4,5,1,4,5,1,1,1,2,3,4,1,5,4,4,1,3,2,3,3,1,3,3,4,3,5,5,3,2,4,3,4,5,5,2,2,4,4,2,4,3,2,1,5,1,2,2,2,2,1,1,2,3,4,4,1,3,1,2,4,4,5,5,3,3,2,2,2,5,2,4,2,3,4,3,5,2,4,5,4,3,2,3,2,2,3,3,3,2,2,5,4,4,4,5,3,2,2,2,3,2,2,1,3,4,2,5,3,5,5,1,5,1,3,2,1,4,5,5,5,5,1,2,1,5,2,1,5,4,3,2,3,3,2,2,2,4,1,5,4,3,5,5,5,1,2,4,5,1,1,2,2,3,2,5,4,2,3,3,5,3,4,1,2,5,4,1,4,3,3,2,2,1,2,1,1,5,5,4,3,2,3,1,4,2,3,4,3,3,4,2,1,3,5,2,2,5,3,3,4,5,4,2,3,5,1,3,2,3,4,3,2,1,5,3,1,2,1,4,5,3,4,5,4,2,2,4,4,5,4,2,5,4,2,2,2,5,3,2,4,4,3,4,1,2,3,2,4,4,4,5,2,1,3,4,4,1,1,5,4,1,3,3,1,2,3,1,2,4,5,1,3,5,1,5,2,4,2,5,2,1,4,1,3,2,5,2,4,2,4,1,4,3,4,4,3,4,4,1,3,4,1,2,1,4,5,5,1,5,1,5,3,4,1,3,4,2,2,3,1,2,4,4,4,1,4,4,2,1,4,4,1,1,1,3,2,5,4,4,2,1,1,5,4,5,5,4,5,1,5,4,5,5,4,3,5,4,1,1,1,4,2,2,3,5,3,1,4,1,1,1,4,3,5,1,3,2,1,2,4,2,4,5,2,5,5,3,1,4,3,5,5,1,3,1,5,1,2,2,4,2,3,2,5,5,4,4,4,1,1,2,2,1,4,3,4,1,2,5,5,5,2,5,3,2,5,2,4,1,4,4,2,4,5,5,1,5,2,2,3,4,3,2,5,2,1,4,4,4,5,4,5,3,1,4,1,3,1,1,5,2,5,4,4,3,3,1,2,2,4,4,3,4,1,1,2,3,2,5,4,1,2,1,2,1,1,2,4,4,2,1,1,2,5,5,5,2,3,2,2,1,4,5,2,3,3,4,3,3,2,2,2,2,2,1,4,5,5,3,5,4,2,4,3,3,4,1,1,4,3,5,4,4,4,5,1,5,5,2,5,5,3,2,5,5,2,4,4,1,4,4,4,2,4,1,2,2,1,3,1,3,4,5,3,2,2,3,4,4,4,2,3,3,1,1,3,3,5,1,1,3,2,1,5,5,4,1,5,2,4,1,5,5,1,1,2,2,1,5,3,4,3,2,1,1,1,1,2,4,1,2,2,2,1,2,5,3,3,4,2,2,5,1,3,5,4,1,4,3,4,4,5,4,2,2,2,2,2,1,5,2,5,1,3,3,3,3,1,1,1,2,5,2,5,3,3,1,4,2,4,2,2,4,1,1,3,4,4,1,2,2,5,2,5,2,5,4,3,1,1,2,1,2,2,4,4,2,3,5,1,3,5,1,1,3,2,2,1,2,4,5,2,1,2,4,5,3,4,1,4,1,5,5,3,2,4,2,4,5,1,5,2,5,5,5,5,2,4,4,3,5,5,2,3,1,4,2,2,3,3,3,5,1,5,1,5,2,3,2,5,1,3,3,1,4,4,5,2,5,1,3,3,4,5,4,2,2,5,5,5,2,2,2,1,2,1,1,1,3,2,3,1,3,1,5,3,1,1,5,2,2,4,5,5,1,1,5,3,5,2,3,2,3,3,1,4,1,4,1,3,5,3,5,5,2,5,2,3,1,3,4,1,4,5,5,1,4,3,2,4,1,4,5,2,1,3,2,5,5,1,2,4,4,2,3,1,1,2,4,1,3,1,4,5,4,2,5,1,5,2,1,4,2,3,4,5,3,2,3,2,4,4,4,1,5,1,2,4,2,2,5,4,3,2,3,5,4,2,3,5,3,5,2,2,1,3,3,4,3,5,3,1,5,4,1,1,1,5,3,5,5,2,1,5,5,5,2,1,1,1,5,5,4,1,5,3,4,3,1,1,1,5,5,4,2,4,4,4,1,2,4,4,2,3,5,3,2,2,5,3,5,5,3,1,2,2,2,3,5,3,5,2,5,3,2,5,2,1,2,1,5,1,3,2,3,3,1,1,2,1,3,3,3,3,5,5,4,3,2,5,3,2,2,3,1,5,1,5,3,5,5,4,2,4,4,4,2,1,5,2,1,5,4,4,2,2,3,1,5,1,2,1,2,4,3,4,3,4,4,5,4,1,2,5,2,4,3,4,1,4,5,4,1,3,5,3,5,5,4,3,1,1,3,4,5,1,2,3,4,5,2,1,4,3,4,3,3,2,5,2,3,5,1,4,3,3,4,2,2,3,5,2,3,5,4,3,1,1,2,5,5,5,4,2,5,5,5,1,4,1,3,5,2,3,2,4,2,3,4,1,4,5,5,2,1,5,4,2,5,4,4,2,4,5,1,3,1,5,2,4,5,1,3,5,3,1,1,5,5,4,3,4,5,5,2,4,4,2,2,5,5,5,5,5,5,4,3,4,1,3,4,3,1,1,5,5,3,4,3,3,2,4,2,4,2,4,5,4,5,1,1,5,3,1,5,3,1,5,4,2,4,3,4,5,3,5,4,4,2,2,3,4,2,3,3,5,5,3,4,4,3,3,3,3,5,4,3,3,5,3,5,4,3,2,5,1,4,2,4,2,1,2,5,2,5,1,5,2,3,3,5,5,1,4,2,3,1,1,3,2,1,1,2,5,3,3,5,1,5,1,5,5,1,2,3,2,4,4,1,5,2,3,4,1,1,1,5,4,4,2,4,2,3,4,2,4,2,1,5,5,5,5,4,5,5,1,3,5,1,3,5,1,3,5,2,3,5,3,3,3,3,1,2,2,4,2,3,5,4,2,5,2,3,5,1,1,1,1,3,3,4,5,4,2,2,4,4,3,5,3,1,2,5,1,5,5,5,3,3,2,5,4,1,1,2,5,5,4,1,4,3,5,3,4,3,1,5,4,5,1,1,1,4,5,2,5,2,3,4,3,1,3,3,3,1,2,4,3,1,2,4,5,4,5,2,4,4,3,1,1,2,5,1,1,1,4,2,4,1,2,1,4,1,5,5,3,3,4,1,3,2,5,1,1,2,3,1,4,4,3,1,1,1,4,2,5,1,2,2,5,4,3,3,3,1,1,2,1,5,5,1,3,1,1,1,2,4,4,4,4,2,2,1,2,3,2,5,3,1,4,3,4,3,4,3,2,5,3,4,2,3,3,4,2,2,2,4,1,5,1,1,1,1,3,2,5,2,4,5,1,1,3,4,2,5,4,4,5,4,2,5,2,3,3,3,4,1,2,5,3,5,2,5,1,3,5,1,2,5,1,3,1,3,5,2,3,5,4,2,4,1,4,5,3,3,3,5,5,3,5,1,3,4,4,3,1,2,3,1,2,5,3,2,1,1,3,2,3,3,5,1,1,4,4,1,3,4,5,4,2,3,1,3,4,4,5,1,5,1,3,1,4,2,1,5,1,4,1,3,2,3,1,2,1,1,4,1,3,3,4,1,3,5,5,3,3,4,1,5,4,2,5,2,1,2,3,4,1,5,1,2,3,1,5,2,2,1,3,1,1,3,3,1,4,5,3,2,2,1,2,4,3,5,1,4,2,3,5,4,2,3,1,4,2,4,2,1,1,1,4,1,4,4,1,3,4,1,1,4,1,1,3,1,5,4,2,3,5,2,1,2,2,2,2,2,5,2,1,1,4,2,5,2,3,3,3,4,5,2,1,1,1,5,1,3,1,2,1,1,5,3,2,5,2,4,4,1,1,2,3,3,3,3,4,4,4,4,2,2,2,3,4,2,3,1,2,2,4,5,5,1,3,5,2,5,1,3,4,2,3,3,1,2,5,5,3,5,4,2,1,1,3,4,3,2,3,4,3,2,4,2,1,2,2,1,2,3,2,2,2,2,4,2,2,4,5,4,5,3,2,4,4,4,1,2,3,2,1,5,3,5,2,4,2,5,1,3,4,4,2,5,2,4,4,4,5,4,2,3,2,5,1,1,2,2,4,2,5,1,2,4,5,5,1,2,1,1,5,3,2,2,5,2,1,1,5,3,5,2,2,1,4,2,2,2,1,4,4,5,5,3,2,4,5,3,3,1,3,1,4,4,1,2,2,2,3,3,2,4,1,3,1,1,4,1,1,1,4,4,2,2,4,4,5,5,1,1,1,4,1,4,3,4,1,4,2,5,5,4,5,3,1,5,1,4,5,3,4,5,3,1,3,2,3,1,5,3,5,4,4,5,4,1,1,2,4,3,5,4,5,3,1,2,1,4,1,1,2,3,4,4,4,2,2,2,4,3,1,2,3,1,2,1,4,2,1,4,2,1,4,3,4,2,4,3,2,4,3,4,2,5,2,3,5,4,3,4,4,4,2,4,2,5,5,4,3,2,1,3,5,5,4,4,3,2,3,3,3,5,5,4,5,1,1,1,4,2,5,5,2,2,4,1,3,2,1,4,3,1,4,4,2,4,1,1,4,2,1,3,1,3,1,4,2,3,5,1,4,3,2,2,3,2,3,3,2,2,4,2,5,2,4,2,3,3,1,1,5,2,4,2,3,4,1,4,5,1,5,3,3,2,2,4,1,3,3,3,5,3,1,3,5,3,5,2,2,2,1,3,5,4,4,1,5,5,2,4,4,4,1,2,3,5,5,4,3,1,1,2,2,2,5,5,3,2,2,3,3,5,3,4,1,4,5,3,4,4,1,4,5,3,5,1,1,5,1,1,2,1,2,5,5,5,4,3,2,3,1,4,4,5,1,2,5,3,3,2,3,2,1,3,1,5,3,3,2,1,5,4,2,2,2,3,1,2,4,2,5,4,5,2,2,2,5,1,5,4,4,4,1,2,1,5,3,3,3,1,3,3,4,2,5,1,4,1,4,4,4,5,1,2,4,1,1,4,1,4,1,1,1,2,4,5,3,2,3,3,3,5,2,1,5,1,1,5,1,3,4,4,3,2,4,2,3,1,2,1,4,4,1,1,3,4,3,5,4,4,5,5,2,5,5,2,2,1,3,2,5,1,2,4,2,2,3,4,5,4,2,5,2,3,3,3,5,3,4,2,3,3,5,1,3,2,3,4,3,3,1,4,4,1,4,2,3,3,5,2,3,2,4,5,3,4,5,2,5,3,2,4,2,2,2,2,4,5,3,3,4,2,5,5,3,1,4,1,1,3,4,4,3,3,5,2,3,3,1,3,4,2,2,1,5,3,1,1,5,3,4,5,4,3,4,2,4,4,4,2,4,5,4,3,1,1,2,4,1,1,4,3,4,5,1,4,5,2,2,2,4,3,4,3,2,1,1,4,1,4,4,2,1,2,3,1,5,2,3,2,5,2,1,2,4,5,5,1,1,3,5,4,1,4,2,5,2,2,1,1,1,2,1,2,5,4,2,5,5,3,4,2,1,3,5,5,5,2,2,5,1,4,2,4,1,5,1,5,3,4,3,2,4,4,5,5,5,5,5,1,3,2,4,5,1,1,2,1,5,2,2,1,3,3,5,5,1,5,3,1,1,3,2,3,2,3,2,2,3,1,4,2,5,4,5,2,5,2,1,1,2,5,1,3,3,5,2,2,2,3,4,1,1,1,5,3,2,5,5,5,1,3,1,2,1,1,5,2,3,2,3,3,3,4,3,3,2,3,2,2,4,1,1,4,4,4,4,2,1,1,1,5,3,4,4,1,4,4,1,3,5,1,1,3,5,2,3,5,3,1,4,2,1,3,5,1,4,5,4,5,4,3,4,4,1,4,3,2,5,5,2,4,1,1,2,1,3,1,1,3,4,2,3,3,2,4,5,1,2,5,5,5,2,2,1,5,3,1,5,4,4,1,4,5,3,2,5,4,3,4,2,4,5,1,4,1,2,2,2,5,1,2,4,1,4,5,1,2,2,3,2,4,2,5,4,4,1,1,2,5,2,2,5,3,1,5,3,2,1,3,4,5,4,5,5,1,2,5,4,2,1,2,5,2,4,4,2,3,4,5,4,3,3,4,2,3,1,3,5,3,5,2,1,3,1,5,4,4,3,2,5,1,5,1,4,1,2,3,1,4,2,3,4,3,1,5,3,3,5,4,5,5,2,5,1,1,2,5,1,1,3,4,2,4,5,5,4,1,5,5,3,1,5,1,5,3,3,3,5,3,2,5,4,4,3,2,2,1,2,5,2,3,3,2,4,3,4,2,5,4,1,3,2,5,5,5,2,2,1,4,5,2,5,1,5,3,5,4,5,3,3,5,3,4,1,1,5,2,3,2,4,3,1,4,5,3,2,3,1,4,3,5,5,5,1,2,3,4,1,3,3,3,3,4,2,5,4,1,4,1,2,2,2,3,5,1,2,1,5,5,2,3,3,4,2,2,5,2,4,3,4,4,3,2,3,4,2,4,4,1,4,4,1,5,3,2,3,2,1,3,1,4,3,3,3,4,2,5,1,3,3,1,3,5,2,5,2,5,2,4,2,2,2,2,3,3,1,1,3,5,5,4,4,3,1,1,4,4,2,4,5,4,2,4,2,2,3,4,3,4,1,4,4,5,4,4,5,3,2,2,5,3,4,2,3,3,4,5,3,2,1,4,1,3,3,5,5,2,5,3,4,5,1,4,5,4,1,4,2,5,5,3,1,5,4,5,4,1,1,1,2,2,4,2,2,4,5,5,1,4,5,1,2,5,3,2,5,4,2,5,1,1,4,2,5,1,1,5,1,5,1,2,3,2,1,5,1,4,1,5,1,1,3,3,1,3,5,1,3,1,1,1,4,2,1,3,4,4,2,1,3,3,4,1,2,3,5,4,4,3,3,5,5,1,2,3,3,4,5,5,3,1,5,2,2,2,1,4,3,4,1,5,1,3,5,5,1,5,1,5,2,5,2,3,4,2,5,1,1,3,4,4,3,2,1,1,1,1,2,2,4,4,2,2,3,2,4,4,1,4,4,5,3,3,1,4,5,2,4,1,5,2,3,2,1,3,3,5,1,1,2,2,3,1,2,3,1,2,4,3,1,4,1,4,2,2,4,2,1,5,2,5,2,1,4,2,5,5,3,4,1,2,5,4,2,4,3,1,4,3,4,5,1,5,3,4,3,2,4,1,5,1,4,5,3,2,1,2,1,4,2,3,2,5,2,1,1,3,2,2,3,2,3,2,1,2,4,1,4,1,2,3,4,3,5,4,3,4,3,3,2,5,4,4,5,5,3,4,1,3,2,1,1,2,1,1,1,5,1,2,1,4,5,3,3,5,1,3,2,3,2,3,3,2,1,3,3,5,1,5,5,1,1,5,4,4,3,5,5,1,1,2,1,5,5,2,5,1,2,1,4,1,5,4,4,5,4,3,3,3,4,3,1,1,1,2,5,1,1,4,3,4,4,4,2,2,4,2,1,1,1,3,2,2,3,3,5,5,3,5,3,5,1,5,1,2,2,1,3,3,2,3,4,3,3,5,1,3,5,5,3,3,2,1,1,5,1,2,1,4,3,3,5,5,4,3,5,2,3,4,4,3,5,1,1,4,2,3,3,2,4,1,5,3,5,4,5,4,2,2,3,5,1,3,4,5,4,2,2,2,2,4,2,4,5,3,1,2,2,4,1,3,1,3,2,5,4,2,5,4,5,1,1,3,3,1,4,2,2,5,4,4,3,3,2,3,5,5,2,2,5,2,3,3,4,2,5,3,4,4,3,4,4,4,2,2,5,5,2,5,4,1,4,3,5,4,5,3,3,2,2,3,1,4,4,2,2,4,3,5,5,1,2,2,1,1,1,5,3,3,5,3,2,3,4,2,5,4,1,2,1,2,2,1,2,5,5,1,2,2,5,1,2,4,3,2,5,1,1,5,3,2,2,3,5,1,2,4,4,1,3,5,2,1,3,2,3,1,1,5,4,1,5,3,4,4,2,1,4,2,5,5,2,2,1,1,4,3,4,1,2,1,2,2,4,4,4,3,4,2,2,1,1,3,2,3,3,2,1,1,5,4,2,4,5,3,3,3,4,3,4,1,2,3,1,2,4,4,4,5,2,5,1,3,4,5,4,1,3,5,1,5,4,4,4,4,2,4,3,5,4,1,2,1,4,4,3,5,2,3,2,5,1,5,3,3,4,4,1,4,1,1,4,1,5,3,1,1,5,4,4,5,3,5,1,4,1,1,1,5,5,1,3,2,5,3,2,3,2,1,3,2,5,5,2,1,1,4,3,4,2,5,2,1,1,5,4,2,2,5,5,2,3,3,4,4,1,5,4,2,3,2,1,3,3,5,4,4,3,5,4,4,2,2,5,4,4,4,4,4,3,3,2,1,5,2,1,4,3,4,4,5,5,1,5,5,2,1,4,2,2,1,1,4,2,4,4,4,1,3,3,5,4,1,4,3,2,5,4,4,1,3,3,2,5,1,1,5,5,2,5,5,1,5,2,5,2,5,3,5,1,1,4,1,1,5,4,1,2,2,2,2,2,2,1,4,2,5,4,3,2,5,5,2,3,5,1,2,1,4,4,4,4,1,2,3,4,1,3,2,2,3,5,4,4,1,2,4,1,3,1,3,5,2,4,1,2,4,3,4,5,5,5,1,1,3,2,2,5,3,2,3,3,4,1,3,5,3,2,3,5,4,2,4,1,2,3,1,1,1,2,3,5,2,4,4,4,1,3,5,2,1,4,1,2,1,4,4,3,2,2,1,4,3,2,3,1,3,5,1,1,2,2,1,2,5,4,4,2,2,4,3,1,4,4,4,4,5,3,2,1,3,1,3,4,5,4,3,4,2,5,1,3,5,5,1,4,4,1,5,5,2,4,2,2,4,5,3,2,5,4,4,3,3,1,2,4,2,3,5,1,2,1,1,5,5,5,2,2,5,2,4,2,2,1,5,3,4,5,1,1,4,4,4,4,5,5,1,1,4,5,4,5,1,5,2,1,1,3,2,3,3,5,3,3,4,2,1,1,1,2,4,3,4,5,5,2,2,3,2,4,1,4,1,4,5,2,3,4,4,5,1,4,4,4,2,1,4,3,5,1,3,4,1,5,1,1,5,1,5,2,3,5,1,3,2,4,3,2,2,2,1,4,4,2,5,2,5,2,1,2,1,1,4,4,3,1,3,5,2,2,3,1,3,4,5,5,4,5,5,1,1,1,3,3,3,5,3,3,3,4,3,3,2,5,4,5,4,5,2,4,3,2,5,2,5,3,3,4,4,3,2,3,5,1,3,5,2,3,3,5,5,1,3,4,3,3,1,5,3,4,2,4,3,3,2,2,3,2,2,4,1,1,5,3,3,2,5,3,4,4,3,1,5,3,4,3,1,1,5,1,4,1,3,4,4,3,3,1,1,2,5,4,2,2,2,4,2,5,3,4,1,1,2,4,3,1,4,4,1,2,3,5,3,2,4,4,4,1,5,5,4,2,2,1,3,1,1,3,3,2,5,3,4,3,1,3,4,1,5,2,5,4,3,5,2,4,5,2,3,3,3,2,3,5,5,3,5,5,4,5,3,3,1,1,5,5,3,3,2,5,3,4,4,1,2,3,1,2,2,5,1,2,4,3,5,5,5,3,4,4,2,2,2,3,2,2,2,1,2,2,3,3,4,1,4,1,2,5,2,3,1,1,5,4,3,1,2,2,2,2,1,4,1,4,5,3,2,4,3,5,4,4,4,4,4,2,4,1,1,4,2,2,1,1,5,5,4,3,4,4,5,1,5,5,4,2,4,3,1,1,3,2,3,5,3,2,1,3,3,3,3,1,1,2,5,1,4,3,5,5,2,2,4,1,2,4,3,5,3,2,3,2,3,1,4,4,5,3,5,2,2,2,4,2,5,2,1,2,1,5,5,2,2,2,3,1,5,2,2,1,5,1,1,5,1,5,2,1,4,1,4,5,4,1,4,2,2,2,5,5,4,5,3,4,5,2,1,1,5,1,1,2,2,3,4,2,5,4,1,4,1,2,5,4,3,4,2,4,5,4,3,1,4,4,5,5,1,5,4,3,3,3,1,1,1,1,4,2,5,3,2,1,4,4,5,1,1,3,3,5,3,2,5,5,2,2,2,3,3,4,3,5,5,1,5,2,3,4,1,3,3,3,2,1,1,1,4,4,4,5,5,2,4,5,4,3,1,1,5,5,2,3,2,4,1,2,3,4,5,2,5,5,3,2,4,3,1,2,3,1,5,1,1,5,3,1,3,2,5,5,4,1,1,1,4,5,2,2,5,2,1,4,2,5,4,5,5,1,2,3,3,3,2,3,1,5,2,2,2,1,4,1,4,4,5,2,4,1,1,1,5,2,5,1,1,4,2,1,3,2,4,3,1,5,5,2,2,1,3,3,2,1,2,3,3,4,4,1,2,2,5,1,4,3,1,4,3,1,2,2,1,4,5,5,3,5,3,4,3,2,4,4,4,5,2,5,3,3,2,3,1,2,1,1,5,4,4,3,3,4,5,2,2,4,2,2,4,2,3,1,3,3,3,4,2,3,5,3,1,3,4,4,2,4,2,2,5,1,5,1,4,4,4,3,3,3,3,2,1,1,3,1,4,2,5,2,2,2,3,1,5,1,5,2,4,4,2,3,3,3,4,2,4,5,4,1,5,4,3,5,2,2,4,2,5,1,1,4,5,1,3,4,2,4,5,1,5,1,3,2,1,3,5,4,3,5,2,3,4,2,4,4,4,1,3,1,4,3,3,1,3,4,2,5,2,4,2,3,5,5,3,4,2,2,4,3,5,3,3,1,2,2,3,3,3,4,3,5,2,4,5,3,1,4,4,3,5,1,2,3,5,5,1,5,3,2,2,5,3,1,3,3,5,1,2,1,1,2,2,5,4,3,4,1,5,1,1,1,4,4,4,2,5,1,1,2,5,3,3,2,5,5,2,3,4,5,2,2,5,4,1,2,2,2,5,4,2,1,3,4,3,1,4,4,1,2,3,1,3,1,3,2,4,5,3,5,5,5,4,4,5,4,1,4,3,1,4,4,2,4,3,2,2,3,2,5,3,5,1,1,4,5,3,5,5,2,2,3,2,1,2,5,5,2,1,4,4,4,3,3,5,1,3,4,5,4,1,4,3,2,3,1,2,5,5,1,5,5,5,2,1,2,3,4,5,2,1,5,3,1,5,3,1,4,3,2,2,3,4,1,5,2,1,4,5,3,2,4,4,4,3,2,3,1,2,5,2,4,3,2,5,5,2,2,4,5,3,1,1,2,2,5,5,2,2,1,1,4,5,1,4,5,2,4,5,5,2,2,2,5,1,5,1,2,1,4,5,1,1,2,3,2,2,1,3,4,1,3,1,4,1,3,3,5,3,5,4,4,5,5,3,1,1,4,1,1,4,5,3,3,1,4,5,4,3,3,5,4,2,2,3,4,1,5,3,2,4,5,1,4,1,5,5,2,3,3,5,3,1,3,3,5,4,4,4,2,4,2,3,5,3,4,2,5,4,5,5,4,4,2,2,4,2,5,5,5,5,2,3,1,1,4,2,5,5,2,2,2,5,2,4,1,1,1,4,5,4,3,5,4,2,4,2,4,5,1,3,3,5,1,2,3,1,5,4,4,5,4,3,3,1,4,5,3,4,2,3,3,2,4,5,4,3,1,3,1,3,3,5,1,4,5,5,1,4,1,1,1,1,1,5,2,2,4,4,2,2,3,3,4,2,1,3,5,3,5,4,2,1,5,5,5,4,3,5,3,4,5,2,3,1,4,2,1,1,4,3,5,1,5,3,5,1,5,5,2,2,2,1,4,5,5,5,1,3,1,2,5,3,2,5,3,5,3,5,5,4,5,2,4,2,1,4,5,2,5,5,5,1,4,3,1,3,1,2,5,2,1,4,4,2,1,4,4,3,4,5,2,3,5,5,4,5,4,1,4,3,3,2,4,2,3,3,4,2,1,2,4,5,5,5,1,1,1,1,2,5,5,3,5,4,2,1,2,4,1,4,5,2,1,2,3,1,5,1,4,5,5,5,4,5,3,4,5,3,2,1,4,1,4,5,1,1,5,2,2,1,5,2,2,2,5,3,3,4,5,3,2,4,5,1,5,3,3,3,1,2,1,4,3,3,4,4,4,5,2,2,3,1,5,4,4,1,5,3,2,1,2,1,4,3,4,3,4,3,5,3,4,4,1,3,2,2,5,5,3,2,1,4,2,3,3,4,5,4,2,4,3,3,4,2,4,3,3,4,4,1,3,2,4,2,5,3,2,2,4,3,3,5,3,5,4,5,5,3,2,3,4,2,4,1,1,4,4,3,3,2,3,4,3,2,3,4,4,3,4,1,2,4,5,3,2,4,4,2,2,5,5,3,2,2,2,1,1,5,4,4,2,2,3,5,4,4,2,4,4,4,1,5,3,1,2,3,1,5,3,5,4,5,1,1,2,1,2,1,3,3,2,3,5,4,3,1,5,4,2,1,4,1,2,5,4,2,4,4,2,4,1,3,3,1,5,5,1,4,5,3,5,5,3,2,3,3,2,5,1,4,3,2,2,4,1,2,2,2,3,2,1,2,1,1,4,5,2,1,5,5,3,2,3,2,3,4,4,5,1,3,1,2,4,4,5,4,2,4,4,4,3,4,5,1,1,2,3,3,1,5,3,4,4,5,1,3,5,5,2,3,4,4,5,1,4,5,4,2,1,5,5,3,4,1,4,4,2,2,1,1,3,2,4,3,2,5,2,2,4,2,3,2,4,2,2,5,5,2,5,3,4,5,1,5,2,3,4,4,2,4,4,4,4,2,3,2,1,5,5,4,3,3,1,5,4,2,5,3,4,4,4,4,1,1,2,4,2,4,5,1,2,5,2,1,4,2,2,2,5,2,4,3,1,2,5,2,5,1,3,4,5,2,3,3,1,1,5,1,1,3,1,3,3,3,1,5,2,1,5,4,5,1,5,5,5,4,5,3,2,4,5,4,3,1,2,4,4,4,1,4,1,1,1,3,1,1,1,2,3,1,4,5,4,2,5,2,5,5,5,2,4,1,2,1,4,4,1,3,1,5,3,4,1,3,2,5,2,4,4,2,5,5,4,5,3,1,2,5,4,4,2,4,1,2,3,5,4,3,3,5,3,1,4,2,1,3,5,1,2,4,1,5,3,2,4,5,5,4,5,3,3,3,4,4,4,2,5,4,5,1,1,1,2,3,4,1,5,4,2,3,1,4,3,2,3,1,2,4,2,4,2,3,1,5,2,1,3,3,5,2,3,3,2,2,4,3,3,5,4,1,1,3,2,4,1,3,4,4,1,5,1,3,1,1,4,2,4,4,3,5,4,4,4,1,2,2,1,5,2,2,2,2,3,2,4,2,1,4,4,5,2,4,3,1,2,1,5,3,3,2,2,1,3,3,3,4,3,1,3,1,1,3,4,3,3,2,4,5,5,2,3,4,1,1,3,3,2,3,4,1,3,5,4,5,2,5,2,1,4,4,1,3,3,2,5,4,2,5,1,3,2,5,3,4,2,2,4,4,4,3,2,2,5,1,4,3,3,2,5,2,5,3,2,5,4,3,2,2,4,4,4,3,1,5,2,4,1,2,4,1,5,4,4,5,2,3,3,2,3,3,3,5,1,3,2,2,1,2,2,3,3,3,4,3,4,4,1,5,3,1,3,4,3,4,1,5,1,3,3,1,1,4,4,5,3,5,4,5,2,5,1,1,5,1,4,2,4,5,3,2,1,2,2,5,3,2,5,5,1,4,4,5,2,1,2,1,2,5,4,4,2,4,4,3,5,4,3,2,5,4,4,3,3,3,5,3,1,1,2,3,4,1,1,5,3,5,2,5,4,5,2,5,2,2,5,3,1,2,4,3,1,2,2,3,2,3,3,2,3,4,2,4,5,5,4,4,3,5,3,1,3,2,3,5,2,4,3,5,1,4,1,5,3,3,5,5,5,2,2,5,3,5,1,1,5,1,2,2,1,2,3,4,5,2,1,2,2,4,3,4,4,5,1,3,2,5,4,3,2,4,3,1,5,1,1,1,1,5,2,2,1,5,4,5,3,1,5,1,1,3,2,1,4,3,4,5,4,3,5,4,5,2,5,5,1,3,3,4,1,2,2,2,5,3,2,4,5,5,3,2,5,4,3,4,2,3,1,2,3,3,2,2,1,2,3,5,5,3,2,5,5,4,5,2,3,4,2,5,5,2,1,4,5,5,1,5,4,4,5,4,4,2,1,3,1,5,2,1,2,2,1,1,4,1,1,4,2,1,1,2,2,2,1,4,1,3,4,1,1,3,2,2,2,1,2,5,4,4,3,3,1,2,1,3,3,2,4,1,1,1,3,1,2,4,2,1,5,2,4,1,1,2,2,1,3,2,3,4,5,4,2,2,1,4,4,1,2,4,2,1,3,1,3,2,2,4,4,3,2,2,5,3,5,3,4,1,1,3,4,1,3,1,5,3,4,5,1,1,2,4,5,1,1,3,3,4,5,1,4,5,2,1,1,5,3,5,5,3,2,2,4,5,2,5,3,2,1,5,4,5,4,5,4,4,2,1,3,5,2,4,2,1,2,2,5,5,1,4,1,5,3,1,4,1,3,2,1,4,3,5,4,1,5,5,2,4,3,4,1,4,2,2,2,1,2,4,3,1,5,2,3,3,2,2,4,4,2,4,4,5,4,1,1,3,5,1,3,5,1,2,4,3,4,3,2,3,4,2,3,2,2,5,5,1,3,2,2,1,3,1,3,2,4,5,2,4,4,4,5,4,5,4,3,5,3,2,1,5,3,5,5,5,4,5,4,1,2,2,1,1,2,3,1,1,4,2,5,5,5,4,1,2,3,1,5,4,4,1,5,4,1,2,4,2,4,5,2,3,2,1,4,5,3,2,5,3,2,5,5,4,4,3,4,5,3,1,4,5,5,4,5,1,2,4,5,4,3,5,5,5,1,3,2,3,5,4,4,2,3,4,3,3,2,2,4,2,2,2,1,2,5,3,1,5,5,1,5,5,1,1,5,1,1,4,1,1,3,2,4,4,2,2,5,3,2,4,2,4,3,5,2,4,4,4,2,3,4,1,4,2,1,3,5,2,5,3,3,4,3,4,5,3,5,4,5,4,3,2,2,4,2,5,2,4,2,5,3,2,4,2,3,1,5,2,1,3,1,4,4,5,4,3,2,5,3,3,2,5,4,4,3,1,1,1,1,1,1,5,3,5,5,1,3,5,1,5,3,4,3,2,2,5,1,4,5,2,2,4,2,3,4,2,2,2,2,4,3,4,2,5,1,5,4,2,5,5,2,5,5,5,3,1,1,5,4,4,3,3,5,4,1,2,5,5,5,3,3,1,4,1,2,3,1,1,1,2,4,2,4,4,4,1,5,3,2,2,2,4,2,1,2,3,1,3,4,4,2,5,3,2,4,1,4,1,2,3,4,4,4,2,1,1,1,4,1,1,5,5,3,3,1,1,1,3,3,5,5,5,1,2,4,1,2,2,5,2,1,5,4,5,4,2,3,1,1,5,2,1,5,1,5,4,5,1,4,5,1,1,1,4,1,4,1,3,4,2,3,1,4,5,4,2,2,3,3,5,5,5,4,2,5,2,4,4,3,1,1,4,2,4,2,3,1,1,2,4,1,5,1,2,2,4,4,3,4,5,5,5,3,1,3,1,4,3,5,1,1,5,2,5,4,1,3,5,2,4,2,4,1,4,2,4,5,5,1,3,4,1,3,4,4,5,4,2,5,4,3,1,5,5,2,2,3,5,4,1,3,3,4,3,5,5,5,4,2,5,1,4,5,1,5,2,4,3,3,2,5,5,3,5,3,3,2,4,3,4,4,5,3,4,5,3,3,5,2,3,3,2,5,5,3,5,3,4,2,2,4,3,2,5,1,1,1,2,3,4,4,3,1,1,5,5,1,5,1,1,2,3,4,2,3,1,3,5,2,3,4,2,3,1,5,3,5,2,3,2,1,5,3,3,1,3,2,1,2,1,3,4,2,5,1,2,3,4,1,2,2,3,1,2,4,3,3,2,1,2,5,1,2,3,3,5,3,3,2,2,1,4,4,2,4,2,2,2,2,2,3,4,5,4,1,4,1,2,5,3,2,2,2,1,3,4,3,1,5,3,1,1,1,3,1,3,5,4,3,4,5,3,2,3,2,1,4,1,2,4,4,1,2,5,4,2,3,4,3,3,4,2,3,1,2,5,4,4,1,5,2,1,4,1,4,4,5,3,3,1,4,4,5,1,2,3,4,4,3,1,1,4,3,5,3,2,5,4,1,5,5,4,2,4,4,5,1,4,3,5,5,3,3,3,2,2,5,2,5,4,1,2,1,5,3,5,3,2,5,1,2,2,1,5,1,1,4,2,2,3,2,4,1,2,1,3,3,5,4,3,4,2,5,2,1,3,3,3,5,4,3,2,5,1,2,2,3,2,1,4,3,4,4,5,4,3,3,5,3,1,5,1,2,4,3,4,5,3,3,1,1,3,2,4,2,4,5,3,5,4,5,2,1,1,1,2,4,4,5,4,3,4,5,4,2,4,2,5,4,1,1,4,5,5,4,5,3,4,4,4,2,5,1,2,5,1,5,4,5,5,1,2,2,4,3,5,4,5,5,1,5,5,5,5,1,4,5,1,1,1,1,2,5,1,2,3,3,3,5,1,5,4,2,1,1,3,4,5,3,4,3,2,2,3,4,2,1,5,3,2,2,5,1,4,3,1,5,1,1,3,2,3,2,5,2,1,4,2,5,4,2,5,2,1,1,5,1,1,1,2,2,4,1,5,1,4,1,5,2,1,1,4,5,4,1,4,2,2,4,5,5,1,5,4,2,5,2,5,2,2,3,4,2,1,5,3,5,4,3,1,4,4,3,3,1,3,4,5,5,1,3,1,3,4,3,4,2,5,4,4,2,3,4,2,3,1,4,5,4,4,4,4,1,5,1,2,5,3,3,4,3,1,2,1,2,1,4,2,4,5,2,1,3,2,5,5,1,4,2,4,4,3,5,2,5,1,1,1,4,1,5,3,1,1,5,5,2,3,1,2,5,3,4,4,3,4,4,2,4,1,3,1,1,5,3,5,1,4,3,2,5,2,4,2,1,4,5,2,2,4,5,3,2,1,5,4,1,5,5,5,2,5,5,1,4,2,2,2,4,5,3,5,3,4,4,3,2,4,3,3,5,1,2,4,1,3,2,4,2,1,5,3,3,1,3,5,3,5,2,4,5,5,1,5,3,5,5,1,4,3,4,2,3,2,4,3,4,2,4,1,3,4,5,5,5,2,5,2,5,4,5,3,2,5,2,3,5,5,5,3,1,2,1,5,5,1,3,3,1,3,5,2,5,4,3,2,4,4,5,3,4,2,5,3,5,3,3,2,2,3,1,4,4,1,3,3,2,3,5,1,3,5,2,5,3,2,5,4,1,2,1,1,1,4,5,2,5,3,3,3,3,1,5,3,4,2,5,1,3,1,2,3,5,4,2,1,3,4,5,5,3,2,2,3,3,3,1,3,2,4,3,2,1,1,3,1,5,3,3,5,5,2,2,2,2,5,3,2,5,3,3,4,5,5,1,2,4,2,4,4,5,2,2,4,2,5,5,5,2,1,5,5,1,1,3,4,1,2,3,1,3,5,1,1,3,3,5,4,4,5,2,4,5,1,4,4,3,2,4,3,3,1,2,2,5,3,1,1,1,2,3,3,2,4,3,2,4,1,1,5,3,5,2,3,4,4,2,1,3,4,4,2,5,2,5,1,2,3,1,3,5,5,4,4,4,4,1,5,1,1,3,5,1,1,5,3,2,3,4,2,4,2,5,3,4,5,1,5,3,5,5,1,5,5,2,5,2,4,3,3,1,5,5,2,2,5,5,1,1,4,2,5,3,3,4,1,5,4,1,1,4,3,1,5,4,5,2,2,2,2,4,4,5,2,5,1,3,3,4,4,1,1,5,2,4,1,2,1,1,1,5,2,3,3,4,4,5,4,2,3,4,3,3,5,4,3,4,4,3,4,4,1,4,3,2,3,1,4,5,4,3,1,3,4,1,1,1,1,3,2,4,4,4,2,5,2,3,5,4,1,3,2,5,5,4,2,1,3,1,2,2,4,5,5,1,3,5,4,5,4,4,5,3,5,5,3,2,4,4,3,1,2,5,5,2,1,2,3,4,2,2,5,1,5,5,1,1,2,5,1,3,1,1,5,5,3,5,3,3,1,2,1,5,3,3,4,2,1,1,5,1,1,2,2,1,4,4,2,3,4,4,1,3,3,2,2,2,3,5,4,2,5,4,3,5,1,5,3,4,1,4,4,5,4,1,1,5,2,1,5,2,2,2,3,5,5,4,2,1,4,3,5,3,3,1,5,1,4,4,5,2,4,1,5,5,3,2,5,3,5,1,3,1,2,4,3,3,1,1,1,1,4,5,2,5,1,2,2,5,1,4,5,4,1,2,1,4,5,4,3,2,3,5,3,4,2,4,4,4,1,5,5,3,3,3,3,4,3,2,3,4,1,3,1,3,3,3,2,5,5,5,3,1,3,4,5,3,3,3,4,3,1,2,1,5,3,1,1,1,2,5,4,3,5,5,2,2,4,1,5,3,3,1,4,4,5,3,3,4,2,2,1,2,4,3,3,3,2,1,3,3,5,4,3,4,5,1,1,3,4,3,5,1,3,5,1,2,5,3,4,1,1,1,5,3,2,2,1,2,3,2,1,4,1,5,1,3,3,2,4,5,5,2,3,4,3,1,1,4,1,1,3,2,3,1,4,3,5,2,4,5,4,1,2,3,4,2,5,5,4,3,1,2,1,4,1,3,3,5,2,2,5,3,5,3,5,4,4,2,4,1,1,3,2,3,4,4,5,1,1,4,2,3,1,1,1,5,1,4,2,3,2,1,5,1,4,3,4,1,5,5,4,1,4,3,1,1,3,4,1,1,4,4,1,1,1,4,1,4,4,1,5,2,4,2,1,1,1,2,4,5,5,3,4,4,5,1,4,2,4,2,5,1,3,3,3,1,4,2,3,1,4,2,2,1,3,1,1,2,3,2,4,4,5,5,3,3,3,3,3,4,5,2,1,5,2,5,2,3,2,1,1,3,1,5,2,4,1,2,5,1,5,2,2,4,5,2,5,4,2,5,3,3,3,5,3,2,1,1,2,2,5,4,2,2,4,3,1,4,4,5,4,4,3,1,1,2,3,1,5,4,4,2,3,2,2,5,3,1,2,5,3,1,2,4,3,4,4,1,3,2,3,2,2,3,5,5,5,4,4,5,3,4,3,4,5,1,5,4,1,4,5,1,4,3,1,3,1,2,1,5,4,5,4,1,1,2,2,4,5,2,5,1,2,5,3,1,2,1,1,4,5,3,4,2,3,4,5,3,4,4,3,2,3,2,5,4,3,3,5,2,2,5,4,2,3,2,4,4,2,2,2,1,5,4,1,1,3,2,3,2,4,5,4,5,2,4,3,4,1,4,2,4,1,4,1,4,4,4,3,2,1,4,4,2,4,5,3,2,3,5,3,1,3,5,1,3,1,4,1,1,4,4,5,2,4,5,3,1,2,2,5,3,2,5,3,5,4,3,2,5,5,2,1,2,4,4,1,4,3,1,2,3,1,3,2,4,4,5,2,3,5,2,1,1,3,1,2,5,2,1,5,3,1,2,1,3,3,3,3,5,2,3,2,3,4,3,5,4,1,3,4,5,1,5,2,4,3,1,4,2,2,4,2,5,4,1,1,2,4,2,4,1,1,1,5,4,1,2,1,3,4,4,4,2,4,1,2,2,1,2,2,3,5,3,3,3,5,3,1,2,2,4,1,5,3,4,3,2,4,4,3,4,4,2,4,3,1,1,3,3,2,4,4,2,5,5,5,4,1,3,4,5,5,5,3,1,3,1,4,1,1,1,1,5,4,5,4,1,4,1,4,2,5,4,3,2,3,1,2,1,4,4,3,4,2,5,5,5,4,1,3,1,5,3,2,1,5,5,4,3,3,3,2,3,2,3,3,1,4,3,5,5,3,4,2,5,5,5,1,1,2,5,5,5,2,4,4,2,3,5,2,2,4,1,3,5,3,2,5,2,3,1,5,2,4,3,5,5,5,2,1,4,1,5,2,4,1,1,3,4,2,4,2,4,5,5,3,3,1,1,1,5,5,2,1,5,1,4,4,3,2,4,4,1,4,5,4,2,3,3,5,5,2,4,1,3,2,5,1,5,1,1,1,2,4,4,2,1,5,3,3,1,2,2,3,5,2,4,1,2,4,2,2,1,1,1,1,2,2,4,4,3,4,1,4,1,1,3,2,1,5,5,2,1,2,5,1,1,2,2,2,1,1,4,1,4,5,5,4,2,4,1,2,5,1,1,3,4,4,4,5,5,2,3,5,2,5,5,5,2,5,1,1,3,3,2,2,4,4,3,5,2,3,1,4,5,2,5,2,3,2,1,2,1,2,3,4,1,1,1,3,2,1,2,2,3,3,4,4,5,2,4,1,4,5,5,4,2,4,2,4,3,2,1,3,3,2,1,1,2,4,3,3,4,5,5,1,2,2,5,3,2,1,2,4,5,1,2,1,2,3,4,1,4,4,3,2,2,5,2,2,2,4,4,3,5,3,2,5,1,5,1,2,1,4,3,5,3,3,4,4,4,1,4,3,2,4,5,4,4,1,4,3,3,5,5,4,5,3,5,2,5,3,3,1,2,2,1,4,5,2,2,3,4,5,5,3,1,3,4,4,5,4,3,2,4,3,5,2,3,2,1,5,5,4,3,3,1,3,2,4,4,3,1,1,3,5,1,4,3,4,4,5,5,5,3,2,1,4,3,5,3,2,5,5,5,2,5,1,3,5,4,4,2,3,2,3,4,2,4,2,3,5,4,1,2,5,5,2,5,5,5,2,2,5,5,1,2,4,4,4,1,5,3,4,5,5,5,4,3,4,5,1,3,3,3,5,5,3,2,2,3,2,4,2,4,3,3,4,1,2,2,3,1,3,2,2,3,3,2,3,1,3,2,3,1,3,1,3,3,1,5,5,5,5,3,5,3,2,2,5,1,4,1,2,3,1,3,2,2,1,1,5,3,5,3,3,2,3,3,5,5,1,5,1,3,2,1,2,2,2,5,1,3,3,2,2,5,5,5,1,2,2,4,4,5,5,2,5,4,5,5,5,2,5,2,3,5,1,1,1,4,2,4,5,5,2,3,2,2,4,3,2,3,1,5,1,4,3,5,5,4,1,5,5,5,5,5,3,4,1,1,2,4,2,1,4,3,5,1,3,1,4,1,4,5,1,5,4,3,1,3,5,5,2,4,5,1,5,2,5,4,5,1,3,1,3,5,5,5,5,2,2,3,3,4,4,2,2,1,2,1,4,1,3,2,2,2,5,2,3,5,1,1,2,4,5,4,3,3,5,3,3,2,1,3,5,4,1,2,4,4,5,1,2,3,5,4,2,3,5,3,3,3,1,2,4,3,5,4,5,1,5,1,3,5,2,3,5,5,4,2,5,1,2,5,5,1,3,1,4,3,2,2,1,4,1,3,3,1,5,2,2,3,4,1,5,5,4,1,5,5,4,3,4,1,1,5,5,1,4,2,1,3,4,3,5,1,4,5,4,1,1,1,2,3,3,3,4,1,5,1,4,3,4,2,1,2,3,5,2,2,3,1,5,5,3,3,1,3,4,3,4,1,5,3,2,4,4,1,1,3,4,2,5,4,5,2,2,4,2,5,3,1,5,3,5,3,1,2,5,5,3,3,3,4,1,5,1,2,1,4,3,2,2,2,5,5,2,3,3,4,2,5,5,1,2,5,3,3,4,2,2,5,5,1,1,3,3,4,1,3,4,4,2,1,5,5,2,3,2,4,1,2,1,2,3,3,5,4,2,2,3,3,4,3,2,3,3,2,4,5,5,2,1,1,4,3,1,5,1,5,3,2,3,5,5,2,1,5,4,4,3,2,5,5,1,2,1,5,2,4,1,2,1,5,2,4,2,4,5,2,3,2,2,3,3,3,4,5,2,5,3,3,5,1,3,2,2,2,1,2,4,2,4,3,1,3,4,1,1,5,4,4,5,5,2,1,4,4,2,2,4,3,3,1,4,4,5,2,4,5,3,3,4,2,2,4,2,2,1,2,4,5,2,3,4,1,4,5,4,4,2,3,1,3,4,3,4,2,3,4,5,5,5,5,3,4,5,3,3,1,5,3,1,5,1,4,4,5,5,4,1,1,5,1,2,1,1,4,1,5,4,2,3,1,4,3,3,2,2,2,2,5,4,1,2,2,4,2,2,2,5,4,5,2,3,3,3,5,4,5,3,3,5,3,2,5,5,3,5,3,1,2,4,1,5,3,4,2,2,4,2,1,1,5,4,3,4,3,4,5,4,2,3,2,3,1,2,1,2,5,5,2,3,4,5,4,1,4,1,1,1,1,2,1,1,2,2,3,3,5,5,5,2,3,5,5,3,1,5,4,1,1,1,1,2,5,4,4,1,2,4,4,1,4,3,5,2,1,1,3,3,1,3,4,5,5,3,5,4,4,1,3,1,4,3,1,1,3,3,1,1,3,2,4,5,5,4,3,5,5,4,4,5,5,4,4,2,3,4,1,3,5,3,5,2,2,4,5,3,3,2,5,4,1,4,3,1,1,4,5,5,2,5,3,5,4,5,3,2,2,4,2,4,1,3,1,3,4,5,3,1,5,1,2,4,5,3,2,4,1,2,1,3,5,4,2,1,2,2,2,2,2,3,3,5,1,1,2,4,1,1,4,1,3,4,2,5,5,2,1,3,4,2,3,1,4,3,4,4,2,1,5,3,5,2,4,1,1,1,3,5,3,2,2,5,5,1,3,1,4,5,5,5,3,5,4,4,1,3,3,1,2,2,3,5,4,4,3,4,3,1,3,4,2,3,5,1,4,2,1,4,3,3,2,4,5,3,5,3,2,4,5,5,4,3,5,5,4,3,4,4,2,2,3,2,5,4,2,4,2,2,3,4,1,4,2,1,4,1,3,3,5,4,5,3,1,2,1,1,3,2,3,5,3,3,3,2,2,5,2,4,5,5,3,3,4,1,5,5,5,2,3,5,3,1,3,4,4,5,4,2,2,5,5,2,1,2,4,5,3,2,4,4,3,1,4,2,4,2,3,1,3,2,4,5,3,4,4,2,1,2,3,3,5,1,1,2,4,1,5,2,2,4,2,3,2,2,4,2,2,5,4,5,5,1,4,2,3,2,4,1,4,5,2,2,4,5,5,1,1,2,1,5,4,2,5,1,1,1,4,5,1,3,3,4,5,4,2,1,2,5,1,2,3,4,1,3,5,3,1,1,1,2,1,2,4,5,3,2,2,5,2,3,4,3,5,1,1,2,4,5,3,3,4,1,2,1,5,1,2,2,2,3,2,3,3,5,4,3,2,5,5,3,3,4,2,4,1,2,4,1,1,4,1,3,5,3,2,1,3,5,1,4,4,3,1,4,5,2,1,5,2,5,2,4,4,4,3,5,5,5,1,4,2,2,5,5,3,4,5,3,1,1,2,1,2,1,1,2,5,5,2,3,3,1,2,3,4,3,2,5,5,2,1,5,3,2,1,1,3,3,2,1,5,1,4,5,4,5,2,5,3,1,1,5,3,4,5,4,4,2,1,3,3,4,3,2,1,1,1,1,5,1,5,5,4,1,4,2,1,2,3,5,4,4,5,3,4,3,4,5,2,3,4,1,4,5,5,2,3,3,5,4,2,2,1,2,2,4,5,4,3,4,4,4,1,1,4,4,5,4,1,1,2,4,4,3,5,3,5,1,4,3,3,5,1,2,5,3,2,5,3,2,3,5,2,1,5,2,2,2,4,2,2,2,2,1,1,5,1,4,1,1,3,2,4,2,5,2,2,2,5,3,4,5,5,1,1,5,3,2,3,5,3,1,5,3,4,3,2,2,4,4,2,4,5,1,5,5,5,4,4,4,4,1,5,2,3,2,5,4,5,5,4,1,4,5,2,5,5,2,2,2,4,2,5,2,5,2,5,2,3,3,3,4,5,2,3,5,5,1,3,5,1,4,5,1,5,2,4,4,4,5,4,5,3,4,1,4,5,2,4,5,2,5,3,1,1,1,2,3,4,2,3,5,2,1,1,3,5,2,4,3,3,1,4,2,1,3,5,2,5,5,2,2,1,5,2,4,4,3,4,2,1,2,5,4,2,3,2,3,2,3,4,3,3,2,4,4,1,3,5,5,4,3,5,3,5,4,3,5,3,1,5,4,4,3,5,4,5,5,3,5,3,2,2,1,3,1,2,3,3,5,5,2,4,5,1,1,2,4,3,3,5,4,1,4,2,4,4,5,3,1,1,3,1,4,3,4,5,2,3,5,5,1,4,4,2,5,5,2,1,4,2,4,1,1,1,4,2,1,1,2,1,2,2,5,1,5,1,3,4,4,2,4,2,2,1,1,5,4,4,1,4,3,2,2,3,1,3,2,2,5,4,2,5,2,5,4,3,4,4,4,3,3,5,3,2,5,1,5,1,5,1,1,5,5,4,3,3,4,3,1,1,3,5,2,3,4,3,5,4,1,2,1,2,1,5,3,2,3,3,2,1,1,2,2,5,4,5,4,1,5,1,3,3,4,1,5,3,4,2,5,2,5,5,3,4,4,2,1,2,3,2,3,2,5,4,2,3,5,5,2,5,3,5,2,1,5,5,4,4,2,4,2,2,2,1,2,4,3,2,5,4,5,1,4,2,1,5,2,4,1,2,1,2,4,2,1,2,5,1,5,2,3,4,3,1,3,4,1,2,1,2,4,1,4,4,1,2,4,2,5,5,1,5,2,4,5,1,3,1,2,4,5,4,1,5,1,5,2,2,1,2,3,5,1,1,5,5,2,4,2,4,3,1,5,4,4,2,2,1,3,3,4,2,3,5,1,1,2,3,3,4,1,5,1,3,3,1,2,4,2,1,5,4,2,5,3,1,3,3,5,2,4,2,3,2,2,5,1,5,2,1,2,5,2,5,3,2,1,3,3,5,4,4,5,3,1,1,3,2,3,2,4,4,4,4,5,2,2,3,3,2,3,4,2,3,1,2,1,2,1,4,2,5,2,3,2,1,3,4,4,5,3,1,4,1,2,2,5,4,4,2,3,4,3,1,5,5,4,2,5,1,5,5,1,5,2,5,2,5,4,3,4,1,1,1,2,1,5,5,5,1,5,1,2,4,1,2,2,5,1,4,4,4,3,1,5,5,1,1,5,4,4,1,2,1,5,3,1,3,4,3,4,5,4,1,3,5,3,2,5,1,1,4,2,5,4,3,5,5,2,5,1,1,3,5,3,4,1,1,5,1,1,4,1,3,5,5,4,4,2,3,1,5,2,1,4,1,2,5,1,1,4,5,2,5,2,2,3,3,4,5,1,5,1,1,4,2,4,1,1,4,1,2,5,2,4,2,3,3,5,3,4,1,3,5,2,4,1,4,5,1,3,4,2,2,3,5,2,5,2,1,2,2,2,5,5,5,4,5,2,4,1,5,4,4,2,4,2,5,5,3,3,2,1,5,1,1,1,4,3,3,3,1,1,3,3,5,1,2,4,4,3,1,4,4,1,2,3,1,3,5,4,1,4,3,5,5,4,5,1,1,1,2,2,1,3,3,5,1,4,5,5,2,5,5,5,2,5,1,1,2,3,4,4,3,2,4,5,4,5,4,3,3,5,3,5,2,3,1,2,1,4,1,4,5,2,2,3,1,3,1,4,4,1,5,1,5,5,3,5,3,2,3,5,4,1,5,2,5,1,1,4,4,2,3,4,2,2,1,3,2,5,4,5,3,3,4,4,5,5,3,2,4,2,2,1,3,2,5,3,5,2,5,3,5,2,1,3,1,4,3,1,4,3,4,3,2,1,1,2,5,2,3,3,5,5,5,2,5,5,2,1,2,2,2,5,3,5,5,4,4,4,3,4,5,1,3,5,3,4,5,5,3,4,5,3,5,2,5,1,3,3,4,2,3,3,4,3,5,2,2,1,1,1,1,1,1,5,1,4,5,5,5,4,3,5,3,3,4,3,5,2,4,2,3,5,1,2,2,1,3,2,4,3,5,2,1,1,5,2,3,2,3,4,5,3,2,5,1,1,4,2,1,5,3,3,5,2,3,5,4,2,3,1,1,4,1,2,5,3,1,3,1,3,5,3,1,3,1,4,2,5,2,2,5,3,1,4,3,2,1,3,4,1,5,2,1,2,3,5,1,2,2,1,5,5,3,4,2,2,1,1,1,1,1,3,1,5,3,4,3,5,5,5,1,1,3,1,4,5,4,3,5,2,4,1,3,5,2,2,2,2,3,2,1,3,3,3,1,4,4,2,3,2,5,4,4,1,1,4,1,1,3,1,4,1,1,4,1,2,2,5,3,5,3,1,2,5,1,5,5,4,4,2,5,2,5,5,5,2,1,1,1,1,2,5,3,2,3,1,3,5,2,4,2,2,1,2,4,2,1,2,5,4,1,5,3,1,3,5,5,4,1,2,2,2,3,2,1,2,3,4,2,3,3,1,2,4,1,2,4,4,4,1,2,4,1,4,2,2,4,1,5,2,5,4,1,3,5,4,4,5,5,5,4,1,1,4,5,4,4,3,3,5,3,5,5,3,4,2,5,3,2,4,2,4,4,2,2,3,4,5,1,2,1,3,3,3,4,3,1,1,1,3,5,3,1,5,1,1,1,3,3,5,1,5,2,1,3,4,3,5,1,4,2,3,2,3,2,4,3,3,5,4,5,3,2,4,3,3,5,4,5,2,5,3,3,1,3,1,3,5,2,4,5,1,3,4,3,3,1,1,2,4,3,5,2,4,2,2,2,1,3,5,1,3,1,2,3,5,2,1,2,1,4,1,3,5,4,5,3,5,4,2,2,3,4,4,3,3,5,4,5,5,4,4,3,5,3,4,1,4,2,5,5,2,2,3,4,1,1,2,1,3,2,2,4,3,2,4,3,3,2,1,1,1,2,4,1,1,3,4,5,4,3,1,2,1,1,1,3,3,2,5,2,1,5,4,5,1,2,2,4,3,5,3,4,1,2,3,1,2,3,5,2,3,3,1,5,2,5,5,1,2,5,1,1,3,4,4,5,4,5,3,5,2,1,1,4,4,5,2,5,2,1,1,2,3,3,1,5,4,2,2,4,4,2,4,4,3,3,4,2,4,2,5,1,2,2,5,2,1,4,2,1,1,3,3,2,2,1,4,5,5,5,1,3,2,2,1,5,5,2,4,1,2,5,2,3,4,3,4,2,1,1,3,4,5,4,3,4,5,2,2,4,4,2,5,4,4,2,3,4,4,2,2,3,5,5,1,1,4,5,2,5,5,4,4,1,1,3,4,3,4,2,4,3,4,2,1,4,4,3,1,2,1,3,3,3,4,2,2,3,1,2,3,2,1,5,4,5,4,2,5,1,3,2,5,1,2,4,1,2,5,1,1,3,5,4,3,1,5,1,2,1,1,5,5,5,5,1,4,2,2,5,5,3,2,1,5,5,4,1,4,3,5,5,4,5,5,4,1,1,5,3,2,3,1,2,3,4,3,1,1,3,4,1,3,1,1,5,2,3,4,1,3,3,1,2,3,3,5,5,3,4,1,2,2,3,5,2,2,3,5,3,1,2,5,5,3,1,3,3,2,4,1,4,1,4,3,2,4,5,4,2,2,1,1,4,1,2,1,2,4,3,4,5,1,1,5,3,1,2,4,3,5,5,5,3,4,4,2,4,4,5,2,3,5,3,3,1,1,5,1,1,3,5,3,3,1,3,5,1,1,2,3,3,4,5,2,5,2,2,1,5,4,2,2,1,4,5,4,1,5,4,5,4,3,5,2,1,1,3,5,3,4,3,1,4,4,5,2,3,1,5,5,3,3,5,2,2,4,2,4,2,3,4,5,1,3,5,2,2,1,5,1,2,4,3,2,4,5,1,5,1,4,4,5,5,5,5,3,5,4,5,2,2,5,5,2,5,3,3,2,1,2,2,1,4,3,4,1,1,4,3,4,3,5,2,3,3,2,1,5,4,4,4,5,5,1,5,5,1,5,3,3,1,3,2,3,5,1,4,5,2,3,5,1,3,2,3,1,1,4,5,4,2,5,2,4,2,5,5,5,1,2,3,1,5,3,3,5,5,2,4,3,5,1,1,4,2,2,2,2,5,5,1,2,1,3,3,1,1,4,1,4,1,5,3,2,2,2,1,1,2,1,2,4,3,1,3,2,5,2,4,4,1,5,2,5,1,2,3,3,2,2,1,5,2,3,5,3,4,1,1,4,1,1,3,2,5,2,1,2,2,1,4,1,3,5,1,2,2,1,3,4,4,5,2,4,1,4,3,1,1,1,4,1,4,2,3,4,5,3,1,3,2,5,2,2,3,4,2,2,3,1,5,4,3,4,4,3,1,1,1,5,2,3,5,5,3,4,3,2,4,5,3,2,5,3,5,1,4,4,4,1,1,2,2,3,4,2,2,3,4,5,1,4,1,5,1,5,3,4,4,5,1,1,2,3,2,5,4,3,1,5,2,3,4,5,3,3,3,5,5,3,4,1,3,1,3,2,2,5,5,1,1,2,1,3,2,3,4,2,1,1,3,1,4,3,5,3,2,5,3,5,4,3,4,4,1,2,4,2,4,1,2,3,4,4,4,1,4,3,2,1,2,4,2,5,1,4,2,4,5,2,3,2,3,5,3,1,3,4,4,2,2,2,1,1,1,4,2,5,2,5,1,5,5,2,5,5,5,1,5,4,5,1,5,3,2,1,2,3,4,2,5,2,4,1,4,3,4,4,2,1,2,5,2,2,2,2,4,3,5,3,1,4,4,5,2,2,3,1,5,1,1,4,3,5,1,5,1,3,1,5,5,5,1,2,1,4,5,3,5,3,4,5,3,1,3,3,3,4,4,4,2,1,5,2,4,2,3,4,2,1,2,2,4,4,4,4,3,1,2,4,1,3,1,3,3,1,2,1,3,2,4,1,3,1,2,2,5,3,5,4,1,2,4,5,3,1,3,1,4,5,2,5,5,3,3,1,4,4,3,4,4,4,1,4,2,1,3,2,5,2,3,3,1,5,5,4,5,3,4,4,4,1,5,4,5,1,5,4,2,3,2,4,5,5,2,2,1,5,2,3,3,5,2,5,1,5,3,1,3,3,5,4,5,4,1,1,3,4,5,4,2,4,2,2,5,1,1,2,3,1,1,1,5,1,5,2,1,1,1,3,4,1,4,2,3,5,2,3,5,1,5,5,5,1,2,4,2,1,1,1,4,2,3,2,2,2,1,4,4,2,1,5,5,5,2,5,1,1,3,2,3,1,1,4,4,1,3,3,5,1,1,5,3,1,4,5,5,2,2,1,3,3,1,5,4,4,3,2,2,5,3,3,4,4,3,1,4,1,5,2,1,5,3,1,1,3,1,5,1,2,1,2,1,4,1,2,1,4,5,1,1,4,3,4,3,4,4,1,5,1,5,1,1,1,5,5,5,4,3,4,2,3,4,4,1,1,5,4,5,4,4,4,5,1,1,1,1,2,3,2,2,3,4,4,1,5,3,3,4,1,1,5,5,3,5,1,4,1,3,1,5,3,3,4,5,5,4,4,4,3,4,2,4,3,1,2,2,5,3,1,4,4,5,4,4,1,1,1,2,1,5,3,2,3,2,5,2,3,5,5,3,2,3,2,1,1,4,5,5,1,2,2,1,3,3,4,2,1,5,2,1,5,5,1,4,3,3,3,1,2,2,4,5,2,1,3,1,5,4,4,5,3,2,3,3,2,3,3,4,3,4,3,4,4,2,4,1,1,1,2,5,5,4,1,3,2,4,3,4,5,1,2,1,5,4,1,2,5,2,3,3,1,5,3,2,3,1,1,3,1,4,5,2,3,4,5,5,1,1,3,4,1,1,3,5,5,4,4,4,5,4,2,3,2,4,1,3,2,2,1,3,4,5,3,4,1,4,1,2,4,3,4,2,3,1,4,1,3,1,4,2,5,4,2,2,2,5,2,4,3,2,3,2,3,4,2,2,4,3,5,4,3,2,5,3,4,2,2,5,5,2,3,4,4,3,1,2,5,1,4,5,2,3,4,4,1,2,4,2,2,3,2,4,5,1,2,1,3,4,2,3,1,2,1,3,3,5,5,4,1,1,5,2,4,1,3,5,1,5,5,3,5,1,4,2,5,2,5,4,4,1,3,2,2,3,3,4,3,2,3,5,1,5,2,2,1,1,2,3,5,3,2,4,5,3,2,2,5,2,2,3,1,4,2,5,3,3,1,1,3,2,4,1,2,2,5,4,5,5,1,2,1,4,2,4,4,3,2,2,4,1,1,1,5,1,5,1,2,4,4,1,3,4,4,4,2,2,4,5,1,2,1,3,2,4,2,3,2,5,4,5,4,5,3,5,2,4,3,5,4,2,1,3,2,1,4,3,2,3,1,4,5,2,1,4,3,4,1,4,4,2,2,5,1,1,3,5,5,5,1,3,4,2,1,5,2,5,4,2,1,4,2,3,2,4,3,4,2,4,4,1,1,5,2,4,2,2,3,1,5,5,1,1,4,1,1,5,2,1,2,3,2,5,3,2,3,4,1,1,4,3,2,2,3,3,1,1,2,2,5,2,4,5,3,4,4,2,1,4,5,2,4,5,3,2,1,2,4,4,3,2,2,1,5,5,4,4,1,5,5,2,5,2,1,5,4,2,1,2,5,4,5,3,5,2,2,1,2,5,3,3,4,4,3,1,1,3,1,5,2,1,5,3,1,1,3,4,2,4,4,3,2,5,5,3,3,3,1,2,2,5,1,4,4,4,2,4,2,5,2,3,5,5,2,3,4,2,1,1,5,4,1,2,4,3,2,5,3,5,5,5,1,1,5,3,2,2,3,4,1,5,3,3,2,1,3,3,2,2,5,1,3,1,5,5,4,4,1,4,4,2,2,5,5,1,5,2,4,2,1,4,3,1,3,4,5,5,2,2,5,3,3,3,1,3,5,1,3,2,4,4,3,5,2,1,2,3,2,5,2,5,2,5,4,5,3,4,1,5,5,2,5,4,2,3,2,5,5,3,2,2,5,3,3,1,2,1,2,1,4,2,1,3,1,2,2,3,5,1,2,3,1,3,5,1,2,1,1,1,4,1,1,4,1,1,5,1,1,3,2,2,1,3,5,2,3,3,4,2,3,5,3,2,3,5,5,2,3,4,5,2,2,3,4,1,1,2,4,3,4,3,5,2,3,2,2,3,2,3,5,1,4,1,4,2,3,4,5,5,1,2,5,3,2,5,4,1,4,3,5,3,2,4,1,2,4,3,5,3,4,4,4,3,2,5,4,5,4,2,5,5,3,5,5,2,1,4,5,5,1,5,4,5,2,5,2,4,1,5,2,1,4,5,5,5,1,2,2,3,5,5,3,1,2,3,5,2,5,2,2,4,3,1,1,3,3,4,2,1,5,5,1,3,1,5,3,3,4,2,3,5,4,4,4,5,4,2,5,3,2,4,2,1,4,3,3,5,1,4,2,4,1,1,5,3,3,3,3,4,4,3,2,5,4,1,2,2,5,4,4,4,3,2,3,3,2,1,2,2,2,1,1,4,1,4,1,1,1,2,3,2,3,1,5,1,4,2,4,2,4,2,2,4,2,3,2,5,5,4,1,1,3,5,5,2,5,5,3,1,1,1,1,4,4,5,3,1,4,4,1,3,2,5,1,5,1,2,4,5,3,1,5,2,3,1,3,5,3,5,5,2,2,1,5,3,5,4,3,4,4,4,5,1,4,4,1,5,2,2,4,2,1,3,3,3,3,3,2,3,3,5,2,2,1,3,1,5,3,4,4,4,1,1,2,2,1,3,4,1,5,1,4,2,1,4,4,1,2,4,5,3,2,2,2,5,1,1,2,5,2,3,2,5,1,2,2,1,4,4,1,3,5,5,3,5,1,1,1,2,4,4,5,5,3,3,1,4,3,5,1,4,4,2,5,4,3,3,3,1,3,3,2,5,5,3,2,4,1,3,2,5,4,5,5,1,5,4,1,5,5,3,2,1,1,3,4,2,4,4,3,1,4,4,1,3,2,1,5,5,4,4,5,4,1,3,1,1,4,1,1,3,4,1,3,2,4,1,1,5,1,3,2,5,3,3,4,1,3,2,1,3,4,1,4,3,4,2,5,5,5,3,2,3,2,2,5,4,1,1,4,3,5,4,2,2,4,3,5,3,1,5,1,1,3,1,3,5,5,5,4,2,5,5,5,3,2,1,4,3,3,4,4,5,4,5,3,3,1,2,2,1,2,2,5,3,3,2,1,4,2,5,4,5,2,3,2,2,1,1,1,2,1,2,1,1,2,4,5,5,2,4,2,2,1,3,3,2,5,1,2,5,1,4,1,4,2,1,4,1,4,4,1,4,2,5,4,4,2,5,1,4,4,3,3,2,2,2,1,4,1,4,2,1,1,3,4,2,3,4,1,3,5,4,4,5,2,4,2,4,5,2,2,1,4,5,4,2,3,4,1,2,5,5,3,1,1,1,4,4,3,3,4,2,1,2,1,2,2,5,2,4,2,5,5,1,5,4,3,1,3,5,1,4,2,3,2,3,2,3,5,5,3,4,3,1,3,4,5,3,3,2,1,3,5,5,4,1,3,2,1,4,4,2,1,1,4,4,1,1,5,2,4,5,5,2,1,5,2,2,1,4,5,2,4,2,2,1,3,2,3,4,1,4,1,1,2,5,4,3,4,4,3,4,1,3,2,2,5,5,3,5,5,2,1,1,1,5,1,3,4,5,4,3,4,4,3,3,1,3,1,5,2,4,4,5,4,5,2,5,4,2,3,2,3,2,4,3,5,2,3,2,5,3,5,1,2,1,3,5,2,2,3,4,4,2,2,1,1,1,4,1,3,5,4,1,4,5,3,2,2,5,4,2,3,3,1,3,1,5,4,5,4,4,2,3,2,3,1,4,1,2,3,5,1,1,4,2,2,1,3,2,5,2,3,4,1,2,4,5,1,4,3,1,5,4,5,5,1,2,1,3,3,1,4,1,5,1,4,5,5,3,3,5,5,2,5,1,2,4,5,5,5,4,2,3,3,4,1,4,5,3,4,1,4,2,1,4,2,2,5,5,2,2,3,2,2,4,3,5,3,3,5,4,1,5,2,1,1,4,3,2,5,3,2,1,1,5,3,4,4,1,1,1,4,5,1,1,4,4,3,2,3,4,1,2,2,1,3,5,4,2,5,3,1,5,3,2,5,2,4,2,1,1,5,1,5,5,5,2,2,1,3,5,4,2,1,4,1,3,2,1,1,4,2,3,2,3,3,5,3,1,5,4,3,3,3,2,5,1,3,4,4,1,3,2,2,5,1,1,4,1,3,3,1,1,4,5,2,3,1,2,3,1,1,1,1,3,1,3,3,2,5,1,3,5,1,2,2,3,3,4,1,5,5,2,3,3,2,5,4,4,5,2,1,3,3,5,5,2,3,2,3,2,5,5,2,4,2,1,3,5,3,2,5,3,1,2,3,1,4,5,3,1,4,4,1,2,1,1,1,1,5,2,4,5,5,4,5,5,1,1,3,2,2,1,4,2,5,3,4,2,4,3,5,1,5,5,2,4,1,3,2,4,3,2,2,3,5,3,1,2,4,2,3,3,4,5,2,5,3,1,1,3,1,2,5,2,4,4,4,1,3,3,1,4,2,4,1,2,3,3,5,3,3,5,3,5,2,4,1,4,2,3,2,4,5,2,1,5,5,3,2,2,3,1,2,5,4,5,4,3,3,3,2,4,4,2,4,1,1,2,5,3,5,1,2,2,4,2,1,1,3,1,3,2,4,4,1,4,2,4,1,4,2,4,3,2,5,1,2,4,1,5,3,4,3,2,3,5,2,4,3,5,4,2,2,1,4,4,5,2,1,2,3,2,2,4,1,4,2,2,1,2,4,2,2,1,4,4,2,3,4,3,5,5,1,3,3,5,3,3,5,1,4,2,1,3,1,1,5,5,2,5,3,4,4,5,3,3,4,2,2,3,3,3,3,1,1,3,2,2,4,4,1,1,4,4,3,4,5,5,1,5,3,3,5,3,4,4,5,5,3,1,3,3,4,3,1,3,5,5,4,5,5,2,2,5,5,3,5,3,1,2,4,4,1,5,2,4,2,2,3,4,4,1,2,2,4,5,3,1,5,3,1,5,5,1,1,5,3,3,2,2,4,5,2,5,4,5,2,2,5,5,4,2,2,3,4,2,4,5,1,2,1,3,5,2,2,2,2,3,2,3,5,2,3,1,5,5,4,4,3,5,2,4,1,1,5,5,1,3,2,3,4,3,1,2,1,5,1,4,1,2,1,5,5,4,5,1,4,3,3,5,5,3,3,3,5,4,2,2,3,3,5,1,5,3,3,1,5,1,1,2,5,5,5,2,4,5,4,2,4,2,5,2,5,2,3,4,2,4,4,1,3,1,2,5,1,4,5,3,2,2,4,3,5,3,5,2,3,3,3,3,3,2,5,3,5,3,3,3,5,5,5,1,3,1,1,4,3,3,5,4,5,3,1,5,2,5,2,3,5,1,2,3,3,2,4,5,5,4,2,2,1,5,5,2,1,1,2,1,1,2,2,1,4,2,1,4,3,1,1,3,3,2,5,4,5,3,4,3,2,5,2,2,5,2,1,3,4,5,3,1,3,3,5,2,3,4,1,4,5,3,1,5,3,3,4,4,1,4,5,4,3,4,2,3,5,4,5,4,1,4,5,5,5,4,4,3,3,4,2,3,1,3,5,5,2,1,2,1,5,2,2,2,5,3,5,4,2,2,5,4,2,2,1,3,2,1,5,2,5,5,3,3,1,5,5,2,5,2,4,5,5,2,5,2,3,5,3,5,5,2,4,3,5,3,2,4,2,2,3,4,2,5,2,5,2,4,4,2,4,1,5,2,3,1,3,3,1,2,3,3,3,2,3,5,5,1,5,2,1,5,4,2,1,3,4,2,4,1,3,2,2,5,3,1,4,4,3,1,3,5,1,4,4,1,2,3,3,1,2,5,3,2,3,4,4,4,1,2,2,1,4,5,5,2,2,5,2,4,3,4,5,5,3,5,1,2,2,1,3,4,4,2,5,2,3,2,2,2,4,5,3,5,4,1,4,5,3,3,3,1,2,3,1,4,2,2,3,1,5,3,4,1,2,1,5,2,1,2,1,3,2,2,2,2,5,1,3,2,5,1,4,1,1,1,1,1,4,1,2,1,1,3,4,3,2,1,1,5,4,5,5,4,2,4,4,3,1,3,1,4,1,4,2,3,5,1,1,5,5,5,2,1,5,1,5,5,1,1,1,4,5,1,1,1,1,1,5,1,1,4,2,3,2,4,1,4,2,1,4,3,4,5,3,3,1,5,3,5,4,2,5,2,1,3,4,2,5,4,4,1,4,4,1,3,2,3,2,4,4,1,4,5,5,1,4,1,3,5,4,2,5,3,2,5,1,4,3,5,1,3,1,1,2,2,4,1,2,3,3,5,4,3,1,3,1,3,3,5,1,3,2,1,1,4,1,3,3,2,5,4,2,3,1,3,3,4,2,3,3,3,2,2,5,3,3,4,1,5,2,1,2,2,1,1,4,5,4,5,1,1,1,3,1,3,3,2,1,4,2,2,3,1,2,1,3,1,1,5,3,4,3,4,5,1,2,3,2,5,3,5,5,5,5,2,4,4,5,5,5,1,1,3,5,5,5,1,2,1,3,3,2,1,2,2,5,5,5,3,1,2,2,4,5,5,4,1,4,4,3,1,2,1,2,2,5,2,1,4,4,5,3,5,2,5,1,5,2,5,2,1,1,2,4,2,3,4,2,5,4,1,4,1,3,3,2,4,1,4,1,1,3,5,3,3,4,2,5,4,3,3,3,2,5,3,1,3,3,2,2,1,2,5,3,1,1,1,1,2,5,3,4,1,4,3,3,3,2,4,3,5,4,2,5,5,5,1,2,4,4,3,4,5,1,4,3,1,1,2,1,1,1,4,3,4,4,1,5,5,3,2,4,5,3,1,4,2,2,2,5,4,5,1,2,1,4,4,4,3,5,4,2,5,5,5,3,3,2,4,4,3,4,1,4,3,2,2,5,5,3,3,3,3,2,4,3,2,5,1,3,5,5,5,5,1,5,1,4,2,5,4,5,2,3,1,3,3,1,1,2,2,2,3,1,1,5,3,4,2,5,5,2,1,1,3,2,4,4,5,5,4,4,3,5,4,3,2,2,4,2,2,1,1,2,5,4,3,3,5,1,2,2,4,5,5,1,3,1,5,3,3,1,3,4,1,2,3,2,1,3,5,5,1,5,4,4,3,5,4,2,1,2,4,5,2,4,5,1,3,3,5,2,2,4,5,1,4,4,2,2,4,3,3,5,2,4,4,3,2,4,3,2,5,4,4,4,5,5,4,5,3,2,3,2,5,5,3,3,2,1,5,5,2,5,5,5,2,2,2,3,3,4,4,5,4,2,5,5,4,1,3,2,2,5,4,2,4,2,2,4,5,4,3,1,1,2,5,2,4,1,3,4,2,5,2,3,3,5,3,2,3,2,4,4,3,1

            //}); 

            // Console.WriteLine(dayOfProgrammer(1800));
            //Console.WriteLine(sockMerchant(9, new List<int>() { 10 ,20 ,20, 10, 10, 30 ,50, 10, 20 }));
            //13.09.1917


            //    string keyboardsStr = "183477 732159 779867 598794 596985 156054 445934 156030 99998 58097 459353 866372 333784 601251 142899 708233 651036 20590 56425 970129 722162 832631 938765 212387 779 181866 992436 183446 617621 304311 611791 524875 7068 432043 23068 291295 524893 611991 399952 139526 46677 292211 973975 366445 232824 456173 90627 785353 618526 199719 382549 514351 983453 592549 466869 46461 860135 607682 680461 170563 450601 65067 13268 949100 942415 965850 563416 808580 385504 304683 15970 97695 230946 684388 241080 440252 683418 122066 610135 495289 833383 34397 173404 909526 391149 258839 182278 662672 755532 311782 425252 520186 207989 546834 567829 184897 31321 969804 842475 775308 449856 939711 395240 895029 926868 598035 727436 922082 326615 88513 570573 196028 520952 45238 961389 325404 844725 388765 747489 271411 539814 828925 586884 356834 965473 280998 607171 542819 276062 140956 296341 802378 165305 74568 15640 987110 423497 772419 394971 198761 293555 5524 14083 815646 198888 707017 711503 729172 790354 771445 606097 74062 926510 358547 651224 115896 915166 863298 850231 623439 449552 330973 95432 63573 370902 311053 668992 325257 666073 729771 591431 637702 274784 887413 561370 472322 383014 119622 971931 713406 849106 760957 721893 561404 236039 771141 256127 493907 40443 522851 710823 427638 110916 25425 439436 107916 201765 31437 895966 636554 475478 314427 563403 508686 695673 907771 139363 249349 604554 410476 539963 755722 203107 228850 943066 76998 599001 289817 694942 161258 880667 929908 624495 808303 295701 633547 105519 871657 456638 803854 218490 186613 416604 892761 883480 539464 324419 807623 122116 896294 356379 318076 907033 110077 272194 227987 647837 427205 521 818200 352649 860925 304850 6954 164693 510863 534210 417506 484940 222158 692593 119893 269474 337692 244181 943123 168329 323276 218814 518908 558228 703178 403928 363712 64907 972001 253973 962665 246932 251840 696462 497361 712432 300947 148121 284905 997966 36896 266842 609702 976835 502793 411130 51491 33059 278710 345149 908471 634495 239616 680859 144928 531055 489564 447885 985873 553018 242110 592831 672287 80872 761792 369738 237692 242215 728381 803321 367866 470407 632449 983645 633673 398915 535896 816616 90311 798525 835491 150752 320853 508314 186561 695970 40785 858553 591027 326033 677717 220291 16592 711310 512209 809684 226547 348745 645319 96199 174406 940736 691094 397662 386823 517868 936942 837899 137552 675843 341144 735382 113500 209119 924902 541570 877537 695942 258000 228602 660133 174995 817407 982390 555326 516753 529770 260888 241907 996479 93124 965637 897418 558420 900621 882836 633245 188750 339107 278935 349289 700516 726120 846852 897313 856518 887287 404600 780052 887971 642177 851121 84159 935846 161666 785518 898757 669139 606566 580818 9200 372367 101495 940346 663652 973884 5063 283985 160845 305433 548858 485724 692052 448526 652109 994682 224320 175965 712340 18080 237303 494005 325474 178863 746660 366552 649780 744339 849415 721103 657762 308131 568437 542663 93696 508929 367799 636476 265263 250519 244045 590004 973230 979114 393187 486852 892248 906303 631281 434493 794991 350158 502751 645249 577034 669075 492629 864363 195287 230238 722615 499306 280836 572134 24322 768728 645618 43614 177151 994775 940671 470051 954144 279624 915071 883694 370243 747888 15461 953287 928528 330825 428281 552890 966873 572422 963838 980553 853202 75364 294516 305766 385185 190955 851329 268536 316994 485390 169531 372771 556927 394781 936366 844404 696187 930227 570190 70432 97199 208966 615146 671295 990277 358728 140116 254221 518447 295358 877571 322624 740936 848861 697173 136653 702643 709071 359573 552945 293658 296577 809544 419876 810296 256265 867268 611652 913447 81613 511458 5187 501630 628036 798476 194318 650111 70957 702126 396874 795972 50780 890206 886817 338072 27623 375668 578996 94004 438573 578411 672178 35951 328227 465703 155077 542767 982063 286606 839123 590967 860599 30508 250308 37357 38844 822786 303334 360272 537204 127090 326725 522361 828056 770168 271605 215870 965470 623031 457369 85367 842213 51694 194424 531475 411447 540757 699670 637574 138385 726255 132776 976072 969756 516417 714757 323030 41077 795366 398911 270894 433619 439071 744211 78475 250918 25357 184376 962866 80892 836169 428411 696131 688655 409046 58207 173334 915420 156473 442452 250300 239842 549351 93895 714757 182908 660347 934825 279997 638415 955081 516813 738064 657260 554479 435772 611859 730204 419695 47727 247787 566165 356053 158683 758017 120192 14397 341957 116099 91820 46014 94179 40738 311484 855654 979732 703817 175370 474281 17165 97857 763537 491727 807095 473579 346383 173241 464779 433950 649921 398595 48070 615989 949360 635237 886881 45315 260953 374698 15308 626001 933647 503250 501153 856683 539499 658843 684118 162972 615990 70585 944105 642564 944465 26518 867395 585908 636547 940443 801130 575604 677321 388258 573497 643434 128530 458357 811387 545740 820825 941677 626081 386190 820612 961408 651632 905555 206731 195836 274023 69377 214638 100801 377345 18226 38972 94465 618394 683161 336631 71205 655871 319048 385484 845066 681768 23278 340702 814652 260754 281919 496150 118192 693047 696895 348416 629085 936860 877670 39196 735237 418041 803662 967799 282099 548096 177480 423567 750784 568649 807017 576055 990729 731813 412711 127719 372102 250073 776588 580675 340881 867312 930967 561994 858607 238651 429091 679998 751041 740076 754713 238290";
            //    string drivesStr = "103148 377814 902757 534448 505367 496674 826644 389706 320122 297703 895725 100008 389290 53498 10841 958758 905586 847334 91308 354986 319386 957017 950276 676923 950822 482630 573568 493137 631980 83304 448547 91725 293277 602577 328739 553828 672670 212776 752545 946408 791758 781473 789797 113491 91227 931139 494532 974468 57572 996156 549653 55884 441630 737202 887905 546039 350995 705991 117094 968871 143024 688185 761683 837153 618358 867064 101146 838670 84126 426188 701128 222627 72780 396741 822046 892098 706402 146638 81368 513442 84857 233281 986862 581437 374356 863333 370726 880559 812983 236739 947462 907899 986224 592023 753548 350298 376345 708341 83520 481776 777322 378073 558531 705244 424318 248781 906559 330327 111223 434550 492737 253740 11357 405294 468767 571602 56316 741141 118845 767368 117553 822976 649357 744380 746213 681193 583501 237560 962390 400314 374956 477823 285777 82910 868795 528490 223647 436435 963440 802290 12158 978121 970098 556131 43170 322760 891344 43411 527820 924852 993189 919323 73814 253048 553980 695568 969521 75452 523216 166253 629541 216858 695906 294561 454644 996056 627700 697083 584446 384289 901362 737267 45457 915461 281027 958919 950626 57877 890465 394611 455760 106781 620273 335736 277444 169719 188164 646995 463803 388356 353432 229447 583788 265998 77753 360427 974615 260009 986433 453343 698319 32324 536218 279827 309598 411300 813979 602918 684886 271019 162654 133216 911133 76218 822723 940744 950014 416733 725883 581294 613554 919384 418338 82768 932939 876859 866259 551713 45229 164872 26373 411348 376549 777778 810736 480479 987499 985509 150451 376824 594265 749748 380977 393078 970133 829352 842309 569210 838518 63527 468799 36831 414913 133883 273469 13676 56389 75377 864918 691871 813085 534467 999943 750080 996862 913372 555557 585282 769161 726285 944979 757252 849839 377936 247404 241140 450646 205092 129189 251500 954266 274794 606312 207275 228695 878419 671852 757170 618268 46908 358244 268734 113584 22190 671725 498278 520425 476318 772493 831559 520281 307847 852374 816570 552032 968192 561065 88429 876852 791997 403574 590089 134046 480155 28790 420631 755308 784846 620450 639506 704239 805227 213013 903355 136403 617403 14548 980684 350667 608225 590051 636788 392333 554941 437574 91023 904363 726561 348334 547570 514106 451013 783830 910677 396633 298027 622227 523721 862558 697800 949735 796652 147107 459451 926797 842282 492228 769091 258303 66251 459240 45872 980254 620946 492730 347492 328826 209178 633544 579781 240200 341641 75881 537385 128909 460223 128075 584898 151937 400391 138859 697825 641020 180108 181922 696659 345746 411754 896991 874515 474069 515353 667709 973330 172359 602071 192333 223900 40878 821976 168974 345161 278654 347698 177051 31812 88723 548839 120664 534544 460883 356072 206381 894419 364352 128778 503531 330174 690551 321656 39321 92312 799591 481254 628042 687940 81778 511773 873776 157014 921080 377371 61092 2596 276941 868497 806383 84537 748429 597413 184563 986480 209397 536712 370556 924250 484633 236170 618395 760127 368997 531386 462639 720679 747640 62356 36692 147773 252494 133147 713511 687321 895409 844631 511793 749786 532234 30480 107197 867411 447514 354227 532738 397254 242526 104893 269304 737572 377370 182325 20076 564093 322152 840900 211496 89225 327572 535457 119790 233269 890728 343005 593727 474077 679256 355185 789350 648969 498555 479691 86940 584332 537228 736989 586974 557868 745608 586668 431757 564586 127610 378858 283840 337523 363165 899851 646063 607693 570907 244409 356177 498360 986738 330423 605912 933903 237281 7537 101806 225384 152894 365440 246014 487920 160718 851010 186610 87908 285160 806047 173413 55667 896968 842504 80252 51648 524630 18247 410490 697119 982600 997481 112065 896813 397946 576129 969689 917603 865703 5302 817257 975287 257961 490860 170927 723059 668794 821047 929586 718620 556889 535158 571742 476727 280043 838772 769667 205124 187086 968213 323753 711113 425533 199552 507725 736414 242465 529960 114863 707390 610758 767953 288696 87310 581370 506218 154398 932225 481249 320715 532710 594017 51836 369314 336681 454371 134445 548727 63390 549046 990184 201776 322427 684726 810057 87888 254699 138857 681657 2712 760400 116723 595773 473273 471683 606239 411934 794469 348947 106724 929739 850920 830807 746143 965245 408611 124326 933149 731033 991153 938552 205048 181274 379315 66512 926659 741288 721760 574603 48106 842019 781691 139804 828128 795447 750671 201673 799718 163693 825319 164303 186447 814759 235745 665348 633902 523184 908071 358912 316268 877399 588440 392534 683136 816784 452051 439234 713944 377030 899871 462785 624243 301446 539903 747778 438844 502834 577617 232266 355443 899778 391571 383978 531978 543676 66635 906677 229077 624379 542972 116925 431626 940044 332891 627850 730714 334982 693874 139304 166769 794205 878828 620213 495536 533582 741628 894094 573280 788775 997918 151710 752573 311793 707140 248546 778748 744114 143161 33540 204591 570019 714225 762631 494093 876964 754806 342159 102940 821443 536603 110657 378907 846643 457104 127518 604094 397377 502402 797475 539983 149952 486468 229304 409048 722416 772056 720199 12206 641293 598578 694105 565636 542847 716341 251856 599165 345774 826986 181639 959291 908656 342602 583524 227403 400942 423693 462110 287995 947497 615089 153386 912058 586362 139148 506003 100818 611592 256074 18115 726260 872321 593097 932329 102236 565261 918958 696808 790263 922708 23028 707398 651514 152574 771421 576419 374520 606852 68938 424227 77339 736611 104271 934578 840629 925778 910892 450941 122839 113264 235960 985064 165558 839088 186363 124691 837680 921050 332222 870093 311515 518955 227447 591409 608032 399093 379392 54774 744418 335273 205627 803035 787968 4634 603858 333575 114294 398259 414598 537517 863713 920063 923169 346425 465806 347032 480946 737668 918662 452320 587201 224656 32855 452542 912956 140889 248283 176427 577763 498481 165551 419020 33887 915052 311544 362476 780672 580720 277650 632407 220147 13098 212729 663687 515290 178077 975762 961287 459093 148697 557431 414718 860826 85369 535191 997099 184505 502309 299664 595520 310007 67092 397408 750130 426886 209953 799963 898257 349466 205186 468338 190731 625117 36558 377812 472174 836754 564969 587586 65724 294111 775703 714221 453391 527767 524509 534577 440863 481197 400854 497124 559767 765529 155276 103005 181970 334439 861980 75521 946329 753416 373394 272364 270806 897633 644145 526698 408827 800931 25393 979152 156188";
            //    int[] keyboards = Array.ConvertAll(keyboardsStr.Split(' '), keyboardsTemp => Convert.ToInt32(keyboardsTemp));
            //   int[] drives = Array.ConvertAll(drivesStr.Split(' '), drivesTemp => Convert.ToInt32(drivesTemp));
            //;
            //    Console.WriteLine(getMoneySpent(keyboards, drives, 374625));
            //var square = new List<List<int>>() {
            //  new List<int>{ 4, 9, 2 },
            //  new List<int>{ 3, 5, 7 },
            //  new List<int>{ 8, 1, 5 },
            //};

            //Console.WriteLine(formingMagicSquare(square));
            //var ranked = new List<int> { 295, 294, 291, 287, 287, 285, 285, 284, 283, 279, 277, 274, 274, 271, 270, 268, 268, 268, 264, 260, 259, 258, 257, 255, 252, 250, 244, 241, 240, 237, 236, 236, 231, 227, 227, 227, 226, 225, 224, 223, 216, 212, 200, 197, 196, 194, 193, 189, 188, 187, 183, 182, 178, 177, 173, 171, 169, 165, 143, 140, 137, 135, 133, 130, 130, 130, 128, 127, 122, 120, 116, 114, 113, 109, 106, 103, 99, 92, 85, 81, 69, 68, 63, 63, 63, 61, 57, 51, 47, 46, 38, 30, 28, 25, 22, 15, 14, 12, 6, 4 };
            //var player = new List<int> { 5, 5, 6, 14, 19, 20, 23, 25, 29, 29, 30, 30, 32, 37, 38, 38, 38, 41, 41, 44, 45, 45, 47, 59, 59, 62, 63, 65, 67, 69, 70, 72, 72, 76, 79, 82, 83, 90, 91, 92, 93, 98, 98, 100, 100, 102, 103, 105, 106, 107, 109, 112, 115, 118, 118, 121, 122, 122, 123, 125, 125, 125, 127, 128, 131, 131, 133, 134, 139, 140, 141, 143, 144, 144, 144, 144, 147, 150, 152, 155, 156, 160, 164, 164, 165, 165, 166, 168, 169, 170, 171, 172, 173, 174, 174, 180, 184, 187, 187, 188, 194, 197, 197, 197, 198, 201, 202, 202, 207, 208, 211, 212, 212, 214, 217, 219, 219, 220, 220, 223, 225, 227, 228, 229, 229, 233, 235, 235, 236, 242, 242, 245, 246, 252, 253, 253, 257, 257, 260, 261, 266, 266, 268, 269, 271, 271, 275, 276, 281, 282, 283, 284, 285, 287, 289, 289, 295, 296, 298, 300, 300, 301, 304, 306, 308, 309, 310, 316, 318, 318, 324, 326, 329, 329, 329, 330, 330, 332, 337, 337, 341, 341, 349, 351, 351, 354, 356, 357, 366, 369, 377, 379, 380, 382, 391, 391, 394, 396, 396, 400 };
            //var result = climbingLeaderboard(ranked, player);

            //foreach (var item in result)
            //{
            //    Console.WriteLine(item);
            //}


            //Console.WriteLine(pickingNumbers(new List<int>() { 4, 6 ,5 ,3 ,3 ,1 })); //3
            // Console.WriteLine(pickingNumbers(new List<int>() { 1 ,2 ,2 ,3 ,1 ,2 }));//5
            //Console.WriteLine(beautifulDaysLinq(20,23,6));
            //Console.WriteLine(viralAdvertising(3));
            //Console.WriteLine(saveThePrisoner(7, 19, 2));
            //Console.WriteLine(saveThePrisoner(3, 7, 3));
            //var numbers = new List<int>() { 16191, 79612, 51694, 4457, 14667, 29663, 90516, 52925, 21934, 88616, 25109, 12013, 3229, 82389, 83226, 49923, 84282, 24639, 52883, 35042, 23709, 3489, 13042, 42269, 34478, 65520, 5267, 17649, 74703, 38538, 98381, 7245, 34501, 50075, 11701, 49167, 96089, 18568, 18444, 18022, 23535, 43552, 46387, 26763, 25941, 29612, 93037, 26574, 54250, 45920, 61615, 94311, 65760, 91008, 52931, 16589, 56527, 74549, 34237, 47581, 13087, 48970, 71177, 47587, 99044, 99229, 13106, 11484, 17796, 31549, 45857, 41330, 75100, 92243, 84444, 17392, 21855, 93833, 43965, 92456, 56104, 21931, 86766, 38215, 12938, 56049, 54803, 85817, 30597, 5392, 49749, 60035, 54361, 20926, 23974, 69756, 20154, 37079, 81239, 54302, 84979, 27095, 11983, 76430, 19338, 12779, 93822, 57544, 6611, 54138, 49999, 79066, 76069, 53117, 17280, 89006, 9165, 72082, 91174, 56113, 93825, 40923, 16148, 48185, 78200, 40121, 17940, 98353, 93551, 15530, 52654, 94881, 42625, 80989, 71310, 78314, 93767, 65131, 35857, 16729, 19269, 2207, 95794, 95337, 71675, 13073, 694, 80839, 1506, 91868, 53304, 95331, 49142, 69451, 43515, 27341, 25923, 77807, 42045, 35825, 93336, 11051, 30705, 52312, 92039, 2014, 30625, 85805, 83497, 82833, 2533, 19117, 1392, 14678, 14453, 73066, 27750, 31498, 70257, 29255, 39717, 23560, 40937, 88858, 9362, 804, 32550, 51636, 78610, 74595, 87460, 88297, 1997, 34516, 40609, 94035, 52881, 87585, 96191, 36377, 86770, 98723, 55493, 88161, 13400, 86297, 61226, 57501, 34147, 31482, 3107, 73863, 71393, 44044, 79073, 80754, 44847, 11622, 32389, 39808, 2568, 36200, 28104, 4564, 70715, 85064, 14950, 23596, 89001, 11140, 76324, 92122, 26214, 31817, 80282, 55965, 34465, 57859, 13465, 68611, 5693, 16572, 42474, 77085, 76967, 37898, 74191, 38165, 65871, 22931, 77972, 84791, 59131, 22427, 89354, 29845, 23843, 20656, 69792, 29195, 31795, 46116, 21316, 58009, 94284, 1597, 13973, 28748, 75807, 43790, 97359, 81499, 76713, 56184, 74936, 53679, 10433, 49126, 91843, 76303, 72056, 86166, 61093, 31186, 24944, 66799, 77383, 48786, 87454, 63526, 77980, 35600, 9641, 15647, 93608, 20276, 17243, 23933, 49024, 9402, 84074, 62734, 90900, 60786, 35269, 65835, 14464, 45701, 31312, 22658, 22003, 19720, 8823, 83096, 50905, 33766, 66246, 44639, 98904, 53699, 24517, 93235, 89298, 34157, 8882, 99258, 70785, 42476, 39542, 19808, 51877, 23615, 98893, 42777, 752, 34161, 24963, 15215, 79861, 72627, 54224, 1863, 92346, 79398, 1310, 59602, 13163, 67555, 20593, 28418, 37605, 45109, 21653, 43255, 95617, 30534, 58864, 66401, 73009, 98405, 86208, 24886, 38371, 85100, 84014, 39122, 19260, 25328, 70688, 15472, 14306, 24911, 17335, 6651, 4308, 18644, 66253, 33822, 2551, 86845, 62240, 40155, 48305, 244, 99761, 43921, 30777, 58624, 10322, 20137, 73380, 12881, 61374, 28102, 14333, 61739, 83575, 33592, 3419, 54262, 49064, 17724, 95524, 82750, 24375, 16183, 17745, 6979, 66357, 20295, 10175, 28596, 76802, 58479, 45191, 92914, 2399, 75967, 51538, 29072, 12455, 41269, 41953, 73829, 69371, 56285, 35567, 52945, 6228, 38985, 23559, 71643, 73061, 35434, 54392, 97435, 51617, 88489, 4413, 17973, 25135, 14587, 62920, 18288, 73065, 24462, 11202, 91815, 428, 79091, 20887, 29234, 20359, 79191, 3062, 6081, 35475, 54981, 75378, 41702, 10317, 15288, 29697, 83377, 50721, 440, 97163, 18689, 88928, 1575, 53013, 14063, 32513, 32284, 32350, 21929, 56745, 59903, 30096, 57172, 38993, 50982, 2758, 75704, 30172, 5819, 81784, 81998, 77151, 73513, 40051, 3820, 88800, 69747, 3548, 39521, 70187, 711, 58209, 75466, 18637, 11222, 89528, 67502, 59857, 38230, 89430, 16602, 98132, 19525, 90125, 37125, 86858, 92882, 29180, 33381, 15053, 10963, 31730, 92203, 84476, 71781, 12374, 89627, 57879, 15922, 29147, 28065, 32984, 3708, 3531, 67972, 31281, 9410, 35473, 91137, 47639, 24903, 7738, 62123, 60779, 97863, 15599, 63989, 7096, 44778, 13721, 22148, 55740, 45451, 30703, 56567, 17231, 43076, 46194, 91461, 75349, 91692, 19526, 24684, 11751, 39408, 92656, 43031, 48817, 28128, 50520, 12808, 69382, 58257, 74930, 46513, 72471, 6880, 26853, 79567, 51657, 40573, 18066, 23748, 86023, 48768, 96667, 19605, 8196, 59212, 11066, 99896, 50903, 46943, 24580, 62654, 2702, 17235, 22036, 67870, 61714, 72555, 80677, 31096, 47164, 71958, 77608, 35986, 78837, 20812, 31904, 30493, 61384, 49970, 70593, 63759, 98737, 67259, 99715, 23284, 26470, 27132, 23180, 93724, 90426, 47759, 56377, 93127, 81345, 94765, 60997, 43058, 83671, 58025, 74153, 30834, 29983, 68112, 83172, 25171, 88923, 15075, 72016, 66659, 65044, 42608, 30417, 80133, 26218, 46483, 3416, 52687, 73615, 26595, 46410, 64040, 90705, 19139, 57167, 72049, 13903, 34515, 15107, 13925, 92539, 5611, 44759, 38873, 90075, 27930, 80396, 95349, 43004, 52411, 62007, 24400, 11370, 92423, 4532, 53939, 38906, 7947, 6625, 28872, 50894, 69386, 92911, 41598, 88524, 66429, 13647, 18778, 943, 45105, 32703, 9834, 50715, 93813, 65058, 40789, 38094, 45453, 36138, 97449, 14215, 98144, 21848, 41936, 6919, 26379, 95874, 62176, 50678, 2498, 7399, 1571, 88236, 309, 59520, 93111, 83090, 73166, 11889, 384, 34622, 60943, 10217, 85337, 71107, 75275, 42477, 9200, 37079, 78614, 6648, 51294, 93110, 28496 };
            //var result = circularArrayRotation(numbers, 734, new List<int>() { 1, 2 });

            //var numbers = new List<int>() { 84876, 94542, 45685, 68583, 75013, 76152, 28691, 59886, 78419, 67645, 11746, 32679, 47036, 26803, 11480, 20032, 43874, 42247, 94209, 77264, 49652, 64199, 71852, 55806, 28332, 49155, 94599, 49780, 52329, 89990, 81102, 53557, 883, 43138, 38491, 75896, 19289, 83533, 35781, 14060, 51178, 63879, 63090, 98213, 7033, 90921, 34596, 67258, 33168, 28804, 44521, 99171, 9355, 32724, 71328, 37686, 81879, 65927, 3817, 50559, 72268, 84918, 20467, 89502, 44408, 58957, 65397, 63696, 42490, 17530, 94107, 10019, 97760, 57196, 24583, 4792, 48117, 59179, 88402, 97636, 4334, 32922, 13158, 13688, 81998, 84485, 51374, 80228, 66763, 55190, 47138, 55382, 56460, 67605, 44884, 867, 26561, 26632, 80914, 85402, 60513, 91373, 11772, 58272, 48568, 36355, 79416, 13036, 11885, 67817, 27023, 16218, 17090, 40180, 46258, 15439, 41017, 97631, 12018, 7779, 69172, 59156, 79513, 41983, 26760, 24396, 42849, 69672, 51027, 40115, 71426, 11540, 31487, 83197, 86163, 96406, 19551, 65578, 25794, 47787, 49746, 52816, 64005, 83188, 9348, 10262, 98626, 50364, 24244, 10644, 74494, 93415, 86151, 54006, 35398, 12910, 78401, 94598, 98933, 45780, 51064, 70358, 57319, 98902, 53555, 43481, 95308, 89457, 25411, 21101, 37244, 91508, 90268, 17600, 74695, 99615, 44213, 89673, 66330, 68456, 16668, 40824, 78222, 2818, 94829, 29971, 32079, 89582, 24569, 31011, 35361, 91984, 1369, 9031, 90886, 71275, 68863, 86193, 77083, 10625, 23645, 30678, 2133, 30264, 64629, 76827, 29879, 8841, 66499, 12560, 93648, 99518, 53383, 71870, 2335, 64564, 18192, 34413, 70497, 42760, 81776, 22209, 51096, 99496, 31239, 41981, 87122, 16453, 28173, 64204, 27078, 68169, 11234, 29210, 14784, 75862, 22388, 61014, 1055, 5239, 73574, 94702, 4756, 26956, 82923, 23443, 7871, 1115, 57855, 78367, 60226, 55982, 575, 11321, 55477, 48165, 53301, 42598, 64618, 97825, 6802, 8047, 65993, 34387, 37256, 97129, 10248, 75995, 58142, 11302, 97585, 31715, 22356, 2341, 58671, 5278, 25783, 82893, 6392, 99989, 61260, 66618, 55971, 78186, 77938, 11447, 26351, 31239, 54045, 7320, 29063, 77198, 15366, 11408, 11584, 68973, 8536, 38183, 44967, 66677, 65837, 42552, 14744, 88192, 61244, 89766, 9821, 3378, 72658, 16213, 3366, 50269, 82830, 75688, 28455, 77119, 3487, 54805, 8357, 73883, 78476, 53772, 67432, 93841, 81531, 95367, 62813, 6418, 49901, 24131, 89446, 15737, 66682, 4189, 20280, 44277, 93954, 30101, 47654, 66612, 46313, 67372, 33232, 45494, 59411, 61686, 22612, 62897, 32842, 47321, 53131, 11317, 1092, 20562, 21509, 98974, 15928, 84321, 5391, 82181, 8452, 94836, 97917, 91485, 99025, 34549, 35762, 9330, 64649, 83415, 92293, 27313, 67138, 25525, 72806, 26549, 3562, 11769, 89445, 36404, 75441, 58928, 64072, 92884, 79489, 85581, 91857, 11769, 69901, 97247, 93949, 94704, 8435, 8217, 2541, 23811, 42765, 38302, 33140, 7413, 38068, 25433, 51077, 5206, 67309, 40234, 48106, 70870, 52003, 53902, 23625, 27443, 12829, 87697, 20327, 92318, 89629, 12183, 20438, 75881, 25782, 14386, 70585, 34216, 38954, 73125, 74378, 81719, 27778, 7517, 5483, 82197, 49301, 56560, 3754, 16609, 96793, 51859, 3831, 65147, 5761, 43807, 8942, 18589, 31503, 29268, 27258, 37483, 57802, 47695, 13364, 99935, 78432, 300, 50502, 17386, 89776, 24879, 15456, 33905, 32396, 20938, 16101, 98048, 93849, 19855, 31009, 6994, 88065, 34839, 72140, 93825, 94997, 81081, 28766, 26500, 26700, 56023, 80334, 854, 20070, 93697, 788, 14853, 93996, 51290, 32238, 123, 76168, 64045, 34027, 24915, 1335, 50128, 39315, 95183, 86334, 70323, 18528, 74398, 21513, 90668, 84575, 16509, 88100, 13340, 59360, 14800, 85714, 39694, 15653, 5783, 49742, 16440, 20636, 60090, 84081, 69225, 60212, 76601, 49622, 94239, 17867, 50956, 60718, 57181, 62490, 47051, 27503, 81018, 21448, 49015, 88037, 22374, 81876, 76136, 35713, 41235, 7287, 21427, 97280, 22939, 43561, 47022, 55731, 80548, 7111, 56163, 66125, 67322, 32763, 15746, 61560, 66982, 83053, 22277, 24162, 45542, 85679, 68017, 42911, 23479, 33383, 30947, 45852, 15258, 23435, 81565, 72845, 30721, 19343, 70124, 70012, 79255, 17145, 25742, 59803, 24255, 98256, 25927, 91577, 47371, 58024, 69488, 14352, 41076, 8117, 38513, 86617, 93795, 22881, 45880, 17273, 56264, 76826, 63125, 71521, 260, 61041, 60717, 30981, 80383, 30841, 17344, 59637, 47985, 43085, 35791, 88592, 41340, 78069, 80168, 88710, 36092, 66007, 19413, 77167, 74123, 74278, 80136, 84270, 97158, 26015, 17894, 53421, 19192, 81018, 41294, 19452, 58410, 2010, 66784, 55144, 49202, 84127, 14781, 97187, 43563, 66923, 85778, 1254, 44992, 82297, 6316, 81083, 64655, 25728, 74602, 38778, 5, 54737, 39399, 13515, 97103, 57292, 66935, 16294, 54662, 24580, 35745, 13071, 42942, 18880, 68215, 92143, 19358, 99347, 89329, 79272, 66269, 91458, 80526, 27612, 90106, 3193, 8695, 54761, 45272, 83296, 9890, 45277, 54384, 49288, 75143, 51486, 22931, 42077, 67779, 77592, 83009, 19876, 90663, 25950, 55107, 75229, 18092, 90817, 90927, 23773, 70088, 57195, 31582, 50613, 1159, 21688, 53805, 9853, 76448, 15429, 9500, 2689, 60705, 80235, 51976, 35847, 48072, 74906, 94275, 32202, 68850, 77283, 52077, 75864, 19584, 23536, 51092, 37676, 14352, 42018, 77800, 84439, 15564, 9381, 51404, 16722, 31068, 21560, 42926, 23867, 36988, 68777, 26555, 14044, 49011, 94882, 66242, 97082, 86140, 76869, 29284, 54989, 70503, 97712, 30852, 90087, 37599, 98295, 44114, 68302, 56664, 21913, 52741, 88579, 47645, 20496, 5301, 78713, 58407, 64578, 18931, 95395, 33355, 61838, 25790, 98717, 56719, 92032, 12151, 59210, 85252, 57786, 14198, 55754, 55497, 61401, 62192, 9448, 76047, 6305, 77749, 32710, 44569, 46841, 21289, 92214, 67336, 42941, 87278, 25743, 23870, 6208, 37489, 57224, 68045, 63278, 72293, 41116, 71661, 84443, 325, 56912, 42228, 30875, 29018, 14076, 8627, 91209, 23523, 84674, 97514, 17624, 17383, 58434, 64464, 55023, 50647, 48152, 97963, 37924, 90246, 21833, 44132, 27734, 95408, 28528, 7363, 84052, 85995, 95376, 68494, 2672, 52287, 27073, 49898, 97656, 41149, 58524, 88865, 81023, 43197, 2730, 98646, 76932, 61163, 63110, 31954, 11810, 27613, 46269, 66085, 17858, 84453, 26568, 45591, 96212, 71448, 69305, 80264, 57442, 64680, 48757, 60113, 33319, 92182, 10010, 30974, 33330, 84886, 36190, 30704, 28082, 38919, 45702, 21365, 16434, 25163, 53319, 44595, 52775, 15939, 10679, 70632, 391, 37247, 32574, 96602, 25046, 1878, 76865, 82487, 82910, 41974, 58952, 32580, 34155, 85313, 79905, 83836, 70198, 16095, 30891, 14632, 71365, 76592, 35996, 4150, 1754, 5666, 48744, 54528, 21604, 75775, 41511, 21994, 29373, 74084, 34948, 54418, 92314, 28164, 36904, 75223, 86489, 12207, 24154, 36995, 97520, 4058, 37182, 84069, 36504, 68073, 98700, 24221, 44664, 51048, 28370, 62770, 56713, 77114, 17297, 78317, 52888, 58808, 16662, 82260, 49243, 51609, 36677, 41556, 96125, 89932, 33130, 82613, 2139, 57283, 19608, 16010, 77693, 56789, 78, 30548, 24861, 15130, 54768, 85877, 66177, 83138, 48646, 22889, 76603, 82294, 17557, 45842, 57453, 34219, 44453, 23048, 2179, 97481, 64603, 98303, 87412, 14085, 80916, 5902, 87719, 523, 38263, 65411, 73663, 38341, 95959, 98524, 69822, 67078, 752, 35998, 50215, 65749, 58886, 43169, 64394, 76443, 89010, 21847, 27013, 49814, 44894, 29191, 47294, 25848, 27494, 51058, 39932, 24761, 73311, 27651, 41635, 11574, 9413, 15297, 66266, 21723, 30172, 36087, 88801, 30923, 72084, 55367, 96671, 47321, 14888, 77417, 40115, 20249, 15615, 67127, 70063, 60508, 12670, 33708, 2707, 56515, 84765, 58991, 81275, 58076, 2993, 22909, 86001, 28757, 38205, 52266, 50480, 84729, 88352, 55632, 15651, 60435, 10998, 28674, 24107, 25885, 6090, 64222, 62486, 21704, 47700, 32548, 98563, 60369, 66255, 17621, 16883, 67372, 76611, 98157, 25447, 95955, 37417, 11447, 24712, 91974, 80064, 75191, 76702, 68415, 47174, 8704, 45201, 58171, 53729, 85659, 408, 76170, 49880, 62893, 97873, 97580, 11792, 12787, 74300, 78046, 46760, 91183, 45417, 39722, 5691, 87215, 35677, 59460, 15013, 76740, 51433, 95076, 68282, 44486, 79842, 15455, 69541, 41394, 73625, 23270, 27053, 90384, 99439, 93284, 69628, 13664, 7215, 81419, 42802, 81515, 75817, 89561, 89049, 37585, 45635, 11091, 41152, 81311, 70550, 72516, 58050, 38334, 83944, 42683, 82819, 63785, 58137, 52360, 21531, 31761, 91981, 48583, 38497, 91419, 58218, 24476, 21434, 65433, 5895, 64236, 46947, 98063, 70148, 52347, 51999, 15782, 63437, 93150, 13444, 33987, 65666, 87845, 72320, 49609, 30527, 71491, 29745, 88663, 40202, 51275, 36776, 32182, 16209, 75272, 39952, 74427, 99747, 61386, 56211, 21993, 41973, 3157, 36407, 12120, 71855, 88406, 44254, 35291, 97907, 57697, 69277, 63572, 45542, 57949, 29532, 76068, 29439, 75629, 81083, 69640, 26903, 17858, 18173, 59464, 9481, 58124, 50242, 25579, 35861, 6452, 63924, 77833, 25960, 330, 6305, 97814, 5087, 66910, 33104, 2994, 24606, 18733, 82917, 86499, 76681, 28801, 78919, 6119, 4429, 60001, 92110, 47683, 94210, 10282, 7146, 3690, 84757, 73739, 45620, 20618, 96542, 9543, 14802, 22501, 26225, 37458, 36666, 47663, 4367, 86122, 50656, 45325, 21206, 49925, 31823, 97886, 78725, 10741, 20356, 83153, 87093, 28817, 30835, 81302, 39098, 54333, 1343, 40206, 28071, 46963, 77175, 24613, 72857, 91977, 63465, 15433, 45786, 16483, 63096, 50153, 2604, 30103, 95477, 40161, 80027, 43651, 38046, 58751, 54392, 74753, 58255, 57836, 3569, 89090, 55490, 42666, 43422, 56832, 99223, 87844, 20146, 76398, 28808, 9355, 84726, 8625, 24787, 30511, 25107, 4234, 97015, 44062, 34337, 92491, 84222, 14363, 36142, 38619, 89466, 6885, 13371, 47720, 81072, 16939, 36809, 36561, 75956, 96582, 9745, 75178, 778, 29890, 51575, 29585, 55596, 36300, 38209, 80383, 83163, 79667, 84616, 80177, 23728, 18952, 89020, 24301, 49667, 25161, 62919, 39132, 48397, 76289, 86851, 45820, 93227, 40012, 82381, 69182, 52945, 92125, 60712, 53722, 38366, 28638, 99659, 93962, 64938, 54219, 90696, 64452, 33886, 75311, 44628, 73965, 10615, 33647, 98266, 60281, 75159, 61184, 15764, 39907, 37473, 2614, 85727, 47051, 58977, 84459, 16233, 11922, 76583, 93296, 65643, 31300, 21933, 81653, 25261, 86870, 35872, 15956, 67673, 69757, 7619, 12301, 43721, 18233, 62299, 58338, 94865, 37458, 19522, 10628, 93716, 56994, 29593, 79442, 20396, 88570, 63900, 36628, 491, 56834, 29923, 82485, 88134, 51856, 64138, 13394, 55077, 9, 45702, 39102, 86117, 53320, 51402, 46189, 87904, 13700, 4527, 82768, 67509, 24048, 9747, 61225, 97393, 55691, 57018, 17788, 44260, 20918, 70768, 61102, 94103, 17042, 43587, 82236, 85249, 24076, 11982, 56678, 40436, 74035, 95779, 26552, 43706, 63532, 89092, 31609, 93583, 93618, 30728, 61092, 34017, 56826, 38668, 47761, 12516, 95685, 65549, 56776, 32954, 52668, 17877, 43409, 69709, 77815, 25644, 71310, 1890, 53977, 27987, 42325, 44363, 23765, 85228, 88068, 87296, 74320, 19676, 80878, 84289, 66755, 58321, 18306, 23580, 13340, 66066, 36096, 9025, 47966, 9223, 58330, 16985, 43451, 1738, 3046, 21266, 43734, 74355, 39507, 14062, 18693, 81832, 58425, 42457, 83411, 46492, 46104, 57730, 82520, 43333, 42019, 49274, 18006, 76676, 89206, 31345, 59093, 41653, 56721, 7059, 50875, 15051, 40395, 10677, 16788, 43440, 31942, 76873, 17794, 71449, 90935, 36486, 69632, 65711, 95294, 69394, 12202, 57749, 27124, 11073, 1082, 85494, 76699, 35439, 78521, 65904, 66783, 37613, 7556, 23504, 61023, 74782, 54906, 1418, 85458, 88045, 44857, 33752, 64918, 79003, 21552, 72204, 31840, 7535, 37914, 43486, 76928, 50115, 1234, 20403, 77540, 18667, 22248, 54238, 70457, 768, 36493, 37240, 38381, 60400, 77095, 99403, 35181, 32000, 17172, 36990, 20044, 78381, 87093, 84961, 73735, 8644, 57164, 5574, 32530, 95077, 65411, 9458, 61544, 82997, 29860, 55435, 18015, 68460, 9672, 88472, 69227, 46164, 25711, 23959, 22915, 2805, 23362, 74447, 34804, 56885, 11436, 54847, 35265, 14881, 56160, 8999, 23524, 29675, 30925, 56054, 41104, 96335, 81863, 18999, 95683, 28074, 74433, 13698, 96533, 84104, 2169, 65760, 46619, 27879, 89718, 69533, 47035, 29431, 43979, 98190, 2668, 71766, 53036, 54284, 86646, 25547, 63283, 26522, 55222, 10559, 98927, 96325, 23245, 80789, 31675, 18928, 25214, 6107, 32625, 21747, 6562, 34793, 3858, 53180, 79023, 9927, 39064, 42409, 55710, 99394, 40598, 74729, 87511, 9985, 29012, 90509, 35532, 92294, 17030, 7105, 19204, 32308, 19781, 42449, 29448, 51455, 77728, 54661, 57561, 10352, 92759, 64122, 61496, 96616, 33653, 56870, 22895, 89068, 99278, 94956, 88461, 39875, 69684, 92323, 49859, 98695, 82831, 1742, 7341, 16212, 8846, 26544, 48519, 28626, 85344, 77966, 96432, 63071, 32627, 53992, 89774, 25385, 34465, 67621, 38353, 84469, 40842, 77599, 73536, 40119, 72554, 78348, 96345, 58589, 70671, 62556, 57283, 69853, 64297, 80975, 86065, 89495, 7519, 50935, 34472, 9214, 28901, 30904, 88637, 77879, 1247, 94762, 19615, 52064, 78735, 74319, 36532, 19576, 51917, 10068, 76047, 40822, 4767, 88743, 99410, 75437, 51298, 73045, 61642, 31947, 54019, 47706, 21441, 77889, 98640, 72264, 87103, 43892, 3167, 92091, 21770, 20766, 86852, 57737, 72829, 65586, 32055, 9360, 85162, 83972, 35779, 77560, 41145, 40546, 66302, 40555, 32334, 33952, 13599, 93975, 65898, 67617, 58032, 87338, 45506, 73024, 75953, 48960, 16915, 79120, 41050, 55037, 16237, 27901, 12773, 89065, 9839, 61179, 14776, 11352, 45150, 66907, 88911, 2647, 23804, 71564, 43201, 72489, 5515, 73151, 82816, 71412, 57119, 40847, 75101, 18976, 30222, 51054, 67935, 63489, 46525, 25336, 34877, 62761, 53237, 64001, 68177, 79427, 25179, 99304, 90778, 86681, 82562, 96040, 89327, 6365, 67603, 48879, 95206, 73118, 22029, 78021, 60881, 95499, 35219, 52334, 14475, 65441, 3387, 98761, 45281, 66263, 24097, 80157, 29023, 93685, 44157, 13551, 73111, 69335, 29206, 63888, 56015, 11768, 76279, 61693, 34484, 43881, 10571, 29689, 33350, 32599, 7709, 10583, 28098, 42928, 62916, 58924, 24720, 66302, 57684, 86352, 32564, 81780, 66508, 77938, 75464, 27016, 7840, 48574, 96350, 37045, 28813, 68717, 65164, 21443, 30409, 99648, 65324, 40980, 29336, 15025, 89930, 53397, 25607, 34379, 12676, 88522, 9654, 53747, 71175, 67338, 40098, 20090, 65469, 6605, 14379, 40933, 49972, 22218, 5858, 62673, 75615, 51023, 31389, 57130, 72465, 78150, 56777, 54140, 35481, 2465, 69165, 41762, 72213, 11123, 92493, 84888, 15997, 2146, 38634, 87171, 85835, 95083, 23613, 51304, 18039, 37991, 8588, 68010, 76561, 14445, 30682, 68527, 81819, 78423, 25656, 54284, 56572, 82433, 8423, 8404, 1249, 93939, 50165, 73461, 21414, 42657, 58348, 37410, 61155, 13333, 40932, 46989, 8415, 64544, 98292, 26453, 18887, 6879, 10814, 95447, 37676, 41495, 63973, 19494, 19917, 5980, 90129, 76488, 88412, 14904, 1243, 6012, 8842, 51408, 79472, 46607, 10416, 54171, 84016, 87922, 83855, 41300, 34911, 92269, 5843, 49554, 35073, 24729, 72785, 45886, 36527, 26812, 87381, 499, 46305, 23649, 22831, 36434, 16489, 11242, 67689, 17731, 33606, 76530, 69138, 13077, 39489, 95906, 83600, 23504, 83827, 67454, 64803, 35089, 59723, 86998, 84643, 11147, 28078, 73779, 73385, 64605, 590, 77117, 81455, 63246, 765, 4285, 99679, 17253, 31879, 67367, 34984, 65484, 60249, 20473, 78560, 99737, 32730, 62159, 39592, 16557, 45965, 20747, 67997, 5687, 7744, 68991, 33185, 52173, 42769, 6569, 16777, 43358, 83685, 98232, 6604, 802, 2516, 22634, 18054, 34394, 6353, 69389, 16229, 82953, 6214, 11141, 99041, 38943, 89651, 54984, 71851, 35615, 75730, 56200, 41301, 99825, 25190, 90838, 68350, 67959, 97406, 85126, 27668, 97443, 83357, 50623, 98244, 2225, 73257, 32649, 52970, 95961, 2038, 69199, 95265, 8251, 80339, 94305, 63545, 69989, 65640, 51748, 5604, 57722, 7947, 63256, 73898, 33136, 54093, 42247, 17446, 67851, 27373, 45114, 81645, 27081, 95736, 79888, 29305, 85344, 12536, 82275, 81304, 30925, 67825, 92920, 55527, 48163, 3576, 35424, 18151, 69216, 87171, 40106, 26937, 11469, 3362, 834, 44604, 73806, 59433, 62050, 58008, 86805, 23515, 39652, 13885, 19250, 35891, 59542, 4594, 48427, 58168, 2249, 95703, 25992, 11521, 51230, 90506, 15096, 86653, 25008, 84311, 73823, 65114, 27599, 1643, 84827, 44785, 46246, 74984, 4217, 24647, 32992, 7373, 48161, 88995, 37609, 67411, 24886, 97150, 88356, 89664, 71669, 6956, 85366, 97660, 18476, 36595, 4517, 33572, 39599, 29525, 34234, 29773, 10990, 61833, 31415, 95816, 6617, 77661, 87151, 27185, 18659, 36494, 34557, 66820, 25489, 72165, 50582, 50374, 85667, 38937, 56389, 57335, 62244, 41754, 71347, 80720, 94701, 75863, 30643, 34299, 5387, 64876, 64072, 16376, 43060, 11838, 28543, 49676, 89498, 15694, 76860, 24509, 68539, 27768, 91328, 94027, 99933, 41909, 60752, 85599, 97197, 17140, 59285, 59440, 58894, 30631, 56511, 69946, 6494, 3505, 4244, 28232, 68381, 84667, 60960, 11440, 96505, 5854, 77468, 2354, 37899, 70679, 26862, 6438, 98447, 34541, 464, 14731, 76449, 77568, 16681, 89997, 94707, 75965, 65789, 69952, 6596, 38651, 39897, 29441, 42156, 60493, 74024, 10536, 45159, 51335, 38327, 58015, 57189, 32146, 60369, 95087, 2825, 3582, 17876, 17623, 38123, 34692, 32353, 30923, 12259, 49033, 20920, 6965, 24997, 3060, 76917, 47944, 41710, 33165, 93736, 217, 93657, 67760, 27104, 38816, 19094, 65431, 96830, 76282, 97576, 73550, 87721, 16752, 77132, 21948, 34374, 15254, 56639, 66726, 62528, 68897, 32110, 99799, 75862, 57107, 2858, 69130, 21402, 60920, 2294, 15138, 61136, 12303, 82897, 88240, 51118, 18342, 70022, 64299, 10976, 83949, 37849, 15048, 17053, 31332, 36995, 51426, 46585, 93634, 34504, 25464, 62530, 66613, 25263, 54743, 40071, 28120, 40224, 61473, 5391, 58870, 92962, 66527, 71172, 92210, 71118, 38641, 10551, 57491, 2939, 37878, 57791, 57139, 52925, 74843, 88470, 89920, 42621, 51406, 99905, 77124, 76870, 62434, 43736, 2132, 33529, 159, 46603, 90104, 61631, 51994, 48973, 70944, 34872, 20144, 63153, 22341, 58784, 90055, 96183, 78075, 27933, 53973, 35213, 80857, 45168, 23683, 87128, 87788, 91440, 87032, 64911, 68309, 65818, 8646, 70440, 99346, 25156, 17043, 89449, 86786, 85388, 54774, 57729, 20259, 91269, 37233, 42599, 50053, 27288, 38781, 44479, 55220, 9105, 79691, 36076, 54272, 19725, 23204, 42059, 11165, 26587, 6969, 95825, 92404, 31967, 82617, 8101, 57122, 16011, 13902, 60260, 1398, 68675, 34340, 38008, 59943, 87925, 80606, 26347, 15212, 35738, 70825, 70431, 61194, 66868, 22858, 15466, 2944, 62413, 73876, 30460, 89000, 97197, 26285, 97755, 45515, 8901, 5856, 18988, 41263, 19757, 95599, 59012, 4783, 29939, 97019, 81077, 17863, 93976, 7424, 49426, 46065, 94600, 36208, 7258, 61467, 59065, 39075, 64411, 37830, 12951, 94870, 26829, 10147, 37506, 24583, 72013, 62758, 46790, 91000, 4020, 82898, 86599, 63031, 87680, 32889, 60049, 68757, 67103, 70376, 92532, 16528, 16440, 87131, 69087, 23698, 64950, 28151, 62772, 29360, 82332, 75722, 40581, 9160, 2220, 78087, 50095, 74232, 57196, 13236, 81584, 61216, 96134, 68182, 40598, 83813, 17422, 16999, 68921, 84524, 87374, 61452, 17403, 3814, 64935, 86489, 27511, 29884, 30991, 90282, 75595, 13323, 82356, 16175, 38834, 927, 10613, 5280, 91511, 67809, 18516, 73094, 29024, 14649, 57627, 85973, 14813, 75048, 2971, 83734, 75923, 90345, 61537, 93325, 94158, 26471, 96165, 38020, 72706, 43507, 44653, 48300, 56829, 27008, 64475, 95663, 44287, 91439, 942, 35797, 59247, 35809, 8890, 4622, 50457, 82868, 90595, 81622, 57915, 93565, 81707, 50189, 261, 43243, 59865, 94418, 86066, 56029, 48789, 75123, 99535, 93442, 23423, 72716, 20449, 4249, 68378, 81087, 95687, 85671, 16883, 54934, 21480, 42124, 59555, 88288, 24991, 66501, 69909, 99257, 76418, 51615, 49445, 76678, 11210, 9309, 87448, 13627, 81689, 36236, 88749, 97576, 29677, 28523, 70291, 66478, 32771, 55020, 47564, 28458, 57042, 80799, 83391, 94873, 22922, 59297, 83161, 64265, 25798, 69421, 63521, 2215, 37388, 29318, 95244, 64949, 54978, 82691, 94927, 36667, 35279, 27, 34242, 64955, 28550, 20884, 31432, 61320, 92255, 95348, 6129, 49296, 76146, 5871, 44169, 15419, 65168, 43681, 79683, 7317, 13101, 43204, 25883, 66840, 72521, 21126, 31788, 27498, 20169, 43066, 80516, 55447, 43093, 31109, 36753, 71642, 51992, 84537, 49313, 44246, 79884, 55442, 9894, 72381, 61312, 54062, 87799, 42831, 97742, 67482, 66499, 27194, 10685, 92381, 10386, 99557, 29859, 42173, 43406, 50027, 1591, 40274, 21825, 44683, 71382, 58577, 32676, 39726, 43113, 81988, 323, 39348, 53781, 10216, 11728, 31445, 80629, 99527, 74275, 94722, 67008, 40774, 21916, 94044, 49506, 32301, 9952, 79364, 90825, 53357, 45742, 92415, 9982, 83918, 53449, 81364, 42495, 86124, 37441, 1959, 68112, 37763, 41307, 38244, 64331, 53034, 69688, 61311, 52560, 43963, 56033, 19567, 1088, 94300, 29962, 50593, 42952, 39913, 46309, 50128, 9622, 8402, 58895, 19603, 92320, 12343, 17318, 51166, 98467, 71110, 53124, 82930, 25225, 94430, 21173, 89555, 47464, 7213, 50865, 16375, 67527, 23249, 52294, 68614, 17548, 82255, 35558, 60499, 22168, 98218, 10627, 48141, 6620, 69521, 67743, 15291, 81863, 1413, 82808, 96681, 72522, 35931, 95962, 97746, 46713, 33487, 3652, 10528, 40699, 70869, 26902, 8225, 94117, 95547, 93190, 11665, 77802, 28747, 88515, 16321, 43317, 99141, 64461, 66288, 85013, 48555, 81578, 83228, 66319, 80737, 79908, 38841, 16667, 92222, 52938, 79731, 25708, 56590, 90258, 82758, 43810, 33512, 7334, 37926, 29058, 523, 49590, 23211, 45621, 38105, 39531, 88937, 53597, 20343, 55224, 38610, 85250, 53153, 38189, 51568, 33889, 34448, 6760, 66908, 26669, 59698, 62990, 68728, 32639, 69600, 51485, 76448, 3111, 58818, 14373, 48520, 59340, 80315, 88083, 21313, 34771, 27613, 10249, 4719, 64308, 81825, 43328, 49557, 34977, 97868, 1124, 85218, 32316, 7884, 52125, 58984, 83933, 31466, 44064, 32923, 1065, 95548, 9370, 20527, 70718, 40094, 69047, 46409, 36760, 57129, 67721, 71530, 1093, 94322, 76249, 81752, 76146, 35928, 31308, 11122, 33796, 48784, 12691, 66111, 56667, 64815, 41446, 56951, 12633, 85509, 89873, 13697, 97409, 15594, 34224, 68126, 72039, 19622, 30886, 8799, 93102, 98607, 80328, 10546, 92928, 72928, 92298, 69073, 25208, 23605, 96546, 75355, 72388, 9237, 57817, 45406, 90403, 99262, 18708, 3035, 1123, 8580, 33084, 98531, 40525, 67307, 83008, 12564, 3280, 13893, 21362, 96381, 28851, 18041, 23278, 38130, 7321, 15575, 23554, 32528, 55532, 36452, 7882, 27919, 45688, 65698, 89677, 52442, 81311, 8384, 71829, 82433, 33316, 4912, 97315, 73840, 88570, 96674, 86403, 91849, 26919, 24116, 4581, 55769, 42157, 27858, 10251, 65829, 43433, 33804, 98356, 98964, 86607, 22589, 43234, 32294, 4638, 49262, 1088, 85948, 57646, 72916, 84733, 7313, 94179, 98399, 97504, 82748, 95073, 259, 90948, 21991, 24374, 11880, 94111, 82882, 39737, 20713, 48710, 99521, 70869, 63417, 14836, 57475, 86005, 58070, 6121, 90642, 23683, 7208, 92942, 97680, 96475, 94026, 4992, 7005, 92424, 2496, 6104, 3848, 2754, 97051, 42190, 27127, 25282, 36301, 26361, 65018, 73365, 75070, 80891, 44233, 54839, 95726, 1708, 40843, 70147, 24180, 47837, 93830, 31387, 57130, 91509, 44213, 51155, 96501, 51217, 59930, 15348, 73672, 63778, 18101, 70722, 5967, 61579, 12355, 58619, 4291, 77372, 31984, 79361, 58262, 76216, 50551, 70340, 94275, 91393, 40486, 18454, 55581, 50667, 66192, 29062, 42176, 26756, 80216, 55028, 77972, 40146, 70375, 51643, 3923, 4827, 38716, 9889, 82757, 51070, 84860, 87048, 44794, 16843, 82760, 19407, 9410, 33310, 89746, 20037, 41054, 46584, 54842, 12987, 97250, 21034, 42048, 39425, 47789, 22264, 10804, 42113, 78761, 97530, 10107, 99035, 2356, 65175, 25275, 1465, 32596, 10134, 4864, 77389, 26976, 87623, 13148, 52738, 37284, 2893, 72774, 78337, 49476, 27615, 91323, 46726, 65000, 49723, 2502, 29141, 71986, 13306, 71253, 67098, 27187, 97711, 66132, 45895, 62885, 91406, 47359, 95481, 1540, 52222, 89221, 44867, 56196, 18720, 97604, 93479, 21613, 86729, 88167, 87440, 14344, 95842, 50517, 95695, 45564, 69371, 24835, 33901, 99028, 96087, 998, 26214, 10150, 83481, 72108, 73034, 74886, 35818, 84866, 92777, 4391, 90439, 53996, 60586, 9158, 67951, 70416, 47122, 54680, 58583, 50914, 69023, 70776, 17782, 81069, 16339, 87152, 5904, 66591, 2531, 18342, 67588, 28745, 28491, 51068, 17204, 17877, 42305, 53022, 19094, 51434, 57412, 25884, 5429, 34350, 35042, 73379, 4765, 98515, 44410, 79699, 65780, 29784, 50474, 83562, 10853, 83164, 87065, 16756, 49754, 89596, 35097, 33693, 34692, 79940, 1112, 68247, 97816, 59769, 21268, 16909, 27554, 95032, 42793, 49334, 29381, 94186, 39064, 34145, 9052, 83474, 13844, 74832, 13257, 80669, 74745, 24109, 80185, 78161, 40864, 46290, 84108, 92313, 79983, 18799, 72252, 97446, 87046, 70067, 73566, 24665, 3327, 1119, 19696, 62471, 50452, 49076, 56656, 89516, 99573, 65708, 72989, 29768, 56891, 2597, 10436, 31635, 26706, 6972, 26147, 83921, 53262, 10255, 92585, 49596, 29053, 64836, 63393, 32450, 51254, 36959, 57115, 70933, 38077, 93162, 33403, 88529, 42238, 90059, 94396, 41810, 72118, 83736, 87929, 45360, 86332, 98364, 76994, 13037, 21688, 3140, 13310, 74949, 29746, 5894, 40896, 58799, 87082, 4288, 7600, 38335, 41246, 81066, 9267, 95675, 74228, 42670, 555, 32817, 49080, 94950, 90978, 37549, 78685, 78906, 82908, 65016, 93621, 76253, 94405, 15308, 79392, 24066, 6608, 25490, 29959, 47503, 84288, 17040, 68143, 8239, 71727, 25740, 5657, 97345, 21414, 79884, 56366, 21968, 29052, 5445, 33269, 36381, 42993, 11953, 31638, 25900, 93321, 25258, 18504, 4077, 56918, 97896, 28142, 79877, 39737, 58100, 43732, 24024, 91492, 11874, 48614, 79570, 37613, 54270, 76914, 75379, 50505, 33280, 97346, 95908, 55076, 46967, 32288, 14421, 75271, 63925, 56672, 68591, 5535, 75176, 72667, 78804, 89423, 17160, 58680, 29159, 91612, 2411, 69534, 83103, 30636, 18147, 79024, 84601, 88769, 55937, 59979, 39273, 5568, 73676, 35181, 76996, 20642, 83820, 91416, 95913, 64097, 48087, 80855, 69631, 39614, 69874, 48434, 29036, 87033, 23465, 58194, 78644, 42228, 44079, 78098, 72863, 78578, 57121, 57463, 67346, 13058, 17441, 22970, 34977, 7469, 58150, 11972, 28110, 58322, 19739, 40374, 22418, 84178, 21229, 8400, 23791, 91102, 73185, 52827, 94486, 96649, 27372, 73130, 38876, 87803, 51227, 28091, 66380, 8348, 85553, 33725, 37757, 19346, 56694, 72733, 26814, 31196, 1057, 71275, 5869, 20795, 28001, 28286, 4972, 65581, 53037, 45115, 73034, 26221, 14293, 67519, 39221, 58016, 40648, 94449, 45818, 91875, 22539, 12197, 16574, 8091, 62273, 54330, 43788, 35319, 43414, 86953, 82866, 60822, 58228, 88734, 81617, 2580, 17019, 2940, 68160, 70055, 48054, 41193, 12627, 78698, 8711, 51847, 36714, 49359, 46295, 82531, 57585, 68833, 11080, 74158, 93276, 73352, 44839, 37063, 8670, 88252, 24016, 91535, 49074, 98595, 96620, 47042, 1174, 13638, 66333, 85685, 44, 30739, 26877, 29022, 9436, 35587, 80869, 46149, 1297, 43515, 45032, 75233, 28700, 56111, 49390, 21975, 29462, 10580, 75389, 54484, 15184, 15756, 62370, 64257, 30702, 58990, 27650, 48227, 88979, 93982, 33911, 5375, 41072, 60787, 50748, 50508, 12726, 47968, 13008, 30374, 91483, 58039, 5607, 20182, 14149, 71348, 58508, 59963, 81928, 50248, 30798, 97111, 82356, 93167, 77719, 13057, 68508, 5368, 61284, 73839, 15701, 11546, 95565, 73125, 88685, 46312, 23632, 1410, 94280, 36639, 48135, 2114, 94678, 53741, 38647, 25178, 25089, 13506, 85140, 23368, 63753, 15937, 20478, 46108, 25456, 14548, 75517, 10315, 36267, 36800, 84153, 51967, 64697, 96069, 41443, 53381, 58733, 65074, 71142, 69364, 18065, 19277, 71477, 29094, 73017, 26475, 54271, 14457, 39980, 55763, 37824, 3732, 71699, 74653, 66192, 97154, 89200, 41708, 23821, 25466, 94859, 24325, 93785, 59555, 20394, 35227, 12936, 79126, 16653, 84077, 64841, 51069, 19705, 36317, 96514, 9074, 62791, 50784, 23530, 19122, 6546, 77706, 22853, 94597, 68710, 89044, 8102, 57910, 47103, 31922, 99727, 41961, 56247, 93511, 1516, 92992, 45090, 14451, 72117, 78094, 14879, 36957, 29162, 34584, 89625, 42027, 60009, 68767, 92810, 83538, 87888, 15708, 77595, 27092, 26656, 46305, 32488, 34757, 20566, 79590, 83031, 20292, 21551, 39277, 30155, 23066, 32268, 75244, 53868, 20736, 69689, 85098, 74044, 15202, 36033, 80020, 57228, 96041, 48786, 66389, 95931, 53025, 98448, 73525, 80116, 25103, 19829, 28955, 59860, 40394, 8545, 42890, 77038, 30095, 98518, 7192, 69512, 30785, 82435, 39731, 67872, 52123, 24828, 41915, 83676, 60861, 21934, 40903, 73253, 87071, 7291, 69183, 40095, 5739, 42708, 36562, 30841, 78888, 65517, 7052, 19282, 90413, 66293, 96319, 36859, 81162, 19862, 6370, 11946, 2296, 46100, 96169, 70770, 70927, 38083, 54445, 48139, 76368, 95347, 21392, 63438, 18989, 90574, 19884, 24727, 49633, 72798, 71920, 28521, 38314, 95323, 47802, 45078, 61616, 60472, 81936, 59129, 80333, 88305, 87427, 98980, 50756, 83595, 86101, 38034, 21678, 56897, 86173, 14397, 68595, 23916, 77835, 87583, 30841, 97718, 28662, 80474, 70515, 581, 8994, 25180, 12255, 73147, 86609, 90222, 33618, 68544, 49351, 30302, 73200, 36777, 45633, 23955, 20371, 31733, 61989, 58400, 88629, 64513, 72797, 73575, 88428, 50631, 61157, 19268, 64700, 89818, 16093, 51567, 6750, 25086, 93098, 19005, 98232, 79707, 25578, 48201, 64602, 74928, 78502, 37802, 11704, 40486, 78108, 32075, 72218, 56448, 6826, 77198, 20960, 79622, 50772, 25739, 46604, 28281, 61359, 27656, 34450, 77451, 95574, 57552, 2537, 88671, 76556, 17120, 84729, 18485, 65321, 65683, 93413, 60174, 19836, 5116, 660, 97943, 53542, 89229, 70743, 76720, 66427, 91702, 56341, 33550, 33793, 2945, 61830, 11503, 46952, 12632, 5305, 42525, 70183, 24193, 31195, 63090, 41313, 32276, 81574, 6633, 97958, 74986, 66806, 34145, 96454, 83817, 32087, 66347, 73046, 2829, 43066, 39472, 10883, 99407, 89373, 61027, 18703, 67555, 72529, 82006, 80186, 94185, 24530, 66720, 18378, 72076, 29809, 59690, 4351, 11382, 82674, 18660, 2720, 65831, 52804, 15525, 49648, 1243, 81871, 22693, 20423, 24937, 78516, 47657, 40695, 84240, 8683, 75749, 51794, 97563, 57754, 48331, 91748, 82283, 15050, 10125, 54358, 44858, 86166, 75061, 72592, 85191, 10072, 91663, 51021, 79228, 7187, 17020, 80470, 5409, 56064, 17244, 30345, 50931, 64901, 87391, 35171, 73583, 79491, 3316, 87498, 53596, 51647, 79245, 52230, 83048, 5721, 6588, 44258, 8238, 98000, 16849, 9780, 24423, 24863, 77152, 3650, 32049, 94172, 471, 37457, 66587, 17715, 84154, 17518, 98967, 87896, 69040, 88901, 67387, 72355, 76398, 37334, 40353, 71994, 89564, 23401, 94066, 12503, 67658, 2303, 10502, 858, 28434, 34924, 25720, 5586, 54926, 74120, 16109, 55396, 27928, 82695, 89462, 12081, 16564, 88428, 16329, 85603, 77329, 67, 74310, 53726, 37400, 14662, 25720, 26963, 54414, 36137, 39465, 38423, 38440, 49966, 39280, 83225, 1242, 81351, 88810, 56167, 71822, 4918, 27914, 99750, 87613, 17376, 28182, 20528, 5803, 44510, 6131, 83131, 44576, 80440, 36857, 81976, 11453, 78928, 8938, 82219, 15064, 48403, 20641, 69855, 14720, 76273, 53080, 15961, 73975, 58241, 88479, 45797, 63159, 16393, 45546, 67123, 33768, 73727, 87650, 55922, 34589, 93780, 39053, 79164, 90571, 92261, 61139, 18376, 87540, 86429, 594, 2603, 34831, 37586, 88810, 49550, 13858, 58241, 81863, 87833, 16481, 70341, 33629, 79639, 3085, 95526, 46761, 53204, 85604, 50763, 9126, 20192, 44542, 48178, 15708, 51465, 56790, 76846, 86192, 44329, 79626, 86785, 63283, 14456, 24370, 52092, 80358, 54580, 10332, 78572, 42412, 26813, 65264, 92392, 22803, 68349, 4269, 69564, 21552, 89872, 20326, 47029, 26416, 81219, 95206, 42123, 49035, 68347, 35320, 35226, 12675, 31298, 38362, 75958, 45753, 79084, 28049, 42462, 33663, 54733, 21033, 92426, 81545, 86297, 1169, 4347, 54645, 5437, 90262, 92548, 11660, 26939, 39577, 54427, 24510, 51134, 96549, 73544, 19481, 48221, 25122, 32155, 79518, 79835, 24464, 41622, 58918, 52513, 84084, 8932, 7245, 21468, 17709, 5141, 7764, 18877, 25839, 78760, 24313, 32453, 87660, 52325, 59391, 27236, 6751, 252, 94721, 19652, 73796, 14201, 84224, 15269, 62708, 63741, 95103, 87171, 21714, 70373, 56035, 22149, 79304, 79631, 43617, 97013, 1123, 67732, 32241, 26962, 46492, 72906, 75766, 50503, 25230, 35156, 77738, 48332, 35408, 88810, 67983, 25555, 19363, 52206, 40823, 82070, 32298, 52277, 85592, 70364, 22649, 41627, 92512, 18305, 37609, 52480, 31669, 38732, 20212, 63909, 82045, 83055, 36814, 57810, 33557, 78395, 9317, 27646, 26727, 61076, 16455, 94709, 86630, 35817, 63267, 43804, 34238, 95564, 12433, 19830, 65927, 51433, 77808, 74791, 69737, 31768, 27270, 17757, 70499, 47481, 81666, 68895, 30535, 34831, 26704, 80443, 13226, 52373, 8088, 56304, 13448, 24543, 51012, 16430, 76711, 30630, 76585, 10949, 42546, 89017, 47130, 8472, 56802, 24937, 99614, 26538, 56704, 26884, 44295, 43555, 90716, 42312, 12449, 37603, 93494, 55505, 18045, 23071, 24229, 42485, 79374, 37676, 83379, 46738, 70457, 60089, 77367, 47042, 87389, 19912, 52410, 34518, 44736, 9211, 75806, 44349, 52101, 48862, 87584, 12747, 92416, 78300, 71410, 21216, 32254, 64903, 93072, 50298, 87974, 17300, 9134, 67347, 71328, 92512, 14084, 41784, 52601, 7803, 5177, 56341, 27714, 73939, 90859, 88801, 99501, 66664, 49502, 51601, 31877, 37085, 80699, 24292, 31736, 52108, 61860, 63989, 17011, 54931, 30639, 21336, 72231, 39772, 88682, 43558, 32284, 19118, 1693, 1236, 26920, 6870, 57576, 70985, 80808, 64786, 59786, 80308, 47802, 9287, 48261, 79678, 62723, 28959, 20322, 94459, 97419, 82181, 74799, 14429, 37111, 5437, 35764, 25693, 61561, 40797, 69250, 10196, 59914, 70943, 11431, 3185, 94164, 85358, 74170, 91323, 66496, 50307, 71630, 14297, 59593, 36242, 93974, 22315, 65201, 30647, 33125, 62619, 12827, 7924, 93399, 49938, 29712, 45514, 75630, 91272, 86310, 61232, 1467, 62576, 48526, 29249, 65760, 42689, 14607, 56281, 34011, 81102, 6587, 21992, 11750, 82531, 58234, 22075, 4846, 39786, 52722, 54322, 18756, 65548, 62245, 28506, 31837, 91957, 74019, 23819, 99580, 76680, 85050, 1047, 39255, 49927, 30295, 21367, 8967, 61253, 93999, 59329, 42354, 586, 97672, 70455, 83116, 55905, 92530, 4313, 12042, 45251, 58635, 47149, 27150, 37231, 75654, 58987, 45539, 49672, 99157, 45119, 42704, 558, 62517, 98310, 50484, 92811, 36028, 59450, 54064, 30027, 18778, 12769, 46964, 16449, 83224, 30079, 88706, 92105, 50744, 17099, 37355, 25730, 64248, 80856, 79312, 56253, 39842, 24851, 5925, 38998, 86321, 64980, 39555, 48837, 63289, 6390, 57999, 99317, 82191, 28414, 29343, 17320, 57535, 76306, 33769, 57110, 22736, 38826, 49214, 89831, 72276, 2920, 31912, 52875, 83775, 11224, 9128, 39969, 52426, 31404, 95318, 38746, 96383, 51225, 3934, 59671, 57614, 78284, 75339, 39805, 6698, 4681, 57124, 80584, 97338, 7244, 37693, 36426, 62421, 86906, 42608, 34697, 6177, 74520, 87571, 89951, 85743, 13050, 46271, 38168, 44453, 41589, 93265, 40835, 92813, 97198, 506, 66778, 75481, 75844, 6582, 98530, 96877, 80058, 79113, 10566, 87301, 33157, 63343, 66074, 36414, 5951, 17122, 42590, 80470, 21044, 48893, 82564, 34094, 95163, 20731, 78546, 36751, 30347, 19381, 45915, 43896, 36238, 12693, 35728, 28433, 35626, 34258, 41661, 15683, 29722, 52227, 19336, 62879, 31921, 85409, 15644, 37871, 2530, 58234, 34692, 23573, 23478, 17255, 57666, 18640, 54337, 52564, 71743, 1035, 71944, 17657, 44930, 24533, 46701, 80658, 52965, 82327, 31267, 94626, 98009, 60988, 63204, 33696, 40218, 95124, 19104, 55862, 49347, 37985, 30447, 84038, 77910, 53924, 17645, 51927, 88915, 88333, 4490, 77009, 89368, 92785, 94666, 34297, 17317, 57718, 31306, 70282, 40044, 62572, 81259, 54405, 39912, 44462, 4452, 96481, 39585, 23556, 52342, 88931, 77892, 99140, 89321, 55801, 69415, 6965, 7728, 58330, 11649, 12217, 35338, 17368, 5002, 46355, 51665, 22318, 20425, 99322, 8951, 76820, 61894, 6561, 31224, 18157, 51022, 35676, 14637, 6959, 75583, 83331, 12241, 53474, 82470, 1561, 9275, 68237, 24877, 33354, 42918, 36526, 45570, 78255, 53893, 66923, 40962, 21909, 5593, 77738, 21231, 14543, 54557, 99476, 21104, 2133, 17632, 88477, 54160, 32268, 95435, 29742, 15598, 7676, 99567, 14420, 25588, 25193, 82656, 50465, 58546, 25573, 3342, 20468, 20179, 57234, 87390, 77492, 95495, 92982, 55229, 33077, 23877, 9786, 48904, 61332, 11918, 66535, 49808, 66077, 15154, 61595, 12170, 47104, 85622, 28088, 61523, 11209, 53281, 44178, 61673, 28178, 86102, 81366, 48645, 6280, 38600, 36035, 83772, 50446, 45368, 55352, 83522, 69244, 65137, 48777, 30575, 93406, 15311, 96735, 75834, 46816, 58329, 88003, 93919, 43950, 32443, 55441, 71510, 2075, 15970, 49535, 30252, 18423, 30900, 95249, 24703, 85851, 47635, 24826, 36296, 93002, 96529, 36169, 78598, 78018, 84945, 9172, 71423, 16607, 22258, 47257, 63423, 96938, 51611, 73693, 57239, 405, 45486, 28749, 2479, 61455, 78283, 32731, 96230, 9182, 27979, 20932, 95033, 75613, 62109, 47680, 84966, 74989, 83849, 63563, 53006, 85145, 89087, 24429, 1752, 11344, 88037, 81526, 8282, 55999, 55218, 65520, 56404, 703, 10620, 58882, 78510, 88902, 7964, 74739, 14436, 52294, 12022, 25820, 44258, 90482, 73499, 29224, 65470, 73699, 9138, 18476, 75196, 98224, 59256, 93299, 25920, 63644, 91176, 34201, 19642, 46393, 16072, 92397, 63448, 26692, 51279, 58309, 31945, 75594, 33047, 62732, 27888, 61420, 88551, 72145, 68253, 78402, 17720, 33722, 68452, 26858, 68549, 59999, 41433, 44156, 53297, 67352, 7799, 44472, 17904, 43793, 7217, 50328, 36189, 87016, 93371, 3819, 45324, 25315, 79413, 94722, 4399, 23652, 72493, 9301, 12148, 40745, 87702, 29868, 74466, 72506, 73077, 59367, 32504, 14509, 3522, 2153, 98213, 27673, 62976, 16116, 71465, 86544, 82795, 7653, 73559, 76165, 11472, 35234, 17832, 7236, 29955, 22230, 30887, 18799, 31530, 43034, 59543, 35584, 89253, 34009, 8089, 78681, 9727, 56944, 9542, 29600, 75448, 7754, 57272, 38424, 40221, 28736, 41319, 23016, 36389, 31230, 15532, 64212, 66463, 33363, 71447, 12770, 55592, 18685, 31568, 87122, 78070, 91111, 39057, 67323, 41471, 63497, 62355, 67549, 20440, 71896, 97148, 12240, 96001, 54420, 50663, 52574, 99507, 8333, 91941, 52247, 39562, 7472, 16458, 6025, 40835, 4256, 35146, 12778, 39292, 66713, 16251, 17362, 74175, 55307, 1036, 31997, 18803, 63390, 99545, 55595, 51638, 96693, 67834, 47638, 51112, 18496, 211, 50618, 43180, 92151, 2865, 82742, 99623, 35674, 5118, 56809, 56282, 40263, 69586, 95573, 23327, 85837, 12934, 13854, 41143, 30321, 45850, 76298, 93711, 45395, 31892, 45348, 42087, 99725, 9337, 9550, 34572, 9548, 76519, 77751, 18050, 95735, 60492, 17672, 47761, 81961, 90832, 4042, 22223, 60418, 99614, 61902, 62606, 28900, 75755, 20100, 59220, 21604, 96397, 69282, 66998, 28288, 30981, 25436, 28012, 40318, 51337, 62583, 49865, 27856, 56686, 84266, 39942, 33529, 1938, 87702, 15490, 9121, 8095, 54064, 69538, 24061, 15965, 48495, 52960, 91719, 68595, 28531, 29675, 64991, 14165, 13024, 93279, 45145, 54812, 37642, 85462, 6148, 16577, 51678, 50355, 73262, 35944, 90297, 23142, 54233, 94350, 38631, 79705, 2445, 9047, 49243, 26505, 25011, 14089, 95816, 33082, 82683, 40698, 79108, 47674, 71214, 92131, 57304, 16359, 46942, 94945, 18172, 69442, 27873, 86202, 19796, 17486, 38497, 26444, 40628, 92729, 37146, 95610, 72433, 39590, 4656, 38027, 82446, 46019, 52116, 94613, 95452, 51150, 51662, 74559, 98823, 22876, 83041, 72478, 55586, 46335, 83775, 73757, 15776, 11647, 76310, 51923, 29133, 14806, 78367, 86112, 23886, 15512, 81721, 12671, 71453, 2729, 50697, 70250, 48747, 19164, 64862, 44198, 86666, 32875, 18756, 1840, 55750, 18148, 74318, 11335, 64482, 58092, 1444, 80257, 69738, 77753, 32180, 15222, 92559, 26898, 1333, 16444, 58761, 99406, 45466, 46565, 2134, 96163, 16814, 50880, 31678, 98027, 11429, 34695, 30901, 46536, 36535, 3003, 64683, 10852, 30689, 29165, 68943, 48484, 25773, 55032, 26237, 74304, 86606, 35147, 1201, 4290, 67942, 76313, 3695, 13408, 22877, 22180, 25922, 39690, 89411, 73951, 54068, 839, 8646, 1321, 63726, 45180, 4323, 28409, 72383, 51363, 73925, 57677, 99847, 99697, 29060, 42435, 74001, 15665, 93933, 91553, 19955, 78226, 67866, 40001, 91633, 90742, 62181, 33906, 46784, 67943, 24209, 17203, 68782, 32854, 18523, 48859, 94385, 22845, 77267, 66767, 90560, 51191, 40795, 90406, 67240, 69854, 49192, 41240, 85519, 43124, 49144, 21825, 37701, 17009, 78177, 45686, 24103, 56709, 79591, 87238, 24652, 20151, 4440, 9785, 53004, 22963, 58643, 63740, 62159, 52262, 46858, 52718, 3452, 87652, 59475, 87043, 73858, 25018, 28282, 75728, 68141, 77426, 97552, 5842, 10786, 92080, 67879, 34888, 65141, 47469, 22125, 89792, 67620, 26565, 15928, 36975, 65879, 74570, 17067, 28037, 26831, 63924, 80755, 46635, 67928, 56581, 50029, 41785, 81599, 94663, 17512, 66091, 72088, 31415, 88284, 99225, 39846, 56162, 50465, 4986, 19983, 72589, 94777, 87602, 15505, 27056, 40928, 81383, 1626, 57994, 25772, 44808, 38270, 22878, 7794, 22549, 79458, 74175, 64333, 77408, 68837, 98196, 43499, 57276, 45962, 48134, 56500, 85807, 4296, 6964, 90793, 24278, 95905, 1921, 28231, 27761, 28977, 85510, 25496, 46954, 59856, 51267, 8113, 14477, 74144, 32259, 37025, 69953, 6433, 17709, 47361, 75269, 32256, 7211, 32544, 78217, 55344, 5395, 64023, 75991, 12359, 54815, 16620, 24615, 73088, 44850, 52375, 2064, 46712, 94222, 49017, 6567, 45488, 73481, 21043, 35983, 5739, 74419, 22288, 12171, 92127, 86000, 3791, 24382, 93210, 36334, 18950, 64905, 41729, 82972, 40896, 70439, 54139, 57515, 95053, 27226, 18717, 63779, 45641, 65428, 58001, 11009, 88346, 19840, 84489, 25740, 72175, 90228, 158, 94462, 18750, 8636, 96813, 38893, 49369, 6374, 75226, 68318, 71278, 33306, 67641, 28525, 20096, 21779, 2392, 15148, 65356, 37460, 95279, 10996, 2887, 69631, 22004, 7584, 89470, 22845, 33323, 61644, 13072, 49832, 72457, 48173, 58467, 69269, 87065, 7835, 75642, 78643, 92504, 63272, 28300, 60144, 8148, 48396, 81923, 10539, 79895, 47278, 47998, 75173, 74626, 67236, 44803, 96629, 74819, 50625, 19473, 24493, 28620, 48896, 74324, 1077, 13421, 49142, 86697, 16837, 56976, 78691, 11831, 65831, 58314, 40131, 25975, 66461, 4878, 7897, 77000, 84772, 71526, 41349, 76297, 62503, 24937, 37451, 75484, 99755, 88075, 11308, 40600, 33047, 60204, 14923, 50475, 89976, 80417, 37171, 23164, 37392, 32213, 34995, 3223, 90526, 91477, 45549, 56987, 96354, 69797, 50338, 97477, 41322, 8038, 90125, 20177, 32974, 27576, 95660, 49081, 32002, 6967, 89680, 81400, 83522, 20954, 31874, 89849, 1370, 69045, 13013, 55114, 1257, 64359, 74688, 8135, 55835, 20236, 65121, 68540, 90032, 31810, 66016, 47705, 39847, 72493, 84233, 89173, 68, 79892, 38253, 48421, 86859, 44284, 29821, 86732, 65237, 61694, 76581, 82959, 47090, 89593, 54424, 64699, 53951, 45463, 72833, 26137, 65698, 54305, 94676, 72081, 2466, 77043, 36137, 42312, 49535, 20370, 47836, 65954, 16613, 86088, 30727, 19823, 30371, 76899, 6555, 11960, 38592, 83135, 11270, 2034, 89079, 82045, 83084, 59381, 27507, 72268, 85517, 9556, 26572, 80192, 97988, 45389, 73586, 34124, 4052, 23121, 70845, 51888, 5426, 3810, 37975, 36152, 23632, 84698, 13050, 30186, 13009, 67994, 29672, 24278, 86379, 18750, 6322, 69462, 78130, 50180, 41729, 79998, 59735, 84652, 60189, 57722, 30040, 50127, 8197, 34091, 73247, 95394, 85978, 95024, 99203, 40305, 47528, 22834, 25002, 60577, 69372, 38010, 44922, 99043, 78639, 31300, 34145, 1312, 17113, 28626, 51491, 58841, 8624, 11225, 59844, 85164, 85298, 89883, 35290, 9846, 23974, 24888, 5239, 26303, 36264, 4441, 66607, 83791, 43627, 7960, 44367, 29350, 45969, 5641, 44744, 40959, 53292, 95240, 42270, 70405, 23866, 10112, 45597, 48841, 37688, 5441, 50356, 22985, 95323, 1998, 49183, 35648, 26885, 54421, 78303, 63148, 75214, 44909, 46938, 35192, 69221, 7657, 64541, 15189, 29649, 9284, 72500, 82940, 4524, 31121, 53344, 44741, 41233, 15293, 93581, 95272, 20733, 43936, 34609, 32407, 62285, 83791, 84407, 89170, 38211, 62709, 68669, 13424, 23969, 31959, 48615, 93189, 55967, 29507, 24730, 85615, 38791, 13581, 84906, 59666, 44701, 54602, 4406, 85933, 69894, 14338, 81205, 90626, 74625, 15813, 39384, 36910, 15955, 23790, 26079, 54165, 2850, 11099, 83941, 43171, 59409, 48907, 36359, 31727, 78414, 77440, 17341, 17204, 91020, 18599, 76869, 35721, 73200, 97626, 38005, 43093, 11963, 35561, 50070, 86587, 67725, 89453, 23496, 83679, 29595, 65926, 54196, 32444, 93377, 38136, 75614, 52785, 87042, 28325, 84512, 81807, 22116, 18204, 99010, 29488, 53154, 92230, 65208, 26353, 89855, 19564, 69445, 18169, 71477, 19514, 4756, 55553, 8967, 44603, 39232, 54913, 10529, 9779, 87356, 20257, 47914, 79322, 89393, 51307, 23998, 90256, 33114, 62465, 8460, 48475, 91952, 61613, 57057, 73511, 4318, 63263, 93075, 73762, 81432, 80903, 9628, 2539, 36455, 34946, 47141, 92038, 89858, 74021, 1816, 93565, 94277, 66081, 72886, 83670, 33740, 13235, 73925, 83205, 75700, 98736, 31679, 84003, 76701, 88735, 57514, 81018, 51998, 66940, 54779, 49781, 47842, 80758, 52319, 84296, 15703, 99459, 92686, 5560, 89832, 10853, 99125, 84108, 76934, 88362, 67777, 27025, 17949, 58054, 10229, 10000, 56789, 41907, 94002, 33489, 46994, 51515, 14506, 15343, 18454, 85637, 65123, 66295, 82746, 33793, 66943, 98449, 33251, 59628, 4008, 23082, 70480, 19484, 23542, 63765, 7846, 91318, 90789, 42146, 49371, 1017, 52145, 22512, 59276, 46146, 56000, 6269, 97661, 86858, 37963, 32466, 88846, 3085, 98761, 71591, 36877, 82055, 86391, 86479, 41682, 90399, 25913, 28513, 26234, 49454, 8630, 50431, 57123, 99418, 92576, 22846, 16787, 44720, 45357, 92414, 7218, 17708, 98682, 4878, 20917, 52996, 37343, 26114, 56080, 52455, 97705, 9308, 34509, 447, 95786, 92542, 90845, 38050, 37407, 33431, 87503, 46036, 83861, 60978, 61805, 76437, 83823, 94943, 37508, 45531, 87356, 44725, 63238, 2389, 65954, 84155, 55384, 19649, 10268, 27815, 88455, 24324, 37122, 39316, 24771, 49260, 31857, 31967, 3661, 85615, 65397, 91164, 48002, 65610, 52141, 26159, 42046, 52315, 21101, 95905, 97845, 24809, 56982, 61082, 43549, 39287, 61588, 98933, 58935, 88208, 43099, 63742, 28883, 96573, 3057, 70005, 62184, 51265, 1972, 65844, 53232, 83720, 57007, 1233, 65681, 25499, 27391, 7726, 94165, 64844, 19983, 92009, 89652, 76964, 69443, 33200, 32602, 31030, 48484, 7889, 35589, 7935, 71630, 64472, 4507, 91038, 50828, 66690, 42302, 52799, 32533, 95533, 52871, 5892, 13118, 18551, 47742, 40508, 42629, 41907, 5351, 78963, 33915, 11354, 72278, 3357, 60906, 4879, 50739, 25741, 12767, 2679, 33675, 748, 67150, 54533, 91785, 17978, 37574, 50439, 87128, 70107, 62323, 56350, 92350, 75440, 91253, 40091, 15948, 50233, 98349, 37650, 29195, 32264, 65356, 1472, 51972, 42613, 22702, 19062, 68353, 35469, 21741, 18380, 52568, 5242, 89264, 44353, 39571, 26838, 94791, 43051, 13296, 57113, 15752, 5645, 48905, 7004, 62087, 81204, 73588, 60436, 18853, 2782, 9051, 560, 20605, 77374, 43172, 43307, 12788, 27877, 95127, 50880, 62608, 47694, 72473, 51871, 8398, 12044, 78708, 19540, 71446, 92003, 93005, 87197, 13999, 41909, 10553, 92438, 23112, 84140, 69225, 58316, 3274, 94627, 58876, 23878, 88352, 2047, 83536, 1139, 46275, 95014, 52018, 8882, 59060, 24491, 60753, 67457, 52886, 55812, 86997, 40683, 64167, 80001, 27879, 94517, 38261, 54783, 86954, 61372, 38923, 72530, 19687, 58548, 67156, 78562, 82425, 55508, 96961, 82313, 72998, 59587, 77326, 25016, 68469, 36385, 65858, 45573, 20194, 35095, 1384, 7190, 75777, 81902, 3542, 20007, 76419, 41802, 74790, 63372, 3173, 30064, 35902, 39211, 88611, 19409, 34125, 87387, 74916, 31085, 69699, 64266, 90671, 47025, 5633, 75491, 99761, 71490, 21063, 19954, 22936, 38799, 43495, 15064, 20700, 47036, 35070, 97118, 5189, 26211, 76842, 24713, 72626, 29095, 63924, 61236, 48503, 98048, 64975, 39771, 45484, 34673, 4036, 52506, 98049, 9668, 27997, 97810, 97509, 65411, 34115, 36796, 20561, 77610, 51859, 41261, 40997, 3280, 54730, 46186, 29491, 47923, 70898, 2116, 77017, 51173, 79704, 41872, 65572, 44678, 97994, 11055, 95702, 18381, 79913, 93751, 44400, 24261, 7912, 58260, 89671, 42026, 95055, 10232, 19635, 63265, 67844, 60632, 66544, 22573, 23169, 12386, 70496, 10418, 14502, 63864, 61591, 10557, 22087, 43514, 71586, 20080, 70921, 67287, 54812, 50833, 61037, 99211, 75093, 85300, 57470, 81115, 27326, 68876, 7698, 63312, 32140, 75541, 23943, 98684, 14466, 63463, 27421, 1313, 73881, 58274, 65176, 51823, 68830, 3615, 95336, 40415, 40046, 66256, 7702, 94858, 33440, 85090, 10420, 24884, 70390, 67890, 5999, 14067, 53117, 13696, 77378, 85257, 5589, 17673, 292, 20054, 81135, 27712, 37718, 55015, 85986, 19245, 23189, 71167, 22859, 34877, 27934, 62905, 17484, 51987, 57762, 50924, 37076, 68181, 75807, 23817, 52422, 98157, 37883, 21891, 28205, 31613, 7147, 33793, 49285, 23790, 70198, 30419, 67853, 7915, 1786, 70190, 27159, 41326, 57709, 66370, 76202, 85642, 29274, 93686, 37628, 3387, 60961, 74703, 87919, 53119, 14872, 56693, 51276, 69106, 78583, 79480, 718, 2081, 29624, 50002, 25870, 99821, 96773, 10074, 24087, 14910, 96616, 51245, 72587, 54324, 17614, 48789, 39965, 63239, 42474, 77592, 66625, 19786, 68646, 70896, 72904, 99869, 27588, 24179, 68975, 6170, 20010, 69692, 8250, 49633, 36046, 50471, 65805, 49170, 76896, 89891, 80431, 73511, 41136, 53017, 27834, 75101, 1805, 84150, 54692, 60630, 61741, 37668, 80415, 46739, 8563, 69671, 46607, 36150, 93849, 31933, 58671, 13859, 17977, 83272, 79843, 70374, 33742, 45648, 19543, 10638, 35538, 16325, 84148, 93025, 69341, 28334, 84478, 87498, 12483, 39169, 64479, 90576, 76836, 61246, 37314, 1751, 30916, 272, 37900, 41116, 32205, 12923, 71326, 50181, 96194, 51169, 20554, 29936, 13168, 56448, 56925, 48705, 72772, 57424, 58082, 58464, 85757, 42559, 62313, 14592, 98079, 43144, 5167, 91266, 4389, 42480, 93016, 51656, 59103, 30916, 9123, 91307, 60190, 80449, 57839, 56383, 47969, 78392, 2670, 61136, 51191, 59594, 9840, 40314, 17018, 84273, 98778, 19126, 26831, 77442, 33717, 41261, 20585, 55235, 32527, 41325, 14066, 25542, 9332, 73169, 72809, 18455, 80827, 32998, 98903, 38666, 5733, 46871, 33409, 8402, 8006, 84600, 67996, 34197, 24913, 1365, 18470, 40042, 20490, 61652, 17484, 70559, 2913, 54420, 25793, 51791, 95745, 39859, 93684, 5076, 13027, 82845, 39882, 93853, 15842, 55136, 48870, 21574, 2006, 82279, 46328, 26363, 83230, 14323, 76912, 8142, 15687, 11733, 64536, 52528, 73384, 82019, 39438, 92648, 36438, 65231, 60790, 48534, 21441, 54474, 69962, 50819, 37318, 9843, 44671, 69511, 64979, 9893, 7437, 83336, 92171, 53764, 26051, 75400, 68086, 2962, 99893, 124, 14694, 64428, 69003, 4429, 62798, 8441, 13429, 15588, 90023, 74218, 64121, 11463, 28691, 50434, 62281, 66008, 76629, 23303, 35519, 57959, 49547, 42955, 41294, 41717, 13070, 83696, 33468, 81155, 3009, 49713, 97630, 34054, 14140, 66632, 38483, 93290, 91424, 51911, 8877, 97798, 42480, 89349, 9260, 71171, 56135, 87892, 53530, 32763, 27547, 5400, 90721, 77093, 48354, 48366, 35162, 77775, 32062, 84981, 58929, 51422, 34693, 72910, 85476, 65185, 55894, 40310, 58474, 47317, 8572, 83702, 61467, 51051, 89402, 87078, 22221, 45536, 74970, 92103, 78298, 18868, 97502, 69018, 12312, 62208, 33736, 63825, 39982, 82149, 48806, 98911, 33570, 99850, 88172, 19045, 65034, 44065, 59354, 39859, 7734, 84277, 23560, 69200, 35328, 29314, 56277, 73900, 74849, 47598, 66002, 53147, 82817, 63504, 38516, 95129, 25711, 72251, 58953, 65692, 54399, 24110, 80954, 4321, 23960, 85478, 23365, 88993, 29542, 99071, 45204, 53627, 83347, 85115, 39178, 35026, 14428, 11807, 8926, 89277, 59404, 74927, 58775, 58573, 54782, 97290, 53701, 80492, 85893, 29005, 62536, 56643, 53115, 59841, 60963, 77074, 45318, 680, 82418, 91212, 16102, 27621, 44838, 99448, 12736, 368, 50826, 27163, 12174, 59751, 32791, 87929, 51029, 91565, 46501, 5811, 5207, 201, 2654, 91099, 45558, 81541, 64093, 98672, 41382, 41408, 75745, 3051, 42087, 74514, 94262, 58188, 2135, 55452, 73987, 31222, 55819, 24812, 58384, 67992, 914, 7527, 55920, 51943, 99091, 18773, 74105, 4297, 35325, 76758, 11747, 80882, 58299, 92192, 79553, 16032, 33599, 71649, 19082, 75685, 46163, 29696, 50224, 64649, 85147, 40562, 95870, 40965, 65374, 70605, 25308, 82639, 78131, 97579, 34581, 93574, 16351, 8685, 14222, 51676, 1795, 42321, 32557, 76445, 34512, 28462, 92476, 68110, 16462, 27909, 60146, 78976, 57604, 26721, 43624, 59102, 67282, 39493, 66, 49007, 26450, 41725, 31646, 20932, 39304, 82578, 14505, 55654, 91263, 28727, 7329, 93057, 87399, 56238, 85853, 21910, 1051, 94680, 6371, 17512, 22588, 66516, 96488, 96544, 93236, 40111, 71997, 76869, 95956, 72063, 25876, 22405, 30139, 73873, 43336, 69442, 56450, 74193, 25096, 47712, 19271, 48776, 57120, 6669, 21365, 59324, 28578, 22415, 54003, 34948, 39927, 76591, 17815, 52766, 89486, 11050, 92876, 61482, 4270, 5183, 49896, 30145, 43939, 80035, 20369, 87275, 65828, 76819, 77819, 90923, 40882, 97089, 56051, 14354, 3757, 93767, 73677, 48686, 16182, 27680, 99985, 72460, 20622, 17799, 25225, 26459, 45200, 34452, 4292, 49469, 39635, 54188, 95966, 83573, 50574, 16334, 87199, 16401, 9504, 65017, 23676, 50386, 78457, 96078, 81091, 98565, 89844, 54767, 47250, 22377, 82446, 47234, 94836, 19419, 65032, 36412, 45877, 10231, 70864, 50169, 76052, 10498, 20708, 72017, 10422, 71281, 4702, 97621, 4033, 14206, 78989, 44060, 64591, 73798, 40137, 45681, 72362, 46333, 16799, 19612, 68709, 15597, 83197, 63545, 35015, 64581, 16308, 97244, 74811, 87171, 47412, 67214, 14020, 84471, 39230, 24442, 72103, 43932, 38414, 76135, 74489, 33754, 36547, 55431, 7551, 76683, 17463, 79913, 39367, 34261, 15876, 8076, 49857, 99072, 87972, 1224, 63652, 4279, 98467, 54815, 91450, 62230, 22028, 5469, 46700, 77610, 46262, 18802, 37893, 84675, 11288, 12381, 18429, 64186, 67811, 42331, 57221, 85273, 22243, 96587, 35885, 54470, 4662, 85742, 53542, 92633, 86965, 33545, 13264, 1783, 4711, 4713, 64012, 43091, 26533, 27063, 20700, 72795, 62216, 74944, 73821, 73503, 87324, 8601, 54041, 71486, 50932, 11261, 73110, 89526, 7847, 8994, 43996, 12509, 11087, 13889, 21493, 14403, 63785, 34756, 16185, 68496, 55820, 96548, 11586, 98705, 23610, 48637, 71499, 85825, 23580, 61671, 75680, 27255, 70272, 29720, 15092, 37555, 57332, 4553, 27080, 65178, 29898, 87427, 94038, 40985, 17667, 15531, 71739, 81452, 66638, 4276, 66299, 22458, 823, 77884, 37514, 40785, 42872, 9012, 42961, 82803, 87034, 18640, 10057, 57305, 64711, 41500, 94859, 22042, 46052, 38291, 3572, 75949, 42069, 97609, 33285, 59736, 29491, 5024, 57539, 96129, 9299, 23837, 34938, 26473, 18072, 72451, 83609, 60943, 97814, 26570, 43745, 84847, 61561, 70153, 58504, 42624, 11652, 69714, 81017, 57703, 8004, 84588, 33651, 50073, 82197, 66936, 26160, 11687, 88311, 83698, 7815, 13961, 7534, 59104, 56785, 25605, 31554, 40394, 2899, 45719, 83315, 46643, 30566, 44875, 16795, 89069, 87498, 28446, 58782, 68515, 2500, 83138, 69454, 36150, 49562, 51650, 19437, 92073, 63337, 7747, 75770, 87503, 38059, 99655, 62959, 94844, 25259, 10864, 35237, 44509, 56583, 18551, 91151, 87148, 79777, 24297, 92568, 83627, 52742, 67701, 68493, 71593, 67190, 37946, 24094, 33103, 89596, 43531, 25175, 69284, 67629, 944, 73138, 5688, 16950, 36096, 531, 42208, 46960, 52119, 86716, 3542, 87021, 94218, 7041, 66797, 18514, 15960, 50423, 87607, 12, 18915, 59199, 83554, 73213, 99645, 16656, 79160, 59527, 41831, 48443, 27155, 59126, 37932, 49194, 76076, 74028, 66076, 34635, 37339, 34546, 37703, 57232, 21566, 48272, 80624, 88363, 66786, 12935, 55137, 70744, 12946, 90404, 46295, 96499, 63616, 45939, 29507, 42775, 21817, 87689, 7569, 48971, 46814, 45500, 14517, 39241, 35879, 96944, 90228, 89569, 47842, 44282, 46800, 69407, 92553, 27423, 74121, 75690, 40357, 45610, 62786, 69655, 36013, 9080, 82505, 15980, 71370, 12011, 75106, 93186, 16051, 99026, 58508, 62865, 60877, 89376, 18457, 96756, 2672, 25036, 2676, 50513, 69317, 49476, 19919, 61870, 93250, 10392, 53911, 49959, 56001, 16696, 35965, 8365, 42127, 18469, 24344, 13496, 46832, 15801, 23033, 62882, 14826, 97893, 42098, 75702, 87268, 76907, 88809, 6291, 1942, 91485, 56803, 71259, 57312, 93074, 49480, 66913, 3465, 3390, 16871, 75817, 20086, 52835, 84181, 62212, 87656, 24876, 92060, 50839, 40676, 31444, 13720, 71853, 29336, 72170, 63906, 32956, 49076, 69067, 39246, 67369, 76903, 12401, 54979, 34214, 5474, 4458, 1126, 25290, 7848, 34349, 1106, 44285, 3535, 85286, 22848, 91190, 10161, 31259, 42028, 67188, 62703, 72100, 39040, 8390, 60621, 2945, 41345, 9696, 72011, 96943, 93416, 48913, 9343, 48395, 99478, 14816, 52852, 16956, 40105, 77051, 51304, 57562, 37687, 54838, 59199, 76887, 62380, 85711, 8145, 20759, 52898, 87199, 92858, 8289, 95589, 53478, 27585, 53285, 79525, 15948, 50227, 72941, 81212, 75921, 37687, 80690, 90736, 6890, 13997, 47192, 83941, 65300, 21105, 37979, 36489, 80303, 14865, 15220, 66013, 23010, 35979, 18910, 10208, 45188, 43550, 22148, 98666, 71135, 75433, 94542, 87082, 42011, 83834, 68293, 17932, 21520, 65334, 25019, 28410, 79330, 88563, 28702, 60981, 9667, 66680, 13822, 89970, 81545, 29041, 55982, 20906, 65019, 91244, 47465, 10207, 34793, 69613, 25224, 22279, 61397, 36117, 9360, 19759, 19951, 94005, 54042, 57822, 59338, 79061, 2583, 55020, 67623, 47636, 16000, 93641, 14316, 29821, 83610, 12212, 75214, 55944, 49469, 56584, 63539, 96933, 83142, 14683, 82897, 8365, 36962, 60645, 60834, 62673, 96756, 97136, 56677, 50797, 54957, 32367, 29857, 73892, 87386, 13831, 21527, 19737, 7472, 52194, 49558, 7433, 64405, 41123, 63376, 30225, 97706, 43266, 27158, 80848, 57949, 26406, 5564, 11262, 87051, 66397, 73934, 83806, 63532, 30611, 34602, 34841, 62977, 80811, 8732, 66714, 10993, 46610, 86450, 18464, 98804, 52359, 25897, 79560, 93481, 5624, 9785, 91187, 65242, 53294, 88386, 23190, 79699, 93949, 34451, 83101, 76698, 24736, 83258, 56581, 55346, 34212, 91421, 34674, 15022, 16504, 1387, 26014, 63114, 4189, 60830, 78269, 56547, 3078, 57828, 50028, 25053, 67612, 57566, 90294, 20905, 45951, 29835, 16956, 56251, 64285, 56, 49300, 5373, 83314, 5881, 77070, 17525, 13653, 11744, 48898, 46509, 29482, 91263, 25974, 33670, 52092, 4242, 6569, 71521, 62069, 56596, 96574, 46033, 30513, 86867, 83289, 76463, 16702, 244, 49065, 97338, 300, 14717, 2710, 99965, 36949, 79780, 33841, 66953, 7875, 99090, 13461, 53708, 90352, 55786, 3730, 58796, 60027, 10298, 30316, 38448, 66893, 26889, 84480, 97405, 13756, 67768, 90219, 46809, 68012, 55635, 44146, 84663, 70351, 63208, 979, 23651, 59339, 51171, 90604, 67213, 50260, 20416, 37272, 40611, 76202, 41001, 99406, 36228, 51298, 46074, 74675, 34542, 72962, 75506, 48298, 3069, 43274, 54868, 66229, 27637, 10503, 10375, 28651, 97205, 89934, 45981, 37208, 49272, 97151, 27811, 32836, 47410, 48226, 86459, 4372, 24427, 27460, 3778, 77007, 95109, 66203, 68033, 46003, 39164, 43539, 94300, 58585, 3164, 49168, 24813, 30800, 76022, 51539, 75802, 89578, 41472, 21782, 26785, 7095, 18932, 70947, 56282, 82693, 19173, 42741, 87064, 59951, 86552, 7193, 53309, 81660, 73395, 21342, 27662, 12559, 81232, 38314, 87495, 84395, 3833, 12307, 31546, 96206, 80198, 7347, 85783, 38021, 45480, 28920, 61468, 80763, 16218, 17749, 63455, 35390, 60489, 50518, 11693, 63392, 74063, 81353, 45052, 47457, 2694, 89065, 76367, 83925, 27378, 63861, 84671, 31210, 92520, 16216, 27415, 89069, 39914, 29550, 27089, 85393, 74821, 88556, 66155, 91038, 22657, 45961, 42780, 99497, 12831, 70824, 62889, 86893, 52176, 7940, 34349, 71222, 13356, 27068, 71498, 40734, 90928, 56169, 88295, 99799, 88736, 32062, 88867, 28650, 77963, 32308, 14042, 52783, 37215, 96549, 60172, 59871, 42509, 19303, 59368, 55339, 90126, 22256, 58583, 42302, 46547, 92932, 29875, 59902, 19999, 1372, 635, 27278, 57540, 88930, 43429, 46276, 37343, 48647, 91277, 15305, 80954, 21670, 68087, 18169, 18218, 44610, 78039, 77079, 63913, 37406, 48769, 70390, 76013, 7352, 29043, 22559, 16635, 58917, 82461, 52985, 60289, 83095, 80262, 34180, 88376, 40042, 96807, 25718, 88689, 88083, 41022, 69642, 9753, 25460, 87810, 44322, 86422, 82201, 37752, 50334, 35958, 86521, 37075, 11971, 10224, 66118, 34529, 26858, 25034, 16989, 79842, 85322, 16436, 76455, 19502, 4811, 16497, 32660, 46881, 5185, 20743, 4254, 74826, 46847, 29714, 78988, 7520, 32487, 77540, 45272, 99172, 13497, 48144, 36246, 41819, 58367, 2363, 76348, 85224, 27397, 93336, 81417, 29070, 26123, 57871, 64923, 30934, 74367, 97583, 94166, 95903, 34677, 98419, 87081, 81523, 44484, 66068, 5394, 76970, 59959, 50665, 76141, 73455, 98808, 12387, 31626, 57174, 31101, 7973, 58749, 58497, 17660, 40165, 87567, 43783, 98036, 52489, 91068, 88754, 66423, 85233, 84657, 1099, 83651, 71737, 98973, 44487, 54156, 4367, 21456, 14114, 71383, 13949, 3920, 86543, 42687, 35545, 60068, 73787, 59869, 18817, 48636, 77529, 58981, 52554, 37663, 73368, 21394, 28730, 78474, 87817, 30314, 63130, 5267, 30316, 51218, 4240, 74802, 5373, 24958, 12610, 35838, 12692, 42910, 56109, 99234, 85596, 91654, 59302, 75734, 67874, 94470, 40721, 45402, 69802, 93274, 99416, 43170, 14668, 44497, 21643, 18836, 74810, 1124, 24102, 21478, 52341, 44693, 12631, 74065, 69650, 25240, 9902, 82342, 84501, 66010, 97927, 86448, 74015, 73580, 62182, 41889, 68049, 19254, 3642, 37851, 12528, 19410, 97372, 43547, 63906, 35366, 78734, 55068, 36489, 2835, 76545, 5181, 63880, 89175, 79245, 49881, 30767, 5498, 48574, 15267, 87859, 46501, 1715, 78226, 20080, 80248, 36466, 88129, 99501, 56459, 42331, 28380, 75868, 39702, 88278, 56126, 91419, 67011, 11193, 27907, 69846, 4089, 49439, 50077, 9615, 45035, 99957, 40381, 50532, 48531, 72000, 54742, 95031, 90066, 32967, 31462, 86665, 69432, 35942, 2517, 25891, 78272, 30897, 18110, 34325, 19174, 74235, 25743, 86185, 1779, 70001, 72382, 5867, 35791, 22458, 15482, 80825, 22414, 72214, 31356, 70944, 60565, 86098, 82326, 66982, 35416, 13788, 53646, 4848, 49729, 56163, 47090, 44353, 3411, 81551, 95029, 38936, 55786, 20772, 41472, 73916, 7124, 30205, 79783, 42915, 52662, 11616, 23739, 91428, 181, 71447, 78723, 77098, 73896, 77401, 44079, 9311, 91188, 14077, 30510, 57268, 86591, 77599, 1620, 6353, 75502, 96649, 45288, 47639, 33772, 3112, 21554, 57247, 33316, 17688, 16513, 2330, 29303, 40252, 93757, 45836, 28050, 88831, 39285, 1945, 66231, 83363, 11255, 73770, 13791, 58117, 31038, 381, 35715, 49009, 6733, 11216, 62009, 68373, 75206, 95780, 71484, 96760, 53027, 21151, 14447, 69539, 23480, 60102, 26142, 33588, 5937, 70543, 22419, 45221, 72487, 5001, 44935, 94, 78771, 58726, 58210, 26160, 75458, 10276, 75168, 98543, 37844, 37177, 83267, 13049, 49308, 71102, 9808, 18686, 92252, 40607, 88225, 32084, 708, 30718, 65671, 22996, 17613, 4441, 68216, 90099, 9442, 29502, 6544, 4564, 4579, 81105, 30723, 80037, 91381, 5890, 94931, 45576, 59418, 78197, 58624, 8726, 49298, 84784, 27411, 57901, 25390, 31987, 89984, 26097, 79057, 55655, 49092, 96669, 60095, 33659, 86767, 85888, 63160, 9663, 90451, 84091, 90767, 37525, 80479, 82147, 43415, 75409, 27722, 2832, 69957, 2698, 27909, 19254, 87481, 55320, 77154, 12870, 87306, 83490, 55318, 66362, 39144, 4409, 63030, 15590, 54419, 66149, 17830, 33930, 75811, 24632, 18020, 66577, 62157, 98498, 65076, 21923, 90258, 9149, 41106, 60214, 11846, 69015, 95819, 15678, 24334, 89325, 44899, 27991, 72814, 216, 94353, 28309, 20976, 73734, 43898, 91746, 39882, 61727, 25676, 15692, 2711, 43695, 98621, 64867, 58545, 80048, 86789, 48802, 89196, 44246, 25368, 17394, 13260, 21186, 33071, 53945, 10510, 94322, 81936, 99675, 10889, 76288, 27983, 31865, 50021, 88233, 39962, 6255, 66311, 65637, 38298, 69021, 25684, 36918, 33887, 84228, 16965, 37027, 49381, 22513, 81273, 91100, 39906, 10884, 12286, 89328, 64829, 39147, 83649, 46764, 38822, 10890, 39403, 83156, 42754, 89423, 71388, 82715, 12029, 37699, 64704, 50327, 6719, 90387, 87244, 56958, 90966, 20561, 93984, 56698, 43073, 91608, 47798, 99330, 2492, 76435, 5009, 67320, 15581, 88658, 30435, 70754, 99547, 69837, 70262, 58652, 75611, 41649, 57718, 87640, 79347, 38773, 37966, 2418, 29159, 25209, 59375, 20124, 62121, 69710, 93174, 21545, 77670, 40971, 20874, 96513, 17405, 25883, 63832, 49337, 30892, 94266, 36443, 46790, 64102, 6704, 21793, 39712, 48352, 95862, 43703, 44051, 34635, 81668, 46468, 63793, 23229, 22194, 269, 85349, 8255, 93442, 23246, 2276, 50764, 44119, 98788, 68168, 86353, 78971, 17504, 33596, 73236, 53946, 96737, 53689, 60649, 18529, 9753, 25353, 14391, 53455, 69403, 65377, 51475, 32222, 45521, 74703, 70767, 45789, 76403, 95373, 55582, 99648, 97649, 6345, 60119, 96436, 90864, 46471, 75407, 8368, 96419, 64994, 78665, 93155, 35035, 55666, 28036, 61139, 81018, 58778, 30945, 66772, 24154, 82419, 98993, 69674, 57121, 86111, 31815, 49876, 81483, 87396, 49523, 79131, 10093, 9641, 91919, 956, 72464, 83677, 9323, 68882, 65022, 4340, 78388, 56, 60005, 6423, 77546, 57374, 65200, 8491, 24145, 89353, 90909, 39489, 59027, 64382, 41951, 90841, 30609, 23433, 94588, 80131, 18916, 4680, 6124, 27186, 5636, 78587, 10862, 31310, 63820, 92235, 35649, 42207, 8643, 12005, 48630, 86188, 85730, 30181, 94678, 9874, 19534, 1939, 65714, 94912, 82672, 7664, 2104, 13280, 47449, 13043, 9762, 66364, 17723, 15885, 9901, 39710, 10823, 20762, 71019, 90994, 12996, 23020, 49553, 37990, 51376, 14534, 24178, 37106, 44714, 35207, 63331, 80599, 53497, 29045, 75510, 52520, 53060, 93965, 65799, 508, 7008, 91913, 83223, 24730, 24149, 93123, 80791, 51324, 30236, 51809, 42317, 59584, 91180, 91869, 97573, 42556, 22754, 38102, 79661, 67468, 73309, 42991, 48066, 26805, 88387, 39928, 79325, 41447, 33892, 61475, 58306, 40899, 69739, 57881, 81980, 93888, 67355, 62770, 45211, 13943, 30931, 3879, 73526, 38462, 12100, 87450, 81017, 34853, 25552, 60677, 2320, 15212, 20020, 66738, 42016, 24758, 6665, 37692, 66204, 56908, 15519, 40862, 97807, 85257, 15094, 96138, 79144, 82448, 75260, 40706, 12742, 22542, 60937, 2619, 61003, 73036, 90069, 42020, 24240, 31972, 19048, 42912, 47183, 55419, 9649, 5550, 80177, 32665, 59594, 62732, 89572, 75112, 3593, 3730, 60368, 35038, 99868, 55864, 33838, 91479, 12921, 46579, 14020, 73857, 49198, 75022, 63244, 55618, 33393, 87484, 87589, 52441, 46747, 51123, 7859, 56395, 56672, 88035, 5411, 32617, 67119, 94982, 7728, 87063, 15064, 68096, 22101, 14931, 23959, 55938, 6409, 53231, 18868, 20428, 27088, 68065, 11801, 90331, 23682, 45194, 94166, 27622, 97634, 40912, 78744, 21844, 13658, 51768, 26231, 35420, 84384, 93349, 46754, 8464, 96763, 61817, 76559, 18863, 76747, 16869, 91152, 99507, 70099, 10020, 36286, 13538, 78084, 48086, 20221, 18118, 9631, 14386, 45739, 23616, 71650, 40835, 45460, 1659, 8954, 88042, 37079, 9689, 97742, 83832, 18152, 94504, 45648, 11062, 29719, 38746, 27930, 20870, 38252, 14381, 30889, 90889, 27918, 25325, 55326, 48138, 59794, 64957, 78876, 21884, 88572, 50525, 62718, 50383, 52183, 88023, 54776, 5613, 97712, 52517, 89444, 32215, 63373, 51443, 43277, 93091, 90188, 71206, 30312, 44791, 1938, 61201, 35679, 29856, 2877, 7357, 94345, 62670, 72313, 73220, 84553, 60884, 40096, 63623, 27619, 8631, 51645, 82394, 14243, 65708, 51263, 20039, 97923, 30987, 71481, 41199, 24077, 78021, 28756, 70740, 39163, 30694, 48292, 91194, 60549, 51168, 98550, 54893, 30189, 70862, 28113, 14742, 48097, 84560, 94716, 75715, 93190, 46360, 74461, 7433, 12068, 25723, 43823, 26342, 56709, 31655, 67540, 97137, 26027, 96295, 67876, 65190, 26988, 16168, 56383, 3888, 83687, 71284, 58781, 13876, 58497, 3245, 44969, 6593, 87804, 39684, 98660, 97346, 2395, 73120, 4778, 30814, 15194, 48600, 57155, 88254, 96606, 24694, 1742, 22633, 37341, 85969, 87822, 80680, 18488, 60556, 84568, 2175, 31839, 59700, 32402, 90335, 79296, 77370, 13279, 67099, 33405, 11938, 64444, 35799, 1409, 85573, 66613, 32954, 50524, 23767, 37559, 47130, 64813, 39300, 69762, 2153, 41621, 73935, 99184, 60108, 34490, 83751, 78634, 82680, 43450, 11035, 89366, 22745, 4756, 2644, 6196, 38160, 30934, 86991, 73959, 48694, 88916, 40571, 81648, 55791, 64337, 35558, 2920, 29149, 74858, 89033, 47653, 16478, 79319, 46837, 92937, 13808, 46939, 71571, 12839, 6741, 82605, 2204, 45837, 87361, 21200, 52032, 25520, 52133, 55375, 99478, 826, 60642, 56400, 98825, 16432, 20737, 34383, 35704, 66237, 25592, 41088, 30242, 58421, 20407, 93430, 51357, 50566, 40368, 22927, 63405, 47108, 21884, 81960, 92945, 25596, 3159, 61328, 51115, 55291, 33054, 66945, 72469, 93695, 23344, 71293, 26479, 60432, 22027, 62182, 43021, 47618, 3269, 73262, 6038, 23675, 66691, 57395, 90593, 23410, 96673, 53997, 86870, 18556, 52308, 79814, 44151, 55467, 57493, 11618, 27109, 90547, 94914, 99577, 593, 34609, 87222, 27071, 95041, 9248, 5604, 54413, 73218, 8873, 27674, 79255, 48899, 10716, 53001, 39491, 34125, 66026, 9839, 20994, 84581, 62147, 17159, 45084, 17613, 74652, 73053, 44721, 81550, 84318, 60650, 98494, 18926, 64223, 25565, 30318, 89822, 47520, 84730, 79391, 56392, 12403, 58646, 5291, 23118, 27998, 61133, 73595, 94023, 70972, 94588, 94956, 33118, 28099, 56391, 67082, 19102, 29443, 28154, 651, 13760, 5155, 15496, 49037, 69377, 57412, 79355, 75551, 4932, 64084, 54941, 61323, 92839, 29938, 82965, 32308, 74288, 60450, 22254, 68310, 31421, 33194, 79617, 80890, 61292, 36007, 47971, 80393, 81801, 76124, 97395, 11912, 81279, 12890, 60949, 67007, 70302, 56655, 58909, 75233, 37090, 13850, 52907, 29928, 60139, 52224, 78588, 34426, 12673, 841, 19088, 44093, 34034, 98704, 41334, 95325, 51063, 89304, 92069, 32863, 81779, 89463, 44775, 79409, 18705, 22075, 62768, 89006, 78729, 21676, 80590, 15818, 51877, 33496, 62098, 12016, 85719, 40685, 62793, 14743, 57877, 81880, 75187, 91911, 80584, 16520, 3587, 31646, 5823, 12008, 80860, 3954, 1470, 41986, 83362, 36526, 64060, 46129, 25531, 59140, 84157, 22472, 74958, 36033, 72320, 53407, 48048, 74390, 94091, 27193, 89133, 68319, 9072, 64319, 76581, 6007, 80839, 96520, 37652, 3013, 8527, 34864, 23318, 26348, 76849, 6680, 62874, 40909, 69160, 4756, 48, 53316, 27228, 91357, 89349, 99547, 44763, 53748, 73936, 55205, 80940, 63068, 23524, 6364, 43739, 104, 12370, 40929, 96623, 66374, 43941, 21501, 1237, 67259, 47849, 78085, 90290, 27074, 35345, 75801, 31829, 35393, 29117, 59056, 43101, 34817, 74954, 87864, 4916, 65242, 59420, 2208, 44661, 82943, 8571, 88399, 99399, 20940, 29327, 12373, 87313, 89620, 33874, 4901, 73230, 98074, 82986, 79871, 25147, 18330, 55671, 73327, 70074, 84787, 48735, 29527, 35955, 23688, 33742, 40871, 5281, 93161, 59430, 49942, 92456, 68000, 38340, 91854, 5291, 84019, 20578, 8956, 73638, 70803, 13856, 63219, 68876, 96841, 43089, 10374, 31523, 98759, 53, 17948, 99898, 48787, 47474, 35852, 88826, 97567, 93074, 94107, 90728, 52503, 44048, 83183, 36854, 98739, 91388, 42145, 82757, 11965, 51100, 72746, 82768, 81307, 35964, 67995, 78148, 79052, 78369, 26022, 77811, 78421, 60321, 77708, 43559, 24147, 29911, 48736, 21713, 22985, 42842, 12440, 91839, 3241, 11974, 28693, 1980, 3361, 87189, 1088, 15326, 54640, 73834, 98093, 35946, 26149, 66087, 30445, 5201, 60807, 72818, 99363, 55579, 33139, 93422, 15489, 73637, 23332, 64225, 95349, 62668, 7066, 24141, 70859, 26659, 36114, 15903, 44990, 39475, 3091, 46077, 71152, 74082, 36262, 85596, 10027, 62411, 68034, 56824, 83963, 28841, 29641, 99677, 771, 79131, 93098, 16260, 52767, 32781, 96836, 48116, 11801, 20253, 88608, 82659, 46911, 41073, 98561, 91900, 96899, 18003, 54329, 68050, 92084, 6942, 53645, 18462, 69352, 38031, 75285, 69666, 83223, 21278, 69342, 83993, 408, 78791, 16604, 53175, 11572, 13439, 17642, 23372, 33692, 6249, 22382, 96954, 47321, 20942, 88854, 60572, 55296, 59534, 28621, 47379, 66475, 98618, 65840, 52179, 36648, 57477, 38196, 19870, 78754, 7538, 20214, 79161, 2680, 36818, 48687, 14251, 66608, 66328, 53974, 299, 88928, 76355, 97253, 52601, 97296, 2458, 13172, 52591, 78343, 58144, 16321, 44817, 56761, 98513, 13347, 9760, 55989, 51543, 29629, 51094, 75432, 49843, 46606, 78111, 3012, 95293, 8714, 69619, 77972, 62687, 86270, 83252, 39042, 83522, 52204, 52689, 2331, 81727, 21632, 80673, 39870, 54304, 41841, 12983, 52816, 71540, 39094, 25156, 39434, 68723, 92601, 14865, 34917, 39207, 9327, 54280, 50851, 18040, 23898, 28822, 97079, 10167, 28425, 52472, 10040, 80628, 21512, 28722, 78706, 43143, 25746, 34928, 13799, 83939, 64262, 66614, 55478, 3355, 8122, 94911, 88429, 722, 26127, 39697, 56280, 35453, 93976, 7130, 69845, 34226, 52304, 66923, 44392, 80728, 35746, 70784, 77708, 57257, 99505, 56413, 16752, 41603, 7692, 30550, 25541, 71953, 13515, 81018, 75308, 21636, 92280, 63736, 38710, 18406, 3433, 94989, 70210, 13760, 18471, 56406, 47985, 70774, 39680, 8729, 51501, 75425, 79512, 45560, 32682, 95368, 18325, 49433, 36970, 26016, 96334, 62510, 97969, 9848, 59879, 89628, 47836, 52158, 53363, 86545, 70563, 73147, 97885, 57125, 86907, 16355, 13530, 34891, 87128, 53210, 43619, 54981, 28634, 39482, 540, 77667, 51202, 18864, 43451, 4523, 61232, 39784, 67033, 59200, 65984, 43263, 48827, 13819, 95421, 18541, 363, 82335, 91688, 98247, 39459, 94946, 30954, 69341, 29836, 18081, 22550, 89807, 73061, 67535, 45640, 89953, 45202, 96841, 25168, 5004, 1364, 86399, 61140, 84748, 61950, 27123, 28010, 10776, 40941, 39782, 45669, 41303, 22117, 37356, 55901, 77927, 48653, 86854, 47267, 78488, 21287, 86168, 84646, 10699, 70055, 46638, 651, 31608, 43478, 42171, 36611, 61193, 28569, 97750, 62292, 90519, 24872, 6654, 17646, 65812, 46435, 63314, 23466, 84903, 17021, 79367, 79182, 65673, 82572, 26448, 60513, 3858, 28968, 61510, 14557, 99022, 8147, 31559, 30629, 67977, 73729, 83591, 45521, 2298, 81341, 7813, 9168, 22564, 30818, 43165, 4728, 93604, 22831, 28193, 78507, 56203, 23911, 57688, 21876, 6483, 487, 98740, 26692, 45806, 76601, 41248, 44827, 84748, 89159, 91807, 69076, 62887, 75398, 14596, 81536, 73090, 38760, 90703, 12005, 69577, 50220, 16732, 63181, 73050, 44925, 58039, 29252, 85187, 32078, 67479, 8021, 32564, 82570, 34713, 78370, 59171, 92312, 39548, 60270, 81470, 31355, 29345, 60709, 23104, 43940, 42244, 12545, 99052, 49299, 24549, 68628, 99518, 57633, 48160, 88919, 18909, 22550, 18170, 4095, 54627, 2001, 28468, 87191, 84570, 63180, 81912, 43740, 71843, 21459, 4009, 69665, 69165, 49705, 30373, 8620, 93645, 88968, 37516, 92696, 38266, 78417, 77675, 54135, 36049, 42187, 43053, 54957, 64736, 77575, 75403, 19363, 79575, 3870, 22905, 80496, 83401, 21168, 40588, 55244, 42626, 60948, 24908, 28143, 10653, 71632, 53114, 4297, 76951, 90630, 13344, 15217, 69046, 7370, 85703, 5094, 49556, 45108, 76402, 30644, 22682, 51804, 66358, 18608, 55674, 5614, 15455, 39074, 26781, 56042, 10669, 85758, 16990, 51928, 13900, 27642, 23559, 67014, 48290, 510, 73995, 77985, 32078, 43040, 85354, 34132, 48133, 51262, 79239, 24534, 81905, 18272, 92689, 48262, 53231, 48362, 53875, 68686, 3788, 97007, 24727, 14456, 82764, 58068, 66384, 13016, 2061, 6294, 96381, 66702, 23155, 70375, 44686, 55232, 13414, 46392, 89364, 77898, 97653, 84954, 18783, 95909, 3226, 27823, 60522, 56456, 76185, 30748, 41493, 96324, 27754, 82572, 10779, 10517, 40639, 93514, 39884, 59052, 99808, 36264, 25753, 22962, 22990, 86791, 94546, 52755, 33182, 261, 30652, 47186, 85214, 65786, 59446, 4791, 93609, 19967, 61247, 86145, 67066, 19091, 82468, 94819, 1662, 9598, 21687, 42301, 3112, 61571, 17704, 2919, 14186, 43456, 42232, 37176, 30246, 36777, 89930, 79779, 37037, 36934, 43316, 22251, 19071, 19113, 27041, 29031, 39079, 4639, 15175, 6144, 23730, 13994, 17314, 25391, 23592, 39001, 84043, 43055, 16923, 1746, 45973, 47460, 61554, 4556, 987, 8151, 41333, 90917, 4282, 78369, 44202, 47597, 16971, 63272, 66710, 44012, 8655, 22140, 65002, 23829, 44636, 5083, 54175, 61949, 30474, 94118, 17301, 30868, 37172, 50575, 48966, 99496, 98035, 10519, 4051, 15373, 35021, 45383, 6289, 39302, 23752, 66842, 3251, 57074, 46466, 69960, 1085, 55120, 8451, 82439, 95300, 53086, 87521, 49474, 31387, 34346, 43591, 65039, 65214, 97114, 15614, 30531, 96609, 30000, 57401, 660, 45372, 92421, 62394, 68013, 48075, 2497, 51206, 51325, 59571, 97671, 37636, 77007, 52790, 46086, 59445, 64442, 15524, 46966, 30267, 46910, 97663, 73858, 28300, 79228, 87323, 60265, 9758, 83932, 90264, 83510, 943, 51988, 75931, 63336, 36352, 40357, 82185, 87557, 91681, 41755, 1580, 29316, 18761, 70721, 75401, 94558, 35162, 90924, 41523, 65429, 54185, 55537, 55638, 82485, 34765, 42960, 42749, 44522, 43243, 49365, 28032, 44185, 17704, 20314, 23873, 54055, 60670, 6057, 57963, 52350, 64163, 59542, 98017, 82923, 30263, 73417, 77480, 81776, 80693, 35354, 47204, 51229, 90891, 19193, 50065, 25655, 62153, 9166, 86528, 21747, 58530, 30911, 82284, 92585, 51224, 6156, 62991, 28245, 28564, 20953, 96946, 92726, 96847, 94962, 92000, 43461, 84731, 69480, 25236, 81775, 21185, 88792, 49355, 28427, 7984, 99420, 70433, 86488, 8585, 73313, 8235, 83466, 4223, 90518, 92402, 71799, 13025, 55392, 43, 41588, 92696, 13341, 50665, 89542, 24654, 42664, 33002, 25736, 28495, 58238, 7510, 66032, 63381, 73217, 94458, 71364, 72636, 81243, 57852, 97572, 54555, 66086, 97389, 58777, 72955, 89790, 30575, 2331, 45181, 46970, 43918, 37876, 76662, 10934, 43770, 1315, 53597, 76771, 43403, 82092, 51360, 50912, 64475, 31092, 40480, 58932, 2456, 29467, 40174, 60307, 27038, 11080, 42744, 40778, 69857, 32050, 46919, 16783, 34380, 8451, 80104, 94649, 46327, 56765, 5582, 6448, 74432, 75530, 99570, 17834, 73973, 67282, 85097, 38447, 98373, 25577, 13731, 828, 71395, 70256, 77486, 98433, 81336, 36581, 55562, 51192, 68630, 2481, 84326, 19361, 10931, 64430, 30361, 73609, 37546, 35942, 96408, 28329, 27824, 95978, 62514, 1796, 63259, 47611, 56595, 77983, 89539, 70325, 95163, 60933, 40580, 72648, 75717, 21915, 25581, 47631, 89458, 10562, 50111, 73784, 29923, 77393, 54565, 60283, 67354, 92110, 12577, 63761, 36791, 40400, 76090, 99304, 58547, 39348, 46914, 15141, 33683, 52804, 85465, 28845, 30089, 42397, 1492, 22157, 64311, 43424, 69787, 70121, 53986, 36249, 43904, 83908, 13642, 14820, 60542, 97347, 23281, 89470, 61107, 60071, 29869, 37197, 59375, 4768, 92896, 22640, 19908, 42930, 91796, 21725, 71774, 21884, 64121, 89618, 44040, 28431, 33041, 13827, 98551, 87026, 50075, 58806, 87285, 80068, 73625, 47827, 93766, 13258, 53648, 54873, 73328, 83517, 8421, 49054, 4636, 17668, 71694, 24543, 60598, 63489, 46267, 32371, 1724, 26739, 38340, 62115, 71522, 71381, 75941, 70072, 58406, 42368, 45230, 62043, 38787, 35206, 26221, 32553, 48463, 79868, 3777, 21791, 79736, 28549, 70844, 84371, 62568, 58889, 8914, 23165, 38729, 71532, 71888, 40452, 14623, 10227, 2567, 86144, 97959, 94859, 56215, 56365, 53578, 17796, 18407, 8717, 53002, 44627, 57621, 17816, 40846, 61397, 55958, 20582, 6297, 43154, 4952, 68864, 2042, 30217, 92029, 57123, 18101, 80268, 13926, 32723, 6846, 32844, 18866, 4805, 27703, 91432, 77521, 97632, 9228, 12279, 6348, 78581, 73257, 63968, 96396, 14102, 41716, 52354, 34683, 48012, 95507, 39635, 16876, 13900, 69851, 25256, 71022, 87951, 5523, 1300, 20673, 28720, 34143, 55890, 33524, 78197, 47322, 11044, 75829, 56549, 23322, 98528, 51481, 96578, 78848, 47876, 10680, 36915, 16581, 45362, 84927, 28439, 1348, 18154, 58691, 87551, 43409, 29712, 75501, 65283, 47363, 12526, 94002, 81506, 68415, 43878, 59702, 32088, 54921, 51882, 88636, 78243, 50410, 56468, 91172, 45609, 4344, 1851, 82523, 37276, 63565, 83801, 82067, 64912, 1954, 40757, 52462, 61714, 86820, 44315, 43348, 34183, 73192, 53702, 15688, 57958, 97579, 75389, 90046, 68851, 27271, 95033, 63445, 94032, 51501, 54617, 55992, 72196, 72819, 38514, 25823, 36383, 38667, 7889, 17647, 40620, 48645, 86460, 18686, 35465, 30774, 78385, 69647, 20317, 48438, 1686, 78275, 46016, 93426, 84672, 31219, 37048, 79704, 94663, 31079, 47556, 65631, 3422, 19751, 38450, 41936, 45574, 74832, 96954, 69814, 8830, 53925, 18459, 95290, 72610, 70275, 42415, 67347, 39921, 62732, 15784, 57958, 41006, 78152, 51383, 25677, 9370, 88431, 21732, 20384, 35861, 69288, 86015, 39283, 89038, 24464, 97570, 50963, 15647, 94523, 20777, 24477, 48447, 55587, 36118, 37409, 25861, 78532, 4755, 82133, 41263, 20538, 40090, 82268, 15041, 7824, 24296, 24410, 96254, 46028, 44794, 32115, 31667, 30808, 71397, 20704, 71623, 68966, 88019, 87269, 63488, 25147, 28097, 11934, 80733, 64214, 49342, 22945, 42746, 70448, 5077, 84008, 90986, 61518, 82628, 6026, 69341, 23275, 46788, 81947, 85654, 7933, 14061, 17320, 55092, 85457, 54376, 26714, 70774, 42394, 30334, 34261, 83892, 58431, 62546, 80976, 38996, 28240, 3920, 81741, 98687, 25348, 82101, 6024, 3217, 81080, 12050, 88909, 4354, 75189, 70855, 90008, 83121, 84915, 23679, 54564, 86723, 78054, 81277, 57496, 36799, 11610, 8108, 20690, 86392, 70654, 18017, 25388, 15245, 21936, 23480, 13931, 63635, 5580, 19955, 66851, 86659, 48356, 72112, 7365, 23544, 42966, 13724, 23016, 44233, 37402, 77579, 30955, 15456, 75207, 4803, 68606, 3168, 12910, 5648, 5912, 99915, 23664, 31299, 15159, 61952, 54778, 45442, 25586, 76710, 65396, 8789, 79720, 13751, 80900, 87084, 53646, 23865, 807, 93013, 68097, 38209, 86943, 15404, 70016, 62149, 20206, 38621, 81668, 33115, 60620, 87579, 49382, 84284, 35229, 80892, 46235, 6359, 26333, 71820, 83068, 91728, 96960, 62787, 21830, 77859, 66223, 91827, 18076, 67029, 84839, 2524, 21589, 88133, 34279, 7956, 50281, 54484, 62929, 48301, 3951, 23548, 35879, 69684, 7831, 71108, 50575, 70417, 93818, 76908, 58589, 76885, 84987, 55548, 56023, 6817, 49759, 38597, 14995, 84186, 21978, 16186, 3061, 59918, 4318, 37340, 67874, 70951, 8175, 30802, 19251, 28477, 70701, 71481, 98160, 78532, 42588, 65087, 65300, 52757, 41994, 23888, 45993, 26980, 79436, 18368, 50148, 45546, 56964, 65143, 29731, 78941, 81328, 49143, 38859, 85645, 2834, 23084, 56595, 11009, 53885, 92197, 55837, 40937, 63678, 53997, 19468, 22617, 19083, 84768, 75374, 77428, 25007, 21366, 20759, 4442, 39733, 70907, 49987, 96697, 52401, 96069, 91989, 50080, 45212, 47199, 35724, 48045, 70282, 8671, 75405, 40518, 17219, 31242, 81455, 80896, 1590, 17274, 3513, 37024, 18393, 95238, 14451, 43400, 16603, 35209, 64193, 72688, 22467, 30532, 85736, 74867, 26600, 94076, 24946, 88163, 41275, 77022, 52560, 27908, 2044, 44316, 68426, 19262, 75557, 49880, 16510, 93498, 83505, 36374, 30521, 1898, 31611, 61323, 61649, 64565, 96532, 25841, 53604, 35350, 56372, 55691, 26569, 99324, 49767, 51514, 3838, 91041, 44887, 72749, 18948, 63282, 17065, 3725, 98896, 8973, 69956, 15405, 2471, 53461, 68130, 49343, 71710, 16092, 10666, 33358, 97008, 23549, 75550, 50612, 75250, 48274, 6302, 1818, 63949, 72420, 69684, 84138, 79812, 14570, 56887, 98760, 94204, 90303, 18836, 93099, 15627, 88792, 24855, 18097, 58604, 9336, 83792, 30313, 25427, 10809, 80022, 38786, 50709, 71923, 89397, 25958, 20196, 12051, 27776, 84144, 84470, 97459, 84634, 64282, 28380, 41520, 79393, 38935, 48174, 14580, 48385, 63800, 3371, 73239, 98249, 78326, 98926, 82040, 24990, 40704, 9200, 5011, 79490, 59908, 93286, 68886, 85865, 13481, 97288, 29992, 13977, 98110, 43802, 98610, 78743, 88534, 56481, 58135, 27468, 4654, 72714, 75853, 68453, 92437, 65443, 66701, 87114, 64369, 65092, 12104, 5072, 74291, 33466, 913, 34198, 26751, 69799, 36415, 56584, 83438, 66406, 70560, 81547, 26560, 85521, 60289, 15093, 42001, 34775, 42560, 46654, 23841, 34764, 31458, 32629, 207, 14511, 19742, 80927, 95954, 48197, 2350, 70245, 81663, 3263, 20794, 24765, 89413, 73560, 81348, 72850, 56318, 68259, 70749, 82877, 53779, 31037, 97969, 95779, 82164, 56880, 58784, 6004, 91644, 6594, 38632, 91850, 21104, 74725, 89128, 17057, 22922, 91477, 3653, 20936, 94739, 40799, 45700, 503, 14358, 27048, 73353, 70675, 95306, 44101, 53551, 65437, 91489, 67871, 61215, 73652, 24751, 36351, 96007, 16394, 42944, 50990, 24595, 80399, 25715, 13722, 13807, 48636, 5198, 17460, 69571, 16289, 58258, 31622, 16791, 88967, 75021, 6495, 59642, 70327, 66947, 29544, 35763, 58436, 13767, 13329, 48439, 38517, 66031, 44446, 54910, 8974, 95435, 95856, 5724, 21149, 9577, 19531, 86136, 31126, 36990, 72058, 47414, 11599, 3680, 80557, 565, 78700, 87051, 76558, 65378, 53998, 22454, 17492, 28785, 36220, 47173, 93575, 74736, 13203, 38020, 45997, 38529, 49807, 41852, 44252, 87307, 67780, 80134, 73443, 98905, 17123, 61852, 46319, 45073, 81883, 43227, 45638, 76935, 46629, 38547, 58664, 626, 61000, 92508, 45762, 97219, 39680, 39337, 88306, 69234, 93708, 34302, 7762, 43514, 92505, 68366, 30821, 60284, 48499, 20615, 59189, 81974, 82466, 21859, 27046, 80701, 65085, 89035, 57635, 11713, 43934, 16298, 28691, 4933, 8805, 90804, 2152, 64836, 30140, 90457, 34070, 23848, 41111, 58183, 83713, 33615, 42900, 14533, 10251, 91399, 35147, 69439, 89724, 33965, 91297, 16769, 14665, 72733, 22156, 88651, 797, 66089, 21300, 29487, 71021, 30105, 20291, 89524, 11292, 66782, 96333, 45361, 6981, 53795, 19896, 90694, 87409, 62795, 21578, 14011, 54193, 73077, 83449, 60268, 23393, 91097, 77037, 54409, 80181, 15544, 43059, 80978, 81632, 64358, 10464, 69004, 10814, 47106, 74880, 22106, 30240, 87564, 83818, 53572, 41358, 20065, 60617, 45118, 82860, 82195, 59129, 53404, 71623, 58929, 13672, 95015, 50026, 7060, 65775, 30206, 22603, 8833, 27535, 20586, 89542, 37999, 5941, 356, 1456, 97172, 38813, 48047, 84735, 38982, 1619, 42444, 59047, 62235, 87562, 58258, 60781, 63042, 11661, 48755, 21970, 25332, 60121, 88347, 48743, 25895, 18553, 71345, 51079, 46087, 8282, 40621, 437, 14223, 57328, 18245, 27746, 12492, 82643, 12481, 51473, 84261, 71276, 26871, 62848, 58837, 85128, 39980, 21878, 96789, 5087, 60200, 38472, 65207, 48546, 87215, 7454, 83450, 74911, 58532, 45889, 83193, 99152, 62677, 13767, 72831, 97273, 41512, 85322, 79916, 70344, 36795, 80528, 41620, 80017, 43375, 16808, 65145, 99707, 55038, 78285, 4793, 15237, 33108, 86351, 63782, 20322, 93804, 63584, 11585, 68688, 9472, 11129, 84191, 72148, 24895, 57022, 69421, 82758, 42343, 49336, 69454, 95489, 29863, 27425, 75506, 89590, 44232, 57002, 5648, 99269, 35286, 26792, 30857, 68393, 13142, 94639, 5067, 23298, 58222, 16651, 91985, 84045, 27779, 76175, 56192, 69025, 33196, 41964, 68134, 91891, 7651, 53939, 87379, 37514, 81363, 79236, 43455, 25595, 36237, 49102, 41215, 87874, 92245, 72072, 72619, 5386, 83062, 77685, 45035, 57635, 10687, 37019, 41679, 54817, 29546, 14222, 40193, 79093, 56186, 24678, 70983, 63836, 78617, 74714, 17701, 59979, 70301, 77507, 1925, 22890, 42960, 43140, 10763, 35204, 31563, 83381, 56942, 14624, 77417, 1976, 88610, 4455, 38995, 30288, 59271, 84892, 60861, 15815, 63984, 33398, 40493, 51319, 13586, 19109, 26032, 47638, 79087, 96332, 25145, 81012, 19221, 68104, 40503, 46336, 19660, 72065, 46068, 76601, 86688, 39837, 78576, 75297, 44291, 33922, 21936, 3562, 18813, 82796, 19376, 99149, 32546, 59868, 50467, 46131, 95328, 92850, 93768, 74415, 89181, 18912, 71778, 24754, 3368, 12280, 87441, 23027, 84344, 33508, 15979, 87383, 89696, 10906, 79031, 33987, 61180, 17318, 53900, 96344, 16465, 73275, 95492, 49010, 49495, 45958, 95140, 44822, 38807, 88908, 35588, 44340, 24171, 23717, 85445, 27538, 35996, 89237, 66916, 36691, 22744, 99246, 40425, 12440, 10152, 35807, 62778, 71331, 53124, 16677, 67674, 69589, 6303, 63166, 18598, 55797, 25475, 30090, 16971, 80634, 18997, 68910, 41325, 43167, 92627, 43121, 87057, 44974, 32357, 70324, 81665, 71452, 69570, 38441, 243, 79721, 74248, 63020, 67403, 27371, 79696, 35076, 13311, 85999, 14593, 48261, 58147, 56420, 78350, 91469, 53405, 13698, 76731, 11081, 73216, 69357, 54201, 76624, 30682, 86557, 46948, 12346, 74360, 16517, 67139, 74603, 12589, 41386, 37622, 79991, 85108, 33670, 15066, 14771, 36020, 46011, 63031, 10518, 18782, 57732, 1987, 72186, 87781, 78717, 83266, 60996, 64425, 37466, 37620, 95106, 40374, 84567, 23804, 14733, 17435, 90942, 89335, 30023, 48679, 43309, 10013, 33786, 93330, 41430, 64908, 29349, 87440, 27938, 39866, 22573, 2021, 58204, 94758, 89801, 36920, 78023, 50797, 17696, 31840, 4768, 29154, 88565, 5686, 52957, 3298, 23120, 60250, 8984, 69494, 25280, 68644, 79506, 75417, 61973, 37287, 40325, 91321, 41079, 68262, 47539, 63651, 86635, 5742, 58409, 76435, 59014, 52783, 43583, 76709, 975, 48350, 5862, 89539, 70387, 75170, 9188, 93506, 51771, 18172, 79351, 77050, 86815, 58856, 52467, 65140, 12495, 9143, 56460, 53573, 77404, 3998, 17223, 64038, 9740, 91983, 56825, 68753, 44766, 407, 61813, 62092, 65109, 84027, 51630, 35495, 75548, 60818, 45353, 43671, 95341, 24703, 20720, 98507, 99911, 89538, 63646, 12405, 98680, 36458, 65977, 92436, 56807, 99551, 72825, 82898, 91534, 29649, 68002, 52651, 46408, 29815, 14742, 11516, 30193, 82723, 63362, 5740, 43540, 25066, 49410, 55232, 49769, 86482, 70091, 66031, 92371, 33736, 78435, 7403, 86545, 60763, 99838, 43352, 60313, 89014, 42601, 68198, 35015, 10603, 20848, 81422, 56769, 51941, 9289, 86961, 34664, 72650, 9052, 94555, 97716, 74814, 49787, 63836, 77647, 19877, 29866, 70017, 69964, 24652, 77419, 72861, 1766, 93608, 32564, 62078, 98974, 75164, 46628, 33988, 85766, 83827, 15409, 42534, 35768, 41049, 45846, 70431, 30050, 71250, 64985, 27765, 46063, 31123, 7952, 23709, 67351, 54169, 10077, 53667, 78820, 3848, 26527, 80585, 97455, 59090, 59015, 12780, 34253, 21994, 46767, 36371, 5820, 78527, 95256, 57939, 19575, 57454, 28369, 49625, 28703, 9706, 93741, 74765, 57180, 18045, 14825, 24531, 72213, 24901, 94549, 51033, 28748, 21075, 47969, 42555, 96516, 23335, 55334, 47120, 45328, 18453, 83490, 51148, 96979, 95098, 9086, 32906, 52551, 53807, 98882, 81253, 79864, 8974, 72369, 37043, 27018, 3545, 77925, 15583, 28445, 72473, 82967, 73545, 9899, 30935, 32451, 6414, 54270, 4136, 69886, 99597, 38940, 69727, 67096, 52271, 64824, 76182, 85176, 33726, 29988, 409, 31330, 9851, 25734, 3698, 63245, 52752, 7242, 57522, 84686, 52039, 46346, 67652, 41935, 56245, 14938, 90737, 79010, 69207, 11224, 65247, 85156, 50164, 34974, 52251, 2434, 99797, 44784, 3961, 49875, 91123, 20721, 81204, 17325, 46454, 1254, 80570, 15557, 24847, 54443, 242, 93237, 788, 84245, 51523, 73384, 99183, 42259, 52394, 68389, 69835, 17640, 69896, 19998, 68965, 38499, 38783, 68762, 83282, 59095, 34988, 74405, 79815, 16191, 91729, 42620, 33796, 88650, 58177, 58643, 43092, 74770, 51879, 43880, 59015, 3402, 17263, 58197, 62012, 86008, 42937, 31846, 3648, 29185, 68195, 72612, 67683, 23329, 57725, 50964, 82423, 9064, 25368, 78589, 25255, 33449, 37561, 75402, 22098, 95737, 34044, 65190, 70506, 2275, 9069, 45872, 5676, 42683, 4068, 84039, 28691, 63357, 15885, 48690, 92541, 431, 37653, 60223, 23760, 95378, 27538, 22534, 20793, 69258, 1123, 62399, 2706, 55035, 37801, 24803, 50771, 71844, 6344, 37628, 74118, 15412, 99852, 96145, 74447, 3919, 80184, 3137, 83627, 12420, 51826, 76167, 12850, 89478, 52741, 36609, 1207, 80279, 59143, 22000, 49536, 76617, 84398, 52241, 31651, 22198, 93395, 98773, 10394, 99739, 52752, 863, 31502, 52603, 97008, 5948, 72874, 93543, 9084, 56500, 5962, 77261, 49019, 18811, 66739, 1759, 71772, 84297, 98389, 47266, 22648, 47924, 40234, 23398, 16516, 88236, 45595, 9911, 87008, 72340, 26001, 56111, 73203, 57502, 25066, 70210, 63450, 97939, 63752, 88885, 70790, 86065, 82498, 36160, 4875, 49236, 37919, 92998, 49884, 52659, 40263, 72532, 583, 80496, 95929, 33450, 68731, 57875, 43360, 72090, 30215, 85712, 44553, 19769, 43214, 69618, 89978, 23015, 67556, 70081, 28251, 54697, 56145, 10748, 90857, 77371, 76335, 45127, 70369, 26219, 97785, 10631, 15102, 14719, 7479, 11030, 48169, 92561, 85256, 7880, 64651, 15470, 93592, 9203, 35238, 53157, 78820, 41567, 92523, 62727, 27999, 20773, 17423, 495, 31521, 24631, 94218, 24207, 69757, 64586, 50425, 83894, 91568, 65526, 98612, 15398, 92907, 63132, 7959, 78163, 71012, 72609, 9984, 80955, 98163, 61574, 34111, 93334, 19492, 42985, 72412, 63843, 63757, 6186, 64337, 11629, 30817, 58554, 35836, 16925, 39491, 2612, 818, 47411, 84490, 99430, 62808, 93748, 78913, 70766, 88262, 49924, 59726, 98246, 47230, 74240, 76171, 97692, 67573, 12014, 40676, 39984, 75856, 4433, 46170, 40193, 32413, 93338, 15098, 84600, 10262, 70941, 87212, 11080, 18351, 71701, 26861, 81158, 81800, 5773, 68276, 70062, 72049, 44353, 84659, 35630, 18593, 60829, 33322, 2517, 72842, 73997, 42501, 65050, 94781, 5022, 21594, 27194, 14711, 36691, 28145, 24972, 7631, 15356, 52403, 42333, 3408, 95615, 39843, 85208, 17740, 24470, 55269, 6140, 68822, 56279, 41769, 87414, 17107, 75090, 6283, 6300, 65439, 65135, 71349, 60219, 86508, 92942, 3764, 1218, 45985, 31909, 26189, 69967, 63616, 94944, 12300, 83376, 90558, 68494, 68583, 24649, 92963, 40203, 30788, 61784, 96481, 72557, 65550, 29939, 47646, 71832, 52590, 29436, 53318, 40291, 6007, 39825, 33232, 26122, 41042, 95568, 74382, 83582, 65535, 37998, 78525, 94186, 21373, 85435, 79031, 6307, 10083, 71993, 62861, 40871, 50128, 59341, 13427, 15677, 5631, 77424, 3860, 58220, 6860, 57177, 14862, 12866, 97001, 48094, 38987, 54394, 60013, 29721, 37976, 41899, 67718, 16500, 52436, 5442, 18286, 31466, 11748, 28369, 3458, 74608, 69239, 69938, 50300, 99017, 85614, 72282, 92792, 5826, 46853, 99651, 79354, 61715, 28868, 92707, 26160, 84207, 47100, 86172, 13927, 85075, 44423, 97996, 17927, 96858, 3437, 36212, 44676, 31536, 64580, 64485, 6143, 50170, 34422, 72794, 65538, 20036, 61427, 58330, 42213, 8279, 74332, 21566, 69993, 3200, 14272, 12504, 3758, 77724, 98676, 34036, 62798, 59450, 32031, 80724, 56307, 51819, 33288, 17334, 83354, 14219, 81819, 5848, 64389, 16240, 78641, 46278, 52627, 56419, 4607, 94839, 64697, 78939, 32757, 51042, 98490, 63380, 63545, 18599, 41103, 78572, 52634, 20253, 38021, 1016, 17328, 10680, 52834, 50615, 28013, 36187, 64834, 9831, 42034, 45574, 26071, 37026, 91851, 78697, 93444, 96458, 89888, 74492, 91748, 38996, 25533, 6589, 2375, 89078, 25187, 59830, 67649, 94172, 80082, 22022, 95187, 13761, 32701, 48020, 64376, 60713, 558, 45561, 86896, 42591, 91134, 29318, 95968, 82984, 8014, 5763, 95793, 14253, 80254, 3892, 53248, 5787, 10480, 71975, 11216, 52018, 48156, 78864, 46189, 44589, 17237, 57727, 58349, 49937, 5746, 39076, 27002, 22655, 84636, 13897, 65245, 75769, 43214, 77564, 75105, 67579, 83326, 87249, 98184, 63580, 91141, 67783, 85718, 17972, 56109, 96933, 69990, 4264, 92148, 32530, 65204, 9385, 90257, 23553, 75673, 96002, 78980, 2674, 18657, 63616, 32922, 253, 55736, 92487, 94169, 30840, 76418, 93846, 18089, 74601, 73777, 25581, 58735, 59494, 43552, 14844, 72778, 13541, 35459, 64926, 62423, 663, 90662, 52679, 40567, 66334, 65032, 35898, 69008, 40, 99513, 18281, 293, 55249, 10768, 10813, 2440, 87185, 4658, 36880, 78137, 78435, 62460, 36871, 54280, 6012, 68066, 27058, 35904, 3525, 8335, 98326, 20539, 98996, 51004, 77457, 65329, 32388, 13354, 50688, 32427, 29219, 68969, 49071, 84467, 96088, 59883, 3258, 83272, 64541, 40138, 77760, 59327, 2597, 14630, 13606, 24960, 82696, 57015, 77216, 2572, 65349, 91893, 39462, 64344, 59249, 16918, 46025, 91636, 46623, 96712, 24062, 75841, 82032, 73133, 76659, 78119, 49367, 96269, 77742, 30259, 36406, 55501, 89585, 55354, 86483, 19543, 80314, 85530, 76557, 73881, 88101, 41906, 65773, 27562, 22601, 41373, 60831, 68625, 33008, 23805, 81689, 73422, 15998, 80072, 46554, 9008, 58191, 95920, 5276, 52284, 26179, 41681, 24137, 32115, 97035, 10619, 51657, 93700, 12500, 28214, 83932, 600, 86471, 66056, 44513, 9071, 7429, 21695, 77696, 40436, 61851, 59384, 13857, 77848, 39455, 76762, 86856, 13997, 89034, 92131, 82633, 31564, 50164, 23121, 80030, 63550, 33739, 31687, 73601, 62590, 76252, 57532, 63189, 62722, 23587, 24053, 71792, 47367, 62099, 65839, 87803, 23949, 25222, 18011, 1797, 81029, 11125, 5004, 11377, 16510, 13486, 10361, 64425, 63649, 33481, 44454, 43550, 83571, 92492, 17150, 46160, 68743, 91033, 25700, 47816, 14620, 49752, 19608, 61986, 28202, 85446, 66140, 52151, 27020, 503, 70299, 24400, 27979, 91654, 35776, 44488, 5139, 46137, 25264, 85140, 79617, 69717, 45041, 63188, 62209, 62191, 25699, 47303, 53223, 51399, 95119, 84194, 1150, 14726, 62532, 45704, 16523, 45023, 97854, 43542, 61877, 84504, 84293, 89855, 76157, 20069, 50694, 97647, 82557, 75957, 99138, 78525, 62026, 44179, 58064, 24234, 22721, 83763, 71536, 75943, 35161, 66654, 76489, 52662, 97731, 39020, 98365, 14254, 394, 12570, 74147, 62271, 13425, 58440, 68477, 5933, 94860, 19171, 3580, 93768, 11479, 19069, 88644, 73504, 63247, 46708, 14089, 85967, 46822, 1977, 78262, 98334, 68630, 54750, 50995, 82713, 10121, 65712, 96966, 26866, 94633, 87464, 5488, 8058, 45903, 73965, 13990, 57114, 9487, 17569, 67233, 37317, 52990, 55877, 10821, 16236, 18936, 41261, 18555, 65757, 43237, 96816, 80442, 11867, 67917, 31436, 94579, 94389, 13499, 7896, 37606, 8132, 95359, 43094, 16189, 57614, 17058, 46530, 31079, 26544, 80451, 98312, 63860, 33440, 70540, 91032, 66027, 89475, 32293, 84581, 71583, 75529, 97748, 52024, 3747, 82016, 99811, 14677, 92756, 13310, 38924, 30362, 37793, 50635, 73455, 70333, 24600, 90512, 16862, 55678, 33407, 97312, 70341, 13618, 30751, 40880, 21002, 96778, 46706, 53294, 97710, 18288, 45174, 95458, 70311, 65273, 93825, 86474, 96301, 86581, 16135, 35225, 16942, 53927, 2211, 90396, 40611, 26810, 97259, 57472, 98839, 30665, 71136, 85532, 60634, 1886, 42763, 81635, 15015, 89469, 51280, 29077, 7756, 12806, 40886, 94419, 78078, 34710, 80892, 90730, 21290, 13378, 42306, 54583, 67304, 44516, 61330, 7914, 71325, 58588, 81737, 86516, 5604, 52872, 72047, 66238, 71110, 14809, 64224, 86124, 20629, 15504, 15200, 28385, 28309, 72437, 39155, 22738, 7147, 36398, 13467, 44788, 49775, 72125, 99371, 33430, 16640, 77052, 57695, 4317, 35640, 39431, 90832, 57595, 92303, 79230, 40184, 63412, 10390, 4408, 65887, 31019, 36263, 97439, 75755, 80923, 69875, 31261, 20012, 93373, 67658, 49830, 38161, 33784, 21954, 53883, 83565, 38594, 30934, 41259, 59262, 82925, 80689, 50093, 40520, 89343, 45674, 97055, 52754, 72415, 1462, 34993, 3433, 54076, 32431, 95539, 34998, 18657, 26799, 71361, 12030, 10808, 21191, 66542, 60943, 43144, 36776, 44507, 98089, 67709, 85765, 57350, 66986, 82806, 23794, 23857, 72148, 69467, 20911, 41254, 41882, 38725, 76246, 61666, 9152, 25028, 57205, 44150, 43684, 84003, 15510, 72065, 11163, 53052, 38606, 72105, 96196, 75381, 16612, 94284, 59442, 18728, 51634, 26427, 1533, 91779, 66635, 90033, 61246, 87545, 31286, 19479, 42621, 23883, 81144, 51773, 48910, 54700, 12274, 92593, 55055, 44135, 81010, 66217, 97187, 19615, 54673, 9734, 11348, 87636, 4017, 87141, 6364, 72002, 29919, 24248, 63781, 96553, 14280, 41378, 449, 61917, 60856, 43070, 85799, 58351, 11194, 34708, 13051, 23467, 43653, 68105, 67601, 41014, 50673, 81139, 60628, 5345, 90872, 88327, 92981, 11241, 75467, 15696, 99594, 5385, 56295, 79726, 18289, 86927, 21103, 18738, 48843, 98310, 78159, 50994, 73013, 89352, 2053, 2415, 12818, 45705, 86871, 96770, 86718, 37543, 94261, 63698, 59239, 85132, 68376, 68571, 12724, 60195, 84266, 12318, 65579, 56913, 92043, 83868, 43839, 29498, 18957, 9033, 44159, 97115, 60026, 17171, 86466, 62079, 19585, 15635, 24135, 6455, 28756, 27205, 60349, 23016, 90902, 19588, 8148, 75629, 88158, 20871, 35823, 88776, 49540, 17754, 62040, 57935, 17973, 5878, 87432, 36929, 14910, 31590, 34043, 91288, 65113, 36860, 53366, 84697, 52494, 93852, 7504, 81249, 21056, 67852, 20617, 28309, 3791, 28764, 3938, 8301, 65986, 56112, 13428, 31878, 73865, 75467, 89812, 91837, 81344, 93595, 45117, 12605, 25184, 95511, 20244, 90296, 32370, 73609, 91345, 1215, 83813, 15200, 98816, 4868, 99403, 19432, 49529, 3194, 64547, 69818, 27846, 46884, 25929, 41273, 78761, 99794, 16739, 84924, 7982, 14434, 78518, 69451, 43390, 3702, 64961, 63634, 10349, 13683, 53594, 18045, 14897, 37406, 49596, 30064, 58626, 48999, 65847, 8154, 52192, 30393, 77971, 96389, 93629, 3899, 37661, 88741, 20044, 70751, 73665, 44378, 1536, 52182, 13828, 44925, 72235, 95140, 24910, 98936, 8822, 78504, 33332, 40071, 15909, 82928, 70134, 90886, 31926, 52333, 99039, 469, 99077, 93361, 96857, 92705, 97260, 50869, 81446, 33655, 21619, 71462, 94384, 39506, 23643, 24563, 84430, 12230, 19703, 9340, 27517, 44876, 4195, 60848, 84946, 36455, 60127, 71432, 27341, 92052, 40116, 26379, 8872, 39192, 36092, 22080, 31897, 49703, 72948, 29694, 83357, 10918, 1155, 94093, 50423, 41149, 18655, 51205, 69730, 54709, 76896, 97246, 99585, 81090, 58094, 882, 17544, 18220, 88665, 44884, 26624, 28780, 87615, 51847, 67972, 40058, 73927, 16220, 89760, 46874, 45913, 73116, 74144, 63419, 83560, 24566, 20919, 2215, 92122, 90649, 73275, 69017, 87894, 72859, 66458, 62339, 90093, 354, 96911, 95109, 61589, 39886, 23889, 65555, 91732, 8212, 5612, 65658, 24431, 95371, 28884, 86695, 84839, 3027, 66465, 68398, 43944, 87383, 86964, 36066, 94383, 60239, 21434, 98629, 49449, 4244, 77319, 39541, 4597, 90581, 51002, 66185, 30466, 74890, 31740, 38550, 83101, 37351, 4207, 23883, 32722, 49442, 26929, 17560, 52468, 93393, 85957, 12764, 97127, 72921, 48829, 7862, 49511, 86614, 6490, 98959, 90857, 160, 54852, 95453, 90741, 5853, 77990, 37558, 97094, 9729, 76107, 96546, 47079, 96666, 20428, 96152, 46107, 63708, 30063, 14927, 73452, 16020, 27690, 70578, 5292, 92870, 94791, 71154, 79483, 1280, 70112, 86692, 1440, 41315, 98496, 8532, 47167, 76485, 46089, 44260, 86213, 22196, 57157, 49644, 18861, 77584, 45795, 81319, 57643, 75858, 96245, 31094, 8229, 23934, 18024, 29872, 16803, 12814, 1025, 96286, 30446, 87488, 99329, 31885, 28803, 97824, 56768, 92321, 74309, 2856, 52933, 76873, 25051, 10089, 26516, 60263, 4025, 88663, 41582, 61667, 80872, 37826, 9113, 5452, 78112, 27136, 35323, 94914, 39949, 52699, 7551, 70394, 56538, 6879, 18630, 1692, 4703, 75397, 10365, 95363, 78253, 63297, 72235, 19655, 89737, 15103, 96270, 10113, 3765, 37851, 88132, 988, 92028, 97244, 6439, 70139, 40731, 58113, 81405, 80679, 27163, 88955, 67425, 83700, 95834, 86054, 1744, 16888, 61451, 12108, 28602, 56055, 91756, 836, 92061, 97844, 32290, 88330, 7957, 36054, 42532, 12440, 37041, 50912, 26035, 59831, 37402, 66765, 17943, 18806, 63795, 45105, 7761, 31219, 45157, 19946, 17273, 46900, 53185, 95075, 75359, 81786, 67481, 67114, 98973, 59541, 81309, 31263, 64223, 5617, 83668, 6754, 18056, 37061, 74017, 60442, 96891, 11419, 27206, 31186, 30224, 91001, 92642, 54336, 22219, 54150, 90633, 55843, 1049, 43817, 50917, 92759, 41954, 18397, 76224, 57279, 77938, 57533, 88541, 58512, 63149, 72208, 65265, 97557, 25620, 55634, 57998, 22511, 67052, 1556, 70048, 13627, 92556, 62689, 67963, 31126, 16839, 58595, 86969, 34239, 18764, 54237, 26998, 60717, 72634, 19573, 34347, 66923, 77105, 22887, 25434, 56606, 11447, 7050, 54162, 37066, 62683, 28511, 75928, 46086, 30066, 45975, 59713, 38973, 25016, 44027, 86451, 41854, 18973, 89771, 92444, 37736, 44007, 35793, 14805, 32992, 55366, 49151, 99914, 32470, 88390, 41699, 89075, 16188, 65101, 59588, 69605, 44135, 88099, 45533, 90221, 34516, 7859, 66285, 73489, 49226, 10311, 76291, 7431, 29283, 66061, 99875, 83371, 10067, 35667, 14527, 43059, 7384, 80029, 59324, 39854, 68418, 1023, 45280, 84605, 66123, 21220, 54210, 10257, 25670, 16094, 16829, 60185, 40304, 83113, 50025, 89530, 9775, 26315, 96960, 55410, 92375, 13186, 38780, 18794, 65205, 69658, 78204, 72588, 49686, 37527, 28793, 34456, 54901, 90425, 19060, 37375, 11644, 89621, 47632, 37313, 22066, 80812, 13849, 62370, 63925, 63874, 68251, 73699, 6540, 65210, 45460, 15267, 94748, 84239, 34060, 59952, 53896, 28615, 48891, 19934, 66141, 94036, 54389, 37394, 84460, 89800, 74768, 12455, 79421, 38751, 66119, 1486, 19563, 79967, 80207, 99839, 60192, 48457, 89889, 66732, 30019, 35349, 81998, 41118, 19587, 32409, 1069, 89835, 77375, 66311, 26120, 43515, 60346, 80508, 97260, 44805, 70307, 72028, 57259, 66079, 10778, 23377, 83917, 30340, 19696, 64123, 30178, 79887, 28932, 20067, 46618, 75302, 55415, 44967, 16419, 91353, 93727, 33839, 97539, 71101, 149, 23658, 30968, 60495, 20517, 28227, 21651, 90824, 254, 95262, 73254, 11032, 34990, 57170, 57723, 54685, 37645, 4253, 50924, 82928, 40671, 97541, 58229, 12437, 58860, 74647, 20141, 52586, 8485, 17680, 40039, 8633, 57689, 71006, 85479, 78206, 99232, 23482, 85381, 15838, 18743, 58634, 43221, 70084, 32156, 943, 41121, 69800, 21547, 92044, 69079, 62217, 5936, 27307, 91005, 64795, 1953, 11146, 33733, 26789, 45177, 73771, 51773, 2865, 44776, 37252, 97422, 60359, 60733, 82802, 76196, 95827, 57788, 19416, 65910, 89943, 36711, 23382, 76094, 58257, 15425, 45172, 36826, 21361, 72478, 27830, 2507, 90782, 38975, 36239, 17570, 84151, 26361, 69342, 3368, 71136, 22945, 789, 31495, 29, 99943, 24042, 12207, 57730, 43458, 94469, 64024, 80168, 17850, 40117, 38424, 33275, 1640, 91601, 70987, 74117, 19431, 73493, 81250, 58405, 26084, 15171, 58908, 52444, 84512, 78627, 39932, 23809, 95767, 87778, 23837, 12061, 11819, 36044, 86142, 55276, 30512, 50165, 51795, 48361, 6633, 6571, 97987, 8272, 98171, 85325, 98740, 17601, 58818, 79989, 92358, 1253, 95159, 67617, 70048, 96023, 46243, 9979, 36183, 58361, 97756, 60019, 70422, 9575, 12414, 56563, 81202, 59277, 6728, 32997, 23990, 29712, 39567, 38328, 37984, 54089, 23653, 53075, 71690, 98822, 33064, 64047, 74, 44574, 48015, 70121, 56948, 94257, 96452, 93130, 52617, 94207, 69501, 39390, 20133, 81914, 95953, 17687, 57543, 19032, 67035, 81532, 48743, 6601, 19859, 86726, 60689, 43511, 39801, 48730, 42332, 89216, 29128, 58757, 50141, 77142, 45230, 7089, 87750, 41681, 218, 56719, 52239, 69718, 96108, 72372, 67984, 92060, 6410, 25526, 11091, 73444, 7057, 76186, 96396, 43267, 79263, 73436, 3130, 19063, 22166, 61813, 24630, 51293, 20570, 74771, 44787, 82151, 98211, 32536, 23831, 98428, 89254, 76069, 84498, 1714, 64792, 52481, 93773, 87553, 78006, 21216, 60996, 1414, 13753, 57391, 44680, 93015, 30827, 64161, 28430, 69344, 25974, 53059, 36988, 62895, 44181, 81774, 45045, 42391, 30662, 68875, 57171, 36267, 61295, 41668, 37980, 42439, 10500, 48105, 29991, 88505, 85672, 7339, 6270, 99424, 64729, 67301, 92438, 11907, 31462, 20867, 81250, 73787, 90278, 18238, 36681, 34458, 16363, 81725, 93201, 47024, 66951, 66723, 83291, 28245, 8390, 37622, 87035, 35241, 85726, 33378, 40097, 71397, 40716, 46366 };
            //var index = new List<int>() { 9751, 2629, 1641, 3594, 3606, 8859, 3147, 2860 };
            //var result = circularArrayRotation(numbers, 12592, index);


            //foreach (var item in result)
            //{
            //    Console.WriteLine(item);

            //}

            //Console.WriteLine(jumpingOnClouds(new int[] { 0, 0, 1, 0}, 2));

            //Console.ReadLine();

            //var result = QuickSortUtil.QuickSort(new List<int> { 2,1 });

            //var result = SortUtils.BubbleSort(new List<int> { 2,8, 6,6,2, 1, 5, 9, 10, 12 });


            //foreach (var item in result)
            //{
            //    Console.WriteLine(item);
            //}

            //Console.WriteLine( ClassicUtils.ReverseString2("2 abcdefgh"));

            //Console.WriteLine(ClassicUtils.IsPalindrome("kayak"));

            //Console.WriteLine(ClassicUtils.RemoveDuplicateCharacters2("23546676678"));

            //var result = ClassicUtils.FindAllSubstrings("abcd");

            //foreach (var item in result)
            //{
            //    Console.WriteLine(item);
            //}

            //AnotherClass ac1 = new AnotherClass(1);
            //AnotherClass ac2 = new AnotherClass(2);
            //AnotherClass ac3 = ac1+ac2;

            //Console.WriteLine(ac3.Number);

            //await AsynchronousProgramming.TaskParallel();

            //var result = ClassicUtils.RotateLeft(new int[5] { 1, 2, 3, 4, 5 }, 5).ToList() ;
            //result.ForEach(i => Console.WriteLine(i));

            //ClassicUtils.CribaErastotenes(20);

            // Console.WriteLine(ClassicUtils.IsPrime(23));



            //Console.WriteLine(appendAndDelete("aaaaaaaaaa", "aaaaa", 7));
            //Console.WriteLine(appendAndDelete("abcd", "abcdert", 10));
            // Console.WriteLine(appendAndDelete("qwerasdf", "qwerbsdf", 6));

            //var result = cutTheSticks(new List<int>() { 5, 4, 4, 2, 2, 8 });
            //result.ForEach(i => Console.WriteLine(i));
            //Console.WriteLine();

            //result = cutTheSticks(new List<int>() { 1,2 ,3, 4 ,3 ,3, 2, 1 });
            //result.ForEach(i => Console.WriteLine(i));
            //Console.WriteLine();

            // Console.WriteLine(  nonDivisibleSubset(4, new List<int>() { 19, 10, 12, 10, 24, 25, 22 })); 

            //Console.WriteLine(nonDivisibleSubset(9, new List<int>() 
            //{
            //    61197933,56459859,319018589,271720536,358582070,849720202,481165658,675266245,541667092,615618805,129027583,755570852,437001718,86763458,791564527,163795318,981341013,516958303,592324531,611671866,157795445,718701842,773810960,72800260,281252802,404319361,757224413,682600363,606641861,986674925,176725535,256166138,827035972,124896145,37969090,136814243,274957936,980688849,293456190,141209943,346065260,550594766,132159011,491368651,3772767,131852400,633124868,148168785,339205816,705527969,551343090,824338597,241776176,286091680,919941899,728704934,37548669,513249437,888944501,239457900,977532594,140391002,260004333,911069927,586821751,113740158,370372870,97014913,28011421,489017248,492953261,73530695,27277034,570013262,81306939,519086053,993680429,599609256,639477062,677313848,950497430,672417749,266140123,601572332,273157042,777834449,123586826
            //}) );

            // Console.WriteLine(repeatedString("bcbccacaacbbacabcabccacbccbababbbbabcccbbcbcaccababccbcbcaabbbaabbcaabbbbbbabcbcbbcaccbccaabacbbacbc", 649606239668));
            // Console.WriteLine(repeatedString("aba", 10));

            //Console.WriteLine(jumpingOnClouds(new List<int>() { 0,1,0,0,0,1,0}));
            //Console.WriteLine(jumpingOnClouds(new List<int>() { 0, 0, 0, 0, 1, 0 }));

            // Console.WriteLine(equalizeArray(new List<int>() { 3 ,3 ,2 ,1 ,3 }));

            //Console.WriteLine(taumBday(27984, 1402, 619246, 615589, 247954));

            //kaprekarNumbers(1, 99999);

            //Console.WriteLine(howManyGames(20, 3, 6, 70));
            //Console.WriteLine(howManyGames(20, 3, 6, 80));
            //Console.WriteLine(howManyGames(20, 3, 6, 85));

            //Console.WriteLine(chocolateFeast(15, 3, 2));

            //Console.WriteLine(chocolateFeast(10, 2, 5));

            //Console.WriteLine(chocolateFeast(12, 4, 4));

            //Console.WriteLine(chocolateFeast(6, 2, 2));

            //Console.WriteLine(chocolateFeast(7, 3, 2));

            //Console.WriteLine(workbook(5, 3, new List<int>() { 4,2,6,1,10 }));

            //Console.WriteLine(workbook(15, 20, new List<int>() { 1, 8 ,19, 15, 2 ,29, 3, 2 ,25, 2, 19, 26, 17, 33, 22 }));

            //Console.WriteLine(flatlandSpaceStations(5, new int[] { 0, 4 }));
            //Console.WriteLine(flatlandSpaceStations(1, new int[] { 0 }));
            Console.ReadLine();
        }
    }
}
