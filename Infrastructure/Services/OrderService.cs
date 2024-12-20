using System.Net;
using Dapper;
using Domain.Models;
using Infrastructure.Data;
using Infrastructure.Interfaces;
using Infrastructure.Responses;

namespace Infrastructure.Services;

public class OrderService(IContext context):IOrderService
{
    public async Task<Response<List<Order>>> GetAllAsync(Order order)
    {
        try
        {
            using var connection = context.Connection();
            var cmd = "SELECT * FROM orders";
            var response = await context.Connection().QueryAsync<Order>(cmd);
            return new Response<List<Order>>(response.ToList());
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public async Task<Response<Order>> GetByIdAsync(int id)
    {
        try
        {
            using var connection = context.Connection();
            var cmd = "SELECT * FROM orders WHERE orderId =@id";
            var response = await context.Connection().QuerySingleOrDefaultAsync<Order>(cmd, new { OrderId = id });
            if (response == null) return new Response<Order>(HttpStatusCode.NotFound, "Order not found");
            return new Response<Order>(response);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    public async Task<Response<bool>> CreateAsync(Order order)
    {
        try
        {
            using var connection = context.Connection();
            var cmd =
                "INSERT INTO orders (FullName,Email,Phone,Role,CreatedAt) values (@FullName, @Email, @Phone, @Role, @CreatedAt)";
            var response = await context.Connection().ExecuteAsync(cmd, order);
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

    public async Task<Response<bool>> UpdateAsync(Order order)
    {
        try
        {
            using var connection = context.Connection();
            var cmd =
                "INSERT INTO orders (FullName=@FullName,Email=@Email,Phone=@Phone,Role=@Role,CreatedAt=@CreatedAt)";
            var response = await context.Connection().ExecuteAsync(cmd, order);
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
            var cmd = "DELETE FROM orders WHERE OrderId = @id";
            var response = await context.Connection().ExecuteAsync(cmd, new { OrderId = id });
            if (response == 0) return new Response<bool>(HttpStatusCode.NotFound, "Order not found");
            return new Response<bool>(response != 0);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }
}