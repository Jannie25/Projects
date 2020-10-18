CREATE PROCEDURE [dbo].[usp_GetUser]
(
	@Username varchar(50),
	@Password varchar(50)
)
AS
BEGIN
	SELECT	[UserId],
			[Username],
			[Email],
			[FirstName],
			[LastName] 
	FROM	[tblUser]
	WHERE	[Username] = @Username AND
			[Password] = @Password 
END
