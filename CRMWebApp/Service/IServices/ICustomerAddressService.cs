using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.IServices
{
    public interface ICustomerAddressService
    {
        Task<CustomerAddress> AddCustomerAddress(CustomerAddress customerAddress);
        Task<CustomerAddress> UpdateCustomerAddress(CustomerAddress customerAddress);
        Task<IEnumerable<CustomerAddress>> GetAllCustomerAddress();
        Task<CustomerAddress> GetCustomerAddressById(int id);
        Task<CustomerAddress> DeleteCustomerAddress(int id);
        Task<IEnumerable<CustomerAddress>> FindCustomerShippingAddress(int id);
        Task<IEnumerable<CustomerAddress>> FindCustomerBillingAddress(int id);
    }
}
