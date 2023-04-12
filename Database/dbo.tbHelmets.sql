CREATE TABLE [dbo].[tbHelmets] (
    [Id]              INT          IDENTITY (1, 1) NOT NULL,
    [ItemType]        VARCHAR (50) DEFAULT ('Helmet') NOT NULL,
    [SerialNumber]    VARCHAR (50) NOT NULL,
    [Brand]           VARCHAR (50) NOT NULL,
    [Model]           VARCHAR (50) NOT NULL,
    [Size]            VARCHAR (50) NOT NULL DEFAULT ('NA'),
    [ManufactureDate] DATE         NOT NULL,
    [DueDate]         DATE         NULL,
    [Location]        VARCHAR (50) DEFAULT ('Fire-Tec') NOT NULL,
    [Color]           VARCHAR (50) NOT NULL
);

