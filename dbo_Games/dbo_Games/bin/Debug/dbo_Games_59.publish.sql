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
The type for column AOver25 in table [dbo].[Games] is currently  DECIMAL (18, 2) NULL but is being changed to  DECIMAL (18) NULL. Data loss could occur.

The type for column ATOver25 in table [dbo].[Games] is currently  DECIMAL (18, 2) NULL but is being changed to  DECIMAL (18) NULL. Data loss could occur.

The type for column Coeff_1 in table [dbo].[Games] is currently  DECIMAL (18, 4) NULL but is being changed to  DECIMAL (18, 2) NULL. Data loss could occur.

The type for column Coeff_2 in table [dbo].[Games] is currently  DECIMAL (18, 4) NULL but is being changed to  DECIMAL (18, 2) NULL. Data loss could occur.

The type for column Coeff_GG in table [dbo].[Games] is currently  DECIMAL (18, 4) NULL but is being changed to  DECIMAL (18, 2) NULL. Data loss could occur.

The type for column Coeff_NG in table [dbo].[Games] is currently  DECIMAL (18, 4) NULL but is being changed to  DECIMAL (18, 2) NULL. Data loss could occur.

The type for column Coeff_O05 in table [dbo].[Games] is currently  DECIMAL (18, 4) NULL but is being changed to  DECIMAL (18, 2) NULL. Data loss could occur.

The type for column Coeff_O15 in table [dbo].[Games] is currently  DECIMAL (18, 4) NULL but is being changed to  DECIMAL (18, 2) NULL. Data loss could occur.

The type for column Coeff_O25 in table [dbo].[Games] is currently  DECIMAL (18, 4) NULL but is being changed to  DECIMAL (18, 2) NULL. Data loss could occur.

The type for column Coeff_U25 in table [dbo].[Games] is currently  DECIMAL (18, 4) NULL but is being changed to  DECIMAL (18, 2) NULL. Data loss could occur.

The type for column Coeff_U35 in table [dbo].[Games] is currently  DECIMAL (18, 4) NULL but is being changed to  DECIMAL (18, 2) NULL. Data loss could occur.

The type for column Coeff_U45 in table [dbo].[Games] is currently  DECIMAL (18, 4) NULL but is being changed to  DECIMAL (18, 2) NULL. Data loss could occur.

The type for column Coeff_X in table [dbo].[Games] is currently  DECIMAL (18, 4) NULL but is being changed to  DECIMAL (18, 2) NULL. Data loss could occur.

The type for column HOver25 in table [dbo].[Games] is currently  DECIMAL (18, 2) NULL but is being changed to  DECIMAL (18) NULL. Data loss could occur.

The type for column TB%GG in table [dbo].[Games] is currently  DECIMAL (18, 2) NULL but is being changed to  DECIMAL (18) NULL. Data loss could occur.

The type for column TGG in table [dbo].[Games] is currently  DECIMAL (18, 2) NULL but is being changed to  DECIMAL (18) NULL. Data loss could occur.

The type for column TOver25 in table [dbo].[Games] is currently  DECIMAL (18, 2) NULL but is being changed to  DECIMAL (18) NULL. Data loss could occur.
*/

IF EXISTS (select top 1 1 from [dbo].[Games])
    RAISERROR (N'Rows were detected. The schema update is terminating because data loss might occur.', 16, 127) WITH NOWAIT

GO
PRINT N'Starting rebuilding table [dbo].[Games]...';


GO
BEGIN TRANSACTION;

SET TRANSACTION ISOLATION LEVEL SERIALIZABLE;

SET XACT_ABORT ON;

CREATE TABLE [dbo].[tmp_ms_xx_Games] (
    [Id]        INT             IDENTITY (1, 1) NOT NULL,
    [Date]      CHAR (20)       NOT NULL,
    [Time]      TIME (7)        NOT NULL,
    [Game]      NCHAR (50)      NOT NULL,
    [Bet]       NCHAR (10)      NOT NULL,
    [Result]    INT             NULL,
    [1]         INT             NULL,
    [2]         INT             NULL,
    [Coeff_1]   DECIMAL (18, 2) NULL,
    [Coeff_X]   DECIMAL (18, 2) NULL,
    [Coeff_2]   DECIMAL (18, 2) NULL,
    [Coeff_GG]  DECIMAL (18, 2) NULL,
    [Coeff_NG]  DECIMAL (18, 2) NULL,
    [Coeff_O05] DECIMAL (18, 2) NULL,
    [Coeff_O15] DECIMAL (18, 2) NULL,
    [Coeff_O25] DECIMAL (18, 2) NULL,
    [Coeff_U25] DECIMAL (18, 2) NULL,
    [Coeff_U35] DECIMAL (18, 2) NULL,
    [Coeff_U45] DECIMAL (18, 2) NULL,
    [HOver25]   DECIMAL (18)    NULL,
    [TOver25]   DECIMAL (18)    NULL,
    [HGG]       DECIMAL (18)    NULL,
    [TGG]       DECIMAL (18)    NULL,
    [AOver25]   DECIMAL (18)    NULL,
    [AGG]       DECIMAL (18)    NULL,
    [ATOver25]  DECIMAL (18)    NULL,
    [ATGG]      DECIMAL (18)    NULL,
    [TB%GG]     DECIMAL (18)    NULL,
    [Val1]      DECIMAL (18, 4) NOT NULL,
    [Val2]      DECIMAL (18, 4) NOT NULL,
    [Val3]      DECIMAL (18, 4) NOT NULL,
    [Val4]      DECIMAL (18, 4) NOT NULL,
    [ValB1]     DECIMAL (18, 4) NOT NULL,
    [ValB2]     DECIMAL (18, 4) NOT NULL,
    [ValB3]     DECIMAL (18, 4) NOT NULL,
    [ValB4]     DECIMAL (18, 4) NOT NULL,
    [Sval1]     DECIMAL (18, 4) NOT NULL,
    [Sval2]     DECIMAL (18, 4) NOT NULL,
    [Sval3]     DECIMAL (18, 4) NOT NULL,
    [Sval4]     DECIMAL (18, 4) NOT NULL,
    [SvalB1]    DECIMAL (18, 4) NOT NULL,
    [SvalB2]    DECIMAL (18, 4) NOT NULL,
    [SvalB3]    DECIMAL (18, 4) NOT NULL,
    [SvalB4]    DECIMAL (18, 4) NOT NULL,
    [Fval1]     DECIMAL (18, 4) NOT NULL,
    [Fval2]     DECIMAL (18, 4) NOT NULL,
    [Fval3]     DECIMAL (18, 4) NOT NULL,
    [Fval4]     DECIMAL (18, 4) NOT NULL,
    [FvalB1]    DECIMAL (18, 4) NOT NULL,
    [FvalB2]    DECIMAL (18, 4) NOT NULL,
    [FvalB3]    DECIMAL (18, 4) NOT NULL,
    [FvalB4]    DECIMAL (18, 4) NOT NULL,
    [F8val1]    DECIMAL (18, 4) NOT NULL,
    [F8val2]    DECIMAL (18, 4) NOT NULL,
    [F8val3]    DECIMAL (18, 4) NOT NULL,
    [F8val4]    DECIMAL (18, 4) NOT NULL,
    [F8valB1]   DECIMAL (18, 4) NOT NULL,
    [F8valB2]   DECIMAL (18, 4) NOT NULL,
    [F8valB3]   DECIMAL (18, 4) NOT NULL,
    [F8valB4]   DECIMAL (18, 4) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

IF EXISTS (SELECT TOP 1 1 
           FROM   [dbo].[Games])
    BEGIN
        SET IDENTITY_INSERT [dbo].[tmp_ms_xx_Games] ON;
        INSERT INTO [dbo].[tmp_ms_xx_Games] ([Id], [Date], [Time], [Game], [Bet], [Result], [1], [2], [Coeff_1], [Coeff_X], [Coeff_2], [Coeff_GG], [Coeff_NG], [Coeff_O05], [Coeff_O15], [Coeff_O25], [Coeff_U25], [Coeff_U35], [Coeff_U45], [HOver25], [TOver25], [TGG], [AOver25], [ATOver25], [TB%GG], [Val1], [Val2], [Val3], [Val4], [ValB1], [ValB2], [ValB3], [ValB4], [Sval1], [Sval2], [Sval3], [Sval4], [SvalB1], [SvalB2], [SvalB3], [SvalB4], [Fval1], [Fval2], [Fval3], [Fval4], [FvalB1], [FvalB2], [FvalB3], [FvalB4], [F8val1], [F8val2], [F8val3], [F8val4], [F8valB1], [F8valB2], [F8valB3], [F8valB4])
        SELECT   [Id],
                 [Date],
                 [Time],
                 [Game],
                 [Bet],
                 [Result],
                 [1],
                 [2],
                 CAST ([Coeff_1] AS DECIMAL (18, 2)),
                 CAST ([Coeff_X] AS DECIMAL (18, 2)),
                 CAST ([Coeff_2] AS DECIMAL (18, 2)),
                 CAST ([Coeff_GG] AS DECIMAL (18, 2)),
                 CAST ([Coeff_NG] AS DECIMAL (18, 2)),
                 CAST ([Coeff_O05] AS DECIMAL (18, 2)),
                 CAST ([Coeff_O15] AS DECIMAL (18, 2)),
                 CAST ([Coeff_O25] AS DECIMAL (18, 2)),
                 CAST ([Coeff_U25] AS DECIMAL (18, 2)),
                 CAST ([Coeff_U35] AS DECIMAL (18, 2)),
                 CAST ([Coeff_U45] AS DECIMAL (18, 2)),
                 CAST ([HOver25] AS DECIMAL (18)),
                 CAST ([TOver25] AS DECIMAL (18)),
                 CAST ([TGG] AS DECIMAL (18)),
                 CAST ([AOver25] AS DECIMAL (18)),
                 CAST ([ATOver25] AS DECIMAL (18)),
                 CAST ([TB%GG] AS DECIMAL (18)),
                 [Val1],
                 [Val2],
                 [Val3],
                 [Val4],
                 [ValB1],
                 [ValB2],
                 [ValB3],
                 [ValB4],
                 [Sval1],
                 [Sval2],
                 [Sval3],
                 [Sval4],
                 [SvalB1],
                 [SvalB2],
                 [SvalB3],
                 [SvalB4],
                 [Fval1],
                 [Fval2],
                 [Fval3],
                 [Fval4],
                 [FvalB1],
                 [FvalB2],
                 [FvalB3],
                 [FvalB4],
                 [F8val1],
                 [F8val2],
                 [F8val3],
                 [F8val4],
                 [F8valB1],
                 [F8valB2],
                 [F8valB3],
                 [F8valB4]
        FROM     [dbo].[Games]
        ORDER BY [Id] ASC;
        SET IDENTITY_INSERT [dbo].[tmp_ms_xx_Games] OFF;
    END

DROP TABLE [dbo].[Games];

EXECUTE sp_rename N'[dbo].[tmp_ms_xx_Games]', N'Games';

COMMIT TRANSACTION;

SET TRANSACTION ISOLATION LEVEL READ COMMITTED;


GO
PRINT N'Update complete.';


GO