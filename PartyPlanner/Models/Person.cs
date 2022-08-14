using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PartyPlanner.Models
{
    public class Person
    {
        public long PersonId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FriendlyName { get; set; }
        public int PersonTypeId { get; set; }
        public long EventId { get; set; }
        public Nullable<int> FavoriteDrinkId { get; set; }
    }
}