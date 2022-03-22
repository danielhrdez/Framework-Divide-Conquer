
namespace DivideConquer.Algorithms {
  class BinarySearch<Type> : Template<Type[], int> {
    private Type _search;
    public BinarySearch(Type search) {
      this._subproblems = "";
      this._sizeSubproblems = "";
      this._additionalComplexity = "";
      this._search = search;
    }

    /// <summary>
    /// Determines if a problem is solvable.
    /// </summary>
    /// <param name="problem">The problem to solve.</param>
    /// <returns>True if the problem is solvable, false otherwise.</returns>
    public override bool Small(Type[] array) {
      return array.Length < 1;
    }

    /// <summary>
    /// Solves a problem.
    /// </summary>
    /// <param name="problem">The problem to solve.</param>
    /// <returns>The solution to the problem.</returns>
    public override int SolveSmall(Type problem) {
      return -1;
    }

    /// <summary>
    /// Divide the problem into n subproblems of size m.
    /// </summary>
    /// <param name="problem">The problem to divide.</param>
    /// <returns>The subproblems.</returns>
    public override Type[][] Divide(Type[] array) {
      int middle = array.Length >> 1;
      if (array[middle] == this._search) return middle;
      List<Type> left = new List<Type>();
      List<Type> right = new List<Type>();
      for (int i = 0; i < mid; i++) left.Add(array[i]);
      for (int i = mid + 1; i < array.Length; i++) right.Add(array[i]);
      return new Type[2][] { left.ToArray(), right.ToArray() };
    }

    /// <summary>
    /// Combine the solutions.
    /// </summary>
    /// <param name="solutions">The solutions to combine.</param>
    /// <returns>The combined solution.</returns>
    public override int Combine(int[] solutions);
  }
}