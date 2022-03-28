/// Universidad de La Laguna
/// Grado en Ingeniería Informática
/// Diseño y Análisis de Algoritmos
/// <author name="Daniel Hernandez de Leon"></author>
/// <class name="DivideConquerMain"> Programa principal para el ejercicio de Divide y Vencerás </class>

// using Sorter = DivideConquer.Solver<int[], int[]>;
// using Searcher = DivideConquer.Solver<DivideConquer.Types.Search<int>, int>;
// using MergeSort = DivideConquer.Algorithms.MergeSort<int>;
// using QuickSort = DivideConquer.Algorithms.QuickSort<int>;
// using SearchInt = DivideConquer.Types.Search<int>;
// using Tower = DivideConquer.Types.Tower;
// using Step = DivideConquer.Types.Step;
// using BinarySearch = DivideConquer.Algorithms.BinarySearch<DivideConquer.Types.Search<int>, int>;
// using HanoiTower = DivideConquer.Algorithms.HanoiTower;
// using TowerSolver = DivideConquer.Solver<DivideConquer.Types.Tower, DivideConquer.Types.Step[]>;
// using RandomGenerators;
// using System;
// using System.Diagnostics;
// using System.IO;
// using System.Linq;
using IO;

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

      // int[][] arrays;
      // SearchInt[] searchArrays;
      // Tower[] towerArrays;
      // Sorter sorter;
      printer.PrintTitle(Constants.TITLE);
      if (args.Contains("-d")) {
        debug = true;
        printer.PrintDebugMode();
      }
      if (args.Contains("-o")) output = true;
      option = printer.PrintMenu();
      if (debug) size = scanner.ChooseSize();
      this.SwitchAlgorithm(option, size, debug, output);
    }

    public void Mergesort(int size, bool debug, bool output) {
      Generator generator = new Generator();
      Benchmark benchmark = new Benchmark();
      Printer printer = new Printer();
      Writer writer = new Writer();

      if (!debug) arrays = generator.GenerateArrays(size, Constants.NUMBER_ARRAYS, Constants.MAX_VALUE, debug);
      else arrays = generator.GenerateArrays(size, 1, Constants.MAX_VALUE, debug);
      object[][] timeResults = benchmark.BenchSort(Constants.ALGORITHM.MergeSort, arrays, debug);
      printer.PrintResults(timeResults);
      if (output) writer.WriteCSV(timeResults, Constants.ALGORITHM.MergeSort.ToString());
    }

    public void Quicksort(int size, bool debug, bool output) {
      Generator generator = new Generator();
      Benchmark benchmark = new Benchmark();
      Printer printer = new Printer();
      Writer writer = new Writer();

      if (!debug) arrays = generator.GenerateArrays(size, NUMBER_ARRAYS, MAX_VALUE);
      else arrays = main.GenerateArrays(size, 1, MAX_VALUE);
      timeResults = benchmark.BenchSort(Constants.ALGORITHM.QuickSort, arrays, debug);
      printer.PrintResults(timeResults);
      if (output) writer.WriteCSV(timeResults, Constants.ALGORITHM.QuickSort.ToString());
    }

    public void BinarySearch(int size, bool debug, bool output) {
      Generator generator = new Generator();
      Benchmark benchmark = new Benchmark();
      Printer printer = new Printer();
      Writer writer = new Writer();

      if (!debug) searchArrays = generator.GenerateSearchArrays(size, NUMBER_SEARCH);
      else searchArrays = generator.GenerateSearchArrays(size, 1);
      timeResults = benchmark.BenchSearch(Constants.ALGORITHM.BinarySearch, searchArrays, debug);
      printer.PrintResults(timeResults);
      if (output) writer.WriteCSV(timeResults, Constants.ALGORITHM.BinarySearch.ToString());
    }

    public void HanoiTower(int size, bool debug, bool output) {
      Generator generator = new Generator();
      Benchmark benchmark = new Benchmark();
      Printer printer = new Printer();
      Writer writer = new Writer();

      if (!debug) towerArrays = generator.GenerateTowerArrays(size, NUMBER_TOWERS);
      else towerArrays = generator.GenerateTowerArrays(size, 1);
      timeResults = benchmark.BenchTower(Constants.ALGORITHM.HanoiTower, towerArrays, debug);
      printer.PrintResults(timeResults);
      if (output) writer.WriteCSV(timeResults, Constants.ALGORITHM.HanoiTower.ToString());
    }

    public void SwitchAlgorithm(Constants.ALGORITHM option, int size, bool debug, bool output) {
      switch (option) {
        case Constants.ALGORITHM.MergeSort:
          this.Mergesort(size, debug, output);
          break;
        case Constants.ALGORITHM.QuickSort:
          this.Quicksort(size, debug, output);
          break;
        case Constants.ALGORITHM.BinarySearch:
          this.BinarySearch(size, debug, output);
          break;
        case Constants.ALGORITHM.HanoiTower:
          this.HanoiTower(size, debug, output);
          break;
      }
    }
  }
}
