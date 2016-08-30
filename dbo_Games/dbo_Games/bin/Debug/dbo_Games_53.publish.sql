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
PRINT N'Altering [dbo].[History]...';


GO
ALTER TABLE [dbo].[History]
    ADD [Coeff_1]   DECIMAL (18, 4) NULL,
        [Coeff_X]   DECIMAL (18, 4) NULL,
        [Coeff_2]   DECIMAL (18, 4) NULL,
        [Coeff_GG]  DECIMAL (18, 4) NULL,
        [Coeff_NG]  DECIMAL (18, 4) NULL,
        [Coeff_O05] DECIMAL (18, 4) NULL,
        [Coeff_O15] DECIMAL (18, 4) NULL,
        [Coeff_O25] DECIMAL (18, 4) NULL,
        [Coeff_U25] DECIMAL (18, 4) NULL,
        [Coeff_U35] DECIMAL (18, 4) NULL,
        [Coeff_U45] DECIMAL (18, 4) NULL;


GO
PRINT N'Update complete.';


GO
