namespace TestRepo.Service.Seller;

public interface IService
{
    public Task<Response.SellerResponse> CreateSeller(Request.CreateSellerRequest seller);
}