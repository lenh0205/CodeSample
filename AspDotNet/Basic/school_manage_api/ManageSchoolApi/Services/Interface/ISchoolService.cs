using Common.ViewModel;
using DataInfastructure.Model;
using DataInfastructure.Responsitory;
using ManageSchoolApi.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ManageSchoolApi.Services.Interface
{
    public interface ISchoolService
    {
        public Task<List<Class>> GetClassWithListId(List<Guid> ids);
        public Task<Class> GetOneClass(Guid id);
        public Task<ResponseItems<Class>> GetWithPagination(string page);
        public Task<ResponseItems<Class>> GetWithPagination(FilterBase filter);
        public Task<SchoolDataViewModel> GetAllPaging(FilterSchool filter);
        //public Task<ResponseItems<Class>> CreateClass(Class c);
        public Task<Class> UpdateCurrentClass(Guid id, Class c);
        public Task<bool> Delete(Guid id);
        public Task<bool> UploadFile([FromForm] IFormFile file);
    }
}
