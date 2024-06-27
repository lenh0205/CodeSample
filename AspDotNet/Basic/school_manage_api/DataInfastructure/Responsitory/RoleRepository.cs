using DataInfastructure.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Collections.Generic;
using DataInfastructure.Interface;

namespace DataInfastructure.Responsitory
{
    public class RoleRepository : RepositoryBase<Role> ,IRoleRepository
    {
        private readonly SchoolDBContext _context;
        public RoleRepository(SchoolDBContext context) : base(context)
        {
            _context = context;
        }
    }
}
