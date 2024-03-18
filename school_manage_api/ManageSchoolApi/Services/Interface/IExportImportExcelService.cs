using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace ManageSchoolApi.Services.Interface
{
    public interface IExportImportExcelService
    {
        public Task<byte[]> ExportExcel();
        public Task<byte[]> ImportExcel(IFormFile file);
    }
}
