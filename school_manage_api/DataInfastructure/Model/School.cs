using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataInfastructure.Model
{
    public class School : BaseEntity
    {
        public virtual ICollection<Class> Classes { get; set; }
    }
}
