namespace NewsAPI.APIModel.News;

public class GetByIdNewsModel
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
    public DateTime Publish_Date { get; set; }
    public string Publisher { get; set; } = string.Empty;
    public int ViewCounter { get; set; }
    public int CommentCounter { get; set; }
    public string Source { get; set; } = string.Empty;
}