CREATE TABLE [dbo].[tbPants] (
    [PantsID]         INT          NOT NULL,
    [Type]            VARCHAR (50) NOT NULL,
    [SerialNum]       VARCHAR (50) NOT NULL,
    [Brand]           VARCHAR (50) NOT NULL,
    [Size]            VARCHAR (50) NOT NULL,
    [ManufactureDate] VARCHAR (50) NOT NULL,
    [Due Date]        VARCHAR (50) NOT NULL,
    [Location]        VARCHAR (50) NOT NULL,
    [Model] NCHAR(10) NULL, 
    PRIMARY KEY CLUSTERED ([PantsID] ASC)
);

