/// Universidad de La Laguna
/// Grado en Ingeniería Informática
/// Diseño y Análisis de Algoritmos
/// <author name="Daniel Hernandez de Leon"></author>
/// <class name="Search"> Clase generica para los problemas de busqueda </class>
 
using System;
using System.Collections.Generic;

namespace DivideConquer.Types {
  class Search<Type> where Type : IComparable {
    private Type[] _list;
    private Type _target;
    private int _index;

    /// <summary>
    /// Constructor of the class
    /// </summary>
    /// <param name="list">The list to search</param>
    /// <param name="target">The target to search</param>
    /// <param name="index">The index of the target</param>
    public Search(Type[] list, Type target, int index = 0) {
      this._list = list;
      this._target = target;
      this._index = index;
    }
    
    /// <summary>
    /// Getter and Setter the index of the target
    /// </summary>
    public Type[] List {
      get { return this._list; }
      set { this._list = value; }
    }

    /// <summary>
    /// Getter and Setter the target to search
    /// </summary>
    public Type Target {
      get { return this._target; }
      set { this._target = value; }
    }

    /// <summary>
    /// Getter and Setter the index of the target
    /// </summary>
    public int Index {
      get { return this._index; }
      set { this._index = value; }
    }
  }
}
