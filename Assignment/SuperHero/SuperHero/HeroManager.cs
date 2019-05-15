using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuperHero
{
    public class HeroManager
    {
       public static Boolean HeroExists(int id)
        {
            var hero = WebApiAssignment.Datastore.SuperheroHandler.GetSuperhero(id);
            if (hero == null)
            {
                return false;
            }
            return true;
        }
        public static WebApiAssignment.Datastore.DataModels.Superhero setupHero(RequestObjects.HeroCreationRequest request, WebApiAssignment.Datastore.DataModels.Superhero hero)
        {
            hero.Id = request.Id;
            hero.UniverseId = request.universeId;
            hero.Abilities = request.abilities;
            hero.AgeAtOrigin = request.ageAtOrigin;
            hero.YearOfAppearance = request.yearOfAppearance;
            hero.SecretIdentity = request.secretIdentity;
            hero.SuperheroName = request.superheroName;
            hero.Alien = request.isAlien;
            return hero;
        }
     
    }
}
