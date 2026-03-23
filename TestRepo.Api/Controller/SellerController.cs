using Microsoft.AspNetCore.Mvc;
using TestRepo.Service.Identity;
using IService = TestRepo.Service.Seller.IService;
using Request = TestRepo.Service.Seller.Request;

namespace TestRepo.Api.Controller;

[ApiController]
[Route("[controller]")]
public class SellerController: ControllerBase
{
    private readonly IService _sellerService;
    
    public SellerController(IService sellerService)
    {
        _sellerService = sellerService;
    }

    [HttpPost("")]
    public async Task<IActionResult> CreateSeller([FromBody] Request.CreateSellerRequest sellerRequest)
    {
        var response = await _sellerService.CreateSeller(sellerRequest);
        return Ok(response);
    }
}