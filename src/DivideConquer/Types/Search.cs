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

    public Search(Type[] list, Type target, int index = 0) {
      this._list = list;
      this._target = target;
      this._index = index;
    }
    
    public Type[] List {
      get { return this._list; }
      set { this._list = value; }
    }

    public Type Target {
      get { return this._target; }
      set { this._target = value; }
    }

    public int Index {
      get { return this._index; }
      set { this._index = value; }
    }
  }
}
