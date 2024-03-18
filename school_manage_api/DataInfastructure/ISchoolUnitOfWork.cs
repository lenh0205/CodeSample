using DataInfastructure.Interface;
using System;

namespace DataInfastructure
{
    public interface ISchoolUnitOfWork : IDisposable
    {
        public IClassRepository ClassRepository { get; }
        public IRoleRepository RoleRepository { get; }
        public ISchoolRepository SchoolRepository { get; }
        public IStudentRepository StudentRepository { get; }
        public ITeacherClassMappingRepository TeacherClassMappingRepository { get; }
        public ITeacherRepository TeacherRepository { get; }
        public IUserRepository UserRepository { get; }
        public IUserRoleMappingRepository UserRoleMappingRepository { get; }

        public int Save();
    }
}
