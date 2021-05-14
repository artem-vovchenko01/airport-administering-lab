using System.Collections.Generic;

namespace Entities
{
    public class Carrier : AbstractEntity
    {
        public string Name { get; set; } 
        
        public virtual List<Route> Routes { get; set; }
    }
}