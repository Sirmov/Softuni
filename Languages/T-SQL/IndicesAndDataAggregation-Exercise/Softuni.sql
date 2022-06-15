USE [Softuni]
GO

-- 13.Departments Total Salaries
SELECT
    [DepartmentId]
    ,SUM([Salary]) AS [TotalSalary]
FROM [Employees]
GROUP BY [DepartmentId]
ORDER BY [DepartmentId] ASC
GO

-- 14.Employees Minimum Salaries
SELECT
    [DepartmentId]
    ,MIN([Salary]) AS [MinimumSalary]
FROM [Employees]
WHERE [HireDate] > '01/01/2000'
    AND [DepartmentId] IN (2, 5, 7)
GROUP BY [DepartmentId]
GO

-- 15.Employees Average Salaries
SELECT
    *
INTO [#TEMP_Employees]
FROM [Employees]
WHERE [Salary] > 30000
GO

DELETE [#TEMP_Employees]
WHERE [ManagerId] = 42
GO

UPDATE [#TEMP_Employees] SET
    [Salary] = [Salary] + 5000
WHERE [DepartmentId] = 1
GO

SELECT
    [DepartmentId]
    ,AVG([Salary]) AS [AverageSalary]
FROM [#TEMP_Employees]
GROUP BY [DepartmentId]
GO

-- 16.Employees Maximum Salaries
SELECT
    [DepartmentId]
    ,MAX([Salary]) AS [MaxSalary]
FROM [Employees]
GROUP BY [DepartmentId]
HAVING MAX([Salary]) NOT BETWEEN 30000 AND 70000
GO

-- 17.Employees Count Salaries
SELECT
    COUNT(*)
FROM [Employees]
WHERE [ManagerId] IS NULL
GO

-- 18.*3rd Highest Salary
SELECT DISTINCT
    [DepartmentId]
    ,[Salary]
FROM
    (
        SELECT
            *
            ,DENSE_RANK() OVER (PARTITION BY [DepartmentId] ORDER BY [Salary] DESC)
            AS [DepartmentSalaryRank]
        FROM [Employees]
    ) AS [SBQ_DepartmentSalaryRanking]
WHERE [DepartmentSalaryRank] = 3
GO

-- 19.**Salary Challenge
SELECT TOP 10
    [e].[FirstName]
    ,[e].[LastName]
    ,[e].[DepartmentId]
FROM [Employees] AS [e]
JOIN
    (
        SELECT
            [DepartmentId]
            ,AVG(Salary) AS [AverageSalary]
        FROM [Employees]
        GROUP BY [DepartmentId]
    ) AS [d]
ON [e].[DepartmentId] = [d].[DepartmentId]
WHERE [e].[Salary] > [d].[AverageSalary]
ORDER BY [e].[DepartmentId] ASC
GO