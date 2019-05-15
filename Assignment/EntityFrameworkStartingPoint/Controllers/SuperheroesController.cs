using EntityFrameworkStartingPoint.Controllers.ResponseObjects;
using EntityFrameworkStartingPoint.RequestObjects;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using WebApiAssignment.Datastore.DataModels;

namespace EntityFrameworkStartingPoint.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperheroesController : ControllerBase
    {
        [HttpGet]
        public SuperheroListResponse GetSueprheroes()
        {
            SuperheroListResponse resp = new SuperheroListResponse();
            List<WebApiAssignment.Datastore.DataModels.Superhero> superHeroList = WebApiAssignment.Datastore.SuperheroHandler.GetSuperheroes();

            resp.TotalResults = superHeroList.Count;

            resp.Items = superHeroList.Select(x => new SuperHeroListItem()
            {
                Abilities = x.Abilities.ToArray(),
                AgeAtOrigin = x.AgeAtOrigin,
                IsAlien = x.Alien,
                OriginStory = x.OriginStory,
                SecretIdentity = x.SecretIdentity,
                SuperheroName = x.SuperheroName,
                Universe = WebApiAssignment.Datastore.UniverseHandler.GetUniverse(x.UniverseId).UniverseName,
                SuperheroId = x.Id,
                YearOfAppearance = x.YearOfAppearance
            }).ToList();

            return resp;
        }

        [HttpGet("{id}")]
        public SuperHeroListItem GetSueprhero(int id)
        {
            SuperheroListResponse resp = new SuperheroListResponse();
            Superhero superhero = WebApiAssignment.Datastore.SuperheroHandler.GetSuperhero(id);

            return new SuperHeroListItem()
            {
                Abilities = superhero.Abilities.ToArray(),
                AgeAtOrigin = superhero.AgeAtOrigin,
                IsAlien = superhero.Alien,
                OriginStory = superhero.OriginStory,
                SecretIdentity = superhero.SecretIdentity,
                SuperheroName = superhero.SuperheroName,
                Universe = WebApiAssignment.Datastore.UniverseHandler.GetUniverse(superhero.UniverseId).UniverseName,
                SuperheroId = superhero.Id,
                YearOfAppearance = superhero.YearOfAppearance
            };

        }

        [HttpPost]
        public Superhero AddSuperhero(SuperheroAddRequest request)
        {
            Universe universe = WebApiAssignment.Datastore.UniverseHandler.GetUniverses()
                .First(x => x.UniverseName == request.Universe);

            Superhero response = new Superhero()
            {
                Abilities = request.Abilities.ToList(),
                AgeAtOrigin = request.AgeAtOrigin,
                Alien = request.IsAlien,
                OriginStory = request.OriginStory,
                SecretIdentity = request.SecretIdentity,
                SuperheroName = request.SuperheroName,
                YearOfAppearance = request.YearOfAppearance,
                UniverseId = universe.Id
            };
            WebApiAssignment.Datastore.SuperheroHandler.AddSuperhero(response);
            return response;
        }

        [HttpPut("{id}")]
        public Superhero UpdateSuperhero(int id, SuperheroAddRequest request)
        {
            Universe universe = WebApiAssignment.Datastore.UniverseHandler.GetUniverses()
                .First(x => x.UniverseName == request.Universe);

            Superhero response = WebApiAssignment.Datastore.SuperheroHandler.GetSuperhero(id);

            response.Abilities = request.Abilities.ToList();
            response.AgeAtOrigin = request.AgeAtOrigin;
            response.Alien = request.IsAlien;
            response.OriginStory = request.OriginStory;
            response.SecretIdentity = request.SecretIdentity;
            response.SuperheroName = request.SuperheroName;
            response.YearOfAppearance = request.YearOfAppearance;
            response.UniverseId = universe.Id;

            WebApiAssignment.Datastore.SuperheroHandler.UpdateSuperhero(response);
            return response;
        }

        [HttpDelete]
        public void DeleteSuperhero(int id)
        {
            WebApiAssignment.Datastore.SuperheroHandler.DeleteSuperhero(id);
        }
    }
}