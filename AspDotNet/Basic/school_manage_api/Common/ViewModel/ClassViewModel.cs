namespace Common.ViewModel
{
    public class ClassViewModel : ViewModelBase
    {
        public Guid MonitorId { get; set; }
        public string MonitorName { get; set; }
        public IEnumerable<StudentViewModel> Students { get; set; }
    }
}
