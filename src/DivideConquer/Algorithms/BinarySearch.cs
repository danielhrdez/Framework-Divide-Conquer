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
  class BinarySearch<S, T> : Template<S, int[]>
      where S : Search<T>
      where T : IComparable {
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
    public override bool Small(S problem) {
      return problem.List.Length < 2;
    }

    /// <summary>
    /// Solves a problem.
    /// </summary>
    /// <param name="problem">The problem to solve.</param>
    /// <returns>The solution to the problem.</returns>
    public override int[] SolveSmall(S problem) {
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
    public override S[] Divide(S problem) {
      int middle = problem.List.Length >> 1;
      List<T> left = new List<T>();
      List<T> right = new List<T>();
      for (int i = 0; i < middle; i++) {
        left.Add(problem.List[i]);
      }
      for (int i = middle; i < problem.List.Length; i++) {
        right.Add(problem.List[i]);
      }
      S[] subproblems = new S[2];
      subproblems[0] = Activator.CreateInstance(
        typeof(S),
        new object[] {
          left,
          problem.Item,
          problem.Index
        }
      ) as S;
      subproblems[1] = Activator.CreateInstance(
        typeof(S),
        new object[] {
          right,
          problem.Item,
          problem.Index + middle
        }
      ) as S;
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
