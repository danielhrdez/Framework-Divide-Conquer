namespace DivideConquer {
  class Solver<Problem, Solution> {
    private Template<Problem, Solution> algorithm;
    public Solver(Template<Problem, Solution> algorithm) {
      this.algorithm = algorithm;
    }

    /// <summary>
    ///   Solve a feneric divide-and-conquer problem recursively.
    /// </summary>
    /// <param name="problem">The problem to solve.</param>
    /// <param name="size">The size of the problem.</param>
    /// <returns>The solution to the problem.</returns>
    public Solution Solve(Problem problem, int size) {
      if (this.algorithm.Small(problem)) {
        return this.algorithm.SolveSmall(problem);
      }
      Problem[] subproblems = this.algorithm.Divide(problem);
      Solution[] solutions = new Solution[subproblems.Length];
      for (int i = 0; i < subproblems.Length; i++) {
        solutions[i] = Solve(
            subproblems[i],
            size / subproblems.Length
        );
      }
      return this.algorithm.Combine(solutions);
    }
  }
}
