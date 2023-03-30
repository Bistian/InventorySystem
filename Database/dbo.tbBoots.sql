CREATE TABLE [dbo].[tbBoots] (
    [BootID]          INT          IDENTITY (1, 1) NOT NULL,
    [SerialNumber]    VARCHAR (50) NOT NULL,
    [Brand]           VARCHAR (50) NOT NULL,
    [Size]            VARCHAR (50) NOT NULL,
    [ManufactureDate] DATE NOT NULL,
    [Location]        VARCHAR (50) DEFAULT ('Fire-Tec') NOT NULL,
    [Material]        VARCHAR (50) NOT NULL,
    [Type]            VARCHAR (50) DEFAULT ('Boot') NOT NULL,
    [DueDate]         DATE NULL,
    [Model]           VARCHAR (50) NOT NULL,
    PRIMARY KEY CLUSTERED ([BootID] ASC)
);

