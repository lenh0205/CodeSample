using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataInfastructure.Model
{
    public class UserRoleMapping : BaseEntity
    {
        [ForeignKey("User")]
        public Guid UserId { get; set; }
        public virtual User User { get; set; }

        [ForeignKey("Role")]
        public Guid RoleId { get; set; }
        public virtual Role Role { get; set; }
    }
}
