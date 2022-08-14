CREATE TABLE [dbo].[PersonType] (
    [PersonTypeId]    INT           IDENTITY (1, 1) NOT NULL,
    [TypeName]        NVARCHAR (50) NOT NULL,
    [TypeDescription] NVARCHAR (50) NULL,
    CONSTRAINT [PK_PersonType] PRIMARY KEY CLUSTERED ([PersonTypeId] ASC)
);

