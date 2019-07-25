USE [pubs]
GO

/****** Object:  UserDefinedTableType [dbo].[udtPublisher]    Script Date: 3/4/2015 4:34:40 PM ******/
DROP TYPE [dbo].[udtPublisher]
GO

/****** Object:  UserDefinedTableType [dbo].[udtPublisher]    Script Date: 3/4/2015 4:34:40 PM ******/
CREATE TYPE [dbo].[udtPublisher] AS TABLE(
	[PublisherID] [char](4) NOT NULL,
	[Name] [varchar](40) NULL,
	[City] [varchar](20) NULL,
	[State] [char](2) NULL,
	[Country] [varchar](30) NULL,
	PRIMARY KEY CLUSTERED 
(
	[PublisherID] ASC
)WITH (IGNORE_DUP_KEY = OFF)
)
GO


