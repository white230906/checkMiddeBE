namespace TestRepo.Service.User;

public class Response
{
    public class UserResponse
    {
        public Guid Id { get; set; }
        public string Email { get; set; } = null!;
    }
}