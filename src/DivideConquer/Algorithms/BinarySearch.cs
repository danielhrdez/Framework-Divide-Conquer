/// Universidad de La Laguna
/// Grado en Ingeniería Informática
/// Diseño y Análisis de Algoritmos
/// <author name="Daniel Hernandez de Leon"></author>
/// <class name="BinarySearch"> Implementación de la búsqueda binaria </class>

using DivideConquer.Types;

namespace DivideConquer.Algorithms {
  class BinarySearch<S, T> : Template<S, int>
      where S : Search<T>
      where T : IComparable {
    /// <summary>
    /// Constructor of BinarySearch.
    /// </summary>
    public BinarySearch() {
      this._subproblems = "1";
      this._sizeSubproblems = "n / 2";
      this._additionalComplexity = "1";
    }

    /// <summary>
    /// Determines if a problem is solvable.
    /// </summary>
    /// <param name="problem">The problem to solve.</param>
    /// <returns>True if the problem is solvable, false otherwise.</returns>
    public override bool Small(S problem) {
      return problem.List.Length == 1;
    }

    /// <summary>
    /// Solves a problem.
    /// </summary>
    /// <param name="problem">The problem to solve.</param>
    /// <returns>The solution to the problem.</returns>
    public override int SolveSmall(S problem) {
      if (problem.List[0].CompareTo(problem.Target) == 0) {
        return problem.Index;
      }
      return -1;
    }

    /// <summary>
    /// Divide the problem into n subproblems of size m.
    /// </summary>
    /// <param name="problem">The problem to divide.</param>
    /// <returns>The subproblems.</returns>
    public override S[] Divide(S problem) {
      int middle = problem.List.Length >> 1;
      if (problem.List[middle].CompareTo(problem.Target) == 0) {
        T[] middleList = new T[1] { problem.List[middle] };
        return new S[1] {
          Activator.CreateInstance(
            typeof(S),
            new object[] {
              middleList,
              problem.Target,
              problem.Index + middle
            }
          ) as S
        };
      }
      if (problem.List[middle].CompareTo(problem.Target) > 0) {
        List<T> left = new List<T>();
        for (int i = 0; i < middle; i++)
          left.Add(problem.List[i]);
        return new S[1] {
          Activator.CreateInstance(
            typeof(S),
            new object[] {
              left.ToArray(),
              problem.Target,
              problem.Index
            }
          ) as S
        };
      }
      List<T> right = new List<T>();
      for (int i = middle + 1; i < problem.List.Length; i++)
        right.Add(problem.List[i]);
      return new S[1] {
        Activator.CreateInstance(
          typeof(S),
          new object[] {
            right.ToArray(),
            problem.Target,
            problem.Index + middle + 1
          }
        ) as S
      };
    }

    /// <summary>
    /// Combine the solutions.
    /// </summary>
    /// <param name="solutions">The solutions to combine.</param>
    /// <returns>The combined solution.</returns>
    public override int Combine(int[] solutions) {
      return solutions[0];
    }
  }
}
