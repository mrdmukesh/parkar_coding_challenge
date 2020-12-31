using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeRegistration.Models
{

    
    public class MockEmployeeRepository : IEmployeeRepository
    {
        private List<Employee> _employeeList;

        public MockEmployeeRepository()
        {
            _employeeList = new List<Employee>()
            {
              new Employee(){  Id = 1, FirstName = "Pat", LastName = "Collumn", Email = "Pat.Collumn@abc.com", Phone = 9923128577},
              new Employee(){  Id = 2, FirstName = "Colin", LastName = "Bell", Email = "Colin.Bell@abc.com", Phone = 9923128578 },
              new Employee(){  Id = 3, FirstName = "Mery", LastName = "John", Email = "Mery.John@abc.com", Phone = 9923128580}
            };
        }
        public Employee GetEmployee(int id)
        {
            return _employeeList.FirstOrDefault(e =>e.Id == id);
        }

        public IEnumerable<Employee> GetAllEmployee()
        {
            return _employeeList;
        }

        public Employee AddEmployee(Employee employee)
        {
            employee.Id = _employeeList.Max(e => e.Id) + 1;
            _employeeList.Add(employee);
            return employee;
        }

        public Employee DeleteEmployee(int empId)
        {
            Employee employee = _employeeList.FirstOrDefault(e => e.Id == empId);

            if (employee != null)
            {
                _employeeList.Remove(employee);
            }

            return employee;
        }

        public Employee UpdateEmployee(Employee employeeupdate)
        {
            Employee employee = _employeeList.FirstOrDefault(e => e.Id == employeeupdate.Id);

            if (employee != null)
            {
                employee.FirstName = employeeupdate.FirstName;
                employee.LastName = employeeupdate.LastName;
                employee.Email = employeeupdate.Email;
                employee.Phone = employeeupdate.Phone;
                
            }

            return employee;
        }


    }
}
