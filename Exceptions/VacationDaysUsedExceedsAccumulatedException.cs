namespace EmployeeManagerAPI.Exceptions;
public class VacationDaysUsedExceedsAccumulatedException : DomainBaseException
{
    public VacationDaysUsedExceedsAccumulatedException()
    {
    }

    public VacationDaysUsedExceedsAccumulatedException(string message) : base(message)
    {
    }

    public VacationDaysUsedExceedsAccumulatedException(string message, Exception innerException) : base(message, innerException)
    {
    }

    public VacationDaysUsedExceedsAccumulatedException(
        decimal vacationDaysUsed,
        decimal vacationDaysAccumulated)
        : this($"{vacationDaysUsed} exceeds the number of vacation days accumulated ({vacationDaysAccumulated}).")
    {
    }
}