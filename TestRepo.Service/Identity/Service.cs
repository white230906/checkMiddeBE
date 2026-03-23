using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using TestRepo.Repository;
using TestRepo.Service.JwtService;

namespace TestRepo.Service.Identity;

public class Service:IService
{
    private readonly AppDbContext _dbContext;
    private readonly JwtService.IService _tokenService;
    private readonly JwtOptions _jwtOption = new();

    public Service(AppDbContext dbContext, JwtService.IService tokenService, IConfiguration configuration)
    {
        _dbContext = dbContext;
        _tokenService = tokenService;
        configuration.GetSection(nameof(JwtOptions)).Bind(_jwtOption);
    }
    
    public async Task<Response.IdentityResponse> Login(string email, string password)
    {
        //check user
        var user = await _dbContext.Users.SingleOrDefaultAsync(x => x.Email == email);
        if (user == null)
        {
            throw new Exception("User not found");
        }
        //check password
        if (user.Password != password)
        {
            throw new Exception("Wrong password");
        }
        // claim
        var claims = new List<Claim>()
        {
            new Claim("UserId", user.Id.ToString()),
            new Claim("Email", user.Email),
            new Claim("Role", user.Role),
            new Claim(ClaimTypes.Role, user.Role)
        };
        //nap claim
        var token = _tokenService.GenerateAccessToken(claims);
        var result = new Response.IdentityResponse()
        {
            AccessToken = token,
        };
        
        //return
        return result;
    }
}