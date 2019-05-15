using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntityFrameworkStartingPoint.RequestObjects
{
    public class UniverseAddRequest
    {
        public string UniverseName { get; set; }
        public string ParentCompany { get; set; }
    }
}
