CREATE TABLE [dbo].[Person] (
    [PersonId]        BIGINT         IDENTITY (1, 1) NOT NULL,
    [FirstName]       NVARCHAR (50)  NOT NULL,
    [LastName]        NVARCHAR (100) NOT NULL,
    [FriendlyName]    NVARCHAR (50)  NULL,
    [PersonTypeId]    INT            NOT NULL,
    [EventId]         BIGINT         NOT NULL,
    [FavoriteDrinkId] INT            NULL,
    CONSTRAINT [PK_Person] PRIMARY KEY CLUSTERED ([PersonId] ASC),
    CONSTRAINT [FK_Person_Event] FOREIGN KEY ([EventId]) REFERENCES [dbo].[PartyEvent] ([EventId]),
    CONSTRAINT [FK_Person_FavoriteDrink] FOREIGN KEY ([FavoriteDrinkId]) REFERENCES [dbo].[FavoriteDrink] ([FavoriteDrinkId]),
    CONSTRAINT [FK_Person_PersonType] FOREIGN KEY ([PersonTypeId]) REFERENCES [dbo].[PersonType] ([PersonTypeId])
);

