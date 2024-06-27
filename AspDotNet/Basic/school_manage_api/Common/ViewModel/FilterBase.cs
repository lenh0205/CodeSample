namespace Common.ViewModel
{
    public class FilterBase    
    {
        public string Name { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; } = 3;
    }
}
