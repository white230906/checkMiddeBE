namespace TestRepo.Service.User;

public class Request
{
    public class CreateUserRequest
    {
        public required string Email { get; set; }
        public required string Password { get; set; }
    }
}