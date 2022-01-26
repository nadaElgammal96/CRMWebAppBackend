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
    public class OrderDetailRepository: GenericRepository<OrderDetail> , IOrderDetailRepository
    {
        private IUnitOfWork unitOfWork;
        public OrderDetailRepository(IUnitOfWork _unitOfWork) : base(_unitOfWork)
        {
            unitOfWork = _unitOfWork;
        }

        public IQueryable<OrderDetail> GetAllWithProductAndTax(int headerId)
        {
            return unitOfWork.Context.OrderDetails.Where(o => o.OrderHeaderID == headerId).Include(o => o.Product).Include(o => o.Tax);
        }

        public async Task<IEnumerable<OrderDetail>> AddByRange(IEnumerable<OrderDetail> orderDetails)
        {
            await unitOfWork.Context.AddRangeAsync(orderDetails);
            await unitOfWork.Commit();
            return orderDetails;

        }
    }
}
