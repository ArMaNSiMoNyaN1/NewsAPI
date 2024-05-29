using NewsAPI.Entities;

namespace NewsAPI.Services.Interfaces;

public interface INewsService
{
    Task<List<News>> GetAll();
    Task<News?> GetById(int id);
    Task<News> Add(News news);
    Task<News?> Update(News updateNews);
    Task<bool> Delete(int id);
}   