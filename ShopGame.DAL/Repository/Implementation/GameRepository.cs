using Microsoft.EntityFrameworkCore;
using ShopGame.DAL.Context;
using ShopGame.DAL.Models;
using ShopGame.DAL.Repository.Interfaces;

namespace ShopGame.DAL.Repository.Implementation;

public class GameRepository:IGameRepository
{
    private ApplicationContext db;

    public GameRepository()
    {
        db = new ApplicationContext();
    }

    public async Task<IEnumerable<Game>> GetAll()
    {
        return await db.Games.Include(x => x.Genre).ToListAsync();
    }

    public async  Task<bool> Insert(Game entity)
    {
        await db.Games.AddAsync(entity);
        await db.SaveChangesAsync();
        return true;
    }

    public async Task<bool> Update(Game entity)
    {
        Game game = await db.Games.FindAsync(entity.Id);
        if (game != null)
        {
            game.Title = entity.Title;
            game.ShortDescription = entity.ShortDescription;
            game.Description = entity.Description;
            game.InStock = entity.InStock;
            game.Cost = entity.Cost;
            game.ImageUrl = entity.ImageUrl;
            game.GenreId = entity.GenreId;
            await db.SaveChangesAsync();
            return true;
        }

        return false;

    }
    
    public async Task<bool> Delete(int id)
    {
        Game game = await db.Games.FindAsync(id);
        if (game != null)
        {
            db.Games.Remove(game);
            await db.SaveChangesAsync();
            return true;
        }

        return false;
    }

    public async Task<Game> GetID(int id)
    {
        return await db.Games.Include(x => x.Genre).FirstAsync(x => x.Id==id);
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