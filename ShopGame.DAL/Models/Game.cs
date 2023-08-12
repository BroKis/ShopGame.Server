using System.ComponentModel.DataAnnotations.Schema;

namespace ShopGame.DAL.Models;

public class Game
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public string? Title { get; set; }
    public string? ShortDescription { get; set; }
    public string? Description { get; set; }
    public string? ImageUrl { get; set; }
    public bool InStock { get; set; }
    public decimal Cost { get; set; }
    public int GenreId { get; set; }
    public virtual Genre Genre { get; set; }
    
    public virtual Order Order { get; set; }
}