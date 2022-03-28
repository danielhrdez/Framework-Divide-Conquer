/// Universidad de La Laguna
/// Grado en Ingeniería Informática
/// Diseño y Análisis de Algoritmos
/// <author name="Daniel Hernandez de Leon"></author>
/// <class name="Step"> Clase para representar pasos de torres de Hanoi </class>
 
using System;
using System.Collections.Generic;

namespace DivideConquer.Types {
  class Step {
    private string _from;
    private string _to;

    /// <summary>
    /// Constructor of the class
    /// </summary>
    /// <param name="from">The origin of the step</param>
    /// <param name="to">The destination of the step</param>
    public Step(string from, string to) {
      this._from = from;
      this._to = to;
    }
    
    /// <summary>
    /// Getter and Setter the origin of the step
    /// </summary>
    public string From {
      get { return this._from; }
      set { this._from = value; }
    }

    /// <summary>
    /// Getter and Setter the destination of the step
    /// </summary>
    public string To {
      get { return this._to; }
      set { this._to = value; }
    }

    /// <summary>
    /// Override of the ToString method
    /// </summary>
    public override string ToString()
    {
      return "From: " + this._from + " To: " + this._to;
    }
  }
}
