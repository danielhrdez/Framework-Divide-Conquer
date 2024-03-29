/// Universidad de La Laguna
/// Grado en Ingeniería Informática
/// Diseño y Análisis de Algoritmos
/// <author name="Daniel Hernandez de Leon"></author>
/// <class name="DivideConquer"> Implementación de algoritmos de divide y vencerás genéricos </class>

namespace DivideConquer {
  class SolverThreading<Problem, Solution> {
    private Template<Problem, Solution> _algorithm;

    /// <summary>
    ///   Constructor.
    /// </summary>
    /// <param name="algorithm">The algorithm to solve.</param>
    public SolverThreading(Template<Problem, Solution> algorithm) {
      this._algorithm = algorithm;
    }

    /// <summary>
    ///   Solve a feneric divide-and-conquer problem recursively.
    /// </summary>
    /// <param name="problem">The problem to solve.</param>
    /// <param name="size">The size of the problem.</param>
    /// <returns>The solution to the problem.</returns>
    public Solution Solve(Problem problem) {
      if (this._algorithm.Small(problem)) {
        return this._algorithm.SolveSmall(problem);
      }
      WaitHandle[] handles = new WaitHandle[2];
      Problem[] subproblems = this._algorithm.Divide(problem);
      Solution[] solutions = new Solution[subproblems.Length];
      Task<Solution>[] tasks = new Task<Solution>[subproblems.Length];
      for (int i = 0; i < subproblems.Length; i++) {
        Problem subproblem = subproblems[i];
        tasks[i] = new Task<Solution>(() => Solve(subproblem));
        tasks[i].Start();
      }
      for (int i = 0; i < tasks.Length; i++) {
        solutions[i] = tasks[i].Result;
      }
      return this._algorithm.Combine(solutions);
    }

    /// <summary>
    ///   Returns the name of the algorithm used by this solver.
    /// </summary>
    /// <returns>The name of the algorithm used by this solver.</returns>

    public string AlgorithmName() {
      string name = this._algorithm
          .GetType()
          .Name
          .Substring(0, this._algorithm.GetType().Name.Length - 2);
      return name + "<" + typeof(Problem).Name + ", " + typeof(Solution).Name + ">";
    }

    public string TimeComplexity() {
      return string.Format(
          "T(n) = {0} * T({1}) + O({2})",
          this._algorithm.Subproblems(),
          this._algorithm.SizeSubproblems(),
          this._algorithm.AdditionalComplexity()
      );
    }
  }
}
