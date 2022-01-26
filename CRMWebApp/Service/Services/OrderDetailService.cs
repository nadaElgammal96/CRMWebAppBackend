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
    public class OrderDetailService : IOrderDetailService
    {
        private IOrderDetailRepository orderDetailReository { get; }

        public OrderDetailService(IOrderDetailRepository _orderDetailReository)
        {
            orderDetailReository = _orderDetailReository;
        }

        public async Task<OrderDetail> AddOrderDetail(OrderDetail orderDetail)
        {
            return await orderDetailReository.Add(orderDetail);
        }

        public async Task<OrderDetail> DeleteOrderDetail(int id)
        {
            return await orderDetailReository.Delete(id);
        }

        public async Task<IEnumerable<OrderDetail>> GetAllOrderDetails()
        {
            return await orderDetailReository.GetAll().ToListAsync();
        }

        public async Task<OrderDetail> GetOrderDetailById(int id)
        {
            return await orderDetailReository.GetById(id);
        }

        public async Task<OrderDetail> UpdateOrderDetail(OrderDetail orderDetail)
        {
            return await orderDetailReository.Update(orderDetail);
        }

        public async Task<IEnumerable<OrderDetailDto>> GetAllWithTaxAndProduct(int headerId)
        {
            return await orderDetailReository.GetAllWithProductAndTax(headerId).Select(
                o => new OrderDetailDto
                {
                    OrderLineID = o.OrderLineID,
                    OrderHeaderID = o.OrderHeaderID,
                    OrderLineNumber = o.OrderLineNumber,
                    Product = o.Product,
                    ProductID = o.ProductID,
                    Tax = o.Tax,
                    TaxID = o.TaxID,
                    Subtotal = o.Subtotal,
                    Grandtotal = o.Grandtotal,
                    Quantity = o.Quantity
                }).ToListAsync();
        }


        public async Task<IEnumerable<OrderDetail>> AddByRange(IEnumerable<OrderDetail> orderDetails)
        {
            return await orderDetailReository.AddByRange(orderDetails);
        }
    }
}
