using Domain.Models;
using Infrastructure.Interfaces;
using Infrastructure.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrderController(IOrderService orderService) : ControllerBase
{
    [HttpGet]
    public async Task<Response<List<Order>>> GetAllAsync(Order order)
    {
        var response = await orderService.GetAllAsync(order);
        return response;
    }

    [HttpGet("{id:int}")]
    public async Task<Response<Order>> GetByIdAsync(int id)
    {
        var response = await orderService.GetByIdAsync(id);
        return response;
    }

    [HttpPost]
    public async Task<Response<bool>> CreateAsync(Order order)
    {
        var response = await orderService.CreateAsync(order);
        return response;
    }
    [HttpPut]
    public async Task<Response<bool>> UpdateAsync(Order order)
    {
        var response = await orderService.UpdateAsync(order);
        return response;
    }
    [HttpDelete]
    public async Task<Response<bool>> DeleteAsync(int id)
    {
        var response = await orderService.DeleteAsync(id);
        return response;
    }

}