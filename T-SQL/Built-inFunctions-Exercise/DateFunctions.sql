-- Problem 18. Orders Table
SELECT
    [ProductName]
    ,[OrderDate]
    ,DATEADD(DAY, 3, [OrderDate]) AS [Pay Due]
    ,DATEADD(MONTH, 1, [OrderDate]) AS [Delivery Due]
FROM [Orders]

-- Problem 19. People Table
SELECT
    [Name]
    ,DATEDIFF(YEAR, [Birthdate], GETDATE()) AS [Age in Years]
    ,DATEDIFF(MONTH, [Birthdate], GETDATE()) AS [Age in Months]
    ,DATEDIFF(DAY, [Birthdate], GETDATE()) AS [Age in Days]
    ,DATEDIFF(MINUTE, [Birthdate], GETDATE()) AS [Age in Minutes]
FROM [People]