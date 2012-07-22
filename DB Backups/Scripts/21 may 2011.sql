USE [TheNuggetList]
GO

-- create the comments table
-- *************************

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Comment](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[ContentTypeID] [bigint] NOT NULL,
	[ContentObjectPK] [bigint] NOT NULL,
	[Content] [nvarchar](max) NOT NULL,
	[Created] [datetime] NOT NULL,
 CONSTRAINT [PK_Comment] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


-- add created column to nuggets table
ALTER TABLE dbo.Nugget
ADD Created datetime NULL

UPDATE dbo.Nugget
SET Created = GETDATE()

ALTER TABLE dbo.Nugget
ALTER COLUMN Created datetime NOT NULL
