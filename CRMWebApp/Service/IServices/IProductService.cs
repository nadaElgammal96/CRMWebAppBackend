using Domain.Entities;
using Service.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.IServices
{
    public interface IProductService
    {
        Task<Product> AddProduct(Product product);
        Task<Product> UpdateProduct(Product product);
        Task<IEnumerable<ProductDto>> GetAllProducts();
        Task<Product> GetProductById(int id);
        Task<Product> DeleteProduct(int id);

        Task<Product> FindProductByCode(string code);
    }
}
