/// Universidad de La Laguna
/// Grado en Ingeniería Informática
/// Diseño y Análisis de Algoritmos
/// <author name="Daniel Hernandez de Leon"></author>
/// <class name="DivideConquerMain"> Programa principal para el ejercicio de Divide y Vencerás </class>

using Sorter = DivideConquer.Solver<int[], int[]>;
using Searcher = DivideConquer.Solver<DivideConquer.Types.Search<int>, int>;
using MergeSort = DivideConquer.Algorithms.MergeSort<int>;
using QuickSort = DivideConquer.Algorithms.QuickSort<int>;
using SearchInt = DivideConquer.Types.Search<int>;
using Tower = DivideConquer.Types.Tower;
using Step = DivideConquer.Types.Step;
using BinarySearch = DivideConquer.Algorithms.BinarySearch<DivideConquer.Types.Search<int>, int>;
using HanoiTower = DivideConquer.Algorithms.HanoiTower;
using TowerSolver = DivideConquer.Solver<DivideConquer.Types.Tower, DivideConquer.Types.Step[]>;
using RandomGenerators;
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;

class DivideConquerMain {
  const int NUMBER_ARRAYS = 18;
  const int NUMBER_SEARCH = 28;
  const int NUMBER_TOWERS = 5;
  const int MAX_VALUE = 100;
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
    HanoiTower,
  }

  /// <summary>
  ///   Benchamrk the algorithms.
  /// </summary>
  /// <param name="algorithm">The algorithms to benchmark.</param>
  /// <param name="arrays">The arrays to benchmark.</param>
  /// <returns> The results of the benchmark.</returns>
  object[][] BenchSort(Sorter algorithm, int[][] arrays, bool debug) {
    int[] result;
    object[][] timeResults = new object[arrays.Length][];
    Stopwatch sw = new Stopwatch();
    for (int i = 0; i < arrays.Length; i++) {
      sw.Reset();
      sw.Start();
      result = algorithm.Solve(arrays[i]);
      sw.Stop();
      if (debug) Console.WriteLine("Sorted Array: [" + string.Join(", ", result) + "]\n");
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
  ///   Benchamrk the algorithms.
  /// </summary>
  /// <param name="algorithm">The algorithms to benchmark.</param>
  /// <param name="arrays">The arrays to benchmark.</param>
  /// <returns> The results of the benchmark.</returns>
  object[][] BenchSearch(Searcher algorithm, SearchInt[] arrays, bool debug) {
    int result;
    object[][] timeResults = new object[arrays.Length][];
    Stopwatch sw = new Stopwatch();
    for (int i = 0; i < arrays.Length; i++) {
      sw.Reset();
      sw.Start();
      result = algorithm.Solve(arrays[i]);
      sw.Stop();
      if (debug) Console.WriteLine("Found value at: " + result + "\n");
      timeResults[i] = new object[4] {
        algorithm.AlgorithmName(), 
        sw.ElapsedMilliseconds, 
        arrays[i].List.Length,
        algorithm.TimeComplexity()
      };
    }
    return timeResults;
  }

  /// <summary>
  ///   Benchamrk the algorithms.
  /// </summary>
  /// <param name="algorithm">The algorithms to benchmark.</param>
  /// <param name="arrays">The arrays to benchmark.</param>
  /// <returns> The results of the benchmark.</returns>
  object[][] BenchTower(TowerSolver algorithm, Tower[] arrays, bool debug) {
    object[][] timeResults = new object[arrays.Length][];
    Stopwatch sw = new Stopwatch();
    for (int i = 0; i < arrays.Length; i++) {
      sw.Reset();
      sw.Start();
      Step[] steps = algorithm.Solve(arrays[i]);
      sw.Stop();
      if (debug) {
        int index = 0;
        string result = "";
        foreach (Step step in steps) {
          result += "Step " + index + ": \n  " + step.ToString() + "\n";
          index++;
        }
        Console.WriteLine(result);
      }
      timeResults[i] = new object[4] {
        algorithm.AlgorithmName(), 
        sw.ElapsedMilliseconds, 
        arrays[i].Disks,
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
  /// <param name="maxSize">The size of the arrays.</param>
  /// <param name="maxValue">The random generator.</param>
  /// <returns>The random arrays.</returns>
  int[][] GenerateArrays(int minSize, int maxSize, int maxValue) {
    int[][] arrays = new int[maxSize][];
    RandomArray<int> generator = new RandomArray<int>();
    for (int size = minSize, i = 0; i < maxSize; size *= 2, i++) {
      arrays[i] = generator.Create(size, (int seed) => {
        return new Random(seed).Next(maxValue);
      });
    }
    return arrays;
  }

  /// <summary>
  ///   Generate search arrays.
  /// </summary>
  /// <param name="size">The size of the arrays.</param>
  /// <returns>The search arrays.</returns>
  SearchInt[] GenerateSearchArrays(int minSize, int maxSize) {
    SearchInt[] arrays = new SearchInt[maxSize];
    int[] intArray;
    for (int size = minSize, i = 0; i < maxSize; size *= 2, i++) {
      intArray = new int[size];
      for (int j = 0; j < size; j++) {
        intArray[j] = j;
      }
      int randomPosition = new Random().Next(size);
      arrays[i] = new SearchInt(intArray, intArray[randomPosition]);
    }
    return arrays;
  }

  /// <summary>
  ///   Generate Tower arrays.
  /// </summary>
  /// <param name="size">The size of the arrays.</param>
  /// <returns>The Tower arrays.</returns>
  Tower[] GenerateTowerArrays(int minSize, int maxSize) {
    Tower[] towers = new Tower[maxSize];
    for (int size = minSize, i = 0; i < maxSize; size *= 2, i++) {
      towers[i] = new Tower(size);
    }
    return towers;
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
    bool debug = false;
    int[][] arrays;
    SearchInt[] searchArrays;
    Tower[] towerArrays;
    Sorter sorter;
    int size = 1;
    main.PrintTitle();
    if (args.Contains("-d")) {
      debug = true;
      main.PrintDebugMode();
    }
    if (args.Contains("-o")) output = true;
    Algorithm option = main.PrintMenu();
    if (debug) size = main.ChooseSize();
    switch (option) {
      case Algorithm.MergeSort:
        if (!debug) arrays = main.GenerateArrays(size, NUMBER_ARRAYS, MAX_VALUE);
        else {
          arrays = main.GenerateArrays(size, 1, MAX_VALUE);
          Console.WriteLine("Array generated: [" + string.Join(", ", arrays[0]) + "]\n");
        }
        sorter = new Sorter(new MergeSort());
        object[][] timeResults = main.BenchSort(sorter, arrays, debug);
        main.PrintResults(timeResults);
        if (output) main.WriteCSV(timeResults, "MergeSort");
        return;
      case Algorithm.QuickSort:
        if (!debug) arrays = main.GenerateArrays(size, NUMBER_ARRAYS, MAX_VALUE);
        else {
          arrays = main.GenerateArrays(size, 1, MAX_VALUE);
          Console.WriteLine("Array generated: [" + string.Join(", ", arrays[0]) + "]\n");
        }
        sorter = new Sorter(new QuickSort());
        timeResults = main.BenchSort(sorter, arrays, debug);
        main.PrintResults(timeResults);
        if (output) main.WriteCSV(timeResults, "QuickSort");
        return;
      case Algorithm.BinarySearch:
        if (!debug) searchArrays = main.GenerateSearchArrays(size, NUMBER_SEARCH);
        else {
          searchArrays = main.GenerateSearchArrays(size, 1);
          Console.WriteLine("Array generated: [" + string.Join(", ", searchArrays[0].List) + "]\n");
          Console.WriteLine("Target: " + searchArrays[0].Target + "\n");
        }
        BinarySearch binarySearch = new BinarySearch();
        Searcher search = new Searcher(binarySearch);
        timeResults = main.BenchSearch(search, searchArrays, debug);
        main.PrintResults(timeResults);
        if (output) main.WriteCSV(timeResults, "BinarySearch");
        return;
      case Algorithm.HanoiTower:
        if (!debug) towerArrays = main.GenerateTowerArrays(size, NUMBER_TOWERS);
        else towerArrays = main.GenerateTowerArrays(size, 1);
        HanoiTower HanoiTower = new HanoiTower();
        TowerSolver solver = new TowerSolver(HanoiTower);
        timeResults = main.BenchTower(solver, towerArrays, debug);
        main.PrintResults(timeResults);
        if (output) main.WriteCSV(timeResults, "HanoiTower");
        return;
    }
  }

  int ChooseSize() {
    string read;
    int size;
    string message = "Choose the size of the arrays: ";
    Console.Write(message);
    while (true) {
      Console.ForegroundColor = ConsoleColor.Yellow;
      read = Console.ReadLine();
      Console.ResetColor();
      Console.WriteLine();
      if (int.TryParse(read, out size)) {
        if (size > 0) return size;
      }
      Console.SetCursorPosition(message.Length, Console.CursorTop - 2);
    }
  }

  void PrintTitle() {
    Console.Clear();
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine("{0}", TITLE);
    Console.ResetColor();
  }

  Algorithm PrintMenu() {
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
    Console.SetCursorPosition(0, Console.CursorTop - 4);
    Console.Write(">");
    Console.SetCursorPosition(0, Console.CursorTop);
    const int MAX = 4;
    int current = 0;
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
          Console.SetCursorPosition(0, Console.CursorTop + 5 - current);
          return (Algorithm) current;
      }
    }
  }

  void PrintDebugMode() {
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine("Debug Mode");
    Console.WriteLine();
    Console.ResetColor();
  }
}
