using NewsAPI.Entities;

namespace NewsAPI.Services.Interfaces;

public interface ICommentService
{
    Task<List<Comments>> GetAll();
    Task<Comments?> GetById(int id);
    Task<Comments> Add(Comments comment);
    Task<Comments?> Update(Comments updateComment);
    Task<bool> Delete(int id);
}