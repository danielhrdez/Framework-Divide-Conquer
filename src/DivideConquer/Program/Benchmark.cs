/// Universidad de La Laguna
/// Grado en Ingeniería Informática
/// Diseño y Análisis de Algoritmos
/// <author name="Daniel Hernandez de Leon"></author>
/// <class name="Benchmark"> Programa para los benchmarks de Divide y Vencerás </class>

using IO;
using DivideConquer.Algorithms;
using DivideConquer.Types;
using DivideConquer;
using System.Diagnostics;

namespace Program {
  class Benchmark {
    /// <summary>
    ///   Benchamrk the algorithms.
    /// </summary>
    /// <param name="algorithm">The algorithms to benchmark.</param>
    /// <param name="arrays">The arrays to benchmark.</param>
    /// <returns> The results of the benchmark.</returns>
    public object[][] BenchSort(Constants.ALGORITHM typeAlgorithm, int[][] arrays, bool debug) {
      int[] result;
      object[][] timeResults = new object[arrays.Length][];
      Solver<int[], int[]> algorithm = new Solver<int[], int[]>(new MergeSort<int>());
      switch (typeAlgorithm) {
        case Constants.ALGORITHM.QuickSort:
          algorithm = new Solver<int[], int[]>(new QuickSort<int>());
          break;
      }
      Stopwatch sw = new Stopwatch();
      for (int i = 0; i < arrays.Length; i++) {
        sw.Reset();
        sw.Start();
        result = algorithm.Solve(arrays[i]);
        sw.Stop();
        if (debug) {
          Printer printer = new Printer();
          printer.PrintSort(arrays[0], result);
        }
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
    public object[][] BenchSearch(Constants.ALGORITHM typeAlgorithm, Search<int>[] arrays, bool debug) {
      int result;
      object[][] timeResults = new object[arrays.Length][];
      Solver<Search<int>, int> algorithm = new Solver<Search<int>, int>(new BinarySearch<Search<int>, int>());
      Stopwatch sw = new Stopwatch();
      for (int i = 0; i < arrays.Length; i++) {
        sw.Reset();
        sw.Start();
        result = algorithm.Solve(arrays[i]);
        sw.Stop();
        if (debug) {
          Printer printer = new Printer();
          printer.PrintSearch(arrays[0], result);
        }
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
    public object[][] BenchTower(Constants.ALGORITHM typeAlgorithm, Tower[] arrays, bool debug) {
      object[][] timeResults = new object[arrays.Length][];
      Stopwatch sw = new Stopwatch();
      Solver<Tower, Step[]> algorithm = new Solver<Tower, Step[]>(new HanoiTower());
      for (int i = 0; i < arrays.Length; i++) {
        sw.Reset();
        sw.Start();
        Step[] steps = algorithm.Solve(arrays[i]);
        sw.Stop();
        if (debug) {
          Printer printer = new Printer();
          printer.PrintTower(steps);
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
  }
}
