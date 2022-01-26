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
    public class TaxesController : ControllerBase
    {
        private ITaxService taxService { get; }
        public TaxesController(ITaxService _taxService)
        {
            taxService = _taxService;
            new Logger();
        }

        // GET: api/<TaxesController>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                return Ok(await taxService.GetAllTaxs());
            }
            catch (Exception ex)
            {
                Log.Error($"Controller: Taxes , Action: GetAll , Message: {ex.Message}");
                return StatusCode(500);
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        // GET api/<TaxesController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTaxById([FromRoute] int id)
        {
            try
            {
                return Ok(await taxService.GetTaxById(id));
            }
            catch (Exception ex)
            {
                Log.Error($"Controller: Taxes , Action: GetTaxById , Message: {ex.Message}");
                return StatusCode(500);
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        // POST api/<TaxesController>
        [HttpPost]
        public async Task<IActionResult> CreateTax([FromBody] Tax tax)
        {
            try
            {
                return Ok(await taxService.AddTax(tax));
            }
            catch (Exception ex)
            {
                Log.Error($"Controller: Taxes , Action: CreateTax , Message: {ex.Message}");
                return StatusCode(500);
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        // PUT api/<TaxesController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpadteTax([FromRoute] int id, [FromBody] Tax tax)
        {
            try
            {
                if (id != tax.TaxID)
                {
                    return BadRequest();
                }
                return Ok(await taxService.UpdateTax(tax));
            }
            catch (Exception ex)
            {
                Log.Error($"Controller: Taxes , Action: UpadteTax , Message: {ex.Message}");
                return StatusCode(500);
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        // DELETE api/<TaxesController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            try
            {
                return Ok(await taxService.DeleteTaxt(id));
            }
            catch (Exception ex)
            {
                Log.Error($"Controller: Taxes , Action: Delete , Message: {ex.Message}");
                return StatusCode(500);
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }
    }
}
