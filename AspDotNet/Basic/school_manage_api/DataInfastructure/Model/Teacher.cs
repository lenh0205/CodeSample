using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataInfastructure.Model
{
    public class Teacher : BaseEntity
    {
        [ForeignKey("Subject")]
        public Guid SubjectId { get; set; }
        public virtual Subject Subject { get; set; }
    }
}
