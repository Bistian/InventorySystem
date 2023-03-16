CREATE TABLE [dbo].[tbInventory] (
    [Id]               INT           NOT NULL,
    [Item Type]        VARCHAR (50)  NULL,
    [Serial Number]    INT           NULL,
    [Brand]            NVARCHAR (50) NULL,
    [Size]             FLOAT (53)    NULL,
    [Manufacture Date] DATE  NULL,
    [Due Date]         DATE  NULL,
    [Location]         VARCHAR (50)  NULL,
    [Color]            NVARCHAR (50) NULL,
    [Rubber / Leather] VARCHAR (50)  NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

