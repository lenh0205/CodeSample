using AutoMapper;
using Microsoft.Extensions.Logging;
using static LenhASP.Controllers.StudentController;

namespace LenhASP.Infrastructure.MappingProfile
{
    public class MyProfile : Profile
    {
        public MyProfile()
        {
            CreateMap<Foo, Bar>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom((src, dest, destMember, context) => context.Items["Idd"]));
        }
    }
}
