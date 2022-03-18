using static DivideConquerTemplate;

namespace DivideConquer {
  class DivideConquer<Problem, Solution> {
    private DivideConquerTemplate<Problem, Solution> divideAlgorithm; 
    DivideConquer(DivideConquerTemplate<Problem, Solution> divideAlgorithm) {
      this.divideAlgorithm = divideAlgorithm;
    }
    /// <summary>
    ///   Solve a feneric divide-and-conquer problem recursively.
    /// </summary>
    /// <param name="problem">The problem to solve.</param>
    /// <returns>The solution to the problem.</returns>
    public Solution solve(Problem problem) {
      if (divideAlgorithm.small(problem)) {
        return divideAlgorithm.solveSmall(problem);
      }
      Problem[] subproblems = divideAlgorithm.divide(problem);
      Solution[] solutions;
      for (int i = 0; i < subproblems.Length; i++) {
        solutions[i] = solve(subproblems[i], problem.Length / subproblems.Length);
      }
      return divideAlgorithm.combine(solutions);
    }
  }
}
