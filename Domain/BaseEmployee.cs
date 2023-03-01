using EmployeeManagerAPI.Exceptions;
using static EmployeeManagerAPI.Constants;

namespace EmployeeManagerAPI.Domain;

public abstract class BaseEmployee : IEmployee
{
    public Guid Id { get; }
    public string FirstName { get; }
    public string LastName { get; }
    public abstract EmployeeType EmployeeType { get; }
    protected abstract decimal VacationDaysAccumulable { get; }
    public decimal VacationDaysAccumulated { get; private set; }
    private decimal VacationAccrualRate => VacationDaysAccumulable / MAXIMUM_ANNUAL_WORK_DAYS;

    protected BaseEmployee(Guid id, string firstName, string lastName)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
    }

    public void Work(int daysWorked)
    {
        if (daysWorked < MINIMUM_ANNUAL_WORK_DAYS || daysWorked > MAXIMUM_ANNUAL_WORK_DAYS)
        {
            throw new DaysWorkedOutOfRangeException();
        }

        VacationDaysAccumulated = decimal.Round(daysWorked * VacationAccrualRate, 2, MidpointRounding.ToZero);
    }

    public void TakeVacation(decimal vacationDaysUsed)
    {
        vacationDaysUsed = decimal.Round(vacationDaysUsed, 2, MidpointRounding.ToZero);

        if (vacationDaysUsed > VacationDaysAccumulated)
        {
            throw new VacationDaysUsedExceedsAccumulatedException(vacationDaysUsed, VacationDaysAccumulated);
        }

        VacationDaysAccumulated -= vacationDaysUsed;
    }
}