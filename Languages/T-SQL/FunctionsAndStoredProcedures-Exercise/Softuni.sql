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
GO

-- 6. Employees by Salary Level
CREATE PROC [USP_EmployeesBySalaryLevel] @SalaryLevel VARCHAR(10)
AS
BEGIN
SELECT
	[FirstName]
    ,[LastName]
FROM [Employees]
WHERE [dbo].[UFN_GetSalaryLevel]([Salary]) = @SalaryLevel
END
GO

-- 7.Define Function
CREATE OR ALTER FUNCTION [UFN_IsWordComprised](@SetOfLetters VARCHAR(30), @Word VARCHAR(30))
RETURNS BIT
AS
BEGIN
    DECLARE @I INT = 1;
    WHILE @I <= LEN(@Word)
    BEGIN
        DECLARE @Letter VARCHAR(1) = SUBSTRING(@Word, @I, 1)
        IF (CHARINDEX(@Letter, @SetOfLetters) = 0)
        BEGIN
            RETURN 0
        END
        SET @I += 1
    END
    RETURN 1
END
GO

-- 8.* Delete Employees and Departments
CREATE PROC [USP_DeleteEmployeesFromDepartment] @DepartmentId INT
AS
BEGIN
    DELETE FROM [EmployeesProjects]
    WHERE [EmployeeId] IN 
                        (
                            SELECT
                                [EmployeeId]
                            FROM [Employees]
                            WHERE [DepartmentId] = @DepartmentId
                        )

    ALTER TABLE [Departments]
    ALTER COLUMN [ManagerId] 
    INT

    UPDATE [Departments]
    SET [ManagerId] = NULL
    WHERE [ManagerId] IN 
                        (
                            SELECT
                                [EmployeeId]
                            FROM [Employees]
                            WHERE [DepartmentId] = @DepartmentId
                        )

    UPDATE [Employees]
    SET [ManagerId] = NULL
    WHERE [ManagerId] IN 
                        (
                            SELECT
                                [EmployeeId]
                            FROM [Employees]
                            WHERE [DepartmentId] = @DepartmentId
                        )

    DELETE FROM [Employees]
    WHERE [EmployeeId] IN 
                        (
                            SELECT
                                [EmployeeId]
                            FROM [Employees]
                            WHERE [DepartmentId] = @DepartmentId
                        )

    DELETE FROM [Departments]
    WHERE [DepartmentId] = @DepartmentId

    SELECT
        COUNT(*)
    FROM [Employees]
    WHERE [DepartmentId] = @DepartmentId
END
GO