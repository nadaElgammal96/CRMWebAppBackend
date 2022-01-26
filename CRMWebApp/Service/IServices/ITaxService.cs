using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.IServices
{
    public interface ITaxService
    {
        Task<Tax> AddTax(Tax tax);
        Task<Tax> UpdateTax(Tax tax);
        Task<IEnumerable<Tax>> GetAllTaxs();
        Task<Tax> GetTaxById(int id);
        Task<Tax> DeleteTaxt(int id);
    }
}
