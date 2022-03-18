using static DivideConquerTemplate;

namespace Algorithms {
  class QuickSort<Array> : DivideConquerTemplate<Problem, Solution> {
    /// <summary>
    ///   Check if the length of the array is less than 2.
    /// </summary>
    /// <param name="array">The array to check.</param>
    /// <returns>True if the length of the array is less than 2.</returns>
    public bool small(Array array) {
      return array.Length < 2;
    }

    /// <summary>
    ///   return the array.
    /// </summary>
    /// <param name="array">The array to return.</param>
    /// <returns>The array.</returns>
    public Array solveSmall(Array array) {
      return new Array(array);
    }

    /// <summary>
    ///   Divide the array into two subarrays by a pivot.
    /// </summary>
    /// <param name="array">The array to divide.</param>
    /// <returns>The two subarrays.</returns>
    public Array[] divide(Array array) {
      int pivot = array[array.Length >> 1];
      Array left = new Array();
      ProbArraylem right = new Array();
      for (int i = 0; i < array.Length; i++) {
        if (array[i] < pivot) {
          left.Add(array[i]);
        } else {
          right.Add(array[i]);
        }
      }
      return new Array[] { left, right };
    }

    /// <summary>
    ///   Merge the two subarrays.
    /// </summary>
    /// <param name="left">The left subarray.</param>
    /// <param name="right">The right subarray.</param>
    /// <returns>The merged subarray.</returns>
    public Array combine(Array[] subarrays) {
      Array left = subarrays[0];
      Array right = subarrays[1];
      return new Array(left.Concat(right));
    }
  }
}
