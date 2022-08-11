﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    internal class Program
    {
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
    }


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

    static void Main(string[] args)
    {

        //var result =  compareTriplets(new List<int>() { 1, 2, 3 }, new List<int>() { 1, 4, 3 });

        // foreach (var item in result)
        //{
        //    Console.WriteLine(item);
        //}

        //plusMinus(new List<int>() { -4, 3, -9, 0, 4, 1 });

        //staircase(6);

        //miniMaxSum(new List<int>() { 256741038 ,623958417, 467905213, 714532089 ,938071625 });

        //Console.WriteLine(birthdayCakeCandles(new List<int>() { 4, 4, 1, 3, }));

        Console.WriteLine(timeConversion("12:00:00PM"));

        Console.ReadLine();
    }
}
}
