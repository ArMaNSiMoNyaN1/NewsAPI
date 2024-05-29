namespace NewsAPI.APIModel.News;

public class UpdateNewsModel
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
    public DateTime Publish_Date { get; set; }
    public string Publisher { get; set; } = string.Empty;
    public string Source { get; set; } = string.Empty;

}