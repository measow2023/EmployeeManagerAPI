namespace EmployeeManagerAPI.Domain;

public class HourlyEmployee : BaseEmployee
{
    public override EmployeeType EmployeeType => EmployeeType.Hourly;
    protected override decimal VacationDaysAccumulable => 10;

    public HourlyEmployee(Guid id, string firstName, string lastName)
        : base(id, firstName, lastName)
    { }
}