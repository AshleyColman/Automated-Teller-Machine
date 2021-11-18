CREATE TABLE [dbo].[Accounts] (
    [Id]        INT           IDENTITY (1, 1) NOT NULL,
    [FirstName] NVARCHAR (50) NOT NULL,
	[LastName] NVARCHAR (50) NOT NULL,
    [Pin]       INT           NOT NULL,
    [Balance]   DECIMAL (18)  NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

