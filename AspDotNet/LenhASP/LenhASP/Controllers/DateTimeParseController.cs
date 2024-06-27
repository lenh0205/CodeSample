using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;

namespace LenhASP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DateTimeParseController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                string dateString = string.Empty;
                DateTime dateTime = DateTime.Parse(dateString);
                return Ok(dateTime.ToString());
            }
            catch (Exception ex)
            {
                return Ok(ex.Message);
            }
        }
    }
}
