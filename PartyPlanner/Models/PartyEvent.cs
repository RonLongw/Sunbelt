using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PartyPlanner.Models
{
    public class PartyEvent
    {
        public long EventId { get; set; }
        public string EventName { get; set; }
        public Nullable<System.DateTime> EventDate { get; set; }
        public System.DateTime DateCreated { get; set; }
    }
}