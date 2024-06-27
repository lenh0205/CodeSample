namespace Common.ViewModel
{
    public class ResponseItems<T>
    {
        public int TotalPages { get; set; }
        public IEnumerable<T> ClassList { get; set; }
    }
}
