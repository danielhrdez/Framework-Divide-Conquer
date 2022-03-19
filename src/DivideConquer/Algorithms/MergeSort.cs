using System;
using System.Collections.Generic;

namespace DivideConquer.Algorithms {
  class MergeSort<Type> : Template<Type[], Type[]> where Type : IComparable {
    /// <summary>
    /// Determines if an array is solvable when the array is length 2.
    /// </summary>
    /// <param name="problem">The array to solve.</param>
    /// <returns>True if the array is solvable, false otherwise.</returns>
    public override bool Small(Type[] problem) {
      return problem.Length < 3;
    }

    /// <summary>
    /// Solves an array when the array is length 1.
    /// </summary>
    /// <param name="problem">The array to solve.</param>
    /// <returns>Left first if left is less, otherwise right.</returns>
    public override Type[] SolveSmall(Type[] problem) {
      if (problem.Length == 1) return problem;
      if (problem[0].CompareTo(problem[1]) <= 0) {
        return new Type[2] { problem[0], problem[1] };
      }
      return new Type[2] { problem[1], problem[0] };
    }

    /// <summary>
    /// Divide the array into 2 subarrays of size n / 2.
    /// </summary>
    /// <param name="problem">The array to divide.</param>
    /// <returns>The 2 subarrays.</returns>
    public override Type[][] Divide(Type[] problem) {
      int mid = problem.Length >> 1;
      List<Type> left = new List<Type>();
      List<Type> right = new List<Type>();
      for (int i = 0; i < mid; i++) {
        left.Add(problem[i]);
      }
      for (int i = mid; i < problem.Length; i++) {
        right.Add(problem[i]);
      }
      return new Type[2][] { left.ToArray(), right.ToArray() };
    }

    /// <summary>
    /// Combine the arrays.
    /// </summary>
    /// <param name="solutions">The arrays to combine.</param>
    /// <returns>The combined array.</returns>
    public override Type[] Combine(Type[][] solutions) {
      int leftIndex = 0;
      int rightIndex = 0;
      List<Type> combined = new List<Type>();
      while (leftIndex < solutions[0].Length && rightIndex < solutions[1].Length) {
        if (solutions[0][leftIndex].CompareTo(solutions[1][rightIndex]) <= 0) {
          combined.Add(solutions[0][leftIndex]);
          leftIndex++;
        } else {
          combined.Add(solutions[1][rightIndex]);
          rightIndex++;
        }
      }
      if (leftIndex < solutions[0].Length) {
        for (int i = leftIndex; i < solutions[0].Length; i++) {
          combined.Add(solutions[0][i]);
        }
      } else {
        for (int i = rightIndex; i < solutions[1].Length; i++) {
          combined.Add(solutions[1][i]);
        }
      }
      return combined.ToArray();
    }

    /// <summary>
    /// Return the number of subproblems each time is divided.
    /// </summary>
    /// <returns>The number of subproblems each time is divided.</returns>
    public override string Subproblems() {
      return "2";
    }

    /// <summary>
    /// Return the size of each subproblem.
    /// </summary>
    /// <returns>The size of each subproblem.</returns>
    public override string SizeSubproblems() {
      return "n / 2";
    }

    /// <summary>
    /// Return the complexity of the divide and combine step.
    /// </summary>
    /// <returns>The complexity of the divide and combine step.</returns>
    public override string AdditionalComplexity() {
      return "O(n)";
    }
  }
}
