CREATE TABLE [dbo].[FavoriteDrink] (
    [FavoriteDrinkId]  INT            IDENTITY (1, 1) NOT NULL,
    [DrinkName]        NVARCHAR (50)  NOT NULL,
    [DrinkDescription] NVARCHAR (500) NULL,
    CONSTRAINT [PK_FavoriteDrink] PRIMARY KEY CLUSTERED ([FavoriteDrinkId] ASC)
);

