CREATE TABLE [dbo].[tbClients] (
    [Id]    INT           NOT NULL,
    [Name]  NVARCHAR (50) NOT NULL,
    [Phone] VARCHAR (50)  NOT NULL,
    [Email] VARCHAR (50)  NOT NULL,
    [Acadamy] VARCHAR(50) NOT NULL, 
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

