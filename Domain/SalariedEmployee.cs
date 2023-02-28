namespace EmployeeManagerAPI.Domain;

public class SalariedEmployee : BaseEmployee
{
    public override EmployeeType EmployeeType => EmployeeType.Salaried;
    protected override decimal VacationDaysAccumulable => 15;

    public SalariedEmployee(Guid id, string firstName, string lastName)
        : base(id, firstName, lastName)
    {
    }
}