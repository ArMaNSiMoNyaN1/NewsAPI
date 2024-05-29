namespace NewsAPI.APIModel.Comments;

public class CreateCommentModel
{
    public int UserId { get; set; }
    public int  NewsId { get; set; }
    public string Comment { get; set; }
}