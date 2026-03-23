namespace TestRepo.Service.User;

public interface IService
{
    public Task<Response.UserResponse> CreateUser(Request.CreateUserRequest userRequest);
}