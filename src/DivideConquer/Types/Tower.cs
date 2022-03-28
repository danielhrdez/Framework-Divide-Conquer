/// Universidad de La Laguna
/// Grado en Ingeniería Informática
/// Diseño y Análisis de Algoritmos
/// <author name="Daniel Hernandez de Leon"></author>
/// <class name="Tower"> Clase para representar problemas de torres de Hanoi </class>
 
using System;
using System.Collections.Generic;

namespace DivideConquer.Types {
  class Tower {
    private int _disks;
    private string _source;
    private string _auxiliary;
    private string _destination;

    /// <summary>
    /// Constructor of the class
    /// </summary>
    /// <param name="disks">The number of disks</param>
    /// <param name="source">The origin of the tower</param>
    /// <param name="auxiliary">The auxiliary of the tower</param>
    /// <param name="destination">The destination of the tower</param>
    public Tower(
        int disks,
        string source = "source",
        string auxiliary = "auxiliary",
        string destination = "destination"
    ) {
      this._disks = disks;
      this._source = source;
      this._auxiliary = auxiliary;
      this._destination = destination;
    }
    
    /// <summary>
    /// Getter and Setter the number of disks
    /// </summary>
    public int Disks {
      get { return this._disks; }
      set { this._disks = value; }
    }

    /// <summary>
    /// Getter and Setter the origin of the tower
    /// </summary>
    public string Source {
      get { return this._source; }
      set { this._source = value; }
    }

    /// <summary>
    /// Getter and Setter the auxiliary of the tower
    /// </summary>
    public string Auxiliary {
      get { return this._auxiliary; }
      set { this._auxiliary = value; }
    }

    /// <summary>
    /// Getter and Setter the destination of the tower
    /// </summary>
    public string Destination {
      get { return this._destination; }
      set { this._destination = value; }
    }
  }
}
