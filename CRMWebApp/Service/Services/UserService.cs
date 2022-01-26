using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Repository.IRepositories;
using Service.DTO;
using Service.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class UserService : IUserService
    {
        private IUserRepository userRepository { get; }
        public UserService(IUserRepository _userRepository)
        {
            userRepository = _userRepository;
        }
        public async Task<User> AddUser(User user)
        {
            return await userRepository.Add(user);
        }

        public async Task<User> ChangeUserActivation(User user)
        {
            user.Active = !user.Active;
            return await userRepository.Update(user);
        }

        public async Task<User> UpdateUser(User user)
        {
            return await userRepository.Update(user);
        }

        public async Task<IEnumerable<UserDto>> GetAllUsers()
        {
            return await userRepository.GetAll().Select( u => new UserDto {
            UserID = u.UserID,
            FirstName = u.FirstName,
            LastName = u.LastName,
            EmailAddress = u.EmailAddress,
            PrimaryPhoneNumber = u.PrimaryPhoneNumber,
            Active = u.Active
            }).ToListAsync();
        }


        public async Task<User> GetUserById(int id)
        {
            return await userRepository.GetById(id);
        }

        public async Task<User> DeleteUser(int id)
        {
            return await userRepository.Delete(id);
        }

        public async Task<User> Login(UserLoginDto user)
        {
            return await userRepository.GetAll()
                .FirstOrDefaultAsync(u => u.Password == user.Password && u.EmailAddress == user.EmailAddress);
        }
    }
}
