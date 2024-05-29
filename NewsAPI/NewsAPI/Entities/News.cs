namespace NewsAPI.Entities;

public class News
{
    public int Id { get; set; }

    public string Title { get; set; }

    public string Content { get; set; }

    public DateTime Publish_Date { get; set; }

    public string Publisher { get; set; }

    public int View_counter { get; set; }

    public int Comment_Counter { get; set; }

    public string Source { get; set; }
}