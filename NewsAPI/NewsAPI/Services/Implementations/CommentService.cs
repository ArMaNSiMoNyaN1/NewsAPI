using Microsoft.EntityFrameworkCore;
using NewsAPI.Data;
using NewsAPI.Entities;
using NewsAPI.Services.Interfaces;

namespace NewsAPI.Services.Implementations;

public class CommentService : ICommentService
{
    private readonly DataContext _context;

    public CommentService(DataContext context)
    {
        _context = context;
    }

    public async Task<List<Comments>> GetAll()
    {
        var comments = await _context.Comments.ToListAsync();
        return comments;
    }

    public async Task<Comments?> GetById(int id)
    {
        return await _context.Comments.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<Comments> Add(Comments comments)
    {
        var result = _context.Comments.Add(comments);
        await _context.SaveChangesAsync();
        return result.Entity;
    }

    public async Task<Comments?> Update(Comments updateComments)
    {
        var comments = await _context.Comments.FindAsync(updateComments.Id);
        if (comments == null)
        {
            return null;
        }

        comments.Id = updateComments.Id;
        comments.UserId = updateComments.UserId;
        comments.Comment = updateComments.Comment;
        _context.Comments.Update(comments);
        await _context.SaveChangesAsync();
        return comments;
    }

    public async Task<bool> Delete(int id)
    {
        var comment = await _context.Comments.FindAsync(id);
        if (comment is null) return false;

        _context.Comments.Remove(comment);
        await _context.SaveChangesAsync();
        return true;
    }
}