CREATE TABLE [dbo].[tbHelmets] (
    [HelmetID]        INT          IDENTITY (1, 1) NOT NULL,
    [SerialNumber]    VARCHAR (50) NOT NULL,
    [Brand]           VARCHAR (50) NOT NULL,
    [Model]           VARCHAR (50) NOT NULL,
    [Color]           VARCHAR (50) NOT NULL,
    [Size]            VARCHAR (50) NOT NULL,
    [ManufactureDate] VARCHAR (50) NOT NULL,
    [Due Date]        VARCHAR (50) NULL,
    [Location] VARCHAR(50) NOT NULL, 
    [Type] VARCHAR(50) NOT NULL, 
    PRIMARY KEY CLUSTERED ([HelmetID] ASC)
);

