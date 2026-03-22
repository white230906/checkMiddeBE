namespace TestRepo.Service.Category;

public interface IService
{
    public Task<Request.CategoryRequest> CreateCategoryRequest(Request.CategoryRequest categoryRequest);
    public Task<List<Response.GetCateGoryResponse>> GetAllCategories();
    public Task<List<Response.GetCateGoryResponse>> GetAllChildren(Guid parentId);
}