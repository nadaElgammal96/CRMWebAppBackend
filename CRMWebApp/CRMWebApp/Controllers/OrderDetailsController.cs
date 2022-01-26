using CRMWebApp.Helpers;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using Service.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CRMWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailsController : ControllerBase
    {
        private IOrderDetailService orderDetailService { get; }

        public OrderDetailsController(IOrderDetailService _orderDetailService)
        {
            orderDetailService = _orderDetailService;
            new Logger();
        }

        // GET: api/<OrderDetailsController>/getAll
        [HttpGet()]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                return Ok(await orderDetailService .GetAllOrderDetails());
            }
            catch (Exception ex)
            {
                Log.Error($"Controller: OrderDetails , Action: GetAll , Message: {ex.Message}");
                return StatusCode(500);
            }
            finally
            {
                Log.CloseAndFlush();
            }

        }

        // GET api/<OrderDetailsController>/getById/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            try
            {
                return Ok(await orderDetailService.GetOrderDetailById(id));
            }
            catch (Exception ex)
            {
                Log.Error($"Controller: OrderDetails , Action: GetById , Message: {ex.Message}");
                return StatusCode(500);
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        // POST api/<OrderDetailsController>/create
        [HttpPost()]
        public async Task<IActionResult> CreateOrderDetail ([FromBody] OrderDetail orderDetail)
        {
            try
            {
                return Ok(await orderDetailService.AddOrderDetail(orderDetail));
            }
            catch (Exception ex)
            {
                Log.Error($"Controller: OrderDetails , Action: CreateOrderDetail , Message: {ex.Message}");
                return StatusCode(500);
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        // PUT api/<OrderDetailsController>/update/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateOrderDetail ( [FromRoute] int id, [FromBody] OrderDetail orderDetail)
        {
            try
            {
                if (id != orderDetail.OrderLineID)
                    return BadRequest();

                return Ok(await orderDetailService.UpdateOrderDetail(orderDetail));
            }
            catch (Exception ex)
            {
                Log.Error($"Controller: OrderDetails , Action: UpdateOrderDetail , Message: {ex.Message}");
                return StatusCode(500);
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        // DELETE api/<OrderDetailsController>/delete/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrderDetail(int id)
        {
            try
            {
                return Ok(await orderDetailService.DeleteOrderDetail(id));
            }
            catch (Exception ex)
            {
                Log.Error($"Controller: OrderDetails , Action: DeleteOrderDetail , Message: {ex.Message}");
                return StatusCode(500);
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        [HttpGet("GetAllWithTaxAndProduct/{id}")]
        public async Task<IActionResult> GetAllWithTaxAndProduct([FromRoute] int id)
        {
            try
            {
                return Ok(await orderDetailService.GetAllWithTaxAndProduct(id));
            }
            catch (Exception ex)
            {
                Log.Error($"Controller: OrderDetails , Action: GetAllWithTaxAndProduct , Message: {ex.Message}");
                return StatusCode(500);
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        [HttpPost("AddByRange")]
        public async Task<IActionResult> AddByRange([FromBody] IEnumerable<OrderDetail> orderDetails)
        {
            try
            {
                return Ok(await orderDetailService.AddByRange(orderDetails));
            }
            catch (Exception ex)
            {
                Log.Error($"Controller: OrderDetails , Action: AddByRange , Message: {ex.Message}");
                return StatusCode(500);
            }
            finally
            {
                Log.CloseAndFlush();
            }

        }
    }
}
