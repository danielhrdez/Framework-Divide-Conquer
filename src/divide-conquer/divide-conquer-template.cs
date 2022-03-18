abstract class DivideConquerTemplate<Problem, Solution> {
  /// <summary>
  /// Determines if a problem is solvable.
  /// </summary>
  /// <param name="problem">The problem to solve.</param>
  /// <returns>True if the problem is solvable, false otherwise.</returns>
  public bool small(Problem problem);

  /// <summary>
  /// Solves a problem.
  /// </summary>
  /// <param name="problem">The problem to solve.</param>
  /// <returns>The solution to the problem.</returns>
  public Solution solveSmall(Problem problem);

  /// <summary>
  /// Divide the problem into n subproblems of size m.
  /// </summary>
  /// <param name="problem">The problem to divide.</param>
  /// <returns>The subproblems.</returns>
  public Problem[] divide(Problem problem);

  /// <summary>
  /// Combine the solutions.
  /// </summary>
  /// <param name="solutions">The solutions to combine.</param>
  /// <returns>The combined solution.</returns>
  public Solution combine(Solution[] solutions);
}
