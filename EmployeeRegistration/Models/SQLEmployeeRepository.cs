using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeRegistration.Models
{
    public class SQLEmployeeRepository : IEmployeeRepository
    {

        public readonly AppDbContext dbContext;
       public SQLEmployeeRepository(AppDbContext Context)
        {
            dbContext = Context;
        }

        public Employee AddEmployee(Employee employee)
        {
            dbContext.Employees.Add(employee);
            dbContext.SaveChanges();
            return employee;
        }

        public Employee DeleteEmployee(int empid)
        {
            Employee employee = dbContext.Employees.Find(empid);
            if(employee != null)
            {
                dbContext.Employees.Remove(employee);
                dbContext.SaveChanges();
            }

            return employee;
        }

        public IEnumerable<Employee> GetAllEmployee()
        {
            return dbContext.Employees;
        }

        public Employee GetEmployee(int id)
        {
            return dbContext.Employees.Find(id);
        }

        public Employee UpdateEmployee(Employee employeeupdated)
        {
            var employee = dbContext.Employees.Attach(employeeupdated);
            employee.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            dbContext.SaveChanges();
            return employeeupdated;
        }
    }
}
