-- Problem 15.Hotel Database
CREATE DATABASE [Hotel]
GO

USE [Hotel]

GO
CREATE TABLE [Employees]
(
    [Id] INT PRIMARY KEY IDENTITY
    ,[FirstName] NVARCHAR(30) NOT NULL
    ,[LastName] NVARCHAR(30) NOT NULL
    ,[Title] NVARCHAR(30) NOT NULL
    ,[Notes] NVARCHAR(300)
)

GO

CREATE TABLE [Customers]
(
    [AccountNumber] VARCHAR(10) NOT NULL
    ,[FirstName] NVARCHAR(30) NOT NULL
    ,[LastName] NVARCHAR(30) NOT NULL
    ,[PhoneNumber] VARCHAR(10) NOT NULL
    ,[EmergencyName] NVARCHAR(40)
    ,[EmergencyNumber] VARCHAR(20)
    ,[Notes] NVARCHAR(300)
)
GO

CREATE TABLE [RoomStatus]
(
    [RoomStatus] NVARCHAR(20) PRIMARY KEY
    ,[Notes] NVARCHAR(300)
)
GO

CREATE TABLE [RoomTypes]
(
    [RoomType] NVARCHAR(30) PRIMARY KEY
    ,[Notes] NVARCHAR(300)
)
GO

CREATE TABLE [BedTypes]
(
    [BedType] NVARCHAR(30) PRIMARY KEY
    ,[Notes] NVARCHAR(300)
)
GO

CREATE TABLE [Rooms]
(
    [RoomNumber] INT PRIMARY KEY IDENTITY
    ,[RoomType] NVARCHAR(30) FOREIGN KEY REFERENCES [RoomTypes]([RoomType]) NOT NULL
    ,[BedType] NVARCHAR(30) FOREIGN KEY REFERENCES [BedTypes]([BedType]) NOT NULL
    ,[Rate] DECIMAL(5, 2) NOT NULL
    ,[RoomStatus] NVARCHAR(20) FOREIGN KEY REFERENCES [RoomStatus]([RoomStatus]) NOT NULL
    ,[Notes] NVARCHAR(300)
)
GO

CREATE TABLE [Payments]
(
    [Id] INT PRIMARY KEY IDENTITY
    ,[EmployeeId] INT FOREIGN KEY REFERENCES [Employees]([Id]) NOT NULL
    ,[PaymentDate] DATETIME2 NOT NULL
    ,[AccountNumber] VARCHAR(20) NOT NULL
    ,[FirstDateOccupied] DATE NOT NULL
    ,[LastDateOccupied] DATE NOT NULL
    ,[TotalDays] INT
    ,[AmountCharged] DECIMAL(6, 2)
    ,[TaxRate] DECIMAL(4, 2)
    ,[TaxAmount] DECIMAL(5, 2)
    ,[PaymentTotal] DECIMAL(6, 2) NOT NULL
    ,[Notes] NVARCHAR(300)
)
GO

CREATE TABLE [Occupancies]
(
    [Id] INT PRIMARY KEY IDENTITY
    ,[EmployeeId] INT FOREIGN KEY REFERENCES [Employees]([Id]) NOT NULL
    ,[DateOccupied] DATE NOT NULL
    ,[AccountNumber] VARCHAR(20) NOT NULL
    ,[RoomNumber] INT FOREIGN KEY REFERENCES [Rooms]([RoomNumber]) NOT NULL
    ,[RateApplied] DECIMAL(5, 2) NOT NULL
    ,[PhoneCharge] DECIMAL(4, 2)
    ,[Notes] NVARCHAR(300)
)
GO

INSERT INTO [Employees]
    ([FirstName], [LastName], [Title])
VALUES ('George', 'Adams', 'Database administrator')
    ,('John', 'Rubber', 'Receptionist')
    ,('Kevin', 'Brown', 'Hotel Manager')
GO

INSERT INTO [Customers]
    ([FirstName], [LastName], [PhoneNumber], [AccountNumber])
VALUES ('Emeli', 'Marriott', '0895674226', '1268749955')
    ,('Orlando', 'Fields', '0888654418', '6598316855')
    ,('Krisha', 'Levy', '0885966377', '2266853794')
GO

INSERT INTO [RoomStatus]
    ([RoomStatus])
VALUES ('Occupied')
    ,('Cleaning')
    ,('Free')
GO

INSERT INTO [RoomTypes]
    ([RoomType])
VALUES ('Studio')
    ,('Balcony')
    ,('Beach')
GO

INSERT INTO [BedTypes]
    ([BedType])
VALUES ('Single')
    ,('Double')
    ,('King')
GO

INSERT INTO [Rooms]
    ([RoomType]
    ,[BedType]
    ,[Rate]
    ,[RoomStatus])
VALUES ('Balcony', 'Double', 35.00, 'Free')
    ,('Beach', 'Single', 25.50, 'Occupied')
    ,('Studio', 'King', 50.00, 'Cleaning')
GO

INSERT INTO [Payments]
    ([EmployeeId]
    ,[PaymentDate]
    ,[AccountNumber]
    ,[FirstDateOccupied]
    ,[LastDateOccupied]
    ,[PaymentTotal])
VALUES (1, GETDATE(), '1268749955', '2019-08-28', '2019-08-31', 250.00)
       ,(2, GETDATE(), '126987536', '2014-06-01', '2014-06-08', 365.50)
       ,(3, GETDATE(), '7855691265', '2021-07-12', '2021-07-14', 100.00)
GO

INSERT INTO [Occupancies]
    ([EmployeeId]
    ,[DateOccupied]
    ,[AccountNumber]
    ,[RoomNumber]
    ,[RateApplied])
VALUES (1, '2022-08-17', '1268749955', 1, 25.00)
    ,(2, '2022-07-07', '4568893278', 2, 35)
    ,(3, '2022-07-18', '7886593341', 3, 55.00)
GO

-- Problem 23.Decrease Tax Rate
UPDATE [Payments]
SET [TaxRate] = [TaxRate] - [TaxRate] *0.03
GO
SELECT [TaxRate]
FROM [Payments]
GO

-- Problem 24.Delete All Records
TRUNCATE TABLE [Occupancies]
GO