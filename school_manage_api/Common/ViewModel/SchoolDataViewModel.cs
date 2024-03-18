using System.Security.Claims;

namespace Common.ViewModel
{
    public class SchoolDataViewModel
    {
        public string SchoolName { get; set; }
        public ResponseItems<ClassViewModel> Classes { get; set; } 
    }
}
