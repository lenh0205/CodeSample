using Microsoft.AspNetCore.Mvc;
using System.Globalization;

namespace LinqPractice.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class LinqController : Controller
    {
        [HttpGet]
        public IActionResult ThemSTT()
        {
            var str = "Davis, Clyne, Fonte, Hooiveld, Shaw, Davis, Schneiderlin, Cork, Lallana, Rodriguez, Lambert";

            var result = string.Join(", " , str.Split(", ").Select((item, index) => index + 1 + ". " + item));
            return Ok(result);
        }

        [HttpGet]
        public IActionResult SapXepTheoTuoi()
        {
            var str = "Jason Puncheon, 26/06/1986; Jos Hooiveld, 22/04/1983; Kelvin Davis, 29/09/1976; Luke Shaw, 12/07/1995; Gaston Ramirez, 02/12/1990; Adam Lallana, 10/05/1988";

            CultureInfo provider = CultureInfo.InvariantCulture;
            var result = str
                .Split("; ")
                .Select(item => {
                    var arr = item.Split(", ");
                    var age = DateTime.Now.Year - DateTime.ParseExact(arr[1], "dd/MM/yyyy", provider).Year;
                    return new string[] { arr[0], age.ToString() }; 
                })
                .OrderBy(item => Convert.ToInt64(item[1]))
                .Select(item  => string.Join(", ",item));
            return Ok(string.Join("; ", result));
        }

        [HttpGet]
        public IActionResult TinhTongThoiGianTuGiayVaPhut()
        {
            var str = "4:12,2:43,3:51,4:29,3:24,3:14,4:46,3:25,4:52,3:27";
            var result = str.Split(",").Aggregate(0, (acc, curr) =>
            {
                var arr = curr.Split(":");
                return acc + Convert.ToInt32(arr[0]) * 60 + Convert.ToInt32(arr[1]);
            });
            return Ok(result);
        }
    }
}
