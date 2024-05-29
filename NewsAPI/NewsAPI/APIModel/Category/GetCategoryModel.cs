using NewsAPI.Entities;

namespace NewsAPI.APIModel.Category;

public class GetCategoryModel
{
    public int Id { get; set; }
    public NewsCategory Category_Name { get; set; }
    public string News_Id { get; set; } = string.Empty;

}