using Application.DTO;
using Application.Interfaces.Service;
using Microsoft.AspNetCore.Mvc;

namespace TestTaskKaspelAn.Controllers
{
  [Route("api/orders")]
  [ApiController]
  public class OrderController : Controller
  {
    private readonly IServiceManager _serviceManager;
    public OrderController(IServiceManager serviceManager)
    {
      _serviceManager = serviceManager;
    }

    [HttpGet("filter")]
    public async Task<IActionResult> GetAllOrders([FromQuery] string? name, [FromQuery] DateTime? orderDate)
    {
      var orders = await _serviceManager.OrderService.GetAllOrders(name, orderDate, trackChanges: false);
      return Ok(orders);
    }

    [HttpGet("{Id:guid}", Name = "GetOrderById")]
    public async Task<IActionResult> GetOrderById(Guid Id)
    {
      var order = await _serviceManager.OrderService.GetOrderById(Id, trackChanges: false);
      return Ok(order);
    }

    [HttpPost]
    public async Task<IActionResult> CreateOrder([FromBody] CreateOrderDTO createOrder)
    {
      var createdOrder = await _serviceManager.OrderService.CreateOrder(createOrder);
      return CreatedAtRoute("GetOrderById", new { id = createdOrder.Id }, createdOrder);
    }

    [HttpPut("{Id:guid}")]
    public async Task<IActionResult> UpdateOrder(Guid Id, [FromBody] UpdateOrderDTO updateOrder)
    {
      //if (updateOrder == null)
      //  return BadRequest("UpdateOrderDTO is null.");

      await _serviceManager.OrderService.UpdateOrder(Id, updateOrder, trackChanges: true);
      return NoContent();
    }

    [HttpDelete("{Id:guid}")]
    public async Task<IActionResult> DeleteOrder(Guid Id)
    {
      await _serviceManager.OrderService.DeleteOrder(Id, trackChanges: false);
      return NoContent();
    }
  }
}
