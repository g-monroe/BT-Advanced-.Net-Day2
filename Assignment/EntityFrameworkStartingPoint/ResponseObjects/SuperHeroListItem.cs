namespace EntityFrameworkStartingPoint.Controllers.ResponseObjects
{
    public class SuperHeroListItem
    {
        public int SuperheroId { get; set; }
        public string SuperheroName { get; set; }
        public string SecretIdentity { get; set; }
        public int? AgeAtOrigin { get; set; }
        public int YearOfAppearance { get; set; }
        public bool IsAlien { get; set; }
        public string OriginStory { get; set; }
        public string Universe { get; set; }
        public string[] Abilities { get; set; }
    }
}