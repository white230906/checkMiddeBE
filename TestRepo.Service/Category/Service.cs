using Microsoft.EntityFrameworkCore;
using TestRepo.Repository;

namespace TestRepo.Service.Category;

public class Service: IService
{
    private readonly AppDbContext _dbContext;
    
    public Service(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<Request.CategoryRequest> CreateCategoryRequest(Request.CategoryRequest categoryRequest)
    {
        var newCategory = new Repository.Entity.Category()
        {
            Name = categoryRequest.Name,
            ParentId = categoryRequest.ParentId,
        };
        await _dbContext.Categories.AddAsync(newCategory);
        await _dbContext.SaveChangesAsync();
        return categoryRequest;
    }

    public async Task<List<Response.GetCateGoryResponse>> GetAllCategories()
    {
        var query = _dbContext.Categories.Where(c => true);
        query = query.OrderBy(c => c.Name);
        var selectedQuery = query.Select(c => new Response.GetCateGoryResponse()
        {
            Id = c.Id,
            Name = c.Name,
        });
        var result = await selectedQuery.ToListAsync();
        return result;
    }

    public async Task<List<Response.GetCateGoryResponse>> GetAllChildren(Guid parentId)
    {
        var query = _dbContext.Categories.Where(c => c.ParentId == parentId);
        query = query.OrderBy(c => c.Name);
        var selectedQuery = query.Select(c => new Response.GetCateGoryResponse()
        {
            Id = c.Id,
            Name = c.Name,
        });
        var result = await selectedQuery.ToListAsync();
        return result;
    }
}