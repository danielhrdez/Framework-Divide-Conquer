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

    public Step(string from, string to) {
      this._from = from;
      this._to = to;
    }
    
    public string From {
      get { return this._from; }
      set { this._from = value; }
    }

    public string To {
      get { return this._to; }
      set { this._to = value; }
    }
  }
}
