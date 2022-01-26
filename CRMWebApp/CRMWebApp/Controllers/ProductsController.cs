using CRMWebApp.Helpers;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using Service.DTO;
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
    public class ProductsController : ControllerBase
    {
        private IProductService productService { get; }

        public ProductsController(IProductService _productService)
        {
            productService = _productService;
            new Logger();
        }

        // GET: api/<ProductsController>/getAll
        [HttpGet()]
        public async Task<IActionResult> GetAllProducts()
        {
            try
            {
                return Ok(await productService .GetAllProducts());
            }
            catch (Exception ex)
            {
                Log.Error($"Controller: Products , Action: GetAllProducts , Message: {ex.Message}");
                return StatusCode(500);
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        // GET api/<ProductsController>/getById/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            try
            {
                return Ok(await productService.GetProductById(id));
            }
            catch (Exception ex)
            {
                Log.Error($"Controller: Products , Action: GetById , Message: {ex.Message}");
                return StatusCode(500);
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        // POST api/<ProductsController>/create
        [HttpPost()]
        public async Task<IActionResult> CreateProduct([FromBody] Product product)
        {
            try
            {
                return Ok(await productService.AddProduct(product));
            }
            catch (Exception ex)
            {
                Log.Error($"Controller: Products , Action: CreateProduct , Message: {ex.Message}");
                return StatusCode(500);
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        // PUT api/<ProductsController>/update/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct( [FromRoute] int id, [FromBody] Product product)
        {
            try
            {
                if (id != product.ProductID)
                {
                    return BadRequest();
                }

                return Ok(await productService.UpdateProduct(product));
            }
            catch (Exception ex)
            {
                Log.Error($"Controller: Products , Action: UpdateProduct , Message: {ex.Message}");
                return StatusCode(500);
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        // DELETE api/<ProductsController>/delete/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            try
            {
                return Ok(await productService.DeleteProduct(id));
            }
            catch (Exception ex)
            {
                Log.Error($"Controller: Products , Action: DeleteProduct , Message: {ex.Message}");
                return StatusCode(500);
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        [HttpGet("findByCode/{code}")]
        public async Task<IActionResult> FindProductByCode([FromRoute] string code)
        {
            try
            {
                return Ok(await productService.FindProductByCode(code));
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
    }
}
