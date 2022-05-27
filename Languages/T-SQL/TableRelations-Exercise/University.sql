-- Problem 6.University Database
CREATE DATABASE [University]
GO

USE [University]
GO

CREATE TABLE [Majors]
(
    [MajorID] INT PRIMARY KEY IDENTITY
    ,[Name] VARCHAR(50) NOT NULL
)
GO

CREATE TABLE [Students]
(
    [StudentID] INT PRIMARY KEY IDENTITY
    ,[StudentNumber] VARCHAR(10)
    ,[StudentName] NVARCHAR(50)
    ,[MajorID] INT NOT NULL
    FOREIGN KEY REFERENCES [Majors]([MajorID])
)
GO

CREATE TABLE [Subjects]
(
    [SubjectID] INT PRIMARY KEY IDENTITY
    ,[SubjectName] VARCHAR(50) NOT NULL
)
GO

CREATE TABLE [Agenda]
(
    [StudentID] INT
    ,[SubjectID] INT
    ,CONSTRAINT [PK_Agenda]
    PRIMARY KEY ([StudentID], [SubjectID])
    ,CONSTRAINT [FK_Agenda_Students]
    FOREIGN KEY ([StudentID]) REFERENCES [Students]([StudentID])
    ,CONSTRAINT [FK_Agenda_Subjects]
    FOREIGN KEY ([SubjectID]) REFERENCES [Subjects]([SubjectID])
)
GO

CREATE TABLE [Payments]
(
    [PaymentID] INT PRIMARY KEY IDENTITY
    ,[PaymentDate] DATETIME2 NOT NULL
    ,[PaymentAmount] DECIMAL(7, 2) NOT NULL
    ,[StudentID] INT NOT NULL
    FOREIGN KEY REFERENCES [Students]([StudentID])
)
GO