using EmployeeManagerAPI.Domain;
using EmployeeManagerAPI.Exceptions;
using EmployeeManagerAPI.Models;

namespace EmployeeManagerAPI.Services;

public class EmployeeService : IEmployeeService
{
    private readonly List<IEmployee> _employees = new();

    public EmployeeService()
    {
        PopulateEmployeesList();
    }

    public IEnumerable<EmployeeResponseModel> GetAll()
    {
        return _employees.Select(ToViewModel);
    }

    public EmployeeResponseModel GetById(Guid employeeId)
    {
        var employee = GetEmployeeById(employeeId);
        return ToViewModel(employee);
    }

    public EmployeeResponseModel Work(Guid employeeId, int workedDays)
    {
        var employee = GetEmployeeById(employeeId);
        employee.Work(workedDays);
        return ToViewModel(employee);
    }

    public EmployeeResponseModel TakeVacation(Guid employeeId, decimal vacationDaysUsed)
    {
        var employee = GetEmployeeById(employeeId);
        employee.TakeVacation(vacationDaysUsed);
        return ToViewModel(employee);
    }

    public static EmployeeResponseModel ToViewModel(IEmployee employee)
    {
        return new EmployeeResponseModel()
        {
            Id = employee.Id,
            FirstName = employee.FirstName,
            LastName = employee.LastName,
            EmployeeType = employee.EmployeeType,
            VacationDaysAccumulated = string.Format("{0:0.00}", employee.VacationDaysAccumulated)
        };
    }

    private IEmployee GetEmployeeById(Guid employeeId)
    {
        var employee = _employees.Find(x => x.Id == employeeId);
        if (employee is null)
        {
            throw new EmployeeNotFoundException($"{nameof(employeeId)} {employeeId} not found.");
        }
        return employee;
    }

    private void PopulateEmployeesList()
    {
        _employees.AddRange(
            new List<IEmployee>() {
                // Hourly
                new HourlyEmployee(new Guid("3685a9b7-bca5-4e94-9d49-2216ea609c59"), "Stewart", "Simon"),
                new HourlyEmployee(new Guid("32b93c8f-aae1-4972-aa09-4648ca561810"), "Terence", "Rhodes"),
                new HourlyEmployee(new Guid("255802ce-1922-49ae-810d-6644f923e35c"), "Vivian", "Boone"),
                new HourlyEmployee(new Guid("81003b70-47b3-46c5-a012-45dffc8462eb"), "Jeannie", "Jimenez"),
                new HourlyEmployee(new Guid("9230948f-66be-4ac3-b01d-f31f2126777f"), "Naomi", "Wallace"),
                new HourlyEmployee(new Guid("cc07745c-7679-47f4-8ed6-0bf9fa141465"),"Mary", "Tucker"),
                new HourlyEmployee(new Guid("6b1d06ee-2b1c-48b5-938d-6aa1f31e864d"), "Jane", "Hogan"),
                new HourlyEmployee(new Guid("91e1e4db-e8d8-405d-a3a8-706c25aecc70"), "Beatrice", "Lee"),
                new HourlyEmployee(new Guid("261e9fd7-cf86-4875-9c01-372b2f3f1e47"), "Lucille", "Fernandez"),
                new HourlyEmployee(new Guid("439bb7bf-757a-4607-86b7-5f0271eabdff"), "Ida", "Hunt"),
                // Salaried
                new SalariedEmployee(new Guid("12773ea0-3e31-4943-807d-d281eab41203"), "Traci", "Hines"),
                new SalariedEmployee(new Guid("6eedf351-9a59-4671-9f6b-52e8c56bcda4"), "Johnny", "Floyd"),
                new SalariedEmployee(new Guid("b7cee2fd-6dc0-4523-b001-3d9013776a5f"), "Joseph", "Francis"),
                new SalariedEmployee(new Guid("f0c7361e-3b81-4b81-bc1a-a08a1d3cc6bd"), "Levi", "Wright"),
                new SalariedEmployee(new Guid("ac3bb87f-cb59-4aaa-a0d8-c916e82d99ae"), "Garrett", "Stewart"),
                new SalariedEmployee(new Guid("e338fdda-a498-4788-8e44-d508f260390b"), "Mack", "Jimenez"),
                new SalariedEmployee(new Guid("f0509f66-ef1a-4365-92ab-0d2fa7b05a6c"), "Nicolas", "Burgess"),
                new SalariedEmployee(new Guid("b3dde6c1-5240-43e2-805f-3cbb27cd6321"), "Maxine", "Delgado"),
                new SalariedEmployee(new Guid("23137e04-1a8f-469c-aba3-c4dd87cfcebb"), "Emma", "Underwood"),
                new SalariedEmployee(new Guid("cb159433-962c-46fa-9b28-6394dcceaa47"), "Kristopher", "Ramirez"),
                // Manager
                new ManagerEmployee(new Guid("d2cec950-3e32-40e0-ae4d-0c0c836ef6ef"), "Doreen", "Rodgers"),
                new ManagerEmployee(new Guid("7763dbb8-3393-4c11-89d0-25e2493dbdd3"), "Walter", "Adams"),
                new ManagerEmployee(new Guid("acb1c972-f14f-477c-a716-d65ff38a10b4"), "Verna", "Lawson"),
                new ManagerEmployee(new Guid("c25e8be9-5dc3-4a4a-a700-b6a5a796e8b0"), "Al", "Miller"),
                new ManagerEmployee(new Guid("723af985-c373-4969-9e7b-7312d7e6b485"), "Cecil", "Lynch"),
                new ManagerEmployee(new Guid("20c60d08-1093-4495-9cc9-12de2939f761"), "Angelica", "Strickland"),
                new ManagerEmployee(new Guid("aa082c3f-9dcb-4918-98ce-f5b5dcf94002"), "Naomi", "Burgess"),
                new ManagerEmployee(new Guid("bdc201db-0f10-4c0f-be49-7bd738f6752e"), "Philip", "Williams"),
                new ManagerEmployee(new Guid("bb984a2b-04c0-4751-8063-b323b3772d1d"), "Thomas", "Mcgee"),
                new ManagerEmployee(new Guid("2ae53756-c7a6-4020-96ef-741b1632cb2d"), "Silvia", "Neal")
            });
    }
}