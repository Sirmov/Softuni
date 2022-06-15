USE [Bank]
GO

-- 1.Create Table Logs
CREATE TABLE [Logs]
(
    [LogId] INT PRIMARY KEY IDENTITY
    ,[AccountId] INT FOREIGN KEY REFERENCES [Accounts]([Id]) NOT NULL
    ,[OldSum] MONEY NOT NULL
    ,[NewSum] MONEY NOT NULL
)
GO

CREATE TRIGGER [TR_LogBalanceOnUpdate]
ON [Accounts] AFTER UPDATE
AS
BEGIN
INSERT INTO [Logs] ([AccountId], [OldSum], [NewSum])
SELECT
    [i].[Id]
    ,[d].[Balance]
    ,[i].[Balance]
FROM [inserted] AS [i]
JOIN [deleted] AS [d]
ON [i].[Id] = [d].[Id]
END
GO

-- 2.Create Table Emails
-- NotificationEmails(Id, Recipient, Subject, Body)
CREATE TABLE [NotificationEmails]
(
    [Id] INT PRIMARY KEY IDENTITY
    ,[Recipient] INT FOREIGN KEY REFERENCES [Accounts]([Id]) NOT NULL
    ,[Subject] VARCHAR(70) NOT NULL
    ,[Body] VARCHAR(100) NOT NULL
)
GO

CREATE TRIGGER [TR_EmailOnLog]
ON [Logs] AFTER INSERT
AS
BEGIN
INSERT INTO [NotificationEmails] ([Recipient], [Subject], [Body])
SELECT
    [i].[AccountId]
    ,CONCAT('Balance change for account: ', [i].[AccountId])
    ,CONCAT('On ', GETDATE(), ' your balance was changed from ', [i].[OldSum], ' to ', [i].[NewSum],'.')
FROM [inserted] AS [i]
END
GO

-- 3.Deposit Money
CREATE PROC [USP_DepositMoney] @AccountId INT, @MoneyAmount MONEY
AS
BEGIN
    BEGIN TRANSACTION
    IF (@MoneyAmount < 0)
    BEGIN
        ROLLBACK
    END
    UPDATE [Accounts]
    SET [Balance] += @MoneyAmount
    WHERE [Id] = @AccountId
    COMMIT
END
GO

-- 4.Withdraw Money
CREATE PROC [USP_WithdrawMoney] @AccountId INT, @MoneyAmount MONEY
AS
BEGIN
    BEGIN TRANSACTION
    IF (@MoneyAmount < 0)
    BEGIN
        ROLLBACK
    END
    UPDATE [Accounts]
    SET [Balance] -= @MoneyAmount
    WHERE [Id] = @AccountId
    COMMIT
END
GO

-- 5.Money Transfer
CREATE PROC [USP_TransferMoney] @SenderId INT, @ReceiverId INT, @Amount MONEY
AS
BEGIN
    BEGIN TRANSACTION
    EXEC [dbo].[USP_WithdrawMoney] @SenderId, @Amount
    EXEC [dbo].[USP_DepositMoney] @ReceiverId, @Amount
    COMMIT
END
GO