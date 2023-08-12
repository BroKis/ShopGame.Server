using ShopGame.DAL.Models;

namespace ShopGame.DAL.Repository.Interfaces;

public interface IOrderRepository:IRepository<Order>
{
    public Task<IEnumerable<Order>> GetByUserId(int userId);
}