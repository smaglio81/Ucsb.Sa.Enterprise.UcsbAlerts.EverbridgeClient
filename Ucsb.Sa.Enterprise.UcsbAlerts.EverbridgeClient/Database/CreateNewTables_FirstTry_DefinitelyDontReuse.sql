use UcsbAlerts
go
/*
Run this script on:

        (local).master    -  This database will be modified

to synchronize it with:

        sql1.dev.sa.ucsb.edu,2433.UcsbAlerts

You are recommended to back up your database before running this script

Script created by SQL Compare version 11.5.2 from Red Gate Software Ltd at 7/26/2016 3:51:47 PM

*/
SET NUMERIC_ROUNDABORT OFF
GO
SET ANSI_PADDING, ANSI_WARNINGS, CONCAT_NULL_YIELDS_NULL, ARITHABORT, QUOTED_IDENTIFIER, ANSI_NULLS ON
GO
SET XACT_ABORT ON
GO
SET TRANSACTION ISOLATION LEVEL SERIALIZABLE
GO
BEGIN TRANSACTION
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating [Alert].[UCSB_Alert_UserID]'
GO
CREATE TABLE [Alert].[UCSB_Alert_UserID]
(
[UCSB_Alert_UserID_ID] [int] NOT NULL IDENTITY(1, 1),
[UCSB_Campus_ID] [char] (36) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[Perm_Nbr] [char] (7) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[UserID] [bigint] NOT NULL,
[Delete_Date] [datetime2] NULL,
[Create_Date] [datetime2] NULL CONSTRAINT [DF__Student_U__Creat__7FF5EA39] DEFAULT (getdate()),
[Last_Update_Date] [datetime2] NULL CONSTRAINT [DF__Student_U__Last___00EA0E78] DEFAULT (getdate()),
[Contact_Email] [varchar] (75) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[First_Name] [varchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[Last_Name] [varchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL
)
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating primary key [PK_Alert.UCSB_Alert_UserID] on [Alert].[UCSB_Alert_UserID]'
GO
ALTER TABLE [Alert].[UCSB_Alert_UserID] ADD CONSTRAINT [PK_Alert.UCSB_Alert_UserID] PRIMARY KEY CLUSTERED  ([UCSB_Alert_UserID_ID])
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating index [IDX_UCSB_Alert_User_ID_UCSB_Alert_UserID_ID_UCSB_Campus_ID] on [Alert].[UCSB_Alert_UserID]'
GO
CREATE NONCLUSTERED INDEX [IDX_UCSB_Alert_User_ID_UCSB_Alert_UserID_ID_UCSB_Campus_ID] ON [Alert].[UCSB_Alert_UserID] ([UCSB_Alert_UserID_ID], [UCSB_Campus_ID])
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating index [IDX_UCSB_Alert_UserID_Perm_Nbr] on [Alert].[UCSB_Alert_UserID]'
GO
CREATE NONCLUSTERED INDEX [IDX_UCSB_Alert_UserID_Perm_Nbr] ON [Alert].[UCSB_Alert_UserID] ([Perm_Nbr])
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating index [IDX_UCSB_Alert_User_ID_User_ID] on [Alert].[UCSB_Alert_UserID]'
GO
CREATE UNIQUE NONCLUSTERED INDEX [IDX_UCSB_Alert_User_ID_User_ID] ON [Alert].[UCSB_Alert_UserID] ([UserID])
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating index [IDX_UCSB_Alert_User_ID_Create_Date] on [Alert].[UCSB_Alert_UserID]'
GO
CREATE NONCLUSTERED INDEX [IDX_UCSB_Alert_User_ID_Create_Date] ON [Alert].[UCSB_Alert_UserID] ([Create_Date])
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating [Alert].[Alert_Audit_Log]'
GO
CREATE TABLE [Alert].[Alert_Audit_Log]
(
[Alert_Audit_Log_ID] [int] NOT NULL IDENTITY(1, 1),
[HostAddress] [varchar] (25) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[PermNbr] [char] (7) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[Date] [datetime2] NOT NULL CONSTRAINT [DF_Alert_Add_Exceptions_Exception_Date] DEFAULT (getdate()),
[ActionType] [varchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[Successful] [bit] NOT NULL,
[ActionCompletedMessage] [nvarchar] (max) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[StackTrace] [nvarchar] (max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL
)
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating primary key [PK_Alert_Add_Exceptions] on [Alert].[Alert_Audit_Log]'
GO
ALTER TABLE [Alert].[Alert_Audit_Log] ADD CONSTRAINT [PK_Alert_Add_Exceptions] PRIMARY KEY CLUSTERED  ([Alert_Audit_Log_ID])
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
COMMIT TRANSACTION
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
DECLARE @Success AS BIT
SET @Success = 1
SET NOEXEC OFF
IF (@Success = 1) PRINT 'The database update succeeded'
ELSE BEGIN
	IF @@TRANCOUNT > 0 ROLLBACK TRANSACTION
	PRINT 'The database update failed'
END
GO