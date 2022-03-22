/**
 * Universidad de La Laguna
 * Grado en Ingeniería Informática
 * Diseño y Análisis de Algoritmos
 * @author Daniel Hernandez de Leon
 * @class BinarySearch
 * @brief Implementación de la búsqueda binaria
 */

using System;
using System.Collections.Generic;

namespace DivideConquer.Algorithms {
  class BinarySearch<Type> : Template<Type[], bool> where Type : IComparable {
    private Type _search;

    /// <summary>
    /// Constructor of BinarySearch.
    /// </summary>
    public BinarySearch(Type search) {
      this._subproblems = "2";
      this._sizeSubproblems = "2";
      this._additionalComplexity = "n";
      this._search = search;
    }

    /// <summary>
    /// Determines if a problem is solvable.
    /// </summary>
    /// <param name="array">The problem to solve.</param>
    /// <returns>True if the problem is solvable, false otherwise.</returns>
    public override bool Small(Type[] array) {
      return array.Length < 2;
    }

    /// <summary>
    /// Solves a problem.
    /// </summary>
    /// <param name="array">The problem to solve.</param>
    /// <returns>The solution to the problem.</returns>
    public override bool SolveSmall(Type[] array) {
      return array[0].CompareTo(this._search) == 0;
    }

    /// <summary>
    /// Divide the problem into n subproblems of size m.
    /// </summary>
    /// <param name="array">The problem to divide.</param>
    /// <returns>The subproblems.</returns>
    public override Type[][] Divide(Type[] array) {
      int middle = array.Length >> 1;
      List<Type> left = new List<Type>();
      List<Type> right = new List<Type>();
      for (int i = 0; i < middle; i++) left.Add(array[i]);
      for (int i = middle; i < array.Length; i++) right.Add(array[i]);
      return new Type[2][] { left.ToArray(), right.ToArray() };
    }

    /// <summary>
    /// Combine the solutions.
    /// </summary>
    /// <param name="solutions">The solutions to combine.</param>
    /// <returns>The combined solution.</returns>
    public override bool Combine(bool[] solutions) {
      for (int i = 0; i < solutions.Length; i++) {
        if (solutions[i]) return true;
      }
      return false;
    }
  }
}