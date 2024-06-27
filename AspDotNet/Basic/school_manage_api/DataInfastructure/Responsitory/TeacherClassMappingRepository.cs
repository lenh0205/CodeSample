using DataInfastructure.Model;
using System.Collections.Generic;
using System.Linq;
using System;
using DataInfastructure.Interface;

namespace DataInfastructure.Responsitory
{
    public class TeacherClassMappingRepository : RepositoryBase<TeacherClassMapping>, ITeacherClassMappingRepository
    {
        private readonly SchoolDBContext _context;
        public TeacherClassMappingRepository(SchoolDBContext context) : base(context)
        {
            _context = context;
        }
    }
}
