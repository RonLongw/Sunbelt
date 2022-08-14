using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PartyPlanner.Models;
using PartyPlanner.Services;

namespace PartyPlanner.Controllers
{
    public class PartyPlannerController : Controller
    {
        // GET: PartyPlanner
        public ActionResult Index()
        {
            List<Models.PartyEvent> events = null;

            var eventService = new PartyEventService();

            events = eventService.getEvents();

            return View(events);
        }

        // GET: PartyPlanner/Create
        public ActionResult Create()
        {
            PartyEvent partyEvent = new PartyEvent();

            return View(partyEvent);
        }

        // POST: PartyPlanner/Create
        [HttpPost]
        public ActionResult Create(Models.PartyEvent partyEvent)
        {
            try
            {
                var eventService = new PartyEventService();

                Database.PartyEvent newEvent = new Database.PartyEvent()
                {
                    EventName = partyEvent.EventName,
                    EventDate = partyEvent.EventDate,
                    DateCreated = DateTime.Now
                };

                eventService.createPartyEvent(newEvent);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: PartyPlanner/Edit/5
        public ActionResult Edit(long id)
        {
            var eventService = new PartyEventService();

            var currentEvent = eventService.getEvent(id);

            return View(currentEvent);
        }

        // POST: PartyPlanner/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, PartyEvent partyEvent)
        {
            try
            {
                var eventService = new PartyEventService();

                var current = new Database.PartyEvent()
                {
                    EventId = partyEvent.EventId,
                    EventName = partyEvent.EventName,
                    EventDate = partyEvent.EventDate
                };

                var success = eventService.updatePartyEvent(current);

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
            var eventService = new PartyEventService();

            var currentEvent = eventService.getEvent(id);

            return View(currentEvent);
        }

        // POST: PartyPlanner/Delete/5
        [HttpPost]
        public ActionResult DeletePartyEvent(long id)
        {
            try
            {
                var eventService = new PartyEventService();

                var success = eventService.deletePartyEvent(id);

                if (success)
                {
                    return RedirectToAction("Index");
                }

                var partyEvent = eventService.getEvent(id);
                
                return View(partyEvent);
            }
            catch
            {
                return View();
            }
        }
    }
}
