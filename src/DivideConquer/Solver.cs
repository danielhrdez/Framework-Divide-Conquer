/// Universidad de La Laguna
/// Grado en Ingeniería Informática
/// Diseño y Análisis de Algoritmos
/// <author name="Daniel Hernandez de Leon"></author>
/// <class name="DivideConquer"> Implementación de algoritmos de divide y vencerás genéricos </class>

namespace DivideConquer {
  class Solver<Problem, Solution> {
    private Template<Problem, Solution> _algorithm;
    private int maximumLevel;
    private int numberRecursiveCalls;

    /// <summary>
    ///   Constructor.
    /// </summary>
    /// <param name="algorithm">The algorithm to solve.</param>
    public Solver(Template<Problem, Solution> algorithm) {
      this._algorithm = algorithm;
      this.maximumLevel = 0;
      this.numberRecursiveCalls = 0;
    }

    /// <summary>
    ///   Solve a feneric divide-and-conquer problem recursively.
    /// </summary>
    /// <param name="problem">The problem to solve.</param>
    /// <param name="size">The size of the problem.</param>
    /// <returns>The solution to the problem.</returns>
    public Solution Solve(Problem problem, int level = 1) {
      if (this._algorithm.Small(problem)) {
        if (level > this.maximumLevel) this.maximumLevel = level;
        return this._algorithm.SolveSmall(problem);
      }
      Problem[] subproblems = this._algorithm.Divide(problem);
      Solution[] solutions = new Solution[subproblems.Length];
      for (int i = 0; i < subproblems.Length; i++) {
        numberRecursiveCalls++;
        solutions[i] = Solve(subproblems[i], level + 1);
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

    public int MaximumLevel() {
      return this.maximumLevel;
    }

    public int NumberRecursiveCalls() {
      return this.numberRecursiveCalls;
    }
  }
}
