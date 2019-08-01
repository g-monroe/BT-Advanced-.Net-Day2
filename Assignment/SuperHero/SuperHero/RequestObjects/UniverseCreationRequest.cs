using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuperHero.RequestObjects
{
    public class UniverseCreationRequest
    {
            public String UniverseName { get; set; }
            public int Id { get; set; }
            public String ParentCompany { get; set; }

    }
}
