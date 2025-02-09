public interface IBaseRepository<T>
{
  Task<T> Create(T obj);
  void Update(T obj);
  void Delete(T obj);
}