USE [Diablo]
GO

-- 13.*Scalar Function: Cash in User Games Odd Rows
CREATE FUNCTION [UFN_CashInUsersGames](@Game NVARCHAR(50))
RETURNS TABLE
AS
RETURN
    SELECT
        SUM([Cash]) AS [SumCash]
    FROM
        (
            SELECT
                ROW_NUMBER() OVER(ORDER BY [ug].[Cash] DESC) AS [RowNumber]
                ,[ug].[Cash]
            FROM [Games] AS [g]
            JOIN [UsersGames] AS [ug]
            ON [g].[Id] = [ug].[GameId]
            WHERE [g].[Name] = @Game
        ) AS [RankingQuery]
    WHERE [RowNumber] % 2 <> 0
GO