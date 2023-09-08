using EFCore_Sample.Models;

namespace EFCore_Sample.EntityModels.Employee
{
    public class EmployeeEntity
    {

        public AppDBContext Context { get; }
        public EmployeeEntity(AppDBContext context)
        {
            Context = context;
        }

        public List<Employee> GetData()
        {
            return Context.Employees.ToList();
        }
    }
}
