class RandomArray {
  /// <summary>
  ///   Generate a random array.
  /// </summary>
  /// <param name="length">The length of the array.</param>
  /// <param name="generator">The random generator.</param>
  /// <returns>The random array.</returns>
  public T[] Create<T>(int length, Func<T> generator) {
    T[] array = new T[length];
    for (int i = 0; i < length; i++) {
      array[i] = generator();
    }
    return array;
  }
}