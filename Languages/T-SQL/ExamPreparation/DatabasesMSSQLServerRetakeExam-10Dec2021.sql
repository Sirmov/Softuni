CREATE DATABASE [Airport]
GO

USE [Airport]
GO

-- 1.Database design
CREATE TABLE [Passengers]
(
    [Id] INT PRIMARY KEY IDENTITY
    ,[FullName] VARCHAR(100) UNIQUE NOT NULL
    ,[Email] VARCHAR(50) UNIQUE NOT NULL
)
GO

CREATE TABLE [Pilots]
(
    [Id] INT PRIMARY KEY IDENTITY
    ,[FirstName] VARCHAR(30) UNIQUE NOT NULL
    ,[LastName] VARCHAR(30) UNIQUE NOT NULL
    ,[Age] TINYINT NOT NULL
    CHECK([Age] BETWEEN 21 AND 62)
    ,[Rating] FLOAT
    CHECK([Rating] BETWEEN 0.0 AND 10.0)
)
GO

CREATE TABLE [AircraftTypes]
(
    [Id] INT PRIMARY KEY IDENTITY
    ,[TypeName] VARCHAR(30) UNIQUE NOT NULL
)
GO

CREATE TABLE [Aircraft]
(
    [Id] INT PRIMARY KEY IDENTITY
    ,[Manufacturer] VARCHAR(25) NOT NULL
    ,[Model] VARCHAR(30) NOT NULL
    ,[Year] INT NOT NULL
    ,[FlightHours] INT
    ,[Condition] CHAR(1) NOT NULL
    ,[TypeId] INT NOT NULL
    FOREIGN KEY REFERENCES [AircraftTypes]([Id])
)
GO

CREATE TABLE [PilotsAircraft]
(
    [AircraftId] INT NOT NULL
    FOREIGN KEY REFERENCES [Aircraft]([Id])
    ,[PilotId] INT NOT NULL
    FOREIGN KEY REFERENCES [Pilots]([Id])
    ,PRIMARY KEY ([AircraftId], [PilotId])
)
GO

CREATE TABLE [Airports]
(
    [Id] INT PRIMARY KEY IDENTITY
    ,[AirportName] VARCHAR(70) UNIQUE NOT NULL
    ,[Country] VARCHAR(100) UNIQUE NOT NULL
)
GO

CREATE TABLE [FlightDestinations]
(
    [Id] INT PRIMARY KEY IDENTITY
    ,[AirportId] INT NOT NULL
    FOREIGN KEY REFERENCES [Airports]([Id])
    ,[Start] DATETIME NOT NULL
    ,[AircraftId] INT NOT NULL
    FOREIGN KEY REFERENCES [Aircraft]([Id])
    ,[PassengerId] INT NOT NULL
    FOREIGN KEY REFERENCES [Passengers]([Id])
    ,[TicketPrice] DECIMAL(18, 2) DEFAULT 15 NOT NULL
)
GO

-- 2.Insert
INSERT INTO [Passengers] ([FullName], [Email])
SELECT
    CONCAT([FirstName], ' ', [LastName]) AS [FullName]
    ,CONCAT([FirstName], [LastName], '@gmail.com') AS [Email]
FROM [Pilots]
WHERE [Id] BETWEEN 5 AND 15
GO

-- 3.Update
UPDATE [Aircraft]
SET [Condition] = 'A'
WHERE ([Condition] = 'C' OR [Condition] = 'B')
    AND ([FlightHours] IS NULL OR [FlightHours] <= 100)
    AND [Year] >= 2013
GO

-- 4.Delete
DELETE [Passengers]
WHERE LEN([FullName]) <= 10
GO

-- 5.Aircraft
SELECT
    [Manufacturer]
    ,[Model]
    ,[FlightHours]
    ,[Condition]
FROM [Aircraft]
ORDER BY [FlightHours] DESC
GO

-- 6.Pilots and Aircraft
SELECT
    [p].[FirstName]
    ,[p].[LastName]
    ,[a].[Manufacturer]
    ,[a].[Model]
    ,[a].[FlightHours]
FROM [Pilots] AS [p]
LEFT JOIN [PilotsAircraft] AS [pa]
ON [p].[Id] = [pa].[PilotId]
LEFT JOIN [Aircraft] AS [a]
ON [pa].[AircraftId] = [a].[Id]
WHERE [a].[FlightHours] IS NOT NULL AND [a].[FlightHours] <= 304
ORDER BY [a].[FlightHours] DESC, [p].[FirstName] ASC
GO

-- 7.Top 20 Flight Destinations
SELECT TOP 20
    [fd].[Id] AS [DestionationId]
    ,[fd].[Start]
    ,[p].[FullName]
    ,[a].[AirportName]
    ,[fd].[TicketPrice]
FROM [FlightDestinations] AS [fd]
JOIN [Passengers] AS [p]
ON [fd].[PassengerId] = [p].[Id]
JOIN [Airports] AS [a]
ON [fd].[AirportId] = [a].[Id]
WHERE DATEPART(DAY, [Start]) % 2 = 0
ORDER BY [TicketPrice] DESC, [AirportName] ASC
GO

-- 8.Number of Flights for Each Aircraft
SELECT
    [a].[Id] AS [AircraftId]
    ,[a].[Manufacturer]
    ,[a].[FlightHours]
    ,COUNT([fd].[Id]) AS [FlightDestinationsCount]
    ,ROUND(AVG([fd].[TicketPrice]), 2) AS [AvgPrice]
FROM [Aircraft] AS [a]
JOIN [FlightDestinations] AS [fd]
ON [a].[Id] = [fd].[AircraftId]
GROUP BY [a].[Id], [a].[Manufacturer], [a].[FlightHours]
HAVING COUNT([fd].[Id]) >= 2
ORDER BY [FlightDestinationsCount] DESC, [a].[Id] ASC
GO

-- 9.Regular Passengers
SELECT
    [p].[FullName]
    ,COUNT([fd].[AircraftId]) AS [CountOfAircraft]
    ,SUM([TicketPrice]) AS [TotalPayed]
FROM [Passengers] AS [p]
JOIN [FlightDestinations] AS [fd]
ON [p].[Id] = [fd].[PassengerId]
WHERE SUBSTRING([p].[FullName], 2, 1) = 'a'
GROUP BY [p].[FullName]
HAVING COUNT([fd].[AircraftId]) > 1
ORDER BY [p].[FullName] ASC
GO

-- 10.Full Info for Flight Destinations
SELECT
    [ap].[AirportName]
    ,[fd].[Start] AS [DayTime]
    ,[fd].[TicketPrice]
    ,[p].[FullName]
    ,[ac].[Manufacturer]
    ,[ac].[Model]
FROM [FlightDestinations] AS [fd]
JOIN [Aircraft] AS [ac]
ON [fd].[AircraftId] = [ac].[Id]
JOIN [Airports] AS [ap]
ON [fd].[AirportId] = [ap].[Id]
JOIN [Passengers] AS [p]
ON [fd].[PassengerId] = [p].[Id]
WHERE DATEPART(HOUR, [fd].[Start]) BETWEEN 6 AND 20
    AND [fd].[TicketPrice] > 2500
ORDER BY [ac].[Model] ASC
GO

-- 11.Find all Destinations by Email Address
CREATE FUNCTION [UDF_FlightDestinationsByEmail](@Email VARCHAR(50))
RETURNS INT
AS
BEGIN
    RETURN (
                SELECT
                    COUNT(*)
                FROM [Passengers] AS [p]
                JOIN [FlightDestinations] AS [fd]
                ON [p].[Id] = [fd].[PassengerId]
                WHERE [p].[Email] = 'Montacute@gmail.com'
           )
END
GO

-- 12.Full Info for Airports
CREATE PROC [USP_SearchByAirportName] @AirportName VARCHAR(70)
AS
BEGIN
    SELECT
        [ap].[AirportName]
        ,[p].[FullName]
        ,CASE
            WHEN [TicketPrice] <= 400 THEN 'Low'
            WHEN [TicketPrice] BETWEEN 401 AND 1500 THEN 'Medium'
            WHEN [TicketPrice] >= 1501 THEN 'High'
        END AS [LevelOfTickerPrice]
        ,[ac].[Manufacturer]
        ,[ac].[Condition]
        ,[at].[TypeName]
    FROM [FlightDestinations] AS [fd]
    JOIN [Airports] AS [ap]
    ON [fd].[AirportId] = [ap].[Id]
    JOIN [Aircraft] AS [ac]
    ON [fd].[AircraftId] = [ac].[Id]
    JOIN [Passengers] AS [p]
    ON [fd].[PassengerId] = [p].[Id]
    JOIN [AircraftTypes] AS [at]
    ON [ac].[TypeId] = [at].[Id]
    WHERE [ap].[AirportName] = @AirportName
    ORDER BY [ac].[Manufacturer] ASC, [p].[FullName] ASC
END
GO