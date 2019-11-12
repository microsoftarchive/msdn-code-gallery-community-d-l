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
/****** Object:  Table [app].[PersistenceQueue]    Script Date: 08/10/2010 12:15:07 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[app].[PersistenceQueue]') AND type in (N'U'))
	DROP TABLE [app].[PersistenceQueue]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE app.PersistenceQueue
(
	QueueItemID uniqueidentifier NOT NULL,
	QueueItemDataRaw varchar(max) NULL, 
	QueueItemDataXml xml NULL,
	QueueItemDataType varchar(255) NULL, 
	QueueItemStatus tinyint NOT NULL, /* 0 - New, 1 - Enqueuing, 2 - Dequeuing */
	QueueItemSize bigint NOT NULL,
	QueueItemLastUpdated datetime NOT NULL
)
GO

CREATE CLUSTERED INDEX PK_QueueItemID ON app.PersistenceQueue (QueueItemID)
GO

SET ANSI_PADDING OFF
GO