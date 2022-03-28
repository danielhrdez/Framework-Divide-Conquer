/// Universidad de La Laguna
/// Grado en Ingeniería Informática
/// Diseño y Análisis de Algoritmos
/// <author name="Daniel Hernandez de Leon"></author>
/// <class name="Generator"> Programa para los generadores de instancias de Divide y Vencerás </class>

using DivideConquer.Types;
using RandomGenerators;
using System;

namespace Program {
  class Generator {
    /// <summary>
    ///   Generate random arrays.
    /// </summary>
    /// <param name="maxSize">The size of the arrays.</param>
    /// <param name="maxValue">The random generator.</param>
    /// <returns>The random arrays.</returns>
    public int[][] GenerateArrays(int minSize, int maxSize, int maxValue) {
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
    public Search<int>[] GenerateSearchArrays(int minSize, int maxSize) {
      Search<int>[] arrays = new Search<int>[maxSize];
      int[] intArray;
      for (int size = minSize, i = 0; i < maxSize; size *= 2, i++) {
        intArray = new int[size];
        for (int j = 0; j < size; j++) {
          intArray[j] = j;
        }
        int randomPosition = new Random().Next(size);
        arrays[i] = new Search<int>(intArray, intArray[randomPosition]);
      }
      return arrays;
    }

    /// <summary>
    ///   Generate Tower arrays.
    /// </summary>
    /// <param name="size">The size of the arrays.</param>
    /// <returns>The Tower arrays.</returns>
    public Tower[] GenerateTowerArrays(int minSize, int maxSize) {
      Tower[] towers = new Tower[maxSize];
      for (int size = minSize, i = 0; i < maxSize; size *= 2, i++) {
        towers[i] = new Tower(size);
      }
      return towers;
    }
  }
}
