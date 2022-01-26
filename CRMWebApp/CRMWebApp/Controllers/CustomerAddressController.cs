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
    public class CustomerAddressController : ControllerBase
    {
        private ICustomerAddressService customerAdressService { get; }

        public CustomerAddressController(ICustomerAddressService _customerAdressService)
        {
            customerAdressService = _customerAdressService;
            new Logger();
        }

        // GET: api/<CustomerAddressController>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                return Ok( await customerAdressService.GetAllCustomerAddress());
            }
            catch (Exception ex)
            {
                Log.Error($"Controller: CustomerAddress , Action: GetAll , Message: {ex.Message}");
                return StatusCode(500);
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        // GET api/<CustomerAddressController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                return Ok(await customerAdressService.GetCustomerAddressById(id));
            }
            catch (Exception ex)
            {
                Log.Error($"Controller: CustomerAddress , Action: GetById , Message: {ex.Message}");
                return StatusCode(500);
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        [HttpGet("findShippingAdressByCustomer/{id}")]
        public async Task<IActionResult> GetShippingAddressByCustomerId([FromRoute] int id)
        {
            try
            {
                return Ok(await customerAdressService.FindCustomerShippingAddress(id));
            }
            catch (Exception ex)
            {
                Log.Error($"Controller: CustomerAddress , Action: GetShippingAddressByCustomerId , Message: {ex.Message}");
                return StatusCode(500);
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        [HttpGet("findBillingAdressByCustomer/{id}")]
        public async Task<IActionResult> GetBillingAddressByCustomerId([FromRoute] int id)
        {
            try
            {
                return Ok(await customerAdressService.FindCustomerBillingAddress(id));
            }
            catch (Exception ex)
            {
                Log.Error($"Controller: CustomerAddress , Action: GetBillingAddressByCustomerId , Message: {ex.Message}");
                return StatusCode(500);
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        // POST api/<CustomerAddressController>
        [HttpPost]
        public async Task<IActionResult> CreateCustomerAddress([FromBody] CustomerAddress customerAddress)
        {
            try
            {
                return Ok(await customerAdressService.AddCustomerAddress(customerAddress));
            }
            catch (Exception ex)
            {
                Log.Error($"Controller: CustomerAddress , Action: CreateCustomerAddress , Message: {ex.Message}");
                return StatusCode(500);
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        // PUT api/<CustomerAddressController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpadteCustomerAddress([FromRoute] int id, [FromBody] CustomerAddress customerAddress)
        {
            try
            {
                if (id != customerAddress.ID)
                {
                    return BadRequest();
                }
                return Ok(await customerAdressService.UpdateCustomerAddress(customerAddress));
            }
            catch (Exception ex)
            {
                Log.Error($"Controller: CustomerAddress , Action: UpadteCustomerAddress , Message: {ex.Message}");
                return StatusCode(500);
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        // DELETE api/<CustomerAddressController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            try
            {
                return Ok(await customerAdressService.DeleteCustomerAddress(id));
            }
            catch (Exception ex)
            {
                Log.Error($"Controller: CustomerAddress , Action: Delete , Message: {ex.Message}");
                return StatusCode(500);
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }
    }
}
