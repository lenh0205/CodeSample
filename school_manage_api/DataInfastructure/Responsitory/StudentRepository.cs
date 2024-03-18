using DataInfastructure.Model;
using System.Collections.Generic;
using System.Linq;
using System;
using DataInfastructure.Interface;

namespace DataInfastructure.Responsitory
{
    public class StudentRepository : RepositoryBase<Student>, IStudentRepository
    {
        private readonly SchoolDBContext _context;
        public StudentRepository(SchoolDBContext context) : base(context) 
        {
            _context = context;
        }

        public void UpdateMoniter()
        {
        }
    }
}
