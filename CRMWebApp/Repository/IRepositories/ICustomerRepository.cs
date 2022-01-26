using Domain.Entities;
using Repository.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.IRepositories
{
    public interface ICustomerRepository: IGenericRepository<Customer>
    {

        Task<Customer> ChangeCustomerActivation(Customer customer);

        IQueryable<Customer> GetAllWithAddress();
    }
}
