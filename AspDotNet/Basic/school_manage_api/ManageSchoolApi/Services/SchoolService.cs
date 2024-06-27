using Common.ViewModel;
using DataInfastructure;
using DataInfastructure.Model;
using DataInfastructure.Responsitory;
using ManageSchoolApi.Realtime;
using ManageSchoolApi.Services.Interface;
using ManageSchoolApi.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace ManageSchoolApi.Services
{
    public class SchoolService : ISchoolService
    {
        ISchoolUnitOfWork _unitOfWork;
        private readonly IHubContext<ClassHub> _classHubContext;

        public SchoolService(ISchoolUnitOfWork schoolUnitOfWork, IHubContext<ClassHub> classHubContext)
        {
            _unitOfWork = schoolUnitOfWork;
            _classHubContext = classHubContext;
        }

        //public async Task<ResponseItems<Class>> CreateClass(Class c)
        //{
        //    _unitOfWork.ClassRepository.Add(c);
        //    int result = _unitOfWork.Save();

        //    if (result > 0)
        //    {
        //        // Send a SignalR message to all connected clients
        //        await _classHubContext.Clients.All.SendAsync("onCreatedClass", finalClassAndPage);
        //    }



        //    ResponseItems<Class> finalClassAndPage = _unitOfWork.ClassRepository.GetFinalClassAndPage();
        //    return finalClassAndPage;
        //}

        public async Task<bool> Delete(Guid id)
        {
            _unitOfWork.ClassRepository.Delete(id);
            int result = _unitOfWork.Save();
            return result > 0 ? true : false;
        }

        public async Task<List<Class>> GetClassWithListId(List<Guid> ids)
        {
            List<Class> classes = await _unitOfWork.ClassRepository.GetByIds(ids);
            return classes;
        }

        public async Task<Class> GetOneClass(Guid id)
        {
            Class c = _unitOfWork.ClassRepository.GetById(id);
            return c;
        }

        public async Task<ResponseItems<Class>> GetWithPagination(string page)
        {
            ResponseItems<Class> allClassAndPage = await _unitOfWork.ClassRepository.GetWithPagination(page);
            return allClassAndPage;
        }

        public async Task<Class> UpdateCurrentClass(Guid id, Class c)
        {
            _unitOfWork.ClassRepository.Update(id, c);
            int result = _unitOfWork.Save();
            return c;
        }

        public Task<bool> UploadFile(IFormFile file)
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseItems<Class>> GetWithPagination(FilterBase filter)
        {
            ResponseItems<Class> allClassAndPage = await _unitOfWork.ClassRepository.GetWithPagination(filter);
            return allClassAndPage;
        }

       public async Task<SchoolDataViewModel> GetAllPaging(FilterSchool filter)
        {
            var schools = _unitOfWork.SchoolRepository.GetReponsitory();
            var classes = _unitOfWork.ClassRepository.GetReponsitory();
            var students = _unitOfWork.StudentRepository.GetReponsitory();

            IQueryable<SchoolDataViewModel> query = from school in schools
                                                     join c in classes
                                                     on school.Id equals c.SchoolId
                                                     group c by school into schoolGroup
                                                     select new SchoolDataViewModel
                                                     {
                                                         SchoolName = schoolGroup.Key.Name,
                                                         Classes = new ResponseItems<ClassViewModel>
                                                         {
                                                             ClassList = schoolGroup.Select(x => new ClassViewModel
                                                             {
                                                                 MonitorName = x.Students.FirstOrDefault(x => x.IsClassMonitor) != null ? x.Students.FirstOrDefault(x => x.IsClassMonitor).Name : string.Empty,
                                                                 Name = x.Name,
                                                                 Students = x.Students.Select(student => new StudentViewModel
                                                                 {
                                                                     Name = student.Name,
                                                                     IsClassMonitor = student.IsClassMonitor,
                                                                      
                                                                 }) 
                                                             }),
                                                         }
                                                     };

            var result = await query.FirstOrDefaultAsync();

            return result;
        }
    }
}
