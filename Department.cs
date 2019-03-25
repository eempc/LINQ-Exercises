using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ
{
    class Department
    {
        public int deptID { get; set; }
        public string deptName { get; set; }

        public Department(int deptID, string deptName) {
            this.deptID = deptID;
            this.deptName = deptName;
        }


    }
}
