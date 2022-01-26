using Domain.Entities;
using Service.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.IServices
{
    public interface IOrderDetailService
    {
        Task<OrderDetail> AddOrderDetail(OrderDetail orderDetail);
        Task<OrderDetail> UpdateOrderDetail(OrderDetail orderDetail);
        Task<IEnumerable<OrderDetail>> GetAllOrderDetails();
        Task<OrderDetail> GetOrderDetailById(int id);
        Task<OrderDetail> DeleteOrderDetail(int id);
        Task<IEnumerable<OrderDetailDto>> GetAllWithTaxAndProduct(int headerId);
        Task<IEnumerable<OrderDetail>> AddByRange(IEnumerable<OrderDetail> orderDetails);


    }
}
