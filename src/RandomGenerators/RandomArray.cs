/// Universidad de La Laguna
/// Grado en Ingeniería Informática
/// Diseño y Análisis de Algoritmos
/// <author name="Daniel Hernandez de Leon"></author>
/// <class name="RandomArray"> Generador de arrays aleatorios </class>

using System;

namespace RandomGenerators {
  class RandomArray<T> {
    /// <summary>
    ///   Generate a random array.
    /// </summary>
    /// <param name="length">The length of the array.</param>
    /// <param name="generator">The random generator.</param>
    /// <returns>The random array.</returns>
    public T[] Create(int length, Func<int, T> generator) {
      T[] array = new T[length];
      for (int i = 0; i < length; i++) {
        array[i] = generator(i);
      }
      return array;
    }
  }
}
