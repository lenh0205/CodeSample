using DataInfastructure.Model;
using System.Collections.Generic;
using System.Linq;
using System;
using DataInfastructure.Interface;

namespace DataInfastructure.Responsitory
{
    public class TeacherRepository : RepositoryBase<Teacher> ,ITeacherRepository
    {
        private readonly SchoolDBContext _context;
        public TeacherRepository(SchoolDBContext context) : base(context)
        {
            _context = context;
        }
    }
}
