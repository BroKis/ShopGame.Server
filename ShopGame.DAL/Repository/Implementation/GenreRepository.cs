using Microsoft.EntityFrameworkCore;
using ShopGame.DAL.Context;
using ShopGame.DAL.Models;
using ShopGame.DAL.Repository.Interfaces;

namespace ShopGame.DAL.Repository.Implementation;

public class GenreRepository:IGenreRepository
{
    
    private ApplicationContext db;

    public GenreRepository()
    {
        db = new ApplicationContext();
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

    public async Task<IEnumerable<Genre>> GetAll()
    {
        return await db.Genres.ToListAsync();
    }

    public async Task<bool> Insert(Genre entity)
    {
        await db.Genres.AddAsync(entity);
        await db.SaveChangesAsync();
        return true;
    }

    public Task<bool> Update(Genre entity)
    {
        throw new NotImplementedException();
    }

    public Task<bool> Delete(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<Genre> GetID(int id)
    {
        return await db.Genres.FindAsync(id);
    }
}