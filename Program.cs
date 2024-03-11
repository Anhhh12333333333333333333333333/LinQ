using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinQ
{
    class Program
    {
        static void Main(string[] args)
        {
            var lstDep = Department.GetDepartments();
            var lstEmp = Employee.GetEmployees();

            var Maxsalary = lstEmp.Max(p => p.Salary);
            var MinSalary = lstEmp.Min(p => p.Salary);
            var TBCSalary = lstEmp.Average(p => p.Salary);
            Console.WriteLine("Ho Dang Quoc Anh-21115053120304");

            Console.WriteLine("Câu a");
            Console.WriteLine("Max salary: {0}", Maxsalary);
            Console.WriteLine("Min salary: {0}", MinSalary);
            Console.WriteLine("Average salary: {0}", TBCSalary);


            Console.WriteLine("Câu b");
            Console.WriteLine("Group Join");

            var grJoin = lstDep.GroupJoin(lstEmp,
                n => n.ID,
                p => p.DepartmentID,
                (n, p) => new
                {
                    Department = n,
                    Employee = p.ToList()
                }
                );
            foreach (var item in grJoin)
            {
                Console.WriteLine($"Department: {item.Department.Name}");
                foreach (var emp in item.Employee)
                {
                    Console.WriteLine($"- {emp.Name}");
                }
                Console.WriteLine();
            }
            Console.WriteLine("Left Join");

            var departmentEmployees = from dept in lstDep
                                      join emp in lstEmp on dept.ID equals emp.DepartmentID into empGroup
                                      from employee in empGroup.DefaultIfEmpty()
                                      select new
                                      {
                                          Department = dept,
                                          Employee = employee
                                      };

            // In ra thông tin của từng Department và Employee tương ứng (nếu có)
            foreach (var item in departmentEmployees)
            {
                Console.WriteLine($"Department: {item.Department.Name}, Employee: {(item.Employee != null ? item.Employee.Name : "No employee")}");
            }
            Console.WriteLine("Right Join");

            var rightjoin = from emp in lstEmp
                            join dept in lstDep on emp.DepartmentID equals dept.ID into deptGroup
                            from department in deptGroup.DefaultIfEmpty()
                            select new
                            {
                                Department = department,
                                Employee = emp
                            };

            foreach (var item in rightjoin)
            {
                Console.WriteLine($"Department: {(item.Department != null ? item.Department.Name : "No department")}, Employee: {item.Employee.Name}");
            }
            Console.WriteLine("Câu c");

            int maxAge = lstEmp.Max(e => CalculateAge(e.birthday));
            int minAge = lstEmp.Min(e => CalculateAge(e.birthday));

            Console.WriteLine($"Max Age: {maxAge}");
            Console.WriteLine($"Min Age: {minAge}");

            int CalculateAge ( DateTime bt)
            {
                DateTime today = DateTime.Today;
                int age = today.Year - bt.Year;
                if (bt.Date > today.AddYears(-age))
                    age--;

                return age;
            }

            
            Console.ReadLine();

        }
    }
}
