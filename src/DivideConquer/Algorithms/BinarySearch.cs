namespace DivideConquer.Algorithms {
  class BinarySearch<Type> : Template<Type[], int> {
    private Type _search;

    /// <summary>
    /// Constructor of BinarySearch.
    /// </summary>
    /// <param name="search">The value to search for.</param>
    public BinarySearch(Type search) {
      this._subproblems = "2";
      this._sizeSubproblems = "2";
      this._additionalComplexity = "n";
      this._search = search;
    }

    /// <summary>
    /// Determines if a problem is solvable.
    /// </summary>
    /// <param name="problem">The problem to solve.</param>
    /// <returns>True if the problem is solvable, false otherwise.</returns>
    public override bool Small(Type[] array) {
      return array.Length < 2;
    }

    /// <summary>
    /// Solves a problem.
    /// </summary>
    /// <param name="array">The problem to solve.</param>
    /// <returns>The solution to the problem.</returns>
    public override int SolveSmall(Type array) {
      return array[0] == this._search;
    }

    /// <summary>
    /// Divide the problem into n subproblems of size m.
    /// </summary>
    /// <param name="problem">The problem to divide.</param>
    /// <returns>The subproblems.</returns>
    public override Type[][] Divide(Type[] array) {
      int middle = array.Length >> 1;
      Hashtable left = new List<object>();
      Hashtable right = new List<object>();
      List<object> middleList = new List<object>();
      for (int i = 0; i < middle; i++) {
        left.Add(array[i]);
      }
      for (int i = middle; i < array.Length; i++) right.Add(array[i]);
      return new Type[2][] { left.ToArray(), right.ToArray() };
    }

    /// <summary>
    /// Combine the solutions.
    /// </summary>
    /// <param name="solutions">The solutions to combine.</param>
    /// <returns>The combined solution.</returns>
    public override int Combine(int[] solutions) {

    }
  }
}