using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Services.Notifications;
using NewsAPI.APIModel.News;
using NewsAPI.Entities;
using NewsAPI.Services.Interfaces;

namespace NewsAPI.Controller;

[Route("api/NewsAPI")]
[ApiController]
public class NewsController : ControllerBase
{
    private readonly INewsService _newsService;
    private readonly IMapper _mapper;

    public NewsController(INewsService newsService, IMapper mapper)
    {
        _newsService = newsService;
        _mapper = mapper;
    }

    [HttpGet]
    [AllowAnonymous]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<List<GetNewsModel>>> GetAll()
    {
        var news = await _newsService.GetAll();
        var result = news.Select(x => _mapper.Map<GetNewsModel>(x)).ToList();

        return result;
    }

    [HttpGet]
    [Authorize(Roles = "admin")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [Route("{id}")]
    public async Task<ActionResult<GetByIdNewsModel>> GetById(int id)
    {
        var news = await _newsService.GetById(id);
        if (news is null) return NotFound();
        var result = _mapper.Map<GetByIdNewsModel>(news);
        return Ok(result);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<GetByIdNewsModel>> Add(CreateNewsModel newsModel)
    {
        var news = _mapper.Map<News>(newsModel);
        var newNews = await _newsService.Add(news);
        var result = _mapper.Map<GetByIdNewsModel>(newNews);
        return Ok(result);
    }

    [HttpPut]
    public async Task<ActionResult<GetByIdNewsModel>> Update(UpdateNewsModel updateNewsModel)
    {
        var news = _mapper.Map<News>(updateNewsModel);
        var updatedNews = await _newsService.Update(news);
        if (updatedNews is null) return NotFound();
        var newsModel = _mapper.Map<GetByIdNewsModel>(news);
        return Ok(newsModel);
    }

    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [HttpDelete("{id}")]
    [Authorize(Roles = "admin")]
    public async Task<ActionResult> Delete(int id)
    {
        var result = await _newsService.Delete(id);
        if (!result)
        {
            return NotFound();
        }

        return NoContent();
    }
}