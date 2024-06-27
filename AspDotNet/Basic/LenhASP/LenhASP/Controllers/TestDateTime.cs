using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LenhASP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestDateTime : ControllerBase
    {
        [HttpGet]
        public IActionResult DateTimeParseExact()
        {
            try
            {
                CultureInfo provider = CultureInfo.InvariantCulture;
                var dateString = "10-22-2015";
                DateTime dateTime = DateTime.ParseExact(dateString, "MM-dd-yyyy", provider);
                return Ok(dateTime.ToString());
            }
            catch (Exception ex)
            {
                return Ok(ex.Message);
            }
        }
    }
}
