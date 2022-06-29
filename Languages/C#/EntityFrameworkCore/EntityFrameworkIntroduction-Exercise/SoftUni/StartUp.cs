using SoftUni.Data;
using SoftUni.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftUni
{
    public class StartUp
    {
        public static void Main()
        {
            
        }

        // Problem 1
        public static string GetEmployeesFullInformation(SoftUniContext context)
        {
            var employees = context.Employees
                .Select(e => new
                {
                    e.EmployeeId,
                    e.FirstName,
                    e.LastName,
                    e.MiddleName,
                    e.JobTitle,
                    e.Salary
                })
                .OrderBy(e => e.EmployeeId)
                .ToList();

            const string outputFormat = "{0} {1} {2} {3} {4:F2}";

            return string.Join(Environment.NewLine, employees
                .Select(e => string.Format(outputFormat, e.FirstName, e.LastName, e.MiddleName, e.JobTitle, e.Salary)));
        }

        // Problem 2
        public static string GetEmployeesWithSalaryOver50000(SoftUniContext context)
        {
            var employees = context.Employees
                .Select(e => new
                {
                    e.FirstName,
                    e.Salary
                })
                .Where(e => e.Salary > 50000)
                .OrderBy(e => e.FirstName)
                .ToList();

            const string outputFormat = "{0} - {1:F2}";

            return string.Join(Environment.NewLine, employees
                .Select(e => string.Format(outputFormat, e.FirstName, e.Salary)));
        }

        // Problem 3
        public static string GetEmployeesFromResearchAndDevelopment(SoftUniContext context)
        {
            var employees = context.Employees
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    DepartmentName = e.Department.Name,
                    e.Salary
                })
                .Where(e => e.DepartmentName == "Research and Development")
                .OrderBy(e => e.Salary)
                .ThenByDescending(e => e.FirstName)
                .ToList();

            const string outputFormat = "{0} {1} from {2} - ${3:F2}";

            return string.Join(Environment.NewLine, employees
                .Select(e => string.Format(outputFormat, e.FirstName, e.LastName, e.DepartmentName, e.Salary)));
        }

        // Problem 4
        public static string AddNewAddressToEmployee(SoftUniContext context)
        {
            Address address = new Address() { AddressText = "Vitoshka 15", TownId = 4 };
            Employee employee = context.Employees.FirstOrDefault(e => e.LastName == "Nakov");
            employee.Address = address;
            context.SaveChanges();

            var employees = context.Addresses
                .Select(a => new
                {
                    a.AddressId,
                    a.AddressText
                })
                .OrderByDescending(a => a.AddressId)
                .Take(10)
                .ToList();

            return string.Join(Environment.NewLine, employees.Select(a => a.AddressText));
        }
    }
}
