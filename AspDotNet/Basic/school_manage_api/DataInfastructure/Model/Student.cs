using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataInfastructure.Model
{
    public class Student : BaseEntity
    {
        [ForeignKey("Class")]
        public Guid ClassId { get; set; }
        public virtual Class Class { get; set; }

        public bool IsClassMonitor { get; set; }
    }
}
