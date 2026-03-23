namespace TestRepo.Service.Seller;

public class Request
{
    public class CreateSellerRequest: User.Request.CreateUserRequest
    {
        public string TaxCode { get; set; } = null!;
        public string CompanyName { get; set; } = null!;
        public string CompanyAddress { get; set; } = null!;
    }
}