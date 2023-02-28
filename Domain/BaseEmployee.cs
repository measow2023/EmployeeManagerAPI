using EmployeeManagerAPI.Exceptions;
using static EmployeeManagerAPI.Constants;

namespace EmployeeManagerAPI.Domain;

public abstract class BaseEmployee : IEmployee
{
    public Guid Id { get; init; }
    public string FirstName { get; init; }
    public string LastName { get; init; }
    public abstract EmployeeType EmployeeType { get; }
    protected abstract decimal VacationDaysAccumulable { get; }
    public decimal VacationDaysAccumulated { get; private set; }
    public decimal DaysWorked { get; private set; }
    private decimal VacationAccrualRate
    {
        get
        {
            return VacationDaysAccumulable / MAXIMUM_ANNUAL_WORK_DAYS;
        }
    }

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

        DaysWorked = daysWorked;
        VacationDaysAccumulated = decimal.Round(DaysWorked * VacationAccrualRate, 2, MidpointRounding.ToZero);
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