USE [pubs]
GO

/****** Object:  StoredProcedure [dbo].[SP_UpdatePublishers]    Script Date: 3/4/2015 4:34:27 PM ******/
DROP PROCEDURE [dbo].[SP_UpdatePublishers]
GO

/****** Object:  StoredProcedure [dbo].[SP_UpdatePublishers]    Script Date: 3/4/2015 4:34:27 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SP_UpdatePublishers] 
	@Publishers dbo.udtPublisher READONLY
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	UPDATE dbo.publishers
	SET pub_name = p.Name,
		city = p.City,
		[state] = p.[State],
		country = p.Country
	FROM dbo.publishers
	INNER JOIN @Publishers AS p
	ON dbo.publishers.pub_id = p.PublisherID
END

GO


