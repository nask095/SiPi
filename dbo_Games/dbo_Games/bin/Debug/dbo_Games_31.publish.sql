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
PRINT N'Altering [dbo].[Games]...';


GO
ALTER TABLE [dbo].[Games] ALTER COLUMN [F8val1] DECIMAL (50, 4) NOT NULL;

ALTER TABLE [dbo].[Games] ALTER COLUMN [F8val2] DECIMAL (50, 4) NOT NULL;

ALTER TABLE [dbo].[Games] ALTER COLUMN [F8val3] DECIMAL (50, 4) NOT NULL;

ALTER TABLE [dbo].[Games] ALTER COLUMN [F8val4] DECIMAL (50, 4) NOT NULL;

ALTER TABLE [dbo].[Games] ALTER COLUMN [F8valB1] DECIMAL (50, 4) NOT NULL;

ALTER TABLE [dbo].[Games] ALTER COLUMN [F8valB2] DECIMAL (50, 4) NOT NULL;

ALTER TABLE [dbo].[Games] ALTER COLUMN [F8valB3] DECIMAL (50, 4) NOT NULL;

ALTER TABLE [dbo].[Games] ALTER COLUMN [F8valB4] DECIMAL (50, 4) NOT NULL;

ALTER TABLE [dbo].[Games] ALTER COLUMN [Fval1] DECIMAL (50, 4) NOT NULL;

ALTER TABLE [dbo].[Games] ALTER COLUMN [Fval2] DECIMAL (50, 4) NOT NULL;

ALTER TABLE [dbo].[Games] ALTER COLUMN [Fval3] DECIMAL (50, 4) NOT NULL;

ALTER TABLE [dbo].[Games] ALTER COLUMN [Fval4] DECIMAL (50, 4) NOT NULL;

ALTER TABLE [dbo].[Games] ALTER COLUMN [FvalB1] DECIMAL (50, 4) NOT NULL;

ALTER TABLE [dbo].[Games] ALTER COLUMN [FvalB2] DECIMAL (50, 4) NOT NULL;

ALTER TABLE [dbo].[Games] ALTER COLUMN [FvalB3] DECIMAL (50, 4) NOT NULL;

ALTER TABLE [dbo].[Games] ALTER COLUMN [FvalB4] DECIMAL (50, 4) NOT NULL;

ALTER TABLE [dbo].[Games] ALTER COLUMN [Sval1] DECIMAL (50, 4) NOT NULL;

ALTER TABLE [dbo].[Games] ALTER COLUMN [Sval2] DECIMAL (50, 4) NOT NULL;

ALTER TABLE [dbo].[Games] ALTER COLUMN [Sval3] DECIMAL (50, 4) NOT NULL;

ALTER TABLE [dbo].[Games] ALTER COLUMN [Sval4] DECIMAL (50, 4) NOT NULL;

ALTER TABLE [dbo].[Games] ALTER COLUMN [SvalB1] DECIMAL (50, 4) NOT NULL;

ALTER TABLE [dbo].[Games] ALTER COLUMN [SvalB2] DECIMAL (50, 4) NOT NULL;

ALTER TABLE [dbo].[Games] ALTER COLUMN [SvalB3] DECIMAL (50, 4) NOT NULL;

ALTER TABLE [dbo].[Games] ALTER COLUMN [SvalB4] DECIMAL (50, 4) NOT NULL;

ALTER TABLE [dbo].[Games] ALTER COLUMN [Val1] DECIMAL (50, 4) NOT NULL;

ALTER TABLE [dbo].[Games] ALTER COLUMN [Val2] DECIMAL (50, 4) NOT NULL;

ALTER TABLE [dbo].[Games] ALTER COLUMN [Val3] DECIMAL (50, 4) NOT NULL;

ALTER TABLE [dbo].[Games] ALTER COLUMN [Val4] DECIMAL (50, 4) NOT NULL;

ALTER TABLE [dbo].[Games] ALTER COLUMN [ValB1] DECIMAL (50, 4) NOT NULL;

ALTER TABLE [dbo].[Games] ALTER COLUMN [ValB2] DECIMAL (50, 4) NOT NULL;

ALTER TABLE [dbo].[Games] ALTER COLUMN [ValB3] DECIMAL (50, 4) NOT NULL;

ALTER TABLE [dbo].[Games] ALTER COLUMN [ValB4] DECIMAL (50, 4) NOT NULL;


GO
PRINT N'Altering [dbo].[Games2]...';


GO
ALTER TABLE [dbo].[Games2]
    ADD [Coeff] NCHAR (50) NULL;


GO
PRINT N'Creating [dbo].[Games3]...';


GO
CREATE TABLE [dbo].[Games3] (
    [Id]      INT             IDENTITY (1, 1) NOT NULL,
    [Date]    CHAR (20)       NOT NULL,
    [Time]    TIME (7)        NOT NULL,
    [Game]    NCHAR (50)      NOT NULL,
    [Bet]     NCHAR (10)      NOT NULL,
    [Result]  INT             NULL,
    [Val1]    DECIMAL (18, 4) NOT NULL,
    [Val2]    DECIMAL (18, 4) NOT NULL,
    [Val3]    DECIMAL (18, 4) NOT NULL,
    [Val4]    DECIMAL (18, 4) NOT NULL,
    [ValB1]   DECIMAL (18, 4) NOT NULL,
    [ValB2]   DECIMAL (18, 4) NOT NULL,
    [ValB3]   DECIMAL (18, 4) NOT NULL,
    [ValB4]   DECIMAL (18, 4) NOT NULL,
    [Sval1]   DECIMAL (18, 4) NOT NULL,
    [Sval2]   DECIMAL (18, 4) NOT NULL,
    [Sval3]   DECIMAL (18, 4) NOT NULL,
    [Sval4]   DECIMAL (18, 4) NOT NULL,
    [SvalB1]  DECIMAL (18, 4) NOT NULL,
    [SvalB2]  DECIMAL (18, 4) NOT NULL,
    [SvalB3]  DECIMAL (18, 4) NOT NULL,
    [SvalB4]  DECIMAL (18, 4) NOT NULL,
    [Fval1]   DECIMAL (18, 4) NOT NULL,
    [Fval2]   DECIMAL (18, 4) NOT NULL,
    [Fval3]   DECIMAL (18, 4) NOT NULL,
    [Fval4]   DECIMAL (18, 4) NOT NULL,
    [FvalB1]  DECIMAL (18, 4) NOT NULL,
    [FvalB2]  DECIMAL (18, 4) NOT NULL,
    [FvalB3]  DECIMAL (18, 4) NOT NULL,
    [FvalB4]  DECIMAL (18, 4) NOT NULL,
    [F8val1]  DECIMAL (18, 4) NOT NULL,
    [F8val2]  DECIMAL (18, 4) NOT NULL,
    [F8val3]  DECIMAL (18, 4) NOT NULL,
    [F8val4]  DECIMAL (18, 4) NOT NULL,
    [F8valB1] DECIMAL (18, 4) NOT NULL,
    [F8valB2] DECIMAL (18, 4) NOT NULL,
    [F8valB3] DECIMAL (18, 4) NOT NULL,
    [F8valB4] DECIMAL (18, 4) NOT NULL,
    [Coeff]   NCHAR (50)      NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
PRINT N'Update complete.';


GO
