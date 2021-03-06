﻿/*
Deployment script for dbo_Games

This code was generated by a tool.
Changes to this file may cause incorrect behavior and will be lost if
the code is regenerated.
*/

GO
SET ANSI_NULLS, ANSI_PADDING, ANSI_WARNINGS, ARITHABORT, CONCAT_NULL_YIELDS_NULL, QUOTED_IDENTIFIER ON;

SET NUMERIC_ROUNDABORT OFF;


GO
:setvar DatabaseName "dbo_Games"
:setvar DefaultFilePrefix "dbo_Games"
:setvar DefaultDataPath "C:\Users\Atanas\AppData\Local\Microsoft\Microsoft SQL Server Local DB\Instances\MSSQLLocalDB"
:setvar DefaultLogPath "C:\Users\Atanas\AppData\Local\Microsoft\Microsoft SQL Server Local DB\Instances\MSSQLLocalDB"

GO
:on error exit
GO
/*
Detect SQLCMD mode and disable script execution if SQLCMD mode is not supported.
To re-enable the script after enabling SQLCMD mode, execute the following:
SET NOEXEC OFF; 
*/
:setvar __IsSqlCmdEnabled "True"
GO
IF N'$(__IsSqlCmdEnabled)' NOT LIKE N'True'
    BEGIN
        PRINT N'SQLCMD mode must be enabled to successfully execute this script.';
        SET NOEXEC ON;
    END


GO
USE [$(DatabaseName)];


GO
/*
The column [dbo].[Table1].[Bet] is being dropped, data loss could occur.

The column [dbo].[Table1].[Date] is being dropped, data loss could occur.

The column [dbo].[Table1].[F8val1] is being dropped, data loss could occur.

The column [dbo].[Table1].[F8val2] is being dropped, data loss could occur.

The column [dbo].[Table1].[F8val3] is being dropped, data loss could occur.

The column [dbo].[Table1].[F8val4] is being dropped, data loss could occur.

The column [dbo].[Table1].[F8valB1] is being dropped, data loss could occur.

The column [dbo].[Table1].[F8valB2] is being dropped, data loss could occur.

The column [dbo].[Table1].[F8valB3] is being dropped, data loss could occur.

The column [dbo].[Table1].[F8valB4] is being dropped, data loss could occur.

The column [dbo].[Table1].[Fval1] is being dropped, data loss could occur.

The column [dbo].[Table1].[Fval2] is being dropped, data loss could occur.

The column [dbo].[Table1].[Fval3] is being dropped, data loss could occur.

The column [dbo].[Table1].[Fval4] is being dropped, data loss could occur.

The column [dbo].[Table1].[FvalB1] is being dropped, data loss could occur.

The column [dbo].[Table1].[FvalB2] is being dropped, data loss could occur.

The column [dbo].[Table1].[FvalB3] is being dropped, data loss could occur.

The column [dbo].[Table1].[FvalB4] is being dropped, data loss could occur.

The column [dbo].[Table1].[Game] is being dropped, data loss could occur.

The column [dbo].[Table1].[Result] is being dropped, data loss could occur.

The column [dbo].[Table1].[Sval1] is being dropped, data loss could occur.

The column [dbo].[Table1].[Sval2] is being dropped, data loss could occur.

The column [dbo].[Table1].[Sval3] is being dropped, data loss could occur.

The column [dbo].[Table1].[Sval4] is being dropped, data loss could occur.

The column [dbo].[Table1].[SvalB1] is being dropped, data loss could occur.

The column [dbo].[Table1].[SvalB2] is being dropped, data loss could occur.

The column [dbo].[Table1].[SvalB3] is being dropped, data loss could occur.

The column [dbo].[Table1].[SvalB4] is being dropped, data loss could occur.

The column [dbo].[Table1].[Time] is being dropped, data loss could occur.

The column [dbo].[Table1].[Val1] is being dropped, data loss could occur.

The column [dbo].[Table1].[Val2] is being dropped, data loss could occur.

The column [dbo].[Table1].[Val3] is being dropped, data loss could occur.

The column [dbo].[Table1].[Val4] is being dropped, data loss could occur.

The column [dbo].[Table1].[ValB1] is being dropped, data loss could occur.

The column [dbo].[Table1].[ValB2] is being dropped, data loss could occur.

The column [dbo].[Table1].[ValB3] is being dropped, data loss could occur.

The column [dbo].[Table1].[ValB4] is being dropped, data loss could occur.
*/

IF EXISTS (select top 1 1 from [dbo].[Table1])
    RAISERROR (N'Rows were detected. The schema update is terminating because data loss might occur.', 16, 127) WITH NOWAIT

GO
PRINT N'Starting rebuilding table [dbo].[Table1]...';


GO
BEGIN TRANSACTION;

SET TRANSACTION ISOLATION LEVEL SERIALIZABLE;

SET XACT_ABORT ON;

CREATE TABLE [dbo].[tmp_ms_xx_Table1] (
    [Id]   INT        NOT NULL,
    [text] NCHAR (10) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

IF EXISTS (SELECT TOP 1 1 
           FROM   [dbo].[Table1])
    BEGIN
        INSERT INTO [dbo].[tmp_ms_xx_Table1] ([Id])
        SELECT   [Id]
        FROM     [dbo].[Table1]
        ORDER BY [Id] ASC;
    END

DROP TABLE [dbo].[Table1];

EXECUTE sp_rename N'[dbo].[tmp_ms_xx_Table1]', N'Table1';

COMMIT TRANSACTION;

SET TRANSACTION ISOLATION LEVEL READ COMMITTED;


GO
PRINT N'Update complete.';


GO
