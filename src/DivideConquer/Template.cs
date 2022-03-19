namespace DivideConquer {
  abstract class Template<Problem, Solution> {
    /// <summary>
    /// Determines if a problem is solvable.
    /// </summary>
    /// <param name="problem">The problem to solve.</param>
    /// <returns>True if the problem is solvable, false otherwise.</returns>
    public abstract bool Small(Problem problem);

    /// <summary>
    /// Solves a problem.
    /// </summary>
    /// <param name="problem">The problem to solve.</param>
    /// <returns>The solution to the problem.</returns>
    public abstract Solution SolveSmall(Problem problem);

    /// <summary>
    /// Divide the problem into n subproblems of size m.
    /// </summary>
    /// <param name="problem">The problem to divide.</param>
    /// <returns>The subproblems.</returns>
    public abstract Problem[] Divide(Problem problem);

    /// <summary>
    /// Combine the solutions.
    /// </summary>
    /// <param name="solutions">The solutions to combine.</param>
    /// <returns>The combined solution.</returns>
    public abstract Solution Combine(Solution[] solutions);

    /// <summary>
    /// Return The number of subproblems each time is divided.
    /// </summary>
    /// <returns>The number of subproblems each time is divided.</returns>
    public abstract string Subproblems();

    /// <summary>
    /// Return the size of each subproblem.
    /// </summary>
    /// <returns>The size of each subproblem.</returns>
    public abstract string SizeSubproblems();

    /// <summary>
    /// Return the complexity of the divide and combine step.
    /// </summary>
    /// <returns>The complexity of the divide and combine step.</returns>
    public abstract string AdditionalComplexity();
  }
}
