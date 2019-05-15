using System.Collections.Generic;

namespace EntityFrameworkStartingPoint.Controllers.ResponseObjects
{
    public class SuperheroListResponse
    {
        public int TotalResults { get; set; }
        public List<SuperHeroListItem> Items { get; set; }
    }
}