USE [Bank]
GO

-- 9.Find Full Name
CREATE PROC [USP_GetHoldersFullName]
AS
BEGIN
    SELECT
        CONCAT([FirstName], ' ', [LastName]) AS [FullName]
    FROM [AccountHolders]
END
GO

-- 10.People with Balance Higher Than
CREATE PROC [USP_GetHoldersWithBalanceHigherThan] @Balance MONEY
AS
BEGIN
    SELECT
        [FirstName]
        ,[LastName]
    FROM [AccountHolders] AS [ah]
    JOIN [Accounts] AS [a]
    ON [ah].[Id] = [a].[AccountHolderId]
    GROUP BY [FirstName], [LastName]
    HAVING SUM([a].[Balance]) > @Balance
    ORDER BY [ah].[FirstName] ASC, [ah].[LastName] ASC
END
GO

-- 11.Future Value Function
CREATE FUNCTION [UFN_CalculateFutureValue](@Sum DECIMAL(18, 4), @YearlyInterest FLOAT, @Years INT)
RETURNS DECIMAL(18, 4)
AS
BEGIN
    DECLARE @FutureValue DECIMAL(18, 4)
    SET @FutureValue = @Sum * POWER((1 + @YearlyInterest), @Years)
    RETURN ROUND(@FutureValue, 4)
END
GO

-- 12.Calculating Interest
CREATE PROC [USP_CalculateFutureValueForAccount] @AccountId INT, @InterestRate FLOAT
AS
BEGIN
    SELECT TOP 1
        [ah].[Id]
        ,[FirstName]
        ,[LastName]
        ,[Balance] AS [Current Balance]
        ,[dbo].[UFN_CalculateFutureValue]([Balance], 0.1, 5) AS [Balance in 5 years]
    FROM [AccountHolders] AS [ah]
    JOIN [Accounts] AS [a]
    ON [ah].[Id] = [a].[AccountHolderId]
    WHERE [ah].[Id] = 1
END
GO