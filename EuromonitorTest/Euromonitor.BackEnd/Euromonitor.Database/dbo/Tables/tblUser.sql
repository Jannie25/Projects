CREATE TABLE [dbo].[tblUser] (
    [UserId]    INT           IDENTITY (1, 1) NOT NULL,
    [Password]  VARCHAR (50)  NULL,
    [Username]  VARCHAR (50)  NULL,
    [Email]     VARCHAR (255) NULL,
    [FirstName] VARCHAR (255) NULL,
    [LastName]  VARCHAR (255) NULL,
    CONSTRAINT [PK_tblUser] PRIMARY KEY CLUSTERED ([UserId] ASC)
);

