using DataInfastructure.Interface;
using DataInfastructure.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataInfastructure.Responsitory
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        private readonly SchoolDBContext _context;
        public UserRepository(SchoolDBContext context) : base(context)
        {
            _context = context;
        }
    }
}
