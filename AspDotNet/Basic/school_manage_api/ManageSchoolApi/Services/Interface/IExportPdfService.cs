using System.Threading.Tasks;

namespace ManageSchoolApi.Services.Interface
{
    public interface IExportPdfService
    {
        public Task<byte[]> ExportPdfClassList();
    }
}
