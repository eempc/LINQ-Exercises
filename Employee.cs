using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ
{
    class Employee
    {
        public int employeeID { get; set; }
        public string employeeName { get; set; }
        public int deptID { get; set; }

        public Employee(int employeeID, string employeeName, int deptID)
        {
            this.employeeID = employeeID;
            this.employeeName = employeeName;
            this.deptID = deptID;
        }
    }
}
