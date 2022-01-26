using CRMWebApp.Helpers;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using Service.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CRMWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {

        private ICustomerService customerService { get; }

        public CustomersController(ICustomerService _customerService)
        {
            customerService = _customerService;
            new Logger();
        }
        
        // GET: api/<CustomersController>/getAll
        [HttpGet()]
        public async Task<IActionResult> GetAllCustomers()
        {
            try
            {
                return Ok(await customerService.GetAllCustomers());
            }
            catch(Exception ex)
            {
                Log.Error($"Controller: Customers , Action: GetAllCustomers , Message: {ex.Message}");
                return StatusCode(500);
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        [HttpGet("GetAllCustomersWithAdress")]
        public async Task<IActionResult> GetAllCustomersWithAdress()
        {
            try
            {
                return Ok(await customerService.GetAllWithAddress());
            }
            catch (Exception ex)
            {
                Log.Error($"Controller: Customers , Action: GetAllCustomersWithAdress , Message: {ex.Message}");
                return StatusCode(500);
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        // GET api/<CustomersController>/getById/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCustomerById([FromRoute] int id)
        {
            try
            {
                return Ok(await customerService.GetCustomerById(id));
            }
            catch (Exception ex)
            {
                Log.Error($"Controller: Customers , Action: GetCustomerById , Message: {ex.Message}");
                return StatusCode(500);
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        [HttpGet("findByCode/{code}")]
        public async Task<IActionResult> FindCustomerByCode([FromRoute] string code)
        {
            try
            {
                return Ok(await customerService.FindCustomerByCode(code));
            }
            catch (Exception ex)
            {
                Log.Error($"Controller: Customers , Action: GetCustomerById , Message: {ex.Message}");
                return StatusCode(500);
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        // POST api/<CustomersController>/create
        [HttpPost()]
        public async Task<IActionResult> CreateCustomer([FromBody] Customer customer)
        {
            try
            {
                return Ok(await customerService.AddCustomer(customer));
            }
            catch (Exception ex)
            {
                Log.Error($"Controller: Customers , Action: CreateCustomer , Message: {ex.Message}");
                return StatusCode(500);
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        // PUT api/<CustomersController>/update/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpadteCustomer([FromRoute] int id, [FromBody] Customer customer)
        {
            try
            {
                if(id != customer.CustomerID)
                {
                    return BadRequest();
                }
                return Ok(await customerService.UpdateCustomer(customer));
            }
            catch (Exception ex)
            {
                Log.Error($"Controller: Customers , Action: UpadteCustomer , Message: {ex.Message}");
                return StatusCode(500);
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        // PUT api/<CustomersController>/changeActivation
        [HttpPut("changeActivation/{id}")]
        public async Task<IActionResult> ChangeCustomerActivation([FromRoute] int id, [FromBody] Customer customer)
        {
            try
            {
                if (id != customer.CustomerID)
                    return BadRequest();
                return Ok(await customerService.ChangeCustomerActivation(customer));
            }
            catch (Exception ex)
            {
                Log.Error($"Controller: Customers , Action: ChangeCustomerActivation , Message: {ex.Message}");
                return StatusCode(500);
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }


        // DELETE api/<CustomersController>/delete/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            try
            {
                return Ok(await customerService.DeleteCustomer(id));
            }
            catch (Exception ex)
            {
                Log.Error($"Controller: Customers , Action: Delete , Message: {ex.Message}");
                return StatusCode(500);
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }
    }
}
