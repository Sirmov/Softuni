USE [Softuni]
GO

-- 1.Employee Address
SELECT TOP 5
    [e].[EmployeeID]
    ,[e].[JobTitle]
    ,[e].[AddressID]
    ,[a].[AddressText]
FROM [Employees] AS [e]
LEFT JOIN [Addresses] AS [a]
ON [e].[AddressID] = [a].[AddressID]
ORDER BY [e].[AddressID] ASC
GO

-- 2.Addresses with Towns
SELECT TOP 50
    [e].[FirstName]
    ,[e].[LastName]
    ,[t].[Name] AS [Town]
    ,[a].[AddressText]
FROM [Employees] AS [e]
LEFT JOIN [Addresses] AS [a]
ON [e].[AddressID] = [a].[AddressID]
LEFT JOIN [Towns] AS [t]
ON [a].[TownID] = [t].[TownID]
ORDER BY [e].[FirstName] ASC, [e].[LastName] ASC
GO

-- 3.Sales Employee
SELECT
    [e].[EmployeeID]
    ,[e].[FirstName]
    ,[e].[LastName]
    ,[d].[Name] AS [DepartmentName]
FROM [Employees] AS [e]
LEFT JOIN [Departments] AS [d]
ON [e].[DepartmentID] = [d].[DepartmentID]
WHERE [d].[Name] = 'Sales'
ORDER BY [e].[EmployeeID] ASC
GO

-- 4.Employee Departments
SELECT TOP 5
    [e].[EmployeeID]
    ,[e].[FirstName]
    ,[e].[Salary]
    ,[d].[Name] AS [DepartmentName]
FROM [Employees] AS [e]
LEFT JOIN [Departments] AS [d]
ON [e].[DepartmentID] = [d].[DepartmentID]
WHERE [e].[Salary] > 15000
ORDER BY [e].[DepartmentID] ASC
GO

-- 5.Employees Without Project
SELECT TOP 3
    [e].[EmployeeID]
    ,[e].[FirstName]
FROM [Employees] AS [e]
LEFT JOIN [EmployeesProjects] AS [ep]
ON [e].[EmployeeID] = [ep].[EmployeeID]
WHERE [ep].[ProjectID] IS NULL
ORDER BY [e].[EmployeeID] ASC
GO

-- 6.Employees Hired After
SELECT
    [e].[FirstName]
    ,[e].[LastName]
    ,[e].[HireDate]
    ,[d].[Name] AS [DeptName]
FROM [Employees] AS [e]
LEFT JOIN [Departments] AS [d]
ON [e].[DepartmentID] = [d].[DepartmentID]
WHERE [e].[HireDate] > '1.1.1999'
    AND [d].[Name] IN ('Sales', 'Finance')
ORDER BY [HireDate] ASC
GO

-- 7.Employees with Project
SELECT TOP 5
    [e].[EmployeeID]
    ,[e].[FirstName]
    ,[p].[Name] AS [ProjectName]
FROM [Employees] AS [e]
JOIN [EmployeesProjects] AS [ep]
ON [e].[EmployeeID] = [ep].[EmployeeID]
JOIN [Projects] AS [p]
ON [ep].[ProjectID] = [p].[ProjectID]
WHERE [p].[StartDate] > '08/13/2002'
    AND [p].[EndDate] IS NULL
ORDER BY [e].[EmployeeID] ASC
GO

-- 8.Employee 24
SELECT
    [e].[EmployeeID]
    ,[e].[FirstName]
    ,CASE
        WHEN [p].[StartDate] >= '01/01/2005' THEN NULL
        ELSE [p].[Name]
    END AS [ProjectName]
FROM [Employees] AS [e]
JOIN [EmployeesProjects] AS [ep]
ON [e].[EmployeeID] = [ep].[EmployeeID]
JOIN [Projects] AS [p]
ON [ep].[ProjectID] = [p].[ProjectID]
WHERE [e].[EmployeeID] = 24
GO

-- 9.Employee Manager
SELECT
    [e].[EmployeeID]
    ,[e].[FirstName]
    ,[m].[EmployeeID] AS [ManagerID]
    ,[m].[FirstName] AS [ManagerName]
FROM [Employees] AS [e]
JOIN [Employees] AS [m]
ON [e].[ManagerID] = [m].[EmployeeID]
WHERE [m].[EmployeeID] IN (3, 7)
ORDER BY [e].[EmployeeID] ASC
GO

-- 10.Employee Summary
SELECT TOP 50
    [e].[EmployeeID]
    ,CONCAT([e].[FirstName], ' ', [e].[LastName]) AS [EmployeeName]
    ,CONCAT([m].[FirstName], ' ', [m].[LastName]) AS [ManagerName]
    ,[d].[Name] AS [DepartmentName]
FROM [Employees] AS [e]
LEFT JOIN [Employees] AS [m]
ON [e].[ManagerID] = [m].[EmployeeID]
LEFT JOIN [Departments] AS [d]
ON [e].[DepartmentID] = [d].[DepartmentID]
ORDER BY [e].[EmployeeID] ASC
GO

-- 11.Min Average Salary
WITH [CTE_AverageSalaryByDepartment] ([DepartmentName], [AverageSalary])
AS
(
    SELECT
        [d].[Name]
        ,AVG([e].[Salary])
    FROM [Employees] AS [e]
    JOIN [Departments] AS [d]
    ON [e].[DepartmentID] = [d].[DepartmentID]
    GROUP BY [d].[Name]
)

SELECT
    MIN([AverageSalary]) AS [MinAverageSalary]
FROM [CTE_AverageSalaryByDepartment]
GO