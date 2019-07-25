USE [pubs]
GO

/****** Object:  StoredProcedure [dbo].[SP_ListAuthorsByLastNamePaged]    Script Date: 3/4/2015 1:39:25 PM ******/
DROP PROCEDURE [dbo].[SP_ListAuthorsByLastNamePaged]
GO

/****** Object:  StoredProcedure [dbo].[SP_ListAuthorsByLastNamePaged]    Script Date: 3/4/2015 1:39:25 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SP_ListAuthorsByLastNamePaged] 
	@lastName varchar(40),
	@startRow int,
	@numberOfRows int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	SELECT * FROM
	(
		SELECT [au_id]
		      ,[au_lname]
		      ,[au_fname]
		      ,[phone]
		      ,[address]
		      ,[city]
		      ,[state]
		      ,[zip]
		      ,[contract]
			  ,ROW_NUMBER() OVER(ORDER BY [au_lname], [au_fname]) AS rowNum
		  FROM [dbo].[authors]
		  WHERE [au_lname] LIKE @lastName
	  ) AS A
	  WHERE rowNum BETWEEN @startRow AND (@startRow + @numberOfRows - 1)

	 SELECT COUNT(1) AS NumberOfAuthors
		FROM [dbo].[authors]
		WHERE [au_lname] LIKE @lastName

END

GO


