using Domain.Entities;
using Service.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.IServices
{
    public interface IUserService
    {
        Task<User> AddUser (User user);
        Task<User> UpdateUser (User user);
        Task<User> ChangeUserActivation (User user);
        Task<IEnumerable<UserDto>> GetAllUsers();
        Task<User> GetUserById(int id);
        Task<User> DeleteUser(int id);
        Task<User> Login(UserLoginDto user);
    }
}
