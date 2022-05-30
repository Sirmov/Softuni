USE [Diablo]
GO

-- Problem 14.Games from 2011 and 2012 year
SELECT TOP 50
    [Name]
    ,FORMAT([Start], 'yyyy-MM-dd') AS [Start]
FROM [Games]
WHERE DATEPART(YEAR, [Start]) BETWEEN 2011 AND 2012
ORDER BY [Start], [Name]
GO

-- Problem 15. User Email Providers
SELECT
    [Username]
    ,SUBSTRING([Email], CHARINDEX('@', [Email]) + 1, LEN([Email])) AS [Email Provider]
FROM [Users]
ORDER BY [Email Provider], [Username]
GO

-- Problem 16. Get Users with IPAdress Like Pattern
SELECT
    [Username]
    ,[IpAddress] AS [IP Address]
FROM [Users]
WHERE [IpAddress] LIKE '___.1_%._%.___'
ORDER BY [Username]
GO

-- Problem 17. Show All Games with Duration and Part of the Day
SELECT
    [Name] AS [Game]
    ,CASE
        WHEN DATEPART(HOUR, [Start]) BETWEEN 0 AND 11 THEN 'Morning'
        WHEN DATEPART(HOUR, [Start]) BETWEEN 12 AND 17 THEN 'Afternoon'
        ELSE 'Evening'
    END AS [Part of the day]
    ,CASE
        WHEN [g].[Duration] <= 3 THEN 'Extra Short'
        WHEN [g].[Duration] <= 6 THEN 'Short'
        WHEN [g].[Duration] > 6 THEN 'Long'
        ELSE 'Extra Long'
    END AS [Duration]
FROM [Games] as [g]
ORDER BY [Name], [Duration], [Part of the day]
GO