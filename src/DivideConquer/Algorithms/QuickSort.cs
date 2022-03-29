/// Universidad de La Laguna
/// Grado en Ingeniería Informática
/// Diseño y Análisis de Algoritmos
/// <author name="Daniel Hernandez de Leon"></author>
/// <class name="QuickSort"> Implementación de la ordenación por selección </class>

namespace DivideConquer.Algorithms {
  class QuickSort<Type> : Template<Type[], Type[]> where Type : IComparable {
    /// <summary>
    /// Constructor of QuickSort.
    /// </summary>
    public QuickSort() {
      this._subproblems = "2";
      this._sizeSubproblems = "n / 2";
      this._additionalComplexity = "n";
    }

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
      Type pivot = array[0];
      for (int i = 1; i < array.Length; i++) {
        if (array[i].CompareTo(pivot) < 0) left.Add(array[i]);
        else right.Add(array[i]);
      }
      return new Type[3][] { left.ToArray(), new Type[1] { pivot }, right.ToArray() };
    }

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
      combined.AddRange(subarrays[2]);
      return combined.ToArray();
    }
  }
}
