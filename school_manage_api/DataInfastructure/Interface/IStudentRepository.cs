using DataInfastructure.Model;
using System.Collections.Generic;
using System;

namespace DataInfastructure.Interface
{
    public interface IStudentRepository : IRepositoryBase<Student>
    {
        public void UpdateMoniter();
    }
}
