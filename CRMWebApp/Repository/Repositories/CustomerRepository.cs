using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Repository.GenericRepository;
using Repository.IRepositories;
using Repository.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class CustomerRepository : GenericRepository<Customer>, ICustomerRepository
    {

        private IUnitOfWork unitOfWork { get; }
        public CustomerRepository(IUnitOfWork _unitOfWork) : base(_unitOfWork)
        {
            unitOfWork = _unitOfWork;
        }
        public async Task<Customer> ChangeCustomerActivation(Customer customer)
        {
            Customer customerToUpdate = await unitOfWork.Context.Customers.FindAsync(customer.CustomerID);
            customerToUpdate.Active = !customerToUpdate.Active;
            await unitOfWork.Commit();
            return customerToUpdate;
        }

        public IQueryable<Customer> GetAllWithAddress()
        {
            return unitOfWork.Context.Customers.Include(c => c.CustomerAddresses);
        }
    }
}
