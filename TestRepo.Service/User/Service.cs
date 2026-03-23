using TestRepo.Repository;

namespace TestRepo.Service.User;

public class Service: IService
{
    private readonly AppDbContext _dbContext;
    
    public Service(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<Response.UserResponse> CreateUser(Request.CreateUserRequest userRequest)
    {
        var newUser = new Repository.Entity.User()
        {
            Email = userRequest.Email,
            Password = userRequest.Password,
        };
        await _dbContext.Users.AddAsync(newUser);
        await _dbContext.SaveChangesAsync();
        return new Response.UserResponse()
        {
            Id = newUser.Id,
            Email = newUser.Email,
        };
    }
    
}