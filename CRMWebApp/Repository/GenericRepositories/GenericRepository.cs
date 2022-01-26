using Repository.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.GenericRepository
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private IUnitOfWork unitOfWork { get; }

        public GenericRepository(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
        }

        public async Task<TEntity> Add(TEntity entity)
        {
            await unitOfWork.Context.Set<TEntity>().AddAsync(entity);
            await unitOfWork.Commit();
            return entity; 
        }

        public IQueryable<TEntity> GetAll()
        {
            return unitOfWork.Context.Set<TEntity>();
        }

        public async Task<TEntity> GetById(int id)
        {
            return await unitOfWork.Context.Set<TEntity>().FindAsync(id);
        }

        public async Task<TEntity> Delete(int id)
        {
            TEntity entity = await GetById(id);
            unitOfWork.Context.Set<TEntity>().Remove(entity);
            await unitOfWork.Commit();
            return entity;
        }

        public async Task<TEntity> Update(TEntity entity)
        {
            unitOfWork.Context.Update(entity);
            await unitOfWork.Commit();
            return entity;
        }
    }
}
