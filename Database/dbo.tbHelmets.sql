CREATE TABLE [dbo].[tbHelmets] (
    [Id]               INT          NOT NULL,
    [SerialNumber]    VARCHAR (50) NOT NULL,
    [Brand]            VARCHAR (50) NOT NULL,
    [Model]            VARCHAR (50) NOT NULL,
    [Color]            VARCHAR (50) NOT NULL,
    [Size]             VARCHAR (50) NOT NULL,
    [ManufactureDate] VARCHAR (50) NOT NULL,
    [Due Date]         VARCHAR (50) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

