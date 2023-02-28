using static EmployeeManagerAPI.Constants;

namespace EmployeeManagerAPI.Exceptions;
public class DaysWorkedOutOfRangeException : DomainBaseException
{
    public DaysWorkedOutOfRangeException()
        : base($"Days worked must be within {MINIMUM_ANNUAL_WORK_DAYS} and {MAXIMUM_ANNUAL_WORK_DAYS}.")
    {
    }

    public DaysWorkedOutOfRangeException(string message) : base(message)
    {
    }

    public DaysWorkedOutOfRangeException(string message, Exception innerException) : base(message, innerException)
    {
    }
}