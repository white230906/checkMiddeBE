using Microsoft.AspNetCore.Mvc;
using TestRepo.Repository;
using TestRepo.Repository.Entity;
using TestRepo.Service.Category;

namespace TestRepo.Api.Controller;

[ApiController]
[Route("[controller]")]
public class CategoryController: ControllerBase
{
    private readonly IService _service;
    public CategoryController(IService service)
    {
        _service = service;
    }
    
    [HttpPost("")]
    public async Task<IActionResult> CreateCategory([FromBody] Request.CategoryRequest request)
    {
        var category = await _service.CreateCategoryRequest(request);
        return Ok(category);
    }
    
    [HttpGet("")]
    public async Task<IActionResult> GetAllCategories()
    {
        var category = await _service.GetAllCategories();
        return Ok(category);
    }
    
    [HttpGet("{parentId}/Children")]
    public async Task<IActionResult> GetAllChildren(Guid parentId)
    {
        var category = await _service.GetAllChildren(parentId);
        return Ok(category);
    }
}