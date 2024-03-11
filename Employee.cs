using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinQ
{
    class Employee
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public double Salary { get; set; }
        public DateTime birthday { get; set; }
        public int DepartmentID { get; set; }
        public static IList<Employee> GetEmployees()
        {
            return new List<Employee>()
            {
                new Employee{ ID=1, Name="A", Age=21, Salary=20000000, birthday= DateTime.Parse("2002-11-11"), DepartmentID=1},
                new Employee{ ID=2, Name="B", Age=31, Salary=30000000, birthday= DateTime.Parse("2003-9-11"), DepartmentID=2},
                new Employee{ ID=3, Name="C", Age=41, Salary=10000000, birthday= DateTime.Parse("2001-10-11"), DepartmentID=3},
                new Employee{ ID=4, Name="D", Age=35, Salary=50000000, birthday= DateTime.Parse("2002-1-11"), DepartmentID=1},
                new Employee{ ID=5, Name="E", Age=30, Salary=15000000, birthday= DateTime.Parse("2002-11-11"), DepartmentID=2}




            };
        }


    }
}
