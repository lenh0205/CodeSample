using Microsoft.AspNetCore.Mvc;

namespace LenhASP.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PracticeLinqController : ControllerBase
    {
        [HttpGet]
        public IActionResult Map_Split_Join()
        {
            var str = "Davis, Clyne, Fonte, Hooiveld, Shaw, Davis, Schneiderlin, Cork, Lallana, Rodriguez, Lambert";
            var result = String.Join(", ", str.Split(", ").Select((item, index) => (index + 1) + ". " + item).ToArray());
            return Ok(result);
            // String.Join() có 2 overloading nên tham số thứ 2 ta có thể truyền "IEnumerable" hoặc "Array"
            // -> nếu truyền IEnumerable, thì nó sẽ dùng "StringBuilder" under the hood
            // -> còn truyền Array, ta sẽ có a heavily optimized implementation with "arrays" and "pointers"
        }

        [HttpGet]
        public IActionResult Map_Sort_DateTime()
        {
            var str = "Jason Puncheon, 26/06/1986; Jos Hooiveld, 22/04/1983; Kelvin Davis, 29/09/1976; Luke Shaw, 12/07/1995; Gaston Ramirez, 02/12/1990; Adam Lallana, 10/05/1988";
            var list = str.Split("; ").Select(item => {
                var childrenItems = item.Split(", ");
                var age = childrenItems[1];
                return new { Name = childrenItems[0], age }; 
            });
            return Ok("result");
        }
    }
}
