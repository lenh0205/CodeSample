 using DataInfastructure.Interface;
using DataInfastructure.Responsitory;
using System;

namespace DataInfastructure
{
    public class SchoolUnitOfWork : ISchoolUnitOfWork
    {
        private SchoolDBContext _context;
        public SchoolUnitOfWork (SchoolDBContext context)
        {
            _context = context;
        }

        private IClassRepository _classRepository;
        public IClassRepository ClassRepository
        {
            get
            {

                if (this._classRepository == null)
                {
                    this._classRepository = new ClassRepository(_context);
                }
                return _classRepository;
            }
        }

        private IRoleRepository _roleRepository;
        public IRoleRepository RoleRepository
        {
            get
            {

                if (this._roleRepository == null)
                {
                    this._roleRepository = new RoleRepository(_context);
                }
                return _roleRepository;
            }
        }

        private ISchoolRepository _schoolRepository;
        public ISchoolRepository SchoolRepository
        {
            get
            {

                if (this._schoolRepository == null)
                {
                    this._schoolRepository = new SchoolRepository(_context);
                }
                return _schoolRepository;
            }
        }

        private IStudentRepository _studentRepository;
        public IStudentRepository StudentRepository
        {
            get
            {

                if (this._studentRepository == null)
                {
                    this._studentRepository = new StudentRepository(_context);
                }
                return _studentRepository;
            }
        }

        private ITeacherClassMappingRepository _teacherClassMappingRepository;
        public ITeacherClassMappingRepository TeacherClassMappingRepository
        {
            get
            {

                if (this._teacherClassMappingRepository == null)
                {
                    this._teacherClassMappingRepository = new TeacherClassMappingRepository(_context);
                }
                return _teacherClassMappingRepository;
            }
        }

        private ITeacherRepository _teacherRepository;
        public ITeacherRepository TeacherRepository
        {
            get
            {

                if (this._teacherRepository == null)
                {
                    this._teacherRepository = new TeacherRepository(_context);
                }
                return _teacherRepository;
            }
        }

        private IUserRepository _userRepository;
        public IUserRepository UserRepository
        {
            get
            {

                if (this._userRepository == null)
                {
                    this._userRepository = new UserRepository(_context);
                }
                return _userRepository;
            }
        }

        private IUserRoleMappingRepository _userRoleMappingRepository;
        public IUserRoleMappingRepository UserRoleMappingRepository
        {
            get
            {

                if (this._userRoleMappingRepository == null)
                {
                    this._userRoleMappingRepository = new UserRoleMappingRepository(_context);
                }
                return _userRoleMappingRepository;
            }
        }

        public int Save()
        {
            var result = _context.SaveChanges();
            return result;
        }

        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
