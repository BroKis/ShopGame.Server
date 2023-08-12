namespace ShopGame.DAL.Models;

public class Genre
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public virtual Game Games { get; set; }
}