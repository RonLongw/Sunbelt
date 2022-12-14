USE [Sunbelt]
GO
SET IDENTITY_INSERT [dbo].[FavoriteDrink] ON 

INSERT [dbo].[FavoriteDrink] ([FavoriteDrinkId], [DrinkName], [DrinkDescription]) VALUES (1, N'Whisky', NULL)
INSERT [dbo].[FavoriteDrink] ([FavoriteDrinkId], [DrinkName], [DrinkDescription]) VALUES (2, N'Vodka', NULL)
INSERT [dbo].[FavoriteDrink] ([FavoriteDrinkId], [DrinkName], [DrinkDescription]) VALUES (3, N'Gin', NULL)
INSERT [dbo].[FavoriteDrink] ([FavoriteDrinkId], [DrinkName], [DrinkDescription]) VALUES (4, N'Beer', NULL)
SET IDENTITY_INSERT [dbo].[FavoriteDrink] OFF
GO
SET IDENTITY_INSERT [dbo].[PersonType] ON 

INSERT [dbo].[PersonType] ([PersonTypeId], [TypeName], [TypeDescription]) VALUES (1, N'PartyOrganizer', N'Party Organizer')
INSERT [dbo].[PersonType] ([PersonTypeId], [TypeName], [TypeDescription]) VALUES (2, N'Attendee', N'Person attending the party')
SET IDENTITY_INSERT [dbo].[PersonType] OFF
GO
