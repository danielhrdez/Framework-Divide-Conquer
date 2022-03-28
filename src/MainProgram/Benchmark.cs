/// Universidad de La Laguna
/// Grado en Ingeniería Informática
/// Diseño y Análisis de Algoritmos
/// <author name="Daniel Hernandez de Leon"></author>
/// <class name="Benchmark"> Programa para los benchmarks de Divide y Vencerás </class>

namespace MainProgram {
  class Benchmark {
    /// <summary>
    ///   Benchamrk the algorithms.
    /// </summary>
    /// <param name="algorithm">The algorithms to benchmark.</param>
    /// <param name="arrays">The arrays to benchmark.</param>
    /// <returns> The results of the benchmark.</returns>
    public object[][] BenchSort(Sorter algorithm, int[][] arrays, bool debug) {
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
    public object[][] BenchSearch(Searcher algorithm, SearchInt[] arrays, bool debug) {
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
    public object[][] BenchTower(TowerSolver algorithm, Tower[] arrays, bool debug) {
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
  }
}
