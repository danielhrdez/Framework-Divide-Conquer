using Solver = DivideConquer.Solver<int[], int[]>;
using MergeSort = DivideConquer.Algorithms.MergeSort<int>;
using QuickSort = DivideConquer.Algorithms.QuickSort<int>;
using RandomArray = RandomGenerators.RandomArray;
using System;
using System.Diagnostics;
using System.IO;

class DivideConquerMain {
  const int NUMBER_ARRAYS = 18;
  const int MIN_SIZE = 1;

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
        sw.Reset();
        sw.Start();
        algorithms[i].Solve(arrays[j]);
        sw.Stop();
        timeResults[i][j] = new object[4] {
          algorithms[i].AlgorithmName(), 
          sw.ElapsedMilliseconds, 
          arrays[j].Length,
          algorithms[i].TimeComplexity()
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
      Console.WriteLine("  Time Complexity:");
      Console.WriteLine("    " + timeResults[i][0][3]);
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
    for (int size = MIN_SIZE, i = 0; i < maxSize; size *= 2, i++) {
      arrays[i] = generator.Create(size, (int seed) => {
        return new Random(seed).Next(maxValue);
      });
    }
    return arrays;
  }

  void WriteCSV(object[][][] timeResults, string fileName) {
    using (StreamWriter writer = new StreamWriter(fileName + ".csv")) {
      for (int i = 0; i < timeResults.Length; i++) {
        writer.Write("{0}: Milliseconds,", timeResults[i][0][0]);
      }
      writer.WriteLine("Size");
      for (int j = 0; j < timeResults[0].Length; j++) {
        for (int i = 0; i < timeResults.Length; i++) {
          writer.Write("{0}", timeResults[i][j][1]);
          if (i < timeResults.Length - 1) {
            writer.Write(",");
          }
        }
        writer.WriteLine("," + timeResults[0][j][2]);
      }
    }
  }

  /// <summary>
  ///   Main method.
  ///   Generate random arrays, 
  ///   benchmark the algorithms and print the results.
  /// </summary>
  /// <param name="args">The arguments.</param>
  static void Main(string[] args) {
    DivideConquerMain main = new DivideConquerMain();
    int[][] arrays = main.GenerateArrays(NUMBER_ARRAYS, int.MaxValue);
    Solver[] algorithms = main.CreateAlgorithms();
    object[][][] timeResults = main.TimeSorts(algorithms, arrays);
    if (args.Length > 1 && args[0] == "-o") {
      main.WriteCSV(timeResults, args[1]);
    } else main.PrintResults(timeResults);
  }
}
