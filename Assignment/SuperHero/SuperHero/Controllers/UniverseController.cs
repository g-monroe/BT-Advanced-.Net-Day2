using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SuperHero.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UniverseController : ControllerBase
    {

        [HttpGet]
        public ResponseObjects.UniverseList GetList()
        {
            var uni = WebApiAssignment.Datastore.UniverseHandler.GetUniverses();
            var resp = new ResponseObjects.UniverseList();
            resp.TotalCount = uni.Count;
            resp.Items = uni.Select(x => new ResponseObjects.UniverseItem() { UniverseName = x.UniverseName, Id = x.Id, ParentCompany = x.ParentCompany }).ToList();
            return resp;
        }
        [HttpGet("{Id}")]
        public WebApiAssignment.Datastore.DataModels.Universe GetUniverse(int id)
        {
            if (!UniverseManager.UniExists(id))
            {
                return null;
            }
            return WebApiAssignment.Datastore.UniverseHandler.GetUniverse(id);
        }
        [HttpGet("{id}/Heroes")]
        public ResponseObjects.HeroList GetUniverseHeros(int id)
        {
            var superheroes= WebApiAssignment.Datastore.SuperheroHandler.GetSuperheroes();
            var heroes = superheroes.Where(x => x.UniverseId == id);
            var resp = new ResponseObjects.HeroList();
            resp.TotalCount = heroes.Count();
            resp.Items = heroes.Select(x => new ResponseObjects.HeroItem() { superheroName = x.SuperheroName, abilities = x.Abilities, isAlien = x.Alien, originStory = x.OriginStory, secretIdentity = x.SecretIdentity, ageAtOrigin = x.AgeAtOrigin, yearOfAppearance = x.YearOfAppearance, universeId = x.UniverseId, Id = x.Id }).ToList();
            return resp;
        }
        [HttpPost]
        public WebApiAssignment.Datastore.DataModels.Universe AddUniverse(RequestObjects.UniverseCreationRequest request)
        {
            var uni = new WebApiAssignment.Datastore.DataModels.Universe();
            UniverseManager.setupUni(request, uni);
            WebApiAssignment.Datastore.UniverseHandler.AddUniverse(uni);
            return uni;
        }
        [HttpPut("{id}")]
        public WebApiAssignment.Datastore.DataModels.Universe UpdateUniverse([FromRoute] int id, [FromBody]RequestObjects.UniverseCreationRequest request)
        {
            var uni = WebApiAssignment.Datastore.UniverseHandler.GetUniverse(id);
            if (!UniverseManager.UniExists(id))
            {
                return null;
            }
            UniverseManager.setupUni(request, uni);
            WebApiAssignment.Datastore.UniverseHandler.UpdateUniverse(uni);
            return uni;
        }
        [HttpDelete("{id}")]
        public void DeleteUniverse([FromRoute]int id)
        {
            var heros = WebApiAssignment.Datastore.SuperheroHandler.GetSuperheroes();
            heros = heros.Where(x => x.UniverseId == id).ToList();
            foreach( WebApiAssignment.Datastore.DataModels.Superhero hero in heros)
            {
                WebApiAssignment.Datastore.SuperheroHandler.DeleteSuperhero(hero.Id);
            }
            WebApiAssignment.Datastore.UniverseHandler.DeleteUniverse(id);
        }
    }
}
