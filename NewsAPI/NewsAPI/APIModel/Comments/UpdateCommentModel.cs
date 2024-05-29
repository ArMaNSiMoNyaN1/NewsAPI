namespace NewsAPI.APIModel.Comments;

public class UpdateCommentModel
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public string Comment { get; set; }
}