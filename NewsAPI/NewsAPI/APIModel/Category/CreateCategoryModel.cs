using NewsAPI.Entities;

namespace NewsAPI.APIModel.Category;

public class CreateCategoryModel
{
    public NewsCategory Category_Name { get; set; }
    public int News_Id { get; set; } 
}