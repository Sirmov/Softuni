CREATE DATABASE [TableRelations]
GO

USE [TableRelations]
GO

-- Problem 1.One-To-One Relationship
CREATE TABLE [Passports]
(
    [PassportID] INT
    CONSTRAINT [PK_Passports]
    PRIMARY KEY ([PassportID])
    ,[PassportNumber] VARCHAR(8) NOT NULL
    CONSTRAINT [UQ_PassportNumber]
    UNIQUE([PassportNumber])
)
GO

CREATE TABLE [Persons]
(
    [PersonID] INT PRIMARY KEY IDENTITY
    ,[FirstName] NVARCHAR(30) NOT NULL
    ,[Salary] DECIMAL(7, 2) NOT NULL
    ,[PassportID] INT NOT NULL
    CONSTRAINT [FK_Persons_Passports]
    FOREIGN KEY ([PassportID]) REFERENCES [Passports]([PassportID])
)
GO

INSERT INTO [Passports]
    ([PassportID]
    ,[PassportNumber])
VALUES
    (101, 'N34FG21B')
    ,(102, 'K65LO4R7')
    ,(103, 'ZE657QP2')
GO

INSERT INTO [Persons]
    ([FirstName]
    ,[Salary]
    ,[PassportID])
VALUES
    ('Roberto', 43300.00, 102)
    ,('Tom', 56100.00, 103)
    ,('Yana', 60200.00, 101)
GO

-- Problem 2.One-To-Many Relationship
CREATE TABLE [Manufacturers]
(
    [ManufacturerID] INT PRIMARY KEY IDENTITY
    ,[Name] NVARCHAR(50) UNIQUE NOT NULL
    ,[EstablishedOn] DATE NOT NULL
)
GO

CREATE TABLE [Models]
(
    [ModelID] INT PRIMARY KEY IDENTITY(101, 1)
    ,[Name] NVARCHAR(50) NOT NULL
    ,[ManufacturerID] INT NOT NULL
    FOREIGN KEY REFERENCES [Manufacturers]([ManufacturerID])
)
GO

INSERT INTO [Manufacturers]
    ([Name]
    ,[EstablishedOn])
VALUES
    ('BMW', '07/03/1916')
    ,('Tesla', '01/01/2003')
    ,('Lada', '01/05/1966')
GO

INSERT INTO [Models]
    ([Name]
    ,[ManufacturerID])
VALUES
    ('X1', 1)
    ,('i6', 1)
    ,('Model S', 2)
    ,('Model X', 2)
    ,('Model 3', 2)
    ,('Nove', 3)
GO

-- Problem 3.Many-To-Many Relationship
CREATE TABLE [Students]
(
    [StudentID] INT PRIMARY KEY IDENTITY
    ,[Name] NVARCHAR(40) NOT NULL
)
GO

CREATE TABLE [Exams]
(
    [ExamID] INT PRIMARY KEY IDENTITY(101, 1)
    ,[Name] NVARCHAR(50) NOT NULL
)
GO

CREATE TABLE [StudentsExams]
(
    [StudentID] INT
    ,[ExamID] INT
    ,CONSTRAINT [PK_StudentsExams]
    PRIMARY KEY ([StudentID], [ExamID])
    ,CONSTRAINT [FK_StudentsExam_Students]
    FOREIGN KEY ([StudentID]) REFERENCES [Students]([StudentID])
    ,CONSTRAINT [FK_StudentsExam_Exams]
    FOREIGN KEY ([ExamID]) REFERENCES [Exams]([ExamID])
)
GO

INSERT INTO [Students]
    ([Name])
VALUES 
    ('Mila')
    ,('Toni')
    ,('Ron')
GO

INSERT INTO [Exams]
    ([Name])
VALUES
    ('SpringMVC')
    ,('Neo4j')
    ,('Oracle 11g')
GO

INSERT INTO [StudentsExams]
    ([StudentID]
    ,[ExamID])
VALUES
    (1, 101)
    ,(1, 102)
    ,(2, 101)
    ,(3, 103)
    ,(2, 102)
    ,(2, 103)
GO

-- Problem 4.Self-Referencing
CREATE TABLE [Teachers]
(
    [TeacherID] INT PRIMARY KEY IDENTITY(101, 1)
    ,[Name] NVARCHAR(40) NOT NULL
    ,[ManagerID] INT
    FOREIGN KEY REFERENCES [Teachers]([TeacherID])
)
GO

INSERT INTO [Teachers]
    ([Name]
    ,[ManagerID])
VALUES
    ('John', NULL)
    ,('Maya', 106)
    ,('Silvia', 106)
    ,('Ted', 105)
    ,('Mark', 101)
    ,('Greta', 101)
GO

-- Problem 9.*Peaks in Rila
USE [Geography]
GO

SELECT 
    [m].[MountainRange]
    ,[p].[PeakName]
    ,[p].[Elevation]
FROM [Mountains] AS m
LEFT JOIN [Peaks] AS p
ON [p].[MountainID] = m.[Id]
WHERE [MountainRange] = 'Rila'
ORDER BY [p].[Elevation] DESC
GO