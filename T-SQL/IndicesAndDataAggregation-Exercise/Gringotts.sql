USE [Gringotts]
GO

-- 1.Records’ Count
SELECT
    COUNT(*)
FROM [WizzardDeposits]
GO

-- 2.Longest Magic Wand
SELECT
    MAX([MagicWandSize]) AS [LongestMagicWand]
FROM [WizzardDeposits]
GO

-- 3.Longest Magic Wand Per Deposit Groups
SELECT
    [DepositGroup]
    ,MAX([MagicWandSize]) AS [LongestMagicWand]
FROM [WizzardDeposits]
GROUP BY [DepositGroup]
GO

-- 4.* Smallest Deposit Group Per Magic Wand Size
WITH [CTE_AverageWandSize_By_DepositGroup] ([DepositGroup], [AverageWandSize])
AS
(
    SELECT
        [DepositGroup]
        ,AVG([MagicWandSize]) AS [AverageWandSize]
    FROM [WizzardDeposits]
    GROUP BY [DepositGroup]
)

SELECT TOP 2
    [DepositGroup]
FROM [CTE_AverageWandSize_By_DepositGroup]
ORDER BY [AverageWandSize] ASC
GO

-- 5.Deposits Sum
SELECT
    [DepositGroup]
    ,SUM([DepositAmount]) AS [TotalSum]
FROM [WizzardDeposits]
GROUP BY [DepositGroup]
GO

-- 6.Deposits Sum for Ollivander Family
SELECT
    [DepositGroup]
    ,SUM([DepositAmount]) AS [TotalSum]
FROM [WizzardDeposits]
WHERE [MagicWandCreator] = 'Ollivander family'
GROUP BY [DepositGroup]
GO

-- 7.Deposits Filter
SELECT
    [DepositGroup]
    ,SUM([DepositAmount]) AS [TotalSum]
FROM [WizzardDeposits]
WHERE [MagicWandCreator] = 'Ollivander family'
GROUP BY [DepositGroup]
HAVING SUM([DepositAmount]) < 150000
ORDER BY [TotalSum] DESC
GO

-- 8. Deposit Charge
SELECT
    [DepositGroup]
    ,[MagicWandCreator]
    ,MIN([DepositCharge])
FROM [WizzardDeposits]
GROUP BY [DepositGroup], [MagicWandCreator]
ORDER BY [MagicWandCreator] ASC, [DepositGroup] ASC
GO

-- 9.Age Groups
SELECT
    [AgeGroup]
    ,COUNT(*)
FROM 
    (
        SELECT
            CASE
                WHEN [Age] < 11 THEN '[0-10]'
                WHEN [Age] BETWEEN 11 AND 20 THEN '[11-20]'
                WHEN [Age] BETWEEN 21 AND 30 THEN '[21-30]'
                WHEN [Age] BETWEEN 31 AND 40 THEN '[31-40]'
                WHEN [Age] BETWEEN 41 AND 50 THEN '[41-50]'
                WHEN [Age] BETWEEN 51 AND 60 THEN '[51-60]'
                WHEN [Age] > 60 THEN '[61+]'
            END AS [AgeGroup]
        FROM [WizzardDeposits]
    ) AS [SBQ_AgeGroups]
GROUP BY [AgeGroup]
GO

-- 10.First Letter
SELECT
    [FirstNameFirstLetter]
FROM 
    (
        SELECT
            *
            ,LEFT([FirstName], 1) AS [FirstNameFirstLetter]
        FROM [WizzardDeposits]
    ) AS [SBQ_FirstName_FirstLetter]
WHERE [DepositGroup] = 'Troll Chest'
GROUP BY [FirstNameFirstLetter]
ORDER BY [FirstNameFirstLetter] ASC
GO

-- 11.Average Interest 
SELECT
    [DepositGroup]
    ,[IsDepositExpired]
    ,AVG([DepositInterest]) AS [AverageInterest]
FROM [WizzardDeposits]
WHERE [DepositStartDate] > '01/01/1985'
GROUP BY [DepositGroup], [IsDepositExpired]
ORDER BY [DepositGroup] DESC, [IsDepositExpired] ASC
GO

-- 12.* Rich Wizard, Poor Wizard
SELECT
    SUM([Difference]) AS [SumDifference]
FROM
    (
        SELECT
            [h].[FirstName] AS [Host Wizard]
            ,[h].[DepositAmount] AS [Host Wizard Deposit]
            ,[g].[FirstName] AS [Guest Wizard]
            ,[g].[DepositAmount] AS [Guest Wizard Deposit]
            ,[g].[DepositAmount] - [h].[DepositAmount] AS [Difference]
        FROM [WizzardDeposits] AS [h]
        JOIN [WizzardDeposits] AS [g]
        ON [h].[Id] = [g].[Id] + 1
    ) AS [SBQ_Host_Guest_Deposit]
GO