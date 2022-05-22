-- Problem 16.Create SoftUni Database
CREATE DATABASE [Softuni]
GO

USE [Softuni]
GO

CREATE TABLE [Towns]
(
    [Id] INT PRIMARY KEY IDENTITY
    ,[Name] NVARCHAR(50) NOT NULL
)
GO

CREATE TABLE [Addresses]
(
    [Id] INT PRIMARY KEY IDENTITY
    ,[AddressText] NVARCHAR(150) NOT NULL
    ,[TownId] INT FOREIGN KEY REFERENCES [Towns]([Id]) NOT NULL
)
GO

CREATE TABLE [Departments]
(
    [Id] INT PRIMARY KEY IDENTITY
    ,[Name] NVARCHAR(50) NOT NULL
)
GO

CREATE TABLE [Employees]
(
    [Id] INT PRIMARY KEY IDENTITY
    ,[FirstName] NVARCHAR(30) NOT NULL
    ,[MiddleName] NVARCHAR(30) NOT NULL
    ,[LastName] NVARCHAR(30) NOT NULL
    ,[JobTitle] NVARCHAR(30) NOT NULL
    ,[DepartmentId] INT FOREIGN KEY REFERENCES [Departments]([Id]) NOT NULL
    ,[HireDate] DATE NOT NULL
    ,[Salary] DECIMAL(9, 2) NOT NULL
    ,[AddressId] INT FOREIGN KEY REFERENCES [Addresses]([Id])
)
GO

-- Problem 17.Backup Database
BACKUP DATABASE [Softuni]
TO DISK = N'/var/opt/mssql/data/softuni-backup.bak'
GO

DROP DATABASE [Softuni]
GO

RESTORE DATABASE [Softuni]
FROM DISK = N'/var/opt/mssql/data/softuni-backup.bak'
GO

-- Problem 18.Basic Insert
INSERT INTO [Towns]
    ([Name])
VALUES
    ('Sofia')
    ,('Plovdiv')
    ,('Varna')
    ,('Burgas')
GO

INSERT INTO [Departments]
    ([Name])
VALUES
    ('Engineering')
    ,('Sales')
    ,('Marketing')
    ,('Software Development')
    ,('Quality Assurance')
GO

INSERT INTO [Employees]
    ([FirstName]
    ,[MiddleName]
    ,[LastName]
    ,[JobTitle]
    ,[DepartmentId]
    ,[HireDate]
    ,[Salary])
VALUES
    ('Ivan', 'Ivanov', 'Ivanov', '.NET Developer', 4, '2013-02-01', 3500.00)
    ,('Petar', 'Petrov', 'Petrov', 'Senior Engineer', 1, '2004-03-02', 4000)
    ,('Maria', 'Petrova', 'Ivanova', 'Intern', 5, '2016-08-28', 525.25)
    ,('Georgi', 'Teziev', 'Ivanov', 'CEO', 2, '2007-12-09', 3000)
    ,('Petar', 'Pan', 'Pan', 'Intern', 3, '2016-08-28', 599.88)
GO

-- Problem 19.Basic Select All Fields
SELECT *
FROM [Towns]

SELECT *
FROM [Departments]

SELECT *
FROM [Employees]

-- Problem 20.Basic Select All Fields and Order Them
SELECT *
FROM [Towns]
ORDER BY [Name] ASC

SELECT *
FROM [Departments]
ORDER BY [Name] ASC

SELECT *
FROM [Employees]
ORDER BY [Salary] DESC

-- Problem 21.Basic Select Some Fields
SELECT 
    [Name]
FROM [Towns]
ORDER BY [Name] ASC

SELECT 
    [Name]
FROM [Departments]
ORDER BY [Name] ASC

SELECT 
    [FirstName]
    ,[LastName]
    ,[JobTitle]
    ,[Salary]
FROM [Employees]
ORDER BY [Salary] DESC

-- Problem 22.Increase Employees Salary
UPDATE [Employees]
SET [Salary] = [Salary] + [Salary] * 0.1
GO
SELECT [Salary]
FROM [Employees]
GO