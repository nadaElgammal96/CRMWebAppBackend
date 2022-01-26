using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Repository.IRepositories;
using Service.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class CustomerAddressService : ICustomerAddressService
    {
        private ICustomerAddressRepository customerAddressRepository { get; }
        public CustomerAddressService(ICustomerAddressRepository _customerAddressRepository)
        {
            customerAddressRepository = _customerAddressRepository;
        }
        public async Task<CustomerAddress> AddCustomerAddress(CustomerAddress customerAddress)
        {
            return await customerAddressRepository.Add(customerAddress);
        }

        public async Task<CustomerAddress> DeleteCustomerAddress(int id)
        {
            return await customerAddressRepository.Delete(id);
        }

        public async Task<IEnumerable<CustomerAddress>> GetAllCustomerAddress()
        {
            return await customerAddressRepository.GetAll().ToListAsync();
        }

        public async Task<CustomerAddress> GetCustomerAddressById(int id)
        {
            return await customerAddressRepository.GetById(id);
        }

        public async Task<CustomerAddress> UpdateCustomerAddress(CustomerAddress customerAddress)
        {
            return await customerAddressRepository.Update(customerAddress);
        }

        public async Task<IEnumerable<CustomerAddress>> FindCustomerShippingAddress(int id)
        {
            return await customerAddressRepository.GetAll().Where(a => a.CustomerID == id && a.ShippingAddress).ToListAsync();
        }

        public async Task<IEnumerable<CustomerAddress>> FindCustomerBillingAddress(int id)
        {
            return await customerAddressRepository.GetAll().Where(a => a.CustomerID == id && a.BillingAddress).ToListAsync();
        }
    }
}
