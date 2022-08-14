using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PartyPlanner.Models
{
    public class FavoriteDrink
    {
        public int FavoriteDrinkId { get; set; }
        public string DrinkName { get; set; }
        public string DrinkDescription { get; set; }
    }
}