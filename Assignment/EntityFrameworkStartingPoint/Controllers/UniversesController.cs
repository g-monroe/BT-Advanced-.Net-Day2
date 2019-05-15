using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EntityFrameworkStartingPoint.Controllers.ResponseObjects;
using EntityFrameworkStartingPoint.RequestObjects;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiAssignment.Datastore.DataModels;

namespace EntityFrameworkStartingPoint.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UniversesController : ControllerBase
    {
        [HttpGet]
        public UniverseListResponse GetUniverses()
        {
            var resp = new UniverseListResponse();
            List<WebApiAssignment.Datastore.DataModels.Universe> universes = WebApiAssignment.Datastore.UniverseHandler.GetUniverses();
            resp.TotalResults = universes.Count;
            resp.Items = universes.Select(x => new UniverseListItem()
            {
                ParentCompany = x.ParentCompany,
                UniverseId = x.Id,
                UniverseName = x.UniverseName
            }).ToList();

            return resp;
        }

        [HttpGet("{id}")]
        public UniverseListItem GetUniverse(int id)
        {
            var resp = new UniverseListResponse();
            var universe = WebApiAssignment.Datastore.UniverseHandler.GetUniverse(id);

            return new UniverseListItem()
            {
                ParentCompany = universe.ParentCompany,
                UniverseId = universe.Id,
                UniverseName = universe.UniverseName
            };
        }

        [HttpPut("{id}")]
        public Universe UpdateUniverse([FromRoute] int id, UniverseAddRequest request)
        {
            var universe = WebApiAssignment.Datastore.UniverseHandler.GetUniverse(id);
            universe.UniverseName = request.UniverseName;
            universe.ParentCompany = request.ParentCompany;
            WebApiAssignment.Datastore.UniverseHandler.UpdateUniverse(universe);
            return universe;
        }

        [HttpPost]
        public Universe AddUniverse(UniverseAddRequest request)
        {
            var universe = new Universe();
            universe.UniverseName = request.UniverseName;
            universe.ParentCompany = request.ParentCompany;
            WebApiAssignment.Datastore.UniverseHandler.AddUniverse(universe);
            return universe;
        }

        [HttpDelete]
        public void DeleteUniverses(int id)
        {
            WebApiAssignment.Datastore.UniverseHandler.DeleteUniverse(id);
        }
    }
}