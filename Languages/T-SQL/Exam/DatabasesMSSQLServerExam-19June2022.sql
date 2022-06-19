CREATE DATABASE [Zoo]
GO

USE [Zoo]
GO

-- 1.Database design
CREATE TABLE [Owners]
(
    [Id] INT PRIMARY KEY IDENTITY
    ,[Name] VARCHAR(50) NOT NULL
    ,[PhoneNumber] VARCHAR(15) NOT NULL
    ,[Address] VARCHAR(50)
)

CREATE TABLE [AnimalTypes]
(
    [Id] INT PRIMARY KEY IDENTITY
    ,[AnimalType] VARCHAR(30) NOT NULL
)

CREATE TABLE [Cages]
(
    [Id] INT PRIMARY KEY IDENTITY
    ,[AnimalTypeId] INT NOT NULL
    FOREIGN KEY REFERENCES [AnimalTypes]([Id])
)

CREATE TABLE [Animals]
(
    [Id] INT PRIMARY KEY IDENTITY
    ,[Name] VARCHAR(30) NOT NULL
    ,[BirthDate] DATE NOT NULL
    ,[OwnerId] INT FOREIGN KEY REFERENCES [Owners]([Id])
    ,[AnimalTypeId] INT NOT NULL
    FOREIGN KEY REFERENCES [AnimalTypes]([Id])
)

CREATE TABLE [AnimalsCages]
(
    [CageId] INT NOT NULL
    FOREIGN KEY REFERENCES [Cages]([Id])
    ,[AnimalId] INT NOT NULL
    FOREIGN KEY REFERENCES [Animals]([Id])
    ,PRIMARY KEY ([CageId], [AnimalId])
)

CREATE TABLE [VolunteersDepartments]
(
    [Id] INT PRIMARY KEY IDENTITY
    ,[DepartmentName] VARCHAR(30) NOT NULL
)

CREATE TABLE [Volunteers]
(
    [Id] INT PRIMARY KEY IDENTITY
    ,[Name] VARCHAR(50) NOT NULL
    ,[PhoneNumber] VARCHAR(15) NOT NULL
    ,[Address] VARCHAR(50)
    ,[AnimalId] INT FOREIGN KEY REFERENCES [Animals]([Id])
    ,[DepartmentId] INT NOT NULL
    FOREIGN KEY REFERENCES [VolunteersDepartments]([Id])
)

-- 2.Insert
INSERT INTO [Volunteers] ([Name], [PhoneNumber], [Address], [AnimalId], [DepartmentId])
VALUES ('Anita Kostova', '0896365412', 'Sofia, 5 Rosa str.', 15, 1)
    ,('Dimitur Stoev', '0877564223', null, 42, 4)
    ,('Kalina Evtimova', '0896321112', 'Silistra, 21 Breza str.', 9, 7)
    ,('Stoyan Tomov', '0898564100', 'Montana, 1 Bor str.', 18, 8)
    ,('Boryana Mileva', '0888112233', null, 31, 5)

INSERT INTO [Animals] ([Name], [BirthDate], [OwnerId], [AnimalTypeId])
VALUES ('Giraffe', '2018-09-21', 21, 1)
    ,('Harpy Eagle', '2015-04-17', 15, 3)
    ,('Hamadryas Baboon', '2017-11-02', null, 1)
    ,('Tuatara', '2021-06-30', 2, 4)

-- 3.Update
UPDATE [Animals]
SET [OwnerId] = 4
WHERE [OwnerId] IS NULL

-- 4.Delete
DELETE FROM [Volunteers]
WHERE [DepartmentId] = 2

DELETE FROM [VolunteersDepartments]
WHERE [Id] = 2

-- 5.Volunteers
SELECT
    [Name]
    ,[PhoneNumber]
    ,[Address]
    ,[AnimalId]
    ,[DepartmentId]
FROM [Volunteers]
ORDER BY [Name] ASC, [AnimalId] ASC, [DepartmentId] ASC

-- 6.Animals data
SELECT
    [a].[Name]
    ,[at].[AnimalType]
    ,FORMAT([a].[BirthDate], 'dd.MM.yyyy') AS [BirthDate]
FROM [Animals] AS [a]
LEFT JOIN [AnimalTypes] AS [at]
ON [a].[AnimalTypeId] = [at].[Id]
ORDER BY [a].[Name] ASC

-- 7.Owners and Their Animals
SELECT TOP 5
    [o].[Name]
    ,COUNT([a].[Id]) AS [CountOfAnimals]
FROM [Owners] as [o]
LEFT JOIN [Animals] AS [a]
ON [o].[Id] = [a].[OwnerId]
GROUP BY [o].[Name]
ORDER BY [CountOfAnimals] DESC, [o].[Name] ASC

-- 8.Owners, Animals and Cages
SELECT
    CONCAT([o].[Name], '-', [a].[Name]) AS [OwnersAnimals]
    ,[o].[PhoneNumber]
    ,[ac].[CageId]
FROM [Owners] AS [o]
JOIN [Animals] AS [a]
ON [o].[Id] = [a].[OwnerId]
JOIN [AnimalTypes] AS [at]
ON [a].[AnimalTypeId] = [at].[Id]
JOIN [AnimalsCages] AS [ac]
ON [a].[Id] = [ac].[AnimalId]
WHERE [at].[AnimalType] = 'mammals'
ORDER BY [o].[Name] ASC, [a].[Name] DESC

-- 9.Volunteers in Sofia
SELECT
    [v].[Name]
    ,[v].[PhoneNumber]
    ,REPLACE(REPLACE([v].[Address], 'Sofia, ', ''), 'Sofia , ', '') AS [Address]
FROM [Volunteers] AS [v]
JOIN [VolunteersDepartments] AS [vd]
ON [v].[DepartmentId] = [vd].[Id]
WHERE [v].[DepartmentId] = 2
    AND [v].[Address] LIKE '%Sofia%'
ORDER BY [v].[Name] ASC

-- 10.Animals for Adoption
SELECT
    [a].[Name]
    ,DATEPART(YEAR, [a].[Birthdate]) AS [BirthYear]
    ,[at].[AnimalType]
FROM [Animals] AS [a]
JOIN [AnimalTypes] AS [at]
ON [a].[AnimalTypeId] = [at].[Id]
WHERE [a].[OwnerId] IS NULL
    AND DATEDIFF(YEAR, [a].[Birthdate], '01/01/2022') < 5
    AND [at].[AnimalType] <> 'Birds'
ORDER BY [a].[Name] ASC
GO

-- 11.All Volunteers in a Department
CREATE FUNCTION [UDF_GetVolunteersCountFromADepartment](@VolunteersDepartment VARCHAR(50))
RETURNS INT
AS
BEGIN
    RETURN (
                SELECT
                    COUNT(*)
                FROM [Volunteers] AS [v]
                JOIN [VolunteersDepartments] AS [vd]
                ON [v].[DepartmentId] = [vd].[Id]
                WHERE [vd].[DepartmentName] = @VolunteersDepartment
           )
END
GO

-- 12.Animals with Owner or Not
CREATE PROC [USP_AnimalsWithOwnersOrNot] @AnimalName VARCHAR(50)
AS
BEGIN
    SELECT
        [a].[Name]
        ,COALESCE([o].[Name], 'For adoption') AS [OwnersName]
    FROM [Animals] AS [a]
    LEFT JOIN [Owners] AS [o]
    ON [a].[OwnerId] = [o].[Id]
    WHERE [a].[Name] = @AnimalName
END