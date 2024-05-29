using Microsoft.EntityFrameworkCore;
using NewsAPI.Data;
using NewsAPI.Entities;
using NewsAPI.Services.Interfaces;

namespace NewsAPI.Services.Implementations;

public class CategoryService : ICategoryService
{
    private readonly DataContext _context;

    public CategoryService(DataContext context)
    {
        _context = context;
    }

    public async Task<List<Category>> GetAll()
    {
        var category = await _context.Categories.ToListAsync();
        return category;
    }

    public async Task<Category?> GetById(int id)
    {
        return await _context.Categories.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<Category> Add(Category category)
    {
        var result = _context.Categories.Add(category);
        await _context.SaveChangesAsync();
        return (await GetById(result.Entity.Id))!;
    }

    public async Task<Category?> Update(Category updateCategory)
    {
        var category = await _context.Categories.FindAsync(updateCategory.Id);
        if (category == null)
        {
            return null;
        }

        category.Id = updateCategory.Id;
        category.Category_Name = updateCategory.Category_Name;
        category.News_Id = updateCategory.News_Id;
        _context.Categories.Update(category);
        await _context.SaveChangesAsync();

        return category;
    }

    public async Task<bool> Delete(int id)
    {
        var category = await _context.Categories.FindAsync(id);
        if (category is null) return false;

        _context.Categories.Remove(category);
        await _context.SaveChangesAsync();
        return true;
    }
}