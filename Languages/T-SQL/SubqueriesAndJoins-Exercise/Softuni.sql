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