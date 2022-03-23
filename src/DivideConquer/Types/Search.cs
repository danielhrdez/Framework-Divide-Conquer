namespace DivideConquer.Types {
  class Search<Type> {
    private Type[] _list;
    private Type _search;
    private int _index;

    public Search(Type[] list, Type search, int index = 0) {
      this._list = list;
      this._search = search;
      this._index = index;
    }
    
    public Type[] List {
      get { return this._list; }
      set { this._list = value; }
    }

    public Type Search {
      get { return this._search; }
      set { this._search = value; }
    }

    public int Index {
      get { return this._index; }
      set { this._index = value; }
    }
  }
}
