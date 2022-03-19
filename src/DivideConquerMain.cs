using Solver = DivideConquer.Solver<int[], int[]>;
using MergeSort = DivideConquer.Algorithms.MergeSort<int>;
using QuickSort = DivideConquer.Algorithms.QuickSort<int>;
using RandomArray = RandomGenerators.RandomArray;
using System;
using System.Diagnostics;

class DivideConquerMain {
  const int MAX_SIZE = 5;

  /// <summary>
  ///   Instanciate the algorithms
  /// </summary>
  /// <returns>The algorithms.</returns>
  Solver[] CreateAlgorithms() {
    Solver mergeSort = new Solver(new MergeSort());
    Solver quickSort = new Solver(new QuickSort());
    return new Solver[] { mergeSort, quickSort };
  }

  /// <summary>
  ///   Benchamrk the algorithms.
  /// </summary>
  /// <param name="algorithms">The algorithms to benchmark.</param>
  /// <param name="arrays">The arrays to benchmark.</param>
  /// <returns> The results of the benchmark.</returns>

  object[][][] TimeSorts(Solver[] algorithms, int [][] arrays) {
    object[][][] timeResults = new object[algorithms.Length][][];
    Stopwatch sw = new Stopwatch();
    for (int i = 0; i < algorithms.Length; i++) {
      timeResults[i] = new object[arrays.Length][];
      for (int j = 0; j < arrays.Length; j++) {
        sw.Start();
        algorithms[i].Solve(arrays[j]);
        sw.Stop();
        timeResults[i][j] = new object[3] {
          algorithms[i].GetAlgorithmName(), 
          sw.ElapsedMilliseconds, 
          arrays[j].Length
        };
      }
    }
    return timeResults;
  }

  /// <summary>
  ///   Print the results of the benchmark.
  /// </summary>
  /// <param name="timeResults">The results of the benchmark.</param>
  void PrintResults(object[][][] timeResults) {
    for (int i = 0; i < timeResults.Length; i++) {
      Console.WriteLine("{0}", timeResults[i][0][0]);
      for (int j = 0; j < timeResults[i].Length; j++) {
        Console.Write("  Time: {0}", timeResults[i][j][1]);
        Console.WriteLine("  Size: {0}", timeResults[i][j][2]);
      }
      Console.WriteLine();
    }
  }

  /// <summary>
  ///   Generate random arrays.
  /// </summary>
  /// <param name="size">The size of the arrays.</param>
  /// <param name="generator">The random generator.</param>
  /// <returns>The random arrays.</returns>
  int[][] GenerateArrays(int maxSize, int maxValue) {
    int[][] arrays = new int[maxSize][];
    RandomArray generator = new RandomArray();
    for (int size = 1, i = 0; i < maxSize; size *= 2, i++) {
      arrays[i] = generator.Create(size, (int seed) => {
        return new Random(seed).Next(maxValue);
      });
    }
    return arrays;
  }

  /// <summary>
  ///   Main method.
  ///   Generate random arrays, 
  ///   benchmark the algorithms and print the results.
  /// </summary>
  static void Main() {
    DivideConquerMain main = new DivideConquerMain();
    int[][] arrays = main.GenerateArrays(MAX_SIZE, int.MaxValue);
    Solver[] algorithms = main.CreateAlgorithms();
    object[][][] timeResults = main.TimeSorts(algorithms, arrays);
    main.PrintResults(timeResults);
  }
}
