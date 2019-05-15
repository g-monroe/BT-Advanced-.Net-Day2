using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuperHero.RequestObjects
{
    public class HeroCreationRequest
    {
        public string superheroName { get; set; }
        public string secretIdentity { get; set; }
        public int? ageAtOrigin { get; set; }
        public int yearOfAppearance { get; set; }
        public bool isAlien { get; set; }
        public string originStory { get; set; }
        public int universeId { get; set; }
        public int Id { get; set; }
        public List<String> abilities { get; set; }
    }
}
