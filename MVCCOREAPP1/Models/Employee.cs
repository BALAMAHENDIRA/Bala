using System;
using System.Collections.Generic;

#nullable disable

namespace MVCCOREAPP1.Models
{
    public partial class Employee
    {
        public int EmpId { get; set; }
        public int DeptId { get; set; }
        public string EmpName { get; set; }
        public decimal EmpSalary { get; set; }

        public virtual Department Dept { get; set; }
    }
}
