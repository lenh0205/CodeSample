using DataInfastructure;
using DataInfastructure.Model;
using ManageSchoolApi.Services.Interface;
using OfficeOpenXml;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace ManageSchoolApi.Services
{
    public class ExportImportExcelService : IExportImportExcelService
    {
        ISchoolUnitOfWork _unitOfWork;
        public ExportImportExcelService(ISchoolUnitOfWork unitOfWork) 
        { 
            _unitOfWork = unitOfWork;
        }
        public async Task<byte[]> ExportExcel()
        {
            // Get the class data from the database
            var classes = await _unitOfWork.ClassRepository.GetAll();

            // Create a new Excel workbook
            using var package = new ExcelPackage();
            var worksheet = package.Workbook.Worksheets.Add("Class_List");

            // Add headers to the worksheet
            worksheet.Cells[1, 1].Value = "Name";
            worksheet.Cells[1, 2].Value = "Description";

            // Add data to the worksheet
            var row = 2;
            foreach (var cls in classes)
            {
                worksheet.Cells[row, 1].Value = cls.Name;
                worksheet.Cells[row, 2].Value = cls.Description;
                row++;
            }

            // Convert the Excel workbook to a byte array
            var bytes = package.GetAsByteArray();
            return bytes;
        }

        public async Task<byte[]> ImportExcel(IFormFile file)
        {
            using var stream = new MemoryStream();
            await file.CopyToAsync(stream);
            using var package = new ExcelPackage(stream);

            var worksheet = package.Workbook.Worksheets.FirstOrDefault();
            if (worksheet == null)
            {
                //return BadRequest("Excel file does not contain any worksheet.");
            }

            var classes = new List<Class>();
            for (var row = 2; row <= worksheet.Dimension.Rows; row++)
            {
                var name = worksheet.Cells[row, 1].Value?.ToString();
                var description = worksheet.Cells[row, 2].Value?.ToString();
                if (!string.IsNullOrEmpty(name))
                {
                    var @class = new Class
                    {
                        Id = Guid.NewGuid(),
                        Name = name,
                        Description = description,
                        CreatedDate = DateTime.UtcNow,
                        UpdatedDate = DateTime.UtcNow,
                        CreatedByUserId = Guid.Empty,
                        UpdatedByUserId = Guid.Empty,
                    };
                    classes.Add(@class);
                }
            }

            await _unitOfWork.ClassRepository.AddList(classes);
            _unitOfWork.Save();

            return stream.ToArray();
        }
    }
}
