USE [Softuni]
GO

-- 1.Employees with Salary Above 35000
CREATE OR ALTER PROC [usp_GetEmployeesSalaryAbove35000]
AS
SELECT
    [FirstName]
    ,[LastName]
FROM [Employees]
WHERE [Salary] > 35000
GO

-- 2.Employees with Salary Above Number
CREATE OR ALTER PROC [USP_GetEmployeesSalaryAboveNumber] @Salary DECIMAL(18, 4)
AS
SELECT
    [FirstName]
    ,[LastName]
FROM [Employees]
WHERE [Salary] >= @Salary
GO

-- 3.Town Names Starting With
CREATE OR ALTER PROC [USP_GetTownsStartingWith] @StartString NVARCHAR(20)
AS
SELECT
    [Name]
FROM [Towns]
WHERE [Name] LIKE CONCAT(@StartString, '%')
GO

-- 4.Employees from Town
CREATE OR ALTER PROC [USP_GetEmployeesFromTown] @Town NVARCHAR(50)
AS
SELECT
    [FirstName]
    ,[LastName]
FROM [Employees] AS [e]
JOIN [Addresses] AS [a]
ON [e].[AddressID] = [a].[AddressID]
JOIN [Towns] AS [t]
ON [a].[TownID] = [t].[TownID]
WHERE [t].[Name] = @Town
GO

-- 5.Salary Level Function
CREATE OR ALTER FUNCTION [UFN_GetSalaryLevel] (@Salary DECIMAL(18,4))
RETURNS VARCHAR(10)
AS
BEGIN
    IF(@Salary < 30000)
    BEGIN
        RETURN 'Low';
    END
    ELSE IF(@Salary < 50000)
    BEGIN
        RETURN 'Average';
    END
    RETURN 'High';
END
