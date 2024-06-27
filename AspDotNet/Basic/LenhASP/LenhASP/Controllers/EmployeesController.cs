using LenhASP.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace LenhASP.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private List<Employee> EmployeeData()
        {
            return new List<Employee>()
            {
                new Employee(){ Id=1, Name = "Employee 1", Email = "employee1@nitishkaushik.com"},
                new Employee(){ Id=2, Name = "Employee 2", Email = "employee2@nitishkaushik.com"},
                new Employee(){ Id=3, Name = "Employee 3", Email = "employee3@nitishkaushik.com"},
                new Employee(){ Id=4, Name = "Employee 4", Email = "employee4@nitishkaushik.com"},
                new Employee(){ Id=5, Name = "Employee 5", Email = "employee5@nitishkaushik.com"}
            };
        }

        //[HttpGet]
        //public IActionResult GetEmployees()
        //{
        //    var employees = EmployeeData();
        //    return Ok(employees);
        //}

        //[HttpPost]
        //public IActionResult AddEmployee([FromBody] Employee model)
        //{
        //    // code to add new employee here  
        //    // int id = call to service.  
        //    return Created("~api/employees/1", model);
        //}

        //[HttpGet("{id}")]
        //public IActionResult GetEmployeeByIdAction([FromRoute] int id)
        //{
        //    var employee = EmployeeData().Where(x => x.Id == id).FirstOrDefault();
        //    return Ok(employee);
        //}
        //[HttpPost]
        //public IActionResult AddEmployeeAction([FromBody] Employee model)
        //{
        //    // code to add new employee here  
        //    int newEmployeeId = 1; // get this id from database.  
        //    return CreatedAtAction("GetEmployeeByIdAction", new { id = newEmployeeId }, model);
        //}

        //[HttpGet]
        //[Route("{id}", Name = "getEmployeeRoute")]
        //public IActionResult GetEmployeeByIdRoute([FromRoute] int id)
        //{
        //    var employee = EmployeeData().Where(x => x.Id == id).FirstOrDefault();
        //    return Ok(employee);
        //}
        //[HttpPost]
        //public IActionResult AddEmployeeRoute([FromBody] Employee model)
        //{
        //    // code to add new employee here    
        //    int newEmployeeId = 1; // get this id from database.    
        //    return CreatedAtRoute("getEmployeeRoute", new { id = newEmployeeId }, model);
        //}

        //[HttpPost("")]
        //public IActionResult AddEmployeeBadRequest([FromBody] Employee model)
        //{
        //    // code goes here  
        //    return BadRequest();  // returns 400 status code  
        //}

        //[HttpGet]
        //[Route("{id}", Name = "getEmployeeRoute")]
        //public IActionResult GetEmployeeById([FromRoute] int id)
        //{
        //    var employee = EmployeeData().Where(x => x.Id == id).FirstOrDefault();
        //    if (employee == null)
        //    {
        //        return NotFound();
        //    }
        //    return Ok(employee);
        //}
    }
}
