CREATE TABLE [dbo].[Table] (
    [Id]           INT           IDENTITY (1, 1) NOT NULL,
    [LicencePlate] NVARCHAR (7)  NOT NULL,
    [Brand]        NVARCHAR (15) NOT NULL,
    [Name]         NVARCHAR (20) NOT NULL,
    [Available]    BIT           NOT NULL,
    [Description]  TEXT          NULL,
    [Image]        VARBINARY(MAX)         NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

