using System;
using System.Collections.Generic;

namespace DivideConquer.Algorithms {
  class MergeSort<Type> : Template<Type[], Type[]> where Type : IComparable {
    /// <summary>
    /// Determines if an array is solvable when the array is length 1.
    /// </summary>
    /// <param name="problem">The array to solve.</param>
    /// <returns>True if the array is solvable, false otherwise.</returns>
    public override bool Small(Type[] problem) {
      return problem.Length <= 1;
    }

    /// <summary>
    /// Solves an array when the array is length 1.
    /// </summary>
    /// <param name="problem">The array to solve.</param>
    /// <returns>Left first if left is less, otherwise right.</returns>
    public override Type[] SolveSmall(Type[] problem) {
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
      List<Type> combined = new List<Type>();
      for (int i = 0; i < solutions[0].Length - 1; i++) {
        if (solutions[0][i].CompareTo(solutions[1][i]) <= 0) {
          combined.Add(solutions[0][i]);
        } else {
          combined.Add(solutions[1][i]);
        }
      }
      return combined.ToArray();
    }
  }
}
