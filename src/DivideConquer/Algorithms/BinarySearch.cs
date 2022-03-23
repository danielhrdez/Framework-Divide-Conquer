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
using DivideConquer.Types;

namespace DivideConquer.Algorithms {
  class BinarySearch<Type> : Template<Type, int[]> where Type : Problem {
    /// <summary>
    /// Constructor of BinarySearch.
    /// </summary>
    public BinarySearch() {
      this._subproblems = "2";
      this._sizeSubproblems = "2";
      this._additionalComplexity = "n";
    }

    /// <summary>
    /// Determines if a problem is solvable.
    /// </summary>
    /// <param name="problem">The problem to solve.</param>
    /// <returns>True if the problem is solvable, false otherwise.</returns>
    public override bool Small(Type problem) {
      return problem.List.Length < 2;
    }

    /// <summary>
    /// Solves a problem.
    /// </summary>
    /// <param name="problem">The problem to solve.</param>
    /// <returns>The solution to the problem.</returns>
    public override int[] SolveSmall(Type problem) {
      if (problem.List[0].CompareTo(problem.Item) == 0) {
        return new int[1] { problem.Index };
      }
      return new int[1] { -1 };
    }

    /// <summary>
    /// Divide the problem into n subproblems of size m.
    /// </summary>
    /// <param name="problem">The problem to divide.</param>
    /// <returns>The subproblems.</returns>
    public override Type[] Divide(Type problem) {
      int middle = problem.List.Length >> 1;
      Type[] subproblems = new Type[2];
      subproblems[0] = new Problem(
        problem.List.GetRange(0, middle),
        problem.Item,
        problem.Index
      );
      subproblems[1] = new Type(
        problem.List.GetRange(middle, problem.List.Length - middle),
        problem.Item,
        problem.Index + middle
      );
      return subproblems;
    }

    /// <summary>
    /// Combine the solutions.
    /// </summary>
    /// <param name="solutions">The solutions to combine.</param>
    /// <returns>The combined solution.</returns>
    public override int[] Combine(int[][] solutions) {
      List<int> result = new List<int>();
      foreach (int[] solution in solutions) {
        foreach (int element in solution) {
          if (element != -1) {
            result.Add(element);
          }
        }
      }
      return result.ToArray();
    }
  }
}
