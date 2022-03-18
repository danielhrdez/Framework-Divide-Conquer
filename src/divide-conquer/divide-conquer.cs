using DivideConquerTemplate;

class DivideConquer<DivideConquerTemplate, Problem, Solution> {
  /// <summary>
  ///   Solve a feneric divide-and-conquer problem recursively.
  /// </summary>
  /// <param name="problem">The problem to solve.</param>
  /// <returns>The solution to the problem.</returns>
  public Solution solve(Problem problem) {
    if (DivideConquerTemplate.small(problem)) {
      return DivideConquerTemplate.solveSmall(problem);
    }
    Problem[] subproblems = DivideConquerTemplate.divide(problem);
    Solution[] solutions;
    for (int i = 0; i < subproblems.Length; i++) {
      solutions[i] = solve(subproblems[i], problem.Length / subproblems.Length);
    }
    return DivideConquerTemplate.combine(solutions);
  }
}
