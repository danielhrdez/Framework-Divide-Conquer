using System;
using System.Collections.Generic;

namespace DivideConquer.Types {
  class Search<Type> : Problem where Type : IComparable {
    private Type[] _list;
    private Type _item;
    private int _index;

    public Search(Type[] list, Type item, int index = 0) {
      this._list = list;
      this._item = item;
      this._index = index;
    }
    
    public Type[] List {
      get { return this._list; }
      set { this._list = value; }
    }

    public Type Item {
      get { return this._item; }
      set { this._item = value; }
    }

    public int Index {
      get { return this._index; }
      set { this._index = value; }
    }
  }
}
