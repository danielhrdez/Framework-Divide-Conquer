using Solver = DivideConquer.Solver<int[], int[]>;
using MergeSort = DivideConquer.Algorithms.MergeSort<int>;
using QuickSort = DivideConquer.Algorithms.QuickSort<int>;
using RandomArray = RandomGenerators.RandomArray;
using System;
using System.Diagnostics;

class DivideConquerMain {
  const int MAX_SIZE = 100;

  Solver[] CreateAlgorithms() {
    Solver mergeSort = new Solver(new MergeSort());
    Solver quickSort = new Solver(new QuickSort());
    return new Solver[] { mergeSort, quickSort };
  }

  long[][][] TimeSorts(Solver[] algorithms, int [][] arrays) {
    long[][][] timeResults = new long[algorithms.Length][][];
    Stopwatch sw = new Stopwatch();
    for (int i = 0; i < algorithms.Length; i++) {
      timeResults[i] = new long[arrays.Length][];
      for (int j = 0; j < arrays.Length; j++) {
        sw.Start();
        algorithms[i].Solve(arrays[j], arrays[j].Length);
        sw.Stop();
        timeResults[i][j] = new long[2] {sw.ElapsedMilliseconds, arrays[j].Length};
      }
    }
    return timeResults;
  }

  void PrintResults(long[][][] timeResults) {
    for (int i = 0; i < timeResults.Length; i++) {
      Console.WriteLine("Algorithm {0}", i);
      for (int j = 0; j < timeResults[i].Length; j++) {
        Console.WriteLine("  Time: {0}", timeResults[i][j][0]);
        Console.WriteLine("  Size: {0}", timeResults[i][j][1]);
      }
    }
  }

  int[][] GenerateArrays(int maxSize, int maxValue) {
    int[][] arrays = new int[maxSize][];
    RandomArray generator = new RandomArray();
    for (int size = 0; size < maxSize; size++) {
      arrays[size] = generator.Create(size + 1, (int seed) => {
        return new Random(seed).Next(maxValue);
      });
    }
    return arrays;
  }

  static void Main() {
    DivideConquerMain main = new DivideConquerMain();
    int[][] arrays = main.GenerateArrays(MAX_SIZE, int.MaxValue);
    Solver[] algorithms = main.CreateAlgorithms();
    long[][][] timeResults = main.TimeSorts(algorithms, arrays);
    main.PrintResults(timeResults);
  }
}
