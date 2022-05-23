USE [Softuni]
GO

-- 2.Find All the Information About Departments
SELECT *
FROM [Departments]
GO

-- 3.Find all Department Names
SELECT [Name]
FROM [Departments]
GO

-- 4.Find Salary of Each Employee
SELECT
    [FirstName]
    ,[LastName]
    ,[Salary]
FROM [Employees]
GO

-- 5.Find Full Name of Each Employee
SELECT
    [FirstName]
    ,[MiddleName]
    ,[LastName]
FROM [Employees]
GO

-- 6.Find Email Address of Each Employee
SELECT
    CONCAT([FirstName], '.', [LastName], '@', 'softuni.bg')
    AS [Full Email Address]
FROM [Employees]
GO

-- 7.Find All Different Employees’ Salaries
SELECT DISTINCT
    [Salary]
FROM [Employees]
GO

-- 8.Find All Information About Employees
SELECT *
FROM [Employees]
WHERE [JobTitle] = 'Sales Representative'
GO

-- 9.Find Names of All Employees by Salary in Range
SELECT
    [FirstName]
    ,[LastName]
    ,[JobTitle]
FROM [Employees]
WHERE [Salary] BETWEEN 20000 AND 30000
GO

-- 10.Find Names of All Employees
SELECT
    CONCAT([FirstName], ' ', [MiddleName], ' ', [LastName])
    AS [Full Name]
FROM [Employees]
WHERE [Salary] IN (25000, 14000, 12500, 23600)
GO

-- 11.Find All Employees Without a Manager
SELECT
    [FirstName]
    ,[LastName]
FROM [Employees]
WHERE [ManagerId] IS NULL
GO

-- 12.Find All Employees with a Salary More Than 50000
SELECT
    [FirstName]
    ,[LastName]
    ,[Salary]
FROM [Employees]
WHERE [Salary] > 50000
ORDER BY [Salary] DESC
GO

-- 13.Find 5 Best Paid Employees.
SELECT TOP(5)
    [FirstName]
    ,[LastName]
FROM [Employees]
ORDER BY [Salary] DESC
GO

-- 14.Find All Employees Except Marketing
SELECT
    [FirstName]
    ,[LastName]
FROM [Employees]
WHERE [DepartmentId] <> 4
GO

-- 15.Sort Employees Table
SELECT *
FROM [Employees]
ORDER BY
    [Salary] DESC
    ,[FirstName] ASC
    ,[LastName] DESC
    ,[MiddleName] ASC
GO

-- 16.Create View Employees with Salaries
CREATE VIEW [V_EmployeesSalaries] AS
SELECT
    [FirstName]
    ,[LastName]
    ,[Salary]
FROM [Employees]
GO

-- 17.Create View Employees with Job Titles
CREATE VIEW [V_EmployeeNameJobTitle] AS
SELECT
    CONCAT([FirstName], ' ', [MiddleName], ' ', [LastName])
    AS [Full Name]
    ,[JobTitle]
FROM [Employees]
GO

-- 18.Distinct Job Titles
SELECT DISTINCT [JobTitle]
FROM [Employees]
GO

-- 19.Find First 10 Started Projects
SELECT TOP(10) *
FROM [Projects]
ORDER BY [StartDate], [Name]
GO

-- 20.Last 7 Hired Employees
SELECT TOP(7)
    [FirstName]
    ,[LastName]
    ,[HireDate]
FROM [Employees]
ORDER BY [HireDate] DESC
GO

-- 21.Increase Salaries
UPDATE [Employees] SET
    [Salary] += [Salary] * 0.12
WHERE [DepartmentId] IN (
                            SELECT [DepartmentID]
                            FROM [Departments]
                            WHERE [Name] IN ('Engineering', 'Tool Design', 'Marketing', 'Information Services')
                        )
GO