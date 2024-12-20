using Domain.DTOs;
using Domain.Models;
using Infrastructure.Responses;

namespace Infrastructure.Interfaces;

public interface IProductService
{
    Task<Response<List<Product>>> GetAllAsync(Product product);
    Task<Response<Product>> GetByIdAsync(int id);
    Task<Response<bool>> CreateAsync(Product product);
    Task<Response<bool>> UpdateAsync(Product product);
    Task<Response<bool>> DeleteAsync(int id);
    Task<Response<List<ProductDto>>> GetLowStockProductsAsync(int threshold);
    Task<Response<ProductDto>> GetMostExpensiveProductAsync();
}