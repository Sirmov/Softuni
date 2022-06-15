CREATE DATABASE [Bitbucket]
GO

USE [Bitbucket]
GO

-- 1.Database Design
CREATE TABLE [Users]
(
    [Id] INT PRIMARY KEY IDENTITY
    ,[Username] VARCHAR(30) NOT NULL
    ,[Password] VARCHAR(30) NOT NULL
    ,[Email] VARCHAR(50) NOT NULL
)
GO

CREATE TABLE [Repositories]
(
    [Id] INT PRIMARY KEY IDENTITY
    ,[Name] VARCHAR(50) NOT NULL 
)
GO

CREATE TABLE [RepositoriesContributors]
(
    [RepositoryId] INT FOREIGN KEY REFERENCES [Repositories]([Id]) NOT NULL
    ,[ContributorId] INT FOREIGN KEY REFERENCES [Users]([Id]) NOT NULL
    ,PRIMARY KEY ([RepositoryId], [ContributorId])
)
GO

CREATE TABLE [Issues]
(
    [Id] INT PRIMARY KEY IDENTITY
    ,[Title] VARCHAR(255) NOT NULL
    ,[IssueStatus] VARCHAR(6) NOT NULL
    ,[RepositoryId] INT FOREIGN KEY REFERENCES [Repositories]([Id]) NOT NULL
    ,[AssigneeId] INT FOREIGN KEY REFERENCES [Users]([Id]) NOT NULL
)
GO

CREATE TABLE [Commits]
(
    [Id] INT PRIMARY KEY IDENTITY
    ,[Message] VARCHAR(255) NOT NULL
    ,[IssueId] INT FOREIGN KEY REFERENCES [Issues]([Id])
    ,[RepositoryId] INT FOREIGN KEY REFERENCES [Repositories]([Id]) NOT NULL
    ,[ContributorId] INT FOREIGN KEY REFERENCES [Users]([Id]) NOT NULL
)
GO

CREATE TABLE [Files]
(
    [Id] INT PRIMARY KEY IDENTITY
    ,[Name] VARCHAR(100) NOT NULL
    ,[Size] DECIMAL(18, 4) NOT NULL
    ,[ParentId] INT FOREIGN KEY REFERENCES [Files]([Id])
    ,[CommitId] INT FOREIGN KEY REFERENCES [Commits]([Id])
)
GO

-- 2.Insert
INSERT INTO [Files] ([Name], [Size], [ParentId], [CommitId])
VALUES ('Trade.idk', 2598.0, 1, 1)
,('menu.net', 9238.31, 2, 2)
,('Administrate.soshy', 1246.93, 3, 3)
,('Controller.php', 7353.15, 4, 4)
,('Find.java', 9957.86, 5, 5)
,('Controller.json', 14034.87, 3, 6)
,('Operate.xix', 7662.92, 7, 7)
GO

INSERT INTO [Issues] ([Title], [IssueStatus], [RepositoryId], [AssigneeId])
VALUES ('Critical Problem with HomeController.cs file', 'open', 1, 4)
,('Typo fix in Judge.html', 'open', 4, 3)
,('Implement documentation for UsersService.cs', 'closed', 8, 2)
,('Unreachable code in Index.cs', 'open', 9, 8)
GO

-- 3.Update
UPDATE [Issues]
SET [IssueStatus] = 'closed'
WHERE [AssigneeId] = 6
GO

-- 4.Delete
DELETE FROM [Files]
WHERE [CommitId] = (
                            SELECT [Id]
                            FROM [Commits]
                            WHERE [RepositoryId] = (
                                                        SELECT [Id]
                                                        FROM [Repositories]
                                                        WHERE [Name] = 'Softuni-Teamwork'
                                                   )
                   )
GO

DELETE FROM [Commits]
WHERE [RepositoryId] = (
                            SELECT [Id]
                            FROM [Repositories]
                            WHERE [Name] = 'Softuni-Teamwork'
                       )
GO

DELETE FROM [Issues]
WHERE [RepositoryId] = (
                            SELECT [Id]
                            FROM [Repositories]
                            WHERE [Name] = 'Softuni-Teamwork'
                       )
GO

DELETE FROM [RepositoriesContributors]
WHERE [RepositoryId] = (
                            SELECT [Id]
                            FROM [Repositories]
                            WHERE [Name] = 'Softuni-Teamwork'
                       )
GO

DELETE FROM [Repositories]
WHERE [Name] = 'Softuni-Teamwork'
GO

-- 5.Commits
SELECT
    [Id]
    ,[Message]
    ,[RepositoryId]
    ,[ContributorId]
FROM [Commits]
ORDER BY [Id], [Message], [RepositoryId], [ContributorId]
GO

-- 6.Front-end
SELECT
    [Id]
    ,[Name]
    ,[Size]
FROM [Files]
WHERE [Size] > 1000 AND [Name] LIKE '%html%'
ORDER BY [Size] DESC, [Id] ASC, [Name] ASC
GO

-- 7.Issue Assignment
SELECT
    [i].[Id]
    ,CONCAT([u].[Username], ' : ', [i].[Title]) AS [IssueAssignee]
FROM [Users] AS [u]
JOIN [Issues] AS [i]
ON [u].[Id] = [i].[AssigneeId]
ORDER BY [i].[Id] DESC, [i].[AssigneeId] ASC
GO

-- 8.Single Files
SELECT
    [fp].[Id]
    ,[fp].[Name]
    ,CONCAT([fp].[Size], 'KB') AS [Size]
FROM [Files] AS [fch]
FULL JOIN [Files] AS [fp]
ON [fch].[ParentId] = [fp].[Id]
WHERE [fch].[Id] IS NULL
ORDER BY [fp].[Id], [fp].[Name], [fp].[Size] DESC
GO

-- 9.Commits in Repositories
SELECT TOP 5
    [r].[Id]
    ,[r].[Name]
    ,COUNT([c].[Id]) AS [Commits]
FROM [Repositories] AS [r]
LEFT JOIN [Commits] AS [c]
ON [r].[Id] = [c].[RepositoryId]
LEFT JOIN [RepositoriesContributors] AS [rc]
ON [r].[Id] = [rc].[RepositoryId]
GROUP BY [r].[Id], [r].[Name]
ORDER BY [Commits] DESC, [r].[Id], [r].[Name]
GO

-- 10.Average Size
SELECT
    [u].[Username]
    ,AVG([f].[Size]) AS [Size]
FROM [Users] AS [u]
JOIN [Commits] AS [c]
ON [u].[Id] = [c].[ContributorId]
JOIN [Files] AS [f]
ON [c].[Id] = [f].[CommitId]
GROUP BY [u].[Username]
ORDER BY [Size] DESC, [u].[Username] ASC
GO

-- 11.All User Commits
CREATE FUNCTION [UDF_AllUserCommits](@Username VARCHAR(30))
RETURNS INT
AS
BEGIN
    RETURN (SELECT
        COUNT(*)
    FROM [Users] AS [u]
    JOIN [Commits] AS [c]
    ON [u].[Id] = [c].[ContributorId]
    WHERE [Username] = @Username)
END
GO

-- 12. Search for Files
CREATE PROC [USP_SearchForFiles] @FileExtension VARCHAR(30)
AS
BEGIN
    SELECT
        [Id]
        ,[Name]
        ,CONCAT([Size], 'KB') AS [Size]
    FROM [Files]
    WHERE [Name] LIKE CONCAT('%.', @FileExtension)
END
GO