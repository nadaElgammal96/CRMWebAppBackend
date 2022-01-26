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
    public class OrderHeaderRepository: GenericRepository<OrderHeader> , IOrderHeaderRepository
    {
        public OrderHeaderRepository(IUnitOfWork _unitOfWork): base(_unitOfWork)
        {
        }
    }
}
