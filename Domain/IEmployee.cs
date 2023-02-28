namespace EmployeeManagerAPI.Domain;
public interface IEmployee
{
    Guid Id { get; init; }
    string FirstName { get; init; }
    string LastName { get; init; }
    EmployeeType EmployeeType { get; }
    decimal DaysWorked { get; }
    decimal VacationDaysAccumulated { get; }
    void TakeVacation(decimal vacationDaysUsed);
    void Work(int daysWorked);
}