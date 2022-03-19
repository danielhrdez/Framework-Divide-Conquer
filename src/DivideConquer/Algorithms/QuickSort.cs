using System;
using System.Collections.Generic;

namespace DivideConquer.Algorithms {
  class QuickSort<Type> : Template<Type[], Type[]> where Type : IComparable {
    /// <summary>
    ///   Check if the length of the array is less than 2.
    /// </summary>
    /// <param name="array">The array to check.</param>
    /// <returns>True if the length of the array is less than 2.</returns>
    public override bool Small(Type[] array) {
      return array.Length < 2;
    }

    /// <summary>
    ///   return the array.
    /// </summary>
    /// <param name="array">The array to return.</param>
    /// <returns>The array.</returns>
    public override Type[] SolveSmall(Type[] array) {
      return array;
    }

    /// <summary>
    ///   Divide the array into two subarrays by a pivot.
    /// </summary>
    /// <param name="array">The array to divide.</param>
    /// <returns>The two subarrays.</returns>
    public override Type[][] Divide(Type[] array) {
      List<Type> left = new List<Type>();
      List<Type> right = new List<Type>();
      for (int i = 1; i < array.Length; i++) {
        if (array[i].CompareTo(array[0]) < 0) {
          left.Add(array[i]);
        } else {
          right.Add(array[i]);
        }
      }
      return new Type[2][] { left.ToArray(), right.ToArray() };
    }

    /// <summary>
    ///   Merge the two subarrays.
    /// </summary>
    /// <param name="left">The left subarray.</param>
    /// <param name="right">The right subarray.</param>
    /// <returns>The merged subarray.</returns>
    public override Type[] Combine(Type[][] subarrays) {
      List<Type> left = new List<Type>(subarrays[0]);
      List<Type> right = new List<Type>(subarrays[1]);
      List<Type> combined = new List<Type>();
      combined.AddRange(left);
      combined.AddRange(right);
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
