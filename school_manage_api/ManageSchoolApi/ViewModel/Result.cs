using DataInfastructure.Model;
using iTextSharp.text;
using System.Collections.Generic;

namespace ManageSchoolApi.ViewModel
{
    public class Result<T> where T : BaseEntity 
    {
        public T Item { get; set; }
        public List<T> Items { get; set; }
        public bool Success { get; set; }
        public string ErrorMessage { get; set; }
    }
}
