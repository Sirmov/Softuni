USE [Geography]
GO

-- 12.Highest Peaks in Bulgaria
SELECT
    [c].[CountryCode]
    ,[m].[MountainRange]
    ,[p].[PeakName]
    ,[p].[Elevation]
FROM [Countries] AS [c]
JOIN [MountainsCountries] AS [mc]
ON [c].[CountryCode] = [mc].[CountryCode]
JOIN [Mountains] AS [m]
ON [mc].[MountainId] = [m].[Id]
JOIN [Peaks] AS [p]
ON [m].[ID]= [p].[MountainId]
WHERE [c].[CountryCode] = 'BG'
    AND [p].[Elevation] > 2835
ORDER BY [p].[Elevation] DESC
GO

-- 13.Count Mountain Ranges
SELECT
    [c].[CountryCode]
    ,COUNT([mc].[MountainId]) AS [MountainRanges]
FROM [Countries] AS [c]
LEFT JOIN [MountainsCountries] AS [mc]
ON [c].[CountryCode] = [mc].[CountryCode]
WHERE [c].[CountryCode] IN ('BG', 'RU', 'US')
GROUP BY [c].[CountryCode]
GO

-- 14.Countries With or Without Rivers
SELECT TOP 5
    [c].[CountryName]
    ,[r].[RiverName]
FROM [Countries] AS [c]
LEFT JOIN [CountriesRivers] AS [cr]
ON [c].[CountryCode] = [cr].[CountryCode]
LEFT JOIN [Rivers] AS [r]
ON [cr].[RiverId] = [r].[Id]
JOIN [Continents] AS [con]
ON [c].[ContinentCode] = [con].[ContinentCode]
WHERE [con].[ContinentCode] = 'AF'
ORDER BY [c].[CountryName] ASC
GO

-- 15.*Continents and Currencies
WITH [CTE_CurrencyUsage_By_Continent_Country] ([ContinentCode], [CurrencyCode], [CurrencyUsage])
AS
(
    SELECT
        [con].[ContinentCode]
        ,[cur].[CurrencyCode]
        ,COUNT([c].[CountryName])
    FROM [Countries] AS [c]
    JOIN [Currencies] AS [cur]
    ON [c].[CurrencyCode] = [cur].[CurrencyCode]
    JOIN [Continents] AS [con]
    ON [c].[ContinentCode] = [con].[ContinentCode]
    GROUP BY [con].[ContinentCode], [cur].[CurrencyCode]
)

SELECT
    [ContinentCode]
    ,[CurrencyCode]
    ,[CurrencyUsage]
FROM
    (
        SELECT
            *
            ,DENSE_RANK() OVER (PARTITION BY [ContinentCode] ORDER BY [CurrencyUsage] DESC)
            AS [CurrencyRank]
        FROM [CTE_CurrencyUsage_By_Continent_Country]
        WHERE [CurrencyUsage] > 1
    ) AS [SUBQ_RankingCurrencyUsage_By_Continent]
WHERE [CurrencyRank] = 1
ORDER BY [ContinentCode]

-- 16.Countries Without any Mountains
SELECT
    COUNT([c].[CountryCode])
FROM [Countries] AS [c]
LEFT JOIN [MountainsCountries] AS [mc]
ON [c].[CountryCode] = [mc].[CountryCode]
WHERE [mc].[MountainId] IS NULL
GO

-- 17.Highest Peak and Longest River by Country
WITH [CTE_HeighestPeak_LogestRiver_By_Country] ([CountryName], [HighestPeakElevation], [LongestRiverLength])
AS
(
    SELECT
        [c].[CountryName]
        ,MAX([p].[Elevation])
        ,MAX([r].[Length])
    FROM [Countries] AS [c]
    LEFT JOIN [MountainsCountries] AS [mc]
    ON [c].[CountryCode] = [mc].[CountryCode]
    LEFT JOIN [Mountains] AS [m]
    ON [mc].[MountainId] = [m].[Id]
    LEFT JOIN [Peaks] AS [p]
    ON [m].[Id] = [p].[MountainId]
    LEFT JOIN [CountriesRivers] AS [cr]
    ON [c].[CountryCode] = [cr].[CountryCode]
    LEFT JOIN [Rivers] AS [r]
    ON [cr].[RiverId] = [r].[Id]
    GROUP BY [c].[CountryName]
)

SELECT TOP 5
    *
FROM [CTE_HeighestPeak_LogestRiver_By_Country]
ORDER BY [HighestPeakElevation] DESC, [LongestRiverLength] DESC, [CountryName] ASC
GO

-- 18.Highest Peak Name and Elevation by Country
WITH [CTE_Peak_Ranking] ([Country], [PeakName], [Elevation], [MountainRange], [PeakRank])
AS
(
SELECT
    [CountryName]
    ,COALESCE([PeakName], '(no highest peak)') AS [PeakName]
    ,COALESCE([Elevation], 0) AS [Elevation]
    ,COALESCE([MountainRange], '(no mountain)') AS [MountainRange]
    ,RANK() OVER (PARTITION BY [CountryName] ORDER BY [Elevation] DESC) AS [PeakRank]
FROM [Countries] AS [c]
LEFT JOIN [MountainsCountries] AS [mc]
ON [c].[CountryCode] = [mc].[CountryCode]
LEFT JOIN [Mountains] AS [m]
ON [mc].[MountainId] = [m].[Id]
LEFT JOIN [Peaks] AS [p]
ON [m].[Id] = [p].[MountainId]
)

SELECT TOP 5
    [Country]
    ,[PeakName] AS [Highest Peak Name]
    ,[Elevation] AS [Highest Peak Elevation]
    ,[MountainRange] AS [Mountain]
FROM [CTE_Peak_Ranking]
WHERE [PeakRank] = 1
ORDER BY [Country] ASC, [PeakName] ASC
GO