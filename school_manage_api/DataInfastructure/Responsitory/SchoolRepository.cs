using DataInfastructure.Model;
using System.Collections.Generic;
using System.Linq;
using System;
using DataInfastructure.Interface;

namespace DataInfastructure.Responsitory
{
    public class SchoolRepository :  RepositoryBase<School>, ISchoolRepository
    {
        private readonly SchoolDBContext _context;
        public SchoolRepository(SchoolDBContext context) : base(context) 
        {
            _context = context;
        }
    }
}
