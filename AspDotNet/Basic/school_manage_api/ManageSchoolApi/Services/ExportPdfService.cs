using DataInfastructure;
using DataInfastructure.Model;
using iTextSharp.text;
using iTextSharp.text.pdf;
using ManageSchoolApi.Services.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace ManageSchoolApi.Services
{
    public class ExportPdfService : IExportPdfService
    {
        ISchoolUnitOfWork _unitOfWork;
        public ExportPdfService (ISchoolUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// ExportPdfClassList
        /// </summary>
        /// <returns>byte[]</returns>
        public async Task<byte[]> ExportPdfClassList()
        {
            // Get the class data from the database
            //var classes = await _context.Classes.ToListAsync();
            List<Class> classes = await _unitOfWork.ClassRepository.GetAll();

            // Create a new PDF document
            var document = new Document();
            var memoryStream = new MemoryStream();
            var writer = PdfWriter.GetInstance(document, memoryStream);

            // Add content to the PDF document
            document.Open();
            var table = new PdfPTable(2);
            table.AddCell("Name");
            table.AddCell("Description");
            foreach (var cls in classes)
            {
                table.AddCell(cls.Name);
                table.AddCell(cls.Description);
            }
            document.Add(table);
            document.Close();

         
            // Return the PDF file as a byte array to the client
            return memoryStream.ToArray();
        }
    }
}
