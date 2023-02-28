using EmployeeManagerAPI.Domain;

namespace EmployeeManagerAPI.Models;

public class EmployeeResponseModel
{
    public Guid Id { get; init; }
    public string FirstName { get; init; }
    public string LastName { get; init; }
    public EmployeeType EmployeeType { get; set; }
    public string WorkedDays { get; set; }
    public string VacationDaysAccumulated { get; set; }
}
