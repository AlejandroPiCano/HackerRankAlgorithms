using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    internal static class SortUtils
    {
        public static List<int> QuickSort(List<int> list)
        {
            //int l = 0;
            //int r = list.Count - 1;

            //QuickSortRec(list, l, r);
            // return list;


            return QuickSortRec(list);
        }

        //private static List<int> QuickSortRec(int l, int r, int p, List<int> list)
        //{
        //    if (list.Count == 0 || list.Count == 1)
        //        return list;

        //    while (l < r && l < list.Count && r > 0)
        //    {
        //        if (list[l] >= list[p] && list[r] <= list[p])
        //        {
        //            Swap(list, l, r);
        //            l++;
        //            r--;
        //        }
        //        else if (list[l] >= list[p])
        //        {
        //            l++;
        //        }
        //        else if (list[r] <= list[p])
        //        {
        //            r--;
        //        }
        //    }

        //    if (l >= r)
        //    {
        //        Swap(list, p, r);
        //        //p = r;
        //    }

        //    var splitLeftList = list.GetRange(0, l - 1);
        //    var leftList = QuickSortRec(0, splitLeftList.Count - 1, splitLeftList.Count / 2, splitLeftList);

        //    var splitRigthList = list.GetRange(l, list.Count - l);

        //    var rigthList = QuickSortRec(0, splitRigthList.Count - 1, splitRigthList.Count / 2, splitRigthList);

        //    return leftList.Union(rigthList).ToList();
        //}

        private static void Swap(List<int> list, int i, int j)
        {
            var temp = list[i];
            list[i] = list[j];
            list[j] = temp;
        }


        //static int Partition(List<int> arr, int low, int high)
        //{
        //    int pivot = arr[high];
        //    int i = low - 1;

        //    for (int j = low; j < high; j++)
        //    {
        //        if (arr[j] <= pivot)
        //        {
        //            i++;
        //            int temp = arr[i];
        //            arr[i] = arr[j];
        //            arr[j] = temp;
        //        }
        //    }

        //    int temp1 = arr[i + 1];
        //    arr[i + 1] = arr[high];
        //    arr[high] = temp1;

        //    return i + 1;
        //}

        //static void QuickSortRec(List<int> arr, int low, int high)
        //{
        //    if (low < high)
        //    {
        //        int pi = Partition(arr, low, high);

        //        QuickSortRec(arr, low, pi - 1);
        //        QuickSortRec(arr, pi + 1, high);
        //    }
        //}


        static List<int> QuickSortRec(List<int> list)
        {
            if (list.Count <= 1)
                return list;

            int pivot = list[list.Count - 1];//The pivot is always the last element
            var exceptPivotList = list.GetRange(0, list.Count - 1);
            var lowerThanPivotList = exceptPivotList.Where(i => i <= pivot).ToList();
            var greaterThanPivotList = exceptPivotList.Where(i => i > pivot).ToList();

            var leftRec = QuickSortRec(lowerThanPivotList);
            var rightRec = QuickSortRec(greaterThanPivotList);

            leftRec.Add(pivot);
            leftRec.AddRange(rightRec);

            return leftRec;
        }

        public static List<int> BubbleSort(List<int> list)
        {
            for (int i = 0; i < list.Count-1; i++)
            {
                for (int j = i+1; j < list.Count; j++)
                {
                    if (list[j] < list[i])
                        Swap(list, i, j);
                }
            }

            return list;
        }
          

}
}
