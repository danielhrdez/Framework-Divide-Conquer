/// Universidad de La Laguna
/// Grado en Ingeniería Informática
/// Diseño y Análisis de Algoritmos
/// <author name="Daniel Hernandez de Leon"></author>
/// <class name="Scanner"> Programa para el scaneo de teclado de Divide y Vencerás </class>

using System;

namespace IO {
  class Scanner {
    /// <summary>
    /// Read the size chosen by the user
    /// </summary>
    /// <returns>The size chosen by the user</returns>
    public int ChooseSize() {
      string read;
      int size;
      string message = "Choose the size of the arrays: ";
      Console.Write(message);
      while (true) {
        Console.ForegroundColor = ConsoleColor.Yellow;
        read = Console.ReadLine();
        Console.ResetColor();
        Console.WriteLine();
        if (int.TryParse(read, out size)) {
          if (size > 0) return size;
        }
        Console.SetCursorPosition(message.Length, Console.CursorTop - 2);
      }
    }
  }
}