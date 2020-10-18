CREATE PROCEDURE [dbo].[uspCheckInAndOutBook]
(
	@BookId int,
	@CheckOutUserId int = 0, 
	@CheckOutUserName varchar(255) = null 
)
AS
BEGIN
	UPDATE	[tblBook]
	SET		[CheckOutUserId] = @CheckOutUserId, 
			[CheckOutUserName] = @CheckOutUserName
	WHERE	[BookId] = @BookId
END
