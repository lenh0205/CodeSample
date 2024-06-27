using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataInfastructure.Model
{
    public class Class : BaseEntity
    {
        [ForeignKey("School")]
        public Guid SchoolId { get; set; }
        public virtual School School { get; set; }

        public string Description { get; set; }
        public virtual ICollection<Student> Students { get; set; }
    }
}
