CREATE TABLE [dbo].[tbPants] (
    [PantsID]         INT          IDENTITY (1, 1) NOT NULL,
    [Type]            VARCHAR (50) DEFAULT ('Pants') NOT NULL,
    [SerialNumber]    VARCHAR (50) NOT NULL,
    [Brand]           VARCHAR (50) NOT NULL,
    [Size]            VARCHAR (50) NOT NULL,
    [ManufactureDate] DATE NOT NULL,
    [DueDate]        DATE NULL,
    [Location]        VARCHAR (50) DEFAULT ('Fire-Tec') NOT NULL,
    [Model]           VARCHAR (50) NOT NULL,
    PRIMARY KEY CLUSTERED ([PantsID] ASC)
);

