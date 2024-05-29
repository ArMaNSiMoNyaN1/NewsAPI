using Microsoft.EntityFrameworkCore;
using NewsAPI.Data;
using NewsAPI.Entities;
using NewsAPI.Services.Interfaces;

namespace NewsAPI.Services.Implementations;

public class NewsService : INewsService
{
    private readonly DataContext _context;

    public NewsService(DataContext context)
    {
        _context = context;
    }

    public async Task<List<News>> GetAll()
    {
        var news = await _context.News.ToListAsync();
        return news;
    }

    public async Task<News?> GetById(int id)
    {
        return await _context.News.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<News> Add(News news)
    {
        var result = _context.News.Add(news);
        await _context.SaveChangesAsync();
        return (await GetById(result.Entity.Id))!;
    }

    public async Task<News?> Update(News updateNews)
    {
        var news = await _context.News.FindAsync(updateNews.Id);
        if (news is null)
        {
            return null;
        }

        news.Id = updateNews.Id;
        news.Title = updateNews.Title;
        news.Content = updateNews.Content;
        news.Publish_Date = DateTime.UtcNow;
        news.Publisher = updateNews.Publisher;
        news.View_counter = updateNews.View_counter;
        news.Comment_Counter = updateNews.Comment_Counter;
        news.Source = updateNews.Source;
        _context.News.Update(news);
        await _context.SaveChangesAsync();

        return news;
    }

    public async Task<bool> Delete(int id)
    {
        var news = await _context.News.FindAsync(id);
        if (news is null) return false;
        _context.News.Remove(news);
        await _context.SaveChangesAsync();
        return true;
    }
}