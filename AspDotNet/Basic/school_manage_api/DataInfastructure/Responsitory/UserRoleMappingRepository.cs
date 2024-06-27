using DataInfastructure.Model;
using System.Collections.Generic;
using System.Linq;
using System;
using DataInfastructure.Interface;

namespace DataInfastructure.Responsitory
{
    public class UserRoleMappingRepository : RepositoryBase<UserRoleMapping>, IUserRoleMappingRepository
    {
        private readonly SchoolDBContext _context;
        public UserRoleMappingRepository(SchoolDBContext context): base(context)
        {
            _context = context;
        }
    }
}
