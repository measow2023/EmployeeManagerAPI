using EmployeeManagerAPI.Models;

namespace EmployeeManagerAPI.Services;

public interface IEmployeeService
{
    IEnumerable<EmployeeResponseModel> GetAll();
    EmployeeResponseModel GetById(Guid id);
    EmployeeResponseModel Work(Guid employeeId, int daysWorked);
    EmployeeResponseModel TakeVacation(Guid employeeId, decimal vacationDaysUsed);
}