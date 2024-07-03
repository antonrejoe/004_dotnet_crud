using System.ComponentModel.DataAnnotations;
using TestCoreMVC.Models.Entities;
using TestCoreMVC.Models.Interface;
// using TestCoreMVC.Models.Interface;     


namespace TestCoreMVC.Models.Implementation 
{ public class EmployeeRepository : IEmployee {
        public static List<Employee> EmployeeData =
        [
            new() {EmployeeId = 1 , Name = "harry weiner"  , Experience=" 2 yrs 3 months" , Section="unkown" , Branch="Health"},
            new() {EmployeeId = 1 , Name = "harry weiner"  , Experience=" 2 yrs 3 months" , Section="unkown" , Branch="Health"},
            new() {EmployeeId = 1 , Name = "harry weiner"  , Experience=" 2 yrs 3 months" , Section="unkown" , Branch="Health"},
            new() {EmployeeId = 1 , Name = "harry weiner"  , Experience=" 2 yrs 3 months" , Section="unkown" , Branch="Health"},
            new() {EmployeeId = 1 , Name = "harry weiner"  , Experience=" 2 yrs 3 months" , Section="unkown" , Branch="Health"},
        ];
        public List<Employee> DataSource()
        {
            return EmployeeData;
        }

        public Employee getEmployeeById(int EmployeeId){
            return DataSource().FirstOrDefault(e => e.EmployeeId == EmployeeId  ) ?? new Employee(); 
        }

        public int UpdateEmployee(Employee updatedEmployee )
        {
            Employee employee =  DataSource().FirstOrDefault(e => e.EmployeeId == updatedEmployee.EmployeeId ) ?? new Employee();
            employee.EmployeeId = updatedEmployee.EmployeeId;
            employee.Name = updatedEmployee.Name;
            employee.Branch = updatedEmployee.Branch;
            employee.Experience = updatedEmployee.Experience;
            employee.Section = updatedEmployee.Section;

            if(updatedEmployee.EmployeeId == 0){

                var maxEmployee = DataSource().MaxBy(e => e.EmployeeId) ;
                int maxEmployeeId = maxEmployee.EmployeeId; 
                employee.EmployeeId = maxEmployee.EmployeeId +1; 
                EmployeeData.Add(employee);

            }

            return employee.EmployeeId ;
        }

        public bool DeleteEmployee(int employeeId)
        {
            Employee employee = DataSource().FirstOrDefault(e => e.EmployeeId == employeeId ) ?? new Employee();
            EmployeeData.Remove(employee);
            return true;
        }

    }

}