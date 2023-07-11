namespace UserAPI.Interfaces
{
    public interface IUser<K,T>
    {
        T Add(T item);
        T Get(K key);
        ICollection<T> GetAll();
        T Update(T item);
        T Delete(K key);
    }
}
