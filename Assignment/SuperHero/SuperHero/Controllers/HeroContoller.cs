using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SuperHero.ResponseObjects;

namespace SuperHero.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HeroController : ControllerBase
    {

        [HttpGet]
        public HeroList GetList()
        {
            var hero = WebApiAssignment.Datastore.SuperheroHandler.GetSuperheroes();
            var resp = new HeroList();
            resp.TotalCount = hero.Count;
            resp.Items = hero.Select(x => new ResponseObjects.HeroItem() { superheroName = x.SuperheroName, abilities = x.Abilities, isAlien= x.Alien, originStory = x.OriginStory, secretIdentity = x.SecretIdentity, ageAtOrigin = x.AgeAtOrigin, yearOfAppearance = x.YearOfAppearance, universeId = x.UniverseId, Id = x.Id }).ToList();
            return resp;
        }
        [HttpGet("{Id}")]
        public WebApiAssignment.Datastore.DataModels.Superhero Gethero(int id)
        {
            if (!HeroManager.HeroExists(id))
            {
                return null;
            }
            return WebApiAssignment.Datastore.SuperheroHandler.GetSuperhero(id);
        }
        [HttpPost]
        public WebApiAssignment.Datastore.DataModels.Superhero AddHero(RequestObjects.HeroCreationRequest request)
        {
            if (UniverseManager.UniExists(request.universeId))
            {
                return null;
            }
            var hero = new WebApiAssignment.Datastore.DataModels.Superhero();
            HeroManager.setupHero(request, hero);
            WebApiAssignment.Datastore.SuperheroHandler.AddSuperhero(hero);
            return hero;
        }
        [HttpPut("{id}")]
        public WebApiAssignment.Datastore.DataModels.Superhero UpdateHero([FromRoute] int id, [FromBody]RequestObjects.HeroCreationRequest request)
        {
            var hero = WebApiAssignment.Datastore.SuperheroHandler.GetSuperhero(id);
            if (!HeroManager.HeroExists(id))
            {
                return null;
            }
            HeroManager.setupHero(request, hero);
            WebApiAssignment.Datastore.SuperheroHandler.UpdateSuperhero(hero);
            return hero;
        }
        [HttpDelete("{id}")]
        public void DeleteHero([FromRoute] int id)
        {
            WebApiAssignment.Datastore.SuperheroHandler.DeleteSuperhero(id);
        }
    }
}
