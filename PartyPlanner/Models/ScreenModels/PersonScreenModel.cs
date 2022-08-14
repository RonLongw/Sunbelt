using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PartyPlanner.Models.ScreenModels
{
    public class PersonScreenModel
    {
        public Person Person { get; set; }

        public List<FavoriteDrink> FavoriteDrinks { get; set; }
    }
}