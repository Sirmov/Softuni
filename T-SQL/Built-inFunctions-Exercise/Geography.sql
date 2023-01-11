USE [Geography]
GO

-- Problem 12.Countries Holding ‘A’ 3 or More Times
SELECT
    [CountryName]
    ,[IsoCode]
FROM [Countries]
WHERE LOWER([CountryName]) LIKE '%a%a%a%'
ORDER BY [IsoCode]
GO

-- Problem 13. Mix of Peak and River Names
SELECT
    [p].[PeakName]
    ,[r].[RiverName]
    ,LOWER(CONCAT([p].[PeakName], SUBSTRING([r].[RiverName], 2, LEN([r].[RiverName]) - 1))) AS [Mix]
FROM [Peaks] AS [p], [Rivers] AS [r]
WHERE RIGHT([p].[PeakName], 1) = LEFT([r].[RiverName], 1)
ORDER BY [Mix]
GO