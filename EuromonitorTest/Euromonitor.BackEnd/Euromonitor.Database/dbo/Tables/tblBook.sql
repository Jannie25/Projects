CREATE TABLE [dbo].[tblBook] (
    [BookId]           INT           IDENTITY (1, 1) NOT NULL,
    [Name]             VARCHAR (255) NOT NULL,
    [Text]             VARCHAR (255) NULL,
    [PurchasePrice]    MONEY         NOT NULL,
    [CheckOutUserId]   INT           NULL,
    [CheckOutUserName] VARCHAR (255) NULL,
    CONSTRAINT [PK_tblBook] PRIMARY KEY CLUSTERED ([BookId] ASC)
);

