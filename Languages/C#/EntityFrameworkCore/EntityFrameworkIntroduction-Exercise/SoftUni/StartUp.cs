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

        // Problem 7
        public static string GetEmployee147(SoftUniContext context)
        {
            var employee = context.Employees
                .Include(e => e.EmployeesProjects)
                .ThenInclude(ep => ep.Project)
                .Single(e => e.EmployeeId == 147);

            StringBuilder output = new StringBuilder();
            output.AppendLine($"{employee.FirstName} {employee.LastName} - {employee.JobTitle}");

            var employeeProjects = employee.EmployeesProjects
                .OrderBy(ep => ep.Project.Name);

            foreach (var employeeProject in employeeProjects)
            {
                output.AppendLine(employeeProject.Project.Name);
            }

            return output.ToString().TrimEnd();
        }

        // Problem 8
        public static string GetDepartmentsWithMoreThan5Employees(SoftUniContext context)
        {
            var departments = context.Departments
                .Include(d => d.Employees)
                .ThenInclude(d => d.Manager)
                .Select(d => new
                {
                    d.Name,
                    EmployeeCount = d.Employees.Count(),
                    d.Manager,
                    d.Employees
                })
                .Where(d => d.EmployeeCount > 5)
                .OrderBy(d => d.EmployeeCount)
                .ThenBy(d => d.Name)
                .ToList();
            StringBuilder output = new StringBuilder();

            foreach (var department in departments)
            {
                output.AppendLine($"{department.Name} - {department.Manager.FirstName} {department.Manager.LastName}");
                var employees = department.Employees.OrderBy(e => e.FirstName).ThenBy(e => e.LastName);

                foreach (var employee in employees)
                {
                    output.AppendLine($"{employee.FirstName} {employee.LastName} - {employee.JobTitle}");
                }
            }

            return output.ToString().TrimEnd();
        }

        // Problem 10
        public static string GetLatestProjects(SoftUniContext context)
        {
            var projects = context.Projects
                .OrderByDescending(p => p.StartDate)
                .Take(10)
                .OrderBy(p => p.Name)
                .ToList();
            StringBuilder output = new StringBuilder();

            foreach (var project in projects)
            {
                output.AppendLine(project.Name);
                output.AppendLine(project.Description);
                output.AppendLine(project.StartDate.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture));
            }

            return output.ToString().TrimEnd();
        }

        // Problem 11
        public static string IncreaseSalaries(SoftUniContext context)
        {
            var employees = context.Employees
                    .Include(e => e.Department)
                    .Where(e => e.Department.Name == "Engineering"
                            || e.Department.Name == "Tool Design"
                            || e.Department.Name == "Marketing"
                            || e.Department.Name == "Information Services")
                    .OrderBy(e => e.FirstName)
                    .ThenBy(e => e.LastName)
                    .ToList();

            foreach (var employee in employees)
            {
                employee.Salary += employee.Salary * 0.12m;
            }

            context.SaveChanges();
            StringBuilder output = new StringBuilder();

            foreach (var employee in employees)
            {
                output.AppendLine($"{employee.FirstName} {employee.LastName} (${employee.Salary:F2})");
            }

            return output.ToString().TrimEnd();
        }

        // Problem 12
        public static string GetEmployeesByFirstNameStartingWithSa(SoftUniContext context)
        {
            var employees = context.Employees
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    e.JobTitle,
                    e.Salary
                })
                .Where(e => e.FirstName.ToLower().StartsWith("sa"))
                .OrderBy(e => e.FirstName)
                .ThenBy(e => e.LastName)
                .ToList();

            StringBuilder output = new StringBuilder();
            foreach (var employee in employees)
            {
                output.AppendLine($"{employee.FirstName} {employee.LastName} - {employee.JobTitle} - (${employee.Salary:F2})");
            }

            return output.ToString().TrimEnd();
        }

        // Problem 13
        public static string DeleteProjectById(SoftUniContext context)
        {
            Project projectToBeRemoved = context.Projects.Find(2);
            var relatedEmployeesProjects = context.EmployeesProjects
                .Where(ep => ep.ProjectId == 2)
                .ToList();

            context.EmployeesProjects.RemoveRange(relatedEmployeesProjects);
            context.Projects.Remove(projectToBeRemoved);
            context.SaveChanges();

            var projects = context.Projects
                .Select(p => p.Name)
                .Take(10)
                .ToList();

            return string.Join(Environment.NewLine, projects);
        }

        // Problem 14
        public static string RemoveTown(SoftUniContext context)
        {
            var town = context.Towns.Single(t => t.Name == "Seattle");
            var addresses = context.Addresses
                .Where(a => a.TownId == town.TownId)
                .ToList();
            var employees = context.Employees
                .Include(e => e.Address)
                .Where(e => addresses.Contains(e.Address))
                .ToList();

            foreach (var employee in employees)
            {
                employee.AddressId = null;
            }

            string output = $"{addresses.Count()} addresses in Seattle were deleted";

            context.Addresses.RemoveRange(addresses);
            context.Towns.Remove(town);
            context.SaveChanges();

            return output;
        }
    }
}
