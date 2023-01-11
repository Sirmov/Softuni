USE [Softuni]
GO

-- Problem 1.Find Names of All Employees by First Name
SELECT
    [FirstName]
    ,[LastName]
FROM [Employees]
--Using wildcards
--WHERE [FirstName] LIKE 'Sa%'
WHERE LEFT([FirstName], 2) = 'Sa'
GO

-- Problem 2.Find Names of All employees by Last Name
SELECT
    [FirstName]
    ,[LastName]
FROM [Employees]
--Using wildcards
--WHERE [LastName] LIKE '%ei%'
WHERE CHARINDEX('ei', [LastName]) > 0
GO

-- Problem 3.Find First Names of All Employees
SELECT
    [FirstName]
FROM [Employees]
WHERE [DepartmentID] IN (3, 10)
    AND YEAR([HireDate]) BETWEEN 1995 AND 2005
GO

-- Problem 4.Find All Employees Except Engineers
SELECT
    [FirstName]
    ,[LastName]
FROM [Employees]
WHERE CHARINDEX('engineer', [JobTitle]) = 0
GO

-- Problem 5.Find Towns with Name Length
SELECT
    [Name]
FROM [Towns]
WHERE LEN([Name]) BETWEEN 5 AND 6
ORDER BY [Name] ASC
GO

-- Problem 6. Find Towns Starting With
SELECT
    [TownId]
    ,[Name]
FROM [Towns]
WHERE LEFT([Name], 1) IN ('M', 'K', 'B', 'E')
ORDER BY [Name] ASC
GO

-- Problem 7. Find Towns Not Starting With
SELECT
    [TownId]
    ,[Name]
FROM [Towns]
WHERE LEFT([Name], 1) NOT IN ('R', 'B', 'D')
ORDER BY [Name] ASC
GO

-- Problem 8.Create View Employees Hired After 2000 Year
CREATE VIEW [V_EmployeesHiredAfter2000] AS
SELECT
    [FirstName]
    ,[LastName]
FROM [Employees]
WHERE DATEPART(YEAR, [HireDate]) > 2000
GO

-- Problem 9.Length of Last Name
SELECT
    [FirstName]
    ,[LastName]
FROM [Employees]
WHERE LEN([LastName]) = 5
GO

-- Problem 10.Rank Employees by Salary
SELECT
    [EmployeeID]
    ,[FirstName]
    ,[LastName]
    ,[Salary]
    ,DENSE_RANK() OVER (PARTITION BY [Salary] ORDER BY [EmployeeID]) AS [Rank]
FROM [Employees]
WHERE [Salary] BETWEEN 10000 AND 50000
ORDER BY [Salary] DESC
GO

-- Problem 11.Find All Employees with Rank 2 *
SELECT
    *
FROM
    (
        SELECT
            [EmployeeID]
            ,[FirstName]
            ,[LastName]
            ,[Salary]
            ,DENSE_RANK() OVER (PARTITION BY [Salary] ORDER BY [EmployeeID]) AS [Rank]
        FROM [Employees]
        WHERE [Salary] BETWEEN 10000 AND 50000
    ) AS [RankingSubquery]
WHERE [Rank] = 2
ORDER BY [Salary] DESC
GO