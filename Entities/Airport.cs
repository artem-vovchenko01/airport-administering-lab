using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class Airport : AbstractEntity
    {
        [Required]
        public string Name {get; set;}
        [Required]
        public string City {get; set; }
        [Required]
        public string Country { get; set;}
        
        public virtual ICollection<Route> ArrivingRoutes { get; set; }
        public virtual ICollection<Route> DeparturingRoutes { get; set; }
    }
}