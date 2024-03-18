namespace LenhASP.Domain.Entities
{
    public class BaseEntity
    {
        public Guid Id { get; set; }

        public int CreatedUserId { get; set; }

        public DateTime? CreatedDate { get; set; } = DateTime.Now;

        public int UpdatedUserId { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public bool IsDeleted { get; set; } = false;
    }
}
