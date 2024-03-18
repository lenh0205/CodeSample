using AutoMapper;
using LenhASP.Controllers.Base;
using LenhASP.Domain.Entities;
using LenhASP.Domain.Services;
using LenhASP.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace LenhASP.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class StudentController : GenericController<Guid, Student, ApplicationDbContext>
    {
        private readonly IMapper _mapper;
        public StudentController(IGenericService<Student, ApplicationDbContext> genericService, IMapper mapper) : base(genericService)
        {
            _mapper = mapper;
        }

        [HttpGet]
        public object TestAutoMapper()
        {
            try
            {
                var src = new Foo { Baz = 1 };
                var des = _mapper.Map<Foo, Bar>(src, opt => opt.Items["Idd"] = "Baz");

                return des;
            }
            catch (Exception ex)
            {
                return "Exception roi nha!!!";
            }
        }

        public class Bar 
        { 
            public int Id { get; set; }
        }

        public class Foo
        {
            public int Id { get; set; }
            public int Baz { get; set; }
            public Foo InnerFoo { get; set; }
        }
    }
}
