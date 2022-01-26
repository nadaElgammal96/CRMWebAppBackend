using CRMWebApp.Helpers;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using Service.DTO;
using Service.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace CRMWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : Controller
    {
        private IUserService userService { get; }

        public UsersController(IUserService _userService)
        {
            userService = _userService;
            new Logger();
        }

        // GET api/<ProductsController>/getAll
        [HttpGet()]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                return Ok(await userService.GetAllUsers());
            }
            catch (Exception ex) 
            { 
                Log.Error($"Controller: Users , Action: GetAll , Message: {ex.Message}"); return StatusCode(500);
            }
            finally 
            { 
                Log.CloseAndFlush();
            }
        }

        // GET api/<ProductsController>/getById/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            try
            {
                return Ok(await userService.GetUserById(id));
            }
            catch (Exception ex)
            {
                Log.Error($"Controller: Users , Action: GetUserById , Message: {ex.Message}");
                return StatusCode(500);
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        // POST api/<ProductsController>/create
        [HttpPost()]
        public async Task<IActionResult> CreateUser(User user)
        {
            try
            {

                return Ok(await userService.AddUser(user));
            }
            catch (Exception ex)
            {
                Log.Error($"Controller: Users , Action: CreateUser , Message: {ex.Message}");
                return StatusCode(500);
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }


        // PUT api/<ProductsController>/update/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpadteUser([FromRoute] int id, [FromBody] User user)
        {
            try
            {
                if(id != user.UserID)
                {
                    return BadRequest();
                }
                return Ok(await userService.UpdateUser(user));
            }
            catch (Exception ex)
            {
                Log.Error($"Controller: Users , Action: UpadteUser , Message: {ex.Message}");
                return StatusCode(500);
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }


        // PUT api/<ProductsController>/changeActivation/5
        [HttpPut("changeActivation/{id}")]
        public async Task<IActionResult> ChangeUserActivation( [FromRoute] int id, [FromBody] User user)
        {
            try
            {
                if (id != user.UserID)
                    return BadRequest();
                return Ok(await userService.ChangeUserActivation(user));
            }
            catch (Exception ex)
            {
                Log.Error($"Controller: Users , Action: ChangeUserActivation , Message: {ex.Message}");
                return StatusCode(500);
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        // DELETE api/<ProductsController>/delete/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                return Ok(await userService.DeleteUser(id));
            }
            catch (Exception ex)
            {
                Log.Error($"Controller: Users , Action: Delete , Message: {ex.Message}");
                return StatusCode(500);
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        // GET api/<ProductsController>/login
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserLoginDto user)
        {
            try
            {
                return Ok(await userService.Login(user));
            }
            catch (Exception ex)
            {
                Log.Error($"Controller: Users , Action: Login , Message: {ex.Message}");
                return StatusCode(500);
            }
            finally
            {
                Log.CloseAndFlush();
            }

        }
    }
}
