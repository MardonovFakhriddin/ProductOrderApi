using Domain.DTOs;
using Domain.Models;
using Infrastructure.Interfaces;
using Infrastructure.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers;
[ApiController]
[Route("api/[controller]")]
public class ProductController(IProductService productService):ControllerBase
{
    [HttpGet]
    public async Task<Response<List<Product>>> GetAllAsync(Product product)
    {
        var response = await productService.GetAllAsync(product);
        return response;
    }

    [HttpGet("{id:int}")]
    public async Task<Response<Product>> GetByIdAsync(int id)
    {
        var response = await productService.GetByIdAsync(id);
        return response;
    }

    [HttpPost]
    public async Task<Response<bool>> CreateAsync(Product product)
    {
        var response = await productService.CreateAsync(product);
        return response;
    }
    [HttpPut]
    public async Task<Response<bool>> UpdateAsync(Product product)
    {
        var response = await productService.UpdateAsync(product);
        return response;
    }
    [HttpDelete]
    public async Task<Response<bool>> DeleteAsync(int id)
    {
        var response = await productService.DeleteAsync(id);
        return response;
    }

    [HttpGet("/api/products/low-stock")]
    public async Task<Response<List<ProductDto>>> GetLowStockProductsAsync(int threshold)
    {
        var response = await productService.GetLowStockProductsAsync(threshold);
        return response;
    }

    [HttpGet("/api/products/most-expensive")]
    public async Task<Response<ProductDto>> GetMostExpensiveProductAsync()
    {
        var response = await productService.GetMostExpensiveProductAsync();
        return response;
    }
}