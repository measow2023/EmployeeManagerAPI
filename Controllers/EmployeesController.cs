using EmployeeManagerAPI.Models;
using EmployeeManagerAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagerAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class EmployeesController : ControllerBase
{
    private readonly ILogger<EmployeesController> _logger;
    private readonly IEmployeeService _service;
    public EmployeesController(ILogger<EmployeesController> logger, IEmployeeService service)
    {
        _logger = logger;
        _service = service;
    }

    [HttpGet(Name = "Get All Employees")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<EmployeeResponseModel>))]
    public ActionResult<List<EmployeeResponseModel>> GetAll()
    {
        var employees = _service.GetAll();
        return Ok(employees);
    }

    [HttpGet("{id}", Name = "Get Employee by Id")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(EmployeeResponseModel))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<EmployeeResponseModel> GetById(string id)
    {
        var employee = _service.GetById(new Guid(id));
        return Ok(employee);
    }

    [HttpPost("{id}/work")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<EmployeeResponseModel> Work(Guid id, WorkRequestModel request)
    {
        var employeeModel = _service.Work(id, request.WorkedDays);
        return Ok(employeeModel);
    }

    [HttpPost("{id}/take-vacation")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<EmployeeResponseModel> TakeVacation(Guid id, TakeVacationRequestModel request)
    {
        var employeeModel = _service.TakeVacation(id, request.VacationDaysUsed);
        return Ok(employeeModel);
    }
}
