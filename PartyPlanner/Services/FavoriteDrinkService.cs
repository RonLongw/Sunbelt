using PartyPlanner.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PartyPlanner.Services
{
    public class FavoriteDrinkService
    {
        public List<Models.FavoriteDrink> getFavoriteDrinks()
        {
            List<Models.FavoriteDrink> drinks = null;

            using (PartyPlannerEntities db = new PartyPlannerEntities())
            {
                drinks = (from fd in db.FavoriteDrinks
                          select new Models.FavoriteDrink()
                          {
                              FavoriteDrinkId = fd.FavoriteDrinkId,
                              DrinkName = fd.DrinkName,
                              DrinkDescription = fd.DrinkDescription
                          }).ToList();
            }

            return drinks;
        }
    }
}