using System;
using System.Collections.Generic;

namespace Rezerwacje.Models
{
    public partial class Employees
    {
        public int EmployeeId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string EmployeeLogin { get; set; }
        public string EmployeePassword { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime EmploymendDate { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public short Priviliges { get; set; }
    }
}
