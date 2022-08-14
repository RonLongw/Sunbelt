using PartyPlanner.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PartyPlanner.Services
{
    public class PartyEventService
    {
        public List<Models.PartyEvent> getEvents()
        {
            List<Models.PartyEvent> events = null;

            using (PartyPlannerEntities db = new PartyPlannerEntities())
            {
                events = (from pe in db.PartyEvents
                          select new Models.PartyEvent()
                          {
                              EventId = pe.EventId,
                              EventName = pe.EventName,
                              EventDate = pe.EventDate,
                              DateCreated = pe.DateCreated
                          }).ToList();
            }

            return events;
        }

        public Models.PartyEvent getEvent(long id)
        {
            Models.PartyEvent partyEvent = null;

            using (PartyPlannerEntities db = new PartyPlannerEntities())
            {
                var currentEvent = db.PartyEvents.Where(p => p.EventId == id).SingleOrDefault();

                partyEvent = new Models.PartyEvent()
                {
                    EventId = currentEvent.EventId,
                    EventName = currentEvent.EventName,
                    EventDate = currentEvent.EventDate,
                    DateCreated = currentEvent.DateCreated
                };
            }

            return partyEvent;
        }

        public bool createPartyEvent(PartyEvent partyEvent)
        {
            using (PartyPlannerEntities db = new PartyPlannerEntities())
            {
                if (partyEvent.EventId == 0)
                {
                    db.PartyEvents.Add(partyEvent);
                    db.SaveChanges();

                    return true;
                }
            }
            return false;
        }

        public bool updatePartyEvent(PartyEvent partyEvent)
        {
            using (PartyPlannerEntities db = new PartyPlannerEntities())
            {
                var current = db.PartyEvents.Where(p => p.EventId == partyEvent.EventId).SingleOrDefault();

                if (current != null)
                {
                    current.EventDate = partyEvent.EventDate;
                    current.EventName = partyEvent.EventName;

                    db.SaveChanges();

                    return true;
                }                
            }

            return false;
        }

        public bool deletePartyEvent(long id)
        {
            using (PartyPlannerEntities db = new PartyPlannerEntities())
            {
                var current = db.PartyEvents.Where(p => p.EventId == id).SingleOrDefault();

                if (current != null)
                {
                    db.PartyEvents.Remove(current);

                    db.SaveChanges();

                    return true;
                }
            }

            return false;
        }
    }
}