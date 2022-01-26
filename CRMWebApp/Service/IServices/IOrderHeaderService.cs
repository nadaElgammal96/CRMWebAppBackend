using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.IServices
{
    public interface IOrderHeaderService
    {
        Task<OrderHeader> AddOrderHeader(OrderHeader orderHeader);
        Task<OrderHeader> UpdateOrderHeader(OrderHeader orderHeader);
        Task<IEnumerable<OrderHeader>> GetAllOrderHeaders();
        Task<OrderHeader> GetOrderHeaderById(int id);
        Task<OrderHeader> DeleteOrderHeader(int id);
    }
}
