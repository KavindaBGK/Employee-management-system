CREATE TABLE [dbo].[Employees] (
    [EmpID]   INT NOT NULL,
    [FName]   VARCHAR(50) NULL,
    [LName]   VARCHAR(50) NULL,
    [Age]     INT            NOT NULL,
    [Address] VARCHAR(50) NULL, 
    CONSTRAINT [PK_Employees] PRIMARY KEY ([EmpID])
);

