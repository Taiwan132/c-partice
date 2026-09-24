using Microsoft.AspNetCore.Mvc;

namespace MyApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    [HttpGet]
    public object Get()
    {
        return new
        {
            Id = 1,
            Name = "鍵盤",
            Price = 1000
        };
    }
}