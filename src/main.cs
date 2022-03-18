using static DivideConquer.DivideConquer;
using static Algorithms.MergeSort;
using static Algorithms.QuickSort;
using static RandomGenerators.RandomArray;

using System;

int size = 100;
int[] randomArray = RandomArray.Create(size, Random);
MergeSort<int> mergeSort = new MergeSort<int>();
QuickSort<int> quickSort = new QuickSort<int>();
DivideConquer<int[], int[]> divideConquer = new DivideConquer<int[], int[]>(mergeSort);
int[] sorted = divideConquer.solve(randomArray);

Console.WriteLine("Random array:");
Console.WriteLine(string.Join(", ", randomArray));
Console.WriteLine("Sorted array:");
Console.WriteLine(string.Join(", ", sorted));
