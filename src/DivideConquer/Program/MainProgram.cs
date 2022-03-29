/// Universidad de La Laguna
/// Grado en Ingeniería Informática
/// Diseño y Análisis de Algoritmos
/// <author name="Daniel Hernandez de Leon"></author>
/// <class name="DivideConquerMain"> Programa principal para el ejercicio de Divide y Vencerás </class>

using IO;
using DivideConquer.Types;

namespace Program {
  class MainProgram {
    /// <summary>
    ///   Main method.
    ///   Generate random arrays, 
    ///   benchmark the algorithms and print the results.
    /// </summary>
    /// <param name="args">The arguments.</param>
    static void Main(string[] args) {
      Printer printer = new Printer();
      Scanner scanner = new Scanner();
      bool debug = false;
      bool output = false;
      Constants.ALGORITHM option;
      int size = 1;

      printer.PrintTitle(Constants.TITLE);
      if (args.Contains("-d")) {
        debug = true;
        printer.DebugMode();
      }
      if (args.Contains("-o")) output = true;
      option = printer.PrintMenu();
      if (debug) size = scanner.ChooseSize();
      SwitchAlgorithm(option, size, debug, output);
    }

    /// <summary>
    ///   Executes the Merge Sort algorithm.
    /// </summary>
    /// <param name="size">The size of the array.</param>
    /// <param name="debug">If true, the user can choose the size of the array.</param>
    /// <param name="output">If true, the results will be printed on csv file.</param>
    public static void Mergesort(int size, bool debug, bool output) {
      Generator generator = new Generator();
      Benchmark benchmark = new Benchmark();
      BenchmarkThreading benchmarkThreading = new BenchmarkThreading();
      Printer printer = new Printer();
      Writer writer = new Writer();
      int[][] arrays;
      object[][] timeResults;

      if (!debug) arrays = generator.GenerateArrays(size, Constants.NUMBER_ARRAYS, Constants.MAX_VALUE);
      else arrays = generator.GenerateArrays(size, 1, Constants.MAX_VALUE);
      timeResults = benchmark.BenchSort(Constants.ALGORITHM.MergeSort, arrays, debug);
      printer.PrintResults(timeResults);
      // timeResults = benchmarkThreading.BenchSort(Constants.ALGORITHM.MergeSort, arrays, debug);
      // printer.PrintResults(timeResults);
      if (output) writer.WriteCSV(timeResults, Constants.ALGORITHM.MergeSort.ToString());
    }

    /// <summary>
    ///   Executes the Quick Sort algorithm.
    /// </summary>
    /// <param name="size">The size of the array.</param>
    /// <param name="debug">If true, the user can choose the size of the array.</param>
    /// <param name="output">If true, the results will be printed on csv file.</param>
    public static void Quicksort(int size, bool debug, bool output) {
      Generator generator = new Generator();
      Benchmark benchmark = new Benchmark();
      BenchmarkThreading benchmarkThreading = new BenchmarkThreading();
      Printer printer = new Printer();
      Writer writer = new Writer();
      int[][] arrays;
      object[][] timeResults;

      if (!debug) arrays = generator.GenerateArrays(size, Constants.NUMBER_ARRAYS, Constants.MAX_VALUE);
      else arrays = generator.GenerateArrays(size, 1, Constants.MAX_VALUE);
      timeResults = benchmark.BenchSort(Constants.ALGORITHM.QuickSort, arrays, debug);
      printer.PrintResults(timeResults);
      // timeResults = benchmarkThreading.BenchSort(Constants.ALGORITHM.QuickSort, arrays, debug);
      // printer.PrintResults(timeResults);
      if (output) writer.WriteCSV(timeResults, Constants.ALGORITHM.QuickSort.ToString());
    }

    /// <summary>
    ///   Executes the Binary Search algorithm.
    /// </summary>
    /// <param name="size">The size of the array.</param>
    /// <param name="debug">If true, the user can choose the size of the array.</param>
    /// <param name="output">If true, the results will be printed on csv file.</param>
    public static void BinarySearch(int size, bool debug, bool output) {
      Generator generator = new Generator();
      Benchmark benchmark = new Benchmark();
      BenchmarkThreading benchmarkThreading = new BenchmarkThreading();
      Printer printer = new Printer();
      Writer writer = new Writer();
      Search<int>[] searchArrays;
      object[][] timeResults;

      if (!debug) searchArrays = generator.GenerateSearchArrays(size, Constants.NUMBER_SEARCH);
      else searchArrays = generator.GenerateSearchArrays(size, 1);
      timeResults = benchmark.BenchSearch(Constants.ALGORITHM.BinarySearch, searchArrays, debug);
      printer.PrintResults(timeResults);
      // timeResults = benchmarkThreading.BenchSearch(Constants.ALGORITHM.BinarySearch, searchArrays, debug);
      // printer.PrintResults(timeResults);
      if (output) writer.WriteCSV(timeResults, Constants.ALGORITHM.BinarySearch.ToString());
    }

    /// <summary>
    ///   Executes the Hanoi Tower algorithm.
    /// </summary>
    /// <param name="size">The size of the array.</param>
    /// <param name="debug">If true, the user can choose the size of the array.</param>
    /// <param name="output">If true, the results will be printed on csv file.</param>
    public static void HanoiTower(int size, bool debug, bool output) {
      Generator generator = new Generator();
      Benchmark benchmark = new Benchmark();
      BenchmarkThreading benchmarkThreading = new BenchmarkThreading();
      Printer printer = new Printer();
      Writer writer = new Writer();
      Tower[] towerArrays;
      object[][] timeResults;

      if (!debug) towerArrays = generator.GenerateTowerArrays(size, Constants.NUMBER_TOWERS);
      else towerArrays = generator.GenerateTowerArrays(size, 1);
      timeResults = benchmark.BenchTower(Constants.ALGORITHM.HanoiTower, towerArrays, debug);
      printer.PrintResults(timeResults);
      // timeResults = benchmarkThreading.BenchTower(Constants.ALGORITHM.HanoiTower, towerArrays, debug);
      // printer.PrintResults(timeResults);
      if (output) writer.WriteCSV(timeResults, Constants.ALGORITHM.HanoiTower.ToString());
    }

    /// <summary>
    ///   Executes the right algorithm.
    /// </summary>
    /// <param name="option">The option of the algorithm.</param>
    /// <param name="size">The size of the array.</param>
    /// <param name="debug">If true, the user can choose the size of the array.</param>
    /// <param name="output">If true, the results will be printed on csv file.</param>
    public static void SwitchAlgorithm(Constants.ALGORITHM option, int size, bool debug, bool output) {
      switch (option) {
        case Constants.ALGORITHM.MergeSort:
          Mergesort(size, debug, output);
          break;
        case Constants.ALGORITHM.QuickSort:
          Quicksort(size, debug, output);
          break;
        case Constants.ALGORITHM.BinarySearch:
          BinarySearch(size, debug, output);
          break;
        case Constants.ALGORITHM.HanoiTower:
          HanoiTower(size, debug, output);
          break;
      }
    }
  }
}
