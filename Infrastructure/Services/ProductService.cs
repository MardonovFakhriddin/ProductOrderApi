using System.Net;
using Dapper;
using Domain.DTOs;
using Domain.Models;
using Infrastructure.Data;
using Infrastructure.Interfaces;
using Infrastructure.Responses;

namespace Infrastructure.Services;

public class ProductService(IContext context):IProductService
{
    public async Task<Response<List<Product>>> GetAllAsync(Product product)
    {
        try
        {
            using var connection = context.Connection();
            var cmd = "SELECT * FROM products";
            var response = await context.Connection().QueryAsync<Product>(cmd);
            return new Response<List<Product>>(response.ToList());
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public async Task<Response<Product>> GetByIdAsync(int id)
    {
        try
        {
            using var connection = context.Connection();
            var cmd = "SELECT * FROM products WHERE productId =@id";
            var response = await context.Connection().QuerySingleOrDefaultAsync<Product>(cmd, new { ProductId = id });
            if (response == null) return new Response<Product>(HttpStatusCode.NotFound, "Product not found");
            return new Response<Product>(response);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public async Task<Response<bool>> CreateAsync(Product product)
    {
        try
        {
            using var connection = context.Connection();
            var cmd =
                "INSERT INTO products (FullName,Email,Phone,Role,CreatedAt) values (@FullName, @Email, @Phone, @Role, @CreatedAt)";
            var response = await context.Connection().ExecuteAsync(cmd, product);
            if (response == 0)
                return new Response<bool>(HttpStatusCode.InternalServerError, "Internal server error");
            return new Response<bool>(response > 0);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public async Task<Response<bool>> UpdateAsync(Product product)
    {
        try
        {
            using var connection = context.Connection();
            var cmd =
                "INSERT INTO products (FullName=@FullName,Email=@Email,Phone=@Phone,Role=@Role,CreatedAt=@CreatedAt)";
            var response = await context.Connection().ExecuteAsync(cmd, product);
            if (response == 0)
                return new Response<bool>(HttpStatusCode.InternalServerError, "Internal server error");
            return new Response<bool>(response > 0);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public async Task<Response<bool>> DeleteAsync(int id)
    {
        try
        {
            using var connection = context.Connection();
            var cmd = "DELETE FROM products WHERE ProductId = @id";
            var response = await context.Connection().ExecuteAsync(cmd, new { ProductId = id });
            if (response == 0) return new Response<bool>(HttpStatusCode.NotFound, "Product not found");
            return new Response<bool>(response != 0);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public async Task<Response<List<ProductDto>>> GetLowStockProductsAsync(int threshold)
    {
        try
        {
            using var connection = context.Connection();
            var cmd = "SELECT ProductId, Name, Stock FROM Products WHERE Stock < @Threshold";
            var response = await connection.QueryAsync<ProductDto>(cmd, new { Threshold = threshold });
            return new Response<List<ProductDto>>(response.ToList());
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public async Task<Response<ProductDto>> GetMostExpensiveProductAsync()
    {
        try
        {
            using var connection = context.Connection();
            var cmd = " SELECT Id, Name, Price FROM Products ORDER BY Price DESC LIMIT 1";
            var response = await connection.QueryFirstOrDefaultAsync<ProductDto>(cmd);
            return new Response<ProductDto>(response);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }
}