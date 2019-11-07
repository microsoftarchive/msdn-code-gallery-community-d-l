/*==================================================================================
// Contoso Cloud Integration Service Layer Solution
//
// The PersistenceQueue database object schema and implementation logic.
//
//==================================================================================
// Copyright © 2011 Microsoft Corporation. All rights reserved.
// 
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY
// OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT
// LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND
// FITNESS FOR A PARTICULAR PURPOSE. YOU BEAR THE RISK OF USING IT.
//=================================================================================*/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_SqlAzurePersistenceQueue_New]') AND type in (N'P', N'PC'))
	DROP PROCEDURE [dbo].[usp_SqlAzurePersistenceQueue_New]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[usp_SqlAzurePersistenceQueue_New]
AS

DECLARE @QueueItemID uniqueidentifier

SET @QueueItemID = NEWID()

INSERT app.PersistenceQueue(QueueItemID, QueueItemDataRaw, QueueItemStatus, QueueItemSize, QueueItemLastUpdated) SELECT @QueueItemID, '', 0 /* Status = New */, 0, getdate()

SELECT @QueueItemID