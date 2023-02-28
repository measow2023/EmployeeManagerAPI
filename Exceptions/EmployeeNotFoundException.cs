namespace EmployeeManagerAPI.Exceptions;
public class EmployeeNotFoundException : DomainBaseException
{
    public EmployeeNotFoundException()
    {
    }

    public EmployeeNotFoundException(string message)
        : base(message)
    {
    }

    public EmployeeNotFoundException(string message, Exception innerException)
        : base(message, innerException)
    {
    }

    public EmployeeNotFoundException(Guid employeeId)
        : this($"Employee with id {employeeId} is not found.")
    {
    }
}