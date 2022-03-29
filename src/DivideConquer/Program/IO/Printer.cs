/// Universidad de La Laguna
/// Grado en Ingeniería Informática
/// Diseño y Análisis de Algoritmos
/// <author name="Daniel Hernandez de Leon"></author>
/// <class name="Printer"> Programa para los prints de Divide y Vencerás </class>

using DivideConquer.Types;
using Program;

namespace IO {
  class Printer {
    /// <summary>
    ///   Print the results of the benchmark.
    /// </summary>
    /// <param name="timeResults">The results of the benchmark.</param>
    public void PrintResults(object[][] timeResults) {
      Console.WriteLine("{0}", timeResults[0][0]);
      for (int i = 0; i < timeResults.Length; i++) {
        Console.Write("  Time: {0}", timeResults[i][1]);
        Console.WriteLine("  Size: {0}", timeResults[i][2]);
      }
      Console.WriteLine();
      Console.WriteLine("Time Complexity:");
      Console.WriteLine("  " + timeResults[0][3]);
      Console.WriteLine();
    }

    /// <summary>
    ///   Print the title.
    /// </summary>
    /// <param name="title">The title to print.</param>
    public void PrintTitle(string title) {
      Console.Clear();
      Console.ForegroundColor = ConsoleColor.Green;
      Console.WriteLine("{0}", title);
      Console.ResetColor();
    }

    /// <summary>
    ///   Print debugmode
    /// </summary>
    public void DebugMode() {
      Console.ForegroundColor = ConsoleColor.Red;
      Console.WriteLine("Debug Mode");
      Console.WriteLine();
      Console.ResetColor();
    }

    /// <summary>
    ///   Print the menu
    /// </summary>
    /// <returns>The algorithm chosen by the user</returns>
    public Constants.ALGORITHM PrintMenu() {
      Console.OutputEncoding = System.Text.Encoding.UTF8;
      Console.WriteLine("Choose Algorithm:");
      Console.ForegroundColor = ConsoleColor.Red;
      Console.WriteLine("  Merge Sort ➗");
      Console.ResetColor();
      Console.ForegroundColor = ConsoleColor.Blue;
      Console.WriteLine("  Quick Sort 💨");
      Console.ResetColor();
      Console.ForegroundColor = ConsoleColor.Yellow;
      Console.WriteLine("  Binary Search 🔍");
      Console.ResetColor();
      Console.ForegroundColor = ConsoleColor.Magenta;
      Console.WriteLine("  Hanoi Towers 🗼");
      Console.ResetColor();
      Console.SetCursorPosition(0, Console.CursorTop - 4);
      Console.Write(">");
      Console.SetCursorPosition(0, Console.CursorTop);
      const int MAX = 4;
      int current = 0;
      while(true) {
        switch (Console.ReadKey(true).Key) {
          case ConsoleKey.UpArrow:
            if (current - 1 >= 0) {
              Console.SetCursorPosition(0, Console.CursorTop);
              Console.Write(" ");
              Console.SetCursorPosition(0, Console.CursorTop - 1);
              Console.Write(">");
              Console.SetCursorPosition(0, Console.CursorTop);
              current--;
            }
            break;
          case ConsoleKey.DownArrow:
            if (current + 1 < MAX) {
              Console.SetCursorPosition(0, Console.CursorTop);
              Console.Write(" ");
              Console.SetCursorPosition(0, Console.CursorTop + 1);
              Console.Write(">");
              Console.SetCursorPosition(0, Console.CursorTop);
              current++;
            }
            break;
          case ConsoleKey.Enter:
            Console.SetCursorPosition(0, Console.CursorTop + 5 - current);
            return (Constants.ALGORITHM) current;
        }
      }
    }

    /// <summary>
    ///   Print the results of the search.
    /// </summary>
    /// <param name="array">The array to search.</param>
    /// <param name="result">The result of the search.</param>
    public void PrintSearch(Search<int> array, int result) {
      Console.WriteLine("Array generated: [" + string.Join(", ", array.List) + "]\n");
      Console.WriteLine("Target: " + array.Target + "\n");
      Console.WriteLine("Found value at: " + result + "\n");
    }

    /// <summary>
    ///   Print the results of the sort.
    /// </summary>
    /// <param name="array">The array to sort.</param>
    /// <param name="result">The result of the sort.</param>
    public void PrintSort(int[] array, int[] result) {
      Console.WriteLine("Array generated: [" + string.Join(", ", array) + "]\n");
      Console.WriteLine("Sorted Array: [" + string.Join(", ", result) + "]\n");
    }

    /// <summary>
    ///   Print the results of the towers of hanoi.
    /// </summary>
    /// <param name="steps">The steps of the towers of hanoi.</param>
    public void PrintTower(Step[] steps) {
      int index = 0;
      foreach (Step step in steps) {
        Console.WriteLine("Step " + index + ": \n  " + step.ToString() + "\n");
        index++;
      }
    }

    public void PrintRecursion(int maxLevel, int calls) {
      Console.WriteLine("Max Level: " + maxLevel);
      Console.WriteLine("Recursion: " + calls + " calls" + "\n");
    }
  }
}
