using Solver = DivideConquer.Solver<int[], int[]>;
using MergeSort = DivideConquer.Algorithms.MergeSort<int>;
using QuickSort = DivideConquer.Algorithms.QuickSort<int>;
using RandomArray = RandomGenerators.RandomArray;
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;

class DivideConquerMain {
  const int NUMBER_ARRAYS = 15;
  const int MIN_SIZE = 1;
  const string TITLE = @"

██████╗ ██╗██╗   ██╗██╗██████╗ ███████╗     █████╗ ███╗   ██╗██████╗      ██████╗ ██████╗ ███╗   ██╗ ██████╗ ██╗   ██╗███████╗██████╗ 
██╔══██╗██║██║   ██║██║██╔══██╗██╔════╝    ██╔══██╗████╗  ██║██╔══██╗    ██╔════╝██╔═══██╗████╗  ██║██╔═══██╗██║   ██║██╔════╝██╔══██╗
██║  ██║██║██║   ██║██║██║  ██║█████╗      ███████║██╔██╗ ██║██║  ██║    ██║     ██║   ██║██╔██╗ ██║██║   ██║██║   ██║█████╗  ██████╔╝
██║  ██║██║╚██╗ ██╔╝██║██║  ██║██╔══╝      ██╔══██║██║╚██╗██║██║  ██║    ██║     ██║   ██║██║╚██╗██║██║▄▄ ██║██║   ██║██╔══╝  ██╔══██╗
██████╔╝██║ ╚████╔╝ ██║██████╔╝███████╗    ██║  ██║██║ ╚████║██████╔╝    ╚██████╗╚██████╔╝██║ ╚████║╚██████╔╝╚██████╔╝███████╗██║  ██║
╚═════╝ ╚═╝  ╚═══╝  ╚═╝╚═════╝ ╚══════╝    ╚═╝  ╚═╝╚═╝  ╚═══╝╚═════╝      ╚═════╝ ╚═════╝ ╚═╝  ╚═══╝ ╚══▀▀═╝  ╚═════╝ ╚══════╝╚═╝  ╚═╝
                                                                                                                                      
";

  enum Algorithm {
    MergeSort,
    QuickSort,
    BinarySearch,
    HanoiTowers,
  }

  /// <summary>
  ///   Benchamrk the algorithms.
  /// </summary>
  /// <param name="algorithm">The algorithms to benchmark.</param>
  /// <param name="arrays">The arrays to benchmark.</param>
  /// <returns> The results of the benchmark.</returns>

  object[][] BenchAlgorithm(Solver algorithm, int [][] arrays) {
    object[][] timeResults = new object[arrays.Length][];
    Stopwatch sw = new Stopwatch();
    for (int i = 0; i < arrays.Length; i++) {
      sw.Reset();
      sw.Start();
      algorithm.Solve(arrays[i]);
      sw.Stop();
      timeResults[i] = new object[4] {
        algorithm.AlgorithmName(), 
        sw.ElapsedMilliseconds, 
        arrays[i].Length,
        algorithm.TimeComplexity()
      };
    }
    return timeResults;
  }

  /// <summary>
  ///   Print the results of the benchmark.
  /// </summary>
  /// <param name="timeResults">The results of the benchmark.</param>
  void PrintResults(object[][] timeResults) {
    Console.WriteLine("{0}", timeResults[0][0]);
    for (int i = 0; i < timeResults.Length; i++) {
      Console.Write("  Time: {0}", timeResults[i][1]);
      Console.WriteLine("  Size: {0}", timeResults[i][2]);
    }
    Console.WriteLine();
    Console.WriteLine("Time Complexity:");
    Console.WriteLine("  " + timeResults[0][3]);
    Console.WriteLine();
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

  void WriteCSV(object[][] timeResults, string fileName) {
    Directory.CreateDirectory("./csv");
    using (StreamWriter writer = new StreamWriter("./csv/" + fileName + ".csv")) {
      writer.WriteLine("{0}: Milliseconds,Size", timeResults[0][0]);
      for (int i = 0; i < timeResults.Length; i++) {
        writer.WriteLine("{0},{1}", timeResults[i][1], timeResults[i][2]);
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
    bool output = false;
    main.PrintTitle();
    if (args.Contains("-d")) main.PrintDebugMode();
    if (args.Contains("-o")) output = true;
    int option = main.PrintMenu();
    int[][] arrays = main.GenerateArrays(NUMBER_ARRAYS, int.MaxValue);
    switch (option) {
      case (int) Algorithm.MergeSort:
        MergeSort mergeSort = new MergeSort();
        Solver solver = new Solver(mergeSort);
        object[][] timeResults = main.BenchAlgorithm(solver, arrays);
        main.PrintResults(timeResults);
        if (output) main.WriteCSV(timeResults, "MergeSort");
        return;
      case (int) Algorithm.QuickSort:
        QuickSort quickSort = new QuickSort();
        solver = new Solver(quickSort);
        timeResults = main.BenchAlgorithm(solver, arrays);
        main.PrintResults(timeResults);
        if (output) main.WriteCSV(timeResults, "QuickSort");
        return;
      case (int) Algorithm.BinarySearch: return;
      case (int) Algorithm.HanoiTowers: return;
    }
    // int[][] arrays = main.GenerateArrays(NUMBER_ARRAYS, int.MaxValue);
    // Solver[] algorithms = main.CreateAlgorithms();
    // object[][][] timeResults = main.TimeSorts(algorithms, arrays);
    // if (args.Length > 1 && args[0] == "-o") {
    //   main.WriteCSV(timeResults, args[1]);
    // } else main.PrintResults(timeResults);
  }

  void PrintTitle() {
    Console.Clear();
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine("{0}", TITLE);
    Console.ResetColor();
  }

  int PrintMenu() {
    Console.OutputEncoding = System.Text.Encoding.UTF8;
    Console.WriteLine("Choose Algorithm:");
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine("  Merge Sort ➗");
    Console.ResetColor();
    Console.ForegroundColor = ConsoleColor.Blue;
    Console.WriteLine("  Quick Sort 💨");
    Console.ResetColor();
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.WriteLine("  Binary Search 🔍");
    Console.ResetColor();
    Console.ForegroundColor = ConsoleColor.Magenta;
    Console.WriteLine("  Hanoi Towers 🗼");
    Console.ResetColor();
    Console.SetCursorPosition(0, Console.CursorTop - 1);
    const int MAX = 4;
    int current = 3;
    while(true) {
      switch (Console.ReadKey(true).Key) {
        case ConsoleKey.UpArrow:
          if (current - 1 >= 0) {
            Console.SetCursorPosition(0, Console.CursorTop);
            Console.Write(" ");
            Console.SetCursorPosition(0, Console.CursorTop - 1);
            Console.Write(">");
            Console.SetCursorPosition(0, Console.CursorTop);
            current--;
          }
          break;
        case ConsoleKey.DownArrow:
          if (current + 1 < MAX) {
            Console.SetCursorPosition(0, Console.CursorTop);
            Console.Write(" ");
            Console.SetCursorPosition(0, Console.CursorTop + 1);
            Console.Write(">");
            Console.SetCursorPosition(0, Console.CursorTop);
            current++;
          }
          break;
        case ConsoleKey.Enter:
        default:
          Console.Clear();
          return current;
      }
    }
  }

  void PrintDebugMode() {
    Console.WriteLine("Debug Mode");
    Console.WriteLine();
  }
}
