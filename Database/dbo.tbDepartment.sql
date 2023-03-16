CREATE TABLE [dbo].[tbDepartment] (
    [DeptID]      INT          IDENTITY (1, 1) NOT NULL,
    [DeptName]    VARCHAR (50) NOT NULL,
    [ContactName] VARCHAR (50) NOT NULL,
    [Phone]       VARCHAR (50) NOT NULL,
    [Email]       VARCHAR (50) NOT NULL,
    [Address]     VARCHAR (50) NOT NULL,
    [City]        VARCHAR (50) NOT NULL,
    [State]       VARCHAR (50) NOT NULL,
    [Zip]         VARCHAR (50) NOT NULL,
    PRIMARY KEY CLUSTERED ([DeptID] ASC)
);

