using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeRegistration.Models
{
    public static class ModelBuilderExtentions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().HasData(
                    new Employee() { Id = 1, FirstName = "Pat", LastName = "Collumn", Email = "Pat.Collumn@abc.com", Phone = 9923128577},
              new Employee() { Id = 2, FirstName = "Colin", LastName = "Bell", Email = "Colin.Bell@abc.com", Phone = 9923128578 },
              new Employee() { Id = 3, FirstName = "Mery", LastName = "John", Email = "Mery.John@abc.com", Phone = 9923128580 }

                );

        }
    }
}
