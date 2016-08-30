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
The column Bet on table [dbo].[Table1] must be changed from NULL to NOT NULL. If the table contains data, the ALTER script may not work. To avoid this issue, you must add values to this column for all rows or mark it as allowing NULL values, or enable the generation of smart-defaults as a deployment option.

The column Date on table [dbo].[Table1] must be changed from NULL to NOT NULL. If the table contains data, the ALTER script may not work. To avoid this issue, you must add values to this column for all rows or mark it as allowing NULL values, or enable the generation of smart-defaults as a deployment option.

The column F8val1 on table [dbo].[Table1] must be changed from NULL to NOT NULL. If the table contains data, the ALTER script may not work. To avoid this issue, you must add values to this column for all rows or mark it as allowing NULL values, or enable the generation of smart-defaults as a deployment option.

The column F8val2 on table [dbo].[Table1] must be changed from NULL to NOT NULL. If the table contains data, the ALTER script may not work. To avoid this issue, you must add values to this column for all rows or mark it as allowing NULL values, or enable the generation of smart-defaults as a deployment option.

The column F8val3 on table [dbo].[Table1] must be changed from NULL to NOT NULL. If the table contains data, the ALTER script may not work. To avoid this issue, you must add values to this column for all rows or mark it as allowing NULL values, or enable the generation of smart-defaults as a deployment option.

The column F8val4 on table [dbo].[Table1] must be changed from NULL to NOT NULL. If the table contains data, the ALTER script may not work. To avoid this issue, you must add values to this column for all rows or mark it as allowing NULL values, or enable the generation of smart-defaults as a deployment option.

The column F8valB1 on table [dbo].[Table1] must be changed from NULL to NOT NULL. If the table contains data, the ALTER script may not work. To avoid this issue, you must add values to this column for all rows or mark it as allowing NULL values, or enable the generation of smart-defaults as a deployment option.

The column F8valB2 on table [dbo].[Table1] must be changed from NULL to NOT NULL. If the table contains data, the ALTER script may not work. To avoid this issue, you must add values to this column for all rows or mark it as allowing NULL values, or enable the generation of smart-defaults as a deployment option.

The column F8valB3 on table [dbo].[Table1] must be changed from NULL to NOT NULL. If the table contains data, the ALTER script may not work. To avoid this issue, you must add values to this column for all rows or mark it as allowing NULL values, or enable the generation of smart-defaults as a deployment option.

The column F8valB4 on table [dbo].[Table1] must be changed from NULL to NOT NULL. If the table contains data, the ALTER script may not work. To avoid this issue, you must add values to this column for all rows or mark it as allowing NULL values, or enable the generation of smart-defaults as a deployment option.

The column Fval1 on table [dbo].[Table1] must be changed from NULL to NOT NULL. If the table contains data, the ALTER script may not work. To avoid this issue, you must add values to this column for all rows or mark it as allowing NULL values, or enable the generation of smart-defaults as a deployment option.

The column Fval2 on table [dbo].[Table1] must be changed from NULL to NOT NULL. If the table contains data, the ALTER script may not work. To avoid this issue, you must add values to this column for all rows or mark it as allowing NULL values, or enable the generation of smart-defaults as a deployment option.

The column Fval3 on table [dbo].[Table1] must be changed from NULL to NOT NULL. If the table contains data, the ALTER script may not work. To avoid this issue, you must add values to this column for all rows or mark it as allowing NULL values, or enable the generation of smart-defaults as a deployment option.

The column Fval4 on table [dbo].[Table1] must be changed from NULL to NOT NULL. If the table contains data, the ALTER script may not work. To avoid this issue, you must add values to this column for all rows or mark it as allowing NULL values, or enable the generation of smart-defaults as a deployment option.

The column FvalB1 on table [dbo].[Table1] must be changed from NULL to NOT NULL. If the table contains data, the ALTER script may not work. To avoid this issue, you must add values to this column for all rows or mark it as allowing NULL values, or enable the generation of smart-defaults as a deployment option.

The column FvalB2 on table [dbo].[Table1] must be changed from NULL to NOT NULL. If the table contains data, the ALTER script may not work. To avoid this issue, you must add values to this column for all rows or mark it as allowing NULL values, or enable the generation of smart-defaults as a deployment option.

The column FvalB3 on table [dbo].[Table1] must be changed from NULL to NOT NULL. If the table contains data, the ALTER script may not work. To avoid this issue, you must add values to this column for all rows or mark it as allowing NULL values, or enable the generation of smart-defaults as a deployment option.

The column FvalB4 on table [dbo].[Table1] must be changed from NULL to NOT NULL. If the table contains data, the ALTER script may not work. To avoid this issue, you must add values to this column for all rows or mark it as allowing NULL values, or enable the generation of smart-defaults as a deployment option.

The column Game on table [dbo].[Table1] must be changed from NULL to NOT NULL. If the table contains data, the ALTER script may not work. To avoid this issue, you must add values to this column for all rows or mark it as allowing NULL values, or enable the generation of smart-defaults as a deployment option.

The column Sval1 on table [dbo].[Table1] must be changed from NULL to NOT NULL. If the table contains data, the ALTER script may not work. To avoid this issue, you must add values to this column for all rows or mark it as allowing NULL values, or enable the generation of smart-defaults as a deployment option.

The column Sval2 on table [dbo].[Table1] must be changed from NULL to NOT NULL. If the table contains data, the ALTER script may not work. To avoid this issue, you must add values to this column for all rows or mark it as allowing NULL values, or enable the generation of smart-defaults as a deployment option.

The column Sval3 on table [dbo].[Table1] must be changed from NULL to NOT NULL. If the table contains data, the ALTER script may not work. To avoid this issue, you must add values to this column for all rows or mark it as allowing NULL values, or enable the generation of smart-defaults as a deployment option.

The column Sval4 on table [dbo].[Table1] must be changed from NULL to NOT NULL. If the table contains data, the ALTER script may not work. To avoid this issue, you must add values to this column for all rows or mark it as allowing NULL values, or enable the generation of smart-defaults as a deployment option.

The column SvalB1 on table [dbo].[Table1] must be changed from NULL to NOT NULL. If the table contains data, the ALTER script may not work. To avoid this issue, you must add values to this column for all rows or mark it as allowing NULL values, or enable the generation of smart-defaults as a deployment option.

The column SvalB2 on table [dbo].[Table1] must be changed from NULL to NOT NULL. If the table contains data, the ALTER script may not work. To avoid this issue, you must add values to this column for all rows or mark it as allowing NULL values, or enable the generation of smart-defaults as a deployment option.

The column SvalB3 on table [dbo].[Table1] must be changed from NULL to NOT NULL. If the table contains data, the ALTER script may not work. To avoid this issue, you must add values to this column for all rows or mark it as allowing NULL values, or enable the generation of smart-defaults as a deployment option.

The column SvalB4 on table [dbo].[Table1] must be changed from NULL to NOT NULL. If the table contains data, the ALTER script may not work. To avoid this issue, you must add values to this column for all rows or mark it as allowing NULL values, or enable the generation of smart-defaults as a deployment option.

The column Time on table [dbo].[Table1] must be changed from NULL to NOT NULL. If the table contains data, the ALTER script may not work. To avoid this issue, you must add values to this column for all rows or mark it as allowing NULL values, or enable the generation of smart-defaults as a deployment option.

The column Val1 on table [dbo].[Table1] must be changed from NULL to NOT NULL. If the table contains data, the ALTER script may not work. To avoid this issue, you must add values to this column for all rows or mark it as allowing NULL values, or enable the generation of smart-defaults as a deployment option.

The column Val2 on table [dbo].[Table1] must be changed from NULL to NOT NULL. If the table contains data, the ALTER script may not work. To avoid this issue, you must add values to this column for all rows or mark it as allowing NULL values, or enable the generation of smart-defaults as a deployment option.

The column Val3 on table [dbo].[Table1] must be changed from NULL to NOT NULL. If the table contains data, the ALTER script may not work. To avoid this issue, you must add values to this column for all rows or mark it as allowing NULL values, or enable the generation of smart-defaults as a deployment option.

The column Val4 on table [dbo].[Table1] must be changed from NULL to NOT NULL. If the table contains data, the ALTER script may not work. To avoid this issue, you must add values to this column for all rows or mark it as allowing NULL values, or enable the generation of smart-defaults as a deployment option.

The column ValB1 on table [dbo].[Table1] must be changed from NULL to NOT NULL. If the table contains data, the ALTER script may not work. To avoid this issue, you must add values to this column for all rows or mark it as allowing NULL values, or enable the generation of smart-defaults as a deployment option.

The column ValB2 on table [dbo].[Table1] must be changed from NULL to NOT NULL. If the table contains data, the ALTER script may not work. To avoid this issue, you must add values to this column for all rows or mark it as allowing NULL values, or enable the generation of smart-defaults as a deployment option.

The column ValB3 on table [dbo].[Table1] must be changed from NULL to NOT NULL. If the table contains data, the ALTER script may not work. To avoid this issue, you must add values to this column for all rows or mark it as allowing NULL values, or enable the generation of smart-defaults as a deployment option.

The column ValB4 on table [dbo].[Table1] must be changed from NULL to NOT NULL. If the table contains data, the ALTER script may not work. To avoid this issue, you must add values to this column for all rows or mark it as allowing NULL values, or enable the generation of smart-defaults as a deployment option.
*/

IF EXISTS (select top 1 1 from [dbo].[Table1])
    RAISERROR (N'Rows were detected. The schema update is terminating because data loss might occur.', 16, 127) WITH NOWAIT

GO
PRINT N'Altering [dbo].[Table1]...';


GO
ALTER TABLE [dbo].[Table1] ALTER COLUMN [Bet] NCHAR (10) NOT NULL;

ALTER TABLE [dbo].[Table1] ALTER COLUMN [Date] CHAR (20) NOT NULL;

ALTER TABLE [dbo].[Table1] ALTER COLUMN [F8val1] DECIMAL (18, 4) NOT NULL;

ALTER TABLE [dbo].[Table1] ALTER COLUMN [F8val2] DECIMAL (18, 4) NOT NULL;

ALTER TABLE [dbo].[Table1] ALTER COLUMN [F8val3] DECIMAL (18, 4) NOT NULL;

ALTER TABLE [dbo].[Table1] ALTER COLUMN [F8val4] DECIMAL (18, 4) NOT NULL;

ALTER TABLE [dbo].[Table1] ALTER COLUMN [F8valB1] DECIMAL (18, 4) NOT NULL;

ALTER TABLE [dbo].[Table1] ALTER COLUMN [F8valB2] DECIMAL (18, 4) NOT NULL;

ALTER TABLE [dbo].[Table1] ALTER COLUMN [F8valB3] DECIMAL (18, 4) NOT NULL;

ALTER TABLE [dbo].[Table1] ALTER COLUMN [F8valB4] DECIMAL (18, 4) NOT NULL;

ALTER TABLE [dbo].[Table1] ALTER COLUMN [Fval1] DECIMAL (18, 4) NOT NULL;

ALTER TABLE [dbo].[Table1] ALTER COLUMN [Fval2] DECIMAL (18, 4) NOT NULL;

ALTER TABLE [dbo].[Table1] ALTER COLUMN [Fval3] DECIMAL (18, 4) NOT NULL;

ALTER TABLE [dbo].[Table1] ALTER COLUMN [Fval4] DECIMAL (18, 4) NOT NULL;

ALTER TABLE [dbo].[Table1] ALTER COLUMN [FvalB1] DECIMAL (18, 4) NOT NULL;

ALTER TABLE [dbo].[Table1] ALTER COLUMN [FvalB2] DECIMAL (18, 4) NOT NULL;

ALTER TABLE [dbo].[Table1] ALTER COLUMN [FvalB3] DECIMAL (18, 4) NOT NULL;

ALTER TABLE [dbo].[Table1] ALTER COLUMN [FvalB4] DECIMAL (18, 4) NOT NULL;

ALTER TABLE [dbo].[Table1] ALTER COLUMN [Game] NCHAR (50) NOT NULL;

ALTER TABLE [dbo].[Table1] ALTER COLUMN [Sval1] DECIMAL (18, 4) NOT NULL;

ALTER TABLE [dbo].[Table1] ALTER COLUMN [Sval2] DECIMAL (18, 4) NOT NULL;

ALTER TABLE [dbo].[Table1] ALTER COLUMN [Sval3] DECIMAL (18, 4) NOT NULL;

ALTER TABLE [dbo].[Table1] ALTER COLUMN [Sval4] DECIMAL (18, 4) NOT NULL;

ALTER TABLE [dbo].[Table1] ALTER COLUMN [SvalB1] DECIMAL (18, 4) NOT NULL;

ALTER TABLE [dbo].[Table1] ALTER COLUMN [SvalB2] DECIMAL (18, 4) NOT NULL;

ALTER TABLE [dbo].[Table1] ALTER COLUMN [SvalB3] DECIMAL (18, 4) NOT NULL;

ALTER TABLE [dbo].[Table1] ALTER COLUMN [SvalB4] DECIMAL (18, 4) NOT NULL;

ALTER TABLE [dbo].[Table1] ALTER COLUMN [Time] TIME (7) NOT NULL;

ALTER TABLE [dbo].[Table1] ALTER COLUMN [Val1] DECIMAL (18, 4) NOT NULL;

ALTER TABLE [dbo].[Table1] ALTER COLUMN [Val2] DECIMAL (18, 4) NOT NULL;

ALTER TABLE [dbo].[Table1] ALTER COLUMN [Val3] DECIMAL (18, 4) NOT NULL;

ALTER TABLE [dbo].[Table1] ALTER COLUMN [Val4] DECIMAL (18, 4) NOT NULL;

ALTER TABLE [dbo].[Table1] ALTER COLUMN [ValB1] DECIMAL (18, 4) NOT NULL;

ALTER TABLE [dbo].[Table1] ALTER COLUMN [ValB2] DECIMAL (18, 4) NOT NULL;

ALTER TABLE [dbo].[Table1] ALTER COLUMN [ValB3] DECIMAL (18, 4) NOT NULL;

ALTER TABLE [dbo].[Table1] ALTER COLUMN [ValB4] DECIMAL (18, 4) NOT NULL;


GO
PRINT N'Update complete.';


GO