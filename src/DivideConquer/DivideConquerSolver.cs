using DivideConquerTemplate = DivideConquer.DivideConquerTemplate;

namespace DivideConquer {
  class DivideConquerSolver<Problem, Solution> {
    private DivideConquerTemplate<Problem, Solution> divideAlgorithm; 

    /// <summary>
    ///   Constructor.
    /// </summary>
    /// <param name="divideAlgorithm">The divide algorithm.</param>
    DivideConquerSolver(DivideConquerTemplate<Problem, Solution> divideAlgorithm) {
      this.divideAlgorithm = divideAlgorithm;
    }
    /// <summary>
    ///   Solve a feneric divide-and-conquer problem recursively.
    /// </summary>
    /// <param name="problem">The problem to solve.</param>
    /// <returns>The solution to the problem.</returns>
    public Solution Solve(Problem problem) {
      if (divideAlgorithm.Small(problem)) {
        return divideAlgorithm.SolveSmall(problem);
      }
      const Problem[] subproblems = divideAlgorithm.Divide(problem);
      Solution[] solutions;
      for (int i = 0; i < subproblems.Length; i++) {
        solutions[i] = Solve(subproblems[i], problem.Length / subproblems.Length);
      }
      return divideAlgorithm.Combine(solutions);
    }
  }
}
