CREATE TABLE [dbo].[tbInventory] (
    [Id]               INT           NOT NULL,
    [Item Type]        VARCHAR (50)  NOT NULL,
    [Serial Number]    INT           NOT NULL,
    [Brand]            NVARCHAR (50) NOT NULL,
    [Size]             FLOAT (53)    NOT NULL,
    [Manufacture Date] VARCHAR (50)  NOT NULL,
    [Due Date]         VARCHAR (50)  NOT NULL,
    [Location]         VARCHAR (50)  NOT NULL,
    [Color]            NVARCHAR (50) NULL,
    [Rubber / Leather] VARCHAR (50)  NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

