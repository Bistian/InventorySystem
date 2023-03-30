CREATE TABLE [dbo].[tbJackets] (
    [JacketID]        INT          NOT NULL,
    [Type]            VARCHAR (50) NOT NULL,
    [SerialNum]       VARCHAR (50) NOT NULL,
    [Brand]           VARCHAR (50) NOT NULL,
    [Size]            VARCHAR (50) NOT NULL,
    [ManufactureDate] VARCHAR (50) NOT NULL,
    [Location]        VARCHAR (50) NOT NULL,
    [DueDate]         VARCHAR (50) NULL,
    [Model] VARCHAR(50) NOT NULL, 
    PRIMARY KEY CLUSTERED ([JacketID] ASC)
);

