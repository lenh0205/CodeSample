using DataInfastructure.Model;
using System.Collections.Generic;
using System;
using DataInfastructure.Responsitory;
using System.Threading.Tasks;
using Common.ViewModel;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace DataInfastructure.Interface
{
    public interface IRepositoryBase<T> where T : BaseEntity
    {
        public T GetById(Guid id);
        public Task<List<T>> GetByIds(List<Guid> ids);
        public Task<ResponseItems<T>> GetWithPagination(string page);
        public Task<ResponseItems<T>> GetWithPagination(FilterBase filter);
        
        public Task<List<T>> GetAll();
        public Task<ResponseItems<T>> GetFinalClassAndPage();
        public Task<T> Add(T c);
        public Task<List<T>> AddList(List<T> cList);
        public Task<T> Update(Guid id, T c);
        public bool Delete(Guid id);
        public IQueryable<T> GetReponsitory();
    }
}
