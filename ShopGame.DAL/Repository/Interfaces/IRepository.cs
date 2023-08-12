namespace ShopGame.DAL.Repository.Interfaces;

public interface IRepository<T>:IDisposable where T:class
{
    Task<IEnumerable<T>> GetAll();
    Task<bool> Insert(T entity);       
    Task<bool> Update(T entity);
    Task<bool> Delete(int id);
    Task<T> GetID(int id);
}