using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuperHero.ResponseObjects
{
    public class UniverseList
    {
        public int TotalCount { get; set; }
        public List<UniverseItem> Items { get; set; }
    }
}
