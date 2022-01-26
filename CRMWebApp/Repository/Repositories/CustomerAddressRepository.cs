using Domain.Entities;
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
    public class CustomerAddressRepository: GenericRepository<CustomerAddress> , ICustomerAddressRepository
    {
        public CustomerAddressRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
