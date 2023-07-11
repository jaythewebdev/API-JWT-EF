namespace HotelAPI.Interfaces
{
    public interface IBaseCRUD<k,T>
    {
        T Add(T item);
        T Get(k item);
        ICollection<T> GetAll();
        T Update(T item);
        T Delete(k item);
    }
}
