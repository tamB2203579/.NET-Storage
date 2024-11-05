using Microsoft.AspNetCore.Mvc;
using StaffsAPI.Data;

[Route("api/[controller]")]
[ApiController]
public class EmployeeController : ControllerBase
{
  private readonly IEmployeeRepository employeeRepository;
  public EmployeeController(IEmployeeRepository employeeRepository)
  {
    this.employeeRepository = employeeRepository;
  }

  [HttpGet]
  public async Task<ActionResult<List<Employee>>> GetEmployees()
  {
    try
    {
      return Ok(await employeeRepository.GetEmployees());
    }
    catch (Exception)
    {
      return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
    }
  }

  [HttpGet("{id:int}")]
  public async Task<ActionResult<Employee>> GetEmployee(int id)
  {
    try
    {
      var result = await employeeRepository.GetEmployee(id);
      if (result == null) return NotFound();
      return result;
    }
    catch (Exception)
    {
      return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
    }
  }

  [HttpPost]
  public async Task<ActionResult<Employee>> CreateEmployee(Employee employee)
  {
    try
    {
      if (employee == null)
      {
        return BadRequest();
      }
      var createdEmployee = await employeeRepository.AddEmployee(employee);
      return CreatedAtAction(nameof(GetEmployees), new { id = createdEmployee.EmployeeId }, createdEmployee);
    }
    catch (Exception)
    {
      return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
    }
  }

  [HttpPut("{id}")]
  public async Task<ActionResult<Employee>> UpdateEmployee(int id, Employee employee)
  {
    try
    {
      var employeeToUpdate = await employeeRepository.GetEmployee(id);
      if (employeeToUpdate == null)
        return NotFound($"Employee with Id = {id} not found");

      return await employeeRepository.UpdateEmployee(employee);
    }
    catch (Exception)
    {
      return StatusCode(StatusCodes.Status500InternalServerError, "Error updating data");
    }
  }

  [HttpDelete("{id:int}")]
  public async Task<ActionResult<Employee>> DeleteEmployee(int id)
  {
    try
    {
      var employeeToDelete = await employeeRepository.GetEmployee(id);
      if (employeeToDelete == null)
      {
        return NotFound($"Employee with Id = {id} not found");
      }
      return await employeeRepository.DeleteEmployee(id);
    }
    catch (Exception)
    {
      return StatusCode(StatusCodes.Status500InternalServerError, "Error deleting data");
    }
  }
}