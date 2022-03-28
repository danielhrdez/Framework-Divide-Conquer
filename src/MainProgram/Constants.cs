/// Universidad de La Laguna
/// Grado en Ingeniería Informática
/// Diseño y Análisis de Algoritmos
/// <author name="Daniel Hernandez de Leon"></author>
/// <class name="Constants"> Programa para las constantes de Divide y Vencerás </class>

namespace MainProgram {
  class Constants {
    public static const int NUMBER_ARRAYS = 18;
    public static const int NUMBER_SEARCH = 28;
    public static const int NUMBER_TOWERS = 5;
    public static const int MAX_VALUE = 100;
    public static const int MIN_SIZE = 1;
    public static const string TITLE = @"

██████╗ ██╗██╗   ██╗██╗██████╗ ███████╗     █████╗ ███╗   ██╗██████╗      ██████╗ ██████╗ ███╗   ██╗ ██████╗ ██╗   ██╗███████╗██████╗ 
██╔══██╗██║██║   ██║██║██╔══██╗██╔════╝    ██╔══██╗████╗  ██║██╔══██╗    ██╔════╝██╔═══██╗████╗  ██║██╔═══██╗██║   ██║██╔════╝██╔══██╗
██║  ██║██║██║   ██║██║██║  ██║█████╗      ███████║██╔██╗ ██║██║  ██║    ██║     ██║   ██║██╔██╗ ██║██║   ██║██║   ██║█████╗  ██████╔╝
██║  ██║██║╚██╗ ██╔╝██║██║  ██║██╔══╝      ██╔══██║██║╚██╗██║██║  ██║    ██║     ██║   ██║██║╚██╗██║██║▄▄ ██║██║   ██║██╔══╝  ██╔══██╗
██████╔╝██║ ╚████╔╝ ██║██████╔╝███████╗    ██║  ██║██║ ╚████║██████╔╝    ╚██████╗╚██████╔╝██║ ╚████║╚██████╔╝╚██████╔╝███████╗██║  ██║
╚═════╝ ╚═╝  ╚═══╝  ╚═╝╚═════╝ ╚══════╝    ╚═╝  ╚═╝╚═╝  ╚═══╝╚═════╝      ╚═════╝ ╚═════╝ ╚═╝  ╚═══╝ ╚══▀▀═╝  ╚═════╝ ╚══════╝╚═╝  ╚═╝
                                                                                                                                      
";

    public static enum ALGORITHM {
      MergeSort,
      QuickSort,
      BinarySearch,
      HanoiTower,
    }
  }
}