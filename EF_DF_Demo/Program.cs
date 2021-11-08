using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_DF_Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            RemoveEmployee();
            Console.ReadLine();
        }

        private static void DisplayAllDepartmentsAndEmployees()
        {
            using (EF_DEMO_DBEntities db = new EF_DEMO_DBEntities())
            {
                var departments = db.DEPARTMENTS.ToList();
                foreach (var department in departments)
                {
                    Console.WriteLine($"Department: {department.NAME}, Location: {department.LOCATION}");
                    foreach (var emp in department.EMPLOYEES)
                    {
                        Console.WriteLine($"Name: {emp.NAME} Email: {emp.EMAIL} Salary: {emp.SALARY}");
                    }
                }

            }
        }

        private static void AddEmployee()
        {
            var employee = new EMPLOYEE
            {
                NAME = "Bikash",
                DEPARTMENT_ID = 1,
                EMAIL = "email@email.com",
                GENDER = "Male",
                SALARY = 90000
            };

            using (var context = new EF_DEMO_DBEntities())
            {
                context.EMPLOYEES.Add(employee);
                context.SaveChanges();
            }
        }

        private static void UpdateEmployee()
        {

            using (var context = new EF_DEMO_DBEntities())
            {
                var emp = (from d in context.EMPLOYEES
                           where d.NAME == "Bikash"
                           select d).Single();
                emp.NAME = "Bikku";
                context.SaveChanges();
            }
        }

        private static void RemoveEmployee()
        {

            using (var context = new EF_DEMO_DBEntities())
            {
                var emp = (from d in context.EMPLOYEES
                           where d.NAME == "Bikku"
                           select d).Single();
                context.EMPLOYEES.Remove(emp);
                context.SaveChanges();
            }
        }


    }
}
