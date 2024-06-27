using DataInfastructure.Interface;
using DataInfastructure.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataInfastructure.Responsitory
{
    public class ClassRepository : RepositoryBase<Class>, IClassRepository
    {
        private readonly SchoolDBContext _context;
        public ClassRepository(SchoolDBContext context) : base(context) 
        {
            _context = context;
        }
    }
}
