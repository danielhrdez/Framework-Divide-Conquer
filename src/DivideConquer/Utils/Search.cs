namespace DivideConquer.Utils {
  class Search<Type> {
    private Type[] _array;
    private Type _search;
    private int _first;
    private int _end;

    /// <summary>
    ///   Constructor.
    /// </summary>
    /// <param name="array">The array to search.</param>
    /// <param name="search">The element to search for.</param>
    /// <param name="first">The first index to search.</param>
    /// <param name="end">The last index to search.</param>
    public Search(Type[] array, Type search, int first, int end) {
      this._array = array;
      this._search = search;
      this._first = first;
      this._end = end;
    }

    /// <summary>
    ///   The array to search.
    /// </summary>
    public Type[] Array {
      get { return this.array; }
      set { this.array = value; }
    }

    /// <summary>
    ///   The element to search for.
    /// </summary>
    public Type Search {
      get { return this.search; }
      set { this.search = value; }
    }
    
    /// <summary>
    ///   The first index of the array to search.
    /// </summary>
    public int First {
      get { return this.first; }
      set { this.first = value; }
    }

    /// <summary>
    ///   The last index of the array to search.
    /// </summary>
    public int End {
      get { return this.end; }
      set { this.end = value; }
    }
  }
}
