using Common.ViewModel;
using DataInfastructure;
using DataInfastructure.Model;
using DataInfastructure.Responsitory;
using iTextSharp.text;
using iTextSharp.text.pdf;
using ManageSchoolApi.Realtime;
using ManageSchoolApi.Services.Interface;
using ManageSchoolApi.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;
using TestApi.Auth;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TestApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SchoolController : ControllerBase
    {
        private ISchoolUnitOfWork _unitOfWork;
        private IExportPdfService _exportPdfService;
        private IExportImportExcelService _exportimportExcelService;
        private ISchoolService _schoolService;

        public SchoolController(ISchoolUnitOfWork unitOfWork, IExportPdfService exportPdfService, IExportImportExcelService exportimportExcelService, ISchoolService schoolService)
        {
            _unitOfWork = unitOfWork;
            _exportPdfService = exportPdfService;
            _exportimportExcelService = exportimportExcelService;
            _schoolService = schoolService;
        }
        /// <summary>
        /// Post
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        [HttpPost("Class/GetItems")]
        [Authorize(Roles = UserRoles.User)]
        public async Task<IActionResult> GetClassWithListId([FromBody] List<Guid> ids)
        {
            List<Class> classes = await _schoolService.GetClassWithListId(ids);
            return Ok(classes);
        }

        /// <summary>
        /// Get
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("Class/GetItem/{id}")]
        public async Task<IActionResult> GetOneClass(Guid id)
        {
            try
            {
                Class c = await _schoolService.GetOneClass(id);

                if (c == null) return NotFound();
                return Ok(c);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        /// <summary>
        /// GetClasses
        /// </summary>
        /// <returns></returns>
        [HttpGet("Class/GetAll")]
        public async Task<IActionResult> GetWithPagination(string page)
        {
            try
            {
                ResponseItems<Class> allClassAndPage = await _schoolService.GetWithPagination(page);

                if (allClassAndPage.ClassList == null)
                    return NotFound(); // return HTTP 404 if no classes found
                return Ok(allClassAndPage); // return HTTP 200 with classes data
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message); // return HTTP 500 with error message
            }
        }

        [HttpPost("Class/GetAllClass")]
        public async Task<IActionResult> GetWithPagination(FilterBase filter)
        {
            try
            {
                ResponseItems<Class> allClassAndPage = await _schoolService.GetWithPagination(filter);

                if (allClassAndPage.ClassList == null)
                    return NotFound(); // return HTTP 404 if no classes found
                return Ok(allClassAndPage); // return HTTP 200 with classes data
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message); // return HTTP 500 with error message
            }
        }

        [HttpPost("Class/GetAll")]
        public async Task<IActionResult> GetAllPaging (FilterSchool filter)
        {
            try
            {
                SchoolDataViewModel schoolData = await _schoolService.GetAllPaging(filter);
                return Ok(schoolData); // return HTTP 200 with classes data
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message); // return HTTP 500 with error message
            }
        }

        [HttpPost("Class/Create")]
        //public async Task<IActionResult> CreateClass([FromBody] Class c)
        //{
        //    try
        //    {
        //        ResponseItems<Class> finalClassAndPage = await _schoolService.CreateClass(c);


        //        return Ok(c);
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }
        //}

        // PUT api/<SchoolController>/5
        [HttpPut("Class/Update/{id}")]
        public async Task<IActionResult> UpdateCurrentClass(Guid id, [FromBody] Class c)
        {
            try
            {
                Class newClass = await _schoolService.UpdateCurrentClass(id, c);
                return Ok(newClass);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // DELETE api/<SchoolController>/5
        [HttpDelete("Class/Delete/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                bool status = await _schoolService.Delete(id);
                return Ok(status);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("Class/Upload")]
        public async Task<IActionResult> UploadFile([FromForm] IFormFile file)
        {
            await _exportimportExcelService.ImportExcel(file);
            return Ok();
        }

        [HttpGet("Class/pdf-class-list")]
        public async Task<IActionResult> ExportPdfClassList()
        {
            // Set the content type and file name for the response
            HttpContext.Response.ContentType = "application/pdf";
            HttpContext.Response.Headers.Add("Content-Disposition", "attachment; filename=classlist.pdf");
            var file = await _exportPdfService.ExportPdfClassList();
            return new FileContentResult(file , "application/pdf");
        }

        [HttpGet("Class/excel-class-list")]
        public async Task<IActionResult> ExportExcelClassList()
        {
            

            // Set the content type and file name for the response
            HttpContext.Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            HttpContext.Response.Headers.Add("Content-Disposition", "attachment; filename=classlist.xlsx");
            //HttpContext.Response.Headers["Content-Disposition"] = "attachment; filename*=UTF-8''classlist.xlsx";

            var bytes = await _exportimportExcelService.ExportExcel();

            // Return the Excel file as a byte array to the client
            return new FileContentResult(bytes, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
        }
    }
}
