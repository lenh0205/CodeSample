namespace LenhASP.Domain.Entities
{
    public class Student : BaseEntity
    {
        public string? Name { get; set; } = string.Empty;
        public int Age { get; set; }
    }
}
