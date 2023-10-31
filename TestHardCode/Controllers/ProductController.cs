using Microsoft.AspNetCore.Mvc;
using TestHardCode.Models;
using TestHardCode.Services;

namespace TestHardCode.Controllers;
[ApiController]
public class ProductController : ControllerBase
{
    private readonly IProductService _productService;

    public ProductController(IProductService productService)
    {
        _productService = productService;
    }

    public async Task<IActionResult> CreatProduct(Product product)
    {
        var result = await _productService.CreatProduct(product);
        return Ok(result);
    }
    
    public async Task<IActionResult> GetProductById(Guid guid)
    {
        var result = await _productService.GetProductById(guid);
        return Ok(result);
    }
    
    public async Task<IActionResult> GetProductList()
    {
        var result = await _productService.GetProductList();
        return Ok(result);
    }
    
    public async Task<IActionResult> GetCategoryProductsById(int id)
    {
        var result = await _productService.GetCategoryProductsById(id);
        return Ok(result);
    }
}