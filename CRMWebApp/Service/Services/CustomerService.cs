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
    public class CustomerService : ICustomerService
    {
        private ICustomerRepository customerRepository { get; }

        public CustomerService(ICustomerRepository _customerRepository)
        {
            customerRepository = _customerRepository;
        }

        public async Task<Customer> AddCustomer(Customer customer)
        {
            return await customerRepository.Add(customer);
        }

        public async Task<Customer> ChangeCustomerActivation(Customer customer)
        {
            return await customerRepository.ChangeCustomerActivation(customer);
        }

        public async Task<Customer> DeleteCustomer(int id)
        {
            return await customerRepository.Delete(id);
        }

        public async Task<IEnumerable<Customer>> GetAllCustomers()
        {
            return await customerRepository.GetAll().ToListAsync();
        }

        public async Task<CustomerDto> GetCustomerById(int id)
        {
            //return await customerRepository.GetById(id);
            return await customerRepository.GetAllWithAddress()
                .Select(
                c => new CustomerDto
                {
                    CustomerID = c.CustomerID,
                    Code = c.Code,
                    FirstName = c.FirstName,
                    LastName = c.LastName,
                    EmailAddress = c.EmailAddress,
                    PrimaryPhoneNumber = c.PrimaryPhoneNumber,
                    OtherPhoneNumber = c.OtherPhoneNumber,
                    Active = c.Active,
                    CustomerAddresses = c.CustomerAddresses
                }
                ).FirstOrDefaultAsync(c => c.CustomerID == id);
        }

        public async Task<Customer> UpdateCustomer(Customer customer)
        {
            return await customerRepository.Update(customer);
        }

        public async Task<IEnumerable<CustomerDto>> GetAllWithAddress()
        {
            return await customerRepository.GetAllWithAddress().Select(
                c => new CustomerDto
                {
                    CustomerID = c.CustomerID,
                    Code = c.Code,
                    FirstName = c.FirstName,
                    LastName = c.LastName,
                    EmailAddress = c.EmailAddress,
                    PrimaryPhoneNumber = c.PrimaryPhoneNumber,
                    Active = c.Active,
                    CustomerAddresses = c.CustomerAddresses
                }
                ).ToListAsync();
        }

        public async Task<CustomerDto> FindCustomerByCode(string code)
        {
            return await customerRepository.GetAllWithAddress().Select(
                c => new CustomerDto
                {
                    CustomerID = c.CustomerID,
                    Code = c.Code,
                    FirstName = c.FirstName,
                    LastName = c.LastName,
                    EmailAddress = c.EmailAddress,
                    PrimaryPhoneNumber = c.PrimaryPhoneNumber,
                    Active = c.Active,
                    CustomerAddresses = c.CustomerAddresses
                }
                ).FirstOrDefaultAsync(c => c.Code == code);
        }
    }
}
