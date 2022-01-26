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
    public class OrderHeaderService : IOrderHeaderService
    {
        private IOrderHeaderRepository orderHeaderRepository { get; }

        public OrderHeaderService(IOrderHeaderRepository _orderHeaderRepository)
        {
            orderHeaderRepository = _orderHeaderRepository;
        }

        public async Task<OrderHeader> AddOrderHeader(OrderHeader orderHeader)
        {
            return await orderHeaderRepository.Add(orderHeader);
        }

        public async Task<OrderHeader> DeleteOrderHeader(int id)
        {
            return await orderHeaderRepository.Delete(id);
        }

        public async Task<IEnumerable<OrderHeader>> GetAllOrderHeaders()
        {
            return await orderHeaderRepository.GetAll().ToListAsync();
        }

        public async Task<OrderHeader> GetOrderHeaderById(int id)
        {
            return await orderHeaderRepository.GetById(id);
        }

        public async Task<OrderHeader> UpdateOrderHeader(OrderHeader orderHeader)
        {
            return await orderHeaderRepository.Update(orderHeader);
        }
    }
}
