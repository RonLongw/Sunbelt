using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PartyPlanner.Database;

namespace PartyPlanner.Services
{
    public class PersonTypeService
    {
        public List<Models.PersonType> getPersonTypes()
        {
            List<Models.PersonType> personTypes = null;

            using (PartyPlannerEntities db = new PartyPlannerEntities())
            {
                personTypes = (from pt in db.PersonTypes
                                select new Models.PersonType()
                                {
                                    PersonTypeId = pt.PersonTypeId,
                                    TypeName = pt.TypeName,
                                    TypeDescription = pt.TypeDescription
                                }).ToList();
            }

            return personTypes;
        }
         
    }
}