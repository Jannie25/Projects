CREATE PROCEDURE usp_GetBooks
AS
BEGIN
	SELECT	[BookId],
			[Name], 
			[Text], 
			[PurchasePrice], 
			[CheckOutUserId], 
			[CheckOutUserName] 
	FROM	[tblBook]
END
