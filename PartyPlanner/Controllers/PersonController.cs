using PartyPlanner.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PartyPlanner.Controllers
{
    public class PersonController : Controller
    {
        // GET: Person
        public ActionResult Index(long partyEventId)
        {
            List<Models.Person> people = null;

            var personService = new PersonService();

            people = personService.getPeople(partyEventId);

            ViewData["partyEventId"] = partyEventId;

            return View(people);
        }

        // GET: Person/Create
        public ActionResult Create(long partyEventId)
        {
            var drinksService = new FavoriteDrinkService();

            Models.ScreenModels.PersonScreenModel person = new Models.ScreenModels.PersonScreenModel()
            {
                Person = new Models.Person()
                {
                    EventId = partyEventId
                },
                FavoriteDrinks = drinksService.getFavoriteDrinks()
            };

            return View(person);
        }

        // POST: Person/Create
        [HttpPost]
        public ActionResult Create(Models.Person person)
        {
            try
            {
                var personService = new PersonService();

                Database.Person newPerson = new Database.Person()
                {
                    FirstName = person.FirstName,
                    LastName = person.LastName,
                    FriendlyName = person.FriendlyName,
                    EventId = person.EventId,
                    FavoriteDrinkId = person.FavoriteDrinkId,
                    PersonTypeId = person.PersonTypeId
                };

                personService.createPerson(newPerson);

                return RedirectToAction("Index", new { partyEventId = person.EventId });
            }
            catch
            {
                return View();
            }
        }

        // GET: PartyPlanner/Edit/5
        public ActionResult Edit(long id)
        {
            var personService = new PersonService();

            var currentPerson = personService.getPerson(id);

            ViewData["partyEventId"] = currentPerson.EventId;

            return View(currentPerson);
        }

        // POST: PartyPlanner/Edit/5
        [HttpPost]
        public ActionResult Edit(Models.Person person)
        {
            try
            {
                var personService = new PersonService();

                var current = new Database.Person()
                {
                    PersonId = person.PersonId,
                    FirstName = person.FirstName,
                    LastName = person.LastName,
                    FriendlyName = person.FriendlyName,
                    EventId = person.EventId,
                    FavoriteDrinkId = person.FavoriteDrinkId,
                    PersonTypeId = person.PersonTypeId
                };

                var success = personService.updatePerson(current);

                if (success)
                {
                    return RedirectToAction("Index");
                }

            }
            catch
            {
                return View();
            }

            return View();
        }

        // GET: PartyPlanner/Delete/5
        public ActionResult Delete(long id)
        {
            var personService = new PersonService();

            var current = personService.getPerson(id);

            return View(current);
        }

        // POST: PartyPlanner/DeletePerson/5
        [HttpPost]
        public ActionResult DeletePerson(long id)
        {
            try
            {
                var personService = new PersonService();

                var success = personService.deletePerson(id);

                if (success)
                {
                    return RedirectToAction("Index");
                }

                var person = personService.getPerson(id);

                return View(person);
            }
            catch
            {
                return View();
            }
        }
    }
}
