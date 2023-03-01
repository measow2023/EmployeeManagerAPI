namespace EmployeeManagerAPI.Domain;
public interface IEmployee
{
    Guid Id { get; }
    string FirstName { get; }
    string LastName { get; }
    EmployeeType EmployeeType { get; }
    decimal VacationDaysAccumulated { get; }
    void TakeVacation(decimal vacationDaysUsed);
    void Work(int daysWorked);
}