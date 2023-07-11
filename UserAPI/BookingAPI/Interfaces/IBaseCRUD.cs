namespace BookingAPI.Interfaces
{
    public interface IBaseCRUD<K,T>
    {
        T Add(T item);
        T Get(K item);
        ICollection<T> GetAll();
        T Update(T item);
        T Delete(K item);
    }
}
