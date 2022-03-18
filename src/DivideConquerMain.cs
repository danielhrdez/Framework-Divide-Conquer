using DivideConquerSolver = DivideConquer.DivideConquerSolver<int[], int[]>;
using MergeSort = DivideConquer.Algorithms.MergeSort<int[]>;
using QuickSort = DivideConquer.Algorithms.QuickSort<int[]>;
using RandomArray = RandomGenerators.RandomArray;
using System;

class DivideConquerMain {
  const int SIZE = 100;

  DivideConquerSolver[] CreateAlgorithms() {
    DivideConquerSolver mergeSort = new DivideConquerSolver(new MergeSort());
    DivideConquerSolver quickSort = new DivideConquerSolver(new QuickSort());
    return new DivideConquerSolver[] { mergeSort, quickSort };
  }

  int[][] Sort(DivideConquerSolver[] algorithms, int [] array) {
    int[][] results = new int[algorithms.Length][];
    for (int i = 0; i < algorithms.Length; i++) {
      results[i] = algorithms[i].Solve(array);
    }
    return results;
  }

  void PrintResults(int[][] results) {
    for (int i = 0; i < results.Length; i++) {
      Console.WriteLine("Algorithm " + i + ":");
      Console.WriteLine(string.Join(", ", results[i]));
    }
  }

  void Main() {
    int[] array = RandomArray.Create(SIZE, () => new Random().Next(int.MaxValue));
    Console.WriteLine("Array:");
    Console.WriteLine(string.Join(", ", array));
    DivideConquerSolver[] algorithms = CreateAlgorithms();
    int[][] results = Sort(algorithms, array);
    printResults(results);
  }
}
