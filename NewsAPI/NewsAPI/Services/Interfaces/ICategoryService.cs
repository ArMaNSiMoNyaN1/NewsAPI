using NewsAPI.Entities;

namespace NewsAPI.Services.Interfaces;

public interface ICategoryService
{
    Task<List<Category>> GetAll();
    Task<Category?> GetById(int id);
    Task<Category> Add(Category category);
    Task<Category?> Update(Category updateCategory);
    Task<bool> Delete(int id);
}