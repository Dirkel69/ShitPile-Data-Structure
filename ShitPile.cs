namespace Test;

class ShitPile<T>
{
    private T[] _arr = Array.Empty<T>();
    public int Weigh => _arr.Length;
    public void Shit(T item)
    {
        T[] newArr = new T[_arr.Length + 1];
        for (int i = 0; i < _arr.Length; i++)
            newArr[i] = _arr[i];
        newArr[_arr.Length] = item; // Corrected line
        _arr = newArr;
    }
    public T Sniff() => _arr[new Random().Next(0, _arr.Length)];
    private void _Remove(int index)
    {
        if (index < 0 || index >= _arr.Length) throw new ArgumentOutOfRangeException(nameof(index), "Index is out of range of the array.");

        T[] newArr = new T[_arr.Length - 1];
        for (int i = 0; i < index; i++)
            newArr[i] = _arr[i];
        for (int i = index + 1; i < _arr.Length; i++)
            newArr[i - 1] = _arr[i];
        _arr = newArr;
    }
    public T Wipe()
    {
        int index = new Random().Next(0, _arr.Length);
        T result = _arr[index];
        _Remove(index);
        return result;
    }
    public void Flush() => _arr = Array.Empty<T>();
}