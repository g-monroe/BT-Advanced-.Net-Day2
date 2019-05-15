using System.Collections.Generic;

namespace EntityFrameworkStartingPoint.Controllers.ResponseObjects
{
    public class UniverseListResponse
    {
        public int TotalResults { get; set; }
        public List<UniverseListItem> Items { get; set; }
    }
}