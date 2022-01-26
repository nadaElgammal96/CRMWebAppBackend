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
    public class ProductService : IProductService
    {
        private IProductRepository productRepository { get; }

        public ProductService(IProductRepository _productRepository)
        {
            productRepository = _productRepository;
        }

        public async Task<Product> AddProduct(Product product)
        {
            return await productRepository.Add(product);
        }

        public async Task<Product> DeleteProduct(int id)
        {
            return await productRepository.Delete(id);
        }

        public async Task<IEnumerable<ProductDto>> GetAllProducts()
        {
            return await productRepository.GetAll().Select(p => new ProductDto 
                                                        { ProductID = p.ProductID,
                                                          Code = p.Code,
                                                          Name = p.Name,
                                                          UnitPrice = p.UnitPrice}).ToListAsync() ;
        }

        public async Task<Product> GetProductById(int id)
        {
            return await productRepository.GetById(id);
        }

        public async Task<Product> UpdateProduct(Product product)
        {
            return await productRepository.Update(product);
        }

        public async Task<Product> FindProductByCode(string code)
        {
            return await productRepository.GetAll().FirstOrDefaultAsync(p => p.Code == code);
        }
    }
}
