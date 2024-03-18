using LenhASP.Domain.SeedWork;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace LenhASP.Domain.Services
{
    public interface IGenericService<TEntity, TContext>
     where TEntity : class
     where TContext : DbContext
    {
        List<TEntity> GetList(Expression<Func<TEntity, bool>> filter = null!, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null!, string includeProperties = "", int PageIndex = 0, int PageSize = 0);
        TEntity GetByID(object id);
        void Insert(TEntity entity);
        void InsertRange(IEnumerable<TEntity> entities);
        void TryDelete(object id);
        void Update(TEntity entityToUpdate);
    }
    public class GenericService<TEntity, TContext> : IGenericService<TEntity, TContext>
        where TEntity : class
        where TContext : DbContext
    {
        internal ILogger _logger;
        internal IUnitOfWork<TEntity, TContext> _unitOfWork;
        public GenericService(ILogger<GenericService<TEntity, TContext>> logger, IUnitOfWork<TEntity, TContext> unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }
        public List<TEntity> GetList(Expression<Func<TEntity, bool>> filter = null!, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null!, string includeProperties = "", int PageIndex = 0, int PageSize = 0)
        {
            try
            {
                return _unitOfWork.Generic.GetList(filter, orderBy, includeProperties, PageIndex, PageSize);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, $"{nameof(GetList)} function error on {nameof(GenericService<TEntity, TContext>)}");
                throw;
            }
        }
        public TEntity GetByID(object id)
        {
            try
            {
                return _unitOfWork.Generic.GetByID(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, $"{nameof(GetByID)} function error on {nameof(GenericService<TEntity, TContext>)}");
                throw;
            }
        }
        public void Insert(TEntity entity)
        {
            try
            {
                _unitOfWork.Generic.Insert(entity);
                _unitOfWork.Commit();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, $"{nameof(Insert)} function error on {nameof(GenericService<TEntity, TContext>)}");
                throw;
            }
        }
        public void InsertRange(IEnumerable<TEntity> entitiesToDelete)
        {
            try
            {
                _unitOfWork.Generic.InsertRange(entitiesToDelete);
                _unitOfWork.Commit();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, $"{nameof(Insert)} function error on {nameof(GenericService<TEntity, TContext>)}");
                throw;
            }
        }
        public void TryDelete(object id)
        {
            try
            {
                _unitOfWork.Generic.TryDelete(id);
                _unitOfWork.Commit();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, $"{nameof(TryDelete)} function error on {nameof(GenericService<TEntity, TContext>)}");
                throw;
            }
        }
        public void Update(TEntity entityToUpdate)
        {
            try
            {
                _unitOfWork.Generic.Update(entityToUpdate);
                _unitOfWork.Commit();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, $"{nameof(Update)} function error on {nameof(GenericService<TEntity, TContext>)}");
                throw;
            }
        }

    }
}
