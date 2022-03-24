/**
 * Universidad de La Laguna
 * Grado en Ingeniería Informática
 * Diseño y Análisis de Algoritmos
 * @author Daniel Hernandez de Leon
 * @class Template
 * @brief Clase abstracta para algoritmos de divide y vencerás
 */
 
namespace DivideConquer {
  abstract class Template<Problem, Solution> {
    protected string _subproblems;
    protected string _sizeSubproblems;
    protected string _additionalComplexity;

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
    /// Return the number of subproblems each time is divided.
    /// </summary>
    /// <returns>The number of subproblems each time is divided.</returns>
    public string Subproblems() {
      return this._subproblems;
    }

    /// <summary>
    /// Return the size of each subproblem.
    /// </summary>
    /// <returns>The size of each subproblem.</returns>
    public string SizeSubproblems() {
      return this._sizeSubproblems;
    }

    /// <summary>
    /// Return the complexity of the divide and combine step.
    /// </summary>
    /// <returns>The complexity of the divide and combine step.</returns>
    public string AdditionalComplexity() {
      return this._additionalComplexity;
    }
  }
}
