using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuperHero.ResponseObjects
{
    public class HeroList
    {
        public int TotalCount { get; set; }
        public List<HeroItem> Items { get; set; }
    }
}
