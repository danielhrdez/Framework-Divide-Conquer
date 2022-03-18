using DivideConquerTemplate = DivideConquer.DivideConquerTemplate;

namespace DivideConquer.Algorithms {
  class MergeSort<Array> : DivideConquerTemplate<Array, Array> {
    /// <summary>
    /// Determines if an array is solvable when the array is length 1.
    /// </summary>
    /// <param name="problem">The array to solve.</param>
    /// <returns>True if the array is solvable, false otherwise.</returns>
    public bool Small(Array problem) {
      return problem.Length <= 1;
    }

    /// <summary>
    /// Solves an array when the array is length 1.
    /// </summary>
    /// <param name="problem">The array to solve.</param>
    /// <returns>Left first if left is less, otherwise right.</returns>
    public Array SolveSmall(Array problem) {
      if (problem[0] <= problem [1]) {
        return new Array(problem[0], problem[1]);
      }
      return new Array(problem[1], problem[0]);
    }

    /// <summary>
    /// Divide the array into 2 subarrays of size n / 2.
    /// </summary>
    /// <param name="problem">The array to divide.</param>
    /// <returns>The 2 subarrays.</returns>
    public Array[] Divide(Array problem) {
      const int mid = problem.Length >> 1;
      const Array left = new Array(problem.Take(mid));
      const Array right = new Array(problem.Skip(mid));
      return new Array[] { left, right };
    }

    /// <summary>
    /// Combine the arrays.
    /// </summary>
    /// <param name="solutions">The arrays to combine.</param>
    /// <returns>The combined array.</returns>
    public async Array Combine(Array[] solutions) {
      Array combined = new Array();
      for (int i = 0; i < solutions[0].Length - 1; i++) {
        if (solutions[0][i] <= solutions[1][i]) {
          combined.Add(solutions[0][i]);
        } else {
          combined.Add(solutions[1][i]);
        }
      }
      return combined;
    }
  }
}
