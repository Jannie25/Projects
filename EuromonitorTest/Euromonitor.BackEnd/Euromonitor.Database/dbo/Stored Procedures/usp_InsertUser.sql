CREATE PROCEDURE [dbo].[usp_InsertUser]
(
	@Username varchar(50),
	@Password varchar(50),
	@Email varchar(50),
	@FirstName varchar(100),
	@LastName varchar(100)
)
AS
BEGIN
	INSERT INTO [tblUser]
	(
		[Username],
		[Password],
		[Email],
		[FirstName],
		[LastName] 
	)
	VALUES
	(
		@Username,
		@Password,
		@Email,
		@FirstName,
		@LastName 
	)
END
