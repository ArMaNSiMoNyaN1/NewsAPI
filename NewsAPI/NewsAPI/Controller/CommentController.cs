using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NewsAPI.APIModel.Comments;
using NewsAPI.Entities;
using NewsAPI.Services.Interfaces;

namespace NewsAPI.Controller;

[Route("api/[controller]")]
[ApiController]
public class CommentController : ControllerBase
{
    private readonly ICommentService _commentService;
    private readonly IMapper _mapper;

    public CommentController(ICommentService commentService, IMapper mapper)
    {
        _commentService = commentService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<List<GetCommentModel>>> GetAll()
    {
        var comment = await _commentService.GetAll();
        var result = comment.Select(x => _mapper.Map<GetCommentModel>(x)).ToList();
        return Ok(result);
    }

    [HttpGet]
    [Route("{id}")]
    public async Task<ActionResult<GetByIdCommentModel>> GetById(int id)
    {
        var comment = await _commentService.GetById(id);
        if (comment is null) return NotFound();
        var result = _mapper.Map<GetByIdCommentModel>(comment);
        return Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult<GetByIdCommentModel>> Add(CreateCommentModel commentModel)
    {
        var comment = _mapper.Map<Comments>(commentModel);
        var newComment = await _commentService.Add(comment);
        var result = _mapper.Map<GetByIdCommentModel>(newComment);
        return Ok(result);
    }

    [HttpPut]
    public async Task<ActionResult<GetByIdCommentModel>> Update(UpdateCommentModel updateCommentModel)
    {
        var comment = _mapper.Map<Comments>(updateCommentModel);
        var updateComment = await _commentService.Update(comment);
        if (updateComment is null) return NotFound();
        var commentModel = _mapper.Map<GetByIdCommentModel>(comment);
        return Ok(commentModel);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var result = await _commentService.Delete(id);
        if (!result)
        {
            return NotFound();
        }

        return NoContent();
    }
}