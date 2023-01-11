-- Problem 14.Car Rental Database
CREATE DATABASE [CarRental]
GO

USE [CarRental]
GO

CREATE TABLE [Categories]
(
    [Id] INT PRIMARY KEY IDENTITY
    ,[CategoryName] NVARCHAR(30) NOT NULL
    ,[DailyRate] INT NOT NULL
    ,[WeeklyRate] INT
    ,[MonthlyRate] INT
    ,[WeekendRate] INT NOT NULL
)
GO

CREATE TABLE [Cars]
(
    [Id] INT PRIMARY KEY IDENTITY
    ,[PlateNumber] NVARCHAR(20) NOT NULL
    ,[Manufacturer] NVARCHAR(20) NOT NULL
    ,[Model] NVARCHAR(20) NOT NULL
    ,[CarYear] INT NOT NULL
    ,[CategoryId] INT FOREIGN KEY REFERENCES [Categories] ([Id]) NOT NULL
    ,[Doors] INT NOT NULL
    CHECK ([Doors] = 3 OR [Doors] = 5)
    ,[Picture] VARBINARY(MAX)
    CHECK (DATALENGTH([Picture]) <= 900000)
    ,[Condition] NVARCHAR(20)
    ,[Available] BIT NOT NULL
)
GO

CREATE TABLE Employees
(
    [Id] INT PRIMARY KEY IDENTITY
    ,[FirstName] NVARCHAR(20) NOT NULL
    ,[LastName] NVARCHAR(20) NOT NULL
    ,[Title] NVARCHAR(20) NOT NULL
    ,[Notes] NVARCHAR(300)
)
GO

CREATE TABLE Customers
(
    [Id] INT PRIMARY KEY IDENTITY
    ,[DriverLicenseNumber] INT NOT NULL
    ,[FullName] NVARCHAR(80) NOT NULL
    ,[Address] NVARCHAR(80)
    ,[City] NVARCHAR(30)
    ,[ZIPCode] INT
    ,[Notes] NVARCHAR(300)
)
GO

CREATE TABLE [RentalOrders]
(
    [Id] INT PRIMARY KEY IDENTITY
    ,[EmployeeId] INT FOREIGN KEY REFERENCES [Employees] ([Id]) NOT NULL
    ,[CustomerId] INT FOREIGN KEY REFERENCES [Customers] ([Id]) NOT NULL
    ,[CarId] INT FOREIGN KEY REFERENCES [Cars] ([Id]) NOT NULL
    ,[TankLevel] INT NOT NULL
    ,[KilometrageStart] INT NOT NULL
    ,[KilometrageEnd] INT NOT NULL
    ,[TotalKilometrage] INT
    ,[StartDate] DATE NOT NULL
    ,[EndDate] DATE NOT NULL
    ,[TotalDays] INT
    ,[RateApplied] INT
    ,[TaxRate] INT
    ,[OrderStatus] NVARCHAR(30) NOT NULL
    ,[Notes] NVARCHAR(300)
)
GO

INSERT INTO [Categories] ([CategoryName], [DailyRate], [WeekendRate])
VALUES ('Hatchback', 35, 55)
    ,('SUV', 45, 60)
    ,('Sport', 70, 120)
GO

INSERT INTO [Cars] ([PlateNumber], [Manufacturer], [Model], [CarYear], [CategoryId], [Doors], [Available])
VALUES ('CA5516BB', 'Honda', 'Jazz', '2004', 1, 3, 1)
    ,('BA1287AK', 'BMW', '320i', '1998', 1, 5, 1)
    ,('CO9999BH', 'Mercedes', 'C63', '2013', 3, 5, 0)
GO

INSERT INTO [Employees] ([FirstName], [LastName], [Title])
VALUES ('John', 'Smith', 'Manager')
    ,('Peter', 'Roosevelt', 'Director')
    ,('Mark', 'Brown', 'Sales Navigator')
GO

INSERT INTO [Customers] ([FullName], [DriverLicenseNumber])
VALUES ('Maeve Wilkinson', 556976)
    ,('Cherish Oneal', 658923)
    ,('Jillian Gomez', 223659)
GO

INSERT INTO [RentalOrders]
(
    [EmployeeId], [CustomerId], [CarId],
    [TankLevel], [KilometrageStart], [KilometrageEnd],
    [StartDate], [EndDate], [OrderStatus]
)
VALUES (1, 3, 1, 20, 150233, 150289, '2022-05-18', '2022-05-22', 'Finished')
    ,(2, 2, 2, 43, 224568, 224702, '2018-04-13', '2018-04-18', 'Finished')
    ,(3, 1, 3, 15, 63000, 63215, '2014-08-25', '2014-08-31', 'Finished')
GO