using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PartyPlanner.Database;

namespace PartyPlanner.Services
{
    public class PersonService
    {
        public Models.Person getPerson(long personId)
        {
            Models.Person person = null;

            using (PartyPlannerEntities db = new PartyPlannerEntities())
            {
                person = (from p in db.People.Where(p => p.PersonId == personId)
                          select new Models.Person()
                          {
                              PersonId = p.PersonId,
                              FirstName = p.FirstName,
                              LastName = p.LastName,
                              FriendlyName = p.FriendlyName,
                              EventId = p.EventId,
                              FavoriteDrinkId = p.FavoriteDrinkId,
                              PersonTypeId = p.PersonTypeId
                          }).SingleOrDefault();
            }

            return person;
        }

        public List<Models.Person> getPeople(long eventId)
        {
            List<Models.Person> people = null;

            using (PartyPlannerEntities db = new PartyPlannerEntities())
            {
                people = (from p in db.People.Where(p => p.EventId == eventId)
                            select new Models.Person()
                            {
                                PersonId = p.PersonId,
                                FirstName = p.FirstName,
                                LastName = p.LastName,
                                FriendlyName = p.FriendlyName,
                                EventId = p.EventId,
                                FavoriteDrinkId = p.FavoriteDrinkId,
                                PersonTypeId = p.PersonTypeId
                            }).ToList();
            }

            return people;
        }

        public bool createPerson(Person person)
        {
            using (PartyPlannerEntities db = new PartyPlannerEntities())
            {
                if (person.PersonId == 0)
                {
                    db.People.Add(person);
                    db.SaveChanges();

                    return true;
                }
            }
            return false;
        }

        public bool updatePerson(Person person)
        {
            using (PartyPlannerEntities db = new PartyPlannerEntities())
            {
                var current = db.People.Where(p => p.PersonId == person.PersonId).SingleOrDefault();

                if (current != null)
                {
                    current.FirstName = person.FirstName;
                    current.LastName = person.LastName;
                    current.FriendlyName = person.FriendlyName;
                    current.EventId = person.EventId;
                    current.FavoriteDrinkId = person.FavoriteDrinkId;
                    current.PersonTypeId = person.PersonTypeId;

                    db.SaveChanges();

                    return true;
                }
            }

            return false;
        }

        public bool deletePerson(long id)
        {
            using (PartyPlannerEntities db = new PartyPlannerEntities())
            {
                var current = db.People.Where(p => p.PersonId == id).SingleOrDefault();

                if (current != null)
                {
                    db.People.Remove(current);

                    db.SaveChanges();

                    return true;
                }
            }

            return false;
        }
    }
}