CREATE DATABASE [Movies]

GO

USE [Movies]

GO

CREATE TABLE [Directors]
(
    [Id] INT PRIMARY KEY IDENTITY(1, 1)
    ,[DirectorName] NVARCHAR(50) NOT NULL
    ,[Notes] NVARCHAR(300)
)

GO

CREATE TABLE [Genres]
(
    [Id] INT PRIMARY KEY IDENTITY(1, 1)
    ,[GenreName] NVARCHAR(30) NOT NULL
    ,[Notes] NVARCHAR(300)
)

GO

CREATE TABLE [Categories]
(
    [Id] INT PRIMARY KEY IDENTITY(1, 1)
    ,[CategoryName] NVARCHAR(30) NOT NULL
    ,[Notes] NVARCHAR(300)
)

GO

CREATE TABLE [Movies]
(
    [Id] INT PRIMARY KEY IDENTITY(1, 1)
    ,[Title] NVARCHAR(50) NOT NULL
    ,[DirectorId] INT FOREIGN KEY REFERENCES [Directors]([Id]) NOT NULL
    ,[CopyrightYear]  DATE NOT NULL
    ,[Length] INT NOT NULL
    ,[GenreId] INT FOREIGN KEY REFERENCES [Genres](Id) NOT NULL
    ,[CategoryId] INT FOREIGN KEY REFERENCES [Categories](Id) NOT NULL
    ,[Rating] DECIMAL(2, 1) NOT NULL
    CHECK ([Rating] >= 0 AND [Rating] <= 5)
    ,[Notes] NVARCHAR(300)
)

GO

INSERT INTO [Directors] ([DirectorName])
VALUES ('Steven Spielberg')
    ,('Alfred Hitchcock')
    ,('Stanley Kubrick')
    ,('Quentin Tarantino')
    ,('Tim Burton')

GO

INSERT INTO [Genres] ([GenreName])
VALUES ('Action')
    ,('Drama')
    ,('Comedy')
    ,('Fantasy')
    ,('Horror')

GO

INSERT INTO [Categories] ([CategoryName])
VALUES ('Silent film')
    ,('Adult')
    ,('Animation')
    ,('Documentary')
    ,('Western')

GO

INSERT INTO [Movies] ([Title], [DirectorId], [CopyrightYear], [Length], [GenreId], [CategoryId], [Rating])
VALUES ('The Shawshank Redemption', 1, '1994-01-01', 126, 2, 3, 4.8)
    ,('12 Angry Men', 3, '1957-01-01', 140, 3, 2, 4.3)
    ,('The lord of the rings', 5, '2003-01-01', 168, 4, 4, 4.2)
    ,('Fight club', 4, '1999-01-01', 132, 3, 5, 4.0)
    ,('The Matrix', 1 ,'1999-01-01', 139, 5, 1, 5.0)