using Exam.Repository.Interfaces;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Exam.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class, new()
    {
        protected readonly RepositoryDbContext _repositoryDbContext;

        public Repository(RepositoryDbContext repositoryDbContext)
        {
            _repositoryDbContext = repositoryDbContext;
        }

        public IQueryable<TEntity> GetAll()
        {
            try
            {
                return _repositoryDbContext.Set<TEntity>();
            }
            catch (Exception ex)
            {
                throw new Exception($"Couldn't retrieve entities: {ex.Message}");
            }
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException($"{nameof(AddAsync)} entity must not be null");
            }

            try
            {
                await _repositoryDbContext.AddAsync(entity);
                await _repositoryDbContext.SaveChangesAsync();

                return entity;
            }
            catch (Exception ex)
            {
                throw new Exception($"{nameof(entity)} could not be saved: {ex.Message}");
            }
        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException($"{nameof(AddAsync)} entity must not be null");
            }

            try
            {
                _repositoryDbContext.Update(entity);
                await _repositoryDbContext.SaveChangesAsync();

                return entity;
            }
            catch (Exception ex)
            {
                throw new Exception($"{nameof(entity)} could not be updated: {ex.Message}");
            }
        }

        public async Task<TEntity> DeleteAsync(int id)
        {
            var entity = _repositoryDbContext.Set<TEntity>().Find(id);
            if (entity == null)
            {
                throw new ArgumentNullException($"{nameof(DeleteAsync)} can't find entity");
            }

            try
            {
                _repositoryDbContext.Remove(entity);
                await _repositoryDbContext.SaveChangesAsync();

                return entity;
            }
            catch (Exception ex)
            {
                throw new Exception($"{nameof(entity)} could not be updated: {ex.Message}");
            }
        }
    }
}
