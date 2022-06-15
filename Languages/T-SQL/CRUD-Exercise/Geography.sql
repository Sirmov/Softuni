USE [Geography]
GO

-- 22. All Mountain Peaks
SELECT
    [PeakName]
FROM [Peaks]
ORDER BY [PeakName] ASC
GO

-- 23. Biggest Countries by Population
SELECT TOP 30
    [CountryName]
    ,[Population]
FROM [Countries]
WHERE [ContinentCode] = 'EU'
ORDER BY [Population] DESC, [CountryName] ASC
GO

-- 24. *Countries and Currency (Euro / Not Euro)
SELECT
    [CountryName]
    ,[CountryCode]
    ,CASE
        WHEN [CurrencyCode] = 'EUR' THEN 'Euro'
        ELSE 'Not Euro'
    END AS [Currency]
FROM [Countries]
ORDER BY [CountryName] ASC
GO