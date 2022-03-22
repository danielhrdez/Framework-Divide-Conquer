/**
 * Universidad de La Laguna
 * Grado en Ingeniería Informática
 * Diseño y Análisis de Algoritmos
 * @author Daniel Hernandez de Leon
 * @class MergeSort
 * @brief Implementación de la ordenación por mezcla
 */

using System;
using System.Collections.Generic;

namespace DivideConquer.Algorithms {
  class MergeSort<Type> : Template<Type[], Type[]> where Type : IComparable {
    /// <summary>
    /// Constructor of MergeSort.
    /// </summary>
    public MergeSort() {
      this._subproblems = "2";
      this._sizeSubproblems = "2";
      this._additionalComplexity = "n";
    }

    /// <summary>
    /// Determines if an array is solvable when the array is length 2.
    /// </summary>
    /// <param name="array">The array to solve.</param>
    /// <returns>True if the array is solvable, false otherwise.</returns>
    public override bool Small(Type[] array) {
      return array.Length < 3;
    }

    /// <summary>
    /// Solves an array when the array is length 1.
    /// </summary>
    /// <param name="array">The array to solve.</param>
    /// <returns>Left first if left is less, otherwise right.</returns>
    public override Type[] SolveSmall(Type[] array) {
      if (array.Length == 1) return array;
      if (array[0].CompareTo(array[1]) <= 0) {
        return new Type[2] { array[0], array[1] };
      }
      return new Type[2] { array[1], array[0] };
    }

    /// <summary>
    /// Divide the array into 2 subarrays of size n / 2.
    /// </summary>
    /// <param name="array">The array to divide.</param>
    /// <returns>The 2 subarrays.</returns>
    public override Type[][] Divide(Type[] array) {
      int mid = array.Length >> 1;
      List<Type> left = new List<Type>();
      List<Type> right = new List<Type>();
      for (int i = 0; i < mid; i++) left.Add(array[i]);
      for (int i = mid; i < array.Length; i++) right.Add(array[i]);
      return new Type[2][] { left.ToArray(), right.ToArray() };
    }

    /// <summary>
    /// Combine the arrays.
    /// </summary>
    /// <param name="arrays">The arrays to combine.</param>
    /// <returns>The combined array.</returns>
    public override Type[] Combine(Type[][] arrays) {
      int leftIndex = 0;
      int rightIndex = 0;
      List<Type> combined = new List<Type>();
      while (leftIndex < arrays[0].Length && rightIndex < arrays[1].Length) {
        if (arrays[0][leftIndex].CompareTo(arrays[1][rightIndex]) <= 0) {
          combined.Add(arrays[0][leftIndex]);
          leftIndex++;
        } else {
          combined.Add(arrays[1][rightIndex]);
          rightIndex++;
        }
      }
      if (leftIndex < arrays[0].Length) {
        for (int i = leftIndex; i < arrays[0].Length; i++) {
          combined.Add(arrays[0][i]);
        }
      } else {
        for (int i = rightIndex; i < arrays[1].Length; i++) {
          combined.Add(arrays[1][i]);
        }
      }
      return combined.ToArray();
    }
  }
}
