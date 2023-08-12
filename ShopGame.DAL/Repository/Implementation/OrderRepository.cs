using Microsoft.EntityFrameworkCore;
using ShopGame.DAL.Context;
using ShopGame.DAL.Models;
using ShopGame.DAL.Repository.Interfaces;

namespace ShopGame.DAL.Repository.Implementation;

public class OrderRepository:IOrderRepository
{
    private ApplicationContext db;

    public OrderRepository()
    {
        db = new ApplicationContext();
    }


   

    public async Task<IEnumerable<Order>> GetAll()
    {
        return await db.Orders.Include(x => x.Game).ToListAsync();
    }

    public async Task<bool> Insert(Order entity)
    {
        await db.Orders.AddAsync(entity);
        await db.SaveChangesAsync();
        return true;
    }

    public Task<bool> Update(Order entity)
    {
        throw new NotImplementedException();
    }

    public Task<bool> Delete(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<Order> GetID(int id)
    {
        return await db.Orders.Include(x => x.Game).FirstAsync(x => x.Id == id);
    }

    public async Task<IEnumerable<Order>> GetByUserId(int userId)
    {
        var list = await db.Orders.Include(x => x.Game).Where(x => x.UserId == userId).ToListAsync();
        return list;
    }
    
    private bool disposed = false;

    public virtual void Dispose(bool disposing)
    {
        if (!this.disposed)
        {
            if (disposing)
            {
                db.Dispose();
            }
        }

        this.disposed = true;
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
}