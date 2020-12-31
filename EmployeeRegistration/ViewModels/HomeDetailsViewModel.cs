using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeRegistration.Models;

namespace EmployeeRegistration.ViewModels
{
    public class HomeDetailsViewModel
    {
        public string PageTitle { get;  set; }
        public Employee Employee { get;  set; }
    }
}
