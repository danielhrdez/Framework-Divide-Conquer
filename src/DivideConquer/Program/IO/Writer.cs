/// Universidad de La Laguna
/// Grado en Ingeniería Informática
/// Diseño y Análisis de Algoritmos
/// <author name="Daniel Hernandez de Leon"></author>
/// <class name="Writer"> Programa para la escritura de fichero de Divide y Vencerás </class>

using System.IO;

namespace IO {
  class Writer {
    /// <summary>
    /// Write the results of the algorithm in a CSV file
    /// </summary>
    /// <param name="timeResults">The results of the algorithm</param>
    /// <param name="filename">The name of the file</param>
    public void WriteCSV(object[][] timeResults, string filename) {
      Directory.CreateDirectory("./csv");
      using (StreamWriter writer = new StreamWriter("./csv/" + filename + ".csv")) {
        writer.WriteLine("{0}: Milliseconds,Size", timeResults[0][0]);
        for (int i = 0; i < timeResults.Length; i++) {
          writer.WriteLine("{0},{1}", timeResults[i][1], timeResults[i][2]);
        }
      }
    }
  }
}
