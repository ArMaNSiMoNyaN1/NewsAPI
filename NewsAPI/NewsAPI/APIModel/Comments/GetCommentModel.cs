namespace NewsAPI.APIModel.Comments;

public class GetCommentModel
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int NewsId { get; set; }
    public string Comment { get; set; }
}