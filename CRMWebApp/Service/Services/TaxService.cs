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
    public class TaxService : ITaxService
    {
        private ITaxRepository taxRepository { get; }
        public TaxService(ITaxRepository _taxRepository)
        {
            taxRepository = _taxRepository;
        }
        public async Task<Tax> AddTax(Tax tax)
        {
            return await taxRepository.Add(tax);
        }

        public async Task<Tax> DeleteTaxt(int id)
        {
            return await taxRepository.Delete(id);
        }

        public async Task<IEnumerable<Tax>> GetAllTaxs()
        {
            return await taxRepository.GetAll().ToListAsync();
        }

        public async Task<Tax> GetTaxById(int id)
        {
            return await taxRepository.GetById(id);
        }

        public async Task<Tax> UpdateTax(Tax tax)
        {
            return await taxRepository.Update(tax);
        }
    }
}
