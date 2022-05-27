-- Problem 5.Online Store Database
CREATE DATABASE [OnlineStore]
GO

USE [OnlineStore]
GO

CREATE TABLE [Cities]
(
    [CityID] INT PRIMARY KEY IDENTITY
    ,[Name] VARCHAR(50) NOT NULL
)
GO

CREATE TABLE [Customers]
(
    [CustomerID] INT PRIMARY KEY IDENTITY
    ,[Name] VARCHAR(50) NOT NULL
    ,[Birthday] DATE
    ,[CityID] INT
    FOREIGN KEY REFERENCES [Cities]([CityID])
)
GO

CREATE TABLE [ItemTypes]
(
    [ItemTypeID] INT PRIMARY KEY IDENTITY
    ,[Name] VARCHAR(50) NOT NULL
)
GO

CREATE TABLE [Items]
(
    [ItemID] INT PRIMARY KEY IDENTITY
    ,[Name] VARCHAR(50) NOT NULL
    ,[ItemTypeID] INT
    FOREIGN KEY REFERENCES [ItemTypes]([ItemTypeID])
)
GO

CREATE TABLE [Orders]
(
    [OrderID] INT PRIMARY KEY IDENTITY
    ,[CustomerID] INT NOT NULL
    FOREIGN KEY REFERENCES [Customers]([CustomerID])
)
GO

CREATE TABLE [OrderItems]
(
    [OrderID] INT
    ,[ItemID] INT
    ,CONSTRAINT [PK_OrderItems]
    PRIMARY KEY([OrderID], [ItemID])
    ,CONSTRAINT [FK_OrderItems_Orders]
    FOREIGN KEY ([OrderID]) REFERENCES [Orders]([OrderID])
    ,CONSTRAINT [FK_OrderItems_Items]
    FOREIGN KEY ([ItemID]) REFERENCES [Items]([ItemID])
)
GO