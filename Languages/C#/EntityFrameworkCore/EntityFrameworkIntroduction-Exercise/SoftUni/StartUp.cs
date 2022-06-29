using Microsoft.EntityFrameworkCore;
using SoftUni.Data;
using SoftUni.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
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
            Employee employee = context.Employees.Single(e => e.LastName == "Nakov");
            employee.Address = address;
            context.SaveChanges();

            var employees = context.Employees
                .Select(e => new
                {
                    e.AddressId,
                    AddressText = e.Address.AddressText
                })
                .OrderByDescending(e => e.AddressId)
                .Take(10)
                .ToList();

            return string.Join(Environment.NewLine, employees.Select(e => e.AddressText));
        }

        // Problem 5
        public static string GetEmployeesInPeriod(SoftUniContext context)
        {
            //Func<EmployeeProject, bool> projectPredicate = ep => ep.Project.StartDate.Year >= 2001 && ep.Project.StartDate.Year <= 2003;
            
            var employees = context.Employees
                    .Include(e => e.Manager)
                    .Include(e => e.EmployeesProjects)
                    .ThenInclude(e => e.Project)
                    .Where(e => e.EmployeesProjects
                        .Any(ep => ep.Project.StartDate.Year >= 2001 && ep.Project.StartDate.Year <= 2003))
                    .Take(10)
                    .ToList();
            StringBuilder output = new StringBuilder();

            foreach (Employee employee in employees)
            {
                Employee manager = employee.Manager;
                output.AppendLine($"{employee.FirstName} {employee.LastName} - Manager: {manager.FirstName} {manager.LastName}");

                foreach (EmployeeProject employeeProject in employee.EmployeesProjects)
                {
                    Project project = employeeProject.Project;
                    string startDate = project.StartDate.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture);
                    string endDate = "not finished";

                    if (project.EndDate != null)
                    {
                        endDate = ((DateTime) project.EndDate).ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture);
                    }

                    output.AppendLine($"--{project.Name} - {startDate} - {endDate}");
                }
            }

            return output.ToString().TrimEnd();
        }

        // Problem 6
        public static string GetAddressesByTown(SoftUniContext context)
        {
            var addresses = context.Addresses
                    .Include(a => a.Town)
                    .Include(a => a.Employees)
                    .Select(a => new
                    {
                        a.AddressText,
                        TownName = a.Town.Name,
                        EmployeeCount =  a.Employees.Count()
                    })
                    .OrderByDescending(a => a.EmployeeCount)
                    .ThenBy(a => a.TownName)
                    .ThenBy(a => a.AddressText)
                    .Take(10)
                    .ToList();

            return string.Join(Environment.NewLine, addresses.Select(a => $"{a.AddressText}, {a.TownName} - {a.EmployeeCount} employees"));
        }
    }
}
