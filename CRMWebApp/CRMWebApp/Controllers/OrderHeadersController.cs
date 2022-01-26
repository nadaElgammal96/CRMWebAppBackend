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
    public class OrderHeadersController : ControllerBase
    {
        private IOrderHeaderService orderHeaderService { get; }

        public OrderHeadersController(IOrderHeaderService _orderHeaderService)
        {
            orderHeaderService = _orderHeaderService;
            new Logger();
        }

        // GET: api/<OrderHeadersController>/getAll
        [HttpGet()]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                return Ok(await orderHeaderService.GetAllOrderHeaders());
            }
            catch (Exception ex)
            {
                Log.Error($"Controller: OrderHeaders , Action: GetAll , Message: {ex.Message}");
                return StatusCode(500);
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        // GET api/<OrderHeadersController>/getById/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            try
            {
                return Ok(await orderHeaderService.GetOrderHeaderById(id));
            }
            catch (Exception ex)
            {
                Log.Error($"Controller: OrderHeaders , Action: GetById , Message: {ex.Message}");
                return StatusCode(500);
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        // POST api/<OrderHeadersController>/create
        [HttpPost()]
        public async Task<IActionResult> CreateOrderHeader([FromBody] OrderHeader orderHeader)
        {
            try
            {
                return Ok(await orderHeaderService.AddOrderHeader(orderHeader));
            }
            catch (Exception ex)
            {
                Log.Error($"Controller: OrderHeaders , Action: CreateOrderHeader , Message: {ex.Message}");
                return StatusCode(500);
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        // PUT api/<OrderHeadersController>/update/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateOrderHeader([FromRoute] int id, [FromBody] OrderHeader orderHeader)
        {
            try
            {
                if (id != orderHeader.OrderHeaderID)
                {
                    return BadRequest();
                }
                return Ok(await orderHeaderService.UpdateOrderHeader(orderHeader));
            }
            catch (Exception ex)
            {
                Log.Error($"Controller: OrderHeaders , Action: UpdateOrderHeader , Message: {ex.Message}");
                return StatusCode(500);
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        // DELETE api/<OrderHeadersController>/delete/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHeader([FromRoute] int id)
        {
            try
            {
                return Ok(await orderHeaderService.DeleteOrderHeader(id));
            }
            catch (Exception ex)
            {
                Log.Error($"Controller: OrderHeaders , Action: DeleteHeader , Message: {ex.Message}");
                return StatusCode(500);
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }
    }
}
