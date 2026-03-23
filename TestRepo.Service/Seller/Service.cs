using TestRepo.Repository;

namespace TestRepo.Service.Seller;

public class Service: IService
{
    private readonly AppDbContext _dbContext;
    
    public Service(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<Response.SellerResponse> CreateSeller(Request.CreateSellerRequest request)
    {
        var user = new Repository.Entity.User()
        {
            Email = request.Email,
            Password = request.Password,
            Role = "Seller",
        };
        
        var seller = new Repository.Entity.Seller()
        {
            User = user,
            TaxCode = request.TaxCode,
            CompanyName = request.CompanyName,
            CompanyAddress = request.CompanyAddress,
        };
        await _dbContext.Users.AddAsync(user);
        await _dbContext.SaveChangesAsync();

        return new Response.SellerResponse()
        {
            Email = user.Email,
            Role = user.Role,
        };
    }
}