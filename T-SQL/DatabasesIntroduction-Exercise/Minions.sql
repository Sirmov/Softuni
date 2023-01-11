-- Problem 1.Create Database
CREATE DATABASE [Minions]

USE [Minions]

-- Problem 2.Create Tables
CREATE TABLE [Minions]
(
	[Id] INT PRIMARY KEY
	,[Name] NVARCHAR(50)
	,[Age] INT
)

CREATE TABLE [Towns]
(
	[Id] INT PRIMARY KEY
	,[Name] NVARCHAR(50)
)

-- Problem 3.Alter Minions Table
ALTER TABLE [Minions]
ADD [TownId] INT FOREIGN KEY REFERENCES [Towns] ([Id])

-- Problem 4.Insert Records in Both Tables
INSERT INTO [Towns] ([Id], [Name])
VALUES (1, 'Sofia')
	,(2, 'Plovdiv')
	,(3, 'Varna')

INSERT INTO [Minions] ([Id], [Name], [Age], [TownId])
VALUES (1, 'Kevin', 22, 1)
	,(2, 'Bob', 15, 3)
	,(3, 'Steward', NULL, 2)

-- Problem 5.Truncate Table Minions
TRUNCATE TABLE [Minions]

-- Problem 6.Drop All Tables
DROP TABLE [Minions], [Towns]

-- Problem 7.Create Table People
CREATE TABLE [People]
(
	[Id] INT PRIMARY KEY IDENTITY(1, 1)
	,[Name] NVARCHAR(200) NOT NULL
	,[Picture] VARBINARY(MAX)
	CHECK (DATALENGTH([Picture]) <= 2000000)
	,[Height] DECIMAL(3, 2)
	,[Weight] DECIMAL(5, 2)
	,[Gender] CHAR(1) NOT NULL
	CHECK ([Gender] = 'm' OR [Gender] = 'f')
	,[Birthdate] DATE NOT NULL
	,[Biography] NVARCHAR(MAX)
)

INSERT INTO [People] ([Name], [Height], [Weight], [Gender], [Birthdate])
VALUES ('Nikola', 1.75, 60.2, 'm', '2004-02-13')
	,('Mariq', 1.63, 47.3, 'f', '2002-08-18')
	,('Peter', 1.79, 75.5, 'm', '1998-03-22')
	,('Hristiqna', 1.78, 44.1, 'f', '1994-07-16')
	,('Gospodin', 1.96, 112.2, 'm', '2000-11-10')

-- Problem 8.Create Table Users
CREATE TABLE [Users]
(
	[Id] BIGINT PRIMARY KEY IDENTITY(1, 1)
	,[Username] VARCHAR(30) NOT NULL
	,[Password] VARCHAR(26) NOT NULL
	,[ProfilePicture] VARBINARY(MAX)
	CHECK ([ProfilePicture] <= 900000)
	,[LastLoginTime] DATETIME2
	,[IsDeleted] BIT
)

INSERT INTO [Users] ([Username], [Password], [IsDeleted])
VALUES ('Nikola', '87654321', 0)
,('George', '135790', 0)
,('Margaret', '12345', 1)
,('John', '246810', 0)
,('Peter', 'mypaSSword', 0)

-- Problem 9.Change Primary Key
ALTER TABLE [Users]
DROP CONSTRAINT [PK__Users__3214EC076BE95FB5]

ALTER TABLE [Users]
ADD CONSTRAINT [PK_User] PRIMARY KEY ([Id], [Username])

-- Problem 10.Add Check Constraint
ALTER TABLE [Users]
ADD CONSTRAINT [CK_Users_PasswordMinLength]
CHECK (DATALENGTH([Password]) > 4)

-- Problem 11.Set Default Value of a Field
ALTER TABLE [Users]
ADD CONSTRAINT [DF_Users_LastLoginTime]
DEFAULT GETDATE() FOR [LastLoginTime]

-- Problem 12.Set Unique Field
ALTER TABLE [Users]
DROP CONSTRAINT [PK_User]

ALTER TABLE [Users]
ADD CONSTRAINT [PK_User] PRIMARY KEY ([Id])

ALTER TABLE [Users]
ADD CONSTRAINT [UC_Users_Username]
UNIQUE ([Username])

ALTER TABLE [Users]
ADD CONSTRAINT [CK_Users_UsernameMinLength]
CHECK (DATALENGTH([Username]) > 2)
