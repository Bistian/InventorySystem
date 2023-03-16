CREATE TABLE [dbo].[tbInventory] (
    [Id]               INT           NOT NULL,
    [Item Type]        VARCHAR (50)  NULL,
    [Serial Number]    VARCHAR(50)           NULL,
    [Brand]            NVARCHAR (50) NULL,
    [Size]             VARCHAR(50)    NULL,
    [Manufacture Date] VARCHAR (50)  NULL,
    [Due Date]         VARCHAR (50)  NULL,
    [Location]         VARCHAR (50)  NULL,
    [Color]            NVARCHAR (50) NULL,
    [Rubber / Leather] VARCHAR (50)  NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

