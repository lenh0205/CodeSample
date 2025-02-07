using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
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

            var result = string.Join(", ", str.Split(", ").Select((item, index) => index + 1 + ". " + item));
            return Ok(result);
        }

        [HttpGet]
        public IActionResult SapXepTheoTuoi()
        {
            var str = "Jason Puncheon, 26/06/1986; Jos Hooiveld, 22/04/1983; Kelvin Davis, 29/09/1976; Luke Shaw, 12/07/1995; Gaston Ramirez, 02/12/1990; Adam Lallana, 10/05/1988";

            var result = str
                .Split("; ")
                .Select(item =>
                {
                    var arr = item.Split(", ");
                    var age = DateTime.Now.Year - DateTime.ParseExact(arr[1], "dd/MM/yyyy", CultureInfo.InvariantCulture).Year;
                    return new string[] { arr[0], age.ToString() };
                })
                .OrderBy(item => Convert.ToInt64(item[1]))
                .Select(item => string.Join(", ", item));
            return Ok(string.Join("; ", result));
        }

        [HttpGet]
        public IActionResult TinhTongThoiGianTuGiayVaPhut()
        {
            var str = "4:12,2:43,3:51,4:29,3:24,3:14,4:46,3:25,4:52,3:27";
            var result1 = str.Split(",").Aggregate(0, (acc, curr) =>
            {
                var arr = curr.Split(":");
                return acc + Convert.ToInt32(arr[0]) * 60 + Convert.ToInt32(arr[1]);
            });

            var result2 = str.Split(',').Select(s => TimeSpan.Parse("0:" + s)).Aggregate((t1, t2) => t1 + t2);

            return Ok(result1 + "_____" + result2);
        }

        [HttpGet]
        public IActionResult LayTatCaToaDo(int x, int y)
        {
            var xRange = Enumerable.Range(0, x);
            var yRange = Enumerable.Range(0, y);
            var result = xRange.Aggregate(" ", (acc, curr) =>
            {
                var item = curr + "," + string.Join(" " + curr.ToString() + ",", yRange);
                return acc + item + " ";
            });
            return Ok(result);
        }

        [HttpGet]
        public IActionResult LayTungKhoangThoiGian()
        {
            var str = "00:45,01:32,02:18,03:01,03:44,04:31,05:19,06:01,06:47,07:35";
            var arr = str.Split(",");

            var result = arr.Select((item, index) =>
            {
                var currentTime = DateTime.ParseExact(item, "mm:ss", CultureInfo.InvariantCulture);
                var previousTime = DateTime.ParseExact(index == 0 ? "00:00" : arr[index - 1], "mm:ss", CultureInfo.InvariantCulture);
                var timeSpan = currentTime - previousTime;
                return timeSpan.TotalSeconds;
            });

            return Ok(string.Join(", ", result));
        }

        [HttpGet]
        public IActionResult TaoLaiDanhSach()
        {
            var str = "2,5,7-10,11,17-18";
            var result = str.Split(",").SelectMany(x => x.Split("-"));
            return Ok(string.Join(" ", result));
        }

        [HttpGet]
        public IActionResult Test()
        {
            var a = TimeSpan.Parse("0:4:12");
            return Ok(a);
        }
    }
}
