using System;

namespace DivideConquer {
  class Solver<Problem, Solution> {
    private Template<Problem, Solution> algorithm;

    /// <summary>
    ///   Constructor.
    /// </summary>
    /// <param name="algorithm">The algorithm to solve.</param>
    public Solver(Template<Problem, Solution> algorithm) {
      this.algorithm = algorithm;
    }

    /// <summary>
    ///   Solve a feneric divide-and-conquer problem recursively.
    /// </summary>
    /// <param name="problem">The problem to solve.</param>
    /// <param name="size">The size of the problem.</param>
    /// <returns>The solution to the problem.</returns>
    public Solution Solve(Problem problem) {
      if (this.algorithm.Small(problem)) {
        return this.algorithm.SolveSmall(problem);
      }
      Problem[] subproblems = this.algorithm.Divide(problem);
      Solution[] solutions = new Solution[subproblems.Length];
      for (int i = 0; i < subproblems.Length; i++) {
        solutions[i] = Solve(subproblems[i]);
      }
      return this.algorithm.Combine(solutions);
    }

    /// <summary>
    ///   Returns the name of the algorithm used by this solver.
    /// </summary>
    /// <returns>The name of the algorithm used by this solver.</returns>

    public string GetAlgorithmName() {
      string name = this.algorithm
          .GetType()
          .Name
          .Substring(0, this.algorithm.GetType().Name.Length - 2);
      string type = this.algorithm.GetType().GetGenericArguments()[0].Name;
      return name + "<" + type + ">";
    }
  }
}
