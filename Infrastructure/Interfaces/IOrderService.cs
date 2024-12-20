using Domain.Models;
using Infrastructure.Responses;

namespace Infrastructure.Interfaces;

public interface IOrderService
{
    Task<Response<List<Order>>> GetAllAsync(Order order);
    Task<Response<Order>> GetByIdAsync(int id);
    Task<Response<bool>> CreateAsync(Order order);
    Task<Response<bool>> UpdateAsync(Order order);
    Task<Response<bool>> DeleteAsync(int id);
}