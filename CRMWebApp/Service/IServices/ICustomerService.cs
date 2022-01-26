using Domain.Entities;
using Service.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.IServices
{
    public interface ICustomerService
    {
        Task<Customer> AddCustomer(Customer customer);
        Task<Customer> UpdateCustomer(Customer customer);
        Task<Customer> ChangeCustomerActivation(Customer customer);
        Task<IEnumerable<Customer>> GetAllCustomers();
        Task<CustomerDto> GetCustomerById(int id);
        Task<CustomerDto> FindCustomerByCode(string code);
        Task<Customer> DeleteCustomer(int id);
        Task<IEnumerable<CustomerDto>> GetAllWithAddress();
    }
}
