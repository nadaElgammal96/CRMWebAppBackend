using Domain.Entities;
using Repository.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.IRepositories
{
    public interface IOrderHeaderRepository: IGenericRepository<OrderHeader>
    {
    }
}
