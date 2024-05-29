using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NewsAPI.APIModel.Category;
using NewsAPI.Entities;
using NewsAPI.Services.Interfaces;

namespace NewsAPI.Controller;

[Route("api/[controller]")]
[ApiController]
public class CategoryController : ControllerBase
{
    private readonly ICategoryService _categoryService;
    private readonly IMapper _mapper;

    public CategoryController(ICategoryService categoryService, IMapper mapper)
    {
        _categoryService = categoryService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<List<GetCategoryModel>>> GetAll()
    {
        var category = await _categoryService.GetAll();
        var result = category.Select(x => _mapper.Map<GetCategoryModel>(x)).ToList();
        return Ok(result);
    }

    [HttpGet]
    [Route("{id}")]
    public async Task<ActionResult<GetByIdCategoryModel>> GetById(int id)
    {
        var category = await _categoryService.GetById(id);
        if (category is null) return NotFound();
        var result = _mapper.Map<GetByIdCategoryModel>(category);
        return Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult<GetByIdCategoryModel>> Add(CreateCategoryModel categoryModel)
    {
        var category = _mapper.Map<Category>(categoryModel);
        var newCategory = await _categoryService.Add(category);
        var result = _mapper.Map<GetByIdCategoryModel>(newCategory);
        return Ok(result);
    }

    [HttpPut]
    public async Task<ActionResult<GetByIdCategoryModel>> Update(UpdateCategoryModel updateCategoryModel)
    {
        var category = _mapper.Map<Category>(updateCategoryModel);
        var updatedCategory = await _categoryService.Update(category);
        if (updatedCategory is null) return NotFound();
        var categoryModel = _mapper.Map<GetByIdCategoryModel>(category);
        return Ok(categoryModel);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var result = await _categoryService.Delete(id);
        if (!result)
        {
            return NotFound();
        }

        return NoContent();
    }
}