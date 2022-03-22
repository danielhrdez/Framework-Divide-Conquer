/**
 * Universidad de La Laguna
 * Grado en Ingeniería Informática
 * Diseño y Análisis de Algoritmos
 * @author Daniel Hernandez de Leon
 * @class BinarySearch
 * @brief Implementación de la búsqueda binaria
 */

namespace DivideConquer.Algorithms {
  class BinarySearch : Template<Search, int[]> {
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
    public override bool Small(Search problem) {
      return problem.First == problem.End;
    }

    /// <summary>
    /// Solves a problem.
    /// </summary>
    /// <param name="problem">The problem to solve.</param>
    /// <returns>The solution to the problem.</returns>
    public override int[] SolveSmall(Search problem) {
      if (problem.Array[0] == problem.Search) {
        return new int[1] {problem.First};
      }
      return new int[1] {-1};
    }

    /// <summary>
    /// Divide the problem into n subproblems of size m.
    /// </summary>
    /// <param name="problem">The problem to divide.</param>
    /// <returns>The subproblems.</returns>
    public override Search[] Divide(Search problem) {
      int middle = problem.Length >> 1;
      return new Search[2] {
        new Search(problem.Array, problem.Search, problem.First, middle),
        new Search(problem.Array, problem.Search, middle, problem.Last)
      };
    }

    /// <summary>
    /// Combine the solutions.
    /// </summary>
    /// <param name="solutions">The solutions to combine.</param>
    /// <returns>The combined solution.</returns>
    public override int[] Combine(int[][] solutions) {
      List<int> combined = new List<int>();
      for (int i = 0; i < solutions.Length; i++) {
        if (solutions[i][0] != -1) {
          combined.Add(solutions[i][0]);
        }
      }
      return combined.ToArray();
    }
  }
}