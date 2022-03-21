using System;
using System.Collections.Generic;
// using System.Linq;

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
      // if (array.Length <= 1) return array;
      // if (array[0].CompareTo(array[1]) <= 0) {
      //   return new Type[2] { array[0], array[1] };
      // }
      // return new Type[2] { array[1], array[0] };
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
      Type pivot = array[0];
      for (int i = 1; i < array.Length; i++) {
        if (array[i].CompareTo(pivot) < 0) {
          left.Add(array[i]);
        } else {
          right.Add(array[i]);
        }
      }
      return new Type[3][] { left.ToArray(), new Type[1] { pivot }, right.ToArray() };
    }
    
    // public override Type[][] Divide(Type[] array) {
    //   int middle = array.Length >> 1;
    //   int end = array.Length - 1;
    //   Type pivot = array[middle];
    //   int left = 0;
    //   int right = end - 1;
    //   array = this.Swap(array, middle, end);
    //   while (left < right) {
    //     while (left < right && array[left].CompareTo(pivot) < 0) left++;
    //     while (left < right && array[right].CompareTo(pivot) > 0) right--;
    //     if (left < right) array = this.Swap(array, left, right);
    //   }
    //   array = this.Swap(array, left, end);
    //   return new Type[2][] {
    //     array.Take(left).ToArray(),
    //     array.Skip(left).ToArray()
    //   };
    // }

    // private Type[] Swap(Type[] array, int left, int right) {
    //   Type temp = array[left];
    //   array[left] = array[right];
    //   array[right] = temp;
    //   return array;
    // }

    /// <summary>
    ///   Merge the two subarrays.
    /// </summary>
    /// <param name="left">The left subarray.</param>
    /// <param name="right">The right subarray.</param>
    /// <returns>The merged subarray.</returns>
    public override Type[] Combine(Type[][] subarrays) {
      List<Type> combined = new List<Type>();
      combined.AddRange(subarrays[0]);
      combined.AddRange(subarrays[1]);
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
