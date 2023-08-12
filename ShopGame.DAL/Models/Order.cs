namespace ShopGame.DAL.Models;

public class Order
{
    public int Id { get; set; }
    public DateTime OrderTime { get; set; }
    public int GameID { get; set; }
    public virtual Game Game { get; set; }
    public int UserId { get; set; }
    
}