USE [Softuni]
GO

-- 8.Employees with Three Projects
CREATE PROC [USP_AssignProject] @EmployeeId INT, @ProjectID INT
AS
BEGIN
    BEGIN TRANSACTION
    DECLARE @EmployeeProjects INT
    SET @EmployeeProjects = (
                                SELECT
                                    COUNT(*)
                                FROM [EmployeesProjects]
                                WHERE [EmployeeID] = @EmployeeId
                            )
    IF (@EmployeeProjects >= 3)
    BEGIN
        RAISERROR('The employee has too many projects!', 16, 1)
        ROLLBACK
    END
    INSERT INTO [EmployeesProjects]
    VALUES (@EmployeeId, @ProjectId)
    COMMIT
END
GO

-- 9.Delete Employees
CREATE TABLE [Deleted_Employees]
(
    [EmployeeId] INT PRIMARY KEY
    ,[FirstName] VARCHAR(50) NOT NULL
    ,[LastName] VARCHAR(50) NOT NULL
    ,[MiddleName] VARCHAR(50)
    ,[JobTitle] VARCHAR(50) NOT NULL
    ,[DepartmentId] INT FOREIGN KEY REFERENCES [Departments]([DepartmentId]) NOT NULL
    ,[Salary] MONEY NOT NULL
)
GO

CREATE TRIGGER [TR_DeletedEmployees]
ON [Employees] AFTER DELETE
AS
BEGIN
    INSERT INTO [Deleted_Employees]
    SELECT
        [FirstName]
        ,[LastName]
        ,[MiddleName]
        ,[JobTitle]
        ,[DepartmentId]
        ,[Salary]
    FROM [deleted]
END
GO