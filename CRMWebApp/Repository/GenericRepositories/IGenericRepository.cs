using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.GenericRepository
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        IQueryable<TEntity> GetAll();

        Task<TEntity> Add(TEntity entity);

        Task<TEntity> GetById(int id);

        Task<TEntity> Delete(int id);
        Task<TEntity> Update(TEntity entity);
    }
}
