namespace EmployeeManagerAPI.Domain;

public class ManagerEmployee : SalariedEmployee
{
    public override EmployeeType EmployeeType => EmployeeType.Manager;
    protected override decimal VacationDaysAccumulable => 30;
    public ManagerEmployee(Guid id, string firstName, string lastName) : base(id, firstName, lastName)
    {
    }
}