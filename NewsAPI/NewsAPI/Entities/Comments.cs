namespace NewsAPI.Entities;

public class Comments
{
    public int Id { get; set; }
    
    public int NewsId { get; set; }
    public int UserId { get; set; }
    public string Comment { get; set; }
    
}